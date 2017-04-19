using System;
using System.Linq;
using System.Collections.Generic;

public class Repository<T> : IRepository<T>
    where T : IEntity
{
    private List<T> items;

    public Repository()
    {
        this.items = new List<T>();
    }

    public void Add(T item)
    {
        if (item == null)
        {
            throw new ArgumentNullException("item", "The item cannot be null.");
        }

        if (this.items.Where(i => i.Id == item.Id).Count() > 0)
        {
            throw new ArgumentException("Item with such id already exist.");
        }

        items.Add(item);
    }

    public T FindById(int id)
    {
        T item = this.items.SingleOrDefault(e => e.Id == id);
        if (item == null)
        {
            throw new ArgumentOutOfRangeException("Item with such id does not exist.");
        }

        return item;
    }

    public IEnumerable<T> All()
    {
        return this.items;
    }
}