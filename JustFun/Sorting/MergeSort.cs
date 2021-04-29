using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JustFun.Sorting
{
    internal static class MergeSort
    {
        public static void Do()
        {
            int[] arr = { 38, 27, 43, 3, 9, 82, 10 }; 

            InnerMergeSort(arr, 0, arr.Length - 1);

            for (int i = 0; i < arr.Length; i++)
            {
                Console.Write(arr[i] + " ");
            }
            Console.WriteLine();
        }

        private static void InnerMergeSort(int[] arr, int low, int high)
        {
            if (low >= high)
            {
                return;
            }

            int mid = low + (high - low) / 2;

            InnerMergeSort(arr, low, mid); // left side
            InnerMergeSort(arr, mid + 1, high); // right side
            Merge(arr, low, mid, high);
        }

        private static void Merge(int[] arr, int low, int mid, int high)
        {
            int[] left = new int[mid - low + 1]; // left array
            int[] right = new int[high - mid]; //right array


            int i = 0;
            while (i < left.Length)
            {
                left[i] = arr[low + i];
                i++;
            }

            int j = 0;

            while (j < right.Length)
            {
                right[j] = arr[mid + 1 + j];
                j++;
            }

            i = 0;
            j = 0;

            int k = low;

            while (i < left.Length && j < right.Length)
            {
                if (left[i] < right[j])
                {
                    arr[k] = left[i++];
                }
                else
                {
                    arr[k] = right[j++];
                }

                k++;
            }

            while (i < left.Length)
            {
                arr[k++] = left[i++];
            }

            while (j < right.Length)
            {
                arr[k++] = right[j++];
            }
        }
    }
}
