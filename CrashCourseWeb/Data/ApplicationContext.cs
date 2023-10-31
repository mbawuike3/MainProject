using CrashCourseWeb.Models;
using Microsoft.EntityFrameworkCore;

namespace CrashCourseWeb.Data;

public class ApplicationContext : DbContext
{
    public ApplicationContext(DbContextOptions<ApplicationContext> options) : base(options)
    {

    }

    public DbSet<Student> Students { get; set; }

    //Fluent API
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        //modelBuilder.Entity<Student>().HasData(
        //    new Student()
        //    {
        //        Id = Guid.NewGuid(),
        //        FirstName = "Favour",
        //        LastName = "Mbagwu",
        //        Email = "favourmbagwu@gmail.com",
        //        Tel = "09033226688",
        //        Username = "mbah34",
        //        Password = "niceGurl2001"
        //    },
        //    new Student()
        //    {
        //        Id = Guid.NewGuid(),
        //        FirstName = "Okorie",
        //        LastName = "Kelechi",
        //        Email = "klaus@gmail.com",
        //        Tel = "09033233772",
        //        Username = "modrid68",
        //        Password = "klaus44"
        //    },
        //    new Student()
        //    {
        //        Id = Guid.NewGuid(),
        //        FirstName = "Chioma",
        //        LastName = "Mbawuiwe",
        //        Email = "chommy@gmail.com",
        //        Tel = "09033260778",
        //        Username = "Chiom68",
        //        Password = "chomzy44"
        //    });

        base.OnModelCreating(modelBuilder);
    }

}
