using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace EnGarde.Test
{
    [TestClass]
    public class ArgumentNullableTExtensionsTests
    {
        [TestClass]
        public class TheHasValueMethod
        {
            [TestMethod]
            public void ShouldNotThrowExceptionIfHasValue()
            {
                // Arrange
                int? value = 0;

                // Act
                Argument.Assert(value, "value").HasValue();
            }

            [TestMethod, ExpectedException(typeof(ArgumentNullException))]
            public void ShouldThrowExceptionIfDoesNotHaveValue()
            {
                // Arrange
                int? value = null;

                // Act
                Argument.Assert(value, "value").HasValue();
            }

            [TestMethod, ExpectedException(typeof(ArgumentException))]
            public void ShouldThrowExceptionIfHasValue()
            {
                // Arrange
                int? value = 0;

                // Act
                Argument.Assert(value, "value").Not().HasValue();
            }

            [TestMethod]
            public void ShouldNotThrowExceptionIfDoesNotHaveValue()
            {
                // Arrange
                int? value = null;

                // Act
                Argument.Assert(value, "value").Not().HasValue();
            }
        }
    }
}
