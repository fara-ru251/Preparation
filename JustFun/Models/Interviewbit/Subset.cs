using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JustFun.Models.Interviewbit
{
    public class Subset
    {
        public List<List<int>> Fill(List<int> arr)
        {

            arr.Sort();
            int i = 0;
            int num_elements = 1; // 2^0 when no elements in array
            int num_base = 2;
            while (i < arr.Count)
            {
                num_elements *= num_base;
                i++;
            }

            List<List<int>> all_part = new List<List<int>>(num_elements);
            List<int> curr_part = new List<int>();
            int start = 0;

            DoRecursive(arr,start, all_part, curr_part);

            return all_part;
        }

        private void DoRecursive(List<int> arr, int start, List<List<int>> all_part, List<int> curr_part)
        {
            all_part.Add(new List<int>(curr_part));

            int i = start;

            while (i < arr.Count)
            {
                curr_part.Add(arr[i]);

                DoRecursive(arr, i + 1, all_part, curr_part);

                curr_part.Remove(arr[i]);
                i++;
            }
        }
    }
}
