using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace SixMan.ChiMa.Migrations
{
    public partial class Add_MulitMedia : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Audio",
                table: "FoodMaterial",
                type: "nvarchar(512)",
                maxLength: 512,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Photo",
                table: "FoodMaterial",
                type: "nvarchar(512)",
                maxLength: 512,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Video",
                table: "FoodMaterial",
                type: "nvarchar(512)",
                maxLength: 512,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Audio",
                table: "Dish",
                type: "nvarchar(512)",
                maxLength: 512,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Photo",
                table: "Dish",
                type: "nvarchar(512)",
                maxLength: 512,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Video",
                table: "Dish",
                type: "nvarchar(512)",
                maxLength: 512,
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Audio",
                table: "FoodMaterial");

            migrationBuilder.DropColumn(
                name: "Photo",
                table: "FoodMaterial");

            migrationBuilder.DropColumn(
                name: "Video",
                table: "FoodMaterial");

            migrationBuilder.DropColumn(
                name: "Audio",
                table: "Dish");

            migrationBuilder.DropColumn(
                name: "Photo",
                table: "Dish");

            migrationBuilder.DropColumn(
                name: "Video",
                table: "Dish");
        }
    }
}
