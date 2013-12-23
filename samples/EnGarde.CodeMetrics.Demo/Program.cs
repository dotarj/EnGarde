using System;
using System.Diagnostics.Contracts;
using System.Linq;

namespace EnGarde.CodeMetrics.Demo
{
    class Program
    {
        static void Main(string[] args)
        {
            NoArgumentValidation(1);
            EnGardeChainedNegatingArgumentValidation(1);
            EnGardeNonChainedNegatingArgumentValidation(1);
            EnGardeChainedNonNegatingArgumentValidation(1);
            EnGardeNonChainedNonNegatingArgumentValidation(1);
            ClassicArgumentValidationCombined(1);
            ClassicArgumentValidation(1);
            ContractValidation(1);

            Console.WriteLine(Benchmark.Run(() => EnGardeChainedNegatingArgumentValidation(1), 100000));
            Console.WriteLine(Benchmark.Run(() => EnGardeChainedNegatingArgumentValidation2(1), 100000));

            Console.ReadLine();
        }

        private static int NoArgumentValidation(int i)
        {
            return i;
        }

        private static int EnGardeChainedNegatingArgumentValidation(int i)
        {
            Argument.Assert(i, "i")
                .Not().IsLessThan(0)
                .Not().IsGreaterThan(2);

            return i;
        }

        private static int EnGardeChainedNegatingArgumentValidation2(int i)
        {
            Argument.Assert(() => i)
                .Not().IsLessThan(0)
                .Not().IsGreaterThan(2);

            return i;
        }

        private static int EnGardeNonChainedNegatingArgumentValidation(int i)
        {
            Argument.Assert(i, "i").Not().IsLessThan(0);
            Argument.Assert(i, "i").Not().IsGreaterThan(2);

            return i;
        }

        private static int EnGardeChainedNonNegatingArgumentValidation(int i)
        {
            Argument.Assert(i, "i")
                .IsGreaterThan(0)
                .IsLessThan(2);

            return i;
        }

        private static int EnGardeNonChainedNonNegatingArgumentValidation(int i)
        {
            Argument.Assert(i, "i").IsGreaterThan(0);
            Argument.Assert(i, "i").IsLessThan(2);

            return i;
        }

        private static int ClassicArgumentValidation(int i)
        {
            if (i > 2)
            {
                throw new ArgumentOutOfRangeException("i", i, "");
            }

            if (i < 0)
            {
                throw new ArgumentOutOfRangeException("i", i, "");
            }

            return i;
        }

        private static int ClassicArgumentValidationCombined(int i)
        {
            if (i < 0 || i > 2)
            {
                throw new ArgumentOutOfRangeException("i", i, "");
            }

            return i;
        }

        private static int ContractValidation(int i)
        {
            Contract.Requires<ArgumentOutOfRangeException>(i <= 2);
            Contract.Requires<ArgumentOutOfRangeException>(i >= 0);

            return i;
        }
    }
}
