using System.Collections.Generic;
namespace Reporter.Repositories
{
    public interface IRepository<T>
    {
        int GetNextId();

        T GetItemById(int id);

        void AddItem(T item);

        IEnumerable<T> GetAllItems();
    }
}
