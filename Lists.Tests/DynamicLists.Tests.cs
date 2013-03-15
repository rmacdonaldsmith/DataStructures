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
			
			var list2 = new DynamicList<int>(100);
			Assert.IsNotNull(list2);
			
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
		}
	}
}

