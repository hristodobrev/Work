using Attribute_Validation.Attributes;
using Attribute_Validation.Models;
using System;
using System.Collections.Generic;
using System.Reflection;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using Attribute_Validation.Utilities;

namespace Attribute_Validation
{
    [BeforeInvoke]
    class AttributeValidation
    {

        [BeforeInvoke]
        static void Main()
        {
            Console.WriteLine("First Line of Main");
            var war = new Warrior()
            {
                Name = "Pesho",
                Health = 120,
                Description = "Very Strong Hero!"
            };

            war.Attack();

            BeforeInvokeAttribute[] type = typeof(AttributeValidation)
                .GetCustomAttributes(typeof(BeforeInvokeAttribute), false)
                .Select(x => x as BeforeInvokeAttribute)
                .ToArray();

            Note note = new Note() { Title = "test" };
        }

        private static void ParserTest()
        {
            var propInfo = GetProperty<Warrior>(warr => warr.Description);

            var warrior = new Warrior() { Name = "Pesho", Health = 100, Description = "Very strong hero!" };
            Console.WriteLine(Parser.GetXML(warrior));
            Console.WriteLine(Parser.GetJSON(warrior));
        }

        private static void AttributeValidationTest()
        {
            List<Warrior> warriors = new List<Warrior>()
            {
                new Warrior()
                { 
                    Name = "Pesho", 
                    Health = 1, 
                    Description = "Very weak hero!"
                },
                new Warrior()
                { 
                    Name = "Gosho", 
                    Health = 100, 
                    //Description = "Weak hero!"
                },
                new Warrior()
                { 
                    Name = "Mariika",
                    Health = 200,
                    Description = "Very strong hero!"
                },
                new Warrior()
                {
                    //Name = "Ivanka",
                    //Health = 100000,
                    Description = "Insanely strong hero!"
                },
            };

            try
            {
                ValidateObjects(warriors);
            }
            catch (AggregateException ex)
            {
                foreach (var innerEx in ex.InnerExceptions)
                {
                    Console.WriteLine(innerEx.Message);
                }
            }

            List<Note> notes = new List<Note>()
            {
                new Note()
                {
                    Title = "Some title",
                    Description = "Some description"
                },
                new Note()
                {
                    Description = "Another description"
                },
                new Note()
                {
                    Title = "Another title",
                },
                new Note()
                {
                    
                },
            };

            try
            {
                ValidateObjects(notes);
            }
            catch (AggregateException ex)
            {
                foreach (var innerEx in ex.InnerExceptions)
                {
                    Console.WriteLine(innerEx.Message);
                }
            }
        }

        [BeforeInvoke]
        private static void ValidateObjects<T>(IEnumerable<T> items)
        {
            Type type = typeof(T);

            IEnumerable<PropertyInfo> requiredProperties = type.GetProperties()
                .Where(x => x.GetCustomAttributes()
                    .Any(y => y is RequiredAttribute));

            IEnumerable<PropertyInfo> requiredIntProperties = type.GetProperties()
                .Where(x => x.GetCustomAttributes()
                    .Any(y => y is RequiredIntAttribute));

            List<Exception> exceptions = new List<Exception>();
            foreach (var item in items)
            {
                foreach (var prop in requiredProperties)
                {
                    if (prop.GetValue(item) == null)
                    {
                        exceptions.Add(new ArgumentNullException(prop.Name, "Property cannot be null."));
                    }
                }

                foreach (var prop in requiredIntProperties)
                {
                    var attr = (RequiredIntAttribute)(prop.GetCustomAttribute(typeof(RequiredIntAttribute)));
                    if (attr.IsEquals)
                    {
                        if ((int)prop.GetValue(item) != attr.Equals)
                        {
                            exceptions.Add(new ArgumentNullException(prop.Name, string.Format("Property must be equals to {0}.", attr.Equals)));
                        }
                    }
                    else
                    {
                        if ((int)prop.GetValue(item) < attr.Min || (int)prop.GetValue(item) > attr.Max)
                        {
                            exceptions.Add(new ArgumentNullException(prop.Name, string.Format("Property must be in range [{0}...{1}].", attr.Min, attr.Max)));
                        }
                    }
                }
            }

            if (exceptions.Count > 0)
            {
                throw new AggregateException(exceptions);
            }
        }

        private static PropertyInfo GetProperty<TEntity>(Expression<Func<TEntity, object>> expression)
        {
            var memberExpression = expression.Body as MemberExpression;

            if (memberExpression == null)
            {
                throw new InvalidOperationException("Not a member access.");
            }

            return memberExpression.Member as PropertyInfo;
        }
    }
}
