using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JustFun.Models
{
    public class SquaresOfSortedArray
    {
        public int[] SortedSquares(int[] nums)
        {
            int left = 0;
            int right = nums.Length - 1;

            int[] ans = new int[nums.Length];

            for (int i = right; i >= 0; i--)
            {
                if (Math.Abs(nums[right]) >= Math.Abs(nums[left]))
                {
                    ans[i] = nums[right] * nums[right];
                    right--;
                }
                else
                {
                    ans[i] = nums[left] * nums[left];
                    left++;
                }
            }
            

            return ans;
        }
    }
}
