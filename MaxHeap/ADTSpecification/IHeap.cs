namespace Heap.ADTSpecifications
{
    public interface IHeap
    {
        void Heapify(int[] array);
        public void Insert(int value);
        int Pop();
    }
}
