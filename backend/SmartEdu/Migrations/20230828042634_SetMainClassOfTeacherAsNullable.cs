using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SmartEdu.Migrations
{
    /// <inheritdoc />
    public partial class SetMainClassOfTeacherAsNullable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Teachers_MainClasses_MainClassId",
                table: "Teachers");

            migrationBuilder.AlterColumn<int>(
                name: "MainClassId",
                table: "Teachers",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddForeignKey(
                name: "FK_Teachers_MainClasses_MainClassId",
                table: "Teachers",
                column: "MainClassId",
                principalTable: "MainClasses",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Teachers_MainClasses_MainClassId",
                table: "Teachers");

            migrationBuilder.AlterColumn<int>(
                name: "MainClassId",
                table: "Teachers",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Teachers_MainClasses_MainClassId",
                table: "Teachers",
                column: "MainClassId",
                principalTable: "MainClasses",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
