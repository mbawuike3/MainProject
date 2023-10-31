using CrashCourseWeb.Data;
using CrashCourseWeb.Helpers;
using CrashCourseWeb.Models;
using MediatR;
using Newtonsoft.Json;
using System.Text.Json.Serialization;

namespace CrashCourseWeb.CQRS.Commands
{
    public class StudentEncyptedPayloadCommand : IRequest<Student>
    {
        public string? EncryptedPayload { get; set; }
    }
    public class StudentEncyptedPayloadCommandHandler : IRequestHandler<StudentEncyptedPayloadCommand, Student>
    {
        private readonly ApplicationContext _context;

        public StudentEncyptedPayloadCommandHandler(ApplicationContext context)
        {
            _context = context;
        }

        public async Task<Student> Handle(StudentEncyptedPayloadCommand command, CancellationToken cancellationToken)
        {
            var plainText = command.EncryptedPayload.Decrypt();
            var request = JsonConvert.DeserializeObject<CreateStudentCommand>(plainText);
            var student = new Student
            {
                FirstName = request!.FirstName,
                LastName = request!.LastName,
                Username = request!.Username,
                Email = request!.Email,
                Password = request.Password!.Encrypt(),
                Tel = request.Tel
            };
            _context.Add(student);
            await _context.SaveChangesAsync();
            return student;
        }
    }
    
}
