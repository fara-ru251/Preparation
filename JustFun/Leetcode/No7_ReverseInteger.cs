using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JustFun.Leetcode
{
    public class No7_ReverseInteger
    {
        public int Reverse(int x)
        {
            /* 1534236469
             * 
             */
            int ans = 0;
            
            while (x != 0)
            {
                int rem = x % 10;
                if (ans > int.MaxValue / 10 || ans == int.MaxValue / 10 && rem > 7)
                {
                    return 0;
                }

                if (ans < int.MinValue / 10 || ans == int.MinValue / 10 && rem < -8)
                {
                    return 0;
                }
                ans = ans * 10 + rem;
                x /= 10;
            }

            
            

            return ans;
        }
    }
}
