using System;
using System.Linq;

public class MathClassOperationsTests
{
    public static void Main()
    {
        Console.WriteLine("Float evaluations:");
        FloatEvaluation();
        Console.WriteLine();
        Console.WriteLine("Double evaluation:");
        DoubleEvaluation();
        Console.WriteLine();
        Console.WriteLine("Decimal evaluation:");
        DecimalEvaluation();
    }

    private static void FloatEvaluation()
    {
        float number = 0;

        Console.Write("Square Root: \t\t");
        TimeDisplayer.DisplayExecutionTime(() =>
        {
            for (int i = 0; i < 20000000; i++)
            {
                Math.Sqrt(number);
            }
        });

        number = 0;

        Console.Write("Natural Logarithm: \t");
        TimeDisplayer.DisplayExecutionTime(() =>
        {
            for (int i = 0; i < 20000000; i++)
            {
                Math.Log(number);
            }
        });

        number = 0;

        Console.Write("Natural Logarithm: \t");
        TimeDisplayer.DisplayExecutionTime(() =>
        {
            for (int i = 0; i < 20000000; i++)
            {
                Math.Sin(number);
            }
        });
    }

    private static void DoubleEvaluation()
    {
        double number = 0;

        Console.Write("Square Root: \t\t");
        TimeDisplayer.DisplayExecutionTime(() =>
        {
            for (int i = 0; i < 20000000; i++)
            {
                Math.Sqrt(number);
            }
        });

        number = 0;

        Console.Write("Natural Logarithm: \t");
        TimeDisplayer.DisplayExecutionTime(() =>
        {
            for (int i = 0; i < 20000000; i++)
            {
                Math.Log(number);
            }
        });

        number = 0;

        Console.Write("Natural Logarithm: \t");
        TimeDisplayer.DisplayExecutionTime(() =>
        {
            for (int i = 0; i < 20000000; i++)
            {
                Math.Sin(number);
            }
        });
    }

    private static void DecimalEvaluation()
    {
        decimal number = 0;

        Console.Write("Square Root: \t\t");
        TimeDisplayer.DisplayExecutionTime(() =>
        {
            for (int i = 0; i < 20000000; i++)
            {
                Math.Sqrt((double)number);
            }
        });

        number = 0;

        Console.Write("Natural Logarithm: \t");
        TimeDisplayer.DisplayExecutionTime(() =>
        {
            for (int i = 0; i < 20000000; i++)
            {
                Math.Log((double)number);
            }
        });

        number = 0;

        Console.Write("Natural Logarithm: \t");
        TimeDisplayer.DisplayExecutionTime(() =>
        {
            for (int i = 0; i < 20000000; i++)
            {
                Math.Sin((double)number);
            }
        });
    }
}