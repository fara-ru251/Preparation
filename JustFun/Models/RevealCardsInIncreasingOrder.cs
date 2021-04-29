using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JustFun.Models
{
    public class RevealCardsInIncreasingOrder
    {
        public int[] Solve(int[] deck)
        {
            /*
             * Explanation: To have sorted decks(in unrevealed view) via following algorithm
             * we need to do the same operation in sorted view of array
             */

            int n = deck.Length;
            Queue<int> q = new Queue<int>(deck.Length);

            for (int i = 0; i < n; i++)
            {
                q.Enqueue(i);
            }

            Array.Sort(deck);

            //result array to return
            int[] rst = new int[n];

            for (int i = 0; i < n; i++)
            {
                rst[q.Dequeue()] = deck[i];

                //Queue have elements
                if (q.Count > 1)
                {
                    //element at the start of the queue to the end
                    q.Enqueue(q.Dequeue());
                }
            }

            


            return rst;
        }
    }
}
