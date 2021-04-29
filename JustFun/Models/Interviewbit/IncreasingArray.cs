using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JustFun.Models.Interviewbit
{
    public class IncreasingArray
    {
        public bool Check(int[] nums)
        {
            int times = 0;

            for (int i = 1; i < nums.Length; i++)
            {
                if (nums[i] < nums[i - 1])
                {
                    times++;

                    if (i == 1 || nums[i - 2] <= nums[i])
                    {
                        nums[i - 1] = nums[i];
                    }
                    else
                    {
                        nums[i] = nums[i - 1];
                    }
                }
            }

            return times <= 1;
        }
    }
}
