using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace CENTER_MANAGEMENT_SYSTEM.Migrations
{
    /// <inheritdoc />
    public partial class Init : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "CourseCategories",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Description = table.Column<string>(type: "nvarchar(300)", maxLength: 300, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CourseCategories", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Instructors",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FullName = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: false),
                    Email = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Specialization = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    HireDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Instructors", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Students",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FullName = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: false),
                    Email = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    PhoneNumber = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    RegistrationDate = table.Column<DateTime>(type: "datetime2", nullable: false, defaultValue: new DateTime(2026, 9, 26, 16, 23, 28, 348, DateTimeKind.Local).AddTicks(2830))
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Students", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Courses",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    DurationHours = table.Column<int>(type: "int", nullable: false),
                    Fee = table.Column<decimal>(type: "decimal(10,2)", precision: 10, scale: 2, nullable: false),
                    Capacity = table.Column<int>(type: "int", nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false, defaultValue: true),
                    CourseCategoryId = table.Column<int>(type: "int", nullable: false),
                    InstructorId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Courses", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Courses_CourseCategories_CourseCategoryId",
                        column: x => x.CourseCategoryId,
                        principalTable: "CourseCategories",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Courses_Instructors_InstructorId",
                        column: x => x.InstructorId,
                        principalTable: "Instructors",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Enrollments",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    EnrollmentDate = table.Column<DateTime>(type: "datetime2", nullable: false, defaultValue: new DateTime(2026, 9, 26, 16, 23, 28, 348, DateTimeKind.Local).AddTicks(3256)),
                    Status = table.Column<int>(type: "int", nullable: false),
                    Grade = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    StudentId = table.Column<int>(type: "int", nullable: false),
                    CourseId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Enrollments", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Enrollments_Courses_CourseId",
                        column: x => x.CourseId,
                        principalTable: "Courses",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Enrollments_Students_StudentId",
                        column: x => x.StudentId,
                        principalTable: "Students",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "CourseCategories",
                columns: new[] { "Id", "Description", "Name" },
                values: new object[,]
                {
                    { 1, "This Is Category 1", "Category 1" },
                    { 2, "This Is Category 2", "Category 2" },
                    { 3, "This Is Category 3", "Category 3" }
                });

            migrationBuilder.InsertData(
                table: "Instructors",
                columns: new[] { "Id", "Email", "FullName", "HireDate", "Specialization" },
                values: new object[,]
                {
                    { 1, "fady@gmail.com", "Fady Mohamed", new DateTime(2026, 9, 26, 16, 23, 28, 348, DateTimeKind.Local).AddTicks(7303), "CS" },
                    { 2, "hamada@gmail.com", "Hamada Mohamed", new DateTime(2026, 9, 26, 16, 23, 28, 348, DateTimeKind.Local).AddTicks(7323), "CS" },
                    { 3, "yara@gmail.com", "Yara Mohamed", new DateTime(2026, 9, 26, 16, 23, 28, 348, DateTimeKind.Local).AddTicks(7335), "ES" },
                    { 4, "nour@gmail.com", "Nour Mohamed", new DateTime(2026, 9, 26, 16, 23, 28, 348, DateTimeKind.Local).AddTicks(7345), "ES" }
                });

            migrationBuilder.InsertData(
                table: "Students",
                columns: new[] { "Id", "Email", "FullName", "PhoneNumber", "RegistrationDate" },
                values: new object[,]
                {
                    { 1, "basil@gmail.com", "Basil Mohamed", "01158589063", new DateTime(2026, 9, 26, 16, 23, 28, 348, DateTimeKind.Local).AddTicks(7217) },
                    { 2, "ahmed@gmail.com", "Ahmed Mohamed", "01158589013", new DateTime(2026, 9, 26, 16, 23, 28, 348, DateTimeKind.Local).AddTicks(7265) },
                    { 3, "mohamed@gmail.com", "Mohamed Lotfy", "01158589033", new DateTime(2026, 9, 26, 16, 23, 28, 348, DateTimeKind.Local).AddTicks(7285) }
                });

            migrationBuilder.InsertData(
                table: "Courses",
                columns: new[] { "Id", "Capacity", "CourseCategoryId", "DurationHours", "Fee", "InstructorId", "IsActive", "Title" },
                values: new object[,]
                {
                    { 1, 25, 1, 40, 2500m, 1, true, "ASP.NET Core Web API" },
                    { 2, 30, 1, 30, 1800m, 2, true, "C# Fundamentals" },
                    { 3, 20, 2, 35, 2000m, 3, true, "SQL Server" }
                });

            migrationBuilder.InsertData(
                table: "Courses",
                columns: new[] { "Id", "Capacity", "CourseCategoryId", "DurationHours", "Fee", "InstructorId", "Title" },
                values: new object[] { 4, 25, 2, 25, 1500m, 1, "Database Fundamentals" });

            migrationBuilder.InsertData(
                table: "Courses",
                columns: new[] { "Id", "Capacity", "CourseCategoryId", "DurationHours", "Fee", "InstructorId", "IsActive", "Title" },
                values: new object[,]
                {
                    { 5, 15, 3, 45, 3000m, 3, true, "Network Fundamentals" },
                    { 6, 30, 3, 50, 3500m, 2, true, "Frontend Development" }
                });

            migrationBuilder.InsertData(
                table: "Enrollments",
                columns: new[] { "Id", "CourseId", "EnrollmentDate", "Grade", "Status", "StudentId" },
                values: new object[,]
                {
                    { 1, 1, new DateTime(2026, 9, 26, 16, 23, 28, 348, DateTimeKind.Local).AddTicks(7479), 100m, 0, 1 },
                    { 2, 1, new DateTime(2026, 9, 26, 16, 23, 28, 348, DateTimeKind.Local).AddTicks(7495), 70m, 0, 2 },
                    { 3, 2, new DateTime(2026, 9, 26, 16, 23, 28, 348, DateTimeKind.Local).AddTicks(7508), 50m, 0, 3 },
                    { 4, 3, new DateTime(2026, 9, 26, 16, 23, 28, 348, DateTimeKind.Local).AddTicks(7521), 30m, 0, 3 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_CourseCategories_Name",
                table: "CourseCategories",
                column: "Name",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Courses_CourseCategoryId",
                table: "Courses",
                column: "CourseCategoryId");

            migrationBuilder.CreateIndex(
                name: "IX_Courses_InstructorId",
                table: "Courses",
                column: "InstructorId");

            migrationBuilder.CreateIndex(
                name: "IX_Enrollments_CourseId_StudentId",
                table: "Enrollments",
                columns: new[] { "CourseId", "StudentId" },
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Enrollments_StudentId",
                table: "Enrollments",
                column: "StudentId");

            migrationBuilder.CreateIndex(
                name: "IX_Instructors_Email",
                table: "Instructors",
                column: "Email",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Students_Email",
                table: "Students",
                column: "Email",
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Enrollments");

            migrationBuilder.DropTable(
                name: "Courses");

            migrationBuilder.DropTable(
                name: "Students");

            migrationBuilder.DropTable(
                name: "CourseCategories");

            migrationBuilder.DropTable(
                name: "Instructors");
        }
    }
}
