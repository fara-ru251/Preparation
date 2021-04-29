using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JustFun.Models.Interviewbit
{
    public class ReverseStackWithRecursion
    {
        public Stack<int> _stack { get; private set; }

        public List<int> out_arr { get; private set; }

        public ReverseStackWithRecursion(List<int> arr)
        {
            this._stack = new Stack<int>(arr.Count);

            this.out_arr = new List<int>(arr.Count);

            for (int i = 0; i < arr.Count; i++)
            {
                _stack.Push(arr[i]);
            }
        }

        public void RecursiveSolve()
        {
            if (this._stack.Count > 0)
            {
                out_arr.Add(this._stack.Pop());

                RecursiveSolve();
            }

            return;
        }
    }
}
