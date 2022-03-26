using OrioksDecorator.Models.Schedule;

namespace OrioksDecorator.Categories.Interfaces
{
    /// <summary>
    ///     Категория расписаний <c>Open API</c>
    /// </summary>
    public interface IScheduleCategory
    {
        /// <summary>
        ///     Получить номер текущей недели
        /// </summary>
        Task<int> GetCurrentWeekAsync();

        /// <summary>
        ///     Получить номер типа текущей недели
        /// </summary>
        Task<int> GetWeekTypeAsync();

        /// <summary>
        ///     Получить группы
        /// </summary>
        Task<IEnumerable<Group>> GetGroupsAsync();

        /// <summary>
        ///     Получить таймтэйбл (время пар)
        /// </summary>
        Task<Class> GetTimetableAsync();

        /// <summary>
        ///     Получить расписание по id группы
        /// </summary>
        Task<IEnumerable<ScheduleItem>> GetScheduleByGroupIdAsync(int groupId);
    }
}
