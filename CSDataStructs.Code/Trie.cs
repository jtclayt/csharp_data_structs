using System;

namespace CSDataStructs.Code
{
    public class Trie
    {
        private Node _root;
        private int _size;

        public int Size
        {
            get { return _size; }
        }

        private class Node
        {
            public char Letter;
            public bool IsWord;
            public HashMap<char, Node> NextLetters;

            public Node(char letter, bool isWord=false)
            {
                Letter = letter;
                IsWord = isWord;
                NextLetters = new HashMap<char, Node>();
            }
        }

        public Trie()
        {
            Clear();
        }

        public void Clear()
        {
            _root = new Node('/');
            _size = 0;
        }

        public void AddWord(string word)
        {
            throw new NotImplementedException();
        }

        public void RemoveWord(string word)
        {
            throw new NotImplementedException();
        }

        public bool Contains(string word)
        {
            throw new NotImplementedException();
        }
    }
}
