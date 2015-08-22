using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

public class Program
{
    static void Main()
    {
        Dictionary<string, int> wordsCount = new Dictionary<string, int>();

        Console.WriteLine("Please enter the number of lines expected:");
        int n = int.Parse(Console.ReadLine());
        for (int i = 0; i < n; i++)
        {
            string line = Console.ReadLine();
            Match match = Regex.Match(line, @"[A-Za-z_\-0-9#]+");
            while (match.Success)
            {
                string word = match.Value;
                if (wordsCount.ContainsKey(word))
                {
                    wordsCount[word]++;
                }
                else
                {
                    wordsCount.Add(word, 1);
                }

                match = match.NextMatch();
            }
        }

        Console.WriteLine("Please enter the number of words you are going ot search for:");
        int numberOfSearchedWords = int.Parse(Console.ReadLine());
        string[] searchedWords = new string[numberOfSearchedWords];

        Console.WriteLine("Please enter searched words one per line");
        for (int i = 0; i < numberOfSearchedWords; i++)
        {
            searchedWords[i] = Console.ReadLine();
        }

        for (int i = 0; i < searchedWords.Length; i++)
        {
            int count = 0;
            if (wordsCount.ContainsKey(searchedWords[i]))
            {
                count = wordsCount[searchedWords[i]];
            }

            Console.WriteLine("{0} -> {1} times", searchedWords[i], count);
        }

        //
    }
}
