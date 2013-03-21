using System;

namespace Lists
{
	public class BinarySearchTree<T>
	{
		private TreeNode<T> _head;
		
		public BinarySearchTree ()
		{
			//empty
		}
		
		public BinarySearchTree(TreeNode<T> head)
		{
			_head = head;
		}
		
		public void Insert(T value)
		{
			//search the tree for the value, insert when we get to NULL
		}
	}
}

