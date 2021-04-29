using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JustFun.Models.Interviewbit
{
    public class LongestRepeatingCharacterReplacementRepeat
    {
        //resolve
        public int FindAfter(string s, int k)
        {
            int curr_len = 0;
            int max_len = 0;
            int l = 0;
            int num_flip = 0;

            int i = 0;

            while (i < s.Length)
            {
                if (s[l] == s[i])
                {
                    curr_len++;
                }
                else
                {
                    if (num_flip  < k)
                    {
                        curr_len++;
                        num_flip++;
                    }
                    else
                    {

                        num_flip = curr_len - num_flip;
                        //while (s[l] != s[i])
                        //{
                        //    num_flip--;
                        //    curr_len--;
                        //    l++;
                        //}
                        //i--;
                    }
                }

                max_len = Math.Max(max_len, curr_len);
                i++;
            }


            return max_len;
        }
    }
}
