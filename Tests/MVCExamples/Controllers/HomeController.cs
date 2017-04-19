using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace MVCExamples.Controllers
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

        public void AddMessage(string message)
        {
            using (StreamWriter file = System.IO.File.AppendText(@"D:\Logs\messages.txt"))
            {
                file.WriteLine(message);
            }
        }

        public JsonResult GetMessages()
        {
            string text = System.IO.File.ReadAllText(@"D:\Logs\messages.txt");

            return new JsonResult
            {
                Data = new
                {
                    messages = text.Split(new char[] { '\n' }, StringSplitOptions.RemoveEmptyEntries)
                },
                JsonRequestBehavior = JsonRequestBehavior.AllowGet
            };
        }
    }
}