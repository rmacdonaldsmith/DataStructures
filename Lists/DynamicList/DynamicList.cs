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
			
			_backingStore = (T[])source.Count();
			_count = _backingStore.Length;
			_indexOfTopElement = _count - 1;
			//we will want to increase the size of the backing store - doulbe it in size
		}
		
		public void Add(T item)
		{
			CheckAndResizeArray(1);
			_backingStore[_indexOfTopElement++] = item;
		}
		
		private void CheckAndResizeArray(int numberOfItemsToAdd)
		{
			if(_count + numberOfItemsToAdd >= _backingStore.Length)
			{
				//double the size of the array
				var newArray = new T[_count * 2];
				Array.Copy(_backingStore, newArray, newArray.Length);
				_backingStore = newArray;
			}
		}
	}
}

