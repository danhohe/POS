using Microsoft.VisualStudio.TestTools.UnitTesting;
using MyList;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyList.Tests
{
    [TestClass()]
    public class LinkedListTests
    {
        private IList _list;

        [TestInitialize]
        public void Setup()
        {
            // Hier sollte die konkrete Implementierung von IList verwendet werden
            _list = new LinkedList(); // Beispiel: Ersetze MyConcreteList durch eine konkrete Klasse
        }

        // Testfälle für Count
        [TestMethod]
        public void Count_Initial_ShouldBeZero()
        {
            Assert.AreEqual(0, _list.Count);
        }

        [TestMethod]
        public void Count_AfterAddingOneElement_ShouldBeOne()
        {
            _list.Add(new object());
            Assert.AreEqual(1, _list.Count);
        }

        [TestMethod]
        public void Count_AfterAddingMultipleElements_ShouldBeCorrect()
        {
            _list.Add(new object());
            _list.Add(new object());
            Assert.AreEqual(2, _list.Count);
        }

        [TestMethod]
        public void Count_AfterRemovingElement_ShouldBeCorrect()
        {
            var item = new object();
            _list.Add(item);
            _list.Remove(item);
            Assert.AreEqual(0, _list.Count);
        }

        [TestMethod]
        public void Count_AfterClear_ShouldBeZero()
        {
            _list.Add(new object());
            _list.Clear();
            Assert.AreEqual(0, _list.Count);
        }

        // Testfälle für Add
        [TestMethod]
        public void Add_Null_ShouldAddNull()
        {
            _list.Add(null);
            Assert.AreEqual(1, _list.Count);
        }

        [TestMethod]
        public void Add_SingleElement_ShouldBeAdded()
        {
            var item = new object();
            _list.Add(item);
            Assert.AreEqual(1, _list.Count);
        }

        [TestMethod]
        public void Add_MultipleSameElements_ShouldBeAdded()
        {
            var item = new object();
            _list.Add(item);
            _list.Add(item);
            Assert.AreEqual(2, _list.Count);
        }

        [TestMethod]
        public void Add_DifferentTypes_ShouldAddElements()
        {
            _list.Add("string");
            _list.Add(42);
            Assert.AreEqual(2, _list.Count);
        }

        [TestMethod]
        public void Add_MultipleElements_CountShouldBeCorrect()
        {
            _list.Add(new object());
            _list.Add(new object());
            Assert.AreEqual(2, _list.Count);
        }

        // Testfälle für Clear
        [TestMethod]
        public void Clear_EmptyList_ShouldNotThrow()
        {
            _list.Clear();
            Assert.AreEqual(0, _list.Count);
        }

        [TestMethod]
        public void Clear_SingleElement_ShouldClearList()
        {
            _list.Add(new object());
            _list.Clear();
            Assert.AreEqual(0, _list.Count);
        }

        [TestMethod]
        public void Clear_MultipleElements_ShouldClearList()
        {
            _list.Add(new object());
            _list.Add(new object());
            _list.Clear();
            Assert.AreEqual(0, _list.Count);
        }

        [TestMethod]
        public void Clear_CountShouldBeZeroAfterClear()
        {
            _list.Add(new object());
            _list.Clear();
            Assert.AreEqual(0, _list.Count);
        }

        [TestMethod]
        public void Clear_ThenAdd_ShouldAllowAddingAfterClear()
        {
            _list.Add(new object());
            _list.Clear();
            _list.Add(new object());
            Assert.AreEqual(1, _list.Count);
        }

        // Testfälle für Remove
        [TestMethod]
        public void Remove_ElementPresent_ShouldRemoveElement()
        {
            var item = new object();
            _list.Add(item);
            _list.Remove(item);
            Assert.AreEqual(0, _list.Count);
        }

        [TestMethod]
        public void Remove_ElementNotPresent_ShouldNotThrow()
        {
            _list.Remove(new object());
            Assert.AreEqual(0, _list.Count);
        }

        [TestMethod]
        public void Remove_NullElement_ShouldNotThrow()
        {
            _list.Add(null);
            _list.Remove(null);
            Assert.AreEqual(0, _list.Count);
        }

        [TestMethod]
        public void Remove_MultipleSameElements_ShouldRemoveOnlyOne()
        {
            var item = new object();
            _list.Add(item);
            _list.Add(item);
            _list.Remove(item);
            Assert.AreEqual(1, _list.Count);
        }

        [TestMethod]
        public void Remove_CountShouldBeCorrectAfterRemoval()
        {
            var item = new object();
            _list.Add(item);
            _list.Remove(item);
            Assert.AreEqual(0, _list.Count);
        }
    }
}