using Microsoft.EntityFrameworkCore.Migrations;

namespace MarketApplicationMVC.Infrastructure.Migrations
{
    public partial class ThirdMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Offers_OfferCategories_OfferCategoryId",
                table: "Offers");

            migrationBuilder.DropForeignKey(
                name: "FK_Users_Types_TypeId",
                table: "Users");

            migrationBuilder.AlterColumn<int>(
                name: "TypeId",
                table: "Users",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddForeignKey(
                name: "FK_Offers_OfferCategories_OfferCategoryId",
                table: "Offers",
                column: "OfferCategoryId",
                principalTable: "OfferCategories",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Users_Types_TypeId",
                table: "Users",
                column: "TypeId",
                principalTable: "Types",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Offers_OfferCategories_OfferCategoryId",
                table: "Offers");

            migrationBuilder.DropForeignKey(
                name: "FK_Users_Types_TypeId",
                table: "Users");

            migrationBuilder.AlterColumn<int>(
                name: "TypeId",
                table: "Users",
                type: "int",
                nullable: false,
                oldClrType: typeof(int),
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Offers_OfferCategories_OfferCategoryId",
                table: "Offers",
                column: "OfferCategoryId",
                principalTable: "OfferCategories",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Users_Types_TypeId",
                table: "Users",
                column: "TypeId",
                principalTable: "Types",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
