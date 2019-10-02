using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Labb_2_DA
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] data = ReadIntfile("largeints"); // Also try "largeints"!
            int N = 2000;    // Change to some smaller number to test on part of array.
            int max = 10000;
            PrintData(N, max, data);

            long before = Environment.TickCount;
            MergeSortClass.MergeSort(data);
            long after = Environment.TickCount;
            Console.WriteLine((after - before) / 1000.0 + " seconds.");

            PrintData(N, max, data);
            Console.ReadLine();
        }

        static void PrintData(int N, int max, int[] data)
        {
            if (N <= max)
            {
                for (int i = 0; i < N; i++) { System.Console.Write(data[i] + " "); }
                System.Console.Write("\n\n");
            }
        }

        static int[] ReadIntfile(String filename)
        {
            // Read file into a byte array, and then combine every group of four bytes to an int. (Not
            // the standard way, but it works!)
            byte[] bytes = File.ReadAllBytes(filename);
            int[] ints = new int[bytes.Length / 4];
            for (int i = 0; i < ints.Length; i++)
            {
                for (int j = 0; j < 4; j++) { ints[i] += (bytes[i * 4 + j] & 255) << (3 - j) * 8; }
            }
            return ints;
        }

        // Checks if the first n element of a are in sorted order.
        private static bool IsSorted(int[] a, int lo, int hi)
        {
            int flaws = 0;
            for (int i = lo + 1; i <= hi; i++)
            {
                if (a[i] < a[i - 1])
                {
                    if (flaws++ >= 10)
                    {
                        System.Console.WriteLine("...");
                        break;
                    }
                    System.Console.WriteLine("a[" + (i - 1) + "] = " + a[i - 1] + ", a[" + i + "] = " + a[i]);
                }
            }
            return flaws == 0;
        }
    }
}
