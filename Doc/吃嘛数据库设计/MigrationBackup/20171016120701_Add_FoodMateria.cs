using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace SixMan.ChiMa.Migrations
{
    public partial class Add_FoodMateria : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "FoodMaterialCategory",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: false,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Code",
                table: "FoodMaterialCategory",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: true,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.CreateTable(
                name: "FoodMaterial",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Calorie = table.Column<int>(type: "int", nullable: false),
                    Carbohydrate = table.Column<int>(type: "int", nullable: false),
                    CreationTime = table.Column<DateTime>( nullable: false),
                    CreatorUserId = table.Column<long>(type: "bigint", nullable: true),
                    DeleterUserId = table.Column<long>(type: "bigint", nullable: true),
                    DeletionTime = table.Column<DateTime>( nullable: true),
                    Description = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: false),
                    ExtensionData = table.Column<string>( nullable: true),
                    Fibrin = table.Column<int>(type: "int", nullable: false),
                    FoodMaterialCategoryId = table.Column<long>(type: "bigint", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    LastModificationTime = table.Column<DateTime>( nullable: true),
                    LastModifierUserId = table.Column<long>(type: "bigint", nullable: true),
                    Minerals = table.Column<int>(type: "int", nullable: false),
                    Protein = table.Column<int>(type: "int", nullable: false),
                    Season = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    Vitamin = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FoodMaterial", x => x.Id);
                    table.ForeignKey(
                        name: "FK_FoodMaterial_FoodMaterialCategory_FoodMaterialCategoryId",
                        column: x => x.FoodMaterialCategoryId,
                        principalTable: "FoodMaterialCategory",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                });

            migrationBuilder.CreateIndex(
                name: "IX_FoodMaterial_FoodMaterialCategoryId",
                table: "FoodMaterial",
                column: "FoodMaterialCategoryId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "FoodMaterial");

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "FoodMaterialCategory",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(50)",
                oldMaxLength: 50);

            migrationBuilder.AlterColumn<string>(
                name: "Code",
                table: "FoodMaterialCategory",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(50)",
                oldMaxLength: 50,
                oldNullable: true);
        }
    }
}
