using System.Web.Mvc;

namespace Allfacebook.SPA.Example.Controllers
{
    public class DashboardController : Controller
    {
        public ActionResult Index()
        {
            return PartialView();
        }
    }
}