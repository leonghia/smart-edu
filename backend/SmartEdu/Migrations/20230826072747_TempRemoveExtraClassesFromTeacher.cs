using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace SmartEdu.Migrations
{
    /// <inheritdoc />
    public partial class TempRemoveExtraClassesFromTeacher : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ExtraClasses_Teachers_TeacherId",
                table: "ExtraClasses");

            migrationBuilder.DropIndex(
                name: "IX_ExtraClasses_TeacherId",
                table: "ExtraClasses");

            //migrationBuilder.DeleteData(
            //    table: "AspNetRoles",
            //    keyColumn: "Id",
            //    keyValue: "b0c43766-5c55-4a82-a9ac-91d04eb79cef");

            //migrationBuilder.DeleteData(
            //    table: "AspNetRoles",
            //    keyColumn: "Id",
            //    keyValue: "df899bfe-f156-4cd2-8872-14c02fe24166");

            migrationBuilder.DropColumn(
                name: "TeacherId",
                table: "ExtraClasses");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "TeacherId",
                table: "ExtraClasses",
                type: "int",
                nullable: true);

            //migrationBuilder.InsertData(
            //    table: "AspNetRoles",
            //    columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
            //    values: new object[,]
            //    {
            //        { "b0c43766-5c55-4a82-a9ac-91d04eb79cef", "6306f168-ffd9-4fcd-903b-eb2aebdb8a7b", "Admin", "ADMIN" },
            //        { "df899bfe-f156-4cd2-8872-14c02fe24166", "bd03de2d-8858-4faf-bda1-6f37a0ee9919", "User", "USER" }
            //    });

            migrationBuilder.CreateIndex(
                name: "IX_ExtraClasses_TeacherId",
                table: "ExtraClasses",
                column: "TeacherId");

            migrationBuilder.AddForeignKey(
                name: "FK_ExtraClasses_Teachers_TeacherId",
                table: "ExtraClasses",
                column: "TeacherId",
                principalTable: "Teachers",
                principalColumn: "Id");
        }
    }
}
