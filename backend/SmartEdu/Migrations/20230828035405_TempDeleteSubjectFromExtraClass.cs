using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SmartEdu.Migrations
{
    /// <inheritdoc />
    public partial class TempDeleteSubjectFromExtraClass : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            //migrationBuilder.DropForeignKey(
            //    name: "FK_ExtraClasses_Subjects_SubjectId",
            //    table: "ExtraClasses");

            migrationBuilder.DropIndex(
                name: "IX_ExtraClasses_SubjectId",
                table: "ExtraClasses");

            migrationBuilder.DropColumn(
                name: "SubjectId",
                table: "ExtraClasses");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "SubjectId",
                table: "ExtraClasses",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.UpdateData(
                table: "ExtraClasses",
                keyColumn: "Id",
                keyValue: 1,
                column: "SubjectId",
                value: 0);

            migrationBuilder.UpdateData(
                table: "ExtraClasses",
                keyColumn: "Id",
                keyValue: 2,
                column: "SubjectId",
                value: 0);

            migrationBuilder.UpdateData(
                table: "ExtraClasses",
                keyColumn: "Id",
                keyValue: 3,
                column: "SubjectId",
                value: 0);

            migrationBuilder.CreateIndex(
                name: "IX_ExtraClasses_SubjectId",
                table: "ExtraClasses",
                column: "SubjectId");

            //migrationBuilder.AddForeignKey(
            //    name: "FK_ExtraClasses_Subjects_SubjectId",
            //    table: "ExtraClasses",
            //    column: "SubjectId",
            //    principalTable: "Subjects",
            //    principalColumn: "Id",
            //    onDelete: ReferentialAction.Cascade);
        }
    }
}
