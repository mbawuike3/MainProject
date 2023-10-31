using CrashCourseWeb.Data;
using CrashCourseWeb.Helpers;
using CrashCourseWeb.Models;
using CrashCourseWeb.Wrappers;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace CrashCourseWeb.CQRS.Commands
{
    public class DeleteStudentCommand : IRequest<Student>
    {
        public Guid Id { get; set; }
    }
    public class DeleteStudentCommandHandler : IRequestHandler<DeleteStudentCommand, Student>
    {
        private readonly ApplicationContext _context;

        public DeleteStudentCommandHandler(ApplicationContext context)
        {
            _context = context;
        }
        public async Task<Student> Handle(DeleteStudentCommand command, CancellationToken cancellationToken)
        {
            var student = await _context.Students.Where(x => x.Id == command.Id).FirstOrDefaultAsync();
            if (student == null)
                return null!;
            _context.Students.Remove(student);
            await _context.SaveChangesAsync();
            return student;
        }
    }
}
