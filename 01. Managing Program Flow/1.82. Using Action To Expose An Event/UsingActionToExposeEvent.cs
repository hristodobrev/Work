using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

class UsingActionToExposeEvent
{
    public class Pub
    {
        public event Action<string> OnLeave = delegate { };

        public event Action<string> OnEnter = delegate { };

        public Pub()
        {
            this.Clients = new List<string>();
        }

        public List<string> Clients { get; set; }

        public void Enter(string clientName)
        {
            this.Clients.Add(clientName);

            this.OnEnter(clientName);
        }

        public void Leave(string clientName)
        {
            if (!this.Clients.Contains(clientName))
            {
                throw new InvalidOperationException(
                    String.Format("There is no client with name {0} in the pub.", clientName));
            }

            this.Clients.Remove(clientName);

            this.OnLeave(clientName);
        }
    }

    static void Main()
    {
        Pub p = new Pub();
        p.OnLeave += name => Console.WriteLine("EN: Client {0} leaved the pub.", name);
        p.OnLeave += name => Console.WriteLine("BG: {0} напусна кръчмата.\n", name);
        p.OnEnter += name => Console.WriteLine("EN: Client {0} entered the pub.", name);
        p.OnEnter += name => Console.WriteLine("BG: {0} влезе в кръчмата.\n", name);

        //p.OnLeave("Petranka"); // When using events this will not compile.

        try
        {
            p.Enter("Petranka");
            p.Enter("Gosho");
            p.Leave("Petranka");
            p.Enter("Mariq");
            p.Enter("Ivancho");
            p.Leave("Gosho");
            p.Leave("Gosho");
        }
        catch (InvalidOperationException e)
        {
            Console.WriteLine(e.Message);
        }
    }
}