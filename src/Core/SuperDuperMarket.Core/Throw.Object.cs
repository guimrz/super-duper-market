using System.Diagnostics.CodeAnalysis;
using System.Runtime.CompilerServices;

namespace SuperDuperMarket.Core
{
    public static partial class Throw
    {
        public static T IfNull<T>([NotNull] T value, [CallerArgumentExpression(nameof(value))] string? argumentName = null)
        {
            if (value is null)
            {
                throw new ArgumentNullException(argumentName);
            }

            return value;
        }
    }
}