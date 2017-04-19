using System;
using System.Collections.Generic;
using System.Text;

public class PeopleCollection : List<Person>
{
    public void RemoveByAge(int age)
    {
        for (int index = this.Count - 1; index >= 0; index--)
        {
            if (this[index].Age == age)
            {
                this.RemoveAt(index);
            }
        }
    }

    public override string ToString()
    {
        StringBuilder sb = new StringBuilder();
        foreach (Person p in this)
        {
            sb.AppendFormat("{0} {1} is {2} year(s) old.{3}", p.FirstName, p.LastName, p.Age, Environment.NewLine);
        }

        return sb.ToString();
    }
}