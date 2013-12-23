using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace EnGarde.Test
{
    [TestClass]
    public class ArgumentTTests
    {
        [TestClass]
        public class TheAssertMethod
        {
            [TestMethod]
            public void ShouldNotThrowExceptionIfArgumentIsNotDefault()
            {
                // Act
                Test(1);
            }

            private void Test(int i)
            {
                Argument.Assert(() => i).Not().IsDefault();
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
