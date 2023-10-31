using CrashCourseWeb.Data;
using CrashCourseWeb.Helpers;
using CrashCourseWeb.Models;
using MediatR;

namespace CrashCourseWeb.CQRS.Commands
{
    public class CreateStudentCommand : IRequest<Guid>
    {
        public string? FirstName { get; set; }

        public string? LastName { get; set; }

        public string? Tel { get; set; }

        public string? Email { get; set; }

        public string? Username { get; set; }

        public string? Password { get; set; }
    }

    public class CreateStudentCommandHandler : IRequestHandler<CreateStudentCommand, Guid>
    {
        private readonly ApplicationContext _context;

        public CreateStudentCommandHandler(ApplicationContext context)
        {
            _context = context;
        }

        public async Task<Guid> Handle(CreateStudentCommand command, CancellationToken cancellationToken)
        {
            var student = new Student
            {
                FirstName = command.FirstName,
                LastName = command.LastName,
                Tel = command.Tel,
                Email = command.Email,
                Username = command.Username,
                Password = command.Password!.Encrypt()
            };

            await _context.Students.AddAsync(student);
            await _context.SaveChangesAsync(); // Use async SaveChanges

            return student.Id;

        }
    }
}
