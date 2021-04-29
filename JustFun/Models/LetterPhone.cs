using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JustFun.Models
{
    public class LetterPhone
    {
        private Dictionary<char, string> dict { get; set; }

        private string[] arr { get; set; }

        public LetterPhone()
        {
            dict = new Dictionary<char, string>()
            {
                { '1', "1" },
                { '2', "abc" },
                { '3', "def" },
                { '4', "ghi" },
                { '5', "jkl" },
                { '6', "mno" },
                { '7', "pqrs" },
                { '8', "tuv" },
                { '9', "wxyz" },
                { '0', "0" }
            };
        }

        public List<string> letterCombinations(string s)
        {
            List<string> ans = new List<string>();

            StringBuilder sb = new StringBuilder();
            int start = 0;

            AllRecursiveCombinations(s, start, ans, sb);

            return ans;
        }

        private void AllRecursiveCombinations(string s, int start, List<string> ans, StringBuilder sb)
        {
            if (start == s.Length)
            {
                ans.Add(sb.ToString());
                return;
            }


            int j = 0;
            string letter = dict[s[start]];

            while (j < letter.Length)
            {
                sb.Append(letter[j]);

                AllRecursiveCombinations(s, start + 1, ans, sb);

                sb.Remove(start, 1);

                j++;
            }
        }
    }
}
