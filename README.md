# MaxHeap Class

The `MaxHeap` class implements a binary max-heap data structure. A max-heap is a complete binary tree where the value of each node is greater than or equal to the values of its children. This class provides methods for inserting elements, popping the maximum element, and heapifying an unsorted array.

## Constructors

### `MaxHeap(int capacity)`

Creates a new instance of the `MaxHeap` class with the specified capacity.

- **Parameters:**
  - `capacity` (int): The maximum capacity of the max-heap.

## Methods

### `void Insert(int value)`

Inserts a new value into the max-heap while maintaining the heap property.

- **Parameters:**
  - `value` (int): The value to be inserted.

### `int Pop()`

Removes and returns the maximum value from the max-heap while maintaining the heap property.

- **Returns:** The maximum value in the max-heap.

### `void Heapify(int[] array)`

Transforms an unsorted array into a max-heap in-place.

- **Parameters:**
  - `array` (int[]): The array to be transformed into a max-heap.

## Private Methods

The following methods are used internally to assist with heap operations:

- `void DoHeapify(int[] array, int index)`
- `static void Swap(int[] array, int indexA, int indexB)`
- `int GetParentIndex(int index)`
- `int GetLeftChildIndex(int index)`
- `int GetRightChildIndex(int index)`
- `bool HasChildWithAGreaterValue(int index)`
- `int GetIndexOfChildWithGreaterValue(int index)`

## Insertion Algorithm

1. Insert the value at the last available position in the array.
2. Compare the new value index with its parent index.
3. If the new value is greater than its parent, swap the value of the current index with its parent index.
4. Repeat step 3, moving the new value up through the heap, until it has a parent whose value is greater than it.

## Pop Algorithm

1. Remove the greatest value (at index 0).
2. Move the value of the last available position in the array to position 0.
3. Check if the new root has children with greater values; if so, move the greatest child to its position.
4. Repeat step 3 until the heap property is restored.

## Heapify Algorithm

1. Go through every item that has children, checking if any of them have a greater value.
2. If a child has a greater value, swap the child with the largest value to the position of the parent and recursively check the subtree.
3. Apply the above step until reaching a node without children with greater values or no children at all.
4. After finishing, move to the next item with children.

## Example Usage

```csharp
MaxHeap maxHeap = new MaxHeap(10);
maxHeap.Insert(5);
maxHeap.Insert(8);
maxHeap.Insert(3);

int max = maxHeap.Pop(); // Returns 8
