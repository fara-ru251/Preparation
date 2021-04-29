using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JustFun.Models
{
    internal class MaximumNumberVowelsInSubstringOfGivenLength
    {
        public int MaxVowels(string s, int k)
        {
            HashSet<char> hs = new HashSet<char>(new char[] { 'a', 'e', 'i', 'o', 'u' });

            int end = 0, start = 0, vowel_cnt = 0, max_vwl_cnt = 0;


            while (end < s.Length)
            {
                


                if (hs.Contains(s[end]))
                {
                    vowel_cnt++;
                }

               

                if (end - start + 1 > k)
                {
                    if (hs.Contains(s[start]))
                    {
                        vowel_cnt--;
                    }

                    start++;
                }

                max_vwl_cnt = Math.Max(max_vwl_cnt, vowel_cnt);

                end++;
            }

            return vowel_cnt;
        }
    }
}
