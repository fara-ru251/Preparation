using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JustFun.Models
{
    public class InsertionSort
    {
        public void Sort(int[] arr)
        {
            for (int i = 1; i < arr.Length; i++)
            {
                int key = arr[i];
                int j = i - 1; // prev element


                while (j >= 0 && arr[j] > key)
                {
                    arr[j + 1] = arr[j];

                    j--;
                }

                arr[j + 1] = key;
            }

            return;
        }
    }
}
