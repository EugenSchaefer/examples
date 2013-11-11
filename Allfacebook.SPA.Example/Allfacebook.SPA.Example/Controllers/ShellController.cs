using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Allfacebook.SPA.Example.Controllers
{
    public class ShellController : Controller
    {
        public ActionResult Index(string returnUrl)
        {
            return PartialView();
        }
    }
}