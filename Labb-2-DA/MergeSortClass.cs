using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Labb_2_DA
{
    static class MergeSortClass
    {
        public static int[] MergeSort(int[] array)
        {
            if (array.Length == 1)
            {
                return array;
            }
            int[] arrayLow = array.Take(array.Length / 2).ToArray();
            int[] arrayHigh = array.Skip(array.Length / 2).ToArray();
            MergeSort(arrayLow);
            MergeSort(arrayHigh);
            return Merge(array, arrayLow, arrayHigh);
        }

        public static int[] Merge(int[] array, int[] arrayLow, int[] arrayHigh)
        {
            int i = 0, j = 0, k = 0;
            while(i != arrayLow.Length && j != arrayHigh.Length)
            {
                if(arrayLow[i] < arrayHigh[j])
                {
                    array[k++] = arrayLow[i++];
                }
                else
                {
                    array[k++] = arrayHigh[j++];
                }
            }
            while(i < arrayLow.Length) array[k++] = arrayLow[i++];
            while (j < arrayHigh.Length) array[k++] = arrayHigh[j++];
            return array;
        }
    }
}
