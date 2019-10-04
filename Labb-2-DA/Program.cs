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
            int max = 10000;
            PrintData(max, data);
            Shuffle(data, 0, data.Length-1);
            if (IsSorted(data, 0, max)) Console.WriteLine("Array is sorted.\n");
            else Console.WriteLine("Array is NOT sorted.\n");

            long before = Environment.TickCount;
            QuickSortClass.QuickSort(data, 0, data.Length - 1);
            long after = Environment.TickCount;
            

            PrintData(max, data);
            if (IsSorted(data, 0, max)) Console.WriteLine("Array is sorted.\n");
            else Console.WriteLine("Array is NOT sorted.\n");
            Console.WriteLine((after - before) / 1000.0 + " seconds.");
            Console.ReadLine();
        }

        static void PrintData(int max, int[] data)
        {
            for (int i = 0; i < data.Length; i++)
            {
                System.Console.Write(data[i] + " ");
                if (i > max) break;
            }
            System.Console.Write("\n\n");

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

        // Shuffles the first n elements of a.
        public static void Shuffle(int[] a, int lo, int hi)
        {
            Random rand = new Random();
            for (int i = lo; i <= hi; i++)
            {
                int r = i + rand.Next(hi + 1 - i);     // between i and hi
                int t = a[i]; a[i] = a[r]; a[r] = t;
            }
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
