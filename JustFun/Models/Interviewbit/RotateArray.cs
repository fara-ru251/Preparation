using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JustFun.Models.Interviewbit
{
    public class RotateArray
    {
        /// <summary>
        /// Slow one. Time complexity O(n^2). Space complexity O(1)
        /// </summary>
        /// <param name="nums"></param>
        /// <param name="k"></param>
        public void Do(ref int[] nums, int k)
        {
            if (k == nums.Length)
            {
                return;
            }

            k = k > nums.Length ? (k % nums.Length) : k; 

            int start_pos = nums.Length - k;

            int m = 0;
            //k-steps to the right
            for (int i = start_pos; i < nums.Length ; i++)
            {
                int swap_num = nums[i];
                //for (int j = m + 1; j <= i; j++)
                //{
                //    nums[j] = nums[j - 1];
                //}

                for (int j = i; j > m; j--)
                {
                    nums[j] = nums[j - 1];
                }

                nums[m] = swap_num;
                m++;
            }

            return;
        }

        public void DoOne(ref int[] nums, int k)
        {
            if (k % nums.Length == 0)
            {
                return;
            }

            k = k % nums.Length;

            //reverse all elements in the array
            Reverse(ref nums, 0, nums.Length - 1);

            //reverse back part which is now located in front part
            Reverse(ref nums, 0, k - 1);

            //reverse front part which is now located in back end
            Reverse(ref nums, k, nums.Length - 1);

        }
        private void Reverse(ref int[] nums, int start, int end)
        {
            int j = end;
            for (int i = start; i <= j; i++)
            {
                int temp = nums[i];
                nums[i] = nums[j];
                nums[j] = temp;
                j--;
            }
        }
    }
}
