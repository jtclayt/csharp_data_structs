using System;
using System.Text;

namespace CSDataStructs.Code
{
    public class LinkedList<T>
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

            public Node(T val, Node next=null)
            {
                Value = val;
                Next = next;
            }
        }

        public LinkedList()
        {
            Clear();
        }

        public void Clear()
        {
            _size = 0;
            _head = null;
            _tail = null;
        }

        public T Get(int index)
        {
            if (index < 0 || index >= _size)
            {
                throw new IndexOutOfRangeException($"Index {index} out of bounds");
            }
            return iterate(index).Value;
        }

        public void InsertFront(T item)
        {
            _head = new Node(item, _head);
            _size++;
            if (_size == 1)
            {
                _tail = _head;
            }
        }

        public void InsertBack(T item)
        {
            if (_size == 0)
            {
                InsertFront(item);
            }
            else
            {
                _tail.Next = new Node(item);
                _tail = _tail.Next;
                _size++;
            }
        }

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
                Node nodeBefore = iterate(index-1);
                nodeBefore.Next = new Node(item, nodeBefore.Next);
                _size++;
            }
        }

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
            return temp;
        }

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
            Node newTail = iterate(_size - 2);
            _tail = newTail;
            _size--;
            return temp;
        }

        public T RemoveAt(int index)
        {
            if (index < 0 || index >= _size)
            {
                throw new IndexOutOfRangeException($"Index {index} out of bounds");
            }
            else if (index == 0)
            {
                return RemoveFront();
            }
            else if (index == _size - 1)
            {
                return RemoveBack();
            }
            Node prevNode = iterate(index - 1);
            T temp = prevNode.Next.Value;
            prevNode.Next = prevNode.Next.Next;
            _size--;
            return temp;
        }

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

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            Node curr = _head;

            while (curr != null)
            {
                sb.Append($"{curr.Value} -> ");
                curr = curr.Next;
            }

            return sb.ToString();
        }

        private Node iterate(int index)
        {
            Node curr = _head;
            while (index > 0)
            {
                curr = curr.Next;
                index--;
            }
            return curr;
        }
    }
}
