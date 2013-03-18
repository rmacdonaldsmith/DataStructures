using System;
using System.Collections.Generic;

namespace Lists
{
	public class DynamicList<T>
	{
		private readonly int _defaultSize = 10;
		private T[] _backingStore;
		private int _indexOfTopElement = 0;
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
			_indexOfTopElement = _count - 1;
			//we will want to increase the size of the backing store - doulbe it in size
		}
		
		public void Add(T item)
		{
			CheckAndResizeArray(1);
			_backingStore[_indexOfTopElement++] = item;
			_count++;
			_indexOfTopElement = _count - 1;
		}
		
		public void Delete(int index)
		{
			if(index > _backingStore.Length)
				throw new IndexOutOfRangeException(
					string.Format("Index {0} is beyond the size of the list {1}.", 
				              index, _backingStore.Length));
			
			//interesting problem here: how do we want to remove an item?
			//do we want to reclaim the space of the item deleted and move the items above it down?
			
			T[] newArray = new T[_backingStore.Length - 1]();
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
		}
		
		public T ItemAtIndex(int index)
		{
			if(index > _backingStore.Length)
				throw new IndexOutOfRangeException(
					string.Format("Index {0} is beyond the size of the list {1}.", 
				              index, _backingStore.Length));
			
			return _backingStore[index];
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

