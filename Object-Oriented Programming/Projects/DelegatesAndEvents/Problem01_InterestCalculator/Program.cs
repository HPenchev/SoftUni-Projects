using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public delegate decimal CalculateInterest(decimal sum, float interest, int years);


    class Program
    {
        static void Main()
        {
            
            InterestCalculator simple = new InterestCalculator(500m, 5.6f, 10, GetCompoundInterest);
            Console.WriteLine(simple.MoneyAfterIdexation);
            InterestCalculator compound = new InterestCalculator(2500m, 7.2f, 15, GetSimpleInterest);
            Console.WriteLine(compound.MoneyAfterIdexation);

        }
        public static decimal GetSimpleInterest(decimal sum, float interest, int years)
        {
            decimal result = sum * (decimal)(1 + interest/100 * years);
            return Math.Round(result, 4);
        }
        public static decimal GetCompoundInterest(decimal sum, float interest, int years)
        {
            decimal result =  (sum * (decimal)Math.Pow(1 + interest / 100 / 12, 12 * years));
            return Math.Round(result, 4);
        }
    }

