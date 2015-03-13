using System;
using System.Linq;

class SimpleOperationsPerformanceTests
{
    static void Main()
    {
        IntEvaluation();
        Console.WriteLine();
        LongEvaluation();
        Console.WriteLine();
        FloatEvaluation();
        Console.WriteLine();
        DoubleEvaluation();
        Console.WriteLine();
        DecimalEvaluation();
    }

    private static void IntEvaluation()
    {
        int number = 0;

        Console.Write("Int Add: \t\t");
        TimeDisplayer.DisplayExecutionTime(() =>
        {
            for (int i = 0; i < 20000000; i++)
            {
                number += 1;
            }
        });

        number = 0;

        Console.Write("Int Substract: \t\t");
        TimeDisplayer.DisplayExecutionTime(() =>
        {
            for (int i = 0; i < 20000000; i++)
            {
                number -= 1;
            }
        });
        number = 0;

        Console.Write("Int Increment: \t\t");
        TimeDisplayer.DisplayExecutionTime(() =>
        {
            for (int i = 0; i < 20000000; i++)
            {
                number++;
            }
        });
        number = 0;

        Console.Write("Int Miltiply: \t\t");
        TimeDisplayer.DisplayExecutionTime(() =>
        {
            for (int i = 0; i < 20000000; i++)
            {
                number *= 1;
            }
        });
        number = 0;

        Console.Write("Int Divide: \t\t");
        TimeDisplayer.DisplayExecutionTime(() =>
        {
            for (int i = 0; i < 20000000; i++)
            {
                number /= 1;
            }
        });       
    }

    private static void LongEvaluation()
    {
        long number = 0;

        Console.Write("Long Add: \t\t");
        TimeDisplayer.DisplayExecutionTime(() =>
        {
            for (int i = 0; i < 20000000; i++)
            {
                number += 1;
            }
        });

        number = 0;

        Console.Write("Long Substract: \t");
        TimeDisplayer.DisplayExecutionTime(() =>
        {
            for (int i = 0; i < 20000000; i++)
            {
                number -= 1;
            }
        });
        number = 0;

        Console.Write("Long Increment: \t");
        TimeDisplayer.DisplayExecutionTime(() =>
        {
            for (int i = 0; i < 20000000; i++)
            {
                number++;
            }
        });
        number = 0;

        Console.Write("Long Miltiply: \t\t");
        TimeDisplayer.DisplayExecutionTime(() =>
        {
            for (int i = 0; i < 20000000; i++)
            {
                number *= 1;
            }
        });
        number = 0;

        Console.Write("Long Divide: \t\t");
        TimeDisplayer.DisplayExecutionTime(() =>
        {
            for (int i = 0; i < 20000000; i++)
            {
                number /= 1;
            }
        });
    }

    private static void FloatEvaluation()
    {
        float number = 0;

        Console.Write("Float Add: \t\t");
        TimeDisplayer.DisplayExecutionTime(() =>
        {
            for (int i = 0; i < 20000000; i++)
            {
                number += 1;
            }
        });

        number = 0;

        Console.Write("Float Substract: \t");
        TimeDisplayer.DisplayExecutionTime(() =>
        {
            for (int i = 0; i < 20000000; i++)
            {
                number -= 1;
            }
        });
        number = 0;

        Console.Write("Float Increment: \t");
        TimeDisplayer.DisplayExecutionTime(() =>
        {
            for (int i = 0; i < 20000000; i++)
            {
                number++;
            }
        });
        number = 0;

        Console.Write("Float Miltiply: \t");
        TimeDisplayer.DisplayExecutionTime(() =>
        {
            for (int i = 0; i < 20000000; i++)
            {
                number *= 1;
            }
        });
        number = 0;

        Console.Write("Float Divide: \t\t");
        TimeDisplayer.DisplayExecutionTime(() =>
        {
            for (int i = 0; i < 20000000; i++)
            {
                number /= 1;
            }
        });
    }

    private static void DoubleEvaluation()
    {
        double number = 0;

        Console.Write("Double Add: \t\t");
        TimeDisplayer.DisplayExecutionTime(() =>
        {
            for (int i = 0; i < 20000000; i++)
            {
                number += 1;
            }
        });

        number = 0;

        Console.Write("Double Substract: \t");
        TimeDisplayer.DisplayExecutionTime(() =>
        {
            for (int i = 0; i < 20000000; i++)
            {
                number -= 1;
            }
        });
        number = 0;

        Console.Write("Double Increment: \t");
        TimeDisplayer.DisplayExecutionTime(() =>
        {
            for (int i = 0; i < 20000000; i++)
            {
                number++;
            }
        });
        number = 0;

        Console.Write("Double Miltiply: \t");
        TimeDisplayer.DisplayExecutionTime(() =>
        {
            for (int i = 0; i < 20000000; i++)
            {
                number *= 1;
            }
        });
        number = 0;

        Console.Write("Double Divide: \t\t");
        TimeDisplayer.DisplayExecutionTime(() =>
        {
            for (int i = 0; i < 20000000; i++)
            {
                number /= 1;
            }
        });
    }

    private static void DecimalEvaluation()
    {
        decimal number = 0;

        Console.Write("Decimal Add: \t\t");
        TimeDisplayer.DisplayExecutionTime(() =>
        {
            for (int i = 0; i < 20000000; i++)
            {
                number += 1;
            }
        });

        number = 0;

        Console.Write("Decimal Substract: \t");
        TimeDisplayer.DisplayExecutionTime(() =>
        {
            for (int i = 0; i < 20000000; i++)
            {
                number -= 1;
            }
        });
        number = 0;

        Console.Write("Decimal Increment: \t");
        TimeDisplayer.DisplayExecutionTime(() =>
        {
            for (int i = 0; i < 20000000; i++)
            {
                number++;
            }
        });
        number = 0;

        Console.Write("Decimal Miltiply: \t");
        TimeDisplayer.DisplayExecutionTime(() =>
        {
            for (int i = 0; i < 20000000; i++)
            {
                number *= 1;
            }
        });
        number = 0;

        Console.Write("Decimal Divide: \t");
        TimeDisplayer.DisplayExecutionTime(() =>
        {
            for (int i = 0; i < 20000000; i++)
            {
                number /= 1;
            }
        });
    }
}