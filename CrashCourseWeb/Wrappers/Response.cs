using System.Text.Json;

namespace CrashCourseWeb.Wrappers;
public class Response<T>
{
    public Response()
    {

    }
    public Response(T data, string message, string code)
    {
        Code = code;
        Succeeded = true;
        Message = message;
        Data = data;
    }
    public Response(T data, string message, string code, bool succeeded)
    {
        Code = code;
        Succeeded = succeeded;  
        Message = message;
        Data = data;
    }
    public Response(T? data)
    {
        Succeeded = true;
        Data = data;
    }
    public Response(string message)
    {
        Succeeded = true;
        Message = message;
    }
    public bool Succeeded { get; set; }
    public string? Message { get; set; }
    public IDictionary<string, string[]> Errors { get; set; } = new Dictionary<string, string[]>();
    public T? Data { get; set; }
    public string Code { get; set; }
    public override string ToString() => JsonSerializer.Serialize(this);
}