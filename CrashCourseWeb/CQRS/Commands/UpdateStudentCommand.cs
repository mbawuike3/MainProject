using CrashCourseWeb.Data;
using CrashCourseWeb.Models;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace CrashCourseWeb.CQRS.Commands
{
    public class UpdateStudentCommand : Student, IRequest<Guid>
    {
       
    }
    public class UpdateStudentCommandHandler : IRequestHandler<UpdateStudentCommand, Guid>
    {
        private readonly ApplicationContext _context;

        public UpdateStudentCommandHandler(ApplicationContext context)
        {
            _context = context;
        }
        public async Task<Guid> Handle(UpdateStudentCommand command, CancellationToken cancellationToken)
        {
            var student =await _context.Students.Where(x => x.Id == command.Id).FirstOrDefaultAsync();
            if(student == null)
            {
                return default;
            }
            _context.Entry(student).CurrentValues.SetValues(command);
            await _context.SaveChangesAsync();
            return student.Id;
        }
    }
}
