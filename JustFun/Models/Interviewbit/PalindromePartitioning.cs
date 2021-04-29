using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JustFun.Models.Interviewbit
{
    public class PalindromePartitioning
    {
        public IList<IList<string>> Do(string s)
        {
            IList<IList<string>> all_part = new List<IList<string>>(s.Length);

            IList<string> curr_part = new List<string>();

            DoRecursive(s, 0, all_part, curr_part);

            return all_part;
        }
        public void DoRecursive(string s, int index, IList<IList<string>> all_part, IList<string> curr_part)
        {
            //guard
            if (index == s.Length)
            {
                all_part.Add(new List<string>(curr_part)); // copy to new list
                return;
            }

            int i = index;
            while (i < s.Length)
            {
                if (IsPalindrome(s, index, i))
                {
                    curr_part.Add(s.Substring(index, i - index + 1));

                    DoRecursive(s, i + 1, all_part, curr_part);

                    curr_part.RemoveAt(curr_part.Count - 1);
                }
                i++;
            }
        }

        private bool IsPalindrome(string s, int l, int r)
        {
            while (l < r)
            {
                if (s[l] != s[r])
                {
                    return false;
                }
                l++;
                r--;
            }

            return true;
        }
    }
}
