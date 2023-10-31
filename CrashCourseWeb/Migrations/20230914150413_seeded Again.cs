using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CrashCourseWeb.Migrations
{
    public partial class seededAgain : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Students",
                keyColumn: "Id",
                keyValue: new Guid("474dff0a-9189-41ef-bf66-782e44d02f6a"));

            migrationBuilder.DeleteData(
                table: "Students",
                keyColumn: "Id",
                keyValue: new Guid("f0281b36-a65f-4f94-a7dd-e417170664bf"));

            migrationBuilder.InsertData(
                table: "Students",
                columns: new[] { "Id", "Email", "FirstName", "LastName", "Password", "Tel", "Username" },
                values: new object[] { new Guid("b437d473-10bf-4d38-88e4-51fa0f7db8ae"), "klaus@gmail.com", "Okorie", "Kelechi", "klaus44", "09033233772", "modrid68" });

            migrationBuilder.InsertData(
                table: "Students",
                columns: new[] { "Id", "Email", "FirstName", "LastName", "Password", "Tel", "Username" },
                values: new object[] { new Guid("c2139393-8a35-4149-9224-2e6f9222d270"), "favourmbagwu@gmail.com", "Favour", "Mbagwu", "niceGurl2001", "09033226688", "mbah34" });

            migrationBuilder.InsertData(
                table: "Students",
                columns: new[] { "Id", "Email", "FirstName", "LastName", "Password", "Tel", "Username" },
                values: new object[] { new Guid("e0c21146-6f67-45d2-948d-4664f1b06deb"), "chommy@gmail.com", "Chioma", "Mbawuiwe", "chomzy44", "09033260778", "Chiom68" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Students",
                keyColumn: "Id",
                keyValue: new Guid("b437d473-10bf-4d38-88e4-51fa0f7db8ae"));

            migrationBuilder.DeleteData(
                table: "Students",
                keyColumn: "Id",
                keyValue: new Guid("c2139393-8a35-4149-9224-2e6f9222d270"));

            migrationBuilder.DeleteData(
                table: "Students",
                keyColumn: "Id",
                keyValue: new Guid("e0c21146-6f67-45d2-948d-4664f1b06deb"));

            migrationBuilder.InsertData(
                table: "Students",
                columns: new[] { "Id", "Email", "FirstName", "LastName", "Password", "Tel", "Username" },
                values: new object[] { new Guid("474dff0a-9189-41ef-bf66-782e44d02f6a"), "favourmbagwu@gmail.com", "Favour", "Mbagwu", "niceGurl2001", "09033226688", "mbah34" });

            migrationBuilder.InsertData(
                table: "Students",
                columns: new[] { "Id", "Email", "FirstName", "LastName", "Password", "Tel", "Username" },
                values: new object[] { new Guid("f0281b36-a65f-4f94-a7dd-e417170664bf"), "klaus@gmail.com", "Okorie", "Kelechi", "klaus44", "09033233772", "modrid68" });
        }
    }
}
