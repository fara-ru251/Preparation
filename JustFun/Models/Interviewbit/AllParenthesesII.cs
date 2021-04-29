using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JustFun.Models.Interviewbit
{
    public class AllParenthesesII
    {
        public List<string> Generate(int n)
        {
            List<string> all_part = new List<string>();
            int left = 1; // opening bracket initial position
            int right = 1; // closing bracket initial position
            int curr = 0;
            char[] arr = new char[6];


            DeRecursiveSecond(n,left, right, curr, all_part, arr);

            return all_part;
        }

        private void DeRecursiveSecond(int n,int l, int r, int curr, List<string> all_part, char[] arr)
        {
            if (l > n && r > n)
            {
                all_part.Add(new string(arr));
                return;
            }


            if (l <= n)
            {
                arr[curr] = '(';
                DeRecursiveSecond(n, l + 1, r, curr + 1, all_part, arr);
            }
            if (r < l)
            {
                arr[curr] = ')';
                DeRecursiveSecond(n, l, r + 1, curr + 1, all_part, arr);
            }

        }
    }
}
