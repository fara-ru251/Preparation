using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JustFun.Models.Interviewbit
{
    public class KthPermutationSequence
    {
        public string Find(int n, int k)
        {
            k--;
            int[] numbers = new int[n];
            int[] indices = new int[n];
            //int[] indices2 = new int[n];

            //initialize numbers
            for (int i = 0; i < n; i++)
            {
                numbers[i] = i + 1;
            }

            //Think about a simple case where you are finding the digits of a decimal number e.g. 4836.
            //You can compute rightmost place by dividing 4836 by 1 then modulo 10 to get 6.
            //Then 4836 by 10 modulo 10 to get 3, then 4836 by 100 modulo 10 to get 8 etc.
            //We don't need to change the number 4836 each time. 
            //Permutation case is similar but we use factorials instead of powers of 10 and modulus value changes


            int divisor = 1;

            for (int place = 1; place <= n; place++)
            {
                if ((k / divisor) == 0)
                {
                    //all the remaining indices will be zero
                    break;
                }

                //from rightmost to leftmost
                indices[n - place] = (k / divisor) % place;

                //divisor *= place;
                divisor += place;
            }


            //int x = k;
            //for (int i = 1; x > 0; x /= i++)
            //{
            //    indices2[n - i] = x % i;
            //}


            for (int i = 0; i < n; i++)
            {
                int index = indices[i] + i;

                if(index != i) // means that number is not in correct place 
                {
                    // take the element at "index" and move it to "i"
                    int temp = numbers[index];
                    for (int j = index; j > i; j--)
                    {
                        // moving the rest numbers to up
                        numbers[j] = numbers[j - 1];
                    }
                    numbers[i] = temp;
                }
            }

            string output = string.Join("", new List<int>(numbers).ConvertAll(i => i.ToString()).ToArray());
            return output;
        }
    }
}
