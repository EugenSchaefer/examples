using System.Web.Mvc;

namespace Allfacebook.SPA.Example.Controllers
{
    public class MessagesController : Controller
    {
        public ActionResult Index()
        {
            return PartialView();
        }
    }
}