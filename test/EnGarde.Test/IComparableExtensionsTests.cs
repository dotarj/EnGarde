using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;

namespace EnGarde.Test
{
    [TestClass]
    public class IComparableExtensionsTests
    {
        [TestClass]
        public class TheIsGreaterThanMethod
        {
            [TestMethod, ExpectedException(typeof(ArgumentOutOfRangeException))]
            public void ShouldThrowArgumentOutOfRangeExceptionIfValueIsEqual()
            {
                // Arrange
                var value = 1;

                // Act
                Argument.Assert(value, "").IsGreaterThan(1);
            }

            [TestMethod, ExpectedException(typeof(InvalidOperationException))]
            public void ShouldThrowInvalidOperationExceptionIfValueIsNull()
            {
                // Arrange
                string value = null;

                // Act
                Argument.Assert(value, "").IsGreaterThan("");
            }

            [TestMethod, ExpectedException(typeof(ArgumentOutOfRangeException))]
            public void ShouldThrowArgumentOutOfRangeExceptionIfValueIsLess()
            {
                // Arrange
                var value = 1;

                // Act
                Argument.Assert(value, "").IsGreaterThan(2);
            }

            [TestMethod]
            public void ShouldNotThrowAnExceptionIfValueIsGreater()
            {
                // Arrange
                var value = 1;

                // Act
                Argument.Assert(value, "").IsGreaterThan(0);
            }

            [TestMethod, ExpectedException(typeof(ArgumentOutOfRangeException))]
            public void ShouldThrowArgumentOutOfRangeExceptionIfValueIsEqualUsingComparer()
            {
                // Arrange
                var value = 1;

                // Act
                Argument.Assert(value, "").IsGreaterThan(1, Comparer<int>.Default);
            }

            [TestMethod, ExpectedException(typeof(ArgumentOutOfRangeException))]
            public void ShouldThrowArgumentOutOfRangeExceptionIfValueIsLessUsingComparer()
            {
                // Arrange
                var value = 1;

                // Act
                Argument.Assert(value, "").IsGreaterThan(2, Comparer<int>.Default);
            }

            [TestMethod]
            public void ShouldNotThrowAnExceptionIfValueIsGreaterUsingComparer()
            {
                // Arrange
                var value = 1;

                // Act
                Argument.Assert(value, "").IsGreaterThan(0, Comparer<int>.Default);
            }
        }

        [TestClass]
        public class TheIsGreaterThanOrEqualToMethod
        {
            [TestMethod, ExpectedException(typeof(ArgumentOutOfRangeException))]
            public void ShouldThrowArgumentOutOfRangeExceptionIfValueIsLess()
            {
                // Arrange
                var value = 1;

                // Act
                Argument.Assert(value, "").IsGreaterThanOrEqualTo(2);
            }

            [TestMethod, ExpectedException(typeof(InvalidOperationException))]
            public void ShouldThrowInvalidOperationExceptionIfValueIsNull()
            {
                // Arrange
                string value = null;

                // Act
                Argument.Assert(value, "").IsGreaterThanOrEqualTo("");
            }

            [TestMethod]
            public void ShouldNotThrowAnExceptionIfValueIsGreater()
            {
                // Arrange
                var value = 1;

                // Act
                Argument.Assert(value, "").IsGreaterThanOrEqualTo(0);
            }

            [TestMethod]
            public void ShouldNotThrowAnExceptionIfValueIsEqual()
            {
                // Arrange
                var value = 1;

                // Act
                Argument.Assert(value, "").IsGreaterThanOrEqualTo(1);
            }

            [TestMethod, ExpectedException(typeof(ArgumentOutOfRangeException))]
            public void ShouldThrowArgumentOutOfRangeExceptionIfValueIsLessUsingComparer()
            {
                // Arrange
                var value = 1;

                // Act
                Argument.Assert(value, "").IsGreaterThanOrEqualTo(2, Comparer<int>.Default);
            }

            [TestMethod]
            public void ShouldNotThrowAnExceptionIfValueIsGreaterUsingComparer()
            {
                // Arrange
                var value = 1;

                // Act
                Argument.Assert(value, "").IsGreaterThanOrEqualTo(0, Comparer<int>.Default);
            }

