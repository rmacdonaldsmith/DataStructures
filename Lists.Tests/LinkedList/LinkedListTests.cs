using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using NUnit.Framework;

namespace Lists.Tests.LinkedList
{
    [TestFixture]
    public class LinkedList
    {
        [Test]
        public void ConstructorTests()
        {
            Assert.IsNotNull(new LinkedList<string>());
        }

        [Test]
        public void AddTests()
	    {
	        var list = new LinkedList<string>();
            list.AddFirst("Robert");
            Assert.AreEqual("Robert", list.Head.Value);
            Assert.IsNull(list.Tail);
            Assert.AreEqual(1, list.Size);

            //add another item
            list.AddFirst("Macdonald Smith");
            Assert.AreEqual("Macdonald Smith", list.Head.Value);
            Assert.AreEqual("Robert", list.Head.Previous.Value);
            Assert.AreEqual(2, list.Size);

            //add to the other end of the list
            list.AddLast("Last");
            Assert.AreEqual("Macdonald Smith", list.Head.Value);
            Assert.AreEqual("Robert", list.Head.Previous.Value);
            Assert.AreEqual("Last", list.Tail.Value);
            Assert.AreEqual(3, list.Size);
	    }

        [Test]
        public void SearchInsertRemoveTests()
        {
            var list = new LinkedList<string>(new []{"first", "second", "third", "forth"});
            Assert.AreEqual(4, list.Size);

            //search for the value "first"
            var retrievedFirst = list.Find("first");
            Assert.IsNotNull(retrievedFirst);
            Assert.AreEqual("first", retrievedFirst.Value);

            //search for the value "forth"
            var retrievedForth = list.Find("forth");
            Assert.IsNotNull(retrievedForth);
            Assert.AreEqual("forth", retrievedForth.Value);

            //search for the value "second"
            var retrieved = list.Find("second");
            Assert.IsNotNull(retrieved);
            Assert.AreEqual("second", retrieved.Value);

            //insert a new node with value "1.5" before the node we just found
            var beforeThisNode = retrieved;
            list.InsertBefore(beforeThisNode, "1.5");
            var foundItAfterInsert = list.Find("1.5");
            Assert.AreSame(beforeThisNode, foundItAfterInsert.Next);
            Assert.AreSame(beforeThisNode.Previous, foundItAfterInsert);
            Assert.AreEqual(5, list.Size);

            //remove the node with the value "third"
            list.Remove("third");
            Assert.AreEqual(4, list.Size);
            Assert.IsNull(list.Find("third"));

            //remove the node with the value "first"
            list.Remove("first");
            Assert.AreEqual(3, list.Size);
            Assert.IsNull(list.Find("first"));
        }
    }
}
