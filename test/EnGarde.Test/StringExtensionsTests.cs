using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace EnGarde.Test
{
    [TestClass]
    public class StringExtensionsTests
    {
        [TestClass]
        public class TheIsNotNullMethod
        {
            [TestMethod, ExpectedException(typeof(ArgumentNullException))]
            public void ShouldThrowArgumentNullExceptionIfValueIsNull()
            {
                // Arrange
                string value = null;

                // Act
                Argument.Assert(value, "value").IsNotNull();
            }

            [TestMethod]
            public void ShouldNotThrowArgumentNullExceptionIfValueIsNotNull()
            {
                // Arrange
                var value = "a";

                // Act
                Argument.Assert(value, "").IsNotNull();
            }
        }

        [TestClass]
        public class TheIsNotEmptyMethod
        {
            [TestMethod, ExpectedException(typeof(ArgumentException))]
            public void ShouldThrowArgumentExceptionIfValueIsEmpty()
            {
                // Arrange
                var value = "";

                // Act
                Argument.Assert(value, "").IsNotEmpty();
            }

            [TestMethod]
            public void ShouldNotThrowArgumentExceptionIfValueIsNotEmpty()
            {
                // Arrange
                var value = "a";

                // Act
                Argument.Assert(value, "").IsNotEmpty();
            }

            [TestMethod]
            public void ShouldNotThrowArgumentExceptionIfValueIsWhitespace()
            {
                // Arrange
                var value = " ";

                // Act
                Argument.Assert(value, "").IsNotEmpty();
            }

            [TestMethod, ExpectedException(typeof(InvalidOperationException))]
            public void ShouldThrowInvalidOperationExceptionIfValueIsNull()
            {
                // Arrange
                string value = null;

                // Act
                Argument.Assert(value, "").IsNotEmpty();
            }
        }

        [TestClass]
        public class TheIsNotWhitespaceMethod
        {
            [TestMethod, ExpectedException(typeof(ArgumentException))]
            public void ShouldThrowArgumentExceptionIfValueIsEmpty()
            {
                // Arrange
                var value = "";

                // Act
                Argument.Assert(value, "").IsNotWhitespace();
            }

            [TestMethod, ExpectedException(typeof(ArgumentException))]
            public void ShouldThrowArgumentExceptionIfValueIsWhitespace()
            {
                // Arrange
                var value = " ";

                // Act
                Argument.Assert(value, "").IsNotWhitespace();
            }

            [TestMethod]
            public void ShouldNotThrowArgumentExceptionIfValueIsNotEmpty()
            {
                // Arrange
                var value = "a";

                // Act
                Argument.Assert(value, "").IsNotWhitespace();
            }

            [TestMethod, ExpectedException(typeof(InvalidOperationException))]
            public void ShouldThrowInvalidOperationExceptionIfValueIsNull()
            {
                // Arrange
                string value = null;

                // Act
                Argument.Assert(value, "").IsNotWhitespace();
            }
        }

        [TestClass]
        public class TheIsNotNullOrEmptyMethod
        {
            [TestMethod, ExpectedException(typeof(ArgumentException))]
            public void ShouldThrowArgumentExceptionIfValueIsEmpty()
            {
                // Arrange
                var value = "";

                // Act
                Argument.Assert(value, "").IsNotNullOrEmpty();
            }

            [TestMethod]
            public void ShouldNotThrowArgumentExceptionIfValueIsWhitespace()
            {
                // Arrange
                var value = " ";

                // Act
                Argument.Assert(value, "").IsNotNullOrEmpty();
            }

            [TestMethod]
            public void ShouldNotThrowArgumentExceptionIfValueIsNotEmpty()
            {
                // Arrange
                var value = "a";

                // Act
                Argument.Assert(value, "").IsNotNullOrEmpty();
            }

            [TestMethod, ExpectedException(typeof(ArgumentNullException))]
            public void ShouldThrowArgumentNullExceptionIfValueIsNull()
            {
                // Arrange
                string value = null;

                // Act
                Argument.Assert(value, "").IsNotNullOrEmpty();
            }
        }

        [TestClass]
        public class TheIsNotNullOrWhitespaceMethod
        {
            [TestMethod, ExpectedException(typeof(ArgumentException))]
            public void ShouldThrowArgumentExceptionIfValueIsEmpty()
            {
                // Arrange
                var value = "";

                // Act
                Argument.Assert(value, "").IsNotNullOrWhitespace();
            }

            [TestMethod, ExpectedException(typeof(ArgumentException))]
            public void ShouldThrowArgumentExceptionIfValueIsWhitespace()
            {
                // Arrange
                var value = " ";

                // Act
                Argument.Assert(value, "").IsNotNullOrWhitespace();
            }

            [TestMethod]
            public void ShouldNotThrowArgumentExceptionIfValueIsNotEmpty()
            {
                // Arrange
                var value = "a";

                // Act
                Argument.Assert(value, "").IsNotNullOrWhitespace();
            }

            [TestMethod, ExpectedException(typeof(ArgumentNullException))]
            public void ShouldThrowArgumentNullExceptionIfValueIsNull()
            {
                // Arrange
                string value = null;

                // Act
                Argument.Assert(value, "").IsNotNullOrWhitespace();
            }
        }
    }
}
