using System;

namespace CSDataStructs.Code
{
    public class HashMap<K, V>
    {
        private Node[] _arr;
        private int _size;

        public int Size
        {
            get { return _size; }
        }

        private class Node
        {
            public K Key;
            public V Value;
            public Node Next;

            public Node(K key, V value)
            {
                Key = key;
                Value = value;
            }
        }

        public HashMap()
        {
            Clear();
        }

        public void Clear()
        {
            _arr = new Node[11];
            _size = 0;
        }

        public bool HasKey(K key)
        {
            throw new NotImplementedException();
        }

        public K[] Keys()
        {
            throw new NotImplementedException();
        }

        public V[] Values()
        {
            throw new NotImplementedException();
        }

        public (K, V)[] Items()
        {
            throw new NotImplementedException();
        }

        public void Insert(K key, V value)
        {
            throw new NotImplementedException();
        }

        public void Remove(K key)
        {
            throw new NotImplementedException();
        }

        public V Get(K key)
        {
            throw new NotImplementedException();
        }
    }
}
