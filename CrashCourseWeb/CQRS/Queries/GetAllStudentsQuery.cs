using CrashCourseWeb.Data;
using CrashCourseWeb.Models;
using CrashCourseWeb.Services;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace CrashCourseWeb.CQRS.Queries
{
    public class GetAllStudentsQuery : IRequest<List<Student>>
    {
    }
    public class GetAllStudentsQueryHandler : IRequestHandler<GetAllStudentsQuery, List<Student>>
    {
        private readonly IstudentService _istudent;

        public GetAllStudentsQueryHandler(IstudentService istudentService)
        {
            _istudent = istudentService;
        }

        public async Task<List<Student>> Handle(GetAllStudentsQuery query, CancellationToken cancellationToken)
        {
            return await _istudent.GetStudents();    
        }
    }
}
