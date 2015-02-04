using System;



public class Frog : Animal
{
    public Frog(string name, sbyte age, string gender)
        : base(name, age, gender) { }
    public override void ProduceSound()
    {
        Console.WriteLine("Kwaaaakkk kwaaaak kwaaaaaak");
    }
}

