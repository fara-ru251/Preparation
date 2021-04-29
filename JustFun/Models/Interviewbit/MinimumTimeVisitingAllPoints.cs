using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JustFun.Models.Interviewbit
{
    public class MinimumTimeVisitingAllPoints
    {
        public int Find(int[][] points)
        {
            if (points == null)
            {
                return 0;
            }

            int time = 0;

            for (int i = 1; i < points.Length; i++)
            {
                //source point "x1" and "y1" (x1, x2)
                int x1 = points[i - 1][0], y1 = points[i - 1][1];
                //target point "x2" and "y2"  (x2, y2)
                int x2 = points[i][0], y2 = points[i][1];

                int x_diff = Math.Abs(x2 - x1);
                int y_diff = Math.Abs(y2 - y1);
                time += Math.Min(x_diff, y_diff) + Math.Abs(y_diff - x_diff);
            }



            return time;
        }
    }
}
