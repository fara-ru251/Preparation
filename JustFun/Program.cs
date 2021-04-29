using JustFun.Asynchrony.ProgressReporting;
using JustFun.Facade;
using JustFun.Facade.Interfaces;
using JustFun.Interfaces;
using JustFun.Leetcode;
using JustFun.Models;
using JustFun.Models.ACMP;
using JustFun.Models.CLRviaCSharpBook;
using JustFun.Models.CLRviaCSharpBook.Chapter10;
using JustFun.Models.CLRviaCSharpBook.Chapter11;
using JustFun.Models.CLRviaCSharpBook.Chapter12_Generics;
using JustFun.Models.CLRviaCSharpBook.Chapter15_BitFlags;
using JustFun.Models.CLRviaCSharpBook.Chapter5;
using JustFun.Models.Codeforces;
using JustFun.Models.Interviewbit;
using JustFun.Models.TestInterfacesApp;
using JustFun.SlidingWindow;
using JustFun.Sorting;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using System.Threading.Tasks;
using static JustFun.Models.DailyEventSchedule;
using GeneralNode = JustFun.Models.CLRviaCSharpBook.Chapter12_Generics.Node;

namespace JustFun
{
    class Program
    {
        //static int MaxN = int.MaxValue;
        static int MODULUS = 1000000007;

        static void Main(string[] args)
        {
            //int[] arr = Array.ConvertAll(Console.ReadLine().Split(' '), arTemp => int.Parse(arTemp));

            //[2,1,5,6,0,9,5,0,3,8]
            //4
            //3

            var no1031 = new No1031_MaximumSumOfTwoNonOverlappingSubarrays();

            var ans = no1031.MaxSumTwoNoOverlap(new int[] { 2, 1, 5, 6, 0, 9, 5, 0, 3, 8 }, 4, 3);

            Console.ReadKey();

            return;

            #region LList
            //int[] arr = new int[] { 1, 3, 2 };

            //ListNode head = null;
            //for (int i = 0; i < arr.Length; i++)
            //{
            //    head = LinkedListHelper.InsertNode(ref head, arr[i]);
            //}


            //head = InsertionSortList.Do(head);



            ////length of linked list
            //ListNode temp = head;


            //while (temp != null)
            //{
            //    Console.Write(temp.Value + "->");
            //    temp = temp.Next;
            //}

            //Console.WriteLine("NULL");

            //return;
            #endregion

            #region NewYearPresent

            ////int idx;

            //int n = Convert.ToInt32(Console.ReadLine());

            //int[] l = Array.ConvertAll(Console.ReadLine().Split(' '), lTemp => Convert.ToInt32(lTemp));

            //Array.Sort(l);

            //for (int i = 0; i < n; i++)
            //{
            //    dp1[l[i]]++;
            //}

            //for (int i = 0; i < n - 1; i++)
            //{
            //    for (int j = i + 1; j < n; j++)
            //    {
            //        dp2[l[i] + l[j]]++;
            //    }
            //}

            //for (int i = 0; i < dp2.Length; i++)
            //{
            //    Console.Write(dp2[i] + " ");
            //}
            #endregion

            #region NZ
            //List<int> A = new List<int>() { 1, 2 };
            //List<int> B = new List<int>() { 3, 4 };

            //var sum = Enumerable.Range(0, A.Count - 1)
            //                    .Sum((index) =>
            //                      {
            //                          return Math.Max(Math.Abs(A[index + 1] - A[index]), Math.Abs(B[index + 1] - B[index]));
            //                      }
            //                    );

            #endregion

            #region Kadane's algorithm
            //string s = "1";//"11001001111100";
            //int their_1s = 0;
            //int sum = 0;
            //int max_sum = int.MinValue;
            //int left = 0;
            //int l = -1;
            //int r = 0;


            //for (int i = 0; i < s.Length; i++)
            //{
            //    if (s[i] == '0')
            //    {
            //        sum++;
            //        if (sum > max_sum)
            //        {
            //            max_sum = sum;
            //            l = left;
            //            r = i;
            //        }
            //    }
            //    else
            //    {
            //        sum--;
            //        if (sum < 0)
            //        {
            //            left = i + 1;
            //        }

            //        sum = Math.Max(sum, 0);


            //    }
            //}



            //Console.WriteLine($"left : {l} | right : {r}");
            #endregion

        }



