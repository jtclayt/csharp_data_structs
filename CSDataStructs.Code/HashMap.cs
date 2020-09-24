using System;
using System.Collections.Generic;

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
                Next = null;
            }
        }

        public HashMap()
        {
            Clear();
        }

        public void Clear()
        {
            _arr = new Node[8];
            _size = 0;
        }

        public bool HasKey(K key)
        {
            return getNode(key) != null;
        }

        public K[] Keys()
        {
            K[] keys = new K[_size];
            Node[] allNodes = nodes();

            for (int i = 0; i < _size; i++)
            {
                keys[i] = allNodes[i].Key;
            }

            return keys;
        }

        public V[] Values()
        {
            V[] values = new V[_size];
            Node[] allNodes = nodes();

            for (int i = 0; i < _size; i++)
            {
                values[i] = allNodes[i].Value;
            }

            return values;
        }

        public (K, V)[] Items()
        {
            (K, V)[] items = new (K, V)[_size];
            Node[] allNodes = nodes();

            for (int i = 0; i < _size; i++)
            {
                items[i] = (allNodes[i].Key, allNodes[i].Value);
            }

            return items;
        }

        public void Insert(K key, V value)
        {
            checkCapacity();

            if (HasKey(key))
            {
                getNode(key).Value = value;
            }
            else
            {
                insertNewNode(key, value);
            }
        }

        private void insertNewNode(K key, V value)
        {
            Node newNode = new Node(key, value);
            int index = getIndex(key);
            if (_arr[index] == null)
            {
                _arr[index] = newNode;
            }
            else
            {
                Node curr = _arr[index];
                while (curr.Next != null)
                {
                    curr = curr.Next;
                }
                curr.Next = newNode;
            }
            _size++;
        }

        public void Remove(K key)
        {
            int index = getIndex(key);
            bool notFound = true;

            if (_arr[index] != null)
            {
                Node curr = _arr[index];

                if (curr != null && curr.Key.Equals(key))
                {
                    notFound = false;
                    _arr[index] = curr.Next;
                    _size--;
                }
                else
                {
                    while (curr.Next != null && !curr.Next.Key.Equals(key))
                    {
                        curr = curr.Next;
                    }
                    if (curr.Next != null)
                    {
                        notFound = false;
                        curr.Next = curr.Next.Next;
                        _size--;
                    }
                }
            }

            if (notFound)
            {
                throw new ArgumentException("Key is not in the map");
            }
        }

        public V Get(K key)
        {
            Node node = getNode(key);

            if (node == null)
            {
                throw new ArgumentException("Key is not in the map");
            }
            return node.Value;
        }

        private int getIndex(K key)
        {
            return Math.Abs(key.GetHashCode()) % _arr.Length;
        }

        private Node getNode(K key)
        {
            int index = getIndex(key);
            Node curr = _arr[index];

            while (curr != null)
            {
                if (curr.Key.Equals(key))
                {
                    return curr;
                }
                curr = curr.Next;
            }

            return null;
        }

        private void checkCapacity()
        {
            int upperCapacity = 3 / 4 * _arr.Length;
            int lowerCapacity = _arr.Length / 4;
            if (_size >= upperCapacity)
            {
                resize(_arr.Length * 2);
            }
            else if (_size < lowerCapacity && _size > 8)
            {
                resize(_arr.Length / 2);
            }
        }

        private void resize(int newMax)
        {
            Node[] newArr = new Node[newMax];

            foreach (Node node in nodes())
            {
                node.Next = null;
                int index = getIndex(node.Key);

                if (newArr[index] == null)
                {
                    newArr[index] = node;
                }
                else
                {
                    Node curr = newArr[index];
                    while (curr.Next != null)
                    {
                        curr = curr.Next;
                    }
                    curr.Next = node;
                }
            }
        }

        private Node[] nodes()
        {
            List<Node> output = new List<Node>();

            for (int i = 0; i < _arr.Length; i++)
            {
                if (_arr[i] != null)
                {
                    Node curr = _arr[i];
                    output.Add(_arr[i]);
                    while (curr.Next != null)
                    {
                        curr = curr.Next;
                        output.Add(curr);
                    }
                }
            }

            return output.ToArray();
        }
    }
}
