using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace firstDiscord.Net.Migrations
{
    public partial class first : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "TeleportChannels",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Name = table.Column<string>(type: "TEXT", nullable: false),
                    Channel = table.Column<int>(type: "INTEGER", nullable: false),
                    Created = table.Column<DateTime>(type: "TEXT", nullable: false),
                    Modified = table.Column<DateTime>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TeleportChannels", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "WayPointCategories",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Name = table.Column<string>(type: "TEXT", nullable: false),
                    Created = table.Column<DateTime>(type: "TEXT", nullable: false),
                    Modified = table.Column<DateTime>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_WayPointCategories", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "WebBookmarks",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Name = table.Column<string>(type: "TEXT", nullable: false),
                    URL = table.Column<string>(type: "TEXT", nullable: false),
                    Description = table.Column<string>(type: "TEXT", nullable: true),
                    WebCategoryId = table.Column<int>(type: "INTEGER", nullable: false),
                    Created = table.Column<DateTime>(type: "TEXT", nullable: false),
                    Modified = table.Column<DateTime>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_WebBookmarks", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "WebCategories",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Name = table.Column<string>(type: "TEXT", nullable: false),
                    Created = table.Column<DateTime>(type: "TEXT", nullable: false),
                    Modified = table.Column<DateTime>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_WebCategories", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "WayPoints",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Name = table.Column<string>(type: "TEXT", nullable: false),
                    X = table.Column<float>(type: "REAL", nullable: false),
                    Y = table.Column<float>(type: "REAL", nullable: false),
                    Z = table.Column<float>(type: "REAL", nullable: false),
                    WayPointCategoryId = table.Column<int>(type: "INTEGER", nullable: false),
                    Created = table.Column<DateTime>(type: "TEXT", nullable: false),
                    Modified = table.Column<DateTime>(type: "TEXT", nullable: false),
                    TeleportChannelId = table.Column<int>(type: "INTEGER", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_WayPoints", x => x.Id);
                    table.ForeignKey(
                        name: "FK_WayPoints_TeleportChannels_TeleportChannelId",
                        column: x => x.TeleportChannelId,
                        principalTable: "TeleportChannels",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_WayPoints_TeleportChannelId",
                table: "WayPoints",
                column: "TeleportChannelId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "WayPointCategories");

            migrationBuilder.DropTable(
                name: "WayPoints");

            migrationBuilder.DropTable(
                name: "WebBookmarks");

            migrationBuilder.DropTable(
                name: "WebCategories");

            migrationBuilder.DropTable(
                name: "TeleportChannels");
        }
    }
}
