using System;

class Test
{
    private int value = 3;

    public void PrintValue(bool printProperty = false)
    {
        int value = 10;
        if (printProperty)
        {
            value = this.value;
        }

        Console.WriteLine(value);
    }
}

class DefiningClasses
{
    string name;
    int age;
    int length;
    bool isMale;

    static void Main()
    {
        Student st1 = new Student("Petya", "Ivaylova", "University of Sofia");
        Student st2 = new Student("Hristo", "Dobrev", "Software Engineering",
            "Software University", "h.dobrev@gmail.com");
        Student st3 = new Student("Ivaylo", "Stoyanov", "Advanced JS", "Software Engineering",
            "Software University", "iv.st@abv.bg");
        Student st4 = new Student("Mariq", "Petrova", "Decheva", "Advanced DataBase",
            "Software Engineering",
            "Software University", "m.decheva@mail.bg", "0876459451");

        Console.WriteLine("Registered Students[{0}]:{1}", Student.StudentsRegistered, Environment.NewLine);
        Console.WriteLine(st1);
        Console.WriteLine(st2);
        Console.WriteLine(st3);
        Console.WriteLine(st4);
    }

    static void TestMain()
    {
        Circle c = new Circle(3);
        c.PrintSurface();

        Console.WriteLine(SqrtPrecalculated.GetSqrt(1000));

        Coffee normalCoffee = new Coffee(CoffeeSize.Normal);
        Coffee doubleCoffee = new Coffee(CoffeeSize.Double);

        Console.WriteLine("The {0} coffee is {1} ml.",
            normalCoffee.Size, (int)normalCoffee.Size);
        Console.WriteLine("The {0} coffee is {1} ml.",
            doubleCoffee.Size, (int)doubleCoffee.Size);

        PriceCalculator calc = new PriceCalculator();
        Console.WriteLine(calc.GetPrice(CoffeeSize.Double));

        string a = "Some text";
        string b = "Another text";
        Swap(ref a, ref b);
        Console.WriteLine(a);
    }

    static void Swap<K>(ref K a, ref K b)
    {
        K oldA = a;
        a = b;
        b = oldA;
    }

    static void OldMain()
    {
        Console.WriteLine("Write first dog name:");
        string firstDogName = Console.ReadLine();

        Dog firstDog = new Dog(firstDogName);

        Dog secondDog = new Dog();

        Console.WriteLine("Write second dog name:");
        string secondDogName = Console.ReadLine();

        //secondDog.Name = secondDogName;

        Dog thirdDog = new Dog();

        Dog[] dogs = new Dog[] { firstDog, secondDog, thirdDog };
        foreach (Dog dog in dogs)
        {
            dog.Bark();
        }

        Dog[] otherDogs = new Dog[] { 
            new Dog("Sharo"),
            new Dog("Tom"),
        };

        DefiningClasses dc = new DefiningClasses();
        Console.WriteLine(dc.name);
        Console.WriteLine(dc.age);
        Console.WriteLine(dc.length);
        Console.WriteLine(dc.isMale);

        var test = new Test();
        test.PrintValue(true);
        Console.WriteLine(Dog.Count);
    }
}