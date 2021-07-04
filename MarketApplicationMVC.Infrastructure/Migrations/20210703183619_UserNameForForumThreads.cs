using Microsoft.EntityFrameworkCore.Migrations;

namespace MarketApplicationMVC.Infrastructure.Migrations
{
    public partial class UserNameForForumThreads : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ForumPosts_Users_UserId",
                table: "ForumPosts");

            migrationBuilder.DropForeignKey(
                name: "FK_ForumThreads_Users_UserId",
                table: "ForumThreads");

            migrationBuilder.DropIndex(
                name: "IX_ForumThreads_UserId",
                table: "ForumThreads");

            migrationBuilder.DropIndex(
                name: "IX_ForumPosts_UserId",
                table: "ForumPosts");

            migrationBuilder.AlterColumn<string>(
                name: "UserId",
                table: "ForumThreads",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddColumn<int>(
                name: "UserId1",
                table: "ForumThreads",
                nullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "UserId",
                table: "ForumPosts",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddColumn<int>(
                name: "UserId1",
                table: "ForumPosts",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_ForumThreads_UserId1",
                table: "ForumThreads",
                column: "UserId1");

            migrationBuilder.CreateIndex(
                name: "IX_ForumPosts_UserId1",
                table: "ForumPosts",
                column: "UserId1");

            migrationBuilder.AddForeignKey(
                name: "FK_ForumPosts_Users_UserId1",
                table: "ForumPosts",
                column: "UserId1",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_ForumThreads_Users_UserId1",
                table: "ForumThreads",
                column: "UserId1",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ForumPosts_Users_UserId1",
                table: "ForumPosts");

            migrationBuilder.DropForeignKey(
                name: "FK_ForumThreads_Users_UserId1",
                table: "ForumThreads");

            migrationBuilder.DropIndex(
                name: "IX_ForumThreads_UserId1",
                table: "ForumThreads");

            migrationBuilder.DropIndex(
                name: "IX_ForumPosts_UserId1",
                table: "ForumPosts");

            migrationBuilder.DropColumn(
                name: "UserId1",
                table: "ForumThreads");

            migrationBuilder.DropColumn(
                name: "UserId1",
                table: "ForumPosts");

            migrationBuilder.AlterColumn<int>(
                name: "UserId",
                table: "ForumThreads",
                type: "int",
                nullable: true,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "UserId",
                table: "ForumPosts",
                type: "int",
                nullable: true,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_ForumThreads_UserId",
                table: "ForumThreads",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_ForumPosts_UserId",
                table: "ForumPosts",
                column: "UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_ForumPosts_Users_UserId",
                table: "ForumPosts",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_ForumThreads_Users_UserId",
                table: "ForumThreads",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
