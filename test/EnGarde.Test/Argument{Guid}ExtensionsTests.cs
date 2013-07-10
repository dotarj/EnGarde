using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace EnGarde.Test
{
    [TestClass]
    public class ArgumentGuidExtensionsTests
    {
        [TestClass]
        public class TheIsEmptyMethod
        {
            [TestMethod]
            public void ShouldNotThrowArgumentExceptionIfValueIsEmpty()
            {
                // Arrange
                var value = Guid.Empty;

                // Act
                Argument.Assert(value, "").IsEmpty();
            }

            [TestMethod, ExpectedException(typeof(ArgumentException))]
            public void ShouldThrowArgumentExceptionIfValueIsNotEmpty()
            {
                // Arrange
                var value = Guid.NewGuid();

                // Act
                Argument.Assert(value, "").IsEmpty();
            }

            [TestMethod, ExpectedException(typeof(ArgumentException))]
            public void ShouldThrowArgumentExceptionIfValueIsEmpty()
            {
                // Arrange
                var value = Guid.Empty;

                // Act
                Argument.Assert(value, "").Not().IsEmpty();
            }

            [TestMethod]
            public void ShouldNotThrowArgumentExceptionIfValueIsNotEmpty()
            {
                // Arrange
                var value = Guid.NewGuid();

                // Act
                Argument.Assert(value, "").Not().IsEmpty();
            }
        }
    }
}