        static string ReverseParentheses(string str)
        {
            int begin = 0;
            int end = str.Length - 1;

            for (int i = 0; i < str.Length; i++)
            {
                //check for start of open parentheses
                if (str[i] == '(')
                {
                    begin = i;
                }

                //check for end parentheses
                if (str[i] == ')')
                {
                    end = i;

                    string substr = str.Substring(begin + 1, end - begin - 1);

                    var revstr = substr.Reverse();

                    return ReverseParentheses(str.Substring(0, begin) + string.Join("", revstr) + str.Substring(end + 1));
                }
            }


            return str;
        }

        static void BuildHero(int strength, int intellect, int experience)
        {
            int min = 0;
            int max = experience;

            while (min <= max)
            {
                int mid = min + (max - min) / 2; // (x + y) / 2

                if (strength + mid > intellect + (experience - mid))
                {
                    max = mid - 1;
                }
                else
                {
                    min = mid + 1;
                }
            }

            int ans = experience - max;

            Console.WriteLine(ans);
        }

        static ListNode KReverseLList(ListNode head, int k)
        {
            ListNode temp = head;
            int length = 0;

            while (temp != null)
            {
                length++;
                temp = temp.Next;
            }

            //temp = head;




            ListNode[] nodes = new ListNode[length / k + length % k]; //k = length / k;
            int i = 0;
            int j = 0;


            ListNode prev = null, curr = head, next = null;

            while (curr != null)
            {
                next = curr.Next;

                curr.Next = prev;

                prev = curr;

                curr = next;

                j++;
                if (j == k)
                {
                    if (i < nodes.Length)
                    {
                        nodes[i++] = prev;

                        prev = null;
                    }

                    j = 0;
                }
            }

            if (length % k != 0)
            {
                nodes[i] = prev;
                prev = null;
            }



            i = 0;
            while (i < nodes.Length - 1)
            {
                curr = nodes[i];
                while (curr.Next != null)
                {
                    curr = curr.Next;
                }


                curr.Next = nodes[i + 1];
                i++;
            }


            return nodes[0];
        }

        static void Shooting(int[] arr)
        {
            int[] idx = new int[arr.Length];



            for (int i = 0; i < arr.Length; i++)
            {
                idx[i] = i + 1;
            }

            Array.Sort(arr, idx);


            Array.Reverse(arr);
            Array.Reverse(idx);

            int sum = 0;
            for (int i = 0; i < arr.Length; i++)
            {
                sum = sum + (arr[i] * i + 1);
            }
            Console.WriteLine(sum);

            //for (int i = 0; i < arr.Length; i++)
            //{
            //    Console.Write(arr[i] + " ");

            //}
            //Console.WriteLine();
            for (int i = 0; i < arr.Length; i++)
            {
                Console.Write(idx[i] + " ");

            }
            Console.WriteLine();
        }

        static void WhitePaper(Point white, Point black1, Point black2)
        {
            // left-low corner
            if (!((white.x1 >= black1.x1 && white.x1 <= black1.x2)
                || (white.x1 >= black2.x1 && white.x1 <= black2.x2))) // by x
            {
                Console.WriteLine("YES");
                return;
            }
            if (!((white.y1 >= black1.y1 && white.y1 <= black1.y2)
                || (white.y1 >= black2.y1 && white.y1 <= black2.y2))) // by y
            {
                Console.WriteLine("YES");
                return;
            }

            // high-right corner
            if (!((white.x2 >= black1.x1 && white.x2 <= black1.x2)
                || (white.x2 >= black2.x1 && white.x2 <= black2.x2)))
            {
                Console.WriteLine("YES");
                return;
            }
            if (!((white.y2 >= black1.y1 && white.y2 <= black1.y2)
                || (white.y2 >= black2.y1 && white.y2 <= black2.y2)))
            {
                Console.WriteLine("YES");
                return;
            }


            // low-right corner
            if (!((white.x2 >= black1.x1 && white.x2 <= black1.x2)
                || (white.x2 >= black2.x1 && white.x2 <= black2.x2)))
            {
                Console.WriteLine("YES");
                return;
            }
            if (!((white.y1 >= black1.y1 && white.y1 <= black1.y2)
                || (white.y1 >= black2.y1 && white.y1 <= black2.y2)))
            {
                Console.WriteLine("YES");
                return;
            }



            // high-left corner
            if (!((white.x1 >= black1.x1 && white.x1 <= black1.x2)
                || (white.x1 >= black2.x1 && white.x1 <= black2.x2)))
            {
                Console.WriteLine("YES");
                return;
            }
            if (!((white.y2 >= black1.y1 && white.y2 <= black1.y2)
                || (white.y2 >= black2.y1 && white.y2 <= black2.y2)))
            {
                Console.WriteLine("YES");
                return;
            }

            Console.WriteLine("NO");
            return;
        }


