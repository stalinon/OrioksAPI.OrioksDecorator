using OrioksDecorator.Models.Teacher;

namespace OrioksDecorator.Categories.Interfaces
{
    public interface ITeacherCategory
    {
        Task<Teacher> GetTeachersInfo(string name);
    }
}
