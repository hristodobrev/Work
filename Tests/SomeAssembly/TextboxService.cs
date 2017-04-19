namespace SomeAssembly
{
    using System;
    using System.Linq.Expressions;
    using System.Text;

    public class TextboxService
    {
        public static string TextboxFor<T>(T item, Expression<Func<T, object>> expression)
        {
            var sb = new StringBuilder();
            sb.Append("<input type='text' ");

            var mexpression = expression.Body as MemberExpression;
            var name = string.Format("{0}{1}", mexpression.Member.DeclaringType.Name, mexpression.Member.Name);
            sb.AppendFormat("name='{0}' ", name);

            var func = expression.Compile();
            sb.AppendFormat("value='{0}' />", func(item));

            return sb.ToString();
        }
    }
}
