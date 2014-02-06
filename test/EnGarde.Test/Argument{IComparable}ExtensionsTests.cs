// Copyright (c) Arjen Post. See License.txt in the project root for license information.

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
                Ensure.That(value, "").IsGreaterThan("");
            }

            [TestMethod, ExpectedException(typeof(ArgumentOutOfRangeException))]
            public void ShouldThrowArgumentOutOfRangeExceptionIfValueIsEqual()
            {
                // Arrange
                var value = 1;

                // Act
                Ensure.That(value, "").IsGreaterThan(1);
            }

            [TestMethod, ExpectedException(typeof(ArgumentOutOfRangeException))]
            public void ShouldThrowArgumentOutOfRangeExceptionIfValueIsLess()
            {
                // Arrange
                var value = 1;

                // Act
                Ensure.That(value, "").IsGreaterThan(2);
            }

            [TestMethod]
            public void ShouldNotThrowAnExceptionIfValueIsGreater()
            {
                // Arrange
                var value = 1;

                // Act
                Ensure.That(value, "").IsGreaterThan(0);
            }

            [TestMethod, ExpectedException(typeof(ArgumentOutOfRangeException))]
            public void ShouldThrowArgumentOutOfRangeExceptionIfValueIsEqualUsingComparer()
            {
                // Arrange
                var value = 1;

                // Act
                Ensure.That(value, "").IsGreaterThan(1, Comparer<int>.Default);
            }

            [TestMethod, ExpectedException(typeof(ArgumentOutOfRangeException))]
            public void ShouldThrowArgumentOutOfRangeExceptionIfValueIsLessUsingComparer()
            {
                // Arrange
                var value = 1;

                // Act
                Ensure.That(value, "").IsGreaterThan(2, Comparer<int>.Default);
            }

            [TestMethod]
            public void ShouldNotThrowAnExceptionIfValueIsGreaterUsingComparer()
            {
                // Arrange
                var value = 1;

                // Act
                Ensure.That(value, "").IsGreaterThan(0, Comparer<int>.Default);
            }

            [TestMethod]
            public void ShouldNotThrowArgumentOutOfRangeExceptionIfValueIsEqual()
            {
                // Arrange
                var value = 1;

                // Act
                Ensure.That(value, "").Not.IsGreaterThan(1);
            }

            [TestMethod]
            public void ShouldNotThrowArgumentOutOfRangeExceptionIfValueIsLess()
            {
                // Arrange
                var value = 1;

                // Act
                Ensure.That(value, "").Not.IsGreaterThan(2);
            }

            [TestMethod, ExpectedException(typeof(ArgumentOutOfRangeException))]
            public void ShouldThrowAnExceptionIfValueIsGreater()
            {
                // Arrange
                var value = 1;

                // Act
                Ensure.That(value, "").Not.IsGreaterThan(0);
            }

            [TestMethod]
            public void ShouldNotThrowArgumentOutOfRangeExceptionIfValueIsEqualUsingComparer()
            {
                // Arrange
                var value = 1;

                // Act
                Ensure.That(value, "").Not.IsGreaterThan(1, Comparer<int>.Default);
            }

            [TestMethod]
            public void ShouldNotThrowArgumentOutOfRangeExceptionIfValueIsLessUsingComparer()
            {
                // Arrange
                var value = 1;

                // Act
                Ensure.That(value, "").Not.IsGreaterThan(2, Comparer<int>.Default);
            }

            [TestMethod, ExpectedException(typeof(ArgumentOutOfRangeException))]
            public void ShouldThrowAnExceptionIfValueIsGreaterUsingComparer()
            {
                // Arrange
                var value = 1;

                // Act
                Ensure.That(value, "").Not.IsGreaterThan(0, Comparer<int>.Default);
            }

            [TestMethod, ExpectedException(typeof(ArgumentOutOfRangeException))]
            public void ShouldThrowArgumentOutOfRangeExceptionIfNullableValueIsEqual()
            {
                // Arrange
                int? value = 1;

                // Act
                Ensure.That(value, "").IsGreaterThan(1);
            }

            [TestMethod, ExpectedException(typeof(ArgumentOutOfRangeException))]
            public void ShouldThrowArgumentOutOfRangeExceptionIfNullableValueIsEqualUsingComparer()
            {
                // Arrange
                int? value = 1;

                // Act
                Ensure.That(value, "").IsGreaterThan(1, Comparer<int>.Default);
            }

            [TestMethod]
            public void ShouldNotThrowArgumentOutOfRangeExceptionIfNullableValueIsNull()
            {
                // Arrange
                int? value = null;

                // Act
                Ensure.That(value, "").IsGreaterThan(1);
            }

            [TestMethod]
            public void ShouldNotThrowArgumentOutOfRangeExceptionIfNullableValueIsNullUsingComparer()
            {
                // Arrange
                int? value = null;

                // Act
                Ensure.That(value, "").IsGreaterThan(1, Comparer<int>.Default);
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
                Ensure.That(value, "").IsGreaterThanOrEqualTo("");
            }

            [TestMethod, ExpectedException(typeof(ArgumentOutOfRangeException))]
            public void ShouldThrowArgumentOutOfRangeExceptionIfValueIsLess()
            {
                // Arrange
                var value = 1;

                // Act
                Ensure.That(value, "").IsGreaterThanOrEqualTo(2);
            }

            [TestMethod]
            public void ShouldNotThrowAnExceptionIfValueIsGreater()
            {
                // Arrange
                var value = 1;

                // Act
                Ensure.That(value, "").IsGreaterThanOrEqualTo(0);
            }

            [TestMethod]
            public void ShouldNotThrowAnExceptionIfValueIsEqual()
            {
                // Arrange
                var value = 1;

                // Act
                Ensure.That(value, "").IsGreaterThanOrEqualTo(1);
            }

            [TestMethod, ExpectedException(typeof(ArgumentOutOfRangeException))]
            public void ShouldThrowArgumentOutOfRangeExceptionIfValueIsLessUsingComparer()
            {
                // Arrange
                var value = 1;

                // Act
                Ensure.That(value, "").IsGreaterThanOrEqualTo(2, Comparer<int>.Default);
            }

            [TestMethod]
            public void ShouldNotThrowAnExceptionIfValueIsGreaterUsingComparer()
            {
                // Arrange
                var value = 1;

                // Act
                Ensure.That(value, "").IsGreaterThanOrEqualTo(0, Comparer<int>.Default);
            }

            [TestMethod]
            public void ShouldNotThrowAnExceptionIfValueIsEqualUsingComparer()
            {
                // Arrange
                var value = 1;

                // Act
                Ensure.That(value, "").IsGreaterThanOrEqualTo(1, Comparer<int>.Default);
            }

            [TestMethod]
            public void ShouldNotThrowArgumentOutOfRangeExceptionIfValueIsLess()
            {
                // Arrange
                var value = 1;

                // Act
                Ensure.That(value, "").Not.IsGreaterThanOrEqualTo(2);
            }

            [TestMethod, ExpectedException(typeof(ArgumentOutOfRangeException))]
            public void ShouldThrowAnExceptionIfValueIsGreater()
            {
                // Arrange
                var value = 1;

                // Act
                Ensure.That(value, "").Not.IsGreaterThanOrEqualTo(0);
            }

            [TestMethod, ExpectedException(typeof(ArgumentOutOfRangeException))]
            public void ShouldThrowAnExceptionIfValueIsEqual()
            {
                // Arrange
                var value = 1;

                // Act
                Ensure.That(value, "").Not.IsGreaterThanOrEqualTo(1);
            }

            [TestMethod]
            public void ShouldNotThrowArgumentOutOfRangeExceptionIfValueIsLessUsingComparer()
            {
                // Arrange
                var value = 1;

                // Act
                Ensure.That(value, "").Not.IsGreaterThanOrEqualTo(2, Comparer<int>.Default);
            }

            [TestMethod, ExpectedException(typeof(ArgumentOutOfRangeException))]
            public void ShouldThrowAnExceptionIfValueIsGreaterUsingComparer()
            {
                // Arrange
                var value = 1;

                // Act
                Ensure.That(value, "").Not.IsGreaterThanOrEqualTo(0, Comparer<int>.Default);
            }

            [TestMethod, ExpectedException(typeof(ArgumentOutOfRangeException))]
            public void ShoulThrowAnExceptionIfValueIsEqualUsingComparer()
            {
                // Arrange
                var value = 1;

                // Act
                Ensure.That(value, "").Not.IsGreaterThanOrEqualTo(1, Comparer<int>.Default);
            }

            [TestMethod, ExpectedException(typeof(ArgumentOutOfRangeException))]
            public void ShouldThrowArgumentOutOfRangeExceptionIfNullableValueIsEqual()
            {
                // Arrange
                int? value = 1;

                // Act
                Ensure.That(value, "").IsGreaterThanOrEqualTo(2);
            }

            [TestMethod, ExpectedException(typeof(ArgumentOutOfRangeException))]
            public void ShouldThrowArgumentOutOfRangeExceptionIfNullableValueIsEqualUsingComparer()
            {
                // Arrange
                int? value = 1;

                // Act
                Ensure.That(value, "").IsGreaterThanOrEqualTo(2, Comparer<int>.Default);
            }

            [TestMethod]
            public void ShouldNotThrowArgumentOutOfRangeExceptionIfNullableValueIsNull()
            {
                // Arrange
                int? value = null;

                // Act
                Ensure.That(value, "").IsGreaterThanOrEqualTo(1);
            }

            [TestMethod]
            public void ShouldNotThrowArgumentOutOfRangeExceptionIfNullableValueIsNullUsingComparer()
            {
                // Arrange
                int? value = null;

                // Act
                Ensure.That(value, "").IsGreaterThanOrEqualTo(1, Comparer<int>.Default);
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
                Ensure.That(value, "").IsLessThan("");
            }

            [TestMethod, ExpectedException(typeof(ArgumentOutOfRangeException))]
            public void ShouldThrowArgumentOutOfRangeExceptionIfValueIsEqual()
            {
                // Arrange
                var value = 1;

                // Act
                Ensure.That(value, "").IsLessThan(1);
            }

            [TestMethod, ExpectedException(typeof(ArgumentOutOfRangeException))]
            public void ShouldThrowArgumentOutOfRangeExceptionIfValueIsGreater()
            {
                // Arrange
                var value = 1;

                // Act
                Ensure.That(value, "").IsLessThan(0);
            }

            [TestMethod]
            public void ShouldNotThrowAnExceptionIfValueIsLess()
            {
                // Arrange
                var value = 1;

                // Act
                Ensure.That(value, "").IsLessThan(2);
            }

            [TestMethod, ExpectedException(typeof(ArgumentOutOfRangeException))]
            public void ShouldThrowArgumentOutOfRangeExceptionIfValueIsEqualUsingComparer()
            {
                // Arrange
                var value = 1;

                // Act
                Ensure.That(value, "").IsLessThan(1, Comparer<int>.Default);
            }

            [TestMethod, ExpectedException(typeof(ArgumentOutOfRangeException))]
            public void ShouldThrowArgumentOutOfRangeExceptionIfValueIsGreaterUsingComparer()
            {
                // Arrange
                var value = 1;

                // Act
                Ensure.That(value, "").IsLessThan(0, Comparer<int>.Default);
            }

            [TestMethod]
            public void ShouldNotThrowAnExceptionIfValueIsLessUsingComparer()
            {
                // Arrange
                var value = 1;

                // Act
                Ensure.That(value, "").IsLessThan(2, Comparer<int>.Default);
            }

            [TestMethod]
            public void ShouldNotThrowArgumentOutOfRangeExceptionIfValueIsEqual()
            {
                // Arrange
                var value = 1;

                // Act
                Ensure.That(value, "").Not.IsLessThan(1);
            }

            [TestMethod]
            public void ShouldNotThrowArgumentOutOfRangeExceptionIfValueIsGreater()
            {
                // Arrange
                var value = 1;

                // Act
                Ensure.That(value, "").Not.IsLessThan(0);
            }

            [TestMethod, ExpectedException(typeof(ArgumentOutOfRangeException))]
            public void ShouldThrowAnExceptionIfValueIsLess()
            {
                // Arrange
                var value = 1;

                // Act
                Ensure.That(value, "").Not.IsLessThan(2);
            }

            [TestMethod]
            public void ShouldNotThrowArgumentOutOfRangeExceptionIfValueIsEqualUsingComparer()
            {
                // Arrange
                var value = 1;

                // Act
                Ensure.That(value, "").Not.IsLessThan(1, Comparer<int>.Default);
            }

            [TestMethod]
            public void ShouldNotThrowArgumentOutOfRangeExceptionIfValueIsGreaterUsingComparer()
            {
                // Arrange
                var value = 1;

                // Act
                Ensure.That(value, "").Not.IsLessThan(0, Comparer<int>.Default);
            }

            [TestMethod, ExpectedException(typeof(ArgumentOutOfRangeException))]
            public void ShouldThrowAnExceptionIfValueIsLessUsingComparer()
            {
                // Arrange
                var value = 1;

                // Act
                Ensure.That(value, "").Not.IsLessThan(2, Comparer<int>.Default);
            }

            [TestMethod, ExpectedException(typeof(ArgumentOutOfRangeException))]
            public void ShouldThrowArgumentOutOfRangeExceptionIfNullableValueIsEqual()
            {
                // Arrange
                int? value = 1;

                // Act
                Ensure.That(value, "").IsLessThan(1);
            }

            [TestMethod, ExpectedException(typeof(ArgumentOutOfRangeException))]
            public void ShouldThrowArgumentOutOfRangeExceptionIfNullableValueIsEqualUsingComparer()
            {
                // Arrange
                int? value = 1;

                // Act
                Ensure.That(value, "").IsLessThan(1, Comparer<int>.Default);
            }

            [TestMethod]
            public void ShouldNotThrowArgumentOutOfRangeExceptionIfNullableValueIsNull()
            {
                // Arrange
                int? value = null;

                // Act
                Ensure.That(value, "").IsLessThan(1);
            }

            [TestMethod]
            public void ShouldNotThrowArgumentOutOfRangeExceptionIfNullableValueIsNullUsingComparer()
            {
                // Arrange
                int? value = null;

                // Act
                Ensure.That(value, "").IsLessThan(1, Comparer<int>.Default);
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
                Ensure.That(value, "").IsLessThanOrEqualTo("");
            }

            [TestMethod, ExpectedException(typeof(ArgumentOutOfRangeException))]
            public void ShouldThrowArgumentOutOfRangeExceptionIfValueIsGreater()
            {
                // Arrange
                var value = 1;

                // Act
                Ensure.That(value, "").IsLessThanOrEqualTo(0);
            }

            [TestMethod]
            public void ShouldNotThrowAnExceptionIfValueIsLess()
            {
                // Arrange
                var value = 1;

                // Act
                Ensure.That(value, "").IsLessThanOrEqualTo(2);
            }

            [TestMethod]
            public void ShouldNotThrowAnExceptionIfValueIsEqual()
            {
                // Arrange
                var value = 1;

                // Act
                Ensure.That(value, "").IsLessThanOrEqualTo(1);
            }

            [TestMethod, ExpectedException(typeof(ArgumentOutOfRangeException))]
            public void ShouldThrowArgumentOutOfRangeExceptionIfValueIsGreaterUsingComparer()
            {
                // Arrange
                var value = 1;

                // Act
                Ensure.That(value, "").IsLessThanOrEqualTo(0, Comparer<int>.Default);
            }

            [TestMethod]
            public void ShouldNotThrowAnExceptionIfValueIsLessUsingComparer()
            {
                // Arrange
                var value = 1;

                // Act
                Ensure.That(value, "").IsLessThanOrEqualTo(2, Comparer<int>.Default);
            }

            [TestMethod]
            public void ShouldNotThrowAnExceptionIfValueIsEqualUsingComparer()
            {
                // Arrange
                var value = 1;

                // Act
                Ensure.That(value, "").IsLessThanOrEqualTo(1, Comparer<int>.Default);
            }

            [TestMethod]
            public void ShouldNotThrowArgumentOutOfRangeExceptionIfValueIsGreater()
            {
                // Arrange
                var value = 1;

                // Act
                Ensure.That(value, "").Not.IsLessThanOrEqualTo(0);
            }

            [TestMethod, ExpectedException(typeof(ArgumentOutOfRangeException))]
            public void ShouldThrowAnExceptionIfValueIsLess()
            {
                // Arrange
                var value = 1;

                // Act
                Ensure.That(value, "").Not.IsLessThanOrEqualTo(2);
            }

            [TestMethod, ExpectedException(typeof(ArgumentOutOfRangeException))]
            public void ShouldThrowAnExceptionIfValueIsEqual()
            {
                // Arrange
                var value = 1;

                // Act
                Ensure.That(value, "").Not.IsLessThanOrEqualTo(1);
            }

            [TestMethod]
            public void ShouldNotThrowArgumentOutOfRangeExceptionIfValueIsGreaterUsingComparer()
            {
                // Arrange
                var value = 1;

                // Act
                Ensure.That(value, "").Not.IsLessThanOrEqualTo(0, Comparer<int>.Default);
            }

            [TestMethod, ExpectedException(typeof(ArgumentOutOfRangeException))]
            public void ShouldThrowAnExceptionIfValueIsLessUsingComparer()
            {
                // Arrange
                var value = 1;

                // Act
                Ensure.That(value, "").Not.IsLessThanOrEqualTo(2, Comparer<int>.Default);
            }

            [TestMethod, ExpectedException(typeof(ArgumentOutOfRangeException))]
            public void ShouldThrowAnExceptionIfValueIsEqualUsingComparer()
            {
                // Arrange
                var value = 1;

                // Act
                Ensure.That(value, "").Not.IsLessThanOrEqualTo(1, Comparer<int>.Default);
            }

            [TestMethod, ExpectedException(typeof(ArgumentOutOfRangeException))]
            public void ShouldThrowArgumentOutOfRangeExceptionIfNullableValueIsEqual()
            {
                // Arrange
                int? value = 1;

                // Act
                Ensure.That(value, "").IsLessThanOrEqualTo(0);
            }

            [TestMethod, ExpectedException(typeof(ArgumentOutOfRangeException))]
            public void ShouldThrowArgumentOutOfRangeExceptionIfNullableValueIsEqualUsingComparer()
            {
                // Arrange
                int? value = 1;

                // Act
                Ensure.That(value, "").IsLessThanOrEqualTo(0, Comparer<int>.Default);
            }

            [TestMethod]
            public void ShouldNotThrowArgumentOutOfRangeExceptionIfNullableValueIsNull()
            {
                // Arrange
                int? value = null;

                // Act
                Ensure.That(value, "").IsLessThanOrEqualTo(1);
            }

            [TestMethod]
            public void ShouldNotThrowArgumentOutOfRangeExceptionIfNullableValueIsNullUsingComparer()
            {
                // Arrange
                int? value = null;

                // Act
                Ensure.That(value, "").IsLessThanOrEqualTo(1, Comparer<int>.Default);
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
                Ensure.That(value, "").IsEqualTo("");
            }

            [TestMethod, ExpectedException(typeof(ArgumentException))]
            public void ShouldThrowArgumentExceptionIfValueIsGreater()
            {
                // Arrange
                var value = 1;

                // Act
                Ensure.That(value, "").IsEqualTo(0);
            }

            [TestMethod, ExpectedException(typeof(ArgumentException))]
            public void ShouldThrowArgumentExceptionIfValueIsLess()
            {
                // Arrange
                var value = 1;

                // Act
                Ensure.That(value, "").IsEqualTo(2);
            }

            [TestMethod]
            public void ShouldNotThrowAnExceptionIfValueIsEqual()
            {
                // Arrange
                var value = 1;

                // Act
                Ensure.That(value, "").IsEqualTo(1);
            }

            [TestMethod, ExpectedException(typeof(ArgumentException))]
            public void ShouldThrowArgumentExceptionIfValueIsGreaterUsingComparer()
            {
                // Arrange
                var value = 1;

                // Act
                Ensure.That(value, "").IsEqualTo(0, EqualityComparer<int>.Default);
            }

            [TestMethod, ExpectedException(typeof(ArgumentException))]
            public void ShouldThrowArgumentExceptionIfValueIsLessUsingComparer()
            {
                // Arrange
                var value = 1;

                // Act
                Ensure.That(value, "").IsEqualTo(2, EqualityComparer<int>.Default);
            }

            [TestMethod]
            public void ShouldNotThrowAnExceptionIfValueIsEqualUsingComparer()
            {
                // Arrange
                var value = 1;

                // Act
                Ensure.That(value, "").IsEqualTo(1, EqualityComparer<int>.Default);
            }

            [TestMethod]
            public void ShouldNotThrowArgumentExceptionIfValueIsGreater()
            {
                // Arrange
                var value = 1;

                // Act
                Ensure.That(value, "").Not.IsEqualTo(0);
            }

            [TestMethod]
            public void ShouldNotThrowArgumentExceptionIfValueIsLess()
            {
                // Arrange
                var value = 1;

                // Act
                Ensure.That(value, "").Not.IsEqualTo(2);
            }

            [TestMethod, ExpectedException(typeof(ArgumentException))]
            public void ShouldThrowAnExceptionIfValueIsEqual()
            {
                // Arrange
                var value = 1;

                // Act
                Ensure.That(value, "").Not.IsEqualTo(1);
            }

            [TestMethod]
            public void ShouldNotThrowArgumentExceptionIfValueIsGreaterUsingComparer()
            {
                // Arrange
                var value = 1;

                // Act
                Ensure.That(value, "").Not.IsEqualTo(0, EqualityComparer<int>.Default);
            }

            [TestMethod]
            public void ShouldNotThrowArgumentExceptionIfValueIsLessUsingComparer()
            {
                // Arrange
                var value = 1;

                // Act
                Ensure.That(value, "").Not.IsEqualTo(2, EqualityComparer<int>.Default);
            }

            [TestMethod, ExpectedException(typeof(ArgumentException))]
            public void ShouldThrowAnExceptionIfValueIsEqualUsingComparer()
            {
                // Arrange
                var value = 1;

                // Act
                Ensure.That(value, "").Not.IsEqualTo(1, EqualityComparer<int>.Default);
            }

            [TestMethod, ExpectedException(typeof(ArgumentException))]
            public void ShouldThrowArgumentExceptionIfNullableValueIsGreater()
            {
                // Arrange
                int? value = 1;

                // Act
                Ensure.That(value, "").IsEqualTo(0);
            }

            [TestMethod, ExpectedException(typeof(ArgumentException))]
            public void ShouldThrowArgumentExceptionIfNullableValueIsGreaterUsingComparer()
            {
                // Arrange
                int? value = 1;

                // Act
                Ensure.That(value, "").IsEqualTo(0, EqualityComparer<int>.Default);
            }

            [TestMethod]
            public void ShouldNotThrowArgumentOutOfRangeExceptionIfNullableValueIsNull()
            {
                // Arrange
                int? value = null;

                // Act
                Ensure.That(value, "").IsEqualTo(1);
            }

            [TestMethod]
            public void ShouldNotThrowArgumentOutOfRangeExceptionIfNullableValueIsNullUsingComparer()
            {
                // Arrange
                int? value = null;

                // Act
                Ensure.That(value, "").IsEqualTo(1, EqualityComparer<int>.Default);
            }
        }


















        [TestClass]
        public class TheIsBetweenThanMethod
        {
            [TestMethod, ExpectedException(typeof(InvalidOperationException))]
            public void ShouldThrowInvalidOperationExceptionIfValueIsNull()
            {
                // Arrange
                string value = null;

                // Act
                Ensure.That(value, "").IsBetween("", "");
            }

            [TestMethod]
            public void ShouldNotThrowExceptionIfValueIsBetween()
            {
                // Arrange
                int value = 2;

                // Act
                Ensure.That(value, "").IsBetween(1, 3);
            }

            [TestMethod]
            public void ShouldNotThrowExceptionIfValueIsEqualToMinValue()
            {
                // Arrange
                int value = 1;

                // Act
                Ensure.That(value, "").IsBetween(1, 3);
            }

            [TestMethod]
            public void ShouldNotThrowExceptionIfValueIsEqualToMaxValue()
            {
                // Arrange
                int value = 3;

                // Act
                Ensure.That(value, "").IsBetween(1, 3);
            }

            [TestMethod, ExpectedException(typeof(ArgumentOutOfRangeException))]
            public void ShouldThrowExceptionIfValueIsLessThanMinValue()
            {
                // Arrange
                int value = 0;

                // Act
                Ensure.That(value, "").IsBetween(1, 3);
            }

            [TestMethod, ExpectedException(typeof(ArgumentOutOfRangeException))]
            public void ShouldThrowExceptionIfValueIsBetween()
            {
                // Arrange
                int value = 2;

                // Act
                Ensure.That(value, "").Not.IsBetween(1, 3);
            }

            [TestMethod, ExpectedException(typeof(ArgumentOutOfRangeException))]
            public void ShouldThrowExceptionIfValueIsEqualToMinValue()
            {
                // Arrange
                int value = 1;

                // Act
                Ensure.That(value, "").Not.IsBetween(1, 3);
            }

            [TestMethod, ExpectedException(typeof(ArgumentOutOfRangeException))]
            public void ShouldThrowExceptionIfValueIsEqualToMaxValue()
            {
                // Arrange
                int value = 3;

                // Act
                Ensure.That(value, "").Not.IsBetween(1, 3);
            }

            [TestMethod]
            public void ShouldNotThrowExceptionIfValueIsLessThanMinValue()
            {
                // Arrange
                int value = 0;

                // Act
                Ensure.That(value, "").Not.IsBetween(1, 3);
            }

            [TestMethod, ExpectedException(typeof(ArgumentOutOfRangeException))]
            public void ShouldThrowExceptionIfValueIsGreaterThanMaxValue()
            {
                // Arrange
                int value = 4;

                // Act
                Ensure.That(value, "").IsBetween(1, 3);
            }

            [TestMethod]
            public void ShouldNotThrowExceptionIfValueIsBetweenUsingComparer()
            {
                // Arrange
                int value = 2;

                // Act
                Ensure.That(value, "").IsBetween(1, 3, Comparer<int>.Default);
            }

            [TestMethod]
            public void ShouldNotThrowExceptionIfValueIsEqualToMinValueUsingComparer()
            {
                // Arrange
                int value = 1;

                // Act
                Ensure.That(value, "").IsBetween(1, 3, Comparer<int>.Default);
            }

            [TestMethod]
            public void ShouldNotThrowExceptionIfValueIsEqualToMaxValueUsingComparer()
            {
                // Arrange
                int value = 3;

                // Act
                Ensure.That(value, "").IsBetween(1, 3, Comparer<int>.Default);
            }

            [TestMethod, ExpectedException(typeof(ArgumentOutOfRangeException))]
            public void ShouldThrowExceptionIfValueIsLessThanMinValueUsingComparer()
            {
                // Arrange
                int value = 0;

                // Act
                Ensure.That(value, "").IsBetween(1, 3, Comparer<int>.Default);
            }

            [TestMethod, ExpectedException(typeof(ArgumentOutOfRangeException))]
            public void ShouldThrowExceptionIfValueIsBetweenUsingComparer()
            {
                // Arrange
                int value = 2;

                // Act
                Ensure.That(value, "").Not.IsBetween(1, 3, Comparer<int>.Default);
            }

            [TestMethod, ExpectedException(typeof(ArgumentOutOfRangeException))]
            public void ShouldThrowExceptionIfValueIsEqualToMinValueUsingComparer()
            {
                // Arrange
                int value = 1;

                // Act
                Ensure.That(value, "").Not.IsBetween(1, 3, Comparer<int>.Default);
            }

            [TestMethod, ExpectedException(typeof(ArgumentOutOfRangeException))]
            public void ShouldThrowExceptionIfValueIsEqualToMaxValueUsingComparer()
            {
                // Arrange
                int value = 3;

                // Act
                Ensure.That(value, "").Not.IsBetween(1, 3, Comparer<int>.Default);
            }

            [TestMethod]
            public void ShouldNotThrowExceptionIfValueIsLessThanMinValueUsingComparer()
            {
                // Arrange
                int value = 0;

                // Act
                Ensure.That(value, "").Not.IsBetween(1, 3, Comparer<int>.Default);
            }

            [TestMethod, ExpectedException(typeof(ArgumentOutOfRangeException))]
            public void ShouldThrowExceptionIfValueIsGreaterThanMaxValueUsingComparer()
            {
                // Arrange
                int value = 4;

                // Act
                Ensure.That(value, "").IsBetween(1, 3, Comparer<int>.Default);
            }

















            [TestMethod]
            public void ShouldNotThrowExceptionIfNullableValueIsBetween()
            {
                // Arrange
                int? value = 2;

                // Act
                Ensure.That(value, "").IsBetween(1, 3);
            }

            [TestMethod]
            public void ShouldNotThrowExceptionIfNullableValueIsEqualToMinValue()
            {
                // Arrange
                int? value = 1;

                // Act
                Ensure.That(value, "").IsBetween(1, 3);
            }

            [TestMethod]
            public void ShouldNotThrowExceptionIfNullableValueIsEqualToMaxValue()
            {
                // Arrange
                int? value = 3;

                // Act
                Ensure.That(value, "").IsBetween(1, 3);
            }

            [TestMethod, ExpectedException(typeof(ArgumentOutOfRangeException))]
            public void ShouldThrowExceptionIfNullableValueIsLessThanMinValue()
            {
                // Arrange
                int? value = 0;

                // Act
                Ensure.That(value, "").IsBetween(1, 3);
            }

            [TestMethod, ExpectedException(typeof(ArgumentOutOfRangeException))]
            public void ShouldThrowExceptionIfNullableValueIsBetween()
            {
                // Arrange
                int? value = 2;

                // Act
                Ensure.That(value, "").Not.IsBetween(1, 3);
            }

            [TestMethod, ExpectedException(typeof(ArgumentOutOfRangeException))]
            public void ShouldThrowExceptionIfNullableValueIsEqualToMinValue()
            {
                // Arrange
                int? value = 1;

                // Act
                Ensure.That(value, "").Not.IsBetween(1, 3);
            }

            [TestMethod, ExpectedException(typeof(ArgumentOutOfRangeException))]
            public void ShouldThrowExceptionIfNullableValueIsEqualToMaxValue()
            {
                // Arrange
                int? value = 3;

                // Act
                Ensure.That(value, "").Not.IsBetween(1, 3);
            }

            [TestMethod]
            public void ShouldNotThrowExceptionIfNullableValueIsLessThanMinValue()
            {
                // Arrange
                int? value = 0;

                // Act
                Ensure.That(value, "").Not.IsBetween(1, 3);
            }

            [TestMethod, ExpectedException(typeof(ArgumentOutOfRangeException))]
            public void ShouldThrowExceptionIfNullableValueIsGreaterThanMaxValue()
            {
                // Arrange
                int? value = 4;

                // Act
                Ensure.That(value, "").IsBetween(1, 3);
            }

            [TestMethod]
            public void ShouldNotThrowExceptionIfNullableValueIsBetweenUsingComparer()
            {
                // Arrange
                int? value = 2;

                // Act
                Ensure.That(value, "").IsBetween(1, 3, Comparer<int>.Default);
            }

            [TestMethod]
            public void ShouldNotThrowExceptionIfNullableValueIsEqualToMinValueUsingComparer()
            {
                // Arrange
                int? value = 1;

                // Act
                Ensure.That(value, "").IsBetween(1, 3, Comparer<int>.Default);
            }

            [TestMethod]
            public void ShouldNotThrowExceptionIfNullableValueIsEqualToMaxValueUsingComparer()
            {
                // Arrange
                int? value = 3;

                // Act
                Ensure.That(value, "").IsBetween(1, 3, Comparer<int>.Default);
            }

            [TestMethod, ExpectedException(typeof(ArgumentOutOfRangeException))]
            public void ShouldThrowExceptionIfNullableValueIsLessThanMinValueUsingComparer()
            {
                // Arrange
                int? value = 0;

                // Act
                Ensure.That(value, "").IsBetween(1, 3, Comparer<int>.Default);
            }

            [TestMethod, ExpectedException(typeof(ArgumentOutOfRangeException))]
            public void ShouldThrowExceptionIfNullableValueIsBetweenUsingComparer()
            {
                // Arrange
                int? value = 2;

                // Act
                Ensure.That(value, "").Not.IsBetween(1, 3, Comparer<int>.Default);
            }

            [TestMethod, ExpectedException(typeof(ArgumentOutOfRangeException))]
            public void ShouldThrowExceptionIfNullableValueIsEqualToMinValueUsingComparer()
            {
                // Arrange
                int? value = 1;

                // Act
                Ensure.That(value, "").Not.IsBetween(1, 3, Comparer<int>.Default);
            }

            [TestMethod, ExpectedException(typeof(ArgumentOutOfRangeException))]
            public void ShouldThrowExceptionIfNullableValueIsEqualToMaxValueUsingComparer()
            {
                // Arrange
                int? value = 3;

                // Act
                Ensure.That(value, "").Not.IsBetween(1, 3, Comparer<int>.Default);
            }

            [TestMethod]
            public void ShouldNotThrowExceptionIfNullableValueIsLessThanMinValueUsingComparer()
            {
                // Arrange
                int? value = 0;

                // Act
                Ensure.That(value, "").Not.IsBetween(1, 3, Comparer<int>.Default);
            }

            [TestMethod, ExpectedException(typeof(ArgumentOutOfRangeException))]
            public void ShouldThrowExceptionIfNullableValueIsGreaterThanMaxValueUsingComparer()
            {
                // Arrange
                int? value = 4;

                // Act
                Ensure.That(value, "").IsBetween(1, 3, Comparer<int>.Default);
            }
        }
    }
}
