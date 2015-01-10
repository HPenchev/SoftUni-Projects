using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


class PeopleAdd
{
    static void Main()
    {
        Console.WriteLine("Please enter a name:");
        string name = Console.ReadLine();
        Console.WriteLine("Please enter age");
        int age = int.Parse(Console.ReadLine());
        Console.WriteLine("Please enter an email or press \"Enter\" to continue:");
        string email = Console.ReadLine();
        Person person = new Person(name, age, email);
        Console.WriteLine(person.ToString());

    }
}

