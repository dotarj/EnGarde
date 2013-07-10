using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace EnGarde.Test
{
    [TestClass]
    public class StringExtensionsTests
    {
        [TestClass]
        public class TheIsNullMethod
        {
            [TestMethod]
            public void ShouldNotThrowExceptionIfValueIsNull()
            {
                // Arrange
                string value = null;

                // Act
                Argument.Assert(value, "value").IsNull();
            }

            [TestMethod, ExpectedException(typeof(ArgumentException))]
            public void ShouldNotThrowArgumentExceptionIfValueIsNotNull()
            {
                // Arrange
                var value = "a";

                // Act
                Argument.Assert(value, "").IsNull();
            }

            [TestMethod, ExpectedException(typeof(ArgumentNullException))]
            public void ShouldThrowArgumentNullExceptionIfValueIsNull()
            {
                // Arrange
                string value = null;

                // Act
                Argument.Assert(value, "value").Not().IsNull();
            }

            [TestMethod]
            public void ShouldNotThrowArgumentNullExceptionIfValueIsNotNull()
            {
                // Arrange
                var value = "a";

                // Act
                Argument.Assert(value, "").Not().IsNull();
            }
        }

        [TestClass]
        public class TheIsEmptyMethod
        {
            [TestMethod]
            public void ShouldNotThrowExceptionIfValueIsEmpty()
            {
                // Arrange
                var value = "";

                // Act
                Argument.Assert(value, "").IsEmpty();
            }

            [TestMethod, ExpectedException(typeof(ArgumentException))]
            public void ShouldThrowArgumentExceptionIfValueIsNotEmpty()
            {
                // Arrange
                var value = "a";

                // Act
                Argument.Assert(value, "").IsEmpty();
            }

            [TestMethod, ExpectedException(typeof(ArgumentException))]
            public void ShouldThrowArgumentExceptionIfValueIsWhitespace()
            {
                // Arrange
                var value = " ";

                // Act
                Argument.Assert(value, "").IsEmpty();
            }

            [TestMethod, ExpectedException(typeof(InvalidOperationException))]
            public void ShouldThrowInvalidOperationExceptionIfValueIsNull()
            {
                // Arrange
                string value = null;

                // Act
                Argument.Assert(value, "").IsEmpty();
            }

            [TestMethod, ExpectedException(typeof(ArgumentException))]
            public void ShouldThrowArgumentExceptionIfValueIsEmpty()
            {
                // Arrange
                var value = "";

                // Act
                Argument.Assert(value, "").Not().IsEmpty();
            }

            [TestMethod]
            public void ShouldNotThrowArgumentExceptionIfValueIsNotEmpty()
            {
                // Arrange
                var value = "a";

                // Act
                Argument.Assert(value, "").Not().IsEmpty();
            }

            [TestMethod]
            public void ShouldNotThrowArgumentExceptionIfValueIsWhitespace()
            {
                // Arrange
                var value = " ";

                // Act
                Argument.Assert(value, "").Not().IsEmpty();
            }
        }

        [TestClass]
        public class TheIsWhitespaceMethod
        {
            [TestMethod]
            public void ShouldNotThrowArgumentExceptionIfValueIsEmpty()
            {
                // Arrange
                var value = "";

                // Act
                Argument.Assert(value, "").IsWhitespace();
            }

            [TestMethod]
            public void ShouldNotThrowArgumentExceptionIfValueIsWhitespace()
            {
                // Arrange
                var value = " ";

                // Act
                Argument.Assert(value, "").IsWhitespace();
            }

            [TestMethod, ExpectedException(typeof(ArgumentException))]
            public void ShouldThrowArgumentExceptionIfValueIsNotEmpty()
            {
                // Arrange
                var value = "a";

                // Act
                Argument.Assert(value, "").IsWhitespace();
            }

            [TestMethod, ExpectedException(typeof(InvalidOperationException))]
            public void ShouldThrowInvalidOperationExceptionIfValueIsNull()
            {
                // Arrange
                string value = null;

                // Act
                Argument.Assert(value, "").IsWhitespace();
            }

            [TestMethod, ExpectedException(typeof(ArgumentException))]
            public void ShouldThrowArgumentExceptionIfValueIsEmpty()
            {
                // Arrange
                var value = "";

                // Act
                Argument.Assert(value, "").Not().IsWhitespace();
            }

            [TestMethod, ExpectedException(typeof(ArgumentException))]
            public void ShouldThrowArgumentExceptionIfValueIsWhitespace()
            {
                // Arrange
                var value = " ";

                // Act
                Argument.Assert(value, "").Not().IsWhitespace();
            }

            [TestMethod]
            public void ShouldNotThrowArgumentExceptionIfValueIsNotEmpty()
            {
                // Arrange
                var value = "a";

                // Act
                Argument.Assert(value, "").Not().IsWhitespace();
            }
        }

        [TestClass]
        public class TheIsNullOrEmptyMethod
        {
            [TestMethod]
            public void ShouldNotThrowArgumentExceptionIfValueIsEmpty()
            {
                // Arrange
                var value = "";

                // Act
                Argument.Assert(value, "").IsNullOrEmpty();
            }

            [TestMethod, ExpectedException(typeof(ArgumentException))]
            public void ShouldThrowArgumentExceptionIfValueIsWhitespace()
            {
                // Arrange
                var value = " ";

                // Act
                Argument.Assert(value, "").IsNullOrEmpty();
            }

            [TestMethod, ExpectedException(typeof(ArgumentException))]
            public void ShouldThrowArgumentExceptionIfValueIsNotEmpty()
            {
                // Arrange
                var value = "a";

                // Act
                Argument.Assert(value, "").IsNullOrEmpty();
            }

            [TestMethod]
            public void ShouldNotThrowArgumentNullExceptionIfValueIsNull()
            {
                // Arrange
                string value = null;

                // Act
                Argument.Assert(value, "").IsNullOrEmpty();
            }

            [TestMethod, ExpectedException(typeof(ArgumentException))]
            public void ShouldThrowArgumentExceptionIfValueIsEmpty()
            {
                // Arrange
                var value = "";

                // Act
                Argument.Assert(value, "").Not().IsNullOrEmpty();
            }

            [TestMethod]
            public void ShouldNotThrowArgumentExceptionIfValueIsWhitespace()
            {
                // Arrange
                var value = " ";

                // Act
                Argument.Assert(value, "").Not().IsNullOrEmpty();
            }

            [TestMethod]
            public void ShouldNotThrowArgumentExceptionIfValueIsNotEmpty()
            {
                // Arrange
                var value = "a";

                // Act
                Argument.Assert(value, "").Not().IsNullOrEmpty();
            }

            [TestMethod, ExpectedException(typeof(ArgumentNullException))]
            public void ShouldThrowArgumentNullExceptionIfValueIsNull()
            {
                // Arrange
                string value = null;

                // Act
                Argument.Assert(value, "").Not().IsNullOrEmpty();
            }
        }

        [TestClass]
        public class TheIsNullOrWhitespaceMethod
        {
            [TestMethod]
            public void ShouldNotThrowArgumentExceptionIfValueIsEmpty()
            {
                // Arrange
                var value = "";

                // Act
                Argument.Assert(value, "").IsNullOrWhitespace();
            }

            [TestMethod]
            public void ShouldNotThrowArgumentExceptionIfValueIsWhitespace()
            {
                // Arrange
                var value = " ";

                // Act
                Argument.Assert(value, "").IsNullOrWhitespace();
            }

            [TestMethod, ExpectedException(typeof(ArgumentException))]
            public void ShouldThrowArgumentExceptionIfValueIsNotEmpty()
            {
                // Arrange
                var value = "a";

                // Act
                Argument.Assert(value, "").IsNullOrWhitespace();
            }

            [TestMethod]
            public void ShouldNotThrowArgumentNullExceptionIfValueIsNull()
            {
                // Arrange
                string value = null;

                // Act
                Argument.Assert(value, "").IsNullOrWhitespace();
            }

            [TestMethod, ExpectedException(typeof(ArgumentException))]
            public void ShouldThrowArgumentExceptionIfValueIsEmpty()
            {
                // Arrange
                var value = "";

                // Act
                Argument.Assert(value, "").Not().IsNullOrWhitespace();
            }

            [TestMethod, ExpectedException(typeof(ArgumentException))]
            public void ShouldThrowArgumentExceptionIfValueIsWhitespace()
            {
                // Arrange
                var value = " ";

                // Act
                Argument.Assert(value, "").Not().IsNullOrWhitespace();
            }

            [TestMethod]
            public void ShouldNotThrowArgumentExceptionIfValueIsNotEmpty()
            {
                // Arrange
                var value = "a";

                // Act
                Argument.Assert(value, "").Not().IsNullOrWhitespace();
            }

            [TestMethod, ExpectedException(typeof(ArgumentNullException))]
            public void ShouldThrowArgumentNullExceptionIfValueIsNull()
            {
                // Arrange
                string value = null;

                // Act
                Argument.Assert(value, "").Not().IsNullOrWhitespace();
            }
        }

        [TestClass]
        public class TheStartsWithMethod
        {
            [TestMethod]
            public void ShouldNotThrowArgumentExceptionIfValueDoesStartWith()
            {
                // Arrange
                var value = "EnGarde";

                // Act
                Argument.Assert(value, "").StartsWith("En");
            }

            [TestMethod, ExpectedException(typeof(ArgumentException))]
            public void ShouldThrowArgumentExceptionIfValueDoesNotStartWith()
            {
                // Arrange
                var value = "EnGarde";

                // Act
                Argument.Assert(value, "").StartsWith("A");
            }

            [TestMethod]
            public void ShouldNotThrowArgumentExceptionIfValueDoesStartWithUsingStringComparison()
            {
                // Arrange
                var value = "EnGarde";

                // Act
                Argument.Assert(value, "").StartsWith("en", StringComparison.OrdinalIgnoreCase);
            }

            [TestMethod, ExpectedException(typeof(ArgumentException))]
            public void ShouldThrowArgumentExceptionIfValueDoesNotStartWithUsingStringComparison()
            {
                // Arrange
                var value = "EnGarde";

                // Act
                Argument.Assert(value, "").StartsWith("a", StringComparison.OrdinalIgnoreCase);
            }

            [TestMethod, ExpectedException(typeof(ArgumentException))]
            public void ShouldThrowArgumentExceptionIfValueDoesStartWith()
            {
                // Arrange
                var value = "EnGarde";

                // Act
                Argument.Assert(value, "").Not().StartsWith("En");
            }

            [TestMethod]
            public void ShouldNotThrowArgumentExceptionIfValueDoesNotStartWith()
            {
                // Arrange
                var value = "EnGarde";

                // Act
                Argument.Assert(value, "").Not().StartsWith("A");
            }

            [TestMethod, ExpectedException(typeof(ArgumentException))]
            public void ShouldThrowArgumentExceptionIfValueDoesStartWithUsingStringComparison()
            {
                // Arrange
                var value = "EnGarde";

                // Act
                Argument.Assert(value, "").Not().StartsWith("en", StringComparison.OrdinalIgnoreCase);
            }

            [TestMethod]
            public void ShouldNotThrowArgumentExceptionIfValueDoesNotStartWithUsingStringComparison()
            {
                // Arrange
                var value = "EnGarde";

                // Act
                Argument.Assert(value, "").Not().StartsWith("a", StringComparison.OrdinalIgnoreCase);
            }

            [TestMethod, ExpectedException(typeof(InvalidOperationException))]
            public void ShouldThrowInvalidOperationExceptionIfValueIsNull()
            {
                // Arrange
                string value = null;

                // Act
                Argument.Assert(value, "").StartsWith("a");
            }

            [TestMethod, ExpectedException(typeof(InvalidOperationException))]
            public void ShouldThrowInvalidOperationExceptionIfValueIsNullUsingStringComparison()
            {
                // Arrange
                string value = null;

                // Act
                Argument.Assert(value, "").StartsWith("a", StringComparison.OrdinalIgnoreCase);
            }
        }

        [TestClass]
        public class TheEndsWithMethod
        {
            [TestMethod]
            public void ShouldNotThrowArgumentExceptionIfValueDoesEndWith()
            {
                // Arrange
                var value = "EnGarde";

                // Act
                Argument.Assert(value, "").EndsWith("Garde");
            }

            [TestMethod, ExpectedException(typeof(ArgumentException))]
            public void ShouldThrowArgumentExceptionIfValueDoesNotEndWith()
            {
                // Arrange
                var value = "EnGarde";

                // Act
                Argument.Assert(value, "").EndsWith("A");
            }

            [TestMethod]
            public void ShouldNotThrowArgumentExceptionIfValueDoesEndWithUsingStringComparison()
            {
                // Arrange
                var value = "EnGarde";

                // Act
                Argument.Assert(value, "").EndsWith("garde", StringComparison.OrdinalIgnoreCase);
            }

            [TestMethod, ExpectedException(typeof(ArgumentException))]
            public void ShouldThrowArgumentExceptionIfValueDoesNotEndWithUsingStringComparison()
            {
                // Arrange
                var value = "EnGarde";

                // Act
                Argument.Assert(value, "").EndsWith("a", StringComparison.OrdinalIgnoreCase);
            }

            [TestMethod, ExpectedException(typeof(ArgumentException))]
            public void ShouldThrowArgumentExceptionIfValueDoesEndWith()
            {
                // Arrange
                var value = "EnGarde";

                // Act
                Argument.Assert(value, "").Not().EndsWith("Garde");
            }

            [TestMethod]
            public void ShouldNotThrowArgumentExceptionIfValueDoesNotEndWith()
            {
                // Arrange
                var value = "EnGarde";

                // Act
                Argument.Assert(value, "").Not().EndsWith("A");
            }

            [TestMethod, ExpectedException(typeof(ArgumentException))]
            public void ShouldThrowArgumentExceptionIfValueDoesEndWithUsingStringComparison()
            {
                // Arrange
                var value = "EnGarde";

                // Act
                Argument.Assert(value, "").Not().EndsWith("garde", StringComparison.OrdinalIgnoreCase);
            }

            [TestMethod]
            public void ShouldNotThrowArgumentExceptionIfValueDoesNotEndWithUsingStringComparison()
            {
                // Arrange
                var value = "EnGarde";

                // Act
                Argument.Assert(value, "").Not().EndsWith("a", StringComparison.OrdinalIgnoreCase);
            }

            [TestMethod, ExpectedException(typeof(InvalidOperationException))]
            public void ShouldThrowInvalidOperationExceptionIfValueIsNull()
            {
                // Arrange
                string value = null;

                // Act
                Argument.Assert(value, "").EndsWith("a");
            }

            [TestMethod, ExpectedException(typeof(InvalidOperationException))]
            public void ShouldThrowInvalidOperationExceptionIfValueIsNullUsingStringComparison()
            {
                // Arrange
                string value = null;

                // Act
                Argument.Assert(value, "").EndsWith("a", StringComparison.OrdinalIgnoreCase);
            }
        }

        [TestClass]
        public class TheContainsMethod
        {
            [TestMethod]
            public void ShouldNotThrowArgumentExceptionIfValueDoesContainWith()
            {
                // Arrange
                var value = "EnGarde";

                // Act
                Argument.Assert(value, "").Contains("Gar");
            }

            [TestMethod, ExpectedException(typeof(ArgumentException))]
            public void ShouldThrowArgumentExceptionIfValueDoesNotContainWith()
            {
                // Arrange
                var value = "EnGarde";

                // Act
                Argument.Assert(value, "").Contains("Z");
            }

            [TestMethod]
            public void ShouldNotThrowArgumentExceptionIfValueDoesContainWithUsingStringComparison()
            {
                // Arrange
                var value = "EnGarde";

                // Act
                Argument.Assert(value, "").Contains("gar", StringComparison.OrdinalIgnoreCase);
            }

            [TestMethod, ExpectedException(typeof(ArgumentException))]
            public void ShouldThrowArgumentExceptionIfValueDoesNotContainWithUsingStringComparison()
            {
                // Arrange
                var value = "EnGarde";

                // Act
                Argument.Assert(value, "").Contains("z", StringComparison.OrdinalIgnoreCase);
            }

            [TestMethod, ExpectedException(typeof(ArgumentException))]
            public void ShouldThrowArgumentExceptionIfValueDoesContainWith()
            {
                // Arrange
                var value = "EnGarde";

                // Act
                Argument.Assert(value, "").Not().Contains("Gar");
            }

            [TestMethod]
            public void ShouldNotThrowArgumentExceptionIfValueDoesNotContainWith()
            {
                // Arrange
                var value = "EnGarde";

                // Act
                Argument.Assert(value, "").Not().Contains("Z");
            }

            [TestMethod, ExpectedException(typeof(ArgumentException))]
            public void ShouldThrowArgumentExceptionIfValueDoesContainWithUsingStringComparison()
            {
                // Arrange
                var value = "EnGarde";

                // Act
                Argument.Assert(value, "").Not().Contains("gar", StringComparison.OrdinalIgnoreCase);
            }

            [TestMethod]
            public void ShouldNotThrowArgumentExceptionIfValueDoesNotContainWithUsingStringComparison()
            {
                // Arrange
                var value = "EnGarde";

                // Act
                Argument.Assert(value, "").Not().Contains("z", StringComparison.OrdinalIgnoreCase);
            }

            [TestMethod, ExpectedException(typeof(InvalidOperationException))]
            public void ShouldThrowInvalidOperationExceptionIfValueIsNull()
            {
                // Arrange
                string value = null;

                // Act
                Argument.Assert(value, "").Contains("z");
            }

            [TestMethod, ExpectedException(typeof(InvalidOperationException))]
            public void ShouldThrowInvalidOperationExceptionIfValueIsNullUsingStringComparison()
            {
                // Arrange
                string value = null;

                // Act
                Argument.Assert(value, "").Contains("z", StringComparison.OrdinalIgnoreCase);
            }
        }
    }
}
