using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Reflection;

namespace EnGarde.Test
{
    [TestClass]
    public class ArgumentClassExtensionsTests
    {
        [TestClass]
        public class TheIsNullMethod
        {
            [TestMethod, ExpectedException(typeof(ArgumentNullException))]
            public void ShouldThrowExceptionIfArgumentIsNull()
            {
                // Act
                ArgumentExtensions.IsNull<List<int>>(null);
            }

            [TestMethod, ExpectedException(typeof(ArgumentNullException))]
            public void ShouldThrowExceptionIfValueIsNull()
            {
                // Arrange
                List<int> value = null;

                // Act
                Argument.Assert(value, "").Not().IsNull();
            }
        }
    }
}
