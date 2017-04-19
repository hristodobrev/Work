using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Code
{
    public class Student : Person
    {
        public Student()
            : this(null, 0, 0)
        {
        }

        public Student(string name, int age, int studentId)
            : base(name, age)
        {
            this.StudentId = studentId;
            this.Courses = new List<string>();
        }

        public int StudentId { get; set; }

        public List<string> Courses { get; set; }

        public new string SayHello()
        {
            return base.SayHello() + string.Format(" I am a student and my student id is {0}.", this.StudentId);
        }
    }
}
