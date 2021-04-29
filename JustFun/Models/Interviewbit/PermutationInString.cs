using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JustFun.Models.Interviewbit
{
    public class PermutationInString
    {
        public bool CheckInclusion(string s1, string s2)
        {
            Dictionary<char, int> dict = new Dictionary<char, int>(s1.Length / 2);

            int i = 0;
            while (i < s1.Length)
            {
                if (!dict.ContainsKey(s1[i]))
                {
                    dict.Add(s1[i], 1);
                }
                else
                {
                    dict[s1[i]]++;
                }
                i++;
            }

            i = 0;

            int l = 0; //left side


            while (i < s2.Length)
            {
                if (dict.ContainsKey(s2[i]))
                {
                    if (dict[s2[i]] > 0)
                    {
                        dict[s2[i]]--;

                        if (i - l + 1 == s1.Length)
                        {
                            return true;
                        }
                    }
                    else
                    {
                        while (l < i && s2[l] != s2[i])
                        {
                            dict[s2[l]]++;
                            l++;
                        }
                        dict[s2[l++]]++;
                        i--;
                    }
                }
                else
                {
                    while (l < i)
                    {
                        dict[s2[l]]++;
                        l++;
                    }
                    l++;
                }
                i++;
            }




            return false;
        }

    }
}
