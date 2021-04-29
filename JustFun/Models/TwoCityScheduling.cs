using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JustFun.Models
{
    public class TwoCityScheduling
    {
        public int Evaluate(int[][] arr)
        {
            int[] refund = new int[arr.Length]; // where we get our overpaid money back

            int total_cost = 0;

            //initially we send all people to city A
            for (int i = 0; i < arr.Length; i++)
            {
                total_cost += arr[i][0]; // every person goes to city A
                refund[i] = arr[i][1] - arr[i][0]; // counting overpaid money
            }

            //sort, so that we get overpaid amount first
            Array.Sort(refund);

            //only traverse half, so that half to city A, another to city B
            for (int i = 0; i < refund.Length / 2; i++)
            {
                total_cost += refund[i];
            }

            return total_cost;
        }
    }
}
