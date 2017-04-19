using System;
using System.Linq;

interface IAnimal
{
    void Move();
}

class Dog : IAnimal
{
    public void Move()
    {
        Console.WriteLine("Dog moving...");
    }

    public void Bark()
    {
        Console.WriteLine("Dog barking...");
    }
}

class Cat : IAnimal
{
    public void Move()
    {
        Console.WriteLine("Cat moving...");
    }

    public void Meow()
    {
        Console.WriteLine("Cat meowing...");
    }
}

class GenericTypeInterface
{
    static void Main()
    {
        ItemsRepository repository = new ItemsRepository();
        repository.Add(new Item("Monitor", 1));
        repository.Add(new Item("Keyboard", 2));
        repository.Add(new Item("Mouse", 3));
        repository.Add(new Item("Camera", 4));

        var items = repository.All();
        Console.WriteLine(string.Join(", ", items.Select(i => i.Name)));

        // Console.WriteLine(repository.FindById(2).Name);

        var itemsWithM = repository.FilterItemsOnSearchKey("mou");
        Console.WriteLine(string.Join(", ", itemsWithM.Select(i => i.Name)));



        IAnimal dogAnimal = new Dog();
        dogAnimal.Move();
        ((Dog)dogAnimal).Bark(); // Access to Bark possible only through casting

        IAnimal catAnimal = new Cat();
        catAnimal.Move();
        ((Cat)catAnimal).Meow(); // Access to Meow possible only through casting
    }
}