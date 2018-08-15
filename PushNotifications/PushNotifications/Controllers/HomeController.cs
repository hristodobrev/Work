using System.Web.Mvc;

namespace PushNotifications.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }

        public ActionResult Chat()
        {
            return View();
        }

        public ActionResult Test(string name, string message)
        {
            ChatHub.BroadCastMessage(name, message);
            return Json(new { name, message });
        }
    }
}