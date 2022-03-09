using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace WUSTZone.Migrations
{
    public partial class AddSeedPostTestData : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "UserName",
                table: "Users",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

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

            migrationBuilder.CreateIndex(
                name: "IX_Users_UserName",
                table: "Users",
                column: "UserName",
                unique: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Users_UserName",
                table: "Users");

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

            migrationBuilder.AlterColumn<string>(
                name: "UserName",
                table: "Users",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string));
        }
    }
}
