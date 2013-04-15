using System;
using System.Collections.Generic;

namespace Lists.BinarySearchTree
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

        public BinarySearchTree()
        { 
            //empty
        }

	    public BinarySearchTree(TreeNode<T> head)
	    {
	        _head = head;
	    }

	    public BinarySearchTree(IEnumerable<T> source)
	    {
	        foreach (var value in source)
	        {
	            Insert(value);
	        }
	    }

	    public TreeNode<T> Find(T value)
	    {
	        return FindRecursive(value, _head);
	    }

	    private TreeNode<T> FindRecursive(T value, TreeNode<T> node)
	    {
	        if (node == null)
	            return null;

	        var comparison = value.CompareTo(node.Value);
            if (comparison == 0)
                return node;

	        if (comparison < 0)
	            return FindRecursive(value, node.Left);
	        else
	            return FindRecursive(value, node.Right);
	    }

	    public TreeNode<T> FindNearestNode(T value)
	    {
	        var nearestNode =  FindNearestNodeInternal(value, _head);

            //we need to check the nearest node against the root to see which is closest
            //as a last check before returning - this algo will fail to return the correct
            //nearest if the nearest is the root node.

	        return nearestNode;
	    }

	    private TreeNode<T> FindNearestNodeInternal(T value, TreeNode<T> node)
	    {
            //do we go left of right from here?
	        var comparison = value.CompareTo(node.Value);

            if (comparison > 0) //RIGHT
            {
                //if the right node from here is null then this node if the nearest
                if (node.Right == null)
                    return node;

                //else nearest to the search value lies somewhere right of here
                return FindNearestNodeInternal(value, node.Right);
            }

            //else LEFT
            //if the left node from here is null then this node if the nearest
	        if (node.Left == null)
	            return node;

	        //else nearest to the search value lies somewhere left of here
            return FindNearestNodeInternal(value, node.Left);
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

	    public void Delete(T Value)
	    {

	    }
	}
}

