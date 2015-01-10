using System;


    class Program
    {
        static void Main()
        {
            Fraction[] fractions = new Fraction[2];
            for (int i = 0; i < 2; i++)
            {
                Console.WriteLine("Please enter a fraction in the format a/b");
                string stringNumbers = Console.ReadLine();
                string[] numbers = stringNumbers.Split('/');
                long numerator = long.Parse(numbers[0]);
                long denominator = long.Parse(numbers[1]);
                fractions[i] = new Fraction(numerator, denominator);
            }
            Console.WriteLine("Please choose + or - for additin or substraction");
            char sign = char.Parse(Console.ReadLine());
            Fraction result;
            if(sign=='+')
            {
                result = fractions[0] + fractions[1];
            }
            else if (sign == '-')
            {
                result = fractions[0] - fractions[1];
            }
            else
            {
                throw new InvalidOperationException ("Invalid operator. Only operators + and - can be used in this application");
            }
            Console.WriteLine(result);
            
        }
    }

