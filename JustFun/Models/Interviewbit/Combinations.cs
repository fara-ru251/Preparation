using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JustFun.Models.Interviewbit
{
    public class Combinations
    {
        public List<List<int>> Find(int n, int k)
        {
            List<List<int>> all_part = new List<List<int>>();
            List<int> curr_part = new List<int>();

            int start = 1;

            DoRecursive(n, k, start, all_part, curr_part);


            return all_part;
        }

        private void DoRecursive(int n, int k, int start, List<List<int>> all_part, List<int> curr_part)
        {
            if (curr_part.Count == k)
            {
                all_part.Add(new List<int>(curr_part));
                return;
            }

            int i = start;

            while (i <= n)
            {
                curr_part.Add(i);

                DoRecursive(n, k, i + 1, all_part, curr_part);

                curr_part.Remove(i);

                i++;
            }
        }
    }
}
