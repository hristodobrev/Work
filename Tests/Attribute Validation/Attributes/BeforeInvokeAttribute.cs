namespace Attribute_Validation.Attributes
{
    using System;

    [AttributeUsage(AttributeTargets.All, AllowMultiple = false)]
    class BeforeInvokeAttribute : Attribute
    {
        public BeforeInvokeAttribute()
        {
            Console.WriteLine("BeforeInvokeAttribute Constructor Invoked!");
        }
    }
}
