// Copyright (c) Arjen Post. See License.txt in the project root for license information.

namespace EnGarde
{
    /// <summary>
    /// A wrapper object containing the actual argument value.
    /// </summary>
    /// <typeparam name="T">The argument type.</typeparam>
    public interface IValidatedArgument<T>
    {
        /// <summary>
        /// Allows subsequent validations.
        /// </summary>
        IArgument<T> And { get; }
    }
}
