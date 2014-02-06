// Copyright (c) Arjen Post. See License.txt in the project root for license information.

using System;
using System.Diagnostics.Contracts;
using System.Linq;

namespace EnGarde.CodeMetrics.Demo
{
    class Program
    {
        static void Main(string[] args)
        {
            NoArgumentValidation(1, "a");
            EnGardeArgumentValidation(1, "a");
            EnGardeArgumentValidationExpression(1, "a");
            ClassicArgumentValidation(1, "a");
            ContractArgumentValidation(1, "a");

            Console.ReadLine();
        }

        private static int NoArgumentValidation(int i, string s)
        {
            return i;
        }

private static int EnGardeArgumentValidation(int i, string s)
{
    Ensure
        .That(i, "i").Not.IsLessThan(0).And.Not.IsGreaterThan(2)
        .That(s, "s").Not.IsNullOrEmpty();

    return i;
}

private static int EnGardeArgumentValidationExpression(int i, string s)
{
    Ensure
        .That(() => i).Not.IsLessThan(0).And.Not.IsGreaterThan(2)
        .That(() => s).Not.IsNullOrEmpty();

    return i;
}

        private static int ClassicArgumentValidation(int i, string s)
        {
            if (i < 0 || i > 2)
            {
                throw new ArgumentOutOfRangeException("i", i, "");
            }

            if (s == null)
            {
                throw new ArgumentNullException("s");
            }

            if (s == string.Empty)
            {
                throw new ArgumentException("s");
            }

            return i;
        }

        private static int ContractArgumentValidation(int i, string s)
        {
            Contract.Requires<ArgumentOutOfRangeException>(i <= 2 || i >= 0);
            Contract.Requires<ArgumentNullException>(s != null);
            Contract.Requires<ArgumentException>(s != string.Empty);

            return i;
        }
    }
}