using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace firstDiscord.Net.Migrations
{
    public partial class addTeleportPipeType : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Type",
                table: "TeleportChannels",
                type: "TEXT",
                nullable: false,
                defaultValue: "");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Type",
                table: "TeleportChannels");
        }
    }
}
