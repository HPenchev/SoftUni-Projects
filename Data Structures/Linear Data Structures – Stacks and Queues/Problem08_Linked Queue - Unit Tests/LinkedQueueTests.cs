using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

[TestClass]
public class LinkedQueueTests
{
    [TestMethod]
    public void NumbersTest()
    {
        LinkedQueue<int> numbers = new LinkedQueue<int>();

        Assert.AreEqual(0, numbers.Count);

        numbers.Enqueue(1);
        Assert.AreEqual(1, numbers.Count);

        int num = numbers.Dequeue();
        Assert.AreEqual(1, num);
        Assert.AreEqual(0, numbers.Count);
    }

    [TestMethod]
    public void StringsTest()
    {
        LinkedQueue<string> strings = new LinkedQueue<string>();

        Assert.AreEqual(0, strings.Count);

        for (int i = 1; i <= 1000; i++)
        {
            strings.Enqueue("Azis e pederas");
            Assert.AreEqual(i, strings.Count);
        }

        for (int i = 999; i <= 0; i--)
        {
            string str = strings.Dequeue();
            Assert.AreEqual(str, "Azis e pederas");
            Assert.AreEqual(i, strings.Count);
        }
    }

    [TestMethod]
    [ExpectedException(typeof(InvalidOperationException),
        "The queue is empty")]
    public void TestPopFromAnEmptyStack()
    {
        LinkedQueue<char> chars = new LinkedQueue<char>();
        char c = chars.Dequeue();
    }

    [TestMethod]
    public void TestAutoGrouth()
    {
        LinkedQueue<int> numbers = new LinkedQueue<int>();

        Assert.AreEqual(0, numbers.Count);

        numbers.Enqueue(10);
        Assert.AreEqual(1, numbers.Count);

        numbers.Enqueue(100);
        Assert.AreEqual(2, numbers.Count);

        int number = numbers.Dequeue();
        Assert.AreEqual(10, number);
        Assert.AreEqual(1, numbers.Count);

        number = numbers.Dequeue();
        Assert.AreEqual(100, number);
        Assert.AreEqual(0, numbers.Count);
    }

    [TestMethod]
    public void ToArrayTest()
    {
        LinkedQueue<int> numbersStack = new LinkedQueue<int>();

        numbersStack.Enqueue(3);
        numbersStack.Enqueue(5);
        numbersStack.Enqueue(-2);
        numbersStack.Enqueue(7);

        int[] array = new int[] { 3, 5, -2, 7 };
        int[] resultArray = numbersStack.ToArray();
        CollectionAssert.AreEqual(array, resultArray);
    }

    [TestMethod]
    public void EmptyStackToArrayTest()
    {
        LinkedQueue<int> numbersStack = new LinkedQueue<int>();


        int[] array = new int[] { };
        int[] resultArray = numbersStack.ToArray();
        CollectionAssert.AreEqual(array, resultArray);
    }
}