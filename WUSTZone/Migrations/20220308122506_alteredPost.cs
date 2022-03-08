using Microsoft.EntityFrameworkCore.Migrations;

namespace WUSTZone.Migrations
{
    public partial class alteredPost : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Condensed",
                table: "Posts",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Title",
                table: "Posts",
                nullable: false,
                defaultValue: "");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Condensed",
                table: "Posts");

            migrationBuilder.DropColumn(
                name: "Title",
                table: "Posts");
        }
    }
}
