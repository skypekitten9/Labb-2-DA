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
            int mid = Partition(array, lo, lo, hi);
            QuickSort(array, lo, mid - 1);
            QuickSort(array, mid + 1, hi);
        }

        static int Partition(int[] array, int pivot, int lo, int hi)
        {
            //1
            int temp = array[hi];
            array[hi] = array[pivot];
            array[pivot] = temp;
            pivot = hi;

            //2-4
            int smaller = 0, larger = 0;
            bool foundLow = false, foundHigh = false;
            for (int i = lo; i <= hi; i++)
            {
                if (array[i] > array[pivot] && !foundHigh)
                {
                    larger = i;
                    foundHigh = true;
                }
                if (array[hi - i + lo] < array[pivot] && !foundLow)
                {
                    smaller = hi - i + lo;
                    foundLow = true;
                }
                if (foundLow && foundHigh) break;
            }

            //5
            if (larger < smaller && foundHigh && foundLow)
            {
                temp = array[larger];
                array[larger] = array[smaller];
                array[smaller] = temp;
                pivot = Partition(array, pivot, lo, hi);
            }
            else if (foundHigh)
            {
                temp = array[larger];
                array[larger] = array[pivot];
                array[pivot] = temp;
                pivot = larger;
            }
            return pivot;
        }
    }
}
