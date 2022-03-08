using Microsoft.EntityFrameworkCore.Migrations;

namespace WUSTZone.Migrations
{
    public partial class AddPostPhoto : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Photo",
                table: "Posts",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Photo",
                table: "Posts");
        }
    }
}
