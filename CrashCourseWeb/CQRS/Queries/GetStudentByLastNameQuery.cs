using CrashCourseWeb.Data;
using CrashCourseWeb.Models;
using CrashCourseWeb.Services;
using MediatR;

namespace CrashCourseWeb.CQRS.Queries
{
    public class GetStudentByLastNameQuery : IRequest<Student>
    {
        public string? LastName { get; set; }
    }
    public class GetStudentByLastNameQueryHandler : IRequestHandler<GetStudentByLastNameQuery, Student>
    {
        private readonly IstudentService _istudent;

        public GetStudentByLastNameQueryHandler(IstudentService istudent)
        {
            _istudent = istudent;
        }

        public async Task<Student> Handle(GetStudentByLastNameQuery query, CancellationToken cancellationToken)
        {
            return (await _istudent.GetStudents(query.LastName)).FirstOrDefault()!;
        }
    }
}
