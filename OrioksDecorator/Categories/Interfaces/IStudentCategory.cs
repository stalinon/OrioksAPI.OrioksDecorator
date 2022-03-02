using OrioksDecorator.Models.Student;

namespace OrioksDecorator.Categories.Interfaces
{
    public interface IStudentCategory
    {
        Task<Disciplines> GetDisciplineInfos();
    }
}
