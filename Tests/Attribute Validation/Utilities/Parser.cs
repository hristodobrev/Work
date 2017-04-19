namespace Attribute_Validation.Utilities
{
    using System;
    using System.Reflection;
    using System.Text;

    public class Parser
    {
        public static string GetJSON<T>(T obj)
        {
            StringBuilder sb = new StringBuilder();

            Type type = obj.GetType();
            sb.AppendLine("{");

            var properties = type.GetProperties();
            foreach (PropertyInfo prop in properties)
            {
                sb.AppendLine(GetJsonProperty(prop.Name, prop.GetValue(obj).ToString()));
            }

            sb.AppendLine("}");
            return sb.ToString();
        }

        public static string GetXML<T>(T obj)
        {
            StringBuilder sb = new StringBuilder();

            Type type = obj.GetType();
            sb.AppendLine(GetOpenningTag(type.Name));

            var properties = type.GetProperties();
            foreach (PropertyInfo prop in properties)
            {
                sb.Append(GetXMLElement(prop.Name, prop.GetValue(obj).ToString(), 4));
            }

            sb.AppendLine(GetClosingTag(type.Name));
            return sb.ToString();
        }

        private static string GetJsonProperty(string propName, string propValue)
        {
            StringBuilder sb = new StringBuilder();

            sb.Append(string.Format("{0}{1}: {2}", new String(' ', 4), propName, propValue));

            return sb.ToString();
        }

        private static string GetXMLElement(string elementName, string elementValue, int indent)
        {
            StringBuilder sb = new StringBuilder();

            sb.AppendLine(GetOpenningTag(elementName, indent));
            sb.AppendLine(string.Format("{0}{1}", new string(' ', indent * 2), elementValue));
            sb.AppendLine(GetClosingTag(elementName, indent));

            return sb.ToString();
        }

        private static string GetOpenningTag(string keyword, int indent = 0)
        {
            return string.Format("{0}<{1}>", new String(' ', indent), keyword);
        }

        private static string GetClosingTag(string keyword, int indent = 0)
        {
            return string.Format("{0}</{1}>", new String(' ', indent), keyword);
        }
    }
}
