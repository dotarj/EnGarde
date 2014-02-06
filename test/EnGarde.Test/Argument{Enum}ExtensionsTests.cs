// Copyright (c) Arjen Post. See License.txt in the project root for license information.

using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.ComponentModel;
using System.Reflection;

namespace EnGarde.Test
{
    [TestClass]
    public class ArgumentEnumExtensionsTests
    {
        [TestClass]
        public class TheIsDefinedMethod
        {
            [TestMethod]
            public void ShouldNotThrowExceptionIfValueIsNotValid()
            {
                // Arrange
                var value = (StringSplitOptions)int.MaxValue;

                // Act
                Ensure.That(value, "").Not.IsDefined();
            }

            [TestMethod, ExpectedException(typeof(ArgumentException))]
            public void ShouldThrowArgumentExceptionIfValueIsValid()
            {
                // Arrange
                var value = StringSplitOptions.RemoveEmptyEntries;

                // Act
                Ensure.That(value, "").Not.IsDefined();
            }

            [TestMethod, ExpectedException(typeof(InvalidOperationException))]
            public void ShouldThrowInvalidOperationExceptionIfValueIsNotEnum()
            {
                // Arrange
                var value = 1;

                // Act
                Ensure.That(value, "").Not.IsDefined();
            }

            [TestMethod, ExpectedException(typeof(InvalidEnumArgumentException))]
            public void ShouldThrowInvalidEnumArgumentExceptionIfValueIsNotValid()
            {
                // Arrange
                var value = (StringSplitOptions)int.MaxValue;

                // Act
                Ensure.That(value, "").IsDefined();
            }

            [TestMethod]
            public void ShouldNotThrowArgumentExceptionIfValueIsValid()
            {
                // Arrange
                var value = StringSplitOptions.RemoveEmptyEntries;

                // Act
                Ensure.That(value, "").IsDefined();
            }

            [TestMethod, ExpectedException(typeof(InvalidEnumArgumentException))]
            public void ShouldThrowInvalidEnumArgumentExceptionIfNullableValueIsNotValid()
            {
                // Arrange
                var value = (StringSplitOptions?)int.MaxValue;

                // Act
                Ensure.That(value, "").IsDefined();
            }

            [TestMethod, ExpectedException(typeof(InvalidOperationException))]
            public void ShouldThrowInvalidOperationExceptionIfNullableValueIsNotEnum()
            {
                // Arrange
                int? value = 1;

                // Act
                Ensure.That(value, "").Not.IsDefined();
            }

            [TestMethod]
            public void ShouldNotThrowExceptionIfNullableValueIsNull()
            {
                // Arrange
                StringSplitOptions? value = null;

                // Act
                Ensure.That(value, "").IsDefined();
            }
        }

        [TestClass]
        public class TheHasFlagMethod
        {
            [TestMethod]
            public void ShouldNotThrowExceptionIfValueIsNotValid()
            {
                // Arrange
                var value = MethodAttributes.Assembly;

                // Act
                Ensure.That(value, "").Not.HasFlag(MethodAttributes.Abstract);
            }

            [TestMethod, ExpectedException(typeof(ArgumentException))]
            public void ShouldThrowArgumentExceptionIfValueIsValid()
            {
                // Arrange
                var value = MethodAttributes.Assembly;

                // Act
                Ensure.That(value, "").Not.HasFlag(MethodAttributes.Assembly);
            }

            [TestMethod, ExpectedException(typeof(InvalidOperationException))]
            public void ShouldThrowInvalidOperationExceptionIfValueIsNotEnum()
            {
                // Arrange
                var value = 1;

                // Act
                Ensure.That(value, "").Not.HasFlag(2);
            }

            [TestMethod, ExpectedException(typeof(ArgumentException))]
            public void ShouldThrowArgumentExceptionIfValueIsNotValid()
            {
                // Arrange
                var value = MethodAttributes.Abstract;

                // Act
                Ensure.That(value, "").HasFlag(MethodAttributes.Assembly);
            }

            [TestMethod]
            public void ShouldNotThrowArgumentExceptionIfValueIsValid()
            {
                // Arrange
                var value = MethodAttributes.Abstract;

                // Act
                Ensure.That(value, "").HasFlag(MethodAttributes.Abstract);
            }

            [TestMethod, ExpectedException(typeof(ArgumentException))]
            public void ShouldThrowArgumentExceptionIfNullableValueIsNotValid()
            {
                // Arrange
                MethodAttributes? value = MethodAttributes.Abstract;

                // Act
                Ensure.That(value, "").HasFlag(MethodAttributes.Assembly);
            }

            [TestMethod, ExpectedException(typeof(InvalidOperationException))]
            public void ShouldThrowInvalidOperationExceptionIfNullableValueIsNotEnum()
            {
                // Arrange
                int? value = 1;

                // Act
                Ensure.That(value, "").Not.HasFlag(2);
            }

            [TestMethod]
            public void ShouldNotThrowArgumentExceptionIfNullableValueIsNull()
            {
                // Arrange
                MethodAttributes? value = null;

                // Act
                Ensure.That(value, "").HasFlag(MethodAttributes.Abstract);
            }
        }
    }
}