        static void PrefixFunc(string str)
        {
            int cnt_a = 0;
            int cnt_b = 0;
            char[] char_arr = new char[str.Length];
            int op_cnt = 0;

            for (int i = 0; i < str.Length; i++)
            {
                if (str[i] == 'a')
                {
                    cnt_a++;
                }
                else
                {
                    cnt_b++;
                }

                char_arr[i] = str[i];

                if (i % 2 != 0)
                {
                    if (cnt_a > cnt_b)
                    {
                        char_arr[i] = 'b';
                        cnt_a--;
                        cnt_b++;
                        op_cnt++;
                    }
                    else if (cnt_a < cnt_b)
                    {
                        char_arr[i] = 'a';
                        cnt_a++;
                        cnt_b--;
                        op_cnt++;
                    }
                    else
                    {
                        continue;
                    }
                }
            }


            Console.WriteLine(op_cnt);

            Console.WriteLine(new string(char_arr));


        }

        static ListNode ReverseListII(ListNode head, int m, int n)
        {

            ListNode prev = null, curr = head, next = null;

            m--;
            n--;
            int counter = 0;
            ListNode first_part = null;

            ListNode middle_part_start = null, third_part = null, middle_part_end = null;




            while (curr != null)
            {
                if (counter >= m && counter <= n)
                {
                    if (counter == m)
                    {
                        middle_part_end = curr;
                    }

                    next = curr.Next;

                    curr.Next = prev;

                    prev = curr;

                    curr = next;
                }
                else
                {
                    if (counter < m)
                    {
                        first_part = curr;
                    }
                    else if (counter > n)
                    {
                        third_part = curr;
                        break;
                    }

                    curr = curr.Next;
                }

                counter++;
            }
            middle_part_start = prev;


            if (first_part != null)
            {
                first_part.Next = middle_part_start;
            }

            if (third_part != null)
            {
                middle_part_end.Next = third_part;
            }

            if (m > 0)
            {
                return head;
            }
            else
            {
                return middle_part_start;
            }



            //return first_part ?? middle_part_start;
        }

        static ListNode rotateRight(ListNode head, int number)
        {
            ListNode temp = head, prev = null;

            int length = 0;
            while (temp != null)
            {
                length++;

                prev = temp;
                temp = temp.Next;
            }


            temp = head;
            prev.Next = head;

            int remainder = number % length;

            length -= remainder;

            int i = 0;
            while (++i < length)
            {
                temp = temp.Next;
            }

            head = temp.Next;
            temp.Next = null;

            return head;
        }

        static int Palindrome(int n)
        {
            long cnt = 0;
            long x = 9;
            int x_cnt = 1;


            for (int i = 1; i <= n; i++)
            {
                cnt = x + cnt;
                cnt = cnt % MODULUS;

                if (i % 2 == 0)
                {
                    x = (x * 10) % MODULUS;
                    x_cnt++;
                }
            }


            return (int)cnt % MODULUS;
        }

        static int CountEqualsFive(long n)
        {
            int num_cnt = 0;

            double oneFourth = Math.Pow(n, ((double)1 / 4));

            for (long i = 2; i <= (long)oneFourth; i++)
            {
                if (isPrime(i))
                {
                    if (Math.Pow(i, 4) <= n)
                    {
                        num_cnt++;
                    }
                    //Console.Write(i + " ");
                }




            }

            return num_cnt;
        }

