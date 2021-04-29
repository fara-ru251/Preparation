using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JustFun.Models.Interviewbit
{
    public class GetEqualSubstringsWithinBudget
    {
        public int Find(string s, string t, int maxCost)
        {
            if (s == t)
            {
                return 0;
            }


            int len = s.Length;
            int max_len = 0;

            int curr_len = 0;
            int curr_cost = 0;
            int left = 0;

            int i = 0;

            while (i < len)
            {
                curr_len++;

                curr_cost += Math.Abs(s[i] - t[i]);

                while (curr_cost > maxCost)
                {
                    curr_cost -= Math.Abs(s[left] - t[left]);
                    curr_len--;
                    left++;
                }


                max_len = Math.Max(max_len, curr_len);
                i++;
            }


            return max_len;
        }
    }
}
