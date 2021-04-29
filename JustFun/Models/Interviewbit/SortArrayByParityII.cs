using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JustFun.Models.Interviewbit
{
    public class SortArrayByParityII
    {
        public int[] Solve(int[] arr)
        {
            int i = 0; // even start position
            int j = arr.Length - 1; // odd start position

            while (i < arr.Length && j >= 1)
            {
                while (i < arr.Length && ((arr[i] & 1) == 0)) // when element is EVEN, and  number position is EVEN 
                {
                    i += 2; // just pass  2 steps
                }

                while (j >= 1 && ((arr[j] & 1) == 1)) // when element is ODD, and number position is ODD
                {
                    j -= 2; //just pass 2 steps
                }

                if (i < arr.Length && j >= 1)
                {
                    int temp = arr[i];
                    arr[i] = arr[j];
                    arr[j] = temp;
                }
            }


            return arr;
        }
    }
}
