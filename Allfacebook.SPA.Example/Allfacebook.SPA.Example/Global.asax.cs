using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;
using Allfacebook.SPA.Example.Models;
using Allfacebook.SPA.Example.Repository;
using AutoMapper;
using WebMatrix.WebData;

namespace Allfacebook.SPA.Example
{
    // Hinweis: Anweisungen zum Aktivieren des klassischen Modus von IIS6 oder IIS7 
    // finden Sie unter "http://go.microsoft.com/?LinkId=9394801".

    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();

            WebApiConfig.Register(GlobalConfiguration.Configuration);
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);
            AuthConfig.RegisterAuth();
            GlobalConfiguration.Configuration.Formatters.XmlFormatter.SupportedMediaTypes.Clear();

            //Automapper Config
            Mapper.CreateMap<Message, MessageModel>();

            if (!WebSecurity.Initialized)
            {
                WebSecurity.InitializeDatabaseConnection("ExampleData", "Users", "Id",
                                                         "UserName", autoCreateTables: true);
            }
        }
    }
}