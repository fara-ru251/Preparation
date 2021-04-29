using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JustFun.Models.Interviewbit
{
    public class FruitIntoBaskets
    {
        public int FindMaxLength(int[] tree)
        {
            int first_type = -1;
            int second_type = -1;

            int last_index_first = -1;
            int last_index_second = -1;
            int curr_size = 0;
            int max_size = int.MinValue;


            int i = 0;
            while (i < tree.Length)
            {
                if (second_type == -1)
                {
                    first_type = second_type;
                    second_type = tree[i];

                    while (i < tree.Length && second_type == tree[i])
                    {
                        curr_size++;
                        last_index_second = i;
                        i++;
                    }
                    //to prevent holes
                    i--;
                }
                else if (first_type == -1)
                {
                    first_type = tree[i];
                   
                    while (i < tree.Length && first_type == tree[i])
                    {
                        curr_size++;
                        last_index_first = i;
                        i++;
                    }
                    //to prevent holes
                    i--;
                }
                else //we have two assigned numbers
                {
                    //check for equality for both of them
                    if (second_type == tree[i])
                    {
                        curr_size++;
                        last_index_second = i;
                    }
                    else if (first_type == tree[i])
                    {
                        curr_size++;
                        last_index_first = i;
                    }
                    else // not equals for both of them
                    {
                        if (last_index_second > last_index_first)
                        {
                            curr_size = last_index_second - last_index_first + 1;
                            first_type = tree[i];
                            last_index_first = i;
                        }
                        else if (last_index_first > last_index_second)
                        {
                            curr_size = last_index_first - last_index_second + 1;
                            second_type = tree[i];
                            last_index_second = i;
                        }
                    }

                }

                max_size = Math.Max(max_size, curr_size);

                i++;
            }

            return max_size;
        }
    }
}
