using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;


[TestClass]
public class PerformanceMethodsTests
{
    [TestMethod]
    public void InsertionSortTest()
    {
        for (int i = 0; i < 1; i++)
        {
            int[] arr1 = SortingTests.TakeIntNumbers();                
            int len = arr1.Length;
            int[] arr2 = new int[len];
                
            for (int j = 0; j < len; j++)
            {
                arr2[j] = arr1[j];
            }

            arr1 = (int[])SortingTests.InsertionSort(arr1);
            Array.Sort(arr2);
                
            CollectionAssert.AreEqual(arr1, arr2);

            double[] arrDouble1 = SortingTests.TakeDoubleNumbers();
            len = arrDouble1.Length;
            double[] arrDouble2 = new double[len];

            for (int j = 0; j < len; j++)
            {
                arrDouble2[j] = arrDouble1[j];
            }

            arrDouble1 = (double[])SortingTests.InsertionSort(arrDouble1);
            Array.Sort(arrDouble2);

            CollectionAssert.AreEqual(arrDouble1, arrDouble2);
        }            
    }

    [TestMethod]
    public void SelectionSortTest()
    {
        for (int i = 0; i < 1; i++)
        {
            //int[] arr1 = SortingTests.TakeIntNumbers();
            int[] arr1 = { 8, 5, 4, 1, 4, 6, 10 };
            int len = arr1.Length;
            int[] arr2 = new int[len];
            
            for (int j = 0; j < len; j++)
            {
                arr2[j] = arr1[j];
            }

            arr1 = (int[])SortingTests.SelectionSort(arr1);
            Array.Sort(arr2);

            CollectionAssert.AreEqual(arr1, arr2);

            double[] arrDouble1 = SortingTests.TakeDoubleNumbers();
            len = arrDouble1.Length;
            double[] arrDouble2 = new double[len];

            for (int j = 0; j < len; j++)
            {
                arrDouble2[j] = arrDouble1[j];
            }

            arrDouble1 = (double[])SortingTests.SelectionSort(arrDouble1);
            Array.Sort(arrDouble2);

            CollectionAssert.AreEqual(arrDouble1, arrDouble2);
        }
    }

    [TestMethod]
    public void QuickSortTest()
    {
        for (int i = 0; i < 1; i++)
        {
            int[] arr1 = SortingTests.TakeIntNumbers();
            //int[] arr1 = { 8, 5, 4, 1, 4, 6, 10, 4, 4 };
            int len = arr1.Length;
            int[] arr2 = new int[len];

            for (int j = 0; j < len; j++)
            {
                arr2[j] = arr1[j];
            }

            SortingTests.QuickSort(arr1, 0, arr1.Length - 1);
            Array.Sort(arr2);
                       
            CollectionAssert.AreEqual(arr1, arr2);            
        }
    }
}