using System;

namespace Lists
{
	public class LinkedList<T>
	{
		private ListNode<T> _head;
		private LinkedList<T> _tail;
		
		public ListNode<T> Head
		{
			get { return _head; }
		}
		
		public LinkedList<T> Tail
		{
			get { return _tail; }
		}
		
		public void Add(T item)
		{
			var node = new ListNode<T>(_tail.Head, _head, item);
			_head = node;
		}
		
		
	}
}