        static bool isPrime(long n)
        {
            // Corner cases 
            if (n <= 3) return true;

            // This is checked so that we  
            // can skip middle five numbers 
            // in below loop 
            if (n % 2 == 0 || n % 3 == 0) return false;

            for (long i = 5; i * i <= n; i = i + 6)
                if (n % i == 0 || n % (i + 2) == 0)
                    return false;

            return true;
        }

        static ListNode ReverseLinkedList(ListNode head)
        {
            //prev,curr,next

            ListNode prev = null, curr = head, next = null;

            while (curr.Next != null)
            {
                next = curr.Next;

                curr.Next = prev;

                prev = curr;

                curr = next;

            }
            head = prev;

            return head;
        }

        static ListNode DeleteDuplicatesII(ListNode head)
        {
            ListNode curr = head.Next, prev = head, last = null;
            int dup_count = 0;
            bool first_time = true;

            while (curr != null)
            {
                if (curr.Value != prev.Value)
                {
                    if (dup_count < 1)
                    {
                        last = prev;



                        if (first_time)
                        {
                            head = last;
                            first_time = false;
                        }
                    }
                    else
                    {
                        if (last != null)
                        {
                            last.Next = curr;
                        }
                        dup_count = 0;
                    }
                }
                else
                {
                    dup_count++;
                }

                prev = curr;
                curr = curr.Next;
            }


            if (last == null && dup_count == 0)
            {
                last = prev;
                return last;
            }
            else if (last == null && dup_count > 0)
            {
                return null;
            }
            else if (last != null && dup_count > 0)
            {
                last.Next = null;
            }



            //if (dup_count > 0)
            //{
            //    last = last.Next;

            //    if (last.Value == prev.Value)
            //    {
            //        last.Next = null;
            //    }
            //}


            return head;
        }

        static ListNode DeleteDuplicates(ListNode head)
        {
            ListNode curr = head.Next, prev = head;


            while (curr != null)
            {
                if (prev.Value == curr.Value)
                {
                    curr = curr.Next;
                    prev.Next = curr;
                }
                else
                {
                    prev = curr;
                    curr = curr.Next;
                }
            }

            return head;
        }


        static void TraverseLinkedList(ListNode head)
        {
            while (head != null)
            {
                Console.Write($"{head.Value}->");
                head = head.Next;
            }

            Console.WriteLine("NULL");
        }

        static int CompareLinkedLists(ListNode first_head, ListNode second_head)
        {
            int ans = 1;

            while (first_head != null && second_head != null)
            {
                if (first_head.Value != second_head.Value)
                {
                    ans = 0;
                    return ans;
                }
                first_head = first_head.Next;
                second_head = second_head.Next;
            }
            return ans;
        }

        static int UniqueGridPaths(int n, int m)
        {
            int val = 1;
            int k = n + m - 2;


            int need_val = n >= m ? n : m;

            for (int j = 0; j <= k; j++)
            {


                if (k == 0 || j == 0)
                {
                    val = 1;
                }
                else
                {
                    val = val * (k - j + 1) / j;
                }
                //if (j == k - need_val + 1)
                //{
                //    Console.Write(val + " ");
                //}
            }

            return val;
        }

        static int HammingDistance(List<int> A)
        {
            int max = int.MinValue;

            for (int i = 0; i < A.Count; i++)
            {
                max = Math.Max(A[i], max);
            }

            int ans = 0;

            //32-bits only
            int j = 0;
            long ones = 0;
            while (max != 0)
            {
                j = 0;
                while (j < A.Count)
                {
                    ones += (A[j] & 1);
                    A[j] = A[j] >> 1;
                    j++;
                }
                ans += (int)((2 * ones * ((long)j - ones)) % 1000000007L);
                ones = 0;
                max = max >> 1;
            }


            return ans;
        }

        static int DivideIntegers(int dividend, int divisor)
        {
            //only one edge case
            if (dividend == int.MinValue && divisor == -1)
            {
                return int.MaxValue;
            }


            //True ^ True = False => 1 || True ^ False = False => -1
            int sign = ((dividend < 0) ^ (divisor < 0)) ? -1 : 1;

            long a = Math.Abs((long)dividend);
            long b = Math.Abs((long)divisor);

            int quotient = 0;


            while (a - b >= 0)
            {
                int temp = 0; // 2^0 = 1
                while (a - (b << 1 << temp) >= 0)
                {
                    temp++;
                }
                quotient += (1 << temp);
                a -= (b << temp);
            }



            return sign * quotient;
        }

