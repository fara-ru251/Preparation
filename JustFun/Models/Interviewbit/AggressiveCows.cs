using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JustFun.Models.Interviewbit
{
    class AggressiveCows
    {
        public static int Arrange(List<int> arr, int cow_count)
        {
            int high = 1000000000;
            int low = 0;

            //sort
            arr.Sort();


            int lmd = low; //largest minimum distance (initial zero)


            while (low < high)
            {
                int mid = (low + high) / 2;


                if (Check(cow_count, mid, arr))
                {
                    low = mid + 1;
                    lmd = mid;
                }
                else
                {
                    high = mid - 1;
                }
            }



            return lmd;
        }

        private static bool Check(int cows, int distance, List<int> arr)
        {
            int cows_placed = 1, last_pos = arr[0];


            for (int i = 1; i < arr.Count; i++)
            {
                if ((arr[i] - last_pos) >= distance)
                {
                    if (++cows_placed == cows)
                    {
                        return true;
                    }
                    last_pos = arr[i];
                }
            }

            return false;
        }
    }
}
