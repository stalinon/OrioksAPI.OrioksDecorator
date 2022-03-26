namespace OrioksDecorator.Models.Disciplines
{
    public sealed class Resourse
    {
        public string Name { get; set; }
        public IEnumerable<ResourseItem> ResourseItems { get; set; }
    }
}