            [TestMethod]
            public void ShouldNotThrowAnExceptionIfValueIsEqualUsingComparer()
            {
                // Arrange
                var value = 1;

                // Act
                Argument.Assert(value, "").IsGreaterThanOrEqualTo(1, Comparer<int>.Default);
            }
        }

        [TestClass]
        public class TheIsLessThanMethod
        {
            [TestMethod, ExpectedException(typeof(ArgumentOutOfRangeException))]
            public void ShouldThrowArgumentOutOfRangeExceptionIfValueIsEqual()
            {
                // Arrange
                var value = 1;

                // Act
                Argument.Assert(value, "").IsLessThan(1);
            }

            [TestMethod, ExpectedException(typeof(InvalidOperationException))]
            public void ShouldThrowInvalidOperationExceptionIfValueIsNull()
            {
                // Arrange
                string value = null;

                // Act
                Argument.Assert(value, "").IsLessThan("");
            }

            [TestMethod, ExpectedException(typeof(ArgumentOutOfRangeException))]
            public void ShouldThrowArgumentOutOfRangeExceptionIfValueIsGreater()
            {
                // Arrange
                var value = 1;

                // Act
                Argument.Assert(value, "").IsLessThan(0);
            }

            [TestMethod]
            public void ShouldNotThrowAnExceptionIfValueIsLess()
            {
                // Arrange
                var value = 1;

                // Act
                Argument.Assert(value, "").IsLessThan(2);
            }

            [TestMethod, ExpectedException(typeof(ArgumentOutOfRangeException))]
            public void ShouldThrowArgumentOutOfRangeExceptionIfValueIsEqualUsingComparer()
            {
                // Arrange
                var value = 1;

                // Act
                Argument.Assert(value, "").IsLessThan(1, Comparer<int>.Default);
            }

            [TestMethod, ExpectedException(typeof(ArgumentOutOfRangeException))]
            public void ShouldThrowArgumentOutOfRangeExceptionIfValueIsGreaterUsingComparer()
            {
                // Arrange
                var value = 1;

                // Act
                Argument.Assert(value, "").IsLessThan(0, Comparer<int>.Default);
            }

            [TestMethod]
            public void ShouldNotThrowAnExceptionIfValueIsLessUsingComparer()
            {
                // Arrange
                var value = 1;

                // Act
                Argument.Assert(value, "").IsLessThan(2, Comparer<int>.Default);
            }
        }

        [TestClass]
        public class TheIsLessThanOrEqualToMethod
        {
            [TestMethod, ExpectedException(typeof(ArgumentOutOfRangeException))]
            public void ShouldThrowArgumentOutOfRangeExceptionIfValueIsGreater()
            {
                // Arrange
                var value = 1;

                // Act
                Argument.Assert(value, "").IsLessThanOrEqualTo(0);
            }

            [TestMethod, ExpectedException(typeof(InvalidOperationException))]
            public void ShouldThrowInvalidOperationExceptionIfValueIsNull()
            {
                // Arrange
                string value = null;

                // Act
                Argument.Assert(value, "").IsLessThanOrEqualTo("");
            }

            [TestMethod]
            public void ShouldNotThrowAnExceptionIfValueIsLess()
            {
                // Arrange
                var value = 1;

                // Act
                Argument.Assert(value, "").IsLessThanOrEqualTo(2);
            }

            [TestMethod]
            public void ShouldNotThrowAnExceptionIfValueIsEqual()
            {
                // Arrange
                var value = 1;

                // Act
                Argument.Assert(value, "").IsLessThanOrEqualTo(1);
            }

            [TestMethod, ExpectedException(typeof(ArgumentOutOfRangeException))]
            public void ShouldThrowArgumentOutOfRangeExceptionIfValueIsGreaterUsingComparer()
            {
                // Arrange
                var value = 1;

                // Act
                Argument.Assert(value, "").IsLessThanOrEqualTo(0, Comparer<int>.Default);
            }

            [TestMethod]
            public void ShouldNotThrowAnExceptionIfValueIsLessUsingComparer()
            {
                // Arrange
                var value = 1;

                // Act
                Argument.Assert(value, "").IsLessThanOrEqualTo(2, Comparer<int>.Default);
            }

