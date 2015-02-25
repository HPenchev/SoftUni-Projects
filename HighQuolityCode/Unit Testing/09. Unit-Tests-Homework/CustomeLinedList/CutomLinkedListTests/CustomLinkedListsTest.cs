using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using CustomLinkedList;

namespace CutomLinkedListTests
{
    [TestClass]
    public class CustomLinkedListsTest
    {
        private DynamicList<int> list;

        [TestInitialize]
        public void InitializaList()
        {
            this.list = new DynamicList<int>();
            this.list.Add(1);
            this.list.Add(2);
            this.list.Add(3);
        }

        [TestMethod]
        public void TestCountAfterPushingThreeItmesAndRemovingOne()
        {            
            this.list.RemoveAt(2);
            Assert.AreEqual(2, this.list.Count, "Counter doesn't work correctly");
        }

        [TestMethod]
        public void TestAdd()
        {           
            string assertMessage = "Items not added correctly";
            Assert.AreEqual(1, this.list[0], assertMessage);
            Assert.AreEqual(2, this.list[1], assertMessage);
            Assert.AreEqual(3, this.list[2], assertMessage);
        }

        [TestMethod]
        public void TestRemoveAt()
        {            
            int removedItem = this.list.RemoveAt(1);
            Assert.AreEqual(3, this.list[1], "Item not removed correctly");
            Assert.AreEqual(2, removedItem, "Removed item not returned correctly");
        }

        [TestMethod]
        public void TestRemove()
        {
            int removedItem = this.list.Remove(1);
            Assert.AreEqual(2, this.list[0], "Item not removed correctly");
            int unexistingItem = this.list.Remove(5);
            Assert.AreEqual(-1, unexistingItem, "Non-existing item position not removed correctlu (-1 expected)");
        }

        [TestMethod]
        public void TestIndexOf()
        {
            int itemPosition = this.list.IndexOf(1);
            Assert.AreEqual(0, itemPosition, "Index of an item not returned correctly");
            int unexistingItemPosition = this.list.IndexOf(5);
            Assert.AreEqual(-1, unexistingItemPosition, "Non-existing item position not removed correctlu" + 
                "(-1 expected)");
        }

        [TestMethod]
        public void TestReachGetByIndex()
        {
            int item = this.list[0];
            Assert.AreEqual(1, item, "Item not reached by index");
        }

        [TestMethod]
        public void TestReachSetByIndex()
        {
            this.list[0] = 4;
            Assert.AreEqual(4, this.list[0], "Item not set by index correctly");
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void TestReachIndexOutOfRange()
        {
            this.list.RemoveAt(2);
            int item = this.list[2];            
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void TestSetIndexOutOfRange()
        {
            this.list[4] = 0;
        }  
    }
}