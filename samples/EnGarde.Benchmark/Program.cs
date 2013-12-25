using System;

namespace EnGarde.Benchmark
{
    class Program
    {
        static void Main(string[] args)
        {
            var iterations = 10000;

            Console.WriteLine(string.Format("{0} iterations:", iterations));

            Console.WriteLine();

            Console.WriteLine(string.Format("Assert:                                  {0} ms", Benchmark.Run(() => Assert(1), iterations).TotalMilliseconds));
            Console.WriteLine(string.Format("AssertUsingExpressionWithoutCompilation: {0} ms", Benchmark.Run(() => AssertUsingExpressionWithoutCompilation(1), iterations).TotalMilliseconds));
            Console.WriteLine(string.Format("AssertUsingFieldInfoReader:              {0} ms", Benchmark.Run(() => AssertUsingFieldInfoReader(1), iterations).TotalMilliseconds));
            Console.WriteLine(string.Format("AssertUsingExpressionCompilation:        {0} ms", Benchmark.Run(() => AssertUsingExpressionCompilation(1), iterations).TotalMilliseconds));

            Console.ReadLine();
        }
        
        private static int Assert(int i)
        {
            EnGarde.Benchmark.Argument.Assert(i, "i")
                .Not().IsLessThan(0)
                .Not().IsGreaterThan(2);

            return i;
        }

        private static int AssertUsingExpressionWithoutCompilation(int i)
        {
            EnGarde.Benchmark.Argument.AssertUsingExpressionWithoutCompilation(() => i)
                .Not().IsLessThan(0)
                .Not().IsGreaterThan(2);

            return i;
        }

        private static int AssertUsingFieldInfoReader(int i)
        {
            EnGarde.Benchmark.Argument.AssertUsingFieldInfoReader(() => i)
                .Not().IsLessThan(0)
                .Not().IsGreaterThan(2);

            return i;
        }

        private static int AssertUsingExpressionCompilation(int i)
        {
            EnGarde.Benchmark.Argument.AssertUsingExpressionCompilation(() => i)
                .Not().IsLessThan(0)
                .Not().IsGreaterThan(2);

            return i;
        }
    }
}
