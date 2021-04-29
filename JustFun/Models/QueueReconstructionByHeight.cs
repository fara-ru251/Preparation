using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JustFun.Models
{
    public class QueueReconstructionByHeight
    {
        public int[][] Solve(int[][] arr)
        {
            Array.Sort(arr, new HeightComparerHelper());

            int[][] ans = new int[arr.Length][];

            for (int i = arr.Length - 1; i >= 0; i--)
            {
                InsertToPosition(ans, arr[i]);
            }



            return ans;
        }

        private void InsertToPosition(int[][] ans, int[] inner_arr)
        {
            if (ans[inner_arr[1]] == null)
            {
                ans[inner_arr[1]] = inner_arr;
                return;
            }



            for (int i = ans.Length - 1; i > inner_arr[1]; i--)
            {
                if (ans[i - 1] != null)
                {
                    ans[i] = ans[i - 1];
                }
            }

            ans[inner_arr[1]] = inner_arr;
        }
    }
    public class HeightComparerHelper : IComparer<int[]>
    {
        public int Compare(int[] x, int[] y)
        {
            if (x[0] < y[0])
            {
                return -1;
            }

            if (x[0] == y[0])
            {
                if (x[1] < y[1])
                {
                    return 1;
                }

                if (x[1] == y[1])
                {
                    return 0;
                }

                return -1;
            }


            return 1;
        }
    }
}
