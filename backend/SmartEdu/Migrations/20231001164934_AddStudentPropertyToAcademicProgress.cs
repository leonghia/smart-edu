using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SmartEdu.Migrations
{
    /// <inheritdoc />
    public partial class AddStudentPropertyToAcademicProgress : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "StudentId",
                table: "AcademicProgresses",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_AcademicProgresses_StudentId",
                table: "AcademicProgresses",
                column: "StudentId");

            migrationBuilder.AddForeignKey(
                name: "FK_AcademicProgresses_Students_StudentId",
                table: "AcademicProgresses",
                column: "StudentId",
                principalTable: "Students",
                principalColumn: "Id",
                onDelete: ReferentialAction.NoAction);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AcademicProgresses_Students_StudentId",
                table: "AcademicProgresses");

            migrationBuilder.DropIndex(
                name: "IX_AcademicProgresses_StudentId",
                table: "AcademicProgresses");

            migrationBuilder.DropColumn(
                name: "StudentId",
                table: "AcademicProgresses");
        }
    }
}