            [TestMethod]
            public void ShouldNotThrowAnExceptionIfValueIsEqualUsingComparer()
            {
                // Arrange
                var value = 1;

                // Act
                Argument.Assert(value, "").IsLessThanOrEqualTo(1, Comparer<int>.Default);
            }
        }




        [TestClass]
        public class TheIsEqualToMethod
        {
            [TestMethod, ExpectedException(typeof(ArgumentException))]
            public void ShouldThrowArgumentExceptionIfValueIsGreater()
            {
                // Arrange
                var value = 1;

                // Act
                Argument.Assert(value, "").IsEqualTo(0);
            }

            [TestMethod, ExpectedException(typeof(InvalidOperationException))]
            public void ShouldThrowInvalidOperationExceptionIfValueIsNull()
            {
                // Arrange
                string value = null;

                // Act
                Argument.Assert(value, "").IsEqualTo("");
            }

            [TestMethod, ExpectedException(typeof(ArgumentException))]
            public void ShouldThrowArgumentExceptionIfValueIsLess()
            {
                // Arrange
                var value = 1;

                // Act
                Argument.Assert(value, "").IsEqualTo(2);
            }

            [TestMethod]
            public void ShouldNotThrowAnExceptionIfValueIsEqual()
            {
                // Arrange
                var value = 1;

                // Act
                Argument.Assert(value, "").IsEqualTo(1);
            }

            [TestMethod, ExpectedException(typeof(ArgumentException))]
            public void ShouldThrowArgumentExceptionIfValueIsGreaterUsingComparer()
            {
                // Arrange
                var value = 1;

                // Act
                Argument.Assert(value, "").IsEqualTo(0, EqualityComparer<int>.Default);
            }

            [TestMethod, ExpectedException(typeof(ArgumentException))]
            public void ShouldThrowArgumentExceptionIfValueIsLessUsingComparer()
            {
                // Arrange
                var value = 1;

                // Act
                Argument.Assert(value, "").IsEqualTo(2, EqualityComparer<int>.Default);
            }

            [TestMethod]
            public void ShouldNotThrowAnExceptionIfValueIsEqualUsingComparer()
            {
                // Arrange
                var value = 1;

                // Act
                Argument.Assert(value, "").IsEqualTo(1, EqualityComparer<int>.Default);
            }
        }

        [TestClass]
        public class TheIsNotEqualToMethod
        {
            [TestMethod]
            public void ShouldNotThrowArgumentOutOfRangeExceptionIfValueIsGreater()
            {
                // Arrange
                var value = 1;

                // Act
                Argument.Assert(value, "").IsNotEqualTo(0);
            }

            [TestMethod, ExpectedException(typeof(InvalidOperationException))]
            public void ShouldThrowInvalidOperationExceptionIfValueIsNull()
            {
                // Arrange
                string value = null;

                // Act
                Argument.Assert(value, "").IsNotEqualTo("");
            }

            [TestMethod]
            public void ShouldNotThrowArgumentOutOfRangeExceptionIfValueIsLess()
            {
                // Arrange
                var value = 1;

                // Act
                Argument.Assert(value, "").IsNotEqualTo(2);
            }

            [TestMethod, ExpectedException(typeof(ArgumentException))]
            public void ShouldThrowAnArgumentExceptionIfValueIsEqual()
            {
                // Arrange
                var value = 1;

                // Act
                Argument.Assert(value, "").IsNotEqualTo(1);
            }

            [TestMethod]
            public void ShouldNotThrowArgumentOutOfRangeExceptionIfValueIsGreaterUsingComparer()
            {
                // Arrange
                var value = 1;

                // Act
                Argument.Assert(value, "").IsNotEqualTo(0, EqualityComparer<int>.Default);
            }

            [TestMethod]
            public void ShouldNotThrowArgumentOutOfRangeExceptionIfValueIsLessUsingComparer()
            {
                // Arrange
                var value = 1;

                // Act
                Argument.Assert(value, "").IsNotEqualTo(2, EqualityComparer<int>.Default);
            }

            [TestMethod, ExpectedException(typeof(ArgumentException))]
            public void ShouldThrowAnArgumentExceptionIfValueIsEqualUsingComparer()
            {
                // Arrange
                var value = 1;

                // Act
                Argument.Assert(value, "").IsNotEqualTo(1, EqualityComparer<int>.Default);
            }
        }
    }
}
