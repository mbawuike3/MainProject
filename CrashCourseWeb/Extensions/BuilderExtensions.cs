using CrashCourseWeb.Middlewares;

namespace CrashCourseWeb.Extensions;

public static class BuilderExtensions
{
    public static void ExtendBuilder(this IApplicationBuilder app)
    {
        app.UseMiddleware<ErrorHandlerMiddleware>();
    }
}
