using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JustFun.Models
{
    public class CheckArrayFormationThroughConcatenation
    {
        public bool CanFormArray(int[] arr, int[][] pieces)
        {
            var dict = new Dictionary<int, int>();

            for (int i = 0; i < arr.Length; i++)
            {
                dict.Add(arr[i], i);
            }


            for (int i = 0; i < pieces.Length; i++)
            {
                var piece = pieces[i];

                for (int j = 0; j < piece.Length; j++)
                {
                    if (!dict.ContainsKey(piece[j]))
                    {
                        return false;
                    }

                    if (j > 0) //more than one element
                    {
                        if (dict[piece[j]] - dict[piece[j - 1]] != 1)
                        {
                            return false;
                        }
                    }
                }
            }


            return true;
        }
    }
}
