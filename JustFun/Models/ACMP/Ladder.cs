using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JustFun.Models.ACMP
{
    public class Ladder
    {
        public int Calculate(int n, int k)
        {
            int result = 1;
            for (int i = 1; i <= n / 2 && i < k; i++)
            {
                result += Calculate(i, k - i);
            }

            return (n < 1) ? 0 : result;

            //for (int i = 1; i <= (n - 1) / 2; i++)
            //{
            //    result += Calculate(i);
            //}
        }

        public int ModifiedCalc(int n, int k)
        {

            /* n => how many blocks we have
             * k => how many blocks we have in a previous row (in one line)
             */





            return int.MinValue;
        }
    }
}
