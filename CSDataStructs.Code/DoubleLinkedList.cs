using System;
using System.Text;

namespace CSDataStructs.Code
{
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

        public void Clear()
        {
            _size = 0;
            _head = null;
            _tail = null;
        }

        public T Get(int index)
        {
            throw new NotImplementedException();
        }

        public void InsertFront(T item)
        {
            throw new NotImplementedException();
        }

        public void InsertBack(T item)
        {
            throw new NotImplementedException();
        }

        public void InsertAt(int index, T item)
        {
            throw new NotImplementedException();
        }

        public T RemoveFront()
        {
            throw new NotImplementedException();
        }

        public T RemoveBack()
        {
            throw new NotImplementedException();
        }

        public T RemoveAt(int index)
        {
            throw new NotImplementedException();
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

            sb.Append("<- ");
            while (curr != null)
            {
                sb.Append($"{curr.Value} <-> ");
                curr = curr.Next;
            }
            sb.Append(" ->");

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