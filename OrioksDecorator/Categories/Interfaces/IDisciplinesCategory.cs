using OrioksDecorator.Models.Disciplines;

namespace OrioksDecorator.Categories.Interfaces
{
    public interface IDisciplinesCategory
    {
        Task<Disciplines> GetCurrentDisciplineInfos();
        Task<Disciplines> GetDisciplineInfoById(int semesterId, int studentId);
        Task<Resourses> GetResoursesByDiscipline(Discipline discipline);
    }
}
