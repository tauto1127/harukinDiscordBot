using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace firstDiscord.Net.Migrations
{
    public partial class adddescription : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_WayPoints_TeleportChannels_TeleportChannelId",
                table: "WayPoints");

            migrationBuilder.DropIndex(
                name: "IX_WayPoints_TeleportChannelId",
                table: "WayPoints");

            migrationBuilder.DropColumn(
                name: "TeleportChannelId",
                table: "WayPoints");

            migrationBuilder.AddColumn<string>(
                name: "Description",
                table: "WayPoints",
                type: "TEXT",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Description",
                table: "TeleportChannels",
                type: "TEXT",
                nullable: false,
                defaultValue: "");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Description",
                table: "WayPoints");

            migrationBuilder.DropColumn(
                name: "Description",
                table: "TeleportChannels");

            migrationBuilder.AddColumn<int>(
                name: "TeleportChannelId",
                table: "WayPoints",
                type: "INTEGER",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_WayPoints_TeleportChannelId",
                table: "WayPoints",
                column: "TeleportChannelId");

            migrationBuilder.AddForeignKey(
                name: "FK_WayPoints_TeleportChannels_TeleportChannelId",
                table: "WayPoints",
                column: "TeleportChannelId",
                principalTable: "TeleportChannels",
                principalColumn: "Id");
        }
    }
}
