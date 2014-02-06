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
                // Act
                Ensure.That(typeof(Exception), "").IsAssignableFrom(typeof(ArgumentException));
            }

            [TestMethod, ExpectedException(typeof(ArgumentException))]
            public void ShouldThrowExceptionIfArgumentTypeIsNotAssignableFromOtherType()
            {
                // Act
                Ensure.That(typeof(Exception), "").Not.IsAssignableFrom(typeof(ArgumentException));
            }

            [TestMethod]
            public void ShouldNotThrowExceptionIfArgumentTypeIsNotAssignableFromOtherType()
            {
                // Act
                Ensure.That(typeof(InvalidOperationException), "").Not.IsAssignableFrom(typeof(ArgumentException));
            }
        }

        [TestClass]
        public class TheIsSubclassOfMethod
        {
            [TestMethod]
            public void ShouldNotThrowExceptionIfArgumentTypeIsSubclassOfOtherType()
            {
                // Act
                Ensure.That(typeof(ArgumentException), "").IsSubclassOf(typeof(Exception));
            }

            [TestMethod, ExpectedException(typeof(ArgumentException))]
            public void ShouldThrowExceptionIfArgumentTypeIsNotSubclassOfOtherType()
            {
                // Act
                Ensure.That(typeof(ArgumentException), "").Not.IsSubclassOf(typeof(Exception));
            }

            [TestMethod]
            public void ShouldNotThrowExceptionIfArgumentTypeIsNotSubclassOfOtherType()
            {
                // Act
                Ensure.That(typeof(InvalidOperationException), "").Not.IsSubclassOf(typeof(ArgumentException));
            }
        }
    }
}
