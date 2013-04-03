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
		    set { _left = value; }
		}

	    public TreeNode<T> Right
		{
			get {return _right; }
            set { _right = value; }
		}
		
		public T Value
		{
			get { return _value; }
		}

	    public TreeNode(T value)
	    {
	        _value = value;
	    }

	    public TreeNode (TreeNode<T> left, TreeNode<T> right, T value)
		{
			_left = left;
			_right = right;
			_value = value;
		}
	}
}

