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

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();

            sb.Append("[");

            for (int i = _start; i < (_start + _size - 1); i++) {
                sb.Append($"{_arr[i]}, ");
            }

            if (_size > 0) {
                sb.Append(_arr[(_start + _size - 1)]);
            }
            sb.Append("]");
            return sb.ToString();
        }

        private void checkOverCapacity() {
            if (_start < _maxSize / 4 || (_maxSize - _start - _size) <= (_maxSize / 4) || _size > _maxSize / 4 * 3) {
                extend();
            }
        }

        private void extend() {
            int newMax = _maxSize * 4;
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
