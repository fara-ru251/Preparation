using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JustFun.Models
{
    internal sealed class MyQuickSort
    {
        public void Sort(int[] arr)
        {
            int low = 0;
            int high = arr.Length - 1;
            InnerQuickSort(arr, low, high);

            for (int i = 0; i < arr.Length; i++)
            {
                Console.Write(arr[i] + " ");
            }
            Console.WriteLine();
        }

        private void InnerQuickSort(int[] arr, int low, int high)
        {
            if (low < high)
            {
                int pivotIndex = Partition(arr, low, high);


                InnerQuickSort(arr, low, pivotIndex);
                InnerQuickSort(arr, pivotIndex + 1, high);
            }
        }

        private int Partition(int[] arr, int low, int high)
        {
            int pivot = arr[high]; // last element

            int i = low; // indexes to swap

            int j = low; // increment

            while (j < high)
            {
                if (arr[j] < pivot)
                {
                    i++;
                }
                else
                {
                    int temp1 = arr[j];
                    arr[j] = arr[i];
                    arr[i] = temp1;
                }

                j++;
            }

            int temp = arr[i];
            arr[i] = arr[high];
            arr[high] = temp;

            return i;
        }
    }
}
