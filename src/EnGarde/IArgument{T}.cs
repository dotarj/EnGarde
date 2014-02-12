// Copyright (c) Arjen Post. See License.txt in the project root for license information.

namespace EnGarde
{
    /// <summary>
    /// A wrapper object containing the actual argument value.
    /// </summary>
    /// <typeparam name="T">The argument type.</typeparam>
    public interface IArgument<out T>
    {
        /// <summary>
        /// Internal and extension use only. Must be called from a validation method for a correct fluent interface.
        /// </summary>
        /// <returns>An <see cref="IValidatedArgument{T}"/> for a correct fluent interface.</returns>
        IValidatedArgument<T> AsValidatedArgument();

        /// <summary>
        /// Gets the argument value.
        /// </summary>
        T Value { get; }

        /// <summary>
        /// Gets the parameter name.
        /// </summary>
        string ParameterName { get; }

        /// <summary>
        /// Gets a value indicating whether the next result is negated.
        /// </summary>
        bool IsNegated { get; }

        /// <summary>
        /// Negates the next result.
        /// </summary>
        IArgument<T> Not { get; }
    }
}
