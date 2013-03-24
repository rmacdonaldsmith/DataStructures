using System;

namespace Lists
{
	public class BinarySearchTree<T> where T : IComparable
	{
		private TreeNode<T> _head;
		private int _height;
		
		public TreeNode<T> Head
		{
			get { return _head; }
		}
		
		public int Height
		{
			get { return _height; }
		}
		
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
			InsertInternal(_head, value);
		}
		
		public void InsertInternal(TreeNode<T> tree, T value)
		{
			if(tree == null)
			{
				var newNode = new TreeNode<T>(null, null, value);
				
				tree = newNode; //this is where we link the new node in to the tree
								//because this is a recursive function, tree will be either the Left or Right
								//node from the call above, or it will be the head
				_height++;
				return;
			}
			
			if(value.CompareTo(tree.Left.Value) < 0)
				InsertInternal(tree.Left, value);
			else
				InsertInternal(tree.Right, value);
		}
	}
}

