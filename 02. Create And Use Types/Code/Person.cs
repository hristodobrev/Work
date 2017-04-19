namespace Code
{
    public class Person
    {
        public Person()
            : this(null, 0)
        {
        }

        public Person(string name, int age)
        {
            this.Name = name;
            this.Age = age;
        }

        private string Name { get; set; }

        private int Age { get; set; }

        public string SayHello()
        {
            return string.Format("{0} says Hello!", this.Name);
        }

        public override string ToString()
        {
            return string.Format("I am {0} and I am {1} years old.", this.Name, this.Age);
        }
    }
}
