using System;
using System.Collections.Generic;
using Xunit;
using CSDataStructs.Code;

namespace CSDataStructs.Tests
{
    public class MinIntHeapTests
    {
        private readonly MinIntHeap heap;
        private Random rng;

        public MinIntHeapTests()
        {
            heap = new MinIntHeap();
            rng = new Random();
        }

        [Fact]
        public void TestConstructor()
        {
            Assert.Equal(0, heap.Size);
        }

        [Fact]
        public void TestClear()
        {
            heap.Insert(2);
            heap.Insert(5);
            heap.Insert(7);
            heap.Insert(1);
            heap.Insert(0);
            Assert.Equal(5, heap.Size);
            heap.Clear();
            Assert.Equal(0, heap.Size);
        }

        [Fact]
        public void TestInsertAndPeekMin()
        {
            heap.Insert(2);
            Assert.Equal(2, heap.PeekMin());
            heap.Insert(5);
            Assert.Equal(2, heap.PeekMin());
            heap.Insert(7);
            Assert.Equal(2, heap.PeekMin());
            heap.Insert(1);
            Assert.Equal(1, heap.PeekMin());
            heap.Insert(0);
            Assert.Equal(0, heap.PeekMin());
            Assert.Equal(5, heap.Size);
        }

        [Fact]
        public void TestPeekMinEmpty()
        {
            Assert.Throws<IndexOutOfRangeException>(() => heap.GetMin());
        }

        [Fact]
        public void GetMin()
        {
            heap.Insert(5);
            heap.Insert(8);
            heap.Insert(3);
            heap.Insert(4);
            heap.Insert(1);
            Assert.Equal(1, heap.GetMin());
            Assert.Equal(3, heap.GetMin());
            Assert.Equal(4, heap.GetMin());
            Assert.Equal(5, heap.GetMin());
            Assert.Equal(8, heap.GetMin());
            Assert.Equal(0, heap.Size);
        }

        [Fact]
        public void TestGetMinEmpty()
        {
            Assert.Throws<IndexOutOfRangeException>(() => heap.GetMin());
        }

        [Fact]
        public void RandomLargeTest()
        {
            List<int> test = new List<int>();
            for (int i = 0; i < 100; i++)
            {
                int randInt = rng.Next(10000);
                test.Add(randInt);
                heap.Insert(randInt);
            }
            test.Sort();
            for (int i = 0; i < 100; i++)
            {
                Assert.Equal(test[i], heap.GetMin());
            }
        }
    }
}
