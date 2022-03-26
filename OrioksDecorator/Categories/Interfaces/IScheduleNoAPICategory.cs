using OrioksDecorator.Models.ScheduleNoApi;

namespace OrioksDecorator.Categories.Interfaces
{
    public interface IScheduleNoAPICategory
    {
        Task<DisciplineSchedule> GetDisciplineScheduleItemsAsync(string groupKey);
    }
}
