using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;

namespace EnGarde.Test
{
    [TestClass]
    public class ArgumentIComparableExtensionsTests
    {
        [TestClass]
        public class TheIsGreaterThanMethod
        {
            [TestMethod, ExpectedException(typeof(InvalidOperationException))]
            public void ShouldThrowInvalidOperationExceptionIfValueIsNull()
            {
                // Arrange
                string value = null;

                // Act
                Argument.Assert(value, "").IsGreaterThan("");
            }

            [TestMethod, ExpectedException(typeof(ArgumentOutOfRangeException))]
            public void ShouldThrowArgumentOutOfRangeExceptionIfValueIsEqual()
            {
                // Arrange
                var value = 1;

                // Act
                Argument.Assert(value, "").IsGreaterThan(1);
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

            [TestMethod]
            public void ShouldNotThrowArgumentOutOfRangeExceptionIfValueIsEqual()
            {
                // Arrange
                var value = 1;

                // Act
                Argument.Assert(value, "").Not().IsGreaterThan(1);
            }

            [TestMethod]
            public void ShouldNotThrowArgumentOutOfRangeExceptionIfValueIsLess()
            {
                // Arrange
                var value = 1;

                // Act
                Argument.Assert(value, "").Not().IsGreaterThan(2);
            }

            [TestMethod, ExpectedException(typeof(ArgumentOutOfRangeException))]
            public void ShouldThrowAnExceptionIfValueIsGreater()
            {
                // Arrange
                var value = 1;

                // Act
                Argument.Assert(value, "").Not().IsGreaterThan(0);
            }

            [TestMethod]
            public void ShouldNotThrowArgumentOutOfRangeExceptionIfValueIsEqualUsingComparer()
            {
                // Arrange
                var value = 1;

                // Act
                Argument.Assert(value, "").Not().IsGreaterThan(1, Comparer<int>.Default);
            }

            [TestMethod]
            public void ShouldNotThrowArgumentOutOfRangeExceptionIfValueIsLessUsingComparer()
            {
                // Arrange
                var value = 1;

                // Act
                Argument.Assert(value, "").Not().IsGreaterThan(2, Comparer<int>.Default);
            }

            [TestMethod, ExpectedException(typeof(ArgumentOutOfRangeException))]
            public void ShouldThrowAnExceptionIfValueIsGreaterUsingComparer()
            {
                // Arrange
                var value = 1;

                // Act
                Argument.Assert(value, "").Not().IsGreaterThan(0, Comparer<int>.Default);
            }
        }

        [TestClass]
        public class TheIsGreaterThanOrEqualToMethod
        {
            [TestMethod, ExpectedException(typeof(InvalidOperationException))]
            public void ShouldThrowInvalidOperationExceptionIfValueIsNull()
            {
                // Arrange
                string value = null;

                // Act
                Argument.Assert(value, "").IsGreaterThanOrEqualTo("");
            }

            [TestMethod, ExpectedException(typeof(ArgumentOutOfRangeException))]
            public void ShouldThrowArgumentOutOfRangeExceptionIfValueIsLess()
            {
                // Arrange
                var value = 1;

                // Act
                Argument.Assert(value, "").IsGreaterThanOrEqualTo(2);
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

            [TestMethod]
            public void ShouldNotThrowArgumentOutOfRangeExceptionIfValueIsLess()
            {
                // Arrange
                var value = 1;

                // Act
                Argument.Assert(value, "").Not().IsGreaterThanOrEqualTo(2);
            }

            [TestMethod, ExpectedException(typeof(ArgumentOutOfRangeException))]
            public void ShouldThrowAnExceptionIfValueIsGreater()
            {
                // Arrange
                var value = 1;

                // Act
                Argument.Assert(value, "").Not().IsGreaterThanOrEqualTo(0);
            }

            [TestMethod, ExpectedException(typeof(ArgumentOutOfRangeException))]
            public void ShouldThrowAnExceptionIfValueIsEqual()
            {
                // Arrange
                var value = 1;

                // Act
                Argument.Assert(value, "").Not().IsGreaterThanOrEqualTo(1);
            }

            [TestMethod]
            public void ShouldNotThrowArgumentOutOfRangeExceptionIfValueIsLessUsingComparer()
            {
                // Arrange
                var value = 1;

                // Act
                Argument.Assert(value, "").Not().IsGreaterThanOrEqualTo(2, Comparer<int>.Default);
            }

            [TestMethod, ExpectedException(typeof(ArgumentOutOfRangeException))]
            public void ShouldThrowAnExceptionIfValueIsGreaterUsingComparer()
            {
                // Arrange
                var value = 1;

                // Act
                Argument.Assert(value, "").Not().IsGreaterThanOrEqualTo(0, Comparer<int>.Default);
            }

            [TestMethod, ExpectedException(typeof(ArgumentOutOfRangeException))]
            public void ShoulThrowAnExceptionIfValueIsEqualUsingComparer()
            {
                // Arrange
                var value = 1;

                // Act
                Argument.Assert(value, "").Not().IsGreaterThanOrEqualTo(1, Comparer<int>.Default);
            }
        }

