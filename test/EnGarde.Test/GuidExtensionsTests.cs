using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace EnGarde.Test
{
    [TestClass]
    public class GuidExtensionsTests
    {
        [TestClass]
        public class TheIsEmptyMethod
        {
            [TestMethod, ExpectedException(typeof(ArgumentException))]
            public void ShouldThrowArgumentExceptionIfValueIsEmpty()
            {
                // Arrange
                var value = Guid.Empty;

                // Act
                Argument.Assert(value, "").IsNotEmpty();
            }

            [TestMethod]
            public void ShouldNotThrowArgumentExceptionIfValueIsNotEmpty()
            {
                // Arrange
                var value = Guid.NewGuid();

                // Act
                Argument.Assert(value, "").IsNotEmpty();
            }
        }
    }
}
