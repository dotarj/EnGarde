// Copyright (c) Arjen Post. See License.txt in the project root for license information.

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

            Console.WriteLine(string.Format("Assert:                                  {0} ms (average)", Benchmark.Run(() => Assert(1), iterations).TotalMilliseconds / iterations));
            Console.WriteLine(string.Format("AssertUsingExpressionWithoutCompilation: {0} ms (average)", Benchmark.Run(() => AssertUsingExpressionWithoutCompilation(1), iterations).TotalMilliseconds / iterations));
            Console.WriteLine(string.Format("AssertUsingFieldInfoReader:              {0} ms (average)", Benchmark.Run(() => AssertUsingFieldInfoReader(1), iterations).TotalMilliseconds / iterations));
            Console.WriteLine(string.Format("AssertUsingExpressionCompilation:        {0} ms (average)", Benchmark.Run(() => AssertUsingExpressionCompilation(1), iterations).TotalMilliseconds / iterations));

            Console.WriteLine();

            Console.WriteLine("Done!");

            Console.ReadLine();
        }
        
        private static int Assert(int i)
        {
            EnGarde.Benchmark.Argument.Assert(i, "i")
                .Not.IsLessThan(0).And.Not.IsGreaterThan(2);

            return i;
        }

        private static int AssertUsingExpressionWithoutCompilation(int i)
        {
            EnGarde.Benchmark.Argument.AssertUsingExpressionWithoutCompilation(() => i)
                .Not.IsLessThan(0).And.Not.IsGreaterThan(2);

            return i;
        }

        private static int AssertUsingFieldInfoReader(int i)
        {
            EnGarde.Benchmark.Argument.AssertUsingFieldInfoReader(() => i)
                .Not.IsLessThan(0).And.Not.IsGreaterThan(2);

            return i;
        }

        private static int AssertUsingExpressionCompilation(int i)
        {
            EnGarde.Benchmark.Argument.AssertUsingExpressionCompilation(() => i)
                .Not.IsLessThan(0).And.Not.IsGreaterThan(2);

            return i;
        }
    }
}
