using System;



class Program
{
    static void Main()
    {
        Student pesho = new Student("Pesho", 23);
        Console.WriteLine(pesho.Name);
        Console.WriteLine(pesho.Age);
        EventListener listener = new EventListener(pesho);
        pesho.Name = "gosho";
        listener.Detach();
    }
}

