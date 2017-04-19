using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Reflection;
using System.Resources;
using System.Threading;
using System.Web;

namespace Test.MVC.Utilities.Localization
{
    public class ResManager
    {
        public static string GetCaption(string id)
        {
            ResourceManager rm = new ResourceManager("Test.MVC.Utilities.Localization.Captions.Captions", Assembly.GetAssembly(typeof(ResManager)));

            string caption = rm.GetString(id, Thread.CurrentThread.CurrentCulture);

            return caption;
        }

        public static string GetText(string textId)
        {
            ResourceManager rm = new ResourceManager("Test.MVC.Utilities.Localization.Text.Text", Assembly.GetAssembly(typeof(ResManager)));

            string caption = rm.GetString(textId, Thread.CurrentThread.CurrentCulture);

            return caption;
        }
    }
}