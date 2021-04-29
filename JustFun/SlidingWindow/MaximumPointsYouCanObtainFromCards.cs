using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JustFun.SlidingWindow
{
    public class MaximumPointsYouCanObtainFromCards
    {
        public int MaxScore(int[] cardPoints, int k)
        {
            int end = 0, start = 0;
            int len = cardPoints.Length;
            int curr_sum = 0;
            int max_sum = 0;
            int ans = 0;
            int window = len - k;

            for (int i = 0; i < cardPoints.Length; i++)
            {
                max_sum += cardPoints[i];
            }

            while (end < len)
            {
                curr_sum += cardPoints[end];

                if (end - start + 1 == window) // length of window
                {
                    ans = Math.Max(ans, max_sum - curr_sum);
                    curr_sum -= cardPoints[start];
                    start++;
                }

                end++;
            }




            return ans;
        }

    }
}
