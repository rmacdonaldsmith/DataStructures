using System;
using System.Collections.Generic;

namespace Lists
{
	public class LinkedList<T>
	{
	    private int _size;
		private ListNode<T> _head;
        private ListNode<T> _tail;

	    public int Size
	    {
	        get { return _size; }
	    }

	    public ListNode<T> Head
		{
			get { return _head; }
		}

        public ListNode<T> Tail
		{
			get { return _tail; }
		}

	    public LinkedList()
	    {
            //empty
	    }

	    public LinkedList(IEnumerable<T> source)
	    {
	        foreach (var item in source)
	        {
	            AddFirst(item);
	        }
	    }

	    public void AddFirst(T item)
		{
		    if (Head != null)
		    {
		        var oldHead = Head;
		        var newNode = new ListNode<T>(oldHead, null, item);
		        oldHead.Next = newNode;
		        _head = newNode;
		    }
		    else
		    {
		        //the list is empty and we are adding the first item
		        var newNode = new ListNode<T>(null, null, item);
		        _head = newNode;
		    }

            _size++;
		}

	    public void AddLast(T item)
	    {
            if (Tail != null)
            {
                var oldTail = Tail;
                var newNode = new ListNode<T>(null, oldTail, item);
                oldTail.Previous = newNode;
                _tail = newNode;
            }
            else
            {
                //the list is empty and we are adding the first item
                var newNode = new ListNode<T>(null, null, item);
                _tail = newNode;
            }

            _size++;
	    }

	    public ListNode<T> Find(T valueToFind)
	    {
	        //return FindIteratively(valueToFind);
	        return FindRecursively(Head, valueToFind);
	    }

        private ListNode<T> FindIteratively(T valueToFind)
        {
            if (Head == null)
                return null;

            var node = Head;
            while (node != null)
            {
                if (node.Value.Equals(valueToFind))
                    return node;

                node = node.Previous;
            }

            return null;
        }

	    private ListNode<T> FindRecursively(ListNode<T> node, T valueToFind)
	    {
	        if (node == null)
	            return null;
	        
            if (node.Value.Equals(valueToFind))
	        {
	            return node;
	        }
	        
            return FindRecursively(node.Previous, valueToFind);
	    }

	    public void InsertBefore(ListNode<T> beforeThisNode, T itemToInsert)
	    {
	        var newNode = new ListNode<T>(itemToInsert);

	        if (beforeThisNode.Previous != null)
	        {
	            var previousNode = beforeThisNode.Previous;
	            beforeThisNode.Previous.Next = newNode;
	            newNode.Previous = previousNode;
	        }

	        beforeThisNode.Previous = newNode;
	        newNode.Next = beforeThisNode;
	        _size++;
	    }

	    public void Remove(T value)
	    {
	        var doomedNode = this.Find(value);

	        if (doomedNode == null)
	            return;

	        var previousNode = doomedNode.Previous;
	        var nextNode = doomedNode.Next;

	        if(previousNode != null)
                previousNode.Next = nextNode;
            
            if(nextNode != null)
	            nextNode.Previous = previousNode;

	        _size--;
	    }
	}
}

