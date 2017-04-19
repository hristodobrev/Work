using System;
using System.Linq;
using System.Collections.Generic;

class CustomEventAccessor
{

    public class Pub
    {
        public event EventHandler OnChange = delegate { };

        public void Raise()
        {
            var exceptions = new List<Exception>();

            foreach (Delegate handler in OnChange.GetInvocationList())
            {
                try
                {
                    handler.DynamicInvoke(this, EventArgs.Empty);
                }
                catch (Exception e)
                {
                    exceptions.Add(e);
                }
            }

            if (exceptions.Any())
            {
                throw new AggregateException(exceptions);
            }
        }
    }

    static void Main()
    {
        Pub p = new Pub();
        p.OnChange += (sender, e) => Console.WriteLine("Subscriber 1 called.");
        p.OnChange += (sender, e) => { throw new Exception(); };
        p.OnChange += (sender, e) => Console.WriteLine("Subscriber 3 called.");

        try
        {
            p.Raise();
        }
        catch (AggregateException ex)
        {
            Console.WriteLine(ex.InnerExceptions.Count);
        }
    }
}