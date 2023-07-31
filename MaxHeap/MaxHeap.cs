using Heap.ADTSpecifications;

namespace Heap
{
    public class MaxHeap : IHeap
    {
        private int[] _data;
        private int _lastItemIndex;

        public MaxHeap(int capacity)
        {
            _data = new int[capacity];    
            _lastItemIndex = 0;
        }

        /// <summary>
        /// To insert a new value into the Max Heap we perform the following algorithm:
        /// <list type="number">
        ///     <item><description>Insert the value at the last available position in the Array</description></item>
        ///     <item><description>Compare this new value index with its parent index</description></item>
        ///     <item><description>If the new value is greater than its parent, we swap the value of the current index with its parent index</description></item>
        ///     <item><description>We repeat step 3, effectively moving the new value up through the heap, until it has a parent whose value is greater than it</description></item>
        /// </list>
        /// </summary>
        /// <param name="value"></param>
        public void Insert(int value)
        {
            _data[_lastItemIndex] = value;
            int currentItemIndex = _lastItemIndex;
            _lastItemIndex++;

            while (currentItemIndex > 0 && _data[currentItemIndex] > _data[GetParentIndex(currentItemIndex)])
            {
                //Swap
                (_data[GetParentIndex(currentItemIndex)], _data[currentItemIndex]) = (_data[currentItemIndex], _data[GetParentIndex(currentItemIndex)]);

                //Set new Item to be the Parent
                currentItemIndex = GetParentIndex(currentItemIndex);
            }
        }

        public int[] GetHeap()
        {
            return _data;
        }

        private int GetParentIndex(int index) => (index - 1) / 2;
        private int GetLeftChildIndex(int index) => (index * 2) + 1;
        private int GetRightChildIndex(int index) => (index * 2) + 2;
    }
}
