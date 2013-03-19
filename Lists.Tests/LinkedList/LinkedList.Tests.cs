using System;
namespace Lists.Tests
{
	[TestFixture]
	public class LinkedList
	{
		[Tests]
		public void ConstructorTests()
		{
			Assert.IsNotNull(new LinkedList<string>());
			Assert.IsNotNull(new LinkedList<string>("robert"));
			
		}
	}
}

