namespace OrioksDecorator.Models.Disciplines
{
    public class Resourse
    {
        public string Name { get; set; }
        public IEnumerable<ResourseItem> ResourseItems { get; set; }
    }
}