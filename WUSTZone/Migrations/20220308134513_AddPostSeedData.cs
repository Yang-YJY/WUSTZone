using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace WUSTZone.Migrations
{
    public partial class AddPostSeedData : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "Category",
                table: "Posts",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int");

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

        protected override void Down(MigrationBuilder migrationBuilder)
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
                type: "int",
                nullable: false,
                oldClrType: typeof(string));
        }
    }
}
