using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tests
{
    public class Student : Person
    {
        public Student(string name,int? age = null, int? studentId = null)
            : base(name, age)
        {
            this.StudentId = studentId;
        }

        public int? StudentId { get; set; }

        public override string ToString()
        {
            return base.ToString() + " [" + this.StudentId + "]";
        }
    }
}
