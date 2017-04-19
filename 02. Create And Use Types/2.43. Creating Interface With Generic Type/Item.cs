public class Item : IEntity
{
    public Item(string name, int id)
    {
        this.Name = name;
        this.Id = id;
    }

    public string Name { get; set; }

    public int Id { get; set; }
}