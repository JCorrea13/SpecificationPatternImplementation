using DAL;
using Microsoft.EntityFrameworkCore.Migrations;

namespace DAL.Migrations
{
    public partial class SeedStudents : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                "Students",
                new string[] { "StudentId", "Name", "Age", "Gender" },
                new object[] { 1, "Juan", 23, 0 });

            migrationBuilder.InsertData(
                "Students",
                new string[] { "StudentId", "Name", "Age", "Gender" },
                new object[] { 2, "Pedro", 22, 2 });

            migrationBuilder.InsertData(
                "Students",
                new string[] { "StudentId", "Name", "Age", "Gender" },
                new object[] { 3, "Maria", 20, 1 });

            migrationBuilder.InsertData(
                "Students",
                new string[] { "StudentId", "Name", "Age", "Gender" },
                new object[] { 4, "Karina", 20, 1 });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData("Students", "StudentId", new int[] { 1, 2, 3, 4, 5 });
        }
    }
}
