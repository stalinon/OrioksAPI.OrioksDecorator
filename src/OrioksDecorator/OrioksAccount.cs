namespace OrioksDecorator
{
    /// <summary>
    ///     Аккаунт <c>Orioks</c>
    /// </summary>
    public sealed class OrioksAccount
    {
        /// <summary>
        ///     Номер студенческого билета
        /// </summary>
        public string Username { get; set; }

        /// <summary>
        ///     Пароль
        /// </summary>
        public string Password { get; set; }

        /// <summary>
        ///     Токен, при наличии
        /// </summary>
        public string? Token { get; set; }
    }
}