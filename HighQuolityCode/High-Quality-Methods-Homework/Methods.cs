using System;

namespace Methods
{
    class Methods
    {
        public static double CalcTriangleArea(double a, double b, double c)
        {
            if (a <= 0 || b <= 0 || c <= 0)
            {
                throw new ArgumentOutOfRangeException("Triangle sides have to be positive numbers");
            }

            if((a + b) <= c || (a + c) <= b || (b + c) <= a)
            {
                throw new ArgumentException("Given sides do not form a triangle");
            }

            double s = (a + b + c) / 2;
            double area = Math.Sqrt(s * (s - a) * (s - b) * (s - c));
            return area;
        }

        public static string DigitToText(int number)
        {
            switch (number)
            {
                case 0: return "zero";
                case 1: return "one";
                case 2: return "two";
                case 3: return "three";
                case 4: return "four";
                case 5: return "five";
                case 6: return "six";
                case 7: return "seven";
                case 8: return "eight";
                case 9: return "nine";
                default:
                    throw new ArgumentException("Only nymbers between 0 - 9 can be considered as digits");
            }
        }

        public static int FindMax(params int[] elements)
        {
            if (elements == null || elements.Length == 0)
            {
                throw new ArgumentException("No numbers entered");
            }

            int maxNumber = Int32.MinValue;

            for (int i = 0; i < elements.Length; i++)
            {
                if (elements[i] > maxNumber)
                {
                    maxNumber = elements[i];
                }
            }
            return maxNumber;
        }

        public static void PrintAsNumber(double number, string format)
        {
            if (format == "f")
            {
                Console.WriteLine("{0:f2}", number);
            }
            else if (format == "%")
            {
                Console.WriteLine("{0:p0}", number);
            }
            else if (format == "r")
            {
                Console.WriteLine("{0,8}", number);
            }
            else
            {
                throw new ArgumentException("Invalid format");
            }
        }


        public static double CalcDistance(double x1, double y1, double x2, double y2)
        {          
            double distance = Math.Sqrt((x2 - x1) * (x2 - x1) + (y2 - y1) * (y2 - y1));
            return distance;
        }

        public static bool IsHorisontal(double y1, double y2)
        {
            if (y1 == y2)
            {
                return true;
            }

            return false;
        }

        public static bool IsVertical(double x1, double x2)
        {
            if (x1 == x2)
            {
                return true;
            }

            return false;
        }

        static void Main()
        {
            Console.WriteLine(CalcTriangleArea(3, 4, 5));
            
            Console.WriteLine(DigitToText(5));
            
            Console.WriteLine(FindMax(5, -1, 3, 2, 14, 2, 3));
            
            PrintAsNumber(1.3, "f");
            PrintAsNumber(0.75, "%");
            PrintAsNumber(2.30, "r");

            Console.WriteLine(CalcDistance(3, -1, 3, 2.5));
            Console.WriteLine("Horizontal? " + IsHorisontal(-1, 2.5));
            Console.WriteLine("Vertical? " + IsVertical(3, 3));

            Student peter = new Student() { FirstName = "Peter", LastName = "Ivanov" };
            peter.DayOfBirth = DateTime.Parse("17.03.1992");

            Student stella = new Student() { FirstName = "Stella", LastName = "Markova" };
            stella.DayOfBirth = DateTime.Parse("03.11.1993");

            Console.WriteLine("{0} older than {1} -> {2}",
                peter.FirstName, stella.FirstName, peter.IsOlderThan(stella));            
        }
    }
}
