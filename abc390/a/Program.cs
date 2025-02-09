using System;
using System.Linq;

namespace x
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] A = Array.ConvertAll(Console.ReadLine().Split(), int.Parse);
            bool canSort = false;

            for (int i = 0; i < A.Length - 1; i++)
            {
                Swap(A, i, i + 1);
                if (IsSorted(A))
                {
                    canSort = true;
                    break;
                }
                Swap(A, i, i + 1);
            }

            Console.WriteLine(canSort ? "Yes" : "No");
        }

        static void Swap(int[] array, int index1, int index2)
        {
            int temp = array[index1];
            array[index1] = array[index2];
            array[index2] = temp;
        }

        static bool IsSorted(int[] array)
        {
            for (int i = 0; i < array.Length - 1; i++)
            {
                if (array[i] > array[i + 1])
                {
                    return false;
                }
            }
            return true;
        }
    }
}
