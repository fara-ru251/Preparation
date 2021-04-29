using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JustFun.Models.Interviewbit
{
    public class ShortestUnsortedContinuousSubarray
    {
        public int Find(int[] nums)
        {
            int start_ind = -1;
            int end_ind = -1;

            int i = 1;
            int j = nums.Length - 1;
            while (i < nums.Length)
            {
                if (nums[i] < nums[i - 1])
                {
                    start_ind = i - 1;
                    break;
                }
                i++;
            }

            while (j >= 1)
            {
                if (nums[j] < nums[j - 1])
                {
                    end_ind = j;
                    break;
                }
                j--;
            }

            if (start_ind == -1)
            {
                return 0;
            }


            //int start_ind = nums.Length - 1;
            //int end_ind = 0;

            //int i = 1;
            //int j = nums.Length - 2;


            ////if i >= j => this means that our array is sorted
            //while (i < j)
            //{
            //    if (nums[i] < nums[i - 1])
            //    {
            //        start_ind =  Math.Min(start_ind, i);
            //    }


            //    if (nums[j] > nums[j + 1])
            //    {
            //        end_ind = Math.Max(end_ind, j);
            //    }

            //    i++;
            //    j--;
            //}

            ////no such subarray
            //if (start_ind >= end_ind)
            //{
            //    return 0;
            //}

            i = start_ind;
            int max = int.MinValue;
            int min = int.MaxValue; 

            while (i <= end_ind)
            {
                max = Math.Max(nums[i], max);
                min = Math.Min(nums[i], min);
                i++;
            }


            i = 0;
            while (i < start_ind)
            {
                if (nums[i] > min)
                {
                    start_ind = i;
                    break;
                }
                i++;
            }

            j = nums.Length - 1;
            while (j > end_ind)
            {
                if (max > nums[j])
                {
                    end_ind = j;
                    break;
                }
                j--;
            }

            return end_ind - start_ind + 1;
        }
    }
}
