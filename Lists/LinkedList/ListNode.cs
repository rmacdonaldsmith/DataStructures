using System;

namespace Lists
{
	public class ListNode<T>
	{
		private ListNode<T> _previous;
		private ListNode<T> _next;
		private T _value;

	    public ListNode<T> Previous
	    {
	        get { return _previous; }
	        set { _previous = value; }
	    }

	    public ListNode<T> Next
	    {
	        get { return _next; }
	        set { _next = value; }
	    }

	    public T Value
	    {
	        get { return _value; }
	    }

	    public ListNode(T dataItem)
			: this(null, null, dataItem)
		{
			//empty
		}
		
		public ListNode (ListNode<T> previousNode, ListNode<T> nextNode, T dataItem)
		{
			_previous = previousNode;
			_next = nextNode;
			_value = dataItem;
		}
	}
}

