using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SmartEdu.Migrations
{
    /// <inheritdoc />
    public partial class AddSomePropsToExtraClass : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Description",
                table: "ExtraClasses",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<TimeSpan>(
                name: "From",
                table: "ExtraClasses",
                type: "time",
                nullable: false,
                defaultValue: new TimeSpan(0, 0, 0, 0, 0));

            migrationBuilder.AddColumn<string>(
                name: "Image",
                table: "ExtraClasses",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<DateTime>(
                name: "OpeningDate",
                table: "ExtraClasses",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<TimeSpan>(
                name: "To",
                table: "ExtraClasses",
                type: "time",
                nullable: false,
                defaultValue: new TimeSpan(0, 0, 0, 0, 0));

            migrationBuilder.AddColumn<byte>(
                name: "Weekday",
                table: "ExtraClasses",
                type: "tinyint",
                nullable: false,
                defaultValue: (byte)0);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Description",
                table: "ExtraClasses");

            migrationBuilder.DropColumn(
                name: "From",
                table: "ExtraClasses");

            migrationBuilder.DropColumn(
                name: "Image",
                table: "ExtraClasses");

            migrationBuilder.DropColumn(
                name: "OpeningDate",
                table: "ExtraClasses");

            migrationBuilder.DropColumn(
                name: "To",
                table: "ExtraClasses");

            migrationBuilder.DropColumn(
                name: "Weekday",
                table: "ExtraClasses");
        }
    }
}
