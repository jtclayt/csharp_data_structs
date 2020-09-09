using System;
using System.Text;

namespace CSDataStructs.Code
{
    public class ArrayList<T>
    {
        int _size;
        int _maxSize;
        int _start;
        T[] _arr;

        public int Size
        {
            get { return _size; }
        }

        public ArrayList()
        {
            Clear();
        }

        public void Clear()
        {
            _size = 0;
            _start = 4;
            _maxSize = 8;
            _arr = new T[8];
        }

        public T Get(int index)
        {
            if (index < 0 || index >= _size)
            {
                throw new IndexOutOfRangeException($"Index {index} out of bounds");
            }
            return (T) _arr[_start + index];
        }

        public void InsertFront(T item)
        {
            checkOverCapacity();
            _start--;
            _arr[_start] = item;
            _size++;
        }

        public void InsertBack(T item)
        {
            checkOverCapacity();
            _arr[_start + _size] = item;
            _size++;
        }

        public void InsertAt(int index, T item)
        {
            if (index < 0 || index > _size)
            {
                throw new IndexOutOfRangeException($"Index {index} out of bounds");
            }

            checkOverCapacity();
            if (index == 0)
            {
                InsertFront(item);
            }
            else if (index == _size)
            {
                InsertBack(item);
            }
            else
            {
                for (int i = _size; i >= index; i--)
                {
                    int fixedIndex = i + _start;
                    _arr[fixedIndex+1] = _arr[fixedIndex];
                }
                _arr[index+_start] = item;
                _size++;
            }
        }

        public T RemoveFront()
        {
            if (_size == 0)
            {
                throw new IndexOutOfRangeException("List is empty");
            }
            T item = _arr[_start];
            _start++;
            _size--;
            checkUnderCapacity();
            return item;
        }

        public T RemoveBack()
        {
            if (_size == 0)
            {
                throw new IndexOutOfRangeException("List is empty");
            }
            T item = _arr[_start + _size - 1];
            _size--;
            checkUnderCapacity();
            return item;
        }

        public T RemoveAt(int index)
        {
            if (index < 0 || index >= _size)
            {
                throw new IndexOutOfRangeException($"Index {index} out of bounds");
            }
            T item = _arr[_start + index];
            for (int i = _start + index; i < _start + _size; i++)
            {
                _arr[i] = _arr[i+1];
            }
            _size--;
            checkUnderCapacity();
            return item;
        }

        public bool Contains(T item)
        {
            foreach(T arrItem in _arr)
            {
                if (item.Equals(arrItem))
                {
                    return true;
                }
            }
            return false;
        }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();

            sb.Append("[");

            for (int i = _start; i < (_start + _size - 1); i++) {
                sb.Append($"{_arr[i]}, ");
            }

            if (_size > 0) {
                sb.Append(_arr[_start + _size - 1]);
            }

            sb.Append("]");
            return sb.ToString();
        }

        private void checkOverCapacity()
        {
            int overCap = _maxSize / 4;
            int leftCap = _start;
            int rightCap = _maxSize - _start - _size;
            if (leftCap <= overCap || rightCap <= overCap) {
                changeArray(true);
            }
        }

        private void checkUnderCapacity()
        {
            if (_size > 8 && _size < _maxSize / 8)
            {
                changeArray(false);
            }
        }

        private void changeArray(bool isExtend)
        {
            int newMax = (isExtend) ? _maxSize * 4 : _maxSize / 4;
            int newStart = (newMax - _size) / 2;
            T[] newArr = new T[newMax];
            for (int i = 0; i < _size; i++) {
                newArr[newStart + i] = _arr[_start + i];
            }
            _arr = newArr;
            _maxSize = newMax;
            _start = newStart;
        }
    }
}
