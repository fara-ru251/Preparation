using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JustFun.Models
{
    public class NearestSmallerElement
    {
        public List<int> Find(List<int> arr)
        {
            Stack<int> st = new Stack<int>(arr.Count);

            List<int> ans = new List<int>(arr.Count);

            for (int i = 0; i < arr.Count; i++)
            {
                while (st.Count > 0 && st.Peek() >= arr[i])
                {
                    st.Pop();
                }

                if (st.Count > 0)
                {
                    ans.Add(st.Peek());
                }
                else
                {
                    ans.Add(-1);
                }

                st.Push(arr[i]);
            }

            return ans;
        }
    }
}
