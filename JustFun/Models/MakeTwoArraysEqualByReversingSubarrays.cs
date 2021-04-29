using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JustFun.Models
{
    public class MakeTwoArraysEqualByReversingSubarrays
    {
        public bool CanBeEqual(int[] target, int[] arr)
        {
            Dictionary<int, int> dict = new Dictionary<int, int>();


            for (int i = 0; i < arr.Length; i++)
            {
                if (!dict.ContainsKey(arr[i]))
                {
                    dict.Add(arr[i], 1);
                }
                else
                {
                    dict[arr[i]]++;
                }
            }

            for (int i = 0; i < target.Length; i++)
            {
                if (!dict.ContainsKey(target[i]))
                {
                    return false;
                }

                dict[target[i]]--;

                if (dict[target[i]] < 0)
                {
                    return false;
                }
            }

            return true;
        }
    }
}
