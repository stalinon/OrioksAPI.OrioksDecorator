using OrioksDecorator.Models.Teacher;

namespace OrioksDecorator.Categories.Interfaces
{
    /// <summary>
    ///     Категория преподавателей
    /// </summary>
    public interface ITeacherCategory
    {
        /// <summary>
        ///     Получить информацию о преподавателе
        ///     по полному имени
        /// </summary>
        Task<Teacher> GetTeachersInfo(string name);
    }
}
