using EntityFrameworkMapping;
using System;
using System.Linq;

public class CharactersLister
{
    public static void Main()
    {
        var context = new DiabloEntities();

        var characters = context.Characters.Select(c => c.Name);

        foreach (var character in characters)
        {
            Console.WriteLine(character);
        }
    }
}