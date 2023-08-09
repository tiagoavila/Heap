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

        /// <summary>
        /// To Pop a value from the Max Heap we perform the following algorithm:
        /// <list type="number">
        ///     <item><description>Remove the greatest value, the one at index 0</description></item>
        ///     <item><description>Move the value of the last available position in the Array to the position 0</description></item>
        ///     <item><description>Then check if that Item has any children with greater value, if it has move the greatest child to its position</description></item>
        ///     <item><description>Repeat the step above until reaches an Item that doesn't have children with a greater value or the end of the array</description></item>
        /// </list>
        /// </summary>
        /// <returns></returns>
        public int Pop()
        {
            (int returnValue, _data[0], _data[_lastItemIndex]) = (_data[0], _data[_lastItemIndex], 0);
            _lastItemIndex--;

            int currentItemIndex = 0;

            while (HasChildWithAGreaterValue(currentItemIndex))
            {
                int indexChildWithGreaterValue = GetIndexOfChildWithGreaterValue(currentItemIndex);
                Swap(_data, currentItemIndex, indexChildWithGreaterValue);
                currentItemIndex = indexChildWithGreaterValue;
            }

            return returnValue;
        }

        /// <summary>
        /// Apply the Heap property to an unsorted array, in summary the algorithm checks every Node that has children (the parents),
        /// checking if the children has greater value, swap if it has a greater value and then check the sub-trees.
        /// Do that until checking all parents.
        /// 
        /// A detailed explanation is the following:
        /// <list type="number">
        ///     <item><description>Go through every Item that has children checking if any of them as a greater value</description></item>
        ///     <item><description>If a children has a greater value, swap the child with largest value to the position of the parent 
        ///     and recursivelly check the children of the child index that had the largest value, 
        ///     this will apply the Heap property to all subtrees below the initial Parent</description></item>
        ///     <item><description>Apply the step above until reaching a node that doesn't have children with greater values or have no children at all.</description></item>
        ///     <item><description>After finishing the step above, move to the next item that has children</description></item>
        /// </list>
        /// </summary>
        /// <param name="array"></param>
        public void Heapify(int[] array)
        {
            _lastItemIndex = array.Length - 1;

            for (int i = array.Length / 2; i >= 0; i--)
            {
                DoHeapify(array, i);
            }

            _data = array;
        }

        private void DoHeapify(int[] array, int index)
        {
            int indexOfLargestValue = index;
            int leftIndex = GetLeftChildIndex(index);
            int rightIndex = GetRightChildIndex(index);

            if (leftIndex < array.Length && array[leftIndex] > array[index]) 
                indexOfLargestValue = leftIndex;

            if (rightIndex < array.Length && array[rightIndex] > array[indexOfLargestValue])
                indexOfLargestValue = rightIndex;

            if (indexOfLargestValue != index)
            {
                Swap(array, index, indexOfLargestValue);
                DoHeapify(array, indexOfLargestValue);
            }
        }

        private static void Swap(int[] array, int indexA, int indexB)
        {
            (array[indexA], array[indexB]) = (array[indexB], array[indexA]);
        }

        private int GetParentIndex(int index) => (index - 1) / 2;

        private int GetLeftChildIndex(int index) => (index * 2) + 1;

        private int GetRightChildIndex(int index) => (index * 2) + 2;

        private bool HasChildWithAGreaterValue(int index)
        {
            int leftChildIndex = GetLeftChildIndex(index);
            int rightChildIndex = GetRightChildIndex(index);
            return (leftChildIndex < _data.Length && _data[leftChildIndex] > _data[index]) || (rightChildIndex < _data.Length && _data[rightChildIndex] > _data[index]);
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
