using System;
using Xunit;
using CSDataStructs.Code;

namespace CSDataStructs.Tests
{
    public class IntBinarySearchTreeTests
    {
        private readonly IntBinarySearchTree bst;
        private Random rng;

        public IntBinarySearchTreeTests()
        {
            bst = new IntBinarySearchTree();
            rng = new Random();
        }

        [Fact]
        public void TestConstructor()
        {
            Assert.Equal(0, bst.Size);
        }

        [Fact]
        public void TestClear()
        {
            bst.Insert(5);
            bst.Insert(9);
            bst.Insert(2);
            bst.Insert(1);
            Assert.Equal(4, bst.Size);
            bst.Clear();
            Assert.Equal(0, bst.Size);
            Assert.False(bst.Contains(5));
        }

        [Fact]
        public void TestToString()
        {
            Assert.Equal("", bst.ToString());
            bst.Insert(5);
            bst.Insert(9);
            bst.Insert(2);
            bst.Insert(1);
            Assert.Equal("1 2 5 9 ", bst.ToString());
        }

        [Fact]
        public void TestInsert()
        {
            bst.Insert(5);
            bst.Insert(9);
            bst.Insert(2);
            bst.Insert(1);
            Assert.Equal(4, bst.Size);
            Assert.True(bst.Contains(5));
            Assert.True(bst.Contains(9));
            Assert.True(bst.Contains(2));
            Assert.True(bst.Contains(1));
        }

        [Fact]
        public void TestInsertDuplicate()
        {
            bst.Insert(5);
            bst.Insert(5);
            Assert.Equal(1, bst.Size);
            Assert.True(bst.Contains(5));
        }

        [Fact]
        public void TestRemove()
        {
            bst.Insert(5);
            Assert.Equal(1, bst.Size);
            Assert.True(bst.Contains(5));
            bst.Remove(5);
            Assert.Equal(0, bst.Size);
            Assert.False(bst.Contains(5));
        }

        [Fact]
        public void TestMany()
        {
            bst.Insert(5);
            bst.Insert(9);
            bst.Insert(2);
            bst.Insert(1);
            Assert.Equal(4, bst.Size);
            Assert.True(bst.Contains(1));
            bst.Remove(5);
            bst.Insert(3);
            bst.Insert(4);
            Assert.True(bst.Contains(2));
            bst.Insert(7);
            bst.Insert(10);
            Assert.Equal(7, bst.Size);
            bst.Remove(2);
            bst.Remove(9);
            Assert.Equal(5, bst.Size);
            Assert.True(bst.Contains(1));
            Assert.True(bst.Contains(3));
            Assert.True(bst.Contains(4));
            Assert.True(bst.Contains(7));
            Assert.True(bst.Contains(10));
        }
    }
}
