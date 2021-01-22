namespace CSDataStructs.Code
{
    using System;
    using System.Text;

    public class DoubleLinkedList<T>
    {
        int _size;
        Node _head;
        Node _tail;

        public int Size
        {
            get { return _size; }
        }

        private class Node
        {
            public T Value;
            public Node Next;
            public Node Prev;

            public Node(T val, Node next=null, Node prev=null)
            {
                Value = val;
                Next = next;
                Prev = prev;
            }
        }

        public DoubleLinkedList()
        {
            Clear();
        }

        #region Public Methods
        /// <summary>
        /// Empty all items from arrays.
        /// </summary>
        public void Clear()
        {
            _size = 0;
            _head = null;
            _tail = null;
        }

        /// <summary>
        /// Get the item at a given index.
        /// </summary>
        /// <param name="index">The index to get.</param>
        /// <returns>The item at the index.</returns>
        /// <exception cref="IndexOutOfRangeException">If the index is out of binds.</exception>
        public T Get(int index)
        {
            if (index < 0 || index >= _size)
            {
                throw new IndexOutOfRangeException($"Index {index} out of bounds");
            }

            return getNode(index).Value;
        }

        /// <summary>
        /// Insert an item to the front of the list.
        /// </summary>
        /// <param name="item">The item to insert.</param>
        public void InsertFront(T item)
        {
            _head = new Node(item, _head);
            _size++;
            if (_size == 1)
            {
                _tail = _head;
            }
            else
            {
                _head.Next.Prev = _head;
            }
        }

        /// <summary>
        /// Insert an item to the back of list.
        /// </summary>
        /// <param name="item">The item to insert.</param>
        public void InsertBack(T item)
        {
            if (_size == 0)
            {
                InsertFront(item);
            }
            else
            {
                _tail.Next = new Node(item, null, _tail);
                _tail = _tail.Next;
                _size++;
            }
        }

        /// <summary>
        /// Insert an item at a given index.
        /// </summary>
        /// <param name="index">The index to insert at.</param>
        /// <param name="item">The item to insert.</param>
        /// <exception cref="IndexOutOfRangeException">If the index is out of binds.</exception>
        public void InsertAt(int index, T item)
        {
            if (index < 0 || index > _size)
            {
                throw new IndexOutOfRangeException($"Index {index} out of bounds");
            }
            else if (index == 0)
            {
                InsertFront(item);
            }
            else if (index == _size)
            {
                InsertBack(item);
            }
            else
            {
                Node prevNode = getNode(index - 1);
                prevNode.Next = new Node(item, prevNode.Next, prevNode);
                prevNode.Next.Next.Prev = prevNode.Next;
                _size++;
            }
        }

        /// <summary>
        /// Remove the first item of the list.
        /// </summary>
        /// <returns>The item removed.</returns>
        /// <exception cref="IndexOutOfRangeException">If the index is out of binds.</exception>
        public T RemoveFront()
        {
            if (_size == 0)
            {
                throw new IndexOutOfRangeException("List is empty");
            }

            T temp = _head.Value;
            _head = _head.Next;
            _size--;

            if (_size == 0)
            {
                _tail = null;
            }
            else
            {
                _head.Prev = null;
            }

            return temp;
        }

        /// <summary>
        /// Remove the last item from list.
        /// </summary>
        /// <returns>The item removed.</returns>
        /// <exception cref="IndexOutOfRangeException">If the index is out of binds.</exception>
        public T RemoveBack()
        {
            if (_size == 0)
            {
                throw new IndexOutOfRangeException("List is empty");
            }
            else if (_size == 1)
            {
                return RemoveFront();
            }

            T temp = _tail.Value;
            _tail = _tail.Prev;
            _tail.Next = null;
            _size--;

            return temp;
        }

        /// <summary>
        /// Remove an item from a given index.
        /// </summary>
        /// <param name="index">Index to remove at.</param>
        /// <returns>The item being removed.</returns>
        /// <exception cref="IndexOutOfRangeException">If the index is out of binds.</exception>
        public T RemoveAt(int index)
        {
            if (index < 0 || index >= _size)
            {
                throw new IndexOutOfRangeException($"Index {index} is out of bounds");
            }
            else if (index == 0)
            {
                return RemoveFront();
            }
            else if (index == _size - 1)
            {
                return RemoveBack();
            }
            Node node = getNode(index);
            node.Next.Prev = node.Prev;
            node.Prev.Next = node.Next;
            _size--;
            return node.Value;
        }

        /// <summary>
        /// Looks for the item in the list.
        /// </summary>
        /// <param name="item">The item to find.</param>
        /// <returns>If the item is in the list.</returns>
        public bool Contains(T item)
        {
            Node curr = _head;
            while (curr != null)
            {
                if (curr.Value.Equals(item))
                {
                    return true;
                }
                curr = curr.Next;
            }
            return false;
        }

        /// <summary>
        /// Gets the string representation of list.
        /// </summary>
        /// <returns>List represented as a string.</returns>
        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            Node curr = _head;

            if (_size > 0)
            {
                sb.Append("<- ");
            }

            while (curr != null)
            {
                sb.Append(curr.Value);
                if (curr.Next != null)
                {
                    sb.Append(" <-> ");
                }
                else
                {
                    sb.Append(" ->");
                }
                curr = curr.Next;
            }

            return sb.ToString();
        }
        #endregion

        #region Private Methods
        /// <summary>
        /// Get the node from the given index, traversing from
        /// front or back depending on which is more efficient.
        /// </summary>
        /// <param name="index">Index to get.</param>
        /// <returns>The node at the index.</returns>
        private Node getNode(int index)
        {
            int mid = (_size - 1) / 2;
            Node curr;

            if (index < mid)
            {
                curr = _head;
                while (index > 0)
                {
                    curr = curr.Next;
                    index--;
                }
            }
            else
            {
                curr = _tail;
                while (index < _size - 1)
                {
                    curr = curr.Prev;
                    index++;
                }
            }
            return curr;
        }
        #endregion
    }
}