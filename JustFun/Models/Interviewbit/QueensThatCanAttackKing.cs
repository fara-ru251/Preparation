using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JustFun.Models.Interviewbit
{
    public class QueensThatCanAttackKing
    {
        public IList<IList<int>> Solve(int[][] queens, int[] king)
        {
            var result = new List<IList<int>>();

            //8 directions  DELTA (variation of variable) {-1, 1}

            //positions of QUEENS (8,8) chessboard
            bool[][] taken = new bool[8][];


            for (int i = 0; i < taken.Length; i++)
            {
                taken[i] = new bool[8];
            }

            for (int i = 0; i < queens.Length; i++)
            {
                //mark positions of queens as TRUE
                taken[queens[i][0]][queens[i][1]] = true;
            }


            for (int d1 = -1; d1 <= 1; d1++)
            {
                for (int d2 = -1; d2 <= 1; d2++)
                {
                    //direction {0, 0} NOT INTERESTING
                    if (d1 == 0 && d2 == 0)
                    {
                        continue;
                    }

                    int row = king[0];
                    int col = king[1];

                    do
                    {
                        row += d1;
                        col += d2;
                    } while (Inside(row, col) && !taken[row][col]);

                    if (Inside(row, col))
                    {
                        result.Add(new List<int>() { row, col });
                    }
                }
            }

            return result;
        }

        private bool Inside(int row, int col)
        {
            // 0 <= row < 8
            // 0 <= col < 8
            return (row >= 0 && row < 8) && (col >= 0 && col < 8);
        }
    }
}
