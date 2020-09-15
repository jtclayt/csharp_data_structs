using System;
using Xunit;
using CSDataStructs.Code;

namespace CSDataStructs.Tests
{
    public class HashMapTests
    {
        public readonly HashMap<string, string> map;

        public HashMapTests()
        {
            map = new HashMap<string, string>();
        }

        [Fact]
        public void TestConstructor()
        {
            Assert.Equal(0, map.Size);
        }

        [Fact]
        public void TestClear()
        {
            map.Insert("k1", "v1");
            map.Insert("k2", "v2");
            map.Insert("k3", "v3");
            Assert.Equal(3, map.Size);
            map.Clear();
            Assert.Equal(0, map.Size);
            Assert.Empty(map.Keys());
            Assert.Empty(map.Values());
            Assert.Empty(map.Items());
        }

        [Fact]
        public void TestHasKey()
        {
            Assert.False(map.HasKey("k1"));
            map.Insert("k1", "v1");
            Assert.True(map.HasKey("k1"));
        }

        [Fact]
        public void TestRemove()
        {
            map.Insert("k1", "v1");
            Assert.Equal(1, map.Size);
            Assert.True(map.HasKey("k1"));
            map.Remove("k1");
            Assert.Equal(0, map.Size);
            Assert.False(map.HasKey("k1"));
        }

        [Fact]
        public void TestInsertAndGet()
        {
            map.Insert("k1", "v1");
            Assert.Equal(1, map.Size);
            Assert.True(map.HasKey("k1"));
            map.Insert("k1", "v2");
            Assert.Equal("v2", map.Get("k1"));
            Assert.Equal(1, map.Size);
        }

        [Fact]
        public void TestKeys()
        {
            var keys = map.Keys();
            Assert.Equal(map.Size, keys.Length);
            foreach (string key in keys)
            {
                Assert.True(map.HasKey(key));
            }
        }

        [Fact]
        public void TestValues()
        {
            var values = map.Values();
            Assert.Equal(map.Size, values.Length);
            foreach (string key in map.Keys())
            {
                Assert.Contains(map.Get(key), values);
            }
        }

        [Fact]
        public void TestItems()
        {
            var items = map.Items();
            Assert.Equal(map.Size, items.Length);
            foreach ((string key, string val) in items)
            {
                Assert.Equal(val, map.Get(val));
            }
        }
    }
}