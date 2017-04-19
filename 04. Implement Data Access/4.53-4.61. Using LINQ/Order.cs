using System.Collections.Generic;

public class Order
{
    public Order()
    {
        this.OrderLines = new List<OrderLine>();
    }

    public List<OrderLine> OrderLines { get; set; }
}