using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SmartEdu.Migrations
{
    /// <inheritdoc />
    public partial class AddSomePropertiesToDocument : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            // migrationBuilder.DropForeignKey(
            //     name: "FK_EcBookmarks_Students_StudentId",
            //     table: "EcBookmarks");

            // migrationBuilder.DropIndex(
            //     name: "IX_EcBookmarks_StudentId",
            //     table: "EcBookmarks");

            // migrationBuilder.DropColumn(
            //     name: "StudentId",
            //     table: "EcBookmarks");

            migrationBuilder.AlterColumn<string>(
                name: "Link",
                table: "Documents",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<string>(
                name: "Description",
                table: "Documents",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AddColumn<string>(
                name: "Image",
                table: "Documents",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "NumbersOfRaing",
                table: "Documents",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<double>(
                name: "Rating",
                table: "Documents",
                type: "float",
                nullable: false,
                defaultValue: 0.0);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Image",
                table: "Documents");

            migrationBuilder.DropColumn(
                name: "NumbersOfRaing",
                table: "Documents");

            migrationBuilder.DropColumn(
                name: "Rating",
                table: "Documents");

            // migrationBuilder.AddColumn<int>(
            //     name: "StudentId",
            //     table: "EcBookmarks",
            //     type: "int",
            //     nullable: false,
            //     defaultValue: 0);

            migrationBuilder.AlterColumn<string>(
                name: "Link",
                table: "Documents",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Description",
                table: "Documents",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            // migrationBuilder.CreateIndex(
            //     name: "IX_EcBookmarks_StudentId",
            //     table: "EcBookmarks",
            //     column: "StudentId");

            // migrationBuilder.AddForeignKey(
            //     name: "FK_EcBookmarks_Students_StudentId",
            //     table: "EcBookmarks",
            //     column: "StudentId",
            //     principalTable: "Students",
            //     principalColumn: "Id",
            //     onDelete: ReferentialAction.Cascade);
        }
    }
}
