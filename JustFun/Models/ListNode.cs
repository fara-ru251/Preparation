using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JustFun.Models
{
    public class ListNode
    {
        public ListNode(int value)
        {
            this.Value = value;
            this.Next = default(ListNode);
        }

        public int Value { get; set; }
        public ListNode Next { get; set; }
    }

    public static class LinkedListHelper
    {
        public static ListNode InsertNode(ref ListNode node, int value)
        {
            ListNode new_node = new ListNode(value);

            if (node == null)
            {
                return new_node;
            }
            else
            {
                ListNode temp = node;

                while (temp.Next != null)
                {
                    temp = temp.Next;
                }

                temp.Next = new_node;
                return node;
            }
        }

        public static ListNode MergeTwoLists(ListNode first, ListNode second)
        {
            ListNode first_mover = first, second_mover = second;
            ListNode prev1 = first_mover, prev2 = second_mover;

            while (first_mover != null && second_mover != null)
            {
                while (first_mover != null && first_mover.Value <= second_mover.Value)
                {
                    prev1 = first_mover;
                    first_mover = first_mover.Next;
                }

                if (prev1.Value <= second_mover.Value)
                {
                    prev1.Next = second_mover;
                }
                
                if (first_mover == null)
                {
                    break;
                }



                while (second_mover != null && second_mover.Value <= first_mover.Value)
                {
                    prev2 = second_mover;
                    second_mover = second_mover.Next;
                }

                if (prev2.Value <= first_mover.Value)
                {
                    prev2.Next = first_mover;
                }

                if (second_mover == null)
                {
                    break;
                }
            }


            return first.Value <= second.Value ? first : second;
        }

        public static ListNode RmNthNode(ListNode head, int n)
        {
            int length = 0;
            ListNode temp = head;

            while (temp != null)
            {
                length++;

                temp = temp.Next;
            }

            temp = head;
            length = Math.Max(length - n, 0);
            ListNode curr = head, prev = null;

            while (temp != null)
            {
                if (length == 0)
                {
                    if (prev == null)
                    {
                        head = temp.Next;
                        break;
                    }

                    prev.Next = temp.Next;
                    break;
                }



                length--;
                prev = temp;
                temp = temp.Next;
            }



            return head;

        }
    }


}
