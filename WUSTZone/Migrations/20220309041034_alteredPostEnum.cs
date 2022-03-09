using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace WUSTZone.Migrations
{
    public partial class alteredPostEnum : Migration
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

            migrationBuilder.DeleteData(
                table: "Posts",
                keyColumn: "Id",
                keyValue: 1005);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Posts",
                columns: new[] { "Id", "Category", "CommentCount", "Condensed", "Content", "IsPinned", "IsSelected", "LikeCount", "Photo", "TimeStamp", "Title", "UserId" },
                values: new object[,]
                {
                    { 1001, 1, 0, "", "郭森泽二号", false, false, 0, "", new DateTime(2022, 3, 9, 10, 7, 53, 729, DateTimeKind.Local).AddTicks(719), "", 1 },
                    { 1002, 1, 0, "", "郭森泽一号", false, false, 0, "", new DateTime(2022, 3, 9, 10, 7, 53, 731, DateTimeKind.Local).AddTicks(8180), "哈哈哈哈哈", 0 },
                    { 1003, 3, 0, "", "郭森泽三号", false, false, 0, "", new DateTime(2022, 3, 9, 10, 7, 53, 731, DateTimeKind.Local).AddTicks(8293), "", 0 },
                    { 1004, 1, 0, "", "郭森泽四号", false, false, 0, "", new DateTime(2022, 3, 9, 10, 7, 53, 731, DateTimeKind.Local).AddTicks(8296), "哈哈哈哈哈", 0 },
                    { 1005, 1, 0, "", "郭森泽五号", false, false, 0, "", new DateTime(2022, 3, 9, 10, 7, 53, 731, DateTimeKind.Local).AddTicks(8298), "哈哈哈哈哈", 0 }
                });
        }
    }
}
