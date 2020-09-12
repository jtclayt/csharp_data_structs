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
