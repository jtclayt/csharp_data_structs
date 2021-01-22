namespace CSDataStructs.Code
{
    using System;
    using System.Collections.Generic;

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

        #region Public Methods
        /// <summary>
        /// Empty the map.
        /// </summary>
        public void Clear()
        {
            _arr = new Node[8];
            _size = 0;
        }

        /// <summary>
        /// Check if a key is in the map.
        /// </summary>
        /// <param name="key">Key to find.</param>
        /// <returns>If the key is in the map.</returns>
        public bool HasKey(K key)
        {
            return getNode(key) != null;
        }

        /// <summary>
        /// Retrieves all the keys in the map.
        /// </summary>
        /// <returns>Array of keys.</returns>
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

        /// <summary>
        /// Retrieves all values in the map.
        /// </summary>
        /// <returns>Array of values.</returns>
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

        /// <summary>
        /// Retrieves tuples of key/value pairs.
        /// </summary>
        /// <returns>Array of tuples, key/value pairs.</returns>
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

        /// <summary>
        /// Insert a new key with given value.
        /// </summary>
        /// <param name="key">The associated key.</param>
        /// <param name="value">The value for the key.</param>
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

        /// <summary>
        /// Remove a key from the map.
        /// </summary>
        /// <param name="key">The key to remove.</param>
        /// <exception cref="ArgumentException">If key is not in map.</exception>
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

        /// <summary>
        /// Get the value for the key.
        /// </summary>
        /// <param name="key">The key to find value for.</param>
        /// <returns>The value of associated key.</returns>
        /// <exception cref="ArgumentException">If key is not in map.</exception>
        public V Get(K key)
        {
            Node node = getNode(key);

            if (node == null)
            {
                throw new ArgumentException("Key is not in the map");
            }
            return node.Value;
        }
        #endregion

        #region Private Methods
        /// <summary>
        /// Find the index of the key.
        /// </summary>
        /// <param name="key">The key to get index of.</param>
        /// <returns>The index for the key.</returns>
        private int getIndex(K key)
        {
            return Math.Abs(key.GetHashCode()) % _arr.Length;
        }

        /// <summary>
        /// Get the node for a given key.
        /// </summary>
        /// <param name="key">The key to get.</param>
        /// <returns>The node for the given key.</returns>
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

        /// <summary>
        /// Insert a new node storing key/value pairs.
        /// </summary>
        /// <param name="key">The key.</param>
        /// <param name="value">The value to store.</param>
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

        /// <summary>
        /// Check if map is within load factor.
        /// </summary>
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

        /// <summary>
        /// Resize the map (extend/contract).
        /// </summary>
        /// <param name="newMax">The new max size.</param>
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

        /// <summary>
        /// Get list of all nodes in the map.
        /// </summary>
        /// <returns>Array of all nodes.</returns>
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
        #endregion
    }
}
