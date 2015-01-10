using System;

class Program
{
    static void Main()
    {

        Console.WriteLine("Please add the name of the element you want to create:");
        string name = Console.ReadLine();
        ElementBuilder element = new ElementBuilder(name);
        Console.WriteLine("You created the element " + element.Element);
        string value;
        while(true)
        {
            Console.WriteLine("Would you like to enter an attribute? Y/N");
            string checker = Console.ReadLine();
            if (checker == "N" || checker == "n") break;
            Console.WriteLine("Please enter the attribute type");
            string attribute = Console.ReadLine();
            Console.WriteLine("Please enter the attribute value");
            value = Console.ReadLine();
            element.AddAttribute(attribute, value);
        }
        Console.WriteLine("The current element is " + element.Element);
        Console.WriteLine("Please add content or press enter to continue. Please note you can't add content if it has already been set:");
        string content = Console.ReadLine();
        element.AddContent(content);
        Console.WriteLine("The current element is " + element.Element);
        Console.WriteLine("How many times do you want to print the element?");
        uint multiplier = uint.Parse(Console.ReadLine());
        Console.WriteLine(element*multiplier);
        Console.WriteLine("Now we are creating an img tag. Please enter img source:");
        string source = Console.ReadLine();
        Console.WriteLine("Please enter img alt:");
        string alt = Console.ReadLine();
        Console.WriteLine("Please enter img title:");
        string title = Console.ReadLine();
        Console.WriteLine(HTMLDispatcher.CreateImage(source, alt, title));
        Console.WriteLine("Now we are creating URL. Please enter the link:");
        source = Console.ReadLine();
        Console.WriteLine("Please enter the text:");
        string text = Console.ReadLine();
        Console.WriteLine("Please enter title:");
        title = Console.ReadLine();
        Console.WriteLine(HTMLDispatcher.CreateURL(source, text, title));
        Console.WriteLine("Now we are creating input. Please enter input type:");
        string type = Console.ReadLine();
        Console.WriteLine("Please enter input name:");
        name = Console.ReadLine();
        Console.WriteLine("Please enter input value:");
        value = Console.ReadLine();
        Console.WriteLine(HTMLDispatcher.CreateInput(type, name, value));
       
    }
}

