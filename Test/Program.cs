using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Heap;

namespace Test
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            MaxComparer<int> comparer = new MaxComparer<int>();
            List<int> list = new List<int> { 8, 15, 11, 6, 9, 7, 8, 1, 3, 5 };
            BinaryHeap<int> kucha = new BinaryHeap<int>(list, comparer);
            Console.WriteLine(kucha.GetMaxOrMin());
            Console.ReadKey();
        }
    }
}