using System;



public class Cat : Animal
{
    public Cat(string name, sbyte age, string gender)
        : base(name, age, gender) { }
    public override void ProduceSound()
    {
        Console.WriteLine("Miauuuuuuuuuu");
    }
}

