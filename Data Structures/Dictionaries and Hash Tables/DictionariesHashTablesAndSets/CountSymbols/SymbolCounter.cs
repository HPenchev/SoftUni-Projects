using System;
using System.Linq;

public class SymbolCounter
{
    static void Main()
    {
        string input = Console.ReadLine();
        Dictionary<char, int> charactersCount = new Dictionary<char,int>();
        foreach (char character in input)
        {
            if (!charactersCount.ContainsKey(character))
            {
                charactersCount[character] = 0;
            }

            charactersCount[character] += 1;
        }

        var orderedCharacters = charactersCount.Keys.OrderBy(c => c);

        foreach (var character in orderedCharacters)
        {
            Console.WriteLine("{0} : {1} time/s", character, charactersCount[character]);
        }
    }
}