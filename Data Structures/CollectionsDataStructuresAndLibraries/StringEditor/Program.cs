using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Wintellect.PowerCollections;

namespace StringEditor
{
    public class Program
    {
        public static void Main()
        {
            BigList<char> str = new BigList<char>();
            
            while(true)
            {
                string[] input = Console.ReadLine().Split(' ');

                string command = input[0].ToLower();

                switch(command)
                {
                    case "insert":
                        InsertString(str, input[1], int.Parse(input[2]));
                        break;
                    case "append":
                        str.AddRange(input[1]);
                        break;
                    case "delete":
                        str.RemoveRange(int.Parse(input[1]), int.Parse(input[2]));
                        break;
                    case "replace":
                        ReplaceSubstring(str, int.Parse(input[1]), int.Parse(input[2]), input[3]);
                        break;
                    case "print":
                        foreach (char ch in str)
                        {
                            Console.Write(ch);
                        }
                        break;
                    default:
                        Console.WriteLine("Invalid command, please try again");
                        break;
                }
            }
        }

        private static void InsertString(BigList<char> list, string insertString, int position)
        {
            if (position < 0 || position > list.Count)
            {
                Console.WriteLine("ERROR");
                return;
            }

            list.InsertRange(position, insertString);
        }

        private static void ReplaceSubstring(BigList<char> list, int startIndex, int count, string stringForReplacement)
        {
            if (startIndex < 0 || count < 0 || startIndex + count > list.Count)
            {
                Console.WriteLine("ERROR");
                return;
            }

            list.RemoveRange(startIndex, count);
            list.InsertRange(startIndex, stringForReplacement);
        }
    }
}