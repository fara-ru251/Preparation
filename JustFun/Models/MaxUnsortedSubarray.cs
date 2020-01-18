using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JustFun.Models
{
    public class MaxUnsortedSubarray
    {
        public static List<int> Find(List<int> arr)
        {
            /*
             * A[l], … , A[r] minimum-unsorted-subarray
             * MIN(A[l], … , A[r]) >= MAX(A[0], … , A[l - 1])
             * MAX(A[l], … , A[r]) <= MIN(A[r + 1], … , A[N - 1])
             *
             */
            int left = -1, right = arr.Count; // initial window range

            int left_max = 0; //maximum in left side of window
            int right_min = 0; // minimum in right side of window

            int i = 0;
            while (i < arr.Count)
            {
                if (arr[i] > arr[i + 1])
                {
                    left = i;
                    break;
                }
                i++;
            }

            i = arr.Count - 1;
            while (i >= 1)
            {
                if (arr[i] < arr[i - 1])
                {
                    right = i;
                    break;
                }
                i--;
            }

            if (left == -1)
            {
                return new List<int>() { left };
            }




            return arr.GetRange(0, arr.Count - 1);
        }
    }
}
