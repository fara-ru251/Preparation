using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JustFun.Models.Interviewbit
{
    public class GrumpyBookstoreOwner
    {
        public int MaxSatisfied(int[] customers, int[] grumpy, int x)
        {
            int len = customers.Length;

            int left = 0;
            int max_num = 0;
            int curr_num = 0;
            int curr_potential_num = 0;
            int max_pot_num = 0;

            int i = 0;

            while (i < len)
            {
                if (grumpy[i] == 0)
                {
                    curr_num += customers[i];

                }

                if (grumpy[i] == 1)
                {
                    curr_potential_num += customers[i];

                    while (left + x <= i) 
                    {
                        if (grumpy[left] == 1)
                        {
                            curr_potential_num -= customers[left];
                        }
                       
                        left++;
                    }

                    max_pot_num = Math.Max(max_pot_num, curr_potential_num);
                }

                max_num = Math.Max(max_num, curr_num + max_pot_num);
                i++;
            }





            return max_num;
        }
    }
}
