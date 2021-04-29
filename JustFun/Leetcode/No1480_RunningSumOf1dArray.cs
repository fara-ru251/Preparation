using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JustFun.Leetcode
{
    public class No1480_RunningSumOf1dArray
    {
        public int[] RunningSum(int[] nums)
        {
            for (int i = 1; i < nums.Length; i++)
            {
                nums[i] = nums[i] + nums[i - 1];
            }

            return nums;
        }
    }

    public class No1108_DefangingIPAddress
    {
        public string DefangIPAddr(string address)
        {
            StringBuilder sb = new StringBuilder();

            for (int i = 0; i < address.Length; i++)
            {
                if (address[i] != '.')
                {
                    sb.Append(address[i]);
                    continue;
                }

                sb.AppendFormat("[{0}]", address[i]);
            }

            return sb.ToString();
        }
    }

    public class No1672_RichestCustomerWealth
    {
        public int MaximumWealth(int[][] accounts)
        {
            int max_sum = 0;

            for (int i = 0; i < accounts.Length; i++)
            {
                var curr_customer = accounts[i];
                int sum = 0;
                for (int j = 0; j < curr_customer.Length; j++)
                {
                    sum = sum + curr_customer[j];
                }

                max_sum = Math.Max(max_sum, sum);
            }

            return max_sum;
        }
    }

    public class No1470_ShuffleTheArray
    {
        public int[] Shuffle(int[] nums, int n)
        {
            int[] ans = new int[nums.Length];
            int firstPart = 0;
            int secondPart = nums.Length / 2;
            int k = 0;


            for (int i = 0; i < nums.Length / 2; i++)
            {
                ans[k++] = nums[firstPart + i];
                ans[k++] = nums[secondPart + i];
            }

            return ans;
        }
    }

    public class No1512_NumberOfGoodPairs
    {
        public int NumIdenticalPairs(int[] nums)
        {
            Dictionary<int, (int count, int result)> dc = new Dictionary<int, (int count, int result)>();

            for (int i = 0; i < nums.Length; i++)
            {
                if (!dc.ContainsKey(nums[i]))
                {
                    dc.Add(nums[i], (1, 0));

                    continue;
                }

                dc[nums[i]] = (dc[nums[i]].count + 1, dc[nums[i]].result + dc[nums[i]].count);
            }

            int result = 0;
            foreach (var key in dc.Keys)
            {
                result += dc[key].result;
            }

            return result;
        }
    }

    public class No1313_DecompressRunLengthEncodedList
    {
        public int[] DecompressRLElist(int[] nums)
        {
            List<int> decompress_list = new List<int>();
            for (int i = 0; i < nums.Length; i += 2)
            {
                decompress_list.AddRange(Enumerable.Repeat(nums[i + 1], nums[i]));
            }

            return decompress_list.ToArray();
        }
    }

    public class No1389_CreateTargetArrayInTheGivenOrder
    {
        public int[] CreateTargetArray(int[] nums, int[] index)
        {
            int[] result = new int[nums.Length];
            bool isAscending = true;
            for (int i = 0, j = 0; i < nums.Length && j < index.Length; i++, j++)
            {
                if (j == 0)
                {
                    result[index[j]] = nums[i];

                    if (index[j] > 0)
                    {
                        isAscending = false;
                    }
                    continue;
                }

                if (isAscending && j > 0 && index[j] > index[j - 1])
                {
                    result[index[j]] = nums[i];

                    continue;
                }

                isAscending = false;
                int k = nums.Length - 1;
                while (k > index[j])
                {
                    result[k] = result[k - 1];
                    k--;
                }
                result[k] = nums[i];
            }

            return result;
        }
    }

    public class No1588_SumOfAllOddLengthSubarrays
    {
        public int SumOddLengthSubarrays(int[] arr)
        {
            int overall_sum = 0, curr_sum = 0;

            for (int i = 0; i < arr.Length; i++)
            {

                for (int j = 1; i + j - 1 < arr.Length; j += 2)
                {
                    int k = i;
                    while (k - i < j)
                    {
                        curr_sum += arr[k];
                        k++;
                    }
                }

                overall_sum += curr_sum;
                curr_sum = 0;
            }

            return overall_sum;
        }
    }

    public class No1769_MinimumNumberOfOperationsToMoveAllBallsToEachBox
    {
        public int[] MinOperations(string boxes)
        {
            int left = 0, right = 0;

            int initial_sum = 0; // 0 -index sum
            int[] answer = new int[boxes.Length];

            if (boxes[0] == '1')
            {
                left += 1;
            }

            for (int i = 1; i < boxes.Length; i++)
            {
                if (boxes[i] == '1')
                {
                    initial_sum += i;
                    right++;
                }
            }

            answer[0] = initial_sum;


            for (int i = 1; i < boxes.Length; i++)
            {
                answer[i] = initial_sum - right + left;
                if (boxes[i] == '1')
                {
                    right--;
                    left++;
                }
            }

            return answer;

        }

    }

    public class No1329_SortTheMatrixDiagonally
    {
        public int[][] DiagonalSort(int[][] mat)
        {
            (int row, int col)[] arr = new (int row, int col)[mat.Length + mat[0].Length - 1];

            int k = 0;
            for (int i = mat.Length - 1; i >= 0; i--)
            {
                arr[k++] = (i, 0);
            }

            for (int i = 1; i < mat[0].Length; i++)
            {
                arr[k++] = (0, i);
            }

            int row = mat.Length;
            int col = mat[0].Length;

            k = 0;
            for (int i = 0; i < arr.Length; i++)
            {
                var diagonal = arr[i];
                var c_row = diagonal.row;
                var c_col = diagonal.col;
                List<int> list = new List<int>();
                while (c_row < row && c_col < col)
                {
                    list.Add(mat[c_row][c_col]);
                    c_row++;
                    c_col++;
                }
                list.Sort();
                c_row = diagonal.row;
                c_col = diagonal.col;
                int m = 0;
                while (c_row < row && c_col < col)
                {
                    mat[c_row][c_col] = list[m++];
                    c_row++;
                    c_col++;
                }
            }

            return mat;
        }
    }
    public class No1395_CountNumberOfTeams
    {
        public int NumTeams(int[] rating)
        {
            int valid_teams = 0;
            int[] greater = new int[rating.Length];
            int[] less = new int[rating.Length];

            for (int i = 0; i < rating.Length; i++)
            {
                int curr_greater = 0;
                int curr_less = 0;
                for (int j = i + 1; j < rating.Length; j++)
                {
                    if (rating[i] < rating[j])
                    {
                        curr_greater++;
                    }
                    else if (rating[i] > rating[j])
                    {
                        curr_less++;
                    }
                }
                greater[i] = curr_greater;
                less[i] = curr_less;
            }

            for (int i = 0; i < rating.Length - 2; i++)
            {
                for (int j = i + 1; j < rating.Length - 1; j++)
                {
                    if (rating[i] < rating[j] && greater[j] > 0)
                    {
                        valid_teams += greater[j];
                    }
                    else if (rating[i] > rating[j] && less[j] > 0)
                    {
                        valid_teams += less[j];
                    }
                }
            }

            return valid_teams;
        }

    }
    public class No1277_CountSquareSubmatricesWithAllOnes
    {
        public int CountSquares(int[][] matrix)
        {
            int count_square_mtx = 0;


            for (int i = 0; i < matrix.Length; i++)
            {
                for (int j = 0; j < matrix[i].Length; j++)
                {
                    if (matrix[i][j] > 0 && i != 0 && j != 0)
                    {
                        matrix[i][j] = Math.Min(matrix[i - 1][j - 1], Math.Min(matrix[i - 1][j], matrix[i][j - 1])) + 1;
                    }

                    count_square_mtx += matrix[i][j];
                }
            }
            return count_square_mtx;
        }
    }

    public class No1823_FindTheWinnerOfTheCircularGame
    {
        public int FindTheWinner(int n, int k)
        {
            int[] friends = new int[n];
            for (int i = 0; i < n; i++)
            {
                friends[i] = i + 1;
            }

            int start = 0;
            int pos = 0;
            while (n > 1)
            {


                while (start < k)
                {
                    if (pos == friends.Length)
                    {
                        pos = 0;
                    }

                    for (int i = pos; i < friends.Length && start < k; i++, pos++)
                    {
                        if (friends[i] != -1)
                        {
                            start++;
                        }
                    }

                    if (start == k)
                    {
                        friends[pos - 1] = -1;
                    }
                }

                start = 0;

                n--;
            }

            for (int i = 0; i < friends.Length; i++)
            {
                if (friends[i] != -1)
                {
                    return friends[i];
                }
            }

            throw new InvalidOperationException($"One element must left in array {nameof(friends)}");
        }
    }


    public class No39_CombinationSum
    {
        public IList<IList<int>> CombinationSum(int[] candidates, int target)
        {
            IList<IList<int>> all_part = new List<IList<int>>();
            var curr_part = new List<int>();
            int initial_index = 0;
            int initial_sum = 0;

            Backtrack(initial_index, candidates, all_part, curr_part, initial_sum, target);

            return all_part;
        }

        private void Backtrack(int index, int[] candidates, IList<IList<int>> all_part, List<int> curr_part, int sum, int target)
        {
            if (sum == target)
            {
                all_part.Add(new List<int>(curr_part));
                return;
            }

            for (int i = index; i < candidates.Length; i++)
            {
                sum += candidates[i];
                if (sum <= target)
                {
                    curr_part.Add(candidates[i]);
                    Backtrack(i, candidates, all_part, curr_part, sum, target);
                    curr_part.Remove(candidates[i]);
                }

                sum -= candidates[i];
            }
        }
    }

    public class No1442_CountTripletsThatCanFormTwoArraysOfEqualXOR
    {
        public int CountTriplets(int[] arr)
        {
            int triplet_num = 0;
            int window = 0;
            for (int i = 0; i < arr.Length; i++)
            {
                for (int j = i; j < arr.Length; j++)
                {
                    window = window ^ arr[j];
                    if (window == 0)
                    {
                        triplet_num += j - i;
                    }
                }

                window = 0;
            }

            return triplet_num;
        }
    }

    public class No1806_MinimumNumberOfOperationsToReinitializePermutation
    {
        public int ReinitializePermutation(int n)
        {
            int mid = n / 2;
            int index = mid; //last position where we need "be"

            if (index % 2 == 0)
            {
                index = index / 2;
            }
            else
            {
                index = mid + (index - 1) / 2;
            }

            int permutation_num = 1;
            while (index != mid)
            {
                if (index % 2 == 0)
                {
                    index /= 2;
                }
                else
                {
                    index = mid + (index - 1) / 2;
                }
                permutation_num++;
            }

            return permutation_num;
        }
    }

    public class No1031_MaximumSumOfTwoNonOverlappingSubarrays
    {
        public int MaxSumTwoNoOverlap(int[] arr, int L, int M)
        {
            //TODO
            return 0;
        }
    }
}
