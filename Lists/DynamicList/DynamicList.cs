using System;
using System.Collections.Generic;

namespace Lists
{
	public class DynamicList<T>
	{
		private readonly int _defaultSize = 10;
		private T[] _backingStore;
		private int _count;
		
		public int Count
		{
			get { return _count; }
		}
		
		public DynamicList ()
		{
			_backingStore = new T[_defaultSize];
		}
		
		public DynamicList(int size)
			: this()
		{
			_defaultSize = size;
		}
		
		public DynamicList(IEnumerable<T> source)
		{
			
			_backingStore = (T[])source;
			_count = _backingStore.Length;
			//we will want to increase the size of the backing store - double it in size
		}
		
		public void Add(T item)
		{
			CheckAndResizeArray(1);
			_backingStore[_count++] = item;
		}
		
		public void Delete(int index)
		{
			if(index > _backingStore.Length)
				throw new IndexOutOfRangeException(
					string.Format("Index {0} is beyond the size of the list {1}.", 
				              index, _backingStore.Length));
			
			//interesting problem here: how do we want to remove an item?
			//do we want to reclaim the space of the item deleted and move the items above it down?
			
			T[] newArray = new T[_backingStore.Length - 1];
			int arrayIndex = 0;
			int newArrayIndex = 0;
			
			while(arrayIndex < _backingStore.Length)
			{
				if(arrayIndex != index)
				{
					newArray[newArrayIndex] = _backingStore[arrayIndex];
					newArrayIndex++;
				}
				
				arrayIndex++;
			}
			
			_backingStore = newArray;
		    _count = _backingStore.Length;
		}
		
		public T ItemAtIndex(int index)
		{
			if(index > _backingStore.Length)
				throw new IndexOutOfRangeException(
					string.Format("Index {0} is beyond the size of the list {1}.", 
				              index, _backingStore.Length));
			
			return _backingStore[index];
		}

	    public T Find(T itemToFind)
	    {
	        //assumes unsorted items in the list, which means we must iterate every item to find
            //what we are looking for.
            //if it were a sorted list: we can employ a binary search and get much better search times
            //also want to introduce an IComparable to let the user specify a comparer rather than use the default.
	        for (int index = 0; index < _backingStore.Length; index++)
	        {
	            T item = _backingStore[index];
	            if (item.Equals(itemToFind))
	                return item;
	        }

	        return default(T);
	    }
		
	    public void Clear()
	    {
            Array.Clear(_backingStore, 0, _count);
	        _count = 0;
	    }

	    private void CheckAndResizeArray(int numberOfItemsToAdd)
		{
			if(_count + numberOfItemsToAdd >= _backingStore.Length)
			{
				//double the size of the array
				var newArray = new T[_backingStore.Length * 2];
				Array.Copy(_backingStore, newArray, newArray.Length);
				_backingStore = newArray;
			}
		}
	}
}

