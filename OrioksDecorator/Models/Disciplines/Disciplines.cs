using Newtonsoft.Json;

namespace OrioksDecorator.Models.Disciplines
{
    /// <summary>
    ///     Список дисциплин
    /// </summary>
    public sealed class Disciplines
    {
        /// <inheritdoc cref="Disciplines"/>
        [JsonProperty("dises")]
        public IEnumerable<Discipline> Items { get; set; }
    }
}
