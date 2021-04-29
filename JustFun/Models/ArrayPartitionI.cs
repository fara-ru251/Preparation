using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JustFun.Models
{
    public class ArrayPartitionI
    {
        public int ArrayPairSum(int[] nums)
        {
            Array.Sort(nums);

            int sum = 0;
            int i = 0;

            while (i < nums.Length)
            {
                sum += nums[i];
                i += 2;
            }

            return sum;
        }
    }
}
