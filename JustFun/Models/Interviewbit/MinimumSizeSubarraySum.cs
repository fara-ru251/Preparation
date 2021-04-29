using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JustFun.Models.Interviewbit
{
    public class MinimumSizeSubarraySum
    {
        public int Find(int[] nums, int needed)
        {
            int curr_size = 0; // initial window size

            int min_size = nums.Length;
            int curr_sum = 0;
            int max_sum = 0;

            int i = 0;

            while (i < nums.Length)
            {
                if (curr_sum < needed)
                {
                    curr_sum += nums[i];
                    curr_size++;
                }
                else
                {
                    //if (sum >= needed || (sum == needed && curr_size > min_size))
                    //{
                    //    min_size = curr_size;
                    //}
                    min_size = Math.Min(min_size, curr_size);

                    curr_sum -= nums[i - curr_size];
                    curr_size--;
                    continue;
                }

                max_sum += nums[i];
                i++;
            }

            if (max_sum < needed)
            {
                return 0;
            }


            while (curr_sum >= needed)
            {

                min_size = Math.Min(min_size, curr_size);

                curr_sum -= nums[i - curr_size];
                curr_size--;


            }



            return min_size;
        }
    }
}
