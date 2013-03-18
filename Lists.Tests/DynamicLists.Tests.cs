using System;
using NUnit.Framework;

namespace Lists.Tests
{
	[TestFixture()]
	public class DynamicLists
	{
		[Test()]
		public void ConstructorTests()
		{
			var list1 = new DynamicList<int>();
			Assert.IsNotNull(list1);
			Assert.AreEqual(0, list1.Count);
			
			var list2 = new DynamicList<int>(100);
			Assert.IsNotNull(list2);
			Assert.AreEqual(0, list2.Count);
			
			var source = new int[2]{12, 13};
			var list3 = new DynamicList<int>(source);
			Assert.IsNotNull(list3);
			Assert.AreEqual(2, list3.Count);
		}
		
		[Test()]
		public void AddTests()
		{
			var list = new DynamicList<int>();
			list.Add(1);
			Assert.AreEqual(1, list.Count);
            Assert.AreEqual(1, list.ItemAtIndex(0));
		}
		
		[Test]
		public void IndexTests()
		{
			var list = new DynamicList<int>(new []{1,2,3,4,5,6});
			Assert.AreEqual(1, list.ItemAtIndex(0));
			Assert.Throws<IndexOutOfRangeException>(() => list.ItemAtIndex(8));
		}
		
		[Test]
		public void DeleteTests()
		{
			var list = new DynamicList<int>(new []{1,2,3,4,5,6});
			Assert.AreEqual(6, list.Count);
			list.Delete(0);
			Assert.AreEqual(5, list.Count);
            Assert.AreEqual(2, list.ItemAtIndex(0));
		}

	    [Test]
	    public void FindTest()
	    {
	        var list = new DynamicList<int>(new int[]{1,2,3,4,5,6});
	        int found = list.Find(2);
            Assert.AreEqual(2, found);
	    }
	}
}

