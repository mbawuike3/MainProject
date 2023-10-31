using CrashCourseWeb.Data;
using CrashCourseWeb.Models;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace CrashCourseWeb.CQRS.Queries
{
    public class GetStudentByIdQuery : IRequest<Student>
    {
        public Guid Id { get; set; }
    }
    public class GetStudentByIdQueryHandler : IRequestHandler<GetStudentByIdQuery, Student>
    {
        private readonly ApplicationContext _context;

        public GetStudentByIdQueryHandler(ApplicationContext context)
        {
            _context = context;
        }

        public async Task<Student> Handle(GetStudentByIdQuery query, CancellationToken cancellationToken)
        {
            var student = await _context.Students.Where(c => c.Id == query.Id).FirstOrDefaultAsync();
            return student;
            
            
        }
    }
}
