using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JustFun.Models.Interviewbit
{
    public static class MaxFrequencyStack
    {
        public static void Solve(List<List<int>> arr)
        {
            Stack<int> st = new Stack<int>();

            int oper_type = 1;
            int num = 0;


            for (int i = 0; i < arr.Count; i++)
            {
                oper_type = arr[i][0];
                num = arr[i][1];

                if (oper_type == 1)
                {
                    st.Push(num);   
                }
                else if (oper_type == 2 && num == 0)
                {

                }
            }

        }
    }
}
