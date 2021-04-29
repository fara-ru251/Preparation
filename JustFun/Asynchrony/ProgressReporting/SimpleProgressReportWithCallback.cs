using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JustFun.Asynchrony.ProgressReporting
{
    internal sealed class SimpleProgressReportWithCallback
    {
        public Task SomeLongRunningTask(Action<int> onProgressPercentChanged)
        {
            return Task.Run(() =>
            {
                for (int i = 0; i <= 1000; i++)
                {
                    if (i % 10 == 0)
                    {
                        onProgressPercentChanged(i / 10);
                    }
                    // som compute-bound action
                }
            });
        }
    }
}
