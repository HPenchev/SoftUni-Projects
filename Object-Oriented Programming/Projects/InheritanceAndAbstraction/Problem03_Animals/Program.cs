using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


class Program
{
    static void Main()
    {
        List<Dog> dogs = new List<Dog>(new Dog[] { new Dog("Sharo", 7, "male"), new Dog("Ginna", 8, "female"), new Dog("Bobb", 2, "male")});
        
        double dogsAge = dogs.Average(x => x.Age);

        List<Cat> cats = new List<Cat>(new Cat[] { new Cat("Tom", 7, "male"), new Cat("Tess", 8, "female"), new Cat("Stasy", 1, "female") });

        double catAge = cats.Average(x => x.Age);

        List<Frog> frogs = new List<Frog>(new Frog[] { new Frog("Pesho", 1, "male"), new Frog("Gosho", 2, "male"), new Frog("Mariika", 2, "female") });

        double frogAge = frogs.Average(x => x.Age);

        Console.WriteLine("Agerage dog age - " + dogsAge);
        Console.WriteLine("Average cat age - " + catAge);
        Console.WriteLine("Average frog age - " + frogAge);

    }
}

