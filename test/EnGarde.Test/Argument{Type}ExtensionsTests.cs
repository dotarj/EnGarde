// Copyright (c) Arjen Post. See License.txt in the project root for license information.

using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Reflection;

namespace EnGarde.Test
{
    [TestClass]
    public class ArgumentTypeExtensionsTests
    {
        [TestClass]
        public class TheIsAssignableFromMethod
        {
            [TestMethod]
            public void ShouldNotThrowExceptionIfArgumentTypeIsAssignableFromOtherType()
            {
                // Arrange
                var value = typeof(Exception);

                // Act
                Ensure.That(value, "").IsAssignableFrom(typeof(ArgumentException));
            }

            [TestMethod, ExpectedException(typeof(ArgumentException))]
            public void ShouldThrowExceptionIfArgumentTypeIsNotAssignableFromOtherType()
            {
                // Arrange
                var value = typeof(Exception);

                // Act
                Ensure.That(value, "").Not.IsAssignableFrom(typeof(ArgumentException));
            }

            [TestMethod]
            public void ShouldNotThrowExceptionIfArgumentTypeIsNotAssignableFromOtherType()
            {
                // Arrange
                var value = typeof(InvalidOperationException);

                // Act
                Ensure.That(value, "").Not.IsAssignableFrom(typeof(ArgumentException));
            }
        }

        [TestClass]
        public class TheIsSubclassOfMethod
        {
            [TestMethod]
            public void ShouldNotThrowExceptionIfArgumentTypeIsSubclassOfOtherType()
            {
                // Arrange
                var value = typeof(ArgumentException);

                // Act
                Ensure.That(value, "").IsSubclassOf(typeof(Exception));
            }

            [TestMethod, ExpectedException(typeof(ArgumentException))]
            public void ShouldThrowExceptionIfArgumentTypeIsNotSubclassOfOtherType()
            {
                // Arrange
                var value = typeof(ArgumentException);

                // Act
                Ensure.That(value, "").Not.IsSubclassOf(typeof(Exception));
            }

            [TestMethod]
            public void ShouldNotThrowExceptionIfArgumentTypeIsNotSubclassOfOtherType()
            {
                // Arrange
                var value = typeof(InvalidOperationException);

                // Act
                Ensure.That(value, "").Not.IsSubclassOf(typeof(ArgumentException));
            }
        }
    }
}
