using System;
using Xunit;
using CSDataStructs.Code;

namespace CSDataStructs.Tests
{
    public class StackTests
    {
        private readonly Stack<int> stack;

        public StackTests()
        {
            stack = new Stack<int>();
        }

        [Fact]
        public void TestConstructor()
        {
            Assert.Equal(0, stack.Size);
        }

        [Fact]
        public void TestClear()
        {
            stack.Push(1);
            stack.Push(1);
            stack.Push(1);
            stack.Push(1);
            Assert.Equal(4, stack.Size);
            stack.Clear();
            Assert.Equal(0, stack.Size);
        }

        [Fact]
        public void TestPushAndPeek()
        {
            stack.Push(1);
            Assert.Equal(1, stack.Size);
            Assert.Equal(1, stack.Peek());
            stack.Push(2);
            Assert.Equal(2, stack.Size);
            Assert.Equal(2, stack.Peek());
        }

        [Fact]
        public void TestPop()
        {
            stack.Push(1);
            Assert.Equal(1, stack.Pop());
            Assert.Equal(0, stack.Size);
            stack.Push(1);
            stack.Push(2);
            stack.Push(3);
            Assert.Equal(3, stack.Pop());
            Assert.Equal(2, stack.Size);
        }

        [Fact]
        public void TestPushPopMany()
        {
            for (int i = 0; i < 100; i++)
            {
                stack.Push(i);
            }
            Assert.Equal(100, stack.Size);
            Assert.Equal(99, stack.Peek());
            for (int i = 99; i >= 0; i--)
            {
                Assert.Equal(i, stack.Pop());
            }
            Assert.Equal(0, stack.Size);
        }

        [Fact]
        public void TestPopEmpty()
        {
            Assert.Throws<IndexOutOfRangeException>(() => stack.Pop());
        }

        [Fact]
        public void TestPeekEmpty()
        {
            Assert.Throws<IndexOutOfRangeException>(() => stack.Peek());
        }
    }
}
