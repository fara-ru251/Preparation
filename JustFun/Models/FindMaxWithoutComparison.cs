using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JustFun.Models
{
    public class FindMaxWithoutComparison
    {
        public int Find(int x, int y)
        {
            // x - ((x- y) & ((x - y) >> 31));
            int sign = ((x - y) >> (sizeof(int) * 8 - 1));
            int subtract_value = (x - y) & sign;
            return x - subtract_value;
        }
    }
}
