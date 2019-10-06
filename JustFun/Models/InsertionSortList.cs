using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JustFun.Models
{
    public static class InsertionSortList
    {
        public static void DoSort(int[] arr)
        {
            int j = 0;
            for (int i = 0; i < arr.Length; i++)
            {
                int key = arr[i];
                j = i - 1;
                while (j >= 0 && arr[j] > key)
                {
                    arr[j + 1] = arr[j];
                    j--;
                }
                arr[j + 1] = key;
            }

            for (int i = 0; i < arr.Length; i++)
            {
                Console.Write(arr[i] + " ");
            }
            Console.WriteLine();
        }

        public static ListNode Do(ListNode head)
        {
            ListNode curr = head, next = null;
            ListNode rev_head = null, curr_rev = null, prev_rev = null;

            while (curr != null)
            {
                //detaching curr from the remaining part
                next = curr.Next;

                //safety mat' ego
                curr.Next = null;

                int key = curr.Value;



                curr_rev = rev_head;
                prev_rev = null;

                if (rev_head != null)
                {
                    if (rev_head.Value <= key)
                    {
                        rev_head = curr;
                    }
                }
                else
                {
                    rev_head = curr;
                }


                while (curr_rev != null && curr_rev.Value > key)
                {
                    prev_rev = curr_rev;
                    curr_rev = curr_rev.Next;
                }

                if (prev_rev != null)
                {
                    prev_rev.Next = curr;
                }

                curr.Next = curr_rev;


                curr = next;
            }

            ListNode prev = null;
            curr = rev_head;

            while (curr != null)
            {
                next = curr.Next;

                curr.Next = prev;

                prev = curr;

                curr = next;
            }

            return prev;
        }
    }
}
