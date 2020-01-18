using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JustFun.Models
{
    public class MatchingStates
    {
        public DateTimeOffset[] times { get; set; }
        public bool[] inOut { get; set; }
        public int len { get; set; }

        public MatchingStates()
        {
            len = 4;
            times = new DateTimeOffset[len];
            inOut = new bool[len];
        }

        public void Resolve()
        {
            for (int i = 0; i < len; i++)
            {
                //inOut => true, but  Date Time Offset have default value
                if (inOut[i] && times[i] == default(DateTimeOffset))
                {
                    Console.WriteLine("no. "+ (i + 1) +  " element assigned" );

                    times[i] = DateTimeOffset.UtcNow; // assign value NOW
                }
                //inOut => false, but Date Time Offset other that default value
                else if (!inOut[i] && times[i] != default(DateTimeOffset))
                {
                    //TODO write to DB or smth else
                    //here to print to console
                    Console.WriteLine((i + 1) + " no. Start: " + times[i].ToString() + " End: " + DateTimeOffset.UtcNow);

                    //assign default value again
                    times[i] = default(DateTimeOffset);
                }
                //other cases not interesting
            }


            return;
        }

    }
}
