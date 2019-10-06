using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JustFun.Models
{
    public class BeerThief
    {
        public static long Calculate(int[] beers, int carry)
        {
            Array.Sort(beers);


            int index = beers.Length - carry;

            index = Math.Max(index, 0);
            long sum = 0;

            for (int i = index; i < beers.Length; i++)
            {
                sum += beers[i];
            }

            return sum;
        }
    }
}
