using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


 public abstract class Animal : ISound
{
    public string Name { get; set; }
    public sbyte Age { get; set; }
    public string Gender { get; set; }
     public Animal(string name, sbyte age, string gender)
    {
        this.Name = name;
        this.Age = age;
        this.Gender = gender;
    }
     public abstract void ProduceSound();
}

