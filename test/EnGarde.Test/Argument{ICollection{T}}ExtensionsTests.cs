// Copyright (c) Arjen Post. See License.txt in the project root for license information.

using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Reflection;

namespace EnGarde.Test
{
    [TestClass]
    public class ArgumentICollectionExtensionsTests
    {
        [TestClass]
        public class TheIsNullMethod
        {
            [TestMethod]
            public void ShouldNotThrowExceptionIfValueContainsItem()
            {
                // Arrange
                var value = new List<int>() { 0, 1, 2 };

                // Act
                Ensure.That(value, "").Contains(1);
            }

            [TestMethod, ExpectedException(typeof(ArgumentException))]
            public void ShouldThrowExceptionIfValueContainsItem()
            {
                // Arrange
                var value = new List<int>() { 0, 1, 2 };

                // Act
                Ensure.That(value, "").Not.Contains(1);
            }

            [TestMethod]
            public void ShouldNotThrowExceptionIfValueDoesNotContainItem()
            {
                // Arrange
                var value = new List<int>() { 0, 1, 2 };

                // Act
                Ensure.That(value, "").Not.Contains(4);
            }

            [TestMethod, ExpectedException(typeof(ArgumentException))]
            public void ShouldThrowExceptionIfValueDoesNotContainItem()
            {
                // Arrange
                var value = new List<int>() { 0, 1, 2 };

                // Act
                Ensure.That(value, "").Contains(4);
            }
        }

        [TestClass]
        public class TheIsEmptyMethod
        {
            [TestMethod]
            public void ShouldNotThrowExceptionIfValueIsEmpty()
            {
                // Arrange
                var value = new List<int>();

                // Act
                Ensure.That(value, "").IsEmpty();
            }

            [TestMethod, ExpectedException(typeof(ArgumentException))]
            public void ShouldThrowExceptionIfValueIsEmpty()
            {
                // Arrange
                var value = new List<int>();

                // Act
                Ensure.That(value, "").Not.IsEmpty();
            }

            [TestMethod]
            public void ShouldNotThrowExceptionIfValueIsNotEmpty()
            {
                // Arrange
                var value = new List<int>() { 0, 1, 2 };

                // Act
                Ensure.That(value, "").Not.IsEmpty();
            }

            [TestMethod, ExpectedException(typeof(ArgumentException))]
            public void ShouldThrowExceptionIfValueIsNotEmpty()
            {
                // Arrange
                var value = new List<int>() { 0, 1, 2 };

                // Act
                Ensure.That(value, "").IsEmpty();
            }
        }
    }
}
