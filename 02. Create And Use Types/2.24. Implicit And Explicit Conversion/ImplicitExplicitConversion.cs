using System;

class Money
{
    public Money(decimal amount)
    {
        this.Amount = amount;
    }

    public decimal Amount { get; set; }

    public static implicit operator decimal(Money money)
    {
        return money.Amount;
    }

    public static explicit operator int(Money money)
    {
        return (int)money.Amount;
    }
}

class ImplicitExplicitConversion
{
    static void Main()
    {
        Money m = new Money(42.42m);
        decimal amount = m;
        int truncatedAmount = (int)m;

        Console.WriteLine(amount);
        Console.WriteLine(truncatedAmount);
    }
}