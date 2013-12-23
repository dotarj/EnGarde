using System;
using System.Collections.Concurrent;
using System.Diagnostics;
using System.Linq.Expressions;
using System.Reflection;

namespace EnGarde
{
    /// <summary>
    /// Contains a static method for validating an argument value.
    /// </summary>
    public static class Argument
    {
        private static ConcurrentDictionary<MemberInfo, Delegate> selectors = new ConcurrentDictionary<MemberInfo, Delegate>();
        
        /// <summary>
        /// Creates an <see cref="Argument{T}"/> for validating an argument value.
        /// </summary>
        /// <typeparam name="T">The argument type.</typeparam>
        /// <param name="value">The argument value.</param>
        /// <param name="parameterName">The name of the parameter.</param>
        /// <returns>A wrapper object containing the actual argument value.</returns>
        [DebuggerStepThrough]
        public static Argument<T> Assert<T>(T value, string parameterName)
        {
            return new Argument<T>(value, parameterName);
        }
    }
}
