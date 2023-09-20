using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SmartEdu.Migrations
{
    /// <inheritdoc />
    public partial class AddBookmarkForExtraClasses : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "EcBookmarkId",
                table: "Students",
                type: "int",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "EcBookmarks",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1")         
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EcBookmarks", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ExtraClassesEcBookmarks",
                columns: table => new
                {
                    EcBookmarkId = table.Column<int>(type: "int", nullable: false),
                    ExtraClassId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ExtraClassesEcBookmarks", x => new { x.EcBookmarkId, x.ExtraClassId });
                    table.ForeignKey(
                        name: "FK_ExtraClassesEcBookmarks_EcBookmarks_EcBookmarkId",
                        column: x => x.EcBookmarkId,
                        principalTable: "EcBookmarks",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                    table.ForeignKey(
                        name: "FK_ExtraClassesEcBookmarks_ExtraClasses_ExtraClassId",
                        column: x => x.ExtraClassId,
                        principalTable: "ExtraClasses",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Students_EcBookmarkId",
                table: "Students",
                column: "EcBookmarkId");

            migrationBuilder.CreateIndex(
                name: "IX_ExtraClassesEcBookmarks_ExtraClassId",
                table: "ExtraClassesEcBookmarks",
                column: "ExtraClassId");

            migrationBuilder.AddForeignKey(
                name: "FK_Students_EcBookmarks_EcBookmarkId",
                table: "Students",
                column: "EcBookmarkId",
                principalTable: "EcBookmarks",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Students_EcBookmarks_EcBookmarkId",
                table: "Students");

            migrationBuilder.DropTable(
                name: "ExtraClassesEcBookmarks");

            migrationBuilder.DropTable(
                name: "EcBookmarks");

            migrationBuilder.DropIndex(
                name: "IX_Students_EcBookmarkId",
                table: "Students");

            migrationBuilder.DropColumn(
                name: "EcBookmarkId",
                table: "Students");
        }
    }
}
