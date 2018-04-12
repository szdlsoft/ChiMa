using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace SixMan.ChiMa.EFCore.Migrations
{
    public partial class add_Nutrition : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ASH",
                table: "FoodMaterial");

            migrationBuilder.DropColumn(
                name: "CA",
                table: "FoodMaterial");

            migrationBuilder.DropColumn(
                name: "CHO",
                table: "FoodMaterial");

            migrationBuilder.DropColumn(
                name: "CU",
                table: "FoodMaterial");

            migrationBuilder.DropColumn(
                name: "Carotene",
                table: "FoodMaterial");

            migrationBuilder.DropColumn(
                name: "Cholesterol",
                table: "FoodMaterial");

            migrationBuilder.DropColumn(
                name: "EnergyKcal",
                table: "FoodMaterial");

            migrationBuilder.DropColumn(
                name: "EnergyKj",
                table: "FoodMaterial");

            migrationBuilder.DropColumn(
                name: "FE",
                table: "FoodMaterial");

            migrationBuilder.DropColumn(
                name: "Fat",
                table: "FoodMaterial");

            migrationBuilder.DropColumn(
                name: "Fibrin",
                table: "FoodMaterial");

            migrationBuilder.DropColumn(
                name: "K",
                table: "FoodMaterial");

            migrationBuilder.DropColumn(
                name: "MG",
                table: "FoodMaterial");

            migrationBuilder.DropColumn(
                name: "MN",
                table: "FoodMaterial");

            migrationBuilder.DropColumn(
                name: "NA",
                table: "FoodMaterial");

            migrationBuilder.DropColumn(
                name: "Niacin",
                table: "FoodMaterial");

            migrationBuilder.DropColumn(
                name: "P",
                table: "FoodMaterial");

            migrationBuilder.DropColumn(
                name: "Protein",
                table: "FoodMaterial");

            migrationBuilder.DropColumn(
                name: "Retinol",
                table: "FoodMaterial");

            migrationBuilder.DropColumn(
                name: "Riboflavin",
                table: "FoodMaterial");

            migrationBuilder.DropColumn(
                name: "SE",
                table: "FoodMaterial");

            migrationBuilder.DropColumn(
                name: "Thiamin",
                table: "FoodMaterial");

            migrationBuilder.DropColumn(
                name: "VitaminA",
                table: "FoodMaterial");

            migrationBuilder.DropColumn(
                name: "VitaminC",
                table: "FoodMaterial");

            migrationBuilder.DropColumn(
                name: "VitaminE",
                table: "FoodMaterial");

            migrationBuilder.DropColumn(
                name: "Water",
                table: "FoodMaterial");

            migrationBuilder.DropColumn(
                name: "ZN",
                table: "FoodMaterial");

            migrationBuilder.AddColumn<string>(
                name: "EnglishName",
                table: "FoodMaterial",
                maxLength: 50,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "SourceUrl",
                table: "FoodMaterial",
                maxLength: 200,
                nullable: true);

            migrationBuilder.CreateTable(
                name: "Nutrition",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Category = table.Column<string>(maxLength: 50, nullable: true),
                    Name = table.Column<string>(maxLength: 50, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Nutrition", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "FoodMaterialNutrition",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Content = table.Column<double>(nullable: false),
                    FoodMaterialId = table.Column<long>(nullable: true),
                    NutritionId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FoodMaterialNutrition", x => x.Id);
                    table.ForeignKey(
                        name: "FK_FoodMaterialNutrition_FoodMaterial_FoodMaterialId",
                        column: x => x.FoodMaterialId,
                        principalTable: "FoodMaterial",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_FoodMaterialNutrition_Nutrition_NutritionId",
                        column: x => x.NutritionId,
                        principalTable: "Nutrition",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_FoodMaterialNutrition_FoodMaterialId",
                table: "FoodMaterialNutrition",
                column: "FoodMaterialId");

            migrationBuilder.CreateIndex(
                name: "IX_FoodMaterialNutrition_NutritionId",
                table: "FoodMaterialNutrition",
                column: "NutritionId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "FoodMaterialNutrition");

            migrationBuilder.DropTable(
                name: "Nutrition");

            migrationBuilder.DropColumn(
                name: "EnglishName",
                table: "FoodMaterial");

            migrationBuilder.DropColumn(
                name: "SourceUrl",
                table: "FoodMaterial");

            migrationBuilder.AddColumn<double>(
                name: "ASH",
                table: "FoodMaterial",
                nullable: true);

            migrationBuilder.AddColumn<double>(
                name: "CA",
                table: "FoodMaterial",
                nullable: true);

            migrationBuilder.AddColumn<double>(
                name: "CHO",
                table: "FoodMaterial",
                nullable: true);

            migrationBuilder.AddColumn<double>(
                name: "CU",
                table: "FoodMaterial",
                nullable: true);

            migrationBuilder.AddColumn<double>(
                name: "Carotene",
                table: "FoodMaterial",
                nullable: true);

            migrationBuilder.AddColumn<double>(
                name: "Cholesterol",
                table: "FoodMaterial",
                nullable: true);

            migrationBuilder.AddColumn<double>(
                name: "EnergyKcal",
                table: "FoodMaterial",
                nullable: true);

            migrationBuilder.AddColumn<double>(
                name: "EnergyKj",
                table: "FoodMaterial",
                nullable: true);

            migrationBuilder.AddColumn<double>(
                name: "FE",
                table: "FoodMaterial",
                nullable: true);

            migrationBuilder.AddColumn<double>(
                name: "Fat",
                table: "FoodMaterial",
                nullable: true);

            migrationBuilder.AddColumn<double>(
                name: "Fibrin",
                table: "FoodMaterial",
                nullable: true);

            migrationBuilder.AddColumn<double>(
                name: "K",
                table: "FoodMaterial",
                nullable: true);

            migrationBuilder.AddColumn<double>(
                name: "MG",
                table: "FoodMaterial",
                nullable: true);

            migrationBuilder.AddColumn<double>(
                name: "MN",
                table: "FoodMaterial",
                nullable: true);

            migrationBuilder.AddColumn<double>(
                name: "NA",
                table: "FoodMaterial",
                nullable: true);

            migrationBuilder.AddColumn<double>(
                name: "Niacin",
                table: "FoodMaterial",
                nullable: true);

            migrationBuilder.AddColumn<double>(
                name: "P",
                table: "FoodMaterial",
                nullable: true);

            migrationBuilder.AddColumn<double>(
                name: "Protein",
                table: "FoodMaterial",
                nullable: true);

            migrationBuilder.AddColumn<double>(
                name: "Retinol",
                table: "FoodMaterial",
                nullable: true);

            migrationBuilder.AddColumn<double>(
                name: "Riboflavin",
                table: "FoodMaterial",
                nullable: true);

            migrationBuilder.AddColumn<double>(
                name: "SE",
                table: "FoodMaterial",
                nullable: true);

            migrationBuilder.AddColumn<double>(
                name: "Thiamin",
                table: "FoodMaterial",
                nullable: true);

            migrationBuilder.AddColumn<double>(
                name: "VitaminA",
                table: "FoodMaterial",
                nullable: true);

            migrationBuilder.AddColumn<double>(
                name: "VitaminC",
                table: "FoodMaterial",
                nullable: true);

            migrationBuilder.AddColumn<double>(
                name: "VitaminE",
                table: "FoodMaterial",
                nullable: true);

            migrationBuilder.AddColumn<double>(
                name: "Water",
                table: "FoodMaterial",
                nullable: true);

            migrationBuilder.AddColumn<double>(
                name: "ZN",
                table: "FoodMaterial",
                nullable: true);
        }
    }
}
