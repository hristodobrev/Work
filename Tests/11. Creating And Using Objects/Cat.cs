namespace Chapter1
{
    using System;

    public class Cat
    {
        private string name;
        private string color;

        public Cat()
        {
            this.Name = "Unnamed";
            this.Color = "Gray";
        }

        public Cat(string name, string color)
        {
            this.Name = name;
            this.Color = color;
        }

        public string Name
        {
            get
            {
                return this.name;
            }
            set
            {
                this.name = value;
            }
        }

        public string Color
        {
            get
            {
                return this.color;
            }
            set
            {
                this.color = value;
            }
        }

        public void SayMeow()
        {
            Console.WriteLine("Cat {0} said: Meeeeoooooow!", this.Name);
        }
    }
}