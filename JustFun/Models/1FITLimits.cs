using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JustFun.Models
{
    public class _1FITLimits
    {
        private bool _isVisited { get; set; }
        public int _trainingCount { get; private set; } // m
        public int _fitnessesCount { get; private set; } // n
        public int _sportTypesCount { get; private set; } // k

        public Training[] _trainings { get; set; }

        public _1FITLimits(int trainingLen, int fitnessCount, int sportTypeCount)
        {
            this._fitnessesCount = fitnessCount;
            this._trainingCount = trainingLen;
            this._sportTypesCount = sportTypeCount;
            this._trainings = new Training[_trainingCount];
        }


        public int _rulesCount { get; set; }

        public Rules[] _rules { get; set; }

        public int _queryCount { get; set; }

        public int[] _queries { get; set; }

        #region Internal Classes
        public class Training
        {
            public int _fitnessID { get; private set; }
            public int _sportTypeID { get; private set; }
            public bool _visited { get; private set; }

            public Training(int fitnessID, int sportTypeID)
            {
                this._fitnessID = fitnessID;
                this._sportTypeID = sportTypeID;
                this._visited = false;
            }

            public void SetVisited()
            {
                if (!this._visited)
                {
                    this._visited = true;
                }
            }



        }

        public class Rules
        {
            public int _fitnessID { get; private set; }
            //TODO
            public HashSet<int> _sportTypesID { get; private set; }
            public int _limit { get; set; }
        }

        #endregion


        public void Solve()
        {
            int i = 0;

            while (i < _queryCount)
            {
                var fitID = _trainings[_queries[i] - 1]._fitnessID;

                var sportID = _trainings[_queries[i] - 1]._sportTypeID;

                if (_trainings[_queries[i] - 1]._visited)
                {
                    Console.WriteLine("no");
                    i++;
                    continue;
                }
                else
                {
                    _trainings[_queries[i] - 1].SetVisited();
                }

                for (int j = 0; j < _rulesCount; j++)
                {
                    if (fitID == _rules[j]._fitnessID && _rules[j]._sportTypesID.Contains(sportID))
                    {
                        if (_rules[j]._limit == -1)
                        {
                            _isVisited = true;
                            Console.WriteLine("yes");
                            break;
                        }
                        else if (_rules[j]._limit > 0)
                        {
                            _isVisited = true;
                            Console.WriteLine("yes");
                            _rules[j]._limit--;
                            break;
                        }
                        else
                        {
                            Console.WriteLine("no");
                            break;
                        }
                    }
                }

                if (!_isVisited)
                {
                    Console.WriteLine("no");

                }
                _isVisited = false;
                i++;
            }
        }



        public static List<int> SearchRange(List<int> arr, int target)
        {
            int len = arr.Count;
            int min = 0, max = len - 1, mid;

            List<int> ans = new List<int>() { -1, -1 };

            while (min < max)
            {
                mid = min + (max - min) / 2;

                if (arr[mid] < target)
                {
                    min = mid + 1;
                }
                else
                {
                    max = mid;
                }
            }

            if (arr[min] != target)
            {
                return ans;
            }

            ans[0] = min;


            max = len - 1; // no need to set "min" to 0

            while (min < max)
            {
                mid = min + (max - min) / 2 + 1;

                if (arr[mid] > target)
                {
                    max = mid - 1;
                }
                else
                {
                    min = mid;
                }
            }
            ans[1] = max;

            return ans;
        }
    }
}
