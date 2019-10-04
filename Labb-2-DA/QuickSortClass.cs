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
            //Swap(array, lo, hi);              //Use lo as pivot
            //Swap(array, (hi - lo) / 2, hi);   //Use middle as pivot
            int i = lo;
            for (int j = lo; j < hi; j++)
            {
                if(array[j] < array[hi])
                {
                    Swap(array, i, j);
                    i++;
                }
            }
            Swap(array, i, hi);
            return i;
        }

        static void Swap(int[] array, int a, int b)
        {
            int temp = array[a];
            array[a] = array[b];
            array[b] = temp;
        }
    }
}
