using System;

namespace Lists
{
	public class ListNode<T>
	{
		private ListNode<T> _previous;
		private ListNode<T> _next;
		private T _data;
		
		public ListNode(T dataItem)
			: this(null, null, dataItem)
		{
			//empty
		}
		
		public ListNode (ListNode<T> previousNode, ListNode<T> nextNode, T dataItem)
		{
			_previous = previousNode;
			_next = nextNode;
			_data = dataItem;
		}
	}
}

