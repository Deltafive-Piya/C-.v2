/**
 * Class to represent a MinHeap which is a Priority Queue optimized for fast
 * retrieval of the minimum value. It is implemented using an array but it is
 * best visualized as a tree structure where each 'node' has left and right
 * children except the 'node' may only have a left child.
 * - parent is located at: Math.floor(i / 2);
 * - left child is located at: i * 2
 * - right child is located at: i * 2 + 1
 * Visualizer: https://www.cs.usfca.edu/~galles/visualization/Heap.html
 */
class MinHeap {
	constructor() {
		this.heap = [null];
	}

	idxOfParent(i) {
		return Math.floor(i / 2);
	}

	idxOfLeftChild(i) {
		return i * 2;
	}

	idxOfRightChild(i) {
		return i * 2 + 1;
	}

	top() {
		if (this.heap.length > 1) {
			return this.heap[1];
		}
		return null;
	}

	/**
	 * Inserts a new number into the heap and maintains the heap's order.
	 * 1. Push new num to the back.
	 * 2. Iteratively swap the new num with its parent while it is smaller than
	 *    its parent.
	 * - Time: O(log n) logarithmic due to shiftUp / iterative swapping.
	 * - Space: O(1) constant.
	 */
	insert(num) {
		this.heap.push(num);
		let currentIdx = this.heap.length - 1;

        //while current index is greaterThan 1 AND 
        //num lessThan index of indexOfParent within thisHeap
		while (currentIdx > 1 && num < this.heap[this.idxOfParent(currentIdx)]) {
			const parentIdx = this.idxOfParent(currentIdx);
			// Swap the child and parent
			[this.heap[currentIdx], this.heap[parentIdx]] = [
				this.heap[parentIdx],
				this.heap[currentIdx],
			];
			currentIdx = parentIdx;
		}
	}

	/**
	 * Logs the tree horizontally with the root on the left and the index in
	 * parenthesis using reverse inorder traversal.
	 */
	printHorizontalTree(parentIdx = 1, spaceCnt = 0, spaceIncr = 10) {
		if (parentIdx > this.heap.length - 1) {
			return;
		}

		spaceCnt += spaceIncr;
		this.printHorizontalTree(parentIdx * 2 + 1, spaceCnt);

		console.log(
			" ".repeat(spaceCnt < spaceIncr ? 0 : spaceCnt - spaceIncr) +
				`${this.heap[parentIdx]} (${parentIdx})`
		);

		this.printHorizontalTree(parentIdx * 2, spaceCnt);
	}
}

// Test code
let testHeap = new MinHeap();

testHeap.insert(5);
testHeap.insert(6);
testHeap.insert(7);
testHeap.insert(4);

console.log("Top of the heap:", testHeap.top());
console.log("Heap:");
testHeap.printHorizontalTree();
