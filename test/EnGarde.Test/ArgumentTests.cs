// Copyright (c) Arjen Post. See License.txt in the project root for license information.

using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace EnGarde.Test
{
    [TestClass]
    public class ArgumentTests
    {
        [TestClass]
        public class TheThatMethod
        {
            [TestMethod]
            public void ShouldNotThrowExceptionIfArgumentIsNotDefault()
            {
                // Act
                Test(1);
            }

            private void Test(int i)
            {
                Ensure.That(() => i).Not.IsDefault();
            }

            [TestMethod, ExpectedException(typeof(ArgumentException))]
            public void ShouldThrowExceptionIfArgumentIsDefault()
            {
                // Act
                Test(1);
                Test(0);
            }
        }
    }
}