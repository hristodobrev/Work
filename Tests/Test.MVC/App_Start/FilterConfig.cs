﻿using System;
using System.Globalization;
using System.Threading;
using System.Web;
using System.Web.Mvc;

namespace Test.MVC
{
    public class FilterConfig
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            filters.Add(new HandleErrorAttribute());
        }
    }
}
