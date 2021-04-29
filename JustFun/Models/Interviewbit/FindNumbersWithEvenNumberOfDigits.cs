using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JustFun.Models.Interviewbit
{
    public class FindNumbersWithEvenNumberOfDigits
    {
        public int Count(int[] nums)
        {
            int cnt = 0;
            for (int i = 0; i < nums.Length; i++)
            {


                int num_digits = GetNumDigits(nums[i]);

                if (num_digits % 2 == 0)
                {
                    cnt++;
                }
            }
            return cnt;
        }

        private int GetNumDigits(int n)
        {
            int cnt_digits = 0;

            while (n > 0)
            {
                cnt_digits++;
                n = n / 10;
            }

            return cnt_digits;
        }

    }
}
