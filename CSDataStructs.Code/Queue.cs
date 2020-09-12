using System;

namespace CSDataStructs.Code
{
    public class Queue<T>
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

            public Node(T val)
            {
                Value = val;
                Next = null;
            }
        }

        public Queue()
        {
            Clear();
        }

        public void Clear()
        {
            _size = 0;
            _head = null;
            _tail = null;
        }

        public void Enqueue(T item)
        {
            if (_size == 0)
            {
                _head = new Node(item);
                _tail = _head;
            }
            else
            {
                _tail.Next = new Node(item);
                _tail = _tail.Next;
            }
            _size++;
        }

        public T Dequeue()
        {
            if (_size == 0)
            {
                throw new IndexOutOfRangeException("Queue is empty");
            }

            T temp = _head.Value;
            _head = _head.Next;
            _size--;

            if (_size == 0)
            {
                _tail = null;
            }

            return temp;
        }

        public T Peek()
        {
            if (_size == 0)
            {
                throw new IndexOutOfRangeException("Queue is empty");
            }

            return _head.Value;
        }
    }
}
