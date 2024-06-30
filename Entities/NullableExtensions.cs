using System.Runtime.CompilerServices;

namespace MangaReader.Entities
{
    public static class NullableExtensions
    {
        public static T ThrowIfNull<T>(
            this T? argument,
            string? message = default,
            [CallerArgumentExpression(nameof(argument))] string? paramName = default
        ) where T : notnull
        {
            if (argument is null)
            {
                throw new ArgumentNullException(paramName, message);
            }

            return argument;
        }

        public static T ThrowIfNull<T>(
            this T? argument,
            string? message = default,
            [CallerArgumentExpression(nameof(argument))] string? paramName = default
        ) where T : struct
        {
            if (argument is null)
            {
                throw new ArgumentNullException(paramName, message);
            }

            return (T)argument;
        }
    }
}
