using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JustFun.Models
{
    class LexicoHelper : IComparer<string>
    {
        public int Compare(string x, string y)
        {
            return string.Compare(x + y, y + x);
        }
    }

}
