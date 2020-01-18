using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JustFun.Models.Interviewbit
{
    public class AllParentheses
    {
        public static int Generate(string str)
        {
            int i = 0;
            Stack<char> st = new Stack<char>();

            while (i < str.Length)
            {
                if (st.Count == 0)
                {
                    st.Push(str[i++]);
                    continue;
                }

                if ( 
                    (st.Peek() == '(' && str[i] == ')')
                    || (st.Peek() == '[' && str[i] == ']')
                    || (st.Peek() == '{' && str[i] == '}')
                    )
                {
                    st.Pop();
                }
                else
                {
                    st.Push(str[i]);
                }


                i++;
            }


            if (st.Count > 0)
            {
                return 0;
            }


            return 1;
        }


    }
}
