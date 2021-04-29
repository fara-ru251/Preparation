using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JustFun.Leetcode
{
    public class No1_TwoSum
    {
        public int[] TwoSum(int[] nums, int target)
        {
            var hashNums = new Dictionary<int, int>();

            for (int i = 0; i < nums.Length; i++)
            {
                var diff = target - nums[i];
                if (hashNums.ContainsKey(diff) && hashNums[diff] != i)
                {
                    return new int[] { i, hashNums[diff] };
                }
                else
                {
                    hashNums.Add(nums[i], i);
                }
            }

            throw new ArgumentException("No solution");
        }
    }
}
