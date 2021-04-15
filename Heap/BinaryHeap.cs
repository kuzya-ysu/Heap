using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Heap
{
    public class BinaryHeap<T>
    {
        public int HeapSize { get; set; }
        public int Capacity { get; set; }
        private T[] Heap { get; set; }
        private IComparer<T> Comparer { get; set; }

        public BinaryHeap(IComparer<T> comparer)
        {
            Comparer = comparer;
        }
        public BinaryHeap(ICollection<T> collection, IComparer<T> comparer)
        {
            collection.CopyTo(Heap, 0);
            HeapSize = Heap.Length;
            Capacity = (int)Math.Pow(2, Math.Ceiling(Math.Log(HeapSize, 2)));
            Comparer = comparer;
        }
        public BinaryHeap(int capacity, IComparer<T> comparer)
        {
            Capacity = capacity;
        }


        public void BuildHeap(T[] array)
        {
            for (var i = (HeapSize - 1) / 2; i >= 0; i--)
            {
                Heapify(i);
            }

        }

        private void Heapify(int index)
        {
            var left = 2 * index + 1;
            var right = 2 * index + 2;
            var largest = index;
            if (left < HeapSize && Comparer.Compare(Heap[left], Heap[index]) > 0)
            { largest = left; }
            if (right < HeapSize && Comparer.Compare(Heap[right], Heap[largest]) > 0)
            { largest = right; }

            if (largest == index) return;
            var temp = Heap[largest];
            Heap[largest] = Heap[index];
            Heap[index] = temp;
            Heapify(largest);
        }


    }
    public class MaxComparer<T> : IComparer<T> where T : IComparable
    {
        public int Compare(T x, T y)
        {
            return x.CompareTo(y);
        }
    }

    public class MinComparer<T> : IComparer<T> where T : IComparable
    {
        public int Compare(T x, T y)
        {
            return y.CompareTo(x);
        }
    }
}
