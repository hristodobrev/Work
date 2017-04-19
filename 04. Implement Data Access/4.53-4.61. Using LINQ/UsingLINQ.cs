using System;
using System.Linq;

class UsingLINQ
{
    static void Main()
    {
        var computer = new Product("Computer", 1600m);
        var mouse = new Product("Mouse", 40m);
        var keyboard = new Product("Keyboard", 60m);
        var laptop = new Product("Laptop", 1400m);
        var monitor = new Product("Monitor", 240m);
        var printer = new Product("Printer", 140m);
        var scanner = new Product("Scanner", 90m);
        var camera = new Product("Camera", 40m);
        var phone = new Product("Phone", 700m);
        var airConditioner = new Product("Air Conditioner", 1700m);

        var computersOrderLine = new OrderLine(12, computer);
        var mousesOrderLine = new OrderLine(7, mouse);
        var keyboardsOrderLine = new OrderLine(9, keyboard);
        var laptopsOrderLine = new OrderLine(14, laptop);
        var monitorsOrderLine = new OrderLine(4, monitor);
        var printersOrderLine = new OrderLine(8, printer);
        var scannersOrderLine = new OrderLine(7, scanner);
        var camerasOrderLine = new OrderLine(18, camera);
        var phonesOrderLine = new OrderLine(24, phone);
        var airConditionersOrderLine = new OrderLine(3, airConditioner);

        var itOrder = new Order();
        var hobbyOrder = new Order();
        var hnOrder = new Order();

        itOrder.OrderLines.Add(computersOrderLine);
        itOrder.OrderLines.Add(mousesOrderLine);
        itOrder.OrderLines.Add(keyboardsOrderLine);
        itOrder.OrderLines.Add(laptopsOrderLine);
        itOrder.OrderLines.Add(monitorsOrderLine);

        hobbyOrder.OrderLines.Add(phonesOrderLine);
        hobbyOrder.OrderLines.Add(camerasOrderLine);
        hobbyOrder.OrderLines.Add(printersOrderLine);
        hobbyOrder.OrderLines.Add(scannersOrderLine);

        hnOrder.OrderLines.Add(airConditionersOrderLine);

        Order[] orders = { itOrder, hobbyOrder, hnOrder };

        var averageNumberOfOrderLines = orders.Average(o => o.OrderLines.Count);
        Console.WriteLine(averageNumberOfOrderLines);

        var result = from o in orders
                     from l in o.OrderLines
                     group l by l.Product into p
                     select new
                     {
                         Product = p.Key,
                         Amount = p.Sum(x => x.Amount)
                     };

        //Console.WriteLine(string.Join("\n", result.Select(o => o.Product.Description + " - " + o.Amount)));

        Console.WriteLine();
        int pageSize = 5;
        int pageIndex = 1;
        while (true)
        {
            var currentPage = result
                .Skip((pageIndex - 1) * pageSize)
                .Take(pageSize);
            if (currentPage.Count() == 0)
            {
                Console.WriteLine("------- End --------");
                break;
            }

            Console.WriteLine("------ Page {0} ------", pageIndex);
            Console.WriteLine(string.Join("\n", currentPage.Select(o => o.Product.Description + " - " + o.Amount)));
            
            pageIndex++;
        }
        Console.WriteLine();


        Product[] products = new Product[]
        {
            new Product("A", 12m),
            new Product("B", 20m),
            new Product("C", 30m),
        };

        string[] pupularProductNames = { "A", "B" };
        var popularProducts = from p in products
                              join n in pupularProductNames on p.Description equals n
                              select p;
        Console.WriteLine(string.Join(", ", popularProducts.Select(p => p.Description)));
    }
}