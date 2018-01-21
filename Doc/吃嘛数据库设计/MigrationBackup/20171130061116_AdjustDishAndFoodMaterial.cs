using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace SixMan.ChiMa.Migrations
{
    public partial class AdjustDishAndFoodMaterial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Dish_CookMethod_CookMethodId",
                table: "Dish");

            migrationBuilder.DropForeignKey(
                name: "FK_Dish_DishCategory_DishCategoryId",
                table: "Dish");

            migrationBuilder.DropForeignKey(
                name: "FK_Dish_Taste_TasteId",
                table: "Dish");

            migrationBuilder.DropTable(
                name: "CookMethod");

            migrationBuilder.DropTable(
                name: "DishCategory");

            migrationBuilder.DropTable(
                name: "Taste");

            migrationBuilder.DropIndex(
                name: "IX_Dish_CookMethodId",
                table: "Dish");

            migrationBuilder.DropIndex(
                name: "IX_Dish_DishCategoryId",
                table: "Dish");

            migrationBuilder.DropIndex(
                name: "IX_Dish_TasteId",
                table: "Dish");

            migrationBuilder.DropColumn(
                name: "CookMethodId",
                table: "Dish");

            migrationBuilder.DropColumn(
                name: "DishCategoryId",
                table: "Dish");

            migrationBuilder.DropColumn(
                name: "TasteId",
                table: "Dish");

            migrationBuilder.AddColumn<long>(
                name: "ImportId",
                table: "FoodMaterial",
                type: "bigint",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "MatchingDescription",
                table: "DishBom",
                
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "CookMethod",
                table: "Dish",
                
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "DishCategory",
                table: "Dish",
                
                nullable: true);

            migrationBuilder.AddColumn<long>(
                name: "ImportId",
                table: "Dish",
                type: "bigint",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Taste",
                table: "Dish",
                
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ImportId",
                table: "FoodMaterial");

            migrationBuilder.DropColumn(
                name: "MatchingDescription",
                table: "DishBom");

            migrationBuilder.DropColumn(
                name: "CookMethod",
                table: "Dish");

            migrationBuilder.DropColumn(
                name: "DishCategory",
                table: "Dish");

            migrationBuilder.DropColumn(
                name: "ImportId",
                table: "Dish");

            migrationBuilder.DropColumn(
                name: "Taste",
                table: "Dish");

            migrationBuilder.AddColumn<long>(
                name: "CookMethodId",
                table: "Dish",
                nullable: true);

            migrationBuilder.AddColumn<long>(
                name: "DishCategoryId",
                table: "Dish",
                nullable: true);

            migrationBuilder.AddColumn<long>(
                name: "TasteId",
                table: "Dish",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "CookMethod",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Code = table.Column<string>(maxLength: 50, nullable: true),
                    CreationTime = table.Column<DateTime>(nullable: false),
                    CreatorUserId = table.Column<long>(nullable: true),
                    DeleterUserId = table.Column<long>(nullable: true),
                    DeletionTime = table.Column<DateTime>(nullable: true),
                    ExtensionData = table.Column<string>(nullable: true),
                    IsDeleted = table.Column<bool>(nullable: false),
                    LastModificationTime = table.Column<DateTime>(nullable: true),
                    LastModifierUserId = table.Column<long>(nullable: true),
                    Name = table.Column<string>(maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CookMethod", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "DishCategory",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Code = table.Column<string>(maxLength: 50, nullable: true),
                    CreationTime = table.Column<DateTime>(nullable: false),
                    CreatorUserId = table.Column<long>(nullable: true),
                    DeleterUserId = table.Column<long>(nullable: true),
                    DeletionTime = table.Column<DateTime>(nullable: true),
                    ExtensionData = table.Column<string>(nullable: true),
                    IsDeleted = table.Column<bool>(nullable: false),
                    LastModificationTime = table.Column<DateTime>(nullable: true),
                    LastModifierUserId = table.Column<long>(nullable: true),
                    Name = table.Column<string>(maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DishCategory", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Taste",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Code = table.Column<string>(maxLength: 50, nullable: true),
                    CreationTime = table.Column<DateTime>(nullable: false),
                    CreatorUserId = table.Column<long>(nullable: true),
                    DeleterUserId = table.Column<long>(nullable: true),
                    DeletionTime = table.Column<DateTime>(nullable: true),
                    ExtensionData = table.Column<string>(nullable: true),
                    IsDeleted = table.Column<bool>(nullable: false),
                    LastModificationTime = table.Column<DateTime>(nullable: true),
                    LastModifierUserId = table.Column<long>(nullable: true),
                    Name = table.Column<string>(maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Taste", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Dish_CookMethodId",
                table: "Dish",
                column: "CookMethodId");

            migrationBuilder.CreateIndex(
                name: "IX_Dish_DishCategoryId",
                table: "Dish",
                column: "DishCategoryId");

            migrationBuilder.CreateIndex(
                name: "IX_Dish_TasteId",
                table: "Dish",
                column: "TasteId");

            migrationBuilder.AddForeignKey(
                name: "FK_Dish_CookMethod_CookMethodId",
                table: "Dish",
                column: "CookMethodId",
                principalTable: "CookMethod",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Dish_DishCategory_DishCategoryId",
                table: "Dish",
                column: "DishCategoryId",
                principalTable: "DishCategory",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Dish_Taste_TasteId",
                table: "Dish",
                column: "TasteId",
                principalTable: "Taste",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
