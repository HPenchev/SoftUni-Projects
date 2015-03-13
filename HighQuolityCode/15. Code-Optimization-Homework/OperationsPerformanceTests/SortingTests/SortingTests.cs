using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;


public class SortingTests
{
    private static Random rnd = new Random();
    private const int VarablesInArray = 10000;
    static void Main()
    {
        TestRandomArraySort();
    }

    public static void TestRandomArraySort()
    {
        

        int[] arrInt1 = TakeIntNumbers();
        int[] arrInt2 = (int[])arrInt1.Clone();
        int[] arrInt3 = (int[])arrInt1.Clone();

        double[] arrDouble1 = TakeDoubleNumbers();
        double[] arrDouble2 = TakeDoubleNumbers();
        double[] arrDouble3 = TakeDoubleNumbers();

        string[] arrString1 = TakeStrings();
        string[] arrString2 = TakeStrings();
        string[] arrString3 = TakeStrings();

        Console.WriteLine("Testing randomly ordered arrays:");

        RunTests(arrInt1, arrInt2, arrInt3, arrDouble1, arrDouble2, arrDouble3, arrString1, arrString2, arrString3);

        Console.WriteLine();
        Console.WriteLine("Testing ordered arrays");
        RunTests(arrInt1, arrInt2, arrInt3, arrDouble1, arrDouble2, arrDouble3, arrString1, arrString2, arrString3);

        arrInt1.Reverse();
        arrInt2.Reverse();
        arrInt3.Reverse();
        arrDouble1.Reverse();
        arrDouble2.Reverse();
        arrDouble2.Reverse();
        arrString1.Reverse();
        arrString2.Reverse();
        arrString3.Reverse();

        Console.WriteLine();
        Console.WriteLine("Testing reversed arrays");
        RunTests(arrInt1, arrInt2, arrInt3, arrDouble1, arrDouble2, arrDouble3, arrString1, arrString2, arrString3);
    }

    private static void RunTests(
        int[] arrInt1, 
        int[] arrInt2,
        int[] arrInt3,
        double[] 
        arrDouble1, 
        double[] arrDouble2,
        double[] arrDouble3, 
        string[] arrString1, 
        string[] arrString2, 
        string[] arrString3)
    {
        Console.WriteLine("Testing int numbers:");
        TestArrays(arrInt1, arrInt2, arrInt3);

        Console.WriteLine();
        Console.WriteLine("Testing double numbers:");

        TestArrays(arrDouble1, arrDouble2, arrDouble3);

        Console.WriteLine();
        Console.WriteLine("Testing strings:");

        TestArrays(arrString1, arrString2, arrString3);
    }

    private static void TestArrays<T>(T[] arr1, T[] arr2, T[] arr3)
        where T : IComparable
    {
        Console.WriteLine("Insertion sort:");
        TimeDisplayer.DisplayExecutionTime(() =>
        {
            var intArr = InsertionSort(arr1);
        });

        Console.WriteLine("Selection sort:");
        TimeDisplayer.DisplayExecutionTime(() =>
        {
            var intArr = SelectionSort(arr2);
        });

        Console.WriteLine("Quick sort:");
        TimeDisplayer.DisplayExecutionTime(() =>
        {
            QuickSort(arr3, 0, arr3.Length - 1);
        });
    }
    public static int[] TakeIntNumbers()
    {
        int[] numbers = new int[VarablesInArray];
        int temp = 0;

        for (int i = 0; i < VarablesInArray; i++)
		{
			temp = rnd.Next(1000000);
            numbers[i] = temp;
		}

        return numbers;
    }

    public static double[] TakeDoubleNumbers()
    {
        double[] numbers = new double[VarablesInArray];
        int temp = 0;

        for (int i = 0; i < VarablesInArray; i++)
		{
			temp = rnd.Next(1000000);
            numbers[i] = temp;
		}

        return numbers;
    }

    private static string[] TakeStrings()
    {
        string[] strings = new string[VarablesInArray];
        int temp = 0;

        for (int i = 0; i < VarablesInArray; i++)
		{
			temp = rnd.Next(100) + 1;
            strings[i] = RandomString(temp);
		}

        return strings;
    }

    private static string RandomString(int size)
    {
        StringBuilder builder = new StringBuilder();
        Random random = new Random();
        char ch;
        for (int i = 0; i < size; i++)
        {
            ch = Convert.ToChar(rnd.Next(128));                 
            builder.Append(ch);
        }

        return builder.ToString();
    }

    public static T[] InsertionSort<T> (T[] list) // works with immutable types only
        where T : IComparable
    {
        int len = list.Length;
        
        for (int i = 1; i < len; i++)
		{
			if (list[i - 1].CompareTo(list[i]) == 1)
            {
                var temp = list[i];

                for (int j = i - 1; j >= 0; j--)
                {
                    if (list[j].CompareTo(temp) == 1)
                    {
                        list[j + 1] = list[j];

                        if(j == 0)
                        {
                            list[j] = temp;
                        }
                    }
                    else
                    {
                        list[j + 1] = temp;
                        break;
                    }
                }			
            }
		}

        return list;
    }

    public static T[] SelectionSort<T>(T[] list) // works with immutable types only
        where T : IComparable
    {
        int len = list.Length;
        T min;
        T temp;
        for (int i = 0; i < len; i++)
        {
            min = list[i];

            for (int j = i; j < len; j++)
            {
                if (list[j].CompareTo(min) < 0)
                {
                    min = list[j];
                }
            }
            list.ToArray();
            temp = min;
            list[Array.LastIndexOf(list, min)] = list[i];
            list[i] = temp;
        }

        return list;
    }

    public static void QuickSort<T>(T[] elements, int left, int right)
        where T : IComparable
    {
        int i = left, j = right;
        IComparable pivot = elements[(left + right) / 2];
 
        while (i <= j)
        {
            while (elements[i].CompareTo(pivot) < 0)
            {
                i++;
            }
 
            while (elements[j].CompareTo(pivot) > 0)
            {
                j--;
            }
 
            if (i <= j)
            {
                // Swap
                T tmp = elements[i];
                elements[i] = elements[j];
                elements[j] = tmp;
 
                i++;
                j--;
            }
        }
 
        // Recursive calls
        if (left < j)
        {
            QuickSort(elements, left, j);
        }
 
        if (i < right)
        {
            QuickSort(elements, i, right);
        }
    } 
     
}