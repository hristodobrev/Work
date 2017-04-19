using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Test.MVC.Controllers
{
    public class DataController : Controller
    {
        public JsonResult Index()
        {
            var data = new { a = 5, b = "test" };

            return new JsonResult
            {
                Data = data,
                JsonRequestBehavior = JsonRequestBehavior.AllowGet
            };
        }

        public JsonResult Test()
        {
            var data = new { a = 5, b = "test" };

            return new JsonResult
            {
                Data = data,
                JsonRequestBehavior = JsonRequestBehavior.AllowGet
            };
        }

        public JsonResult GetPagesData()
        {
            int[] nums = new int[100];
            for (int i = 0; i < 100; i++)
            {
                nums[i] = i + 1;
            }

            return new JsonResult
            {
                Data = nums,
                JsonRequestBehavior = JsonRequestBehavior.AllowGet
            };
        }
    }
}