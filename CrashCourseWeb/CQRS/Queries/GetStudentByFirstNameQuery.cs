using CrashCourseWeb.Data;
using CrashCourseWeb.Models;
using CrashCourseWeb.Services;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace CrashCourseWeb.CQRS.Queries
{
    public class GetStudentByFirstNameQuery :IRequest<Student>
    {
        public string? FirstName { get; set; }
    }
    public class GetStudentByFirstNameQueryHandler : IRequestHandler<GetStudentByFirstNameQuery, Student>
    {

        private readonly IstudentService _istudent;
        public GetStudentByFirstNameQueryHandler(IstudentService istudent)
        {
            _istudent = istudent;
        }

        public async Task<Student> Handle(GetStudentByFirstNameQuery query, CancellationToken cancellationToken)
        {
            return (await _istudent.GetStudents(query.FirstName)).FirstOrDefault()!;
        }
    }
}
