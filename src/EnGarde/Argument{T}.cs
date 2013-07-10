namespace EnGarde
{
    /// <summary>
    /// A wrapper object containing the actual argument value.
    /// </summary>
    /// <typeparam name="T">The argument type.</typeparam>
    public class Argument<T>
    {
        internal Argument(T value, string parameterName)
        {
            this.Value = value;
            this.ParameterName = parameterName;
        }

        internal T Value { get; private set; }

        internal string ParameterName { get; private set; }

        internal bool IsNegativeAssertion { get; set; }
    }
}
