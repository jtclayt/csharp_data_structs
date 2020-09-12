using System;
using Xunit;
using CSDataStructs.Code;

namespace CSDataStructs.Tests
{
  public class QueueTests
  {
    private readonly Queue<int> queue;
    Random rng;

    public QueueTests()
    {
      queue = new Queue<int>();
      rng = new Random();
    }

    [Fact]
    public void TestConstructor()
    {
      Assert.Equal(0, queue.Size);
    }

    [Fact]
    public void TestSize()
    {
      queue.Enqueue(1);
      queue.Enqueue(1);
      queue.Enqueue(1);
      queue.Enqueue(1);
      Assert.Equal(4, queue.Size);
    }

    [Fact]
    public void TestClear()
    {
      queue.Enqueue(1);
      queue.Enqueue(1);
      queue.Enqueue(1);
      queue.Enqueue(1);
      queue.Clear();
      Assert.Equal(0, queue.Size);
    }

    [Fact]
    public void TestEnqueue()
    {
      queue.Enqueue(1);
      Assert.Equal(1, queue.Peek());
      queue.Enqueue(2);
      queue.Enqueue(3);
      queue.Enqueue(4);
      Assert.Equal(1, queue.Peek());
      Assert.Equal(4, queue.Size);
    }

    [Fact]
    public void TestDequeue()
    {
      queue.Enqueue(1);
      Assert.Equal(1, queue.Dequeue());
      queue.Enqueue(1);
      queue.Enqueue(2);
      queue.Enqueue(3);
      queue.Enqueue(4);
      Assert.Equal(1, queue.Dequeue());
      Assert.Equal(2, queue.Dequeue());
      Assert.Equal(3, queue.Dequeue());
      Assert.Equal(4, queue.Dequeue());
      Assert.Equal(0, queue.Size);
    }

    [Fact]
    public void TestDequeueEmpty()
    {
      Assert.Throws<IndexOutOfRangeException>(() => queue.Dequeue());
    }

    [Fact]
    public void TestPeek()
    {
      queue.Enqueue(1);
      queue.Enqueue(2);
      queue.Enqueue(3);
      queue.Enqueue(4);
      Assert.Equal(1, queue.Peek());
      queue.Dequeue();
      Assert.Equal(2, queue.Peek());
      queue.Dequeue();
      Assert.Equal(3, queue.Peek());
      queue.Dequeue();
      Assert.Equal(4, queue.Peek());
    }

    [Fact]
    public void TestPeekEmpty()
    {
      Assert.Throws<IndexOutOfRangeException>(() => queue.Peek());
    }
  }
}
