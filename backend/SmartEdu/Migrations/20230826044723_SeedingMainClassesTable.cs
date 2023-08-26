using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace SmartEdu.Migrations
{
    /// <inheritdoc />
    public partial class SeedingMainClassesTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "4c35255c-274e-499f-93e1-1180f7272315");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "72ff2f12-ffa5-4774-b67a-8d0215d84550");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "b0c43766-5c55-4a82-a9ac-91d04eb79cef", "6306f168-ffd9-4fcd-903b-eb2aebdb8a7b", "Admin", "ADMIN" },
                    { "df899bfe-f156-4cd2-8872-14c02fe24166", "bd03de2d-8858-4faf-bda1-6f37a0ee9919", "User", "USER" }
                });

            migrationBuilder.InsertData(
                table: "MainClasses",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { 1, "10A" },
                    { 2, "10B" },
                    { 3, "10C" },
                    { 4, "10D" },
                    { 5, "10E" },
                    { 6, "10G" },
                    { 7, "10H" },
                    { 8, "10I" },
                    { 9, "10K" },
                    { 10, "10M" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "b0c43766-5c55-4a82-a9ac-91d04eb79cef");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "df899bfe-f156-4cd2-8872-14c02fe24166");

            migrationBuilder.DeleteData(
                table: "MainClasses",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "MainClasses",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "MainClasses",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "MainClasses",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "MainClasses",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "MainClasses",
                keyColumn: "Id",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "MainClasses",
                keyColumn: "Id",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "MainClasses",
                keyColumn: "Id",
                keyValue: 8);

            migrationBuilder.DeleteData(
                table: "MainClasses",
                keyColumn: "Id",
                keyValue: 9);

            migrationBuilder.DeleteData(
                table: "MainClasses",
                keyColumn: "Id",
                keyValue: 10);

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "4c35255c-274e-499f-93e1-1180f7272315", "c6fa7d39-4d52-494c-be5a-bf74f7ac4f83", "Admin", "ADMIN" },
                    { "72ff2f12-ffa5-4774-b67a-8d0215d84550", "b37c72de-70e3-4b98-9eca-21b03eaa666d", "User", "USER" }
                });
        }
    }
}
