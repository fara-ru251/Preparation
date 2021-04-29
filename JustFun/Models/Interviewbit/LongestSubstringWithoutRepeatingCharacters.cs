using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JustFun.Models.Interviewbit
{
    public class LongestSubstringWithoutRepeatingCharacters
    {

        //done
        public int Find(string s)
        {
            int l = 0;
            int i = 0;
            int curr_window = 0;
            int max_window = 0;
            Dictionary<char, bool> dict = new Dictionary<char, bool>(s.Length / 2);

            while (i < s.Length)
            {
                curr_window++;

                if (!dict.ContainsKey(s[i]) || !dict[s[i]])
                {
                    dict[s[i]] = true;
                    
                }
                else
                {
                    while (l < i && s[l] != s[i])
                    {
                        dict[s[l]] = false;
                        l++;
                        //curr_window--;
                        
                    }
                    //dict[s[l]] = false;
                    l++; // additional increment to get around s[l] == s[i]
                    curr_window = i - l + 1;
                }

                max_window = Math.Max(max_window, curr_window);
                i++;
            }

            return max_window;
        }
    }
}
