using System;
using System.Collections.Generic;

namespace Lists.BinarySearchTree
{
	public class BinarySearchTree<T> where T : IComparable
	{
		private TreeNode<T> _head;
		private int _height;
	    private readonly Func<T, T, int> _distanceDelegate;
		
		public TreeNode<T> Head
		{
			get { return _head; }
		}
		
		public int Height
		{
			get { return _height; }
		}
		
		public BinarySearchTree (Func<T, T, int> distanceDelegate)
		{
		    _distanceDelegate = distanceDelegate;
		    //empty
		}

	    public BinarySearchTree(TreeNode<T> head, Func<T, T, int> distanceDelegate)
	    {
	        _head = head;
	        _distanceDelegate = distanceDelegate;
	    }

	    public BinarySearchTree(IEnumerable<T> source, Func<T, T, int> distanceDelegate)
	    {
	        _distanceDelegate = distanceDelegate;
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
	        return FindNearestNodeInternal(value, _head);
	    }

	    private TreeNode<T> FindNearestNodeInternal(T value, TreeNode<T> node)
	    {
            //do we go left of right from here?
	        var comparison = value.CompareTo(node.Value);

            if (comparison > 0) //RIGHT
            {
                //is the search value greater than the Right value?
                if (value.CompareTo(node.Right.Value) > 0)
                {
                    //recurse
                    return FindNearestNodeInternal(value, node.Right);
                }

                //else the search value is in between the current node and the right node
                //which is closest to the value: this node or node.right?
                return Nearest(node, node.Right, value);
            }

            //else LEFT
	        //is the search value less than the Left value?
	        if (value.CompareTo(node.Left.Value) < 0)
	            return FindNearestNodeInternal(value, node.Left); //he value is somewhere left of here, recurse

	        //else the search value lies between the current node and the left node
	        return Nearest(node, node.Left, value);
	    }

	    private TreeNode<T> Nearest(TreeNode<T> n1, TreeNode<T> n2, T value)
	    {
	        var distance1 = Math.Abs(_distanceDelegate(n1.Value, value));
	        var distance2 = Math.Abs(_distanceDelegate(n2.Value, value));

	        if (distance1 == distance2)
                return n1; // default behaviour if both nodes are equidistant from the value.

	        return distance1 < distance2 ? n1 : n2;
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

