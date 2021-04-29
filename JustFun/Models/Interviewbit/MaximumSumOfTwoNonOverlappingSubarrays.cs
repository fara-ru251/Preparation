using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JustFun.Models.Interviewbit
{
    public class MaximumSumOfTwoNonOverlappingSubarrays
    {
        public int Solve(int[] nums, int l, int m)
        {
            return SumVariantsII(nums, l, m);

            //for overlapping subarrays
            //int sum1 = SumVariants(nums, l, m);
            //int sum2 = SumVariants(nums, m, l);

            //return Math.Max(sum1, sum2);
        }
        /// <summary>
        /// Maximum sum of two subarrays for overlapping one
        /// </summary>
        /// <param name="nums"></param>
        /// <param name="l"></param>
        /// <param name="m"></param>
        /// <returns></returns>
        private int SumVariants(int[] nums, int l, int m)
        {
            //first situation
            //0 <= i <= i + L - 1 < j <= j + M - 1 < nums.Length
            //second situation
            //0 <= j <= j + M - 1 < i <= i + L - 1 < nums.Length

            int first_part_sum = 0;
            int second_part_sum = 0;

            int i = 0; // first part starts with 0-index
            int j = l; // second part starts with l-index, l => length of first part as we need non-overlapping

            //starting sum of first part
            while (i < l)
            {
                first_part_sum += nums[i];
                i++;
            }

            //starting sum of second part
            while (j < l + m)
            {
                second_part_sum += nums[j];
                j++;
            }

            int temp_second_part = second_part_sum;
            int temp_first_part = first_part_sum;
            while (j < nums.Length)
            {
                temp_first_part = temp_first_part + nums[i] - nums[i - l];
                temp_second_part = temp_second_part + nums[j] - nums[j - m];
                first_part_sum = Math.Max(first_part_sum, temp_first_part);
                second_part_sum = Math.Max(second_part_sum, temp_second_part);
                i++;
                j++;
            }

            return first_part_sum + second_part_sum;
        }

        private int SumVariantsII(int[] nums, int l, int m)
        {
            for (int i = 1; i < nums.Length; i++)
            {
                //cumulative sum of next elements
                nums[i] += nums[i - 1];
            }

            int result = nums[l + m - 1]; //initially resulting sum (arr[0] + ... + arr[l - 1]) + (arr[l] + ... + arr[m - 1])
            int l_max = nums[l - 1];
            int m_max = nums[m - 1];

            //starting looping from "l + m", because of previous initial subarray values
            for (int i = l + m; i < nums.Length; i++)
            {
                l_max = Math.Max(l_max, nums[i - m] - nums[i - l - m]);
                m_max = Math.Max(m_max, nums[i - l] - nums[i - l - m]);

                //protection to not overlap
                result = Math.Max(result, Math.Max(l_max + nums[i] - nums[i - m], m_max + nums[i] - nums[i - l]));
            }

            return result;
        }
    }
}