        [TestClass]
        public class TheIsLessThanMethod
        {
            [TestMethod, ExpectedException(typeof(InvalidOperationException))]
            public void ShouldThrowInvalidOperationExceptionIfValueIsNull()
            {
                // Arrange
                string value = null;

                // Act
                Argument.Assert(value, "").IsLessThan("");
            }

            [TestMethod, ExpectedException(typeof(ArgumentOutOfRangeException))]
            public void ShouldThrowArgumentOutOfRangeExceptionIfValueIsEqual()
            {
                // Arrange
                var value = 1;

                // Act
                Argument.Assert(value, "").IsLessThan(1);
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

            [TestMethod]
            public void ShouldNotThrowArgumentOutOfRangeExceptionIfValueIsEqual()
            {
                // Arrange
                var value = 1;

                // Act
                Argument.Assert(value, "").Not().IsLessThan(1);
            }

            [TestMethod]
            public void ShouldNotThrowArgumentOutOfRangeExceptionIfValueIsGreater()
            {
                // Arrange
                var value = 1;

                // Act
                Argument.Assert(value, "").Not().IsLessThan(0);
            }

            [TestMethod, ExpectedException(typeof(ArgumentOutOfRangeException))]
            public void ShouldThrowAnExceptionIfValueIsLess()
            {
                // Arrange
                var value = 1;

                // Act
                Argument.Assert(value, "").Not().IsLessThan(2);
            }

            [TestMethod]
            public void ShouldNotThrowArgumentOutOfRangeExceptionIfValueIsEqualUsingComparer()
            {
                // Arrange
                var value = 1;

                // Act
                Argument.Assert(value, "").Not().IsLessThan(1, Comparer<int>.Default);
            }

            [TestMethod]
            public void ShouldNotThrowArgumentOutOfRangeExceptionIfValueIsGreaterUsingComparer()
            {
                // Arrange
                var value = 1;

                // Act
                Argument.Assert(value, "").Not().IsLessThan(0, Comparer<int>.Default);
            }

            [TestMethod, ExpectedException(typeof(ArgumentOutOfRangeException))]
            public void ShouldThrowAnExceptionIfValueIsLessUsingComparer()
            {
                // Arrange
                var value = 1;

                // Act
                Argument.Assert(value, "").Not().IsLessThan(2, Comparer<int>.Default);
            }
        }

        [TestClass]
        public class TheIsLessThanOrEqualToMethod
        {
            [TestMethod, ExpectedException(typeof(InvalidOperationException))]
            public void ShouldThrowInvalidOperationExceptionIfValueIsNull()
            {
                // Arrange
                string value = null;

                // Act
                Argument.Assert(value, "").IsLessThanOrEqualTo("");
            }

