using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Labb_2_DA
{
    static class QuickSortClass
    {
        public static void QuickSort(int[] array, int lo, int hi)
        {
            if (!(hi > lo)) return;
            int pivot = Partition(array, lo, hi);
            QuickSort(array, lo, pivot - 1);
            QuickSort(array, pivot + 1, hi);
        }

        static int Partition(int[] array, int lo, int hi)
        {
            int i = lo;
            int j = hi + 1;
            int pivot = array[lo];
            while (true)
            {
                while(array[++i] < pivot)
                {
                    if (i == hi) break;
                }
                while(pivot < array[--j])
                {
                    if (j == lo) break;
                }
                if (i>=j) break;
                Swap(array, i, j);
            }
            Swap(array, lo, j);
            return j;
        }

        public static void Swap(int[] array, int a, int b)
        {
            int temp = array[a];
            array[a] = array[b];
            array[b] = temp;
        }
    }
}
