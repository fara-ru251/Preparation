using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JustFun.Sorting
{
    internal class QuickSortPivotLastElement
    {
        public void QuickSort(int[] arr)
        {
            int low = 0, high = arr.Length - 1;
            InnerQuickSort(arr, low, high);

            int i = 0;

            while (i <= high)
            {
                Console.Write(arr[i].ToString() + " ");
                i++;
            }
            Console.WriteLine();
        }

        private void InnerQuickSort(int[] arr, int low, int high)
        {
            if (low < high)
            {
                int pi = Partition(arr, low, high);

                InnerQuickSort(arr, low, pi - 1);
                InnerQuickSort(arr, pi + 1, high);
            }
        }

        private int Partition(int[] arr, int low, int high)
        {
            int pivot = arr[high];

            int j = low, i = low;

            while (j < high)
            {
                if (arr[j] < pivot)
                {
                    Swap(arr, i, j);

                    i++;
                }

                j++;
            }

            Swap(arr, i, high);

            return i;
        }

        private void Swap(int[] arr, int j, int i)
        {
            int ti = arr[j];
            arr[j] = arr[i];
            arr[i] = ti;
        }
    }
}