            [TestMethod, ExpectedException(typeof(ArgumentOutOfRangeException))]
            public void ShouldThrowArgumentOutOfRangeExceptionIfValueIsGreater()
            {
                // Arrange
                var value = 1;

                // Act
                Argument.Assert(value, "").IsLessThanOrEqualTo(0);
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

            [TestMethod]
            public void ShouldNotThrowArgumentOutOfRangeExceptionIfValueIsGreater()
            {
                // Arrange
                var value = 1;

                // Act
                Argument.Assert(value, "").Not().IsLessThanOrEqualTo(0);
            }

            [TestMethod, ExpectedException(typeof(ArgumentOutOfRangeException))]
            public void ShouldThrowAnExceptionIfValueIsLess()
            {
                // Arrange
                var value = 1;

                // Act
                Argument.Assert(value, "").Not().IsLessThanOrEqualTo(2);
            }

            [TestMethod, ExpectedException(typeof(ArgumentOutOfRangeException))]
            public void ShouldThrowAnExceptionIfValueIsEqual()
            {
                // Arrange
                var value = 1;

                // Act
                Argument.Assert(value, "").Not().IsLessThanOrEqualTo(1);
            }

            [TestMethod]
            public void ShouldNotThrowArgumentOutOfRangeExceptionIfValueIsGreaterUsingComparer()
            {
                // Arrange
                var value = 1;

                // Act
                Argument.Assert(value, "").Not().IsLessThanOrEqualTo(0, Comparer<int>.Default);
            }

            [TestMethod, ExpectedException(typeof(ArgumentOutOfRangeException))]
            public void ShouldThrowAnExceptionIfValueIsLessUsingComparer()
            {
                // Arrange
                var value = 1;

                // Act
                Argument.Assert(value, "").Not().IsLessThanOrEqualTo(2, Comparer<int>.Default);
            }

            [TestMethod, ExpectedException(typeof(ArgumentOutOfRangeException))]
            public void ShouldThrowAnExceptionIfValueIsEqualUsingComparer()
            {
                // Arrange
                var value = 1;

                // Act
                Argument.Assert(value, "").Not().IsLessThanOrEqualTo(1, Comparer<int>.Default);
            }
        }

        [TestClass]
        public class TheIsEqualToMethod
        {
            [TestMethod, ExpectedException(typeof(InvalidOperationException))]
            public void ShouldThrowInvalidOperationExceptionIfValueIsNull()
            {
                // Arrange
                string value = null;

                // Act
                Argument.Assert(value, "").IsEqualTo("");
            }

            [TestMethod, ExpectedException(typeof(ArgumentException))]
            public void ShouldThrowArgumentExceptionIfValueIsGreater()
            {
                // Arrange
                var value = 1;

                // Act
                Argument.Assert(value, "").IsEqualTo(0);
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

            [TestMethod]
            public void ShouldNotThrowArgumentExceptionIfValueIsGreater()
            {
                // Arrange
                var value = 1;

                // Act
                Argument.Assert(value, "").Not().IsEqualTo(0);
            }

            [TestMethod]
            public void ShouldNotThrowArgumentExceptionIfValueIsLess()
            {
                // Arrange
                var value = 1;

                // Act
                Argument.Assert(value, "").Not().IsEqualTo(2);
            }

            [TestMethod, ExpectedException(typeof(ArgumentException))]
            public void ShouldThrowAnExceptionIfValueIsEqual()
            {
                // Arrange
                var value = 1;

                // Act
                Argument.Assert(value, "").Not().IsEqualTo(1);
            }

            [TestMethod]
            public void ShouldNotThrowArgumentExceptionIfValueIsGreaterUsingComparer()
            {
                // Arrange
                var value = 1;

                // Act
                Argument.Assert(value, "").Not().IsEqualTo(0, EqualityComparer<int>.Default);
            }

            [TestMethod]
            public void ShouldNotThrowArgumentExceptionIfValueIsLessUsingComparer()
            {
                // Arrange
                var value = 1;

                // Act
                Argument.Assert(value, "").Not().IsEqualTo(2, EqualityComparer<int>.Default);
            }

            [TestMethod, ExpectedException(typeof(ArgumentException))]
            public void ShouldThrowAnExceptionIfValueIsEqualUsingComparer()
            {
                // Arrange
                var value = 1;

                // Act
                Argument.Assert(value, "").Not().IsEqualTo(1, EqualityComparer<int>.Default);
            }
        }
    }
}
