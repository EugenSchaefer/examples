using Microsoft.Web.WebPages.OAuth;

namespace Allfacebook.SPA.Example
{
    public static class AuthConfig
    {
        public static void RegisterAuth()
        {
            // Damit sich Benutzer dieser Website mithilfe ihrer Konten von anderen Websites (z. B. Microsoft, Facebook und Twitter) anmelden können,
            // müssen Sie diese Website aktualisieren. Weitere Informationen finden Sie unter "http://go.microsoft.com/fwlink/?LinkID=252166".

            //OAuthWebSecurity.RegisterMicrosoftClient(
            //    clientId: "",
            //    clientSecret: "");

            //OAuthWebSecurity.RegisterTwitterClient(
            //    consumerKey: "",
            //    consumerSecret: "");

            OAuthWebSecurity.RegisterFacebookClient(
                appId: "1375655012679198",
                appSecret: "34c84700a10cdfa5563f397af5236fb1");

            //OAuthWebSecurity.RegisterGoogleClient();
        }
    }
}