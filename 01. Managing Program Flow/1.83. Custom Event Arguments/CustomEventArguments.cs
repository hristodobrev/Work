using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

class CustomEventArguments
{
    public class MyArgs : EventArgs
    {
        public MyArgs(int value)
        {
            this.Value = value;
        }

        public int Value { get; set; }
    }

    public class Pub
    {
        public event EventHandler<MyArgs> OnChange = delegate { };

        public void Raise()
        {
            OnChange(this, new MyArgs(42));
        }
    }

    static void Main()
    {
        Pub p = new Pub();

        p.OnChange += (sender, e) => Console.WriteLine("Event raised: {0}", e.Value);

        p.Raise();
    }
}