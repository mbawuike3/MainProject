using CrashCourseWeb.Data;
using CrashCourseWeb.Models;
using CrashCourseWeb.Services;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace CrashCourseWeb.CQRS.Commands
{
    public class LoginUserCommand : Login, IRequest<bool>
    {
    }
    public class LoginUserCommandHandler : IRequestHandler<LoginUserCommand, bool>
    {
        private readonly ApplicationContext _context;
        private readonly IPasswordService _passwordService;

        public LoginUserCommandHandler(ApplicationContext context, IPasswordService passwordService)
        {
            _context = context;
            _passwordService = passwordService;
        }

        public async Task<bool> Handle(LoginUserCommand request, CancellationToken cancellationToken)
        {
            var userFromDb = await _context.Students.Where(x => x.Username!.ToLower() == request.Username!.ToLower()).FirstOrDefaultAsync();
            if (userFromDb == null)
            {
                return false;
            }
            var salt = userFromDb.Salt;
            request.Password = request.Password!.Trim();
            request.Password += salt;
            var hashedPassword = _passwordService.Encoder(request.Password);
            if(hashedPassword.Equals(userFromDb.Password))
            {
                return true;
            }
            return false;
        }
    }
}
