using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SmartEdu.Migrations
{
    /// <inheritdoc />
    public partial class AddAcademicProgress : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "AcademicProgressId",
                table: "Marks",
                type: "int",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "AcademicProgresses",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TimetableId = table.Column<int>(type: "int", nullable: false),
                    Attendance = table.Column<int>(type: "int", nullable: false),
                    IsDoneHomework = table.Column<bool>(type: "bit", nullable: false),
                    TeacherComment = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AcademicProgresses", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AcademicProgresses_Timetables_TimetableId",
                        column: x => x.TimetableId,
                        principalTable: "Timetables",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Marks_AcademicProgressId",
                table: "Marks",
                column: "AcademicProgressId");

            migrationBuilder.CreateIndex(
                name: "IX_AcademicProgresses_TimetableId",
                table: "AcademicProgresses",
                column: "TimetableId");

            migrationBuilder.AddForeignKey(
                name: "FK_Marks_AcademicProgresses_AcademicProgressId",
                table: "Marks",
                column: "AcademicProgressId",
                principalTable: "AcademicProgresses",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Marks_AcademicProgresses_AcademicProgressId",
                table: "Marks");

            migrationBuilder.DropTable(
                name: "AcademicProgresses");

            migrationBuilder.DropIndex(
                name: "IX_Marks_AcademicProgressId",
                table: "Marks");

            migrationBuilder.DropColumn(
                name: "AcademicProgressId",
                table: "Marks");
        }
    }
}
