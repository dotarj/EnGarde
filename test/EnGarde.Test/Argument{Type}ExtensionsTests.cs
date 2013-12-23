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
                Argument.Assert(typeof(Exception), "").IsAssignableFrom(typeof(ArgumentException));
            }

            [TestMethod, ExpectedException(typeof(ArgumentException))]
            public void ShouldThrowExceptionIfArgumentTypeIsNotAssignableFromOtherType()
            {
                // Act
                Argument.Assert(typeof(Exception), "").Not().IsAssignableFrom(typeof(ArgumentException));
            }

            [TestMethod]
            public void ShouldNotThrowExceptionIfArgumentTypeIsNotAssignableFromOtherType()
            {
                // Act
                Argument.Assert(typeof(InvalidOperationException), "").Not().IsAssignableFrom(typeof(ArgumentException));
            }
        }

        [TestClass]
        public class TheIsSubclassOfMethod
        {
            [TestMethod]
            public void ShouldNotThrowExceptionIfArgumentTypeIsSubclassOfOtherType()
            {
                // Act
                Argument.Assert(typeof(ArgumentException), "").IsSubclassOf(typeof(Exception));
            }

            [TestMethod, ExpectedException(typeof(ArgumentException))]
            public void ShouldThrowExceptionIfArgumentTypeIsNotSubclassOfOtherType()
            {
                // Act
                Argument.Assert(typeof(ArgumentException), "").Not().IsSubclassOf(typeof(Exception));
            }

            [TestMethod]
            public void ShouldNotThrowExceptionIfArgumentTypeIsNotSubclassOfOtherType()
            {
                // Act
                Argument.Assert(typeof(InvalidOperationException), "").Not().IsSubclassOf(typeof(ArgumentException));
            }
        }
    }
}
