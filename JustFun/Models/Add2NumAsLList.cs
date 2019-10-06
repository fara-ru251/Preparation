using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JustFun.Models
{
    public static class Add2NumAsLList
    {
        public static ListNode Go(ListNode first, ListNode second)
        {
            int carry = 0;
            ListNode ftemp = first, stemp = second;
            //int ans = 0;
            //ListNode ans = null;

            while (ftemp != null && stemp != null)
            {
                //ans = ans * 10 + ((ftemp.Value + stemp.Value) % 10) + carry;
                int x = ftemp.Value + stemp.Value + carry;
                
                ftemp.Value = (x % 10);
                carry = x / 10;

                if (ftemp.Next == null && stemp.Next == null)
                {
                    if (carry != 0)
                    {
                        ftemp.Next = new ListNode(carry);
                    }
                }
                else if (ftemp.Next != null && stemp.Next == null)
                {
                    ftemp = ftemp.Next;
                    while (ftemp != null)
                    {
                        int val = ftemp.Value + carry;
                        ftemp.Value = val % 10;
                        carry = val / 10;
                        if (ftemp.Next == null && carry != 0)
                        {
                            ftemp.Next = new ListNode(carry);
                            break;
                        }
                        ftemp = ftemp.Next;

                        
                    }

                    //ftemp.Next.Value = ftemp.Next.Value + carry;
                    break;
                }
                else if (ftemp.Next == null && stemp.Next != null)
                {
                    ftemp.Next = stemp.Next;
                    stemp = stemp.Next;
                    while (stemp != null)
                    {
                        int val = stemp.Value + carry;
                        stemp.Value = val % 10;
                        carry = val / 10;

                        if (stemp.Next == null && carry != 0)
                        {
                            stemp.Next = new ListNode(carry);
                            break;
                        }
                        stemp = stemp.Next;

                        
                    }

                    //ftemp.Next = stemp.Next;
                    //stemp.Next.Value = stemp.Next.Value + carry;
                    break;
                }


                ftemp = ftemp.Next;
                stemp = stemp.Next;
            }


            return first;
        }
    }
}
