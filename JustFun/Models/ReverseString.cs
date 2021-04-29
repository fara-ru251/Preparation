using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JustFun.Models
{
    public class ReverseString
    {
        public void Do(char[] s)
        {
            for (int i = 0; i < s.Length / 2; i++)
            {
                char temp = s[i];
                s[i] = s[(s.Length - 1) - i];
                s[(s.Length - 1) - i] = temp;
            }



        }
    }
}
