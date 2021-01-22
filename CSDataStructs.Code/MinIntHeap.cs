namespace CSDataStructs.Code
{
    using System;

    public class MinIntHeap
    {
        private int[] _arr;
        private int _size;

        public int Size
        {
            get { return _size; }
        }

        public MinIntHeap()
        {
            Clear();
        }

        #region Public Methods
        public void Clear()
        {
            _arr = new int[8];
            _size = 0;
        }

        public void Insert(int num)
        {
            checkCapacity();
            _arr[_size] = num;
            bubbleUp();
            _size++;
        }

        public int PeekMin()
        {
            if (_size == 0)
            {
                throw new IndexOutOfRangeException("Heap is empty");
            }
            return _arr[0];
        }

        public int GetMin()
        {
            if (_size == 0)
            {
                throw new IndexOutOfRangeException("Heap is empty");
            }
            int temp = _arr[0];
            _size--;
            _arr[0] = _arr[_size];
            sinkDown();
            checkCapacity();
            return temp;
        }
        #endregion

        #region Private Methods
        private void checkCapacity()
        {
            if (_size >= _arr.Length / 2)
            {
                resize(_arr.Length * 2);
            }
            else if (_size < _arr.Length / 4 && _size > 8)
            {
                resize(_arr.Length / 2);
            }
        }

        private void resize(int newMax)
        {
            int[] newArr = new int[newMax];
            for (int i = 0; i < _size; i++)
            {
                newArr[i] = _arr[i];
            }
            _arr = newArr;
        }

        private void bubbleUp()
        {
            int currIndex = _size;
            while (_arr[parent(currIndex)] > _arr[currIndex])
            {
                swap(parent(currIndex), currIndex);
                currIndex = parent(currIndex);
            }
        }

        private void sinkDown(int currIndex = 0)
        {
            int leftIdx = leftChild(currIndex);
            int rightIdx = rightChild(currIndex);
            int minIdx = -1;
            if (rightIdx < _size && _arr[rightIdx] < _arr[leftIdx])
            {
                minIdx = rightIdx;
            }
            else if (leftIdx < _size)
            {
                minIdx = leftIdx;
            }

            if (minIdx != -1 && _arr[currIndex] > _arr[minIdx])
            {
                swap(currIndex, minIdx);
                sinkDown(minIdx);
            }
        }

        private void swap(int idx1, int idx2)
        {
            int temp = _arr[idx1];
            _arr[idx1] = _arr[idx2];
            _arr[idx2] = temp;
        }

        private int parent(int index)
        {
            return (index - 1) / 2;
        }

        private int leftChild(int index)
        {
            return 2 * (index + 1) - 1;
        }

        private int rightChild(int index)
        {
            return 2 * (index + 1);
        }
        #endregion
    }
}
