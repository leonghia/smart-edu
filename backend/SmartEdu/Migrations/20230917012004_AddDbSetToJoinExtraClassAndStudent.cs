using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SmartEdu.Migrations
{
    /// <inheritdoc />
    public partial class AddDbSetToJoinExtraClassAndStudent : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ExtraClassStudent");

            migrationBuilder.CreateTable(
                name: "ExtraClassesStudents",
                columns: table => new
                {
                    ExtraClassId = table.Column<int>(type: "int", nullable: false),
                    StudentId = table.Column<int>(type: "int", nullable: false),
                    RegisteredOn = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ExtraClassesStudents", x => new { x.ExtraClassId, x.StudentId });
                    table.ForeignKey(
                        name: "FK_ExtraClassesStudents_ExtraClasses_ExtraClassId",
                        column: x => x.ExtraClassId,
                        principalTable: "ExtraClasses",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ExtraClassesStudents_Students_StudentId",
                        column: x => x.StudentId,
                        principalTable: "Students",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ExtraClassesStudents_StudentId",
                table: "ExtraClassesStudents",
                column: "StudentId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ExtraClassesStudents");

            migrationBuilder.CreateTable(
                name: "ExtraClassStudent",
                columns: table => new
                {
                    ExtraClassesId = table.Column<int>(type: "int", nullable: false),
                    StudentsId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ExtraClassStudent", x => new { x.ExtraClassesId, x.StudentsId });
                    table.ForeignKey(
                        name: "FK_ExtraClassStudent_ExtraClasses_ExtraClassesId",
                        column: x => x.ExtraClassesId,
                        principalTable: "ExtraClasses",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ExtraClassStudent_Students_StudentsId",
                        column: x => x.StudentsId,
                        principalTable: "Students",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ExtraClassStudent_StudentsId",
                table: "ExtraClassStudent",
                column: "StudentsId");
        }
    }
}
