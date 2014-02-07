// Copyright (c) Arjen Post. See License.txt in the project root for license information.

namespace EnGarde.Benchmark
{
    /// <summary>
    /// A wrapper object containing the actual argument value.
    /// </summary>
    /// <typeparam name="T">The argument type.</typeparam>
    public class Argument<T> : IArgument<T>, IValidatedArgument<T>
    {
        internal Argument(T value, string parameterName)
        {
            this.Value = value;
            this.ParameterName = parameterName;
        }

        /// <summary>
        /// Gets the argument value.
        /// </summary>
        public T Value { get; private set; }

        /// <summary>
        /// Gets the parameter name.
        /// </summary>
        public string ParameterName { get; private set; }

        /// <summary>
        /// Gets a value indicating whether the next result is negated.
        /// </summary>
        public bool IsNegated { get; private set; }

        /// <summary>
        /// Internal and extension use only. Must be called from a validation method for a correct fluent interface.
        /// </summary>
        /// <returns>An <see cref="IValidatedArgument{T}"/> for a correct fluent interface.</returns>
        public IValidatedArgument<T> AsValidatedArgument()
        {
            IsNegated = false;

            return this;
        }

        /// <summary>
        /// Allows subsequent validations.
        /// </summary>
        public IArgument<T> And
        {
            get { return this; }
        }

        /// <summary>
        /// Negates the next result.
        /// </summary>
        public IArgument<T> Not
        {
            get
            {
                IsNegated = !IsNegated;

                return this;
            }
        }
    }
}