using System;
using System.Linq;

public class Phonebook
{
    static void Main()
    {
        Console.WriteLine("Please enter your input in format \"name - phone\". Type \"search\" to test searching");

        Dictionary<string, string> phoneBook = new Dictionary<string, string>();
        string input = null;

        do
        {
            input = Console.ReadLine();

            string[] splittedInput = input.Split('-');
            if (splittedInput.Length > 1)
            {
                phoneBook[splittedInput[0].Trim()] = splittedInput[1].Trim();
            }
        }
        while (input != "search");

        Console.WriteLine("Please enter a name to search or \"exit\" for exit");

        do
        {
            input = Console.ReadLine();
            if (input == "exit")
            {
                break;
            }

            if (phoneBook.ContainsKey(input))
            {
                Console.WriteLine("{0} -> {1}", input, phoneBook[input]);
            }
            else
            {
                Console.WriteLine("Contact {0} does not exist", input);
            }
                        
        }
        while (input != "exit");
    }
}