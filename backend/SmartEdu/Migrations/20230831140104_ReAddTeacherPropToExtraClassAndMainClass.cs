using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SmartEdu.Migrations
{
    /// <inheritdoc />
    public partial class ReAddTeacherPropToExtraClassAndMainClass : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "TeacherId",
                table: "MainClasses",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "TeacherId",
                table: "ExtraClasses",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_MainClasses_TeacherId",
                table: "MainClasses",
                column: "TeacherId");

            migrationBuilder.CreateIndex(
                name: "IX_ExtraClasses_TeacherId",
                table: "ExtraClasses",
                column: "TeacherId");

            migrationBuilder.AddForeignKey(
                name: "FK_ExtraClasses_Teachers_TeacherId",
                table: "ExtraClasses",
                column: "TeacherId",
                principalTable: "Teachers",
                principalColumn: "Id",
                onDelete: ReferentialAction.NoAction);

            migrationBuilder.AddForeignKey(
                name: "FK_MainClasses_Teachers_TeacherId",
                table: "MainClasses",
                column: "TeacherId",
                principalTable: "Teachers",
                principalColumn: "Id",
                onDelete: ReferentialAction.NoAction);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ExtraClasses_Teachers_TeacherId",
                table: "ExtraClasses");

            migrationBuilder.DropForeignKey(
                name: "FK_MainClasses_Teachers_TeacherId",
                table: "MainClasses");

            migrationBuilder.DropIndex(
                name: "IX_MainClasses_TeacherId",
                table: "MainClasses");

            migrationBuilder.DropIndex(
                name: "IX_ExtraClasses_TeacherId",
                table: "ExtraClasses");

            migrationBuilder.DropColumn(
                name: "TeacherId",
                table: "MainClasses");

            migrationBuilder.DropColumn(
                name: "TeacherId",
                table: "ExtraClasses");
        }
    }
}
