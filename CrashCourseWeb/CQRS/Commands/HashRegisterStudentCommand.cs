using CrashCourseWeb.Data;
using CrashCourseWeb.Models;
using CrashCourseWeb.Services;
using MediatR;

namespace CrashCourseWeb.CQRS.Commands
{
    public class HashRegisterStudentCommand : IRequest<Student>
    {
        public string? FirstName { get; set; }

        public string? LastName { get; set; }

        public string? Tel { get; set; }

        public string? Email { get; set; }

        public string? Username { get; set; }

        public string? Password { get; set; }

    }
    public class HashRegisterStudentCommandHandler : IRequestHandler<HashRegisterStudentCommand, Student>
    {
        private readonly ApplicationContext _context;
        private readonly IPasswordService _passwordService;

        public HashRegisterStudentCommandHandler(ApplicationContext context, IPasswordService passwordService)
        {
            _context = context;
            _passwordService = passwordService;
        }

        public async Task<Student> Handle(HashRegisterStudentCommand request, CancellationToken cancellationToken)
        {
            try
            {
                //Generate Salt
                var salt = Guid.NewGuid().ToString();
                //work on password
                request.Password += salt; // salting
                                          //creating new student
                var student = new Student
                {
                    FirstName = request.FirstName,
                    LastName = request.LastName,
                    Username = request.Username,
                    Email = request.Email,
                    Tel = request.Tel,
                    Salt = salt,
                    Password = _passwordService.Encoder(request.Password)
                };
                await _context.Students.AddAsync(student);
                await _context.SaveChangesAsync();
                return new Student
                {
                    FirstName = request.FirstName,
                    LastName = request.LastName,
                    Username = request.Username,
                    Email = request.Email,
                    Tel = request.Tel
                };
            }
            catch (Exception ex)
            {

                throw;
            }
        }
    }
}
