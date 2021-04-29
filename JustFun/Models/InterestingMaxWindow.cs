using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JustFun.Models
{
    internal sealed class InterestingMaxWindow
    {
        public void PrintMaxWindow(Nullable<int>[] arr)
        {
            int i = 0, end = 0;
            int curr_len = 0, max_len = 0;
            int curr_sum = 0, max_sum = 0;

            while (i < arr.Length)
            {
                if (!arr[i].HasValue) // skip "null" values
                {
                    curr_len = 0;
                    curr_sum = 0;
                    i++;
                    continue;
                }

                curr_len++;
                curr_sum += arr[i].Value;



                if (curr_sum > max_sum || (curr_sum == max_sum && curr_len > max_len))
                {
                    max_sum = curr_sum;
                    max_len = curr_len;
                    end = i;
                }

                i++;
            }


            i = end - max_len + 1;

            while (i <= end)
            {
                Console.Write(arr[i] + " ");
                i++;
            }
            Console.WriteLine();
        }

        public void PrintMinAverageWindow(Nullable<int>[] arr)
        {
            int i = 0, end = 0;
            int curr_len = 0, len = 0;
            int curr_sum = 0;
            int curr_avg = 0, min_avg = int.MaxValue;

            while (i < arr.Length)
            {
                if (!arr[i].HasValue) // skip "null" values
                {
                    curr_len = 0;
                    curr_sum = 0;
                    i++;
                    continue;
                }



                while (i < arr.Length && arr[i].HasValue)
                {
                    curr_len++;
                    curr_sum += arr[i].Value;
                    curr_avg = curr_sum / curr_len;
                    i++;
                }

                i--;
               
                if (curr_avg < min_avg)
                {
                    min_avg = curr_avg;
                    len = curr_len;
                    end = i;
                }

                i++;
            }


            i = end - len + 1;

            while (i <= end)
            {
                Console.Write(arr[i] + " ");
                i++;
            }
            Console.WriteLine();
            Console.WriteLine("Length: " + len + " Ending Index: " + end);
        }
    }
}
