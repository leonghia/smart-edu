using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SmartEdu.Migrations
{
    /// <inheritdoc />
    public partial class RemoveMainClassIdNavPropFromTeacher : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Teachers_MainClasses_MainClassId",
                table: "Teachers");

            migrationBuilder.DropIndex(
                name: "IX_Teachers_MainClassId",
                table: "Teachers");

            migrationBuilder.DropIndex(
                name: "IX_MainClasses_TeacherId",
                table: "MainClasses");

            migrationBuilder.DropColumn(
                name: "MainClassId",
                table: "Teachers");

            migrationBuilder.CreateIndex(
                name: "IX_MainClasses_TeacherId",
                table: "MainClasses",
                column: "TeacherId",
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_MainClasses_TeacherId",
                table: "MainClasses");

            migrationBuilder.AddColumn<int>(
                name: "MainClassId",
                table: "Teachers",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Teachers_MainClassId",
                table: "Teachers",
                column: "MainClassId");

            migrationBuilder.CreateIndex(
                name: "IX_MainClasses_TeacherId",
                table: "MainClasses",
                column: "TeacherId");

            migrationBuilder.AddForeignKey(
                name: "FK_Teachers_MainClasses_MainClassId",
                table: "Teachers",
                column: "MainClassId",
                principalTable: "MainClasses",
                principalColumn: "Id");
        }
    }
}
