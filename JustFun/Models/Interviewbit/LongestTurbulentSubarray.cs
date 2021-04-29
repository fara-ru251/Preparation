using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JustFun.Models.Interviewbit
{
    public class LongestTurbulentSubarray
    {
        public int Find(int[] arr)
        {
            if (arr == null || arr.Length == 0)
            {
                return 0;
            }


            int curr_len = 1; // initial size of turbulent subarray
            int left = 0; // left part of subarray

            int max_len = 1;

            int i = 1; // starting from second element

            //checking for arr[k - 1] > arr[k] < arr[k + 1]
            while (i < arr.Length)
            {
                max_len = Math.Max(max_len, curr_len);
                curr_len++;

                // if curr_subarray_size(MOD)2 equals to 0, it should lie between  two greater elements OR two less elements
                // this means that arr[k - 1] > arr[k] < arr[k + 1]
                // we check for minority

                if (curr_len % 2 == 0)
                {


                    if (arr[i - 1] <= arr[i])
                    {
                        left = i;
                        curr_len = 1;
                    }
                    
                }
                else 
                {
                    if (arr[i - 1] > arr[i])
                    {
                        left = i - 1;
                        curr_len = 2;
                    }
                    else if (arr[i - 1] == arr[i])
                    {
                        left = i;
                        curr_len = 1;
                    }
                }

                i++;
            }

            max_len = Math.Max(max_len, curr_len);

            i = 1;
            curr_len = 1;
            left = 0;

            //checking for arr[k - 1] < arr[k] > arr[k + 1]
            while (i < arr.Length)
            {
                max_len = Math.Max(max_len, curr_len);
                curr_len++;

                if (curr_len % 2 == 0)
                {


                    if (arr[i - 1] >= arr[i])
                    {
                        left = i;
                        curr_len = 1;
                    }
                }
                else
                {
                    if (arr[i - 1] < arr[i])
                    {
                        left = i - 1;
                        curr_len = 2;
                    }
                    else if (arr[i - 1] == arr[i])
                    {
                        left = i;
                        curr_len = 1;
                    }
                }

                i++;
            }


            max_len = Math.Max(max_len, curr_len);


            return max_len;
        }
    }
}
