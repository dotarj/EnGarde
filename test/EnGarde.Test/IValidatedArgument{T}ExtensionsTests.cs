// Copyright (c) Arjen Post. See License.txt in the project root for license information.

using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;

namespace EnGarde.Test
{
    [TestClass]
    public class IValidatedArgumentExtensionsTests
    {
        [TestClass]
        public class TheThatMethod
        {
            [TestMethod]
            public void ShouldNotThrowExceptionIfArgumentIsNotDefaultAndNotNullUsingExpression()
            {
                // Act
                TestUsingExpression(1, "");
            }

            private void TestUsingExpression(int i, string s)
            {
                Ensure
                    .That(() => i).Not.IsDefault()
                    .That(() => s).Not.IsNull();
            }

            [TestMethod, ExpectedException(typeof(ArgumentNullException))]
            public void ShouldThrowExceptionIfArgumentIsDefaultUsingExpression()
            {
                // Act
                TestUsingExpression(1, "");
                TestUsingExpression(1, null);
            }

            [TestMethod]
            public void ShouldNotThrowExceptionIfArgumentIsNotDefaultAndNotNull()
            {
                // Act
                Test(1, "");
            }

            private void Test(int i, string s)
            {
                Ensure
                    .That(i, "").Not.IsDefault().And.Not.IsEqualTo(int.MaxValue)
                    .That(s, "").Not.IsNull();
            }

            [TestMethod, ExpectedException(typeof(ArgumentNullException))]
            public void ShouldThrowExceptionIfArgumentIsDefault()
            {
                // Act
                Test(1, "");
                Test(1, null);
            }
        }
    }
}
