using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp3
{
    delegate void NeedAllStart(int[,] Array);

    static class Math
    {
        static private event NeedAllStart AllMethod;
        private static int min = 0;
        private static int max = 0;
        public static int Min { get => min; }
        public static int Max { get => max; }
        private static int difference = 0;
        public static int Difference { get => difference; }

        public static void MinIn2DArray(int[,] Array)
        {
            Array = Sort(Array, 0, Array.GetLength(0) - 1);
            min = Array[0,0];
        }

        public static void MaxIn2DArray(int[,] Array)
        {
            Array = Sort(Array, 0, Array.GetLength(0) - 1);
            max = Array[Array.GetLength(0) - 1, Array.GetLength(1) - 1];
        }

        public static void DifferenceIn2DArray(int[,] Array)
        {
            Array = Sort(Array, 0, Array.GetLength(0) - 1);
            difference = Array[0,0] + Array[Array.GetLength(0) - 1, Array.GetLength(1) - 1];
        }

        public static void Print(int[,] Array)
        {
            {
                int j;
                for (int i = 0; i < Array.GetLength(0) - 1; i++)
                {
                    for (j = 0; j < Array.GetLength(1) - 1; j++)
                        Console.Write(Array[i, j] + ", ");
                    Console.WriteLine();
                }
            }
            Console.WriteLine();

            Console.WriteLine($"Min {Min}");
            Console.WriteLine($"Max {Max}");
            Console.WriteLine($"Difference {Difference}");
            Console.WriteLine();
        }

        public static void Print()
        {
            Console.WriteLine($"Min {Min}");
            Console.WriteLine($"Max {Max}");
            Console.WriteLine($"Difference {Difference}");
            Console.WriteLine();
        }

        public static void StartAll(int[,] Array) { AllMethod.Invoke(Array); }

        private static int[,] Sort(int[,] array, int left, int right)
        {
            if (left < right)
            {
                int partitionIndex = Partition(array, left, right);
                Sort(array, left, partitionIndex - 1);
                Sort(array, partitionIndex + 1, right);
            }

            return array;
        }

        private static int Partition(int[,] array, int left, int right)
        {
            int pivot = array[left, 0];
            int low = left + 1;
            int high = right;

            while (true)
            {
                while (low <= high && array[low, 0] <= pivot)
                    low++;

                while (low <= high && array[high, 0] > pivot)
                    high--;

                if (low > high)
                    break;

                for (int j = 0; j < array.GetLength(1); j++)
                {
                    int temp = array[low, j];
                    array[low, j] = array[high, j];
                    array[high, j] = temp;
                }
            }

            for (int j = 0; j < array.GetLength(1); j++)
            {
                int temp = array[left, j];
                array[left, j] = array[high, j];
                array[high, j] = temp;
            }

            return high;
        }

        static Math()
        {
            AllMethod += Print;
            AllMethod += MinIn2DArray;
            AllMethod += MaxIn2DArray;
            AllMethod += DifferenceIn2DArray;
            AllMethod += Print;
        }
    }

    internal class Program
    {
        static void Main(string[] args)
        {
            int[,] number = {
                {5,3,2,4,1},
                {8,10,6,9,7},
                {13,15,11,14,15},
                {44,55,12,10,3}
            };

            Math.StartAll(number);
        }
    }
}
