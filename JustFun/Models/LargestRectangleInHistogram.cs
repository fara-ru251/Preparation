using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JustFun.Models
{
    public class LargestRectangleInHistogram
    {
        public int Find(List<int> arr)
        {
            Stack<int> st = new Stack<int>();
            int maxArea = 0;

            for (int i = 0; i < arr.Count; i++)
            {
                if (st.Count == 0 || arr[i] >= arr[st.Peek()])
                {
                    st.Push(i);
                }

                if (arr[i] < arr[st.Peek()])
                {
                    while (st.Count > 0 && arr[st.Peek()] >= arr[i])
                    {
                        int height = arr[st.Pop()];

                        int left;
                        if (st.Count == 0)
                        {
                            left = -1;
                        }
                        else
                        {
                            left = st.Peek();
                        }

                        maxArea = Math.Max(maxArea, (i - left - 1) * height);
                    }
                    st.Push(i);
                }
            }

            if (st.Count > 0)
            {
                while (st.Count > 0)
                {
                    int height = arr[st.Pop()];

                    int left;
                    if (st.Count == 0)
                    {
                        left = -1;
                    }
                    else
                    {
                        left = st.Peek();
                    }

                    maxArea = Math.Max(maxArea, (arr.Count - left - 1) * height);
                }
            }


            return maxArea;
        }
    }
}
