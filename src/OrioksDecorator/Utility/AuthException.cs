namespace OrioksDecorator.Utility
{
    /// <summary>
    ///     Ошибка авторизации
    /// </summary>
    internal sealed class AuthException : Exception
    {
        /// <inheritdoc cref="AuthException"/>
        public AuthException(string? message = "Wrong login or password") : base(message)
        {}
    }
}
