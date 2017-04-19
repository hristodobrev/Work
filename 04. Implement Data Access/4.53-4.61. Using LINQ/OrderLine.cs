public class OrderLine
{
    public OrderLine(int amount, Product product)
    {
        this.Amount = amount;
        this.Product = product;
    }

    public int Amount { get; set; }

    public Product Product { get; set; }
}