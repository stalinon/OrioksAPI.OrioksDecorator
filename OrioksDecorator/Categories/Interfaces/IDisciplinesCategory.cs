using OrioksDecorator.Models.Disciplines;

namespace OrioksDecorator.Categories.Interfaces
{
    /// <summary>
    ///     Категория дисциплин
    /// </summary>
    public interface IDisciplinesCategory
    {
        /// <summary>
        ///     Получить информацию о текущих дисциплинах
        /// </summary>
        Task<Disciplines> GetCurrentDisciplineInfos();

        /// <summary>
        ///     Получить информацию о дисциплинах
        ///     конкретного семестра и студента
        /// </summary>
        Task<Disciplines> GetDisciplineInfoById(int semesterId, int studentId);

        /// <summary>
        ///     Получить ресурсы дисциплины
        /// </summary>
        Task<Resourses> GetResoursesByDiscipline(Discipline discipline);
    }
}
