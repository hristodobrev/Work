using System.Data.Entity;

public class PeopleContext : DbContext
{
    public IDbSet<Person> People { get; set; }
}