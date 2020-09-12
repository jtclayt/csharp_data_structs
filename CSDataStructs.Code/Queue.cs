using System;
using System.Text;

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
      throw new NotImplementedException();
    }

    public T Dequeue()
    {
      throw new NotImplementedException();
    }

    public T Peek()
    {
      throw new NotImplementedException();
    }
  }
}
