using static System.Net.Mime.MediaTypeNames;
using System.Net;
using CrashCourseWeb.ExceptionHandlers;

namespace CrashCourseWeb.Middlewares;
public class ErrorHandlerMiddleware
{
    readonly RequestDelegate _next;

    public ErrorHandlerMiddleware(RequestDelegate next)
    {
        _next = next;
    }
    public async Task Invoke(HttpContext context)
    {
        try
        {
            await _next(context);
        }
        catch (Exception error)
        {

            Dictionary<string, string[]> errors = new()
            {
                { "Error", new string[] { error.Message } }
            };

            if (error.InnerException != null)
            {
                errors.Add("InnerException", new string[] { error.InnerException.Message });
            }
            var response = context.Response;

            response.ContentType = "application/json";

            var responseModel = new Wrappers.Response<string>()
            {
                Succeeded = false,
                Message = "An error occurred",
                Errors = errors
            };

            string errorCode = "99";
            switch (error)
            {
                case ApiException e:
                    response.StatusCode = (int)HttpStatusCode.BadRequest;
                    responseModel = new Wrappers.Response<string>
                    {
                        Succeeded = false,
                        Message = error.Message,
                        Errors = errors,
                        Code = errorCode
                    };
                    break;
                case ValidationException e:
                    //Custom application error
                    response.StatusCode = (int)HttpStatusCode.BadRequest;
                    responseModel.Errors = e.Errors;
                    responseModel.Code = "10";
                    responseModel.Message = "Validation exception occurred.";
                    break;
                case KeyNotFoundException e:
                    //Not found error
                    response.StatusCode = (int)HttpStatusCode.NotFound;
                    responseModel.Code = errorCode;
                    responseModel.Message = "KeyNotFound exception occurred.";
                    break;
                default:
                    //Unhandled error
                    response.StatusCode = (int)HttpStatusCode.InternalServerError;
                    responseModel.Code = errorCode;
                    break;
            }
            var result = System.Text.Json.JsonSerializer.Serialize(responseModel);
            await response.WriteAsync(result);
        }
    }
}