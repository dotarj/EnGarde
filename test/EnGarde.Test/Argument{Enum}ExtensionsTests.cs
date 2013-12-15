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
                Argument.Assert(value, "").Not().IsDefined();
            }

            [TestMethod, ExpectedException(typeof(ArgumentException))]
            public void ShouldThrowArgumentExceptionIfValueIsValid()
            {
                // Arrange
                var value = StringSplitOptions.RemoveEmptyEntries;

                // Act
                Argument.Assert(value, "").Not().IsDefined();
            }

            [TestMethod, ExpectedException(typeof(InvalidOperationException))]
            public void ShouldThrowInvalidOperationExceptionIfValueIsNotEnum()
            {
                // Arrange
                var value = 1;

                // Act
                Argument.Assert(value, "").Not().IsDefined();
            }

            [TestMethod, ExpectedException(typeof(InvalidEnumArgumentException))]
            public void ShouldThrowInvalidEnumArgumentExceptionIfValueIsNotValid()
            {
                // Arrange
                var value = (StringSplitOptions)int.MaxValue;

                // Act
                Argument.Assert(value, "").IsDefined();
            }

            [TestMethod]
            public void ShouldNotThrowArgumentExceptionIfValueIsValid()
            {
                // Arrange
                var value = StringSplitOptions.RemoveEmptyEntries;

                // Act
                Argument.Assert(value, "").IsDefined();
            }

            [TestMethod, ExpectedException(typeof(InvalidEnumArgumentException))]
            public void ShouldThrowInvalidEnumArgumentExceptionIfNullableValueIsNotValid()
            {
                // Arrange
                var value = (StringSplitOptions?)int.MaxValue;

                // Act
                Argument.Assert(value, "").IsDefined();
            }

            [TestMethod, ExpectedException(typeof(InvalidOperationException))]
            public void ShouldThrowInvalidOperationExceptionIfNullableValueIsNotEnum()
            {
                // Arrange
                int? value = 1;

                // Act
                Argument.Assert(value, "").Not().IsDefined();
            }

            [TestMethod]
            public void ShouldNotThrowExceptionIfNullableValueIsNull()
            {
                // Arrange
                StringSplitOptions? value = null;

                // Act
                Argument.Assert(value, "").IsDefined();
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
                Argument.Assert(value, "").Not().HasFlag(MethodAttributes.Abstract);
            }

            [TestMethod, ExpectedException(typeof(ArgumentException))]
            public void ShouldThrowArgumentExceptionIfValueIsValid()
            {
                // Arrange
                var value = MethodAttributes.Assembly;

                // Act
                Argument.Assert(value, "").Not().HasFlag(MethodAttributes.Assembly);
            }

            [TestMethod, ExpectedException(typeof(InvalidOperationException))]
            public void ShouldThrowInvalidOperationExceptionIfValueIsNotEnum()
            {
                // Arrange
                var value = 1;

                // Act
                Argument.Assert(value, "").Not().HasFlag(2);
            }

            [TestMethod, ExpectedException(typeof(ArgumentException))]
            public void ShouldThrowArgumentExceptionIfValueIsNotValid()
            {
                // Arrange
                var value = MethodAttributes.Abstract;

                // Act
                Argument.Assert(value, "").HasFlag(MethodAttributes.Assembly);
            }

            [TestMethod]
            public void ShouldNotThrowArgumentExceptionIfValueIsValid()
            {
                // Arrange
                var value = MethodAttributes.Abstract;

                // Act
                Argument.Assert(value, "").HasFlag(MethodAttributes.Abstract);
            }

            [TestMethod, ExpectedException(typeof(ArgumentException))]
            public void ShouldThrowArgumentExceptionIfNullableValueIsNotValid()
            {
                // Arrange
                MethodAttributes? value = MethodAttributes.Abstract;

                // Act
                Argument.Assert(value, "").HasFlag(MethodAttributes.Assembly);
            }

            [TestMethod, ExpectedException(typeof(InvalidOperationException))]
            public void ShouldThrowInvalidOperationExceptionIfNullableValueIsNotEnum()
            {
                // Arrange
                int? value = 1;

                // Act
                Argument.Assert(value, "").Not().HasFlag(2);
            }

            [TestMethod]
            public void ShouldNotThrowArgumentExceptionIfNullableValueIsNull()
            {
                // Arrange
                MethodAttributes? value = null;

                // Act
                Argument.Assert(value, "").HasFlag(MethodAttributes.Abstract);
            }
        }
    }
}
