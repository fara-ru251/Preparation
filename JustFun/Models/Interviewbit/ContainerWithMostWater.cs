using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JustFun.Models.Interviewbit
{
    public class ContainerWithMostWater
    {
        public int Solve(int[] heights)
        {
            int i = 0;
            int j = heights.Length - 1;
            int area = 0;

            while (i < j)
            {
                

                area = Math.Max(area, Math.Min(heights[i], heights[j])* (j - i));

                if (heights[i] > heights[j])
                {
                    j--;
                }
                else
                {
                    i++;
                }
            }

            return area;
        }
    }
}
