using CrashCourseWeb.CQRS.Commands;
using CrashCourseWeb.Helpers;
using CrashCourseWeb.Models;
using FluentValidation;

namespace CrashCourseWeb.Validations;

public class StudentValidator : AbstractValidator<Student>
{
    public StudentValidator()
    {
        RuleFor(x => x.FirstName)
            .NotEmpty()
            .NotNull()
            .MaximumLength(25)
            .Must(p => StringHelper.IsAlphabelts(p));

        RuleFor(x => x.LastName)
           .NotEmpty()
           .NotNull()
           .MaximumLength(25)
           .Must(p => StringHelper.IsAlphabelts(p));

        RuleFor(x => x.Username)
          .NotEmpty()
          .NotNull()
          .MaximumLength(25)
          .Must(p => StringHelper.isAlphaNumeric(p));

        RuleFor(x => x.Tel)
            .NotEmpty()
            .NotNull()
            .Length(11)
            .Must(p => StringHelper.IsNumbers(p));

        RuleFor(x => x.Email)
            .NotEmpty()
            .NotNull()
            .Must(p => StringHelper.IsValidEmail(p));
        RuleFor(x => x.Password)
            .NotEmpty()
            .NotNull()
            .MaximumLength(20)
            .Must(p => StringHelper.isAlphaNumeric(p));
    }
}
