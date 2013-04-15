using System;
using Lists.BinarySearchTree;
using NUnit.Framework;
using Lists;

namespace DataStructureTests.BinarySearchTreeTests
{
	[TestFixture]
	public class BinarySearchTreeTests
	{
		[Test]
		public void InsertTest ()
		{
			var tree = new BinarySearchTree<int>();
			tree.Insert(10);
			Assert.AreEqual(1, tree.Height);
			Assert.IsNotNull(tree.Head);

            tree.Insert(8);
            Assert.AreEqual(2, tree.Height);

            tree.Insert(12);
            Assert.AreEqual(3, tree.Height);
		}
	}
}

