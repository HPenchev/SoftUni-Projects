using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


class PCCatalog
{
    static void Main()
    {
        List<Computer> computers = ComputersAdd();
        computers = computers.OrderBy(o => o.Price).ToList();
        foreach (Computer computer in computers)
        {
            Console.WriteLine(computer.ToString());
            Console.WriteLine();

        }
        
    }
    static List<Component> ComponentsAdd()
    {
        List<Component> components = new List<Component>();
        string checker = null;
        do
        {
            Console.WriteLine("Please add component name:");
            string name = Console.ReadLine();
            Console.WriteLine("Please add component details or press enter if not available:");
            string details = Console.ReadLine();
            Console.WriteLine("Please enter component price in BGN");
            float price = float.Parse(Console.ReadLine());
            Component component = new Component(name, price, details);
            components.Add(component);
            Console.WriteLine("Would you like to enter another component? Y\\N");
            checker = Console.ReadLine();
        } while (checker != "N" && checker != "n");
        return components;
    }
    static List<Computer> ComputersAdd()
    {
        List<Computer> computers = new List<Computer>();
        string checker = null;
        do
        {
            Console.WriteLine("Please enter computer name: ");
            string name = Console.ReadLine();
            List<Component> components = ComponentsAdd();
            
            Computer computer = new Computer(name, components);
            computers.Add(computer);
            Console.WriteLine("Would you like to add another computer? Y\\N");
            checker = Console.ReadLine();
        } while (checker != "N" && checker != "n");
        return computers;
    }

}

