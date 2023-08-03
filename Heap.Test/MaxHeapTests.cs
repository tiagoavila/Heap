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
        public void MaxHeapWorksByDoingInsertsAndPops()
        {
            int[] testHeap = new int[] { 100, 88, 87, 86, 50, 25, 16, 15, 12, 8, 3, 2 };
            MaxHeap maxHeap = new(testHeap.Length);
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

            for (int i = 0; i < testHeap.Length; i++)
            {
                int poppedValue = maxHeap.Pop();
                Assert.That(testHeap[i], Is.EqualTo(poppedValue));
            }
        }
    }
}