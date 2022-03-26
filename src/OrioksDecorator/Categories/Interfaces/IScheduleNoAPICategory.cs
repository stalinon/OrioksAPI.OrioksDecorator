using OrioksDecorator.Models.ScheduleNoApi;

namespace OrioksDecorator.Categories.Interfaces
{
    /// <summary>
    ///     Категория расписаний
    /// </summary>
    public interface IScheduleNoAPICategory
    {
        /// <summary>
        ///     Получить расписание группы по ключу, <code>Пример ключа: БТС-11</code>
        /// </summary>
        Task<DisciplineSchedule> GetDisciplineScheduleItemsAsync(string groupKey);
    }
}
