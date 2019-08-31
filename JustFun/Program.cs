using JustFun.Models;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace JustFun
{
    class Program
    {
        //static int MaxN = int.MaxValue;
        static int MODULUS = 1000000007;

        static void Main(string[] args)
        {
            int dividend = -2147483648; //делимое
            int divisor = 1; //делитель

            //only one edge case
            if (dividend == int.MinValue && divisor == -1)
            {
                Console.WriteLine(int.MaxValue);
                return;
            }


            //True ^ True = False => 1 || True ^ False = False => -1
            int sign = ((dividend < 0) ^ (divisor < 0)) ? -1 : 1;

            long a = Math.Abs((long)dividend);
            long b = Math.Abs((long)divisor);

            //Console.WriteLine((divisor << 31));


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



            Console.WriteLine(sign * quotient);
            return;


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

            #region HZ
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

        static int DivideIntegers()
        {

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

}

