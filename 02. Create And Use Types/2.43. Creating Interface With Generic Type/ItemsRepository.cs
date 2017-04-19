using System.Collections.Generic;
using System.Linq;

public class ItemsRepository : Repository<Item>
{
    public ItemsRepository()
        : base()
    {

    }

    public IEnumerable<Item> FilterItemsOnSearchKey(string key)
    {
        return this.All().Where(i => i.Name.ToLower().Contains(key));
    }
}