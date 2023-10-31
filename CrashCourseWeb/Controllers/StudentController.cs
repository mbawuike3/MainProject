using CrashCourseWeb.CQRS.Commands;
using CrashCourseWeb.CQRS.Queries;
using CrashCourseWeb.Data;
using CrashCourseWeb.Helpers;
using CrashCourseWeb.Models;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace CrashCourseWeb.Controllers;

[Route("api/v1")]
[ApiController]
public class StudentController : ControllerBase
{
    readonly IMediator _mediator;

    public StudentController(IMediator mediator)
    {
        _mediator = mediator;
    }

    [HttpPost]
    public async Task<IActionResult> Create(CreateStudentCommand command)
    {
        return Ok(await _mediator.Send(command));
    }
    [HttpGet]
    public async Task<IActionResult> GetAllStudents()
    {
        var query = new GetAllStudentsQuery();
        var students = await _mediator.Send(query);
        return Ok(students);
    }
    [HttpGet("{id}")]
    public async Task<IActionResult> GetById(Guid id)
    {
        var query =new GetStudentByIdQuery { Id = id};
        var student =await _mediator.Send(query);
        if(student == null)
        {
            return NotFound();
        }
        return Ok(student);
    }
    [HttpGet("firstname/{firstName}")]
    public async Task<IActionResult> GetByFirstName(string firstName)
    {
        var query = new GetStudentByFirstNameQuery { FirstName = firstName };
        var student = await _mediator.Send(query);
        if (student == null)
            return NotFound($"Student with firstName {firstName} not found");
        return Ok(student);
    }
    [HttpGet("lastname/{lastName}")]
    public async Task<IActionResult> GetByLastName(string lastName)
    {
        var query = new GetStudentByLastNameQuery { LastName = lastName };
        var student = await _mediator.Send(query);
        if (student == null)
            return NotFound();
        return Ok(student);
    }
    [HttpPut("{id}")]
    public async Task<IActionResult> UpdateStudent(Guid id, UpdateStudentCommand command)
    {
        if(command.Id != id)
        {
            return BadRequest();
        }
        return Ok(await _mediator.Send(command));
    }
    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteStudent(Guid id)
    {
        var query = new DeleteStudentCommand { Id = id};
        var student = await _mediator.Send(query);
        if(student == null)
        {
            return NotFound("Student was not found");
        }
        return Ok("student successfully deleted");
    }
    [HttpGet("get-password")]
    public async Task<IActionResult> GetPlainPassword(string input)
    {
        var query = new GetStudentPlainPasswordQuery { Input = input };
        var student = await _mediator.Send(query);
        if(student.Code.Equals("99"))
        {
            return BadRequest(student.Message);
        }
        return Ok(student);
    }
    [HttpPost("student-encrypt")]
    public async Task<IActionResult> CreateEncryptStudent(CreateStudentCommand command)
    {
        string commandString = JsonConvert.SerializeObject(command);
        string commandCipher = commandString.Encrypt();
        return Ok( await _mediator.Send(new StudentEncyptedPayloadCommand { EncryptedPayload = commandCipher }));
    }
    [HttpPost("HashRegister")]
    public async Task<IActionResult> RegisterAsync([FromBody]HashRegisterStudentCommand command)
    {
        return Ok(await _mediator.Send(command));
    }
    [HttpGet("student-verification")]
    public async Task<IActionResult> UserVerifyAsync(string username)
    {
        var response = await _mediator.Send(new UserVerifyQuery { Username = username });
        bool userExit = response.Item1;
        string message = response.Item2;
        if(userExit)
        {
            return BadRequest(message);
        }
        return Ok(message);
    }
    [HttpPost("Login-hash")]
    public async Task<IActionResult> LoginHash(LoginUserCommand command)
    {
        return Ok(await _mediator.Send(command));
    }
}
