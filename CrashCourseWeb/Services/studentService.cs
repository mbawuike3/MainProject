using CrashCourseWeb.Data;
using CrashCourseWeb.Models;
using Microsoft.EntityFrameworkCore;

namespace CrashCourseWeb.Services
{
    public class studentService : IstudentService
    {

        private readonly ApplicationContext _context;

        public studentService(ApplicationContext context)
        {
            _context = context;
        }

        public async Task<List<Student>> GetStudents(string? filter)
        {
            var students = await _context.Students.Where(
                (x => (string.IsNullOrEmpty(filter) || x.FirstName!.ToLower().Equals(filter.ToLower()))
                 || (string.IsNullOrEmpty(filter) || x.LastName!.ToLower().Equals(filter.ToLower())))).ToListAsync();
            return students;
        }
    }
}
