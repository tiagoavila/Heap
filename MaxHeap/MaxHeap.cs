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
            _lastItemIndex = -1;
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
            _lastItemIndex++;
            _data[_lastItemIndex] = value;
            int currentItemIndex = _lastItemIndex;
            int parentIndex = GetParentIndex(currentItemIndex);

            while (currentItemIndex > 0 && _data[currentItemIndex] > _data[parentIndex])
            {
                //Swap
                (_data[currentItemIndex], _data[parentIndex]) = (_data[parentIndex], _data[currentItemIndex]);

                //Set new Item to be the Parent
                currentItemIndex = parentIndex;
                parentIndex = GetParentIndex(currentItemIndex);
            }
        }

        public int Pop()
        {
            (int returnValue, _data[0], _data[_lastItemIndex]) = (_data[0], _data[_lastItemIndex], 0);
            _lastItemIndex--;

            int currentItemIndex = 0;

            while (HasChildWithAGreaterValue(currentItemIndex))
            {
                int indexChildWithGreaterValue = GetIndexOfChildWithGreaterValue(currentItemIndex);
                (_data[currentItemIndex], _data[indexChildWithGreaterValue]) = (_data[indexChildWithGreaterValue], _data[currentItemIndex]);
                currentItemIndex = indexChildWithGreaterValue;
            }

            return returnValue;
        }

        private int GetParentIndex(int index) => (index - 1) / 2;

        private int GetLeftChildIndex(int index) => (index * 2) + 1;

        private int GetRightChildIndex(int index) => (index * 2) + 2;

        private bool HasChildWithAGreaterValue(int index)
        {
            int leftChildIndex = GetLeftChildIndex(index);
            int rightChildIndex = GetRightChildIndex(index);
            return _data[index] < _data[leftChildIndex] || (rightChildIndex < _data.Length && _data[index] < _data[rightChildIndex]);
        }

        private int GetIndexOfChildWithGreaterValue(int index)
        {
            int leftChildIndex = GetLeftChildIndex(index);
            int rightChildIndex = GetRightChildIndex(index);

            if (rightChildIndex > _data.Length || _data[rightChildIndex] == 0)
                return leftChildIndex;
            
            int leftChildValue = _data[leftChildIndex];
            int rightChildValue = _data[rightChildIndex];

            return rightChildValue > leftChildValue ? rightChildIndex : leftChildIndex;
        }
    }
}
