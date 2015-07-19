using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

[TestClass]
public class ArrayStackUnitTests
{
    [TestMethod]
    public void NumbersTest()
    {
        ArrayStack<int> numbers = new ArrayStack<int>();

        Assert.AreEqual(0, numbers.Count);

        numbers.Push(1);
        Assert.AreEqual(1, numbers.Count);

        int num = numbers.Pop();
        Assert.AreEqual(1, num);
        Assert.AreEqual(0, numbers.Count);
    }    

    [TestMethod]
    public void StringsTest()
    {
        ArrayStack<string> strings = new ArrayStack<string>();

        Assert.AreEqual(0, strings.Count);

        for (int i = 1; i <= 1000; i++)
        {
            strings.Push("Azis e pederas");
            Assert.AreEqual(i, strings.Count);
        }

        for (int i = 999; i <= 0; i--)
        {
            string str = strings.Pop();
            Assert.AreEqual(str, "Azis e pederas");
            Assert.AreEqual(i, strings.Count);
        }
    }

    [TestMethod]
    [ExpectedException(typeof(InvalidOperationException),
        "The stack is empty")]
    public void TestPopFromAnEmptyStack()
    {
        ArrayStack<char> chars = new ArrayStack<char>();
        char c = chars.Pop();
    }

    [TestMethod]
    public void TestAutoGrouth()
    {
        ArrayStack<int> numbers = new ArrayStack<int>(1);

        Assert.AreEqual(0, numbers.Count);

        numbers.Push(10);
        Assert.AreEqual(1, numbers.Count);

        numbers.Push(100);
        Assert.AreEqual(2, numbers.Count);

        int number = numbers.Pop();
        Assert.AreEqual(100, number);
        Assert.AreEqual(1, numbers.Count);

        number = numbers.Pop();
        Assert.AreEqual(10, number);
        Assert.AreEqual(0, numbers.Count);
    }

    [TestMethod]
    public void ToArrayTest()
    {
        ArrayStack<int> numbersStack = new ArrayStack<int>();

        numbersStack.Push(3);
        numbersStack.Push(5);
        numbersStack.Push(-2);
        numbersStack.Push(7);

        int[] array = new int[] { 3, 5, -2, 7 };
        int[] resultArray = numbersStack.ToArray();
        CollectionAssert.AreEqual(array, resultArray);
    }

    [TestMethod]
    public void EmptyStackToArrayTest()
    {
        ArrayStack<int> numbersStack = new ArrayStack<int>();


        int[] array = new int[]{};
        int[] resultArray = numbersStack.ToArray();
        CollectionAssert.AreEqual(array, resultArray);
    }
}