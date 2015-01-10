using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


class Program
{
    static void Main()
    {
        Action f = testMethod; ;
        AsyncTimer test = new AsyncTimer(f, 10, 500);
        test.Run();
        string testString = Console.ReadLine();
        
    }
    public static void testMethod()
    {
        Console.WriteLine("test");
    }
}

