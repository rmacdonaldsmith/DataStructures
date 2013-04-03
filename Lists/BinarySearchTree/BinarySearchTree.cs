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
            if (_head == null)
            {
                var newNode = new TreeNode<T>(value);

                _head = newNode; //this is where we link the new node in to the tree
                //because this is a recursive function, node will be either the Left or Right
                //node from the call above, or it will be the head
                _height++;
                return;
            }

            InsertInternal(value, _head);
		}

	    private void InsertInternal(T value, TreeNode<T> parent)
	    {
	        if (value.CompareTo(parent.Value) < 0)
	        { 
	            if (parent.Left == null) //insert here - we have found the leaf
	            {
	                var newNode = new TreeNode<T>(value);
	                parent.Left = newNode;
                    _height++;
	                return;
	            }
                //Insert somewhere in the Left side of the tree
                InsertInternal(value, parent.Left);
	        }
	        else
	        {
	            if (parent.Right == null)
	            {
	                var newNode = new TreeNode<T>(value);
	                parent.Right = newNode;
                    _height++;
	                return;
	            }
                //Insert somewhere in the Right side of the tree
                InsertInternal(value, parent.Right);
	        }
	    }
	}
}

