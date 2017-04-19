using System.Collections.Generic;

public interface IRepository<T>
{
    void Add(T item);

    T FindById(int id);

    IEnumerable<T> All();
}