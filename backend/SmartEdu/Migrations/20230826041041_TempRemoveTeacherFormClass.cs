using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace SmartEdu.Migrations
{
    /// <inheritdoc />
    public partial class TempRemoveTeacherFormClass : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
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

            //migrationBuilder.DeleteData(
            //    table: "AspNetRoles",
            //    keyColumn: "Id",
            //    keyValue: "ac67196b-3d4a-44ed-9b49-b35343e57bb0");

            //migrationBuilder.DeleteData(
            //    table: "AspNetRoles",
            //    keyColumn: "Id",
            //    keyValue: "f91facd7-5027-4c85-828a-3c9a0994f2ba");

            migrationBuilder.DropColumn(
                name: "TeacherId",
                table: "MainClasses");

            migrationBuilder.RenameColumn(
                name: "type",
                table: "Exams",
                newName: "Type");

            migrationBuilder.AlterColumn<int>(
                name: "TeacherId",
                table: "ExtraClasses",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            //migrationBuilder.InsertData(
            //    table: "AspNetRoles",
            //    columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
            //    values: new object[,]
            //    {
            //        { "4c35255c-274e-499f-93e1-1180f7272315", "c6fa7d39-4d52-494c-be5a-bf74f7ac4f83", "Admin", "ADMIN" },
            //        { "72ff2f12-ffa5-4774-b67a-8d0215d84550", "b37c72de-70e3-4b98-9eca-21b03eaa666d", "User", "USER" }
            //    });

            migrationBuilder.AddForeignKey(
                name: "FK_ExtraClasses_Teachers_TeacherId",
                table: "ExtraClasses",
                column: "TeacherId",
                principalTable: "Teachers",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ExtraClasses_Teachers_TeacherId",
                table: "ExtraClasses");

            //migrationBuilder.DeleteData(
            //    table: "AspNetRoles",
            //    keyColumn: "Id",
            //    keyValue: "4c35255c-274e-499f-93e1-1180f7272315");

            //migrationBuilder.DeleteData(
            //    table: "AspNetRoles",
            //    keyColumn: "Id",
            //    keyValue: "72ff2f12-ffa5-4774-b67a-8d0215d84550");

            migrationBuilder.RenameColumn(
                name: "Type",
                table: "Exams",
                newName: "type");

            migrationBuilder.AddColumn<int>(
                name: "TeacherId",
                table: "MainClasses",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AlterColumn<int>(
                name: "TeacherId",
                table: "ExtraClasses",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            //migrationBuilder.InsertData(
            //    table: "AspNetRoles",
            //    columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
            //    values: new object[,]
            //    {
            //        { "ac67196b-3d4a-44ed-9b49-b35343e57bb0", "a741670f-6482-439f-a966-8df6a4b6eb8d", "User", "USER" },
            //        { "f91facd7-5027-4c85-828a-3c9a0994f2ba", "15918b0a-7433-4bee-ab14-b071fc42fe94", "Admin", "ADMIN" }
            //    });

            migrationBuilder.CreateIndex(
                name: "IX_MainClasses_TeacherId",
                table: "MainClasses",
                column: "TeacherId");

            migrationBuilder.AddForeignKey(
                name: "FK_ExtraClasses_Teachers_TeacherId",
                table: "ExtraClasses",
                column: "TeacherId",
                principalTable: "Teachers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_MainClasses_Teachers_TeacherId",
                table: "MainClasses",
                column: "TeacherId",
                principalTable: "Teachers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
