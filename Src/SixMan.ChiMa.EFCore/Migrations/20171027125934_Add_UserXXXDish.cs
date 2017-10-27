using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace SixMan.ChiMa.Migrations
{
    public partial class Add_UserXXXDish : Migration
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

            migrationBuilder.AlterColumn<long>(
                name: "TasteId",
                table: "Dish",
                type: "bigint",
                nullable: true,
                oldClrType: typeof(long));

            migrationBuilder.AlterColumn<long>(
                name: "DishCategoryId",
                table: "Dish",
                type: "bigint",
                nullable: true,
                oldClrType: typeof(long));

            migrationBuilder.AlterColumn<long>(
                name: "CookMethodId",
                table: "Dish",
                type: "bigint",
                nullable: true,
                oldClrType: typeof(long));

            migrationBuilder.AddColumn<long>(
                name: "HomeMadeUserId",
                table: "Dish",
                type: "bigint",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "Public",
                table: "Dish",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.CreateTable(
                name: "UserBrowseDish",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    BrowseTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreationTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatorUserId = table.Column<long>(type: "bigint", nullable: true),
                    DeleterUserId = table.Column<long>(type: "bigint", nullable: true),
                    DeletionTime = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DishId = table.Column<long>(type: "bigint", nullable: true),
                    ExtensionData = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    LastModificationTime = table.Column<DateTime>(type: "datetime2", nullable: true),
                    LastModifierUserId = table.Column<long>(type: "bigint", nullable: true),
                    UserId = table.Column<long>(type: "bigint", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserBrowseDish", x => x.Id);
                    table.ForeignKey(
                        name: "FK_UserBrowseDish_Dish_DishId",
                        column: x => x.DishId,
                        principalTable: "Dish",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_UserBrowseDish_UserInfo_UserId",
                        column: x => x.UserId,
                        principalTable: "UserInfo",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "UserCommentDish",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Content = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    CreationTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatorUserId = table.Column<long>(type: "bigint", nullable: true),
                    DeleterUserId = table.Column<long>(type: "bigint", nullable: true),
                    DeletionTime = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DishId = table.Column<long>(type: "bigint", nullable: true),
                    ExtensionData = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    LastModificationTime = table.Column<DateTime>(type: "datetime2", nullable: true),
                    LastModifierUserId = table.Column<long>(type: "bigint", nullable: true),
                    Rate = table.Column<int>(type: "int", nullable: true),
                    UserId = table.Column<long>(type: "bigint", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserCommentDish", x => x.Id);
                    table.ForeignKey(
                        name: "FK_UserCommentDish_Dish_DishId",
                        column: x => x.DishId,
                        principalTable: "Dish",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_UserCommentDish_UserInfo_UserId",
                        column: x => x.UserId,
                        principalTable: "UserInfo",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "UserFavoriteDish",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    CreationTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatorUserId = table.Column<long>(type: "bigint", nullable: true),
                    DeleterUserId = table.Column<long>(type: "bigint", nullable: true),
                    DeletionTime = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DishId = table.Column<long>(type: "bigint", nullable: true),
                    ExtensionData = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    LastModificationTime = table.Column<DateTime>(type: "datetime2", nullable: true),
                    LastModifierUserId = table.Column<long>(type: "bigint", nullable: true),
                    UserId = table.Column<long>(type: "bigint", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserFavoriteDish", x => x.Id);
                    table.ForeignKey(
                        name: "FK_UserFavoriteDish_Dish_DishId",
                        column: x => x.DishId,
                        principalTable: "Dish",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_UserFavoriteDish_UserInfo_UserId",
                        column: x => x.UserId,
                        principalTable: "UserInfo",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Dish_HomeMadeUserId",
                table: "Dish",
                column: "HomeMadeUserId");

            migrationBuilder.CreateIndex(
                name: "IX_UserBrowseDish_DishId",
                table: "UserBrowseDish",
                column: "DishId");

            migrationBuilder.CreateIndex(
                name: "IX_UserBrowseDish_UserId",
                table: "UserBrowseDish",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_UserCommentDish_DishId",
                table: "UserCommentDish",
                column: "DishId");

            migrationBuilder.CreateIndex(
                name: "IX_UserCommentDish_UserId",
                table: "UserCommentDish",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_UserFavoriteDish_DishId",
                table: "UserFavoriteDish",
                column: "DishId");

            migrationBuilder.CreateIndex(
                name: "IX_UserFavoriteDish_UserId",
                table: "UserFavoriteDish",
                column: "UserId");

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
                name: "FK_Dish_UserInfo_HomeMadeUserId",
                table: "Dish",
                column: "HomeMadeUserId",
                principalTable: "UserInfo",
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

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Dish_CookMethod_CookMethodId",
                table: "Dish");

            migrationBuilder.DropForeignKey(
                name: "FK_Dish_DishCategory_DishCategoryId",
                table: "Dish");

            migrationBuilder.DropForeignKey(
                name: "FK_Dish_UserInfo_HomeMadeUserId",
                table: "Dish");

            migrationBuilder.DropForeignKey(
                name: "FK_Dish_Taste_TasteId",
                table: "Dish");

            migrationBuilder.DropTable(
                name: "UserBrowseDish");

            migrationBuilder.DropTable(
                name: "UserCommentDish");

            migrationBuilder.DropTable(
                name: "UserFavoriteDish");

            migrationBuilder.DropIndex(
                name: "IX_Dish_HomeMadeUserId",
                table: "Dish");

            migrationBuilder.DropColumn(
                name: "HomeMadeUserId",
                table: "Dish");

            migrationBuilder.DropColumn(
                name: "Public",
                table: "Dish");

            migrationBuilder.AlterColumn<long>(
                name: "TasteId",
                table: "Dish",
                nullable: false,
                oldClrType: typeof(long),
                oldType: "bigint",
                oldNullable: true);

            migrationBuilder.AlterColumn<long>(
                name: "DishCategoryId",
                table: "Dish",
                nullable: false,
                oldClrType: typeof(long),
                oldType: "bigint",
                oldNullable: true);

            migrationBuilder.AlterColumn<long>(
                name: "CookMethodId",
                table: "Dish",
                nullable: false,
                oldClrType: typeof(long),
                oldType: "bigint",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Dish_CookMethod_CookMethodId",
                table: "Dish",
                column: "CookMethodId",
                principalTable: "CookMethod",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Dish_DishCategory_DishCategoryId",
                table: "Dish",
                column: "DishCategoryId",
                principalTable: "DishCategory",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Dish_Taste_TasteId",
                table: "Dish",
                column: "TasteId",
                principalTable: "Taste",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
