using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Lists;
using NUnit.Framework;
using Lists.BinarySearchTree;

namespace DataStructureTests.BinarySearchTree
{
    [TestFixture]
    public class when_finding_nearest_value
    {
        private BinarySearchTree<int> _btree;

        [SetUp]
        public void given_a_Btree_with_data()
        {
            _btree = new BinarySearchTree<int>(new[] { 12, 43, 6, 7, 34, 24, 16, 456, 1, 4, 9 }, (n1, n2) => n1 - n2);
        }

        [Test]
        public void then_we_find_the_nearest_node_in_the_tree()
        {
            //it appears that I must visit all nodes to find the nearest node
            //

            var nearestNode = _btree.FindNearestNode(18);

            Assert.IsNotNull(nearestNode);
            Assert.AreEqual(16, nearestNode.Value);
        }
    }
}
