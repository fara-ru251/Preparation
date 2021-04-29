using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JustFun.Models.Interviewbit
{
    public class ToeplitzMatrix
    {
        //Usage:
        //int[][] matrix = new int[3][]
        //    {
        //        new int[3]{ 1, 2, 3 },
        //        new int[3]{ 5, 1, 2 },
        //        new int[3]{ 9, 5, 1 }
        //    };

        //ToeplitzMatrix toeplitz = new ToeplitzMatrix();

        //var isThis = toeplitz.IsThisOne(matrix);

        public bool IsThisOne(int[][] matrix)
        {
            


            int m = matrix.Length - 1; // row len
            int n = matrix[0].Length - 1; // column len
            int i = matrix.Length - 2;
            int j = 0;

            //by bottom-left row to top-left
            int curr = 0;
            while(i >= 0)
            {
                j = 0;
                int k = i;
                curr = matrix[k++][j++];
                while (k <= m)
                {
                    if (curr != matrix[k++][j++])
                    {
                        return false;
                    }
                }
                i--;
            }

            j = 1;
            while (j <= n - 1)
            {
                i = 0;
                int k = j;
                curr = matrix[i++][k++];
                while (k <= n)
                {
                    if (curr != matrix[i++][k++])
                    {
                        return false;
                    }
                }
                j++;
            }

            return true;
        }
    }
}
