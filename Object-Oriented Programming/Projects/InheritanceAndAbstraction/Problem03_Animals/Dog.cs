using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


public class Dog : Animal
{
    public Dog(string name, sbyte age, string gender)
        : base(name, age, gender) { }
    public override void ProduceSound()
    {
        Console.WriteLine("waawwww waw waw waw");
    }
}

