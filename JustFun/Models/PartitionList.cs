using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JustFun.Models
{
    public static class PartitionList
    {
        public static ListNode Go(ListNode head, int x)
        {
            ListNode less = null, more = null, temp = head;
            ListNode less_start = null, more_start = null;
            bool isLessHead = true, isMoreHead = true;

            while (temp != null)
            {
                if (temp.Value < x)
                {
                    if (less != null)
                    {
                        less = less.Next = temp;
                    }
                    else
                    {
                        less = temp;
                    }

                    


                    if (isLessHead)
                    {
                        less_start = less;
                        isLessHead = false;
                    }

                    //less = less.Next = null;
                }
                else
                {
                    if (more != null)
                    {
                        more = more.Next = temp;
                    }
                    else
                    {
                        more = temp;
                    }

                    

                    if (isMoreHead)
                    {
                        more_start = more;
                        isMoreHead = false;
                    }
                    //more = more.Next = null;
                }


                temp = temp.Next;
            }

            if (less != null)
            {
                less.Next = null;

                if (more != null)
                {
                    more.Next = null;
                }


                temp = less_start;

                while (temp.Next != null)
                {
                    temp = temp.Next;
                }
                temp.Next = more_start;

                return less_start;
            }
            else
            {
                return more_start;
            }
            
           

            
        }
    }
}
