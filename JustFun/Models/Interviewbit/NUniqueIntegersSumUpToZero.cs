using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JustFun.Models.Interviewbit
{
    public class NUniqueIntegersSumUpToZero
    {
        public int[] FindSumZero(int n)
        {
            int[] arr = new int[n];
            if (n % 2 == 0) // n is even
            {
                int start = (n / 2) * -1;
                int i = 0;
                while (start <= (n / 2))
                {
                    if (start == 0)
                    {
                        start++;
                        continue;
                    }

                    arr[i++] = start++;
                }
            }
            else // n is odd
            {
                int start = (n / 2) * -1;
                int i = 0;
                while (start <= (n / 2))
                {
                    arr[i++] = start++;
                }
            }


            return arr;
        }
    }
}
