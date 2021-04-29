using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JustFun.Models
{
    public class LongestRepeatingCharacterReplacement
    {
        public int Replace(string s, int k)
        {
            int[] letters = new int[26];
            int start = 0;
            int window_max_char = 0;
            int max_len = 0;

            for (int end = 0; end < s.Length; end++)
            {
                window_max_char = Math.Max(window_max_char, ++letters[s[end] - 'A']); // increment current char count

                if (end - start + 1 > window_max_char + k)
                {
                    letters[s[start] - 'A']--;
                    start++; // shift left end for one point right
                }

                max_len = Math.Max(max_len, end - start + 1);
            }

            return max_len;
        }
    }
}
