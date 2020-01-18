using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JustFun.Models.Codeforces
{
    public static class RectangularLand
    {
        public static void Calculate(int area)
        {

            int root = (int)Math.Ceiling(Math.Sqrt(area));



            int i = 1;

            while (i <= root)
            {
                int new_area = i * (area / i);

                if (new_area == area)
                {
                    break;
                }

                i++;
            }

            Console.WriteLine(i + " " + (area / i));
        }
    }

    public static class EndingPoint
    {
        public static void Find(int x, int y, string s)
        {
            int i = 0;

            while (i < s.Length)
            {
                if (s[i] == 'U')
                {
                    y++;
                }
                else if (s[i] == 'D')
                {
                    y--;
                }
                else if (s[i] == 'R')
                {
                    x++;
                }
                else if (s[i] == 'L')
                {
                    x--;
                }

                i++;
            }


            Console.WriteLine(x + " " + y);
        }
    }

    public static class ShortestPath{
        public static void Find(int n, int coins, int[] arr)
        {
            int curr_left = 0, curr_right = 0;
            int curr_sum = 0;

            int left = 0, right = n - 1;

            int i = 0;

            while (i < n)
            {
                curr_sum += arr[i];
                curr_right = i;

                if (curr_sum >= coins)
                {
                    while(curr_sum - arr[curr_left] >= coins)
                    {
                        curr_sum = curr_sum - arr[curr_left];
                        curr_left++;
                    }

                    if ((curr_right - curr_left) <= (right - left))
                    {
                        left = curr_left;
                        right = curr_right;
                    }
                }
                i++;
            }

            if (curr_sum < coins)
            {
                Console.WriteLine(-1);
                return;
            }

            Console.WriteLine(right - left + 1);
        }
    }

}
