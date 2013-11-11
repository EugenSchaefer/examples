using System;
using System.Net;
using System.Net.Http;
using System.Security.Principal;
using System.Threading;
using System.Web;
using System.Web.Http;
using System.Web.Security;
using DotNetOpenAuth.AspNet;
using Microsoft.Web.WebPages.OAuth;
using WebMatrix.WebData;

namespace Allfacebook.SPA.Example.Api
{
    public class LoginController : ApiController
    {
        /// <summary>
        ///     Start a external login operation with the configured oAuth providers
        /// </summary>
        /// <param name="provider">User selected provider</param>
        /// <param name="returnUrl">The return url to this domain</param>
        /// <returns>http response code</returns>
        [HttpGet]
        [AllowAnonymous]
        public HttpResponseMessage ExternalLogin(string provider, string returnUrl, bool pushstate = false)
        {
            try
            {
                // Start oAuth authentication and call the ExternalLoginCallback when returning to this domain
                OAuthWebSecurity.RequestAuthentication(provider,
                                                       "/api/login/ExternalLoginCallback?returnurl=" + returnUrl +
                                                       "&pushstate=" + pushstate);
                return new HttpResponseMessage(HttpStatusCode.OK);
            }
            catch (Exception ex)
            {
                throw new HttpResponseException(Request.CreateErrorResponse(HttpStatusCode.BadRequest,
                                                                            ex.InnerException.Message));
            }
        }

        /// <summary>
        ///     This method will be called when returning from the provider oAuth
        ///     system to get the authentication result data
        /// </summary>
        /// <param name="returnUrl">The return url (Set up in ExternalLogin start method)</param>
        /// <returns>http response</returns>
        [HttpGet]
        [AllowAnonymous]
        public HttpResponseMessage ExternalLoginCallback(string returnUrl, bool pushstate)
        {
            string url = returnUrl ?? "";
            string pushstateHash = pushstate ? "/" : "#";
            try
            {
                AuthenticationResult result = OAuthWebSecurity.VerifyAuthentication();

                //Login successful?
                if (!result.IsSuccessful)
                {
                    HttpResponseMessage response = Request.CreateResponse(HttpStatusCode.Redirect);
                    response.Headers.Location =
                        new Uri("http://" + Request.RequestUri.Authority + pushstateHash +
                                "account/externalloginfailure");
                    return response;
                }

                //User already exists?
                if (OAuthWebSecurity.Login(result.Provider, result.ProviderUserId, createPersistentCookie: false))
                {
                    IPrincipal principal = new GenericPrincipal(new GenericIdentity(result.ProviderUserId), null);
                    Thread.CurrentPrincipal = principal;
                    HttpContext.Current.User = principal;
                    HttpResponseMessage response = Request.CreateResponse(HttpStatusCode.Redirect);
                    response.Headers.Location =
                        new Uri("http://" + Request.RequestUri.Authority + pushstateHash + "/" + url);
                    return response;
                }

                //User already authenticated?
                if (User.Identity.IsAuthenticated)
                {
                    // If the current user is logged in add the new account
                    OAuthWebSecurity.CreateOrUpdateAccount(result.Provider, result.ProviderUserId, User.Identity.Name);
                    HttpResponseMessage response = Request.CreateResponse(HttpStatusCode.Redirect);
                    response.Headers.Location = new Uri("http://" + Request.RequestUri.Authority + pushstateHash + url);
                    return response;
                }
                else //New User
                {
                    //Create User
                    WebSecurity.CreateUserAndAccount(result.UserName, "test");

                    //Create OAuth UserLogin
                    OAuthWebSecurity.CreateOrUpdateAccount(result.Provider, result.ProviderUserId, result.UserName);
                    //Add Roles
                    Roles.AddUsersToRole(new[] {result.UserName}, "User");

                    //Login User
                    OAuthWebSecurity.Login(result.Provider, result.ProviderUserId, createPersistentCookie: false);


                    IPrincipal principal = new GenericPrincipal(new GenericIdentity(result.UserName), null);
                    Thread.CurrentPrincipal = principal;
                    HttpContext.Current.User = principal;

                    HttpResponseMessage response = Request.CreateResponse(HttpStatusCode.Redirect);
                    response.Headers.Location =
                        new Uri("http://" + Request.RequestUri.Authority + pushstateHash +
                                "/" + url);

                    return response;
                }
            }
            catch (Exception ex)
            {
                HttpResponseMessage response = Request.CreateResponse(HttpStatusCode.Redirect);
                response.Headers.Location =
                    new Uri("http://" + Request.RequestUri.Authority + pushstateHash + "login/externalloginfailure");
                return response;
            }
        }

        /// <summary>
        ///     Sign out the authenticated user
        /// </summary>
        /// <returns>Authenticathion object containing the result of the sign out operation</returns>
        [HttpGet]
        [HttpOptions]
        public HttpResponseMessage Logout()
        {
            // Try to sign out
            try
            {
                WebSecurity.Logout();
                Thread.CurrentPrincipal = null;
                HttpContext.Current.User = null;
            }
            catch (MembershipCreateUserException e)
            {
                throw new HttpResponseException(Request.CreateErrorResponse(HttpStatusCode.BadRequest, e.Message));
            }

            return Request.CreateResponse(HttpStatusCode.OK);
        }
    }
}