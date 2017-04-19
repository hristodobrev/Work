public class Product
{
    public Product(string description, decimal price)
    {
        this.Description = description;
        this.Price = price;
    }

    public string Description { get; set; }

    public decimal Price { get; set; }
}