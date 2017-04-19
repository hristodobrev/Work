namespace Tests
{
    using System;

    public class Person
    {
        private string name;

        public Person(string name, int? age = null)
        {
            this.Name = name;
            this.Age = age;
        }

        public string Name
        {
            get
            {
                return this.name;
            }

            set
            {
                if (String.IsNullOrEmpty(value))
                {
                    throw new ArgumentException("Name cannot be empty.");
                }

                this.name = value;
            }
        }

        public int? Age { get; set; }

        public static Person Parse(string str)
        {
            // name, age
            string[] tokens = str.Split(new char[] { ' ', ',' }, StringSplitOptions.RemoveEmptyEntries);
            if (tokens.Length < 1)
            {
                throw new FormatException("Invalid count of arguments.");
            }

            string name = tokens[0];

            int? age = null;
            if (tokens.Length > 1)
            {
                int currentAge;
                bool successParse = int.TryParse(tokens[1], out currentAge);
                if (currentAge != 0)
                {
                    age = currentAge;
                }
                else
                {
                    age = null;
                }
            }

            return new Person(name, age);
        }

        public override bool Equals(object obj)
        {
            Person other = null;
            // if (obj is Person)
            if (obj.GetType() == typeof(Person))
            {
                other = (Person)obj;
            }
            else
            {
                throw new InvalidOperationException("Person cannot compare classes different than itself.");
            }

            if (this.Name != other.Name)
            {
                return false;
            }

            if (this.Age != other.Age)
            {
                return false;
            }

            return true;
        }

        public override string ToString()
        {
            return String.Format("({0}) {1}{2}", this.GetType().Name, this.Name, this.Age != null ? " [Age: " + this.Age + "]" : "");
        }
    }
}
