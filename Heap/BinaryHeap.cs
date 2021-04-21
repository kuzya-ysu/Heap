using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Heap
{
    public class BinaryHeap<T>
    {
        public int Count { get; set; }
        public int Capacity { get; set; }
        private List<T> Heap { get; set; }
        private IComparer<T> Comparer { get; set; }

        public BinaryHeap(IComparer<T> comparer)
        {
            Comparer = comparer;
        }

        public BinaryHeap(ICollection<T> collection, IComparer<T> comparer)
        {
            Heap = collection.ToList();
            Count = Heap.Count;
            Capacity = (int)Math.Pow(2, Math.Ceiling(Math.Log(Count, 2)));
            Comparer = comparer;
            BuildHeap(Heap);
        }

        public BinaryHeap(int capacity, IComparer<T> comparer)
        {
            Capacity = capacity;
            Comparer = comparer;
        }

        public void Add(T value)
        {
            Heap.Add(value);
            Count++;
            int i = Count - 1;
            int parent = (i - 1) / 2;

            while (i > 0 && Comparer.Compare(Heap[parent], Heap[i]) < 0)
            {
                var temp = Heap[i];
                Heap[i] = Heap[parent];
                Heap[parent] = temp;

                i = parent;
                parent = (i - 1) / 2;
            }
        }

        public T GetMaxOrMin()
        {
            return Heap[0];
        }

        public void RemoveMaxOrMin()
        {
            Heap[0] = Heap[Count - 1];
            Heap.RemoveAt(Count - 1);
            Heapify(0);
        }

        private void BuildHeap(List<T> list)
        {
            for (var i = (Count - 1) / 2; i >= 0; i--)
            {
                Heapify(i);
            }
        }

        private void Heapify(int index)
        {
            var left = 2 * index + 1;
            var right = 2 * index + 2;
            var largest = index;
            if (left < Count && Comparer.Compare(Heap[left], Heap[index]) > 0)
            { largest = left; }
            if (right < Count && Comparer.Compare(Heap[right], Heap[largest]) > 0)
            { largest = right; }

            if (largest == index)
                return;
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