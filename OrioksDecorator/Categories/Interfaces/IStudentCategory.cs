using OrioksDecorator.Models.Disciplines;
using OrioksDecorator.Models.Student;

namespace OrioksDecorator.Categories.Interfaces
{
    /// <summary>
    ///     Категория студента
    /// </summary>
    public interface IStudentCategory
    {
        /// <summary>
        ///     Получиь информацию текущего студента
        /// </summary>
        Task<Student> GetStudentInfo();

        /// <summary>
        ///     Получить долги текущего студента
        /// </summary>
        Task<IEnumerable<AcademicDebts>> GetAcademicDebts();

        /// <summary>
        ///     Получить пересдачи по долгам
        /// </summary>
        Task<IEnumerable<Resit>> GetResitsByDebtId(int debtId);

        /// <summary>
        ///     Получить дисциплины
        /// </summary>
        Task<IEnumerable<Discipline>> GetDisciplines();

        /// <summary>
        ///     Получить мероприятия дисциплины
        /// </summary>
        Task<IEnumerable<Event>> GetEventsByDisciplineId(int disciplineId);
    }
}
