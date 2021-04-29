using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JustFun.Models
{
    public class DungeonGame
    {
        public int CalculateMinimumHP(int[][] arr)
        {
            int row = arr.Length;
            int col = arr[0].Length;

            int[][] dp = new int[row][];

            for (int i = 0; i < row; i++)
            {
                dp[i] = new int[col];
            }

            for (int i = row - 1; i >= 0; i--)
            {
                for (int j = col - 1; j >= 0; j--)
                {
                    if (i == row - 1 && j == col - 1) //princess cell (bottom-right)
                    {
                        dp[i][j] = Math.Min(0, arr[i][j]);
                    }
                    else if (i == row - 1) // last row
                    {
                        dp[i][j] = Math.Min(0, arr[i][j] + dp[i][j + 1]);
                    }
                    else if (j == col - 1) // last col
                    {
                        dp[i][j] = Math.Min(0, arr[i][j] + dp[i + 1][j]);
                    }
                    else
                    {
                        dp[i][j] = Math.Min(0, arr[i][j] + Math.Max(dp[i][j + 1], dp[i + 1][j]));
                    }
                }
            }

            return Math.Abs(dp[0][0]) + 1;
        }
    }
}