        static bool isPowerOfTwo(int x)
        {
            return (x != 0) && ((x & (x - 1)) == 0);
        }


        static uint ReverseBits(uint A)
        {
            int pos = (sizeof(int) * 8 - 1);

            uint reverse = 0;

            while (pos >= 0 && A != 0)
            {
                if ((A & 1) != 0)
                {
                    reverse = reverse | (uint)(1 << pos);
                }

                A = A >> 1;
                pos--;
            }

            return reverse;
        }

        static int BinarySearch(List<int> arr, int key)
        {
            int min = 0;
            int max = arr.Count - 1;

            while (min <= max)
            {
                int mid = (min + max) / 2;


                if (arr[mid] < key)
                {
                    min = mid + 1;
                }
                else
                {
                    if (arr[mid] == key)
                    {
                        return ++mid;
                    }

                    max = mid - 1;
                }
            }
            return min;
        }

        static long FactorLCM(int[] arr)
        {
            int max_num = 0;
            for (int i = 0; i < arr.Length; i++)
            {
                max_num = Math.Max(max_num, arr[i]);
            }


            long res = 1;

            int x = 2;

            while (x <= max_num)
            {
                List<int> indexes = new List<int>();
                for (int j = 0; j < arr.Length; j++)
                {
                    if (arr[j] % x == 0)
                    {
                        indexes.Add(j);
                    }
                }

                if (indexes.Count >= 2)
                {
                    for (int j = 0; j < indexes.Count; j++)
                    {
                        arr[indexes[j]] = arr[indexes[j]] / x;
                    }
                    res = (res * x);
                }
                else
                {
                    x++;
                }
            }

            for (int i = 0; i < arr.Length; i++)
            {
                res = (res * arr[i]);
            }

            return res % MODULUS;
        }

        static long stringoholics(List<string> A)
        {
            int[] interim_res = new int[A.Count];
            for (int i = 0; i < A.Count; i++)
            {
                interim_res[i] = computeLPS(A[i]);
            }

            int n = 1;

            for (int i = 0; i < interim_res.Length; i++)
            {
                while (((n * (n + 1)) / 2) % interim_res[i] != 0)
                {
                    n++;
                }
                interim_res[i] = n;
                n = 1;
            }

            //for (int i = 0; i < interim_res.Length; i++)
            //{
            //    Console.Write(interim_res[i] + " ");
            //}
            //Console.WriteLine();

            if (interim_res.Length == 1)
            {
                return interim_res[interim_res.Length - 1];
            }

            //int l = interim_res[0];
            //int r = interim_res[1];

            //int comm_res = lcm(l, r);

            //for (int i = 2; i < interim_res.Length; i++)
            //{
            //    comm_res = lcm(comm_res, interim_res[i]);
            //}

            //return comm_res % MODULUS;

            return FactorLCM(interim_res);
        }
        static int computeLPS(string A)
        {
            int[] lps = new int[A.Length];

            lps[0] = 0;

            int i = 1;
            int j = 0;
            while (i < A.Length)
            {
                if (A[i] == A[j])
                {
                    lps[i] = ++j;
                    i++;
                }
                else
                {
                    if (j != 0)
                    {
                        j = lps[j - 1];
                    }
                    else
                    {
                        lps[i] = 0;
                        i++;
                    }
                }
            }


            int len = lps[lps.Length - 1];
            int str_len = lps.Length;

            if (len > 0 && str_len % (str_len - len) == 0)
            {
                return len;
            }

            return A.Length;
        }

        static int gcd(int A, int B)
        {
            int T;
            if (A < B)
            {
                T = A;
                A = B;
                B = T;
            }
            while (B != 0)
            {
                T = B;
                B = A % B;
                A = T;
            }
            return A;
        }
        static int lcm(int a, int b)
        {
            return (a * b) / gcd(a, b);
        }
    }
    class Point
    {
        public int x1 { get; set; }
        public int y1 { get; set; }
        public int x2 { get; set; }
        public int y2 { get; set; }
    }
    class Hero
    {
        public int strength { get; set; }
        public int intellect { get; set; }
        public int experience { get; set; }
    }
}

