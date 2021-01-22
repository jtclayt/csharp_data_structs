namespace CSDataStructs.Code
{
    using System;

    public class Stack<T>
    {
        private int _size;
        private int _maxSize;
        private T[] _arr;

        public int Size
        {
            get {return _size;}
        }

        public Stack()
        {
            Clear();
        }

        #region Public Methods
        public void Clear()
        {
            _size = 0;
            _maxSize = 8;
            _arr = new T[8];
        }

        public void Push(T item)
        {
            if (_size >= (_maxSize / 2))
            {
                resize(_maxSize * 2);
            }
            _arr[_size] = item;
            _size++;
        }

        public T Peek()
        {
            if (_size == 0)
            {
                throw new IndexOutOfRangeException("Stack is empty");
            }
            return _arr[_size - 1];
        }

        public T Pop()
        {
            if (_size == 0)
            {
                throw new IndexOutOfRangeException("Stack is empty");
            }
            else if (_size < (_maxSize / 4) && _size > 8)
            {
                resize(_maxSize / 2);
            }
            _size--;
            return _arr[_size];
        }
        #endregion

        #region Private Methods
        private void resize(int newMax)
        {
            T[] newArr = new T[newMax];
            for (int i = 0; i < _size; i++)
            {
                newArr[i] = _arr[i];
            }
            _maxSize = newMax;
            _arr = newArr;
        }
        #endregion
    }
}
