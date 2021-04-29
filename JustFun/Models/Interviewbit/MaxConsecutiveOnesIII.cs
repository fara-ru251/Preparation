using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JustFun.Models.Interviewbit
{
    public class MaxConsecutiveOnesIII
    {
        public int Find(int[] arr, int k)
        {
            int curr_len = 0;
            int max_len = 0;
            int left = 0; // left border of window
            int num_flips = 0; // number of flips from 0 to 1
            //int right = 0; // right border of 1 numbered element

            int i = 0;

            while (i < arr.Length)
            {
                if (arr[i] == 1)
                {
                    curr_len++;
                    //right = i;
                }
                else // arr[i] == 0
                {
                    if (num_flips < k)
                    {
                        num_flips++;
                        curr_len++;
                    }
                    else //num_flips == k
                    {
                        if (arr[left] == 0) // left border's number is 0
                        {
                            left++; // move left border to one position forward
                            //do nothing it is OK
                        }
                        else // arr[left] == 1
                        {
                            while (arr[left] == 1)
                            {
                                left++;
                                curr_len--;
                            }
                            i--;
                        }
                    }
                }

                max_len = Math.Max(max_len, curr_len);
                i++;
            }



            return max_len;
        }
    }
}
