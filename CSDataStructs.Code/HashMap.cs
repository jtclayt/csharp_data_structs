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

        private int getDoublePrime(int currentPrime)
        {
            int nextPrime = 2 * currentPrime;
            while (isNotPrime(nextPrime))
            {
                nextPrime++;
            }
            return nextPrime;
        }

        private bool isNotPrime(int num)
        {
            for (int i = 2; i < Math.Floor(Math.Sqrt(num)); i++)
            {
                if (num / i == 0)
                {
                    return true;
                }
            }
            return false;
        }
    }
}
