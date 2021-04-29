using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JustFun.Asynchrony.ProgressReporting
{
    internal sealed class AdvancedProgressReporting
    {
        public Task SomeAction(IProgress<int> progress)
        {
            return Task.Run(() => 
            {
                for (int i = 0; i <= 1000; i++)
                {
                    if (i % 10 == 0)
                    {
                        progress.Report(i / 10);
                    }
                    // some other compute-bound things...
                }
            });
        }

    }
}
