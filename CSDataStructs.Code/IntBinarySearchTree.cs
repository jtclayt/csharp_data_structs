using System;

namespace CSDataStructs.Code
{
    public class IntBinarySearchTree
    {
        private int[] _tree;
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
            _tree = new int[8];
            _size = 0;
        }

        public void Insert(int value)
        {
            throw new NotImplementedException();
        }

        public void Remove(int value)
        {
            throw new NotImplementedException();
        }

        public bool Contains(int value)
        {
            throw new NotImplementedException();
        }
    }
}
