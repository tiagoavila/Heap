# MaxHeap

The `MaxHeap` class is an implementation of a maximum heap data structure, which is a specialized binary tree-based data structure with the following properties:

## Constructor
- `MaxHeap(int capacity)`: Constructs a new instance of the MaxHeap class with a specified capacity.

## Insertion Operation
- `void Insert(int value)`: Inserts a new value into the Max Heap by following the algorithm described below:
  1. The new value is inserted at the last available position in the underlying array.
  2. The new value's index is compared with its parent's index.
  3. If the new value is greater than its parent, the values of the current index and its parent index are swapped.
  4. The above step is repeated, effectively moving the new value up through the heap, until it has a parent whose value is greater than it.

## Utility Methods
- `int[] GetHeap()`: Returns the underlying array representation of the Max Heap.

## Private Helper Methods
- `int GetParentIndex(int index)`: Calculates and returns the index of the parent node for a given node index in the binary heap.
- `int GetLeftChildIndex(int index)`: Calculates and returns the index of the left child node for a given node index in the binary heap.
- `int GetRightChildIndex(int index)`: Calculates and returns the index of the right child node for a given node index in the binary heap.

The MaxHeap class efficiently maintains the Max Heap property, which ensures that the value of each node in the heap is greater than or equal to the values of its child nodes. The class provides methods to insert new elements and access the underlying data structure. This data structure is often used in various algorithms and applications, such as priority queues, sorting algorithms, and graph algorithms like Prim's algorithm.
