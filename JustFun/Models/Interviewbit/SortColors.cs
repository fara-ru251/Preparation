using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JustFun.Models.Interviewbit
{
    public class SortColors
    {
        // TODO дорешать 
        public int Solve(int[] nums)
        {
            int start = 0;
            int end = nums.Length - 1;
            int current = 0;
            while (current <= end && start < end)
            {
                if (nums[current] == 0)
                {
                    nums[current] = nums[start];
                    nums[start] = 0;
                    current++;
                    start++;
                }
                else if (nums[current] = 2)
                {
                    nums[current] = nums[end];
                    nums[end] = 2;
                    end--;
                }
                else
                {
                    current++;
                }
            }

            return nums;
        }
    }
}
