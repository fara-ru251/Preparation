using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JustFun.Models.Interviewbit
{
    public class ContainsDuplicateII
    {
        public bool Check(int[] nums, int k)
        {
            //using sliding window
            if (k <= 0)
            {
                return false;
            }

            k = k >= nums.Length ? nums.Length : k;

            HashSet<int> hash_set = new HashSet<int>();


            for (int i = 0; i < nums.Length; i++)
            {
                if (hash_set.Count < k + 1)
                {
                    if (!hash_set.Add(nums[i]))
                    {
                        return true;
                    }
                }
                else
                {
                    if (!hash_set.Remove(nums[i - (k + 1)]))
                    {
                        throw new KeyNotFoundException("Element not found");
                    }

                    if (!hash_set.Add(nums[i]))
                    {
                        return true;
                    }
                }
            }





            return false;
        }
    }
}
