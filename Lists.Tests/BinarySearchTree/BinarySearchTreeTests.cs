using System;
using NUnit.Framework;

namespace Lists.Tests
{
	[TestFixture]
	public class BinarySearchTreeTests
	{
		[Test]
		public void InsertTest ()
		{
			var tree = new BinarySearchTree<string>();
			tree.Insert("new value");
			
			Assert.AreEqual(1, tree.Height);
			Assert.IsNotNull(tree.Head);
		}
	}
}

