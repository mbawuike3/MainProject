using CrashCourseWeb.Data;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace CrashCourseWeb.CQRS.Queries
{
    public class UserVerifyQuery : IRequest<Tuple<bool, string>>
    {
        public string? Username { get; set; }
    }
    public class UserVerifyQueryHandler : IRequestHandler<UserVerifyQuery, Tuple<bool, string>>
    {
        private readonly ApplicationContext _context;

        public UserVerifyQueryHandler(ApplicationContext context)
        {
            _context = context;
        }

        public async Task<Tuple<bool, string>> Handle(UserVerifyQuery request, CancellationToken cancellationToken)
        {
            var isUsernameExist = await _context.Students.AnyAsync(x => x.Username!.ToLower().Equals(request.Username!.ToLower()));
            if(isUsernameExist)
            {
                return Tuple.Create(true, $"Username {request.Username} already exist");
            }
            return Tuple.Create(false, $"Username {request.Username} is available");
        }

    }
}
