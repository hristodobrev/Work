using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MVCExamples.Controllers
{
    public class TemplateController : Controller
    {
        public ActionResult Main()
        {
            return View();
        }

        public ActionResult Users()
        {
            return View();
        }

        public ActionResult Messages()
        {
            return View();
        }
    }
}