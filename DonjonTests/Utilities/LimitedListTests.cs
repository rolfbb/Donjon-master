using Microsoft.VisualStudio.TestTools.UnitTesting;
using Donjon.Utilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections;

namespace Donjon.Utilities.Tests
{
    [TestClass()]
    public class LimitedListTests
    {
        [TestMethod()]
        public void Instatiate_Keeps_Capacity()  // Constructor
        {
            //arrange
            int capacity = 4;
            //act
            LimitedList<object> limitedList = new LimitedList<object>(capacity);
            //assert
            Assert.AreEqual(capacity, limitedList.Capacity);
        }

        [TestMethod()]
        public void Add_When_Not_Full_Succeds()
        {
            //arrange
            var list = new LimitedList<object>(1);

            //act
            var added = list.Add(new object());

            //assert
            Assert.IsTrue(added);
        }

        [TestMethod()]
        public void Add_When_Full_Fails()
        {
            //arrange
            var list = new LimitedList<object>(1);
            list.Add(new object());

            //act
            var added = list.Add(new object());

            //assert
            Assert.IsFalse(added);
        }

        [TestMethod()]
        public void IsFull_Is_True_When_Not_Is_Full()
        {
            //arrange
            var list = new LimitedList<object>(2);
            list.Add(new object());

            //act
            bool isFull = list.IsFull;

            //assert
            Assert.IsFalse(isFull);
        }

        [TestMethod()]
        public void IsFull_Is_False_When_Is_Full()
        {
            //arrange
            var list = new LimitedList<object>(1);
            list.Add(new object());

            //act
            bool isFull = list.IsFull;

            //assert
            Assert.IsTrue(isFull);
        }

        [TestMethod()]
        public void Remove_Existing_Suceeds()
        {
            //arrange
            var obj = new object();
            var list = new LimitedList<object>(1);
            list.Add(obj);

            //act
            var removed = list.Remove(obj);

            //assert
            Assert.IsTrue(removed);
            foreach (var item in list) //inget obj ska vara samma som det borttagna
            {
                Assert.AreNotEqual(obj, item);
            }

        }

        [TestMethod()]
        public void Remove_NonExisting_Fails()
        {
            //arrange
            var obj1 = new object();
            var obj2 = new object();
            var list = new LimitedList<object>(1);
            list.Add(obj1);

            //act
            var removed = list.Remove(obj2);

            //assert
            Assert.IsFalse(removed);
        }

        [TestMethod()]
        public void Foreach_Returns_Contents()
        {
            //arrange
            object obj1 = 1;
            object obj2 = 2;
            var list = new LimitedList<object>(2);
            list.Add(obj1);
            list.Add(obj2);

            //act
            var result = new List<object>();
            //foreach (var item in (IEnumerable) list) //testar GetEnumerator() i LimitedList
            foreach (var item in list)
            {
                result.Add(item);
            }

            //assert - test att de pekar på samma referens
            Assert.AreEqual(obj1, result[0]);
            Assert.AreEqual(obj2, result[1]);
        }

    }
}