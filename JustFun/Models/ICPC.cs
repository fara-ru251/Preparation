using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JustFun.Models
{
    internal class ICPC
    {
        public int FindMaxNumberOfTasksCompleted(int n, int[][] times)
        {
            //int index = 0;
            //int[] time_remain = new int[] { 300, 300, 300 }; // each has 300 min = 5 hours
            List<List<int>> all_part = new List<List<int>>();
            List<int> sum_part = new List<int>();

            for (int i = 0; i < times.Length; i++)
            {
                List<int> curr_ans = new List<int>();
                RecursiveSolution(times, i, new int[] { 300, 300, 300 }, new List<int>(), all_part, sum_part);
            }

            int max_cnt = 0;
            int min_penalty = int.MaxValue;

            for (int i = 0; i < all_part.Count; i++)
            {
                var inner = all_part[i];
                var sum = sum_part[i];

                if (inner.Count > max_cnt)
                {
                    max_cnt = inner.Count;

                    min_penalty = sum;
                }
                else if (inner.Count == max_cnt)
                {
                    min_penalty = Math.Min(min_penalty, sum);
                }

                for (int j = 0; j < inner.Count; j++)
                {
                    Console.Write(inner[j] + " ");
                }
                Console.WriteLine(", sum: " + sum);
            }

            Console.WriteLine("No.tasks: " + max_cnt + ", Min.penalty: " + min_penalty);


            return 0;
        }

        private void RecursiveSolution(int[][] times, int index, int[] time_remain, List<int> curr_part, List<List<int>> all_part, List<int> sum_part)
        {
            if (index == times.Length)
            {
                return;
            }

            var curr_task = times[index];
            for (int j = 0; j < curr_task.Length; j++)
            {
                if (time_remain[j] - curr_task[j] >= 0) // has complete current task
                {
                    curr_part.Add(curr_task[j]);
                    time_remain[j] -= curr_task[j];

                    RecursiveSolution(times, index + 1, time_remain, curr_part, all_part, sum_part);


                    all_part.Add(new List<int>(curr_part));
                    sum_part.Add(curr_part.Sum());

                    curr_part.Remove(curr_task[j]);
                    time_remain[j] += curr_task[j];
                }
                else if (curr_task[j] > 300) // GT 5 hours
                {
                    RecursiveSolution(times, index + 1, time_remain, curr_part, all_part, sum_part);
                }
                
                //otherwise skip
            }
        }
    }
}
