using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace SixMan.ChiMa.Migrations
{
    public partial class update_food_dish : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Calorie",
                table: "FoodMaterial");

            migrationBuilder.DropColumn(
                name: "Carbohydrate",
                table: "FoodMaterial");

            migrationBuilder.DropColumn(
                name: "Minerals",
                table: "FoodMaterial");

            migrationBuilder.DropColumn(
                name: "Vitamin",
                table: "FoodMaterial");

            migrationBuilder.DropColumn(
                name: "MatchingType",
                table: "DishBom");

            migrationBuilder.AlterColumn<double>(
                name: "Protein",
                table: "FoodMaterial",
                type: "float",
                nullable: true,
                oldClrType: typeof(int));

            migrationBuilder.AlterColumn<double>(
                name: "Fibrin",
                table: "FoodMaterial",
                type: "float",
                nullable: true,
                oldClrType: typeof(int));

            migrationBuilder.AddColumn<double>(
                name: "ASH",
                table: "FoodMaterial",
                type: "float",
                nullable: true);

            migrationBuilder.AddColumn<double>(
                name: "CA",
                table: "FoodMaterial",
                type: "float",
                nullable: true);

            migrationBuilder.AddColumn<double>(
                name: "CHO",
                table: "FoodMaterial",
                type: "float",
                nullable: true);

            migrationBuilder.AddColumn<double>(
                name: "CU",
                table: "FoodMaterial",
                type: "float",
                nullable: true);

            migrationBuilder.AddColumn<double>(
                name: "Carotene",
                table: "FoodMaterial",
                type: "float",
                nullable: true);

            migrationBuilder.AddColumn<double>(
                name: "Cholesterol",
                table: "FoodMaterial",
                type: "float",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "EdiblePercent",
                table: "FoodMaterial",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<double>(
                name: "EnergyKcal",
                table: "FoodMaterial",
                type: "float",
                nullable: true);

            migrationBuilder.AddColumn<double>(
                name: "EnergyKj",
                table: "FoodMaterial",
                type: "float",
                nullable: true);

            migrationBuilder.AddColumn<double>(
                name: "FE",
                table: "FoodMaterial",
                type: "float",
                nullable: true);

            migrationBuilder.AddColumn<double>(
                name: "Fat",
                table: "FoodMaterial",
                type: "float",
                nullable: true);

            migrationBuilder.AddColumn<double>(
                name: "K",
                table: "FoodMaterial",
                type: "float",
                nullable: true);

            migrationBuilder.AddColumn<double>(
                name: "MG",
                table: "FoodMaterial",
                type: "float",
                nullable: true);

            migrationBuilder.AddColumn<double>(
                name: "MN",
                table: "FoodMaterial",
                type: "float",
                nullable: true);

            migrationBuilder.AddColumn<double>(
                name: "NA",
                table: "FoodMaterial",
                type: "float",
                nullable: true);

            migrationBuilder.AddColumn<double>(
                name: "Niacin",
                table: "FoodMaterial",
                type: "float",
                nullable: true);

            migrationBuilder.AddColumn<double>(
                name: "P",
                table: "FoodMaterial",
                type: "float",
                nullable: true);

            migrationBuilder.AddColumn<double>(
                name: "Retinol",
                table: "FoodMaterial",
                type: "float",
                nullable: true);

            migrationBuilder.AddColumn<double>(
                name: "Riboflavin",
                table: "FoodMaterial",
                type: "float",
                nullable: true);

            migrationBuilder.AddColumn<double>(
                name: "SE",
                table: "FoodMaterial",
                type: "float",
                nullable: true);

            migrationBuilder.AddColumn<double>(
                name: "Thiamin",
                table: "FoodMaterial",
                type: "float",
                nullable: true);

            migrationBuilder.AddColumn<double>(
                name: "VitaminA",
                table: "FoodMaterial",
                type: "float",
                nullable: true);

            migrationBuilder.AddColumn<double>(
                name: "VitaminC",
                table: "FoodMaterial",
                type: "float",
                nullable: true);

            migrationBuilder.AddColumn<double>(
                name: "VitaminE",
                table: "FoodMaterial",
                type: "float",
                nullable: true);

            migrationBuilder.AddColumn<double>(
                name: "Water",
                table: "FoodMaterial",
                type: "float",
                nullable: true);

            migrationBuilder.AddColumn<double>(
                name: "ZN",
                table: "FoodMaterial",
                type: "float",
                nullable: true);

            migrationBuilder.AlterColumn<double>(
                name: "Matching",
                table: "DishBom",
                type: "float",
                nullable: false,
                oldClrType: typeof(int));

            migrationBuilder.AddColumn<string>(
                name: "PreProcess",
                table: "DishBom",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "EnglishName",
                table: "Dish",
                type: "nvarchar(max)",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
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
                name: "EdiblePercent",
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

            migrationBuilder.DropColumn(
                name: "PreProcess",
                table: "DishBom");

            migrationBuilder.DropColumn(
                name: "EnglishName",
                table: "Dish");

            migrationBuilder.AlterColumn<int>(
                name: "Protein",
                table: "FoodMaterial",
                nullable: false,
                oldClrType: typeof(double),
                oldType: "float",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "Fibrin",
                table: "FoodMaterial",
                nullable: false,
                oldClrType: typeof(double),
                oldType: "float",
                oldNullable: true);

            migrationBuilder.AddColumn<int>(
                name: "Calorie",
                table: "FoodMaterial",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "Carbohydrate",
                table: "FoodMaterial",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "Minerals",
                table: "FoodMaterial",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "Vitamin",
                table: "FoodMaterial",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AlterColumn<int>(
                name: "Matching",
                table: "DishBom",
                nullable: false,
                oldClrType: typeof(double),
                oldType: "float");

            migrationBuilder.AddColumn<int>(
                name: "MatchingType",
                table: "DishBom",
                nullable: false,
                defaultValue: 0);
        }
    }
}
