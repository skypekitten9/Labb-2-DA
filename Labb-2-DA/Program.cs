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
            Shuffle(data, 0, data.Length-1);

            int[] test = {4, 5, 6, 2};

            long before = Environment.TickCount;
            QuickSortClass.QuickSort(test, 0, test.Length - 1);
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
    }
}
