using System.Web.Mvc;

namespace Allfacebook.SPA.Example.Controllers
{
    public class LoginController : Controller
    {
        public ActionResult Index()
        {
            return PartialView();
        }
    }
}