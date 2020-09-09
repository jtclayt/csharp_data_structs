using System;
using System.Text;

namespace CSDataStructs.Code
{
    public class LinkedList<T>
    {
        int _size;
        Node _head;

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
            throw new NotImplementedException();
        }

        public override string ToString()
        {
            throw new NotImplementedException();
        }
    }
}
