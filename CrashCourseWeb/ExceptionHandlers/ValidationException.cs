using FluentValidation.Results;

namespace CrashCourseWeb.ExceptionHandlers;

public class ValidationException : ApplicationException
{
    public ValidationException()
        : base("One or more validation errors have occurred")
    {
        Errors = new Dictionary<string, string[]>();
    }

    //Will handle errors from our custom validation using Fluent Validation
    public ValidationException(IEnumerable<ValidationFailure> failures)
        : this()
    {
        Errors = failures
                    .GroupBy(e => e.PropertyName, e => e.ErrorMessage)
                    .ToDictionary(failureGroup => failureGroup.Key,
                    failureGroup => failureGroup.ToArray());
    }
    public IDictionary<string, string[]> Errors { get; }
}
