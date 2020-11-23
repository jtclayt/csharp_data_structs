using System;
using System.Text;

namespace CSDataStructs.Code
{
    public class IntBinarySearchTree
    {
        private Node _root;
        private int _size;

        public int Size
        {
            get { return _size; }
        }

        private class Node
        {
            public int Value;
            public Node Left;
            public Node Right;

            public Node(int v)
            {
                Value = v;
                Left = null;
                Right = null;
            }
        }

        public IntBinarySearchTree()
        {
            Clear();
        }

        public void Clear()
        {
            _root = null;
            _size = 0;
        }

        public void Insert(int value)
        {

            if (_root == null)
            {
                _root = new Node(value);
                _size = 1;
            }
            else
            {
                Node parent = findParent(value);

                if (value < parent.Value)
                {
                    parent.Left = new Node(value);
                    _size++;
                }
                else if (value > parent.Value)
                {
                    parent.Right = new Node(value);
                    _size++;
                }
            }
        }

        public void Remove(int value)
        {
            _root = removeR(_root, value, out bool removedNode);

            if (removedNode)
            {
                _size--;
            }
        }

        public bool Contains(int value)
        {
            Node foundNode = find(value);
            return foundNode != null;
        }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            if (_root != null)
            {
                inOrderTraverse(_root, sb);
            }
            return sb.ToString();
        }

        private void inOrderTraverse(Node curr, StringBuilder sb)
        {
            if (curr.Left != null)
            {
                inOrderTraverse(curr.Left, sb);
            }
            sb.Append($"{curr.Value} ");
            if (curr.Right != null)
            {
                inOrderTraverse(curr.Right, sb);
            }
        }

        private Node removeR(Node root, int value, out bool removed)
        {
            removed = false;
            if (root != null)
            {
                if (value < root.Value)
                {
                    root.Left = removeR(root.Left, value, out removed);
                }
                else if (value > root.Value)
                {
                    root.Right = removeR(root.Right, value, out removed);
                }
                else
                {
                    if (root.Right != null)
                    {
                        root.Value = findMinVal(root.Right);
                        root.Right = removeR(root.Right, root.Value, out removed);
                    }
                    else if (root.Left != null)
                    {
                        root.Value = findMinVal(root.Left);
                        root.Left = removeR(root.Left, root.Value, out removed);
                    }
                    else
                    {
                        root = null;
                    }
                    removed = true;
                }
            }
            return root;
        }

        private int findMinVal(Node root)
        {
            if (root.Left != null)
            {
                return findMinVal(root.Left);
            }
            return root.Value;
        }

        private Node find(int value)
        {
            if (_root == null)
            {
                return _root;
            }

            Node curr = _root;
            while (curr != null)
            {
                if (value < curr.Value)
                {
                    curr = curr.Left;
                }
                else if (value > curr.Value)
                {
                    curr = curr.Right;
                }
                else if (value == curr.Value)
                {
                    return curr;
                }
            }

            return null;
        }

        private Node findParent(int value)
        {
            Node curr = _root;

            while(curr != null)
            {
                if (value < curr.Value && curr.Left != null)
                {
                    curr = curr.Left;
                }
                else if (value > curr.Value && curr.Right != null)
                {
                    curr = curr.Right;
                }
                else
                {
                    break;
                }
            }
            return curr;
        }
    }
}
