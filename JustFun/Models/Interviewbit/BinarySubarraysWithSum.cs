using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JustFun.Models.Interviewbit
{
    public class BinarySubarraysWithSum
    {
        public int FindCount(int[] arr, int needed)
        {
            int left = 0, right = 0, sum = 0, result = 0;

            while (right < arr.Length)
            {
                sum += arr[right];

                //moving left border to get rid of 1's
                while (left < right && sum > needed)
                {
                    //no addions to result
                    sum -= arr[left++];
                }

                //right border will always be counted first, means VARIATIONS of right border 
                if (sum == needed)
                {
                    result++;

                    int i = left;
                    while (i < right && arr[i] == 0) // left border must be equal to zero to count it as variation
                    {
                        result++;
                        i++;
                    }
                }

                right++;
            }

            return result;


            #region OldVersion
            //int curr_sum = 0;
            //int cnt = 0;
            //int l = 0; // left trailing part

            //int i = 0;

            //while (i < arr.Length)
            //{
            //    if (curr_sum + arr[i] < needed)
            //    {
            //        curr_sum += arr[i];
            //    }
            //    else if (curr_sum + arr[i] == needed)
            //    {
            //        curr_sum += arr[i];
            //        cnt++;

            //        while (curr_sum - arr[l] == needed && i > l)
            //        {
            //            cnt++;
            //            l++;
            //        }
                    
            //    }
            //    else
            //    {
            //        curr_sum -= arr[l++];
            //        continue;
            //    }

            //    i++;
            //}

            //return cnt;
            #endregion
        }
    }
}
