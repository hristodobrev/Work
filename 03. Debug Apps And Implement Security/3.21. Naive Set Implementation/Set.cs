using System.Collections.Generic;

public class Set<T>
{
    private List<T> list = new List<T>();

    public void Insert(T item)
    {
        if (!this.Contains(item))
        {
            list.Add(item);
        }
    }

    public bool Contains(T item)
    {
        foreach (T member in list)
        {
            if (member.Equals(item))
            {
                return true;
            }
        }

        return false;
    }
}