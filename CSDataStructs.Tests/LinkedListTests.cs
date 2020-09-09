using System;
using Xunit;
using CSDataStructs.Code;

namespace CSDataStructs.Tests
{
    class LinkedListTests
    {
        private readonly LinkedList<int> list;
        Random rng;

        public LinkedListTests()
        {
            list = new LinkedList<int>();
            rng = new Random();
        }

        [Fact]
        public void TestConstructor()
        {
            Assert.Equal(0, list.Size);
        }

        [Fact]
        public void TestToString()
        {
            Assert.Equal("", list.ToString());
        }

        [Fact]
        public void TestClear()
        {
            list.InsertBack(4);
            list.InsertBack(3);
            list.Clear();
            Assert.Equal(0, list.Size);
            Assert.Equal("", list.ToString());
        }

        [Fact]
        public void TestInsertFront()
        {
            list.InsertFront(1);
            Assert.Equal(1, list.Size);
            Assert.Equal("1 ->", list.ToString());
            list.InsertFront(2);
            Assert.Equal(2, list.Size);
            Assert.Equal("2 -> 1 ->", list.ToString());
        }

        [Fact]
        public void TestInsertFrontMany()
        {
            buildBigOrderedList("front");
            Assert.Equal(100, list.Size);
        }

        [Fact]
        public void TestInsertBack()
        {
            list.InsertBack(1);
            Assert.Equal(1, list.Size);
            Assert.Equal("1 ->", list.ToString());
            list.InsertBack(2);
            Assert.Equal(2, list.Size);
            Assert.Equal("1 -> 2 ->", list.ToString());
        }

        [Fact]
        public void TestInsertBackMany()
        {
            buildBigOrderedList("back");
            Assert.Equal(100, list.Size);
        }

        [Fact]
        public void TestGet()
        {
            list.InsertBack(1);
            Assert.Equal(1, list.Get(0));
            list.InsertFront(5);
            Assert.Equal(1, list.Get(1));
        }

        [Fact]
        public void TestGetOutOfRange()
        {
            Assert.Throws<IndexOutOfRangeException>(() => list.Get(0));
            list.InsertBack(1);
            list.InsertBack(2);
            Assert.Throws<IndexOutOfRangeException>(() => list.Get(-1));
            Assert.Throws<IndexOutOfRangeException>(() => list.Get(2));
        }

        [Fact]
        public void TestGetMany()
        {
            buildBigOrderedList("back");
            for (int i = 0; i < 10; i++)
            {
                int index = rng.Next(100);
                Assert.Equal(index, list.Get(index));
            }
        }

        [Fact]
        public void TestInsertAt()
        {
            list.InsertAt(0, 1);
            Assert.Equal(1, list.Get(0));
            Assert.Equal(1, list.Size);
            list.InsertAt(1, 3);
            Assert.Equal(3, list.Get(1));
            list.InsertAt(1, 2);
            Assert.Equal(2, list.Get(1));
            Assert.Equal(3, list.Size);
        }

        [Fact]
        public void TestInsertAtOutOfBounds()
        {
            Assert.Throws<IndexOutOfRangeException>(() => list.InsertAt(1, 1));
            Assert.Throws<IndexOutOfRangeException>(() => list.InsertAt(-4, 1));
        }

        [Fact]
        public void TestRemoveFrontFromEmpty()
        {
            Assert.Throws<IndexOutOfRangeException>(() => list.RemoveFront());
        }

        [Fact]
        public void TestRemoveFront()
        {
            list.InsertFront(1);
            Assert.Equal(1, list.RemoveFront());
            Assert.Equal(0, list.Size);
            list.InsertFront(2);
            list.InsertBack(3);
            Assert.Equal(2, list.RemoveFront());
            Assert.Equal(1, list.Size);
        }

        [Fact]
        public void TestRemoveFrontMany()
        {
            buildBigOrderedList("back");
            for (int i = 0; i < 100; i++)
            {
                Assert.Equal(i, list.RemoveFront());
            }
        }

        [Fact]
        public void TestRemoveBackFromEmpty()
        {
            Assert.Throws<IndexOutOfRangeException>(() => list.RemoveBack());
        }

        [Fact]
        public void TestRemoveBack()
        {
            list.InsertFront(1);
            Assert.Equal(1, list.RemoveBack());
            Assert.Equal(0, list.Size);
            list.InsertBack(2);
            list.InsertBack(3);
            Assert.Equal(3, list.RemoveBack());
            Assert.Equal(1, list.Size);
        }

        [Fact]
        public void TestRemoveAtOutOfBounds()
        {
            list.InsertFront(1);
            Assert.Throws<IndexOutOfRangeException>(() => list.RemoveAt(-2));
            Assert.Throws<IndexOutOfRangeException>(() => list.RemoveAt(1));
        }

        [Fact]
        public void TestRemoveAt()
        {
            list.InsertFront(1);
            Assert.Equal(1, list.RemoveAt(0));
            Assert.Equal(0, list.Size);
            list.InsertBack(2);
            list.InsertBack(3);
            Assert.Equal(3, list.RemoveAt(1));
            list.InsertBack(4);
            list.InsertBack(5);
            Assert.Equal(4, list.RemoveAt(1));
            Assert.Equal(2, list.Size);
        }

        [Fact]
        public void TestContains()
        {
            Assert.False(list.Contains(4));
            list.InsertBack(1);
            Assert.True(list.Contains(1));
            list.InsertBack(2);
            list.InsertBack(3);
            list.InsertBack(4);
            list.InsertBack(5);
            Assert.True(list.Contains(4));
        }

        [Fact]
        public void TestStringContains()
        {
            var strList = new ArrayList<string>();
            Assert.False(strList.Contains("test"));
            strList.InsertBack("word");
            strList.InsertBack("test");
            Assert.True(strList.Contains("test"));
        }

        private void buildBigOrderedList(string side)
        {
            for (int i = 0; i < 100; i++)
            {
                if (side == "front")
                {
                    list.InsertFront(i);
                }
                else
                {
                    list.InsertBack(i);
                }
            }
        }
    }
}
