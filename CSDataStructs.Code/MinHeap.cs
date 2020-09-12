using System;

namespace CSDataStructs.Code
{
    public class MinIntHeap
    {
        private int[] _heap;
        private int _size;

        public int Size
        {
            get { return _size; }
        }

        public MinIntHeap()
        {
            Clear();
        }

        public void Clear()
        {
            _heap = new int[8];
            _size = 0;
        }

        public void insert(int num)
        {
            throw new NotImplementedException();
        }

        public int peekMin()
        {
            throw new NotImplementedException();
        }

        public int getMin()
        {
            throw new NotImplementedException();
        }
    }
}
