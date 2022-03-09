using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace WUSTZone.Migrations
{
    public partial class AddSeedData : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Posts",
                keyColumn: "Id",
                keyValue: 1001);

            migrationBuilder.DeleteData(
                table: "Posts",
                keyColumn: "Id",
                keyValue: 1002);

            migrationBuilder.DeleteData(
                table: "Posts",
                keyColumn: "Id",
                keyValue: 1003);

            migrationBuilder.DeleteData(
                table: "Posts",
                keyColumn: "Id",
                keyValue: 1004);

            migrationBuilder.AlterColumn<int>(
                name: "Category",
                table: "Posts",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.CreateTable(
                name: "Comments",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PostId = table.Column<int>(nullable: false),
                    UserId = table.Column<int>(nullable: false),
                    FatherId = table.Column<int>(nullable: false),
                    TimeStamp = table.Column<DateTime>(nullable: false),
                    Content = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Comments", x => x.Id);
                });
        }



        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Comments");

            migrationBuilder.AlterColumn<string>(
                name: "Category",
                table: "Posts",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(int));

            migrationBuilder.InsertData(
                table: "Posts",
                columns: new[] { "Id", "Category", "CommentCount", "Condensed", "Content", "IsPinned", "IsSelected", "LikeCount", "Photo", "TimeStamp", "Title", "UserId" },
                values: new object[,]
                {
                    { 1001, "树洞", 0, "", "郭森泽二号", false, false, 0, "", new DateTime(2022, 3, 8, 21, 45, 12, 931, DateTimeKind.Local).AddTicks(6036), "", 1 },
                    { 1002, "求助", 0, "", "郭森泽一号", false, false, 0, "", new DateTime(2022, 3, 8, 21, 45, 12, 934, DateTimeKind.Local).AddTicks(5434), "", 0 },
                    { 1003, "闲聊", 0, "", "郭森泽三号", false, false, 0, "", new DateTime(2022, 3, 8, 21, 45, 12, 934, DateTimeKind.Local).AddTicks(5565), "", 0 },
                    { 1004, "默认类型", 0, "", "郭森泽四号", false, false, 0, "", new DateTime(2022, 3, 8, 21, 45, 12, 934, DateTimeKind.Local).AddTicks(5569), "", 0 }
                });
        }
    }
}
