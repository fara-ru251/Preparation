using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JustFun.Models.Interviewbit
{
    public class MergeSortedArray
    {
        public void Do(int[] nums1, int m, int[] nums2, int n)
        {
            int i = m - 1, j = n - 1;
            int k = m + n - 1;

            //m >= n

            while (k >= 0)
            {
                if (i >= 0 && j >= 0)
                {
                    if (nums1[i] > nums2[j])
                    {
                        nums1[k] = nums1[i--];
                    }
                    else
                    {
                        nums1[k] = nums2[j--];
                    }
                }
                else if (j >= 0)
                {
                    nums1[k] = nums2[j--];
                }

                k--;
            }
        }   
    }
}
