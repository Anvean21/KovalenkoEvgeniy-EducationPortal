using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace EducationPortal.Infrastructure.Data.Migrations
{
    public partial class VideoMaterial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Courses_Users_UserId",
                table: "Courses");

            migrationBuilder.DropForeignKey(
                name: "FK_Courses_Users_UserId1",
                table: "Courses");

            migrationBuilder.DropForeignKey(
                name: "FK_Tests_Courses_CourseId",
                table: "Tests");

            migrationBuilder.DropTable(
                name: "SkillUser");

            migrationBuilder.DropIndex(
                name: "IX_Tests_CourseId",
                table: "Tests");

            migrationBuilder.DropIndex(
                name: "IX_Courses_UserId",
                table: "Courses");

            migrationBuilder.DropIndex(
                name: "IX_Courses_UserId1",
                table: "Courses");

            migrationBuilder.DeleteData(
                table: "Answers",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Answers",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Questions",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Tests",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Courses",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DropColumn(
                name: "CourseId",
                table: "Tests");

            migrationBuilder.DropColumn(
                name: "Level",
                table: "Skills");

            migrationBuilder.DropColumn(
                name: "UserId",
                table: "Courses");

            migrationBuilder.DropColumn(
                name: "UserId1",
                table: "Courses");

            migrationBuilder.AddColumn<string>(
                name: "Link",
                table: "VideoMaterial",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "TestId",
                table: "Courses",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "UserCoursesInProgress",
                columns: table => new
                {
                    UserId = table.Column<int>(type: "int", nullable: false),
                    CourseId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserCoursesInProgress", x => new { x.UserId, x.CourseId });
                    table.ForeignKey(
                        name: "FK_UserCoursesInProgress_Courses_CourseId",
                        column: x => x.CourseId,
                        principalTable: "Courses",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_UserCoursesInProgress_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "UserPassedCourses",
                columns: table => new
                {
                    UserId = table.Column<int>(type: "int", nullable: false),
                    CourseId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserPassedCourses", x => new { x.UserId, x.CourseId });
                    table.ForeignKey(
                        name: "FK_UserPassedCourses_Courses_CourseId",
                        column: x => x.CourseId,
                        principalTable: "Courses",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_UserPassedCourses_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "UserSkills",
                columns: table => new
                {
                    UserId = table.Column<int>(type: "int", nullable: false),
                    SkillId = table.Column<int>(type: "int", nullable: false),
                    Level = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserSkills", x => new { x.UserId, x.SkillId });
                    table.ForeignKey(
                        name: "FK_UserSkills_Skills_SkillId",
                        column: x => x.SkillId,
                        principalTable: "Skills",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_UserSkills_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.UpdateData(
                table: "ArticleMaterial",
                keyColumn: "Id",
                keyValue: 1,
                column: "PublishDate",
                value: new DateTime(2021, 6, 27, 16, 21, 10, 678, DateTimeKind.Local).AddTicks(5274));

            migrationBuilder.InsertData(
                table: "Skills",
                columns: new[] { "Id", "Name" },
                values: new object[] { 2, ".Net" });

            migrationBuilder.CreateIndex(
                name: "IX_Courses_TestId",
                table: "Courses",
                column: "TestId");

            migrationBuilder.CreateIndex(
                name: "IX_UserCoursesInProgress_CourseId",
                table: "UserCoursesInProgress",
                column: "CourseId");

            migrationBuilder.CreateIndex(
                name: "IX_UserPassedCourses_CourseId",
                table: "UserPassedCourses",
                column: "CourseId");

            migrationBuilder.CreateIndex(
                name: "IX_UserSkills_SkillId",
                table: "UserSkills",
                column: "SkillId");

            migrationBuilder.AddForeignKey(
                name: "FK_Courses_Tests_TestId",
                table: "Courses",
                column: "TestId",
                principalTable: "Tests",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Courses_Tests_TestId",
                table: "Courses");

            migrationBuilder.DropTable(
                name: "UserCoursesInProgress");

            migrationBuilder.DropTable(
                name: "UserPassedCourses");

            migrationBuilder.DropTable(
                name: "UserSkills");

            migrationBuilder.DropIndex(
                name: "IX_Courses_TestId",
                table: "Courses");

            migrationBuilder.DeleteData(
                table: "Skills",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DropColumn(
                name: "Link",
                table: "VideoMaterial");

            migrationBuilder.DropColumn(
                name: "TestId",
                table: "Courses");

            migrationBuilder.AddColumn<int>(
                name: "CourseId",
                table: "Tests",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "Level",
                table: "Skills",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "UserId",
                table: "Courses",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "UserId1",
                table: "Courses",
                type: "int",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "SkillUser",
                columns: table => new
                {
                    SkillsId = table.Column<int>(type: "int", nullable: false),
                    UsersId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SkillUser", x => new { x.SkillsId, x.UsersId });
                    table.ForeignKey(
                        name: "FK_SkillUser_Skills_SkillsId",
                        column: x => x.SkillsId,
                        principalTable: "Skills",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_SkillUser_Users_UsersId",
                        column: x => x.UsersId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Answers",
                columns: new[] { "Id", "IsTrue", "Name", "QuestionId" },
                values: new object[,]
                {
                    { 1, true, "answer 1", null },
                    { 2, false, "answer 2", null }
                });

            migrationBuilder.UpdateData(
                table: "ArticleMaterial",
                keyColumn: "Id",
                keyValue: 1,
                column: "PublishDate",
                value: new DateTime(2021, 6, 17, 19, 50, 5, 889, DateTimeKind.Local).AddTicks(8554));

            migrationBuilder.InsertData(
                table: "Courses",
                columns: new[] { "Id", "Description", "Name", "UserId", "UserId1" },
                values: new object[] { 1, "Description", "Course", null, null });

            migrationBuilder.InsertData(
                table: "Questions",
                columns: new[] { "Id", "Name", "TestId" },
                values: new object[] { 1, "Question 1", null });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "Email", "Name", "Password" },
                values: new object[] { 1, "anvean@gmail.com", "Anvean", "leitxrf33" });

            migrationBuilder.InsertData(
                table: "Tests",
                columns: new[] { "Id", "CourseId", "Name" },
                values: new object[] { 1, 1, "Test1" });

            migrationBuilder.CreateIndex(
                name: "IX_Tests_CourseId",
                table: "Tests",
                column: "CourseId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Courses_UserId",
                table: "Courses",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_Courses_UserId1",
                table: "Courses",
                column: "UserId1");

            migrationBuilder.CreateIndex(
                name: "IX_SkillUser_UsersId",
                table: "SkillUser",
                column: "UsersId");

            migrationBuilder.AddForeignKey(
                name: "FK_Courses_Users_UserId",
                table: "Courses",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Courses_Users_UserId1",
                table: "Courses",
                column: "UserId1",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Tests_Courses_CourseId",
                table: "Tests",
                column: "CourseId",
                principalTable: "Courses",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
