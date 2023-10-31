using CrashCourseWeb.Data;
using CrashCourseWeb.Helpers;
using CrashCourseWeb.Wrappers;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace CrashCourseWeb.CQRS.Queries
{
    public class GetStudentPlainPasswordQuery : IRequest<Response<string>>
    {
        public string? Input { get; set; }
    }
    public class GetStudentPlainPasswordQueryHandler : IRequestHandler<GetStudentPlainPasswordQuery, Response<string>>
    {
        private readonly ApplicationContext _context;

        public GetStudentPlainPasswordQueryHandler(ApplicationContext context)
        {
            _context = context;
        }

        public async Task<Response<string>> Handle(GetStudentPlainPasswordQuery query, CancellationToken cancellationToken)
        {
            var student = await _context.Students.Where(x => (x.Username!.ToLower().Equals(query.Input!.ToLower())) || (x.Tel!.Equals(query.Input))).FirstOrDefaultAsync();
            if(student == null)
            {
                return new Response<string>(data: null, code: "99", succeeded: false, message: "User does not exist");
            }
            return new Response<string>(data: student.Password.Decrypt(), succeeded: true, code: "00", message: "Successful");
        }
    }
}
