using System.Diagnostics.CodeAnalysis;
using System.Runtime.CompilerServices;

namespace SuperDuperMarket.Core
{
    public static partial class Throw
    {
        public static string IfNullOrWhiteSpace([NotNull] string? value, [CallerArgumentExpression(nameof(value))] string? argumentName = null)
        {
            if (string.IsNullOrWhiteSpace(value))
            {
                throw new ArgumentException("The value cannot be null, an empty string or whitespaces.", argumentName);
            }

            return value;
        }
    }
}