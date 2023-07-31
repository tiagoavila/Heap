using NUnit.Framework.Constraints;

namespace Heap.Test
{
    public class Tests
    {
        [SetUp]
        public void Setup()
        {

        }

        [Test]
        public void Test1()
        {
            int[] _testHeap = new int[] { 100, 88, 25, 87, 16, 8, 12, 86, 50, 2, 15, 3 };
            MaxHeap maxHeap = new(_testHeap.Length);
            maxHeap.Insert(8);
            maxHeap.Insert(3);
            maxHeap.Insert(2);
            maxHeap.Insert(12);
            maxHeap.Insert(15);
            maxHeap.Insert(25);
            maxHeap.Insert(16);
            maxHeap.Insert(50);
            maxHeap.Insert(100);
            maxHeap.Insert(86);
            maxHeap.Insert(87);
            maxHeap.Insert(88);

            Assert.Equals(_testHeap, maxHeap.GetHeap());
        }
    }
}