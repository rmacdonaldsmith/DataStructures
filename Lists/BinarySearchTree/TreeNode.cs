using System;

namespace Lists
{
	public class TreeNode<T>
	{
		private TreeNode<T> _left;
		private TreeNode<T> _right;
		private T _value;
		
		public TreeNode<T> Left
		{
			get { return _left; }
		}
		
		public TreeNode<T> Right
		{
			get {return _right; }
		}
		
		public T Value
		{
			get { return _value; }
		}
		
		public TreeNode (TreeNode<T> left, TreeNode<T> right, T value)
		{
			_left = left;
			_right = right;
			_value = value;
		}
	}
}

