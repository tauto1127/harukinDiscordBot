using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace firstDiscord.Net.Migrations
{
    public partial class addRelation : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Id",
                table: "WebCategories",
                newName: "WebCategoryId");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "WebBookmarks",
                newName: "WebBookmarkId");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "WayPoints",
                newName: "WayPointId");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "WayPointCategories",
                newName: "WayPointCategoryId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "WebCategoryId",
                table: "WebCategories",
                newName: "Id");

            migrationBuilder.RenameColumn(
                name: "WebBookmarkId",
                table: "WebBookmarks",
                newName: "Id");

            migrationBuilder.RenameColumn(
                name: "WayPointId",
                table: "WayPoints",
                newName: "Id");

            migrationBuilder.RenameColumn(
                name: "WayPointCategoryId",
                table: "WayPointCategories",
                newName: "Id");
        }
    }
}
