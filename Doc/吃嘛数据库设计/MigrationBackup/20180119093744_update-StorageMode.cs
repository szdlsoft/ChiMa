using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace SixMan.ChiMa.Migrations
{
    public partial class updateStorageMode : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "StorageMode",
                table: "FoodMaterialInventory");

            migrationBuilder.AddColumn<string>(
                name: "StorageMode",
                table: "FoodMaterial",
                maxLength: 256,
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "StorageMode",
                table: "FoodMaterial");

            migrationBuilder.AddColumn<string>(
                name: "StorageMode",
                table: "FoodMaterialInventory",
                maxLength: 256,
                nullable: true);
        }
    }
}
