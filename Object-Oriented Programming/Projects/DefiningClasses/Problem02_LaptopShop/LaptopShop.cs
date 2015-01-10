using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


class LaptopShop
{
    static void Main()
    {
        string model = null;
        string manufacturer = null;
        string processor = null;
        string ram = null;
        string graphicsCard = null;
        string hdd = null;
        string screen = null;
        string batteryInfo = null;
        string batteryLife = null;
        string price = null;
        Console.WriteLine("Please enter laptop model:");
        model = Console.ReadLine();
        Console.WriteLine("Please enter laptop manufacturer or press enter if unknown:");
        manufacturer = Console.ReadLine();
        Console.WriteLine("Please enter laptop processor or press enter if unknown:");
        processor = Console.ReadLine();
        Console.WriteLine("Please enter laptop RAM in GB or press enter if unknown:");
        ram = Console.ReadLine();
        Console.WriteLine("Please enter laptop graphics card or press enter if unknown:");
        graphicsCard = Console.ReadLine();
        Console.WriteLine("Please enter laptop HDD or press enter if unknown:");
        hdd = Console.ReadLine();
        Console.WriteLine("Please enter laptop screen or press enter if unknown:");
        screen = Console.ReadLine();
        Console.WriteLine("Please enter laptop battery or press enter if unknown:");
        batteryInfo = Console.ReadLine();
        Console.WriteLine("Please enter laptop battery life in hours or press enter if unknown:");
        batteryLife = Console.ReadLine();
        Console.WriteLine("Please enter laptop price:");
        price = Console.ReadLine();
        Battery battery = new Battery(batteryInfo, batteryLife);
        Laptop laptop = new Laptop(model, price, manufacturer, processor, ram, graphicsCard, hdd, screen, battery);
        Console.WriteLine(laptop.ToString());
       
    }
}

