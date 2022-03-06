using OrioksDecorator.Models.Schedule;

namespace OrioksDecorator.Categories.Interfaces
{
    public interface IScheduleCategory
    {
        Task<int> GetCurrentWeekAsync();
        Task<int> GetWeekTypeAsync();
        Task<IEnumerable<Group>> GetGroupsAsync();
        Task<Class> GetTimetableAsync();
        Task<IEnumerable<ScheduleItem>> GetScheduleByGroupIdAsync(int groupId);
    }
}
