using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace CrashCourseWeb.Models;

public class Student : Login
{
    //[JsonIgnore]
    public Guid Id { get; set; }
    
    public string? FirstName { get; set; }
    
    public string? LastName { get; set; }
    
    public string? Tel { get; set; }
    
    public string? Email { get; set; }

    [JsonIgnore]
    public string? Salt { get; set; }
}
