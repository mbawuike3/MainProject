using CrashCourseWeb.Behaviours;
using CrashCourseWeb.CQRS.Commands;
using CrashCourseWeb.Data;
using CrashCourseWeb.Extensions;
using CrashCourseWeb.Services;
using CrashCourseWeb.Validations;
using FluentValidation;
using MediatR;
using Microsoft.AspNetCore.Mvc.Infrastructure;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System.Reflection;

var builder = WebApplication.CreateBuilder(args);
//Validation Pipeline
builder.Services.AddValidatorsFromAssembly(typeof(StudentValidator).Assembly);
builder.Services.AddTransient(typeof(IPipelineBehavior<,>), typeof(ValidationBehaviour<,>));
builder.Services.AddMediatR(x => x.RegisterServicesFromAssemblies(Assembly.GetExecutingAssembly()));
builder.Services.AddDbContext<ApplicationContext>(options =>
options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"), 
b => b.MigrationsAssembly(typeof(ApplicationContext).Assembly.FullName)));
builder.Services.AddControllers();
builder.Services.AddScoped<IstudentService, studentService>();
builder.Services.AddScoped<IPasswordService, PasswordService>();
string swaggerName = "Gozie and Habzone Crash Course";
//Adding Swagger Service
builder.Services.AddSwaggerGen(options => options.SwaggerDoc("v1", new Microsoft.OpenApi.Models.OpenApiInfo { Title = swaggerName, Version = "v1" }));
// Add services to the container.
builder.Services.AddRazorPages();


var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
}
app.UseSwagger();
app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", swaggerName));
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapRazorPages();

//Custom Middleware
app.ExtendBuilder();
app.MapControllers();
app.Run();
