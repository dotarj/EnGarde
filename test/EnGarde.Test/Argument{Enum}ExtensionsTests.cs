using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.ComponentModel;

namespace EnGarde.Test
{
    [TestClass]
    public class ArgumentEnumExtensionsTests
    {
        [TestClass]
        public class TheIsDefinedMethod
        {
            [TestMethod, ExpectedException(typeof(InvalidEnumArgumentException))]
            public void ShouldThrowInvalidEnumArgumentExceptionIfValueIsNotValid()
            {
                // Arrange
                var value = (StringSplitOptions)int.MaxValue;

                // Act
                Argument.Assert(value, "").Not().IsDefinedEnumValue();
            }

            [TestMethod]
            public void ShouldNotThrowInvalidEnumArgumentExceptionIfValueIsValid()
            {
                // Arrange
                var value = StringSplitOptions.RemoveEmptyEntries;

                // Act
                Argument.Assert(value, "").Not().IsDefinedEnumValue();
            }

            [TestMethod, ExpectedException(typeof(InvalidOperationException))]
            public void ShouldThrowInvalidOperationExceptionIfValueIsNotEnum()
            {
                // Arrange
                var value = 1;

                // Act
                Argument.Assert(value, "").Not().IsDefinedEnumValue();
            }

            [TestMethod]
            public void ShouldNotThrowInvalidEnumArgumentExceptionIfValueIsNotValid()
            {
                // Arrange
                var value = (StringSplitOptions)int.MaxValue;

                // Act
                Argument.Assert(value, "").IsDefinedEnumValue();
            }

            [TestMethod, ExpectedException(typeof(ArgumentException))]
            public void ShouldThrowArgumentExceptionIfValueIsValid()
            {
                // Arrange
                var value = StringSplitOptions.RemoveEmptyEntries;

                // Act
                Argument.Assert(value, "").IsDefinedEnumValue();
            }
        }
    }
}
