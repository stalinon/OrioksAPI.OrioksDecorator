using OrioksDecorator.Models.Disciplines;

namespace OrioksDecorator.Categories.Interfaces
{
    public interface IResoursesCategory
    {
        Task<Resourses> GetResoursesByDiscipline(Discipline discipline);
    }
}
