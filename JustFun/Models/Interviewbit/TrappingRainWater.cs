using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JustFun.Models.Interviewbit
{
    public class TrappingRainWater
    {
        public int Solve(int[] heights)
        {
            int max_height = 0;
            int max_h_index = 0;

            int i = 0;


            for (i = 0; i < heights.Length; i++)
            {
                max_height = Math.Max(max_height, heights[i]);

                if (heights[i] >= max_height)
                {
                    max_height = heights[i];
                    max_h_index = i;
                }

            }

            i = 0;
            int curr_h = 0;
            int max_h = 0;
            int cumulative_sum = 0;

            while (i < max_h_index)
            {
                curr_h = heights[i];

                max_h = Math.Max(max_h, curr_h);

                cumulative_sum += max_h - curr_h;

                i++;
            }


            i = heights.Length - 1;
            max_h = 0;

            while (i > max_h_index)
            {

                curr_h = heights[i];

                max_h = Math.Max(max_h, curr_h);

                cumulative_sum += max_h - curr_h;
                i--;
            }


            return cumulative_sum;
        }
    }
}
