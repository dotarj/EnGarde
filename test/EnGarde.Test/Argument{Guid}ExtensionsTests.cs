// Copyright (c) Arjen Post. See License.txt in the project root for license information.

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
                Ensure.That(value, "").IsEmpty();
            }

            [TestMethod, ExpectedException(typeof(ArgumentException))]
            public void ShouldThrowArgumentExceptionIfValueIsNotEmpty()
            {
                // Arrange
                var value = Guid.NewGuid();

                // Act
                Ensure.That(value, "").IsEmpty();
            }

            [TestMethod, ExpectedException(typeof(ArgumentException))]
            public void ShouldThrowArgumentExceptionIfValueIsEmpty()
            {
                // Arrange
                var value = Guid.Empty;

                // Act
                Ensure.That(value, "").Not.IsEmpty();
            }

            [TestMethod]
            public void ShouldNotThrowArgumentExceptionIfValueIsNotEmpty()
            {
                // Arrange
                var value = Guid.NewGuid();

                // Act
                Ensure.That(value, "").Not.IsEmpty();
            }

            [TestMethod, ExpectedException(typeof(ArgumentException))]
            public void ShouldThrowArgumentExceptionIfNullableValueIsEmpty()
            {
                // Arrange
                var value = (Guid?)Guid.Empty;

                // Act
                Ensure.That(value, "").Not.IsEmpty();
            }

            [TestMethod]
            public void ShouldNotThrowExceptionIfNullableValueNull()
            {
                // Arrange
                Guid? value = null;

                // Act
                Ensure.That(value, "").Not.IsEmpty();
            }
        }
    }
}
