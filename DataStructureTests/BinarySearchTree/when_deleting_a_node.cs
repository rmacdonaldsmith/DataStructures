using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Lists.BinarySearchTree;
using NUnit.Framework;

namespace DataStructureTests.BinarySearchTree
{
    [TestFixture]
    public class when_deleting_a_node
    {
        private BinarySearchTree<int> _btree;

        [SetUp]
        public void given_a_Btree_with_data()
        {
            _btree = new BinarySearchTree<int>(new[] { 12, 43, 6, 7, 34, 24, 16, 456, 1, 4, 9 });
        }

        [Test]
        public void when_deleting_a_node_in_the_middle()
        {
            _btree.Delete(6);
            Assert.IsNull(_btree.Find(6));
            Assert.AreEqual(11, _btree.Height);
            Assert.AreEqual(0, _btree.Find(12).Left); //need to fix this assertion
        }
    }
}
