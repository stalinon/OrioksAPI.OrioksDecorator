using OrioksDecorator.Models;
using OrioksDecorator.Models.Disciplines;
using OrioksDecorator.Models.Student;

namespace OrioksDecorator.Categories.Interfaces
{
    public interface IStudentCategory
    {
        Task<Student> GetStudentInfo();
        Task<IEnumerable<AcademicDebts>> GetAcademicDebts();
        Task<IEnumerable<Resit>> GetResitsByDebtId(int debtId);
        Task<IEnumerable<Discipline>> GetDisciplines();
        Task<IEnumerable<Event>> GetEventsByDisciplineId(int disciplineId);
    }
}
