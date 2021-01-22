namespace CSDataStructs.Code
{
    using System;
    using System.Text;

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

        #region Public Methods
        /// <summary>
        /// Empty all items from list.
        /// </summary>
        public void Clear()
        {
            _size = 0;
            _start = 4;
            _maxSize = 8;
            _arr = new T[8];
        }

        /// <summary>
        /// Get item from given index.
        /// </summary>
        /// <param name="index">The index to get.</param>
        /// <returns>The item at the index.</returns>
        /// <exception cref="IndexOutOfRangeException">If index is out of range.</exception>
        public T Get(int index)
        {
            if (index < 0 || index >= _size)
            {
                throw new IndexOutOfRangeException($"Index {index} out of bounds");
            }
            return (T) _arr[_start + index];
        }

        /// <summary>
        /// Insert an item into the front of the list.
        /// </summary>
        /// <param name="item">The item to insert.</param>
        public void InsertFront(T item)
        {
            checkOverCapacity();
            _start--;
            _arr[_start] = item;
            _size++;
        }

        /// <summary>
        /// Insert an item to the back of the list.
        /// </summary>
        /// <param name="item">The item to insert.</param>
        public void InsertBack(T item)
        {
            checkOverCapacity();
            _arr[_start + _size] = item;
            _size++;
        }

        /// <summary>
        /// Insert an item at a given index.
        /// </summary>
        /// <param name="index">The index to insert item at.</param>
        /// <param name="item">The item to insert.</param>
        /// <exception cref="IndexOutOfRangeException">The index is not in the list.</exception>
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

        /// <summary>
        /// Remove first item from list.
        /// </summary>
        /// <returns>The first item being removed.</returns>
        /// <exception cref="IndexOutOfRangeException">If the list is empty.</exception>
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

        /// <summary>
        /// Remove the last item from the list.
        /// </summary>
        /// <returns>The last item being removed.</returns>
        /// <exception cref="IndexOutOfRangeException">If the list is empty.</exception>
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

        /// <summary>
        /// Remove an item at a given index.
        /// </summary>
        /// <param name="index">The index to remove at.</param>
        /// <returns>The item being removed.</returns>
        /// <exception cref="IndexOutOfRangeException">If the given index is out of range.</exception>
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

        /// <summary>
        /// Check if item is in list.
        /// </summary>
        /// <param name="item">The item being searched for.</param>
        /// <returns>If the item is in the list.</returns>
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

        /// <summary>
        /// Returns string representation of list.
        /// </summary>
        /// <returns>The list in a string format.</returns>
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
        #endregion

        #region Private Methods
        /// <summary>
        /// Checks if the list is over load factor.
        /// </summary>
        private void checkOverCapacity()
        {
            int overCap = _maxSize / 4;
            int leftCap = _start;
            int rightCap = _maxSize - _start - _size;
            if (leftCap <= overCap || rightCap <= overCap) {
                changeArray(true);
            }
        }

        /// <summary>
        /// Checks if list is under load factor.
        /// </summary>
        private void checkUnderCapacity()
        {
            if (_size > 8 && _size < _maxSize / 8)
            {
                changeArray(false);
            }
        }

        /// <summary>
        /// Extends/contracts underlying array to satisfy load factor.
        /// </summary>
        /// <param name="isExtend">Whether to extend or contract array.</param>
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
        #endregion
    }
}
