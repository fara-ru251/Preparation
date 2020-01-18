using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JustFun.Models
{
    public static class ReversePolishNotation
    {
        public static int Evaluate(List<string> arr)
        {
            int i = 0;
            Stack<int> st = new Stack<int>();

            while (i < arr.Count)
            {
                if (arr[i] != "+" && arr[i] != "-" && arr[i] != "/" && arr[i] != "*")
                {
                    st.Push(int.Parse(arr[i]));
                }
                else
                {
                    if (arr[i] == "+")
                    {
                        int sum = 0;
                        bool two_times = false;
                        while (st.Count > 0)
                        {
                            sum += st.Pop();
                            if (two_times)
                            {
                                break;
                            }
                            two_times = true;
                        }
                        st.Push(sum);
                    }
                    else if (arr[i] == "-")
                    {
                        int diff = 0;
                        if (st.Count > 0)
                        {
                            diff = (-1) * st.Pop();
                        }

                        if (st.Count > 0)
                        {
                            diff += st.Pop();
                            st.Push(diff);
                        }
                        else
                        {
                            st.Push((-1) * diff);
                        }
                    }
                    else if (arr[i] == "*")
                    {
                        int product = 1;
                        bool two_times = false;
                        while (st.Count > 0)
                        {
                            product *= st.Pop();
                            if (two_times)
                            {
                                break;
                            }
                            two_times = true;
                        }
                        st.Push(product);
                    }
                    else if (arr[i] == "/")
                    {
                        int div = 0;
                        if (st.Count > 0)
                        {
                            div = st.Pop();
                        }

                        if (st.Count > 0)
                        {
                            div = st.Pop() / div;
                        }
                        st.Push(div);
                    }
                }
                i++;
            }

            return st.Pop();
        }

        
    }
}
