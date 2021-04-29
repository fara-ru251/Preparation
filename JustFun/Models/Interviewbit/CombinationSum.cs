using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JustFun.Models.Interviewbit
{
    public class CombinationSum
    {
        public List<List<int>> combinationSum(List<int> arr, int k)
        {
            var uniq_arr = arr.Distinct().ToList();

            uniq_arr.Sort();

            List<List<int>> all_part = new List<List<int>>();

            List<int> curr_part = new List<int>();

            int start = 0;
            int sum = 0;

            DoRecursive(arr, k, start, all_part, curr_part, sum);

            return all_part;
        }

        private void DoRecursive(List<int> arr, int k, int start, List<List<int>> all_part, List<int> curr_part, int sum)
        {
            if (sum == k)
            {
                all_part.Add(new List<int>(curr_part));
                return;
            }


            int i = start;

            while (i < arr.Count)
            {
                sum += arr[i];

                if ((sum < k && (k - sum >= arr[i])) || sum == k)
                {
                    curr_part.Add(arr[i]);

                    DoRecursive(arr, k, i, all_part, curr_part, sum);

                    curr_part.Remove(arr[i]);
                }

                sum -= arr[i];
                i++;
            }
        }
    }
}
