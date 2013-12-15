using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;

namespace EnGarde.Test
{
    [TestClass]
    public class ArgumentExtensionsTests
    {
        [TestClass]
        public class TheNotMethod
        {
            [TestMethod, ExpectedException(typeof(ArgumentNullException))]
            public void ShouldThrowExceptionIfArgumentIsNull()
            {
                // Act
                ArgumentExtensions.Not<int>(null);
            }
        }

        [TestClass]
        public class TheIsDefaultMethod
        {
            [TestMethod]
            public void ShouldNotThrowExceptionIfValueIsDefault()
            {
                // Arrange
                List<int> value = null;

                // Act
                Argument.Assert(value, "value").IsDefault();
            }

            [TestMethod, ExpectedException(typeof(ArgumentException))]
            public void ShouldThrowExceptionIfValueIsNotDefault()
            {
                // Arrange
                var value = new List<int>();

                // Act
                Argument.Assert(value, "value").IsDefault();
            }

            [TestMethod, ExpectedException(typeof(ArgumentNullException))]
            public void ShouldThrowExceptionIfValueIsDefault()
            {
                // Arrange
                List<int> value = null;

                // Act
                Argument.Assert(value, "value").Not().IsDefault();
            }

            [TestMethod]
            public void ShouldNotThrowExceptionIfValueIsNotDefault()
            {
                // Arrange
                var value = new List<int>();

                // Act
                Argument.Assert(value, "value").Not().IsDefault();
            }

            [TestMethod, ExpectedException(typeof(ArgumentException))]
            public void ShouldThrowExceptionIfStructValueIsNotDefault()
            {
                // Arrange
                var value = 1;

                // Act
                Argument.Assert(value, "value").IsDefault();
            }

            [TestMethod, ExpectedException(typeof(ArgumentException))]
            public void ShouldThrowExceptionIfStructValueIsDefault()
            {
                // Arrange
                var value = 0;

                // Act
                Argument.Assert(value, "value").Not().IsDefault();
            }

            [TestMethod]
            public void ShouldNotThrowExceptionIfStructValueIsDefault()
            {
                // Arrange
                var value = 0;

                // Act
                Argument.Assert(value, "value").IsDefault();
            }

            [TestMethod, ExpectedException(typeof(ArgumentException))]
            public void ShouldThrowExceptionIfNullableValueIsDefault()
            {
                // Arrange
                int? value = 0;

                // Act
                Argument.Assert(value, "value").Not().IsDefault();
            }

            [TestMethod]
            public void ShouldNotThrowExceptionIfNullableValueIsNull()
            {
                // Arrange
                int? value = null;

                // Act
                Argument.Assert(value, "value").Not().IsDefault();
            }
        }
    }
}
