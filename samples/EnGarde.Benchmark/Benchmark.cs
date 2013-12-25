using System;
using System.Diagnostics;

namespace EnGarde.Benchmark
{
    public static class Benchmark
    {
        public static TimeSpan Run(Action action, int iterations, bool shouldWarmup = true)
        {
            if (action == null)
            {
                throw new ArgumentNullException("action");
            }

            if (shouldWarmup)
            {
                action();
            }

            GC.Collect();
            GC.WaitForPendingFinalizers();

            // Clean up finalized objects as explained here: http://tech.pro/tutorial/1433/performance-benchmark-mistakes-part-four
            GC.Collect();

            var stopwatch = Stopwatch.StartNew();

            for (var i = 0; i < iterations; i++)
            {
                action();
            }

            stopwatch.Stop();

            return stopwatch.Elapsed;
        }
    }
}