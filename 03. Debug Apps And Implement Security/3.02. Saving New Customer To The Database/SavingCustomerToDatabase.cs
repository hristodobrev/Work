using System;
using System.Data.Entity;

public class ShopContext : DbContext
{
    public IDbSet<Customer> Customers { get; set; }

    protected override void OnModelCreating(DbModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Customer>().HasRequired(bm => bm.BillingAddress)
            .WithMany().WillCascadeOnDelete(false);
    }
}



class SavingCustomerToDatabase
{
    static void Main()
    {
        using (ShopContext ctx = new ShopContext())
        {
            Address a = new Address
            {
                AddressLine1 = "Somewhere 1",
                AddressLine2 = "At some floor",
                City = "SomeCity",
                ZipCode = "1111AA"
            };

            Customer c = new Customer()
            {
                FirstName = "John",
                LastName = "Doe",
                BillingAddress = a,
                ShippingAddress = a
            };

            ctx.Customers.Add(c);
            ctx.SaveChanges();
        }
    }
}