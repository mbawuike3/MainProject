using CrashCourseWeb.Models;

namespace CrashCourseWeb.Services
{
    public interface IstudentService
    {
        Task<List<Student>> GetStudents(string? filter = null);
    }
}