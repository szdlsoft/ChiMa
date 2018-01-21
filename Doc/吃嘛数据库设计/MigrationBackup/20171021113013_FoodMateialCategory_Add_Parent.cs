using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace SixMan.ChiMa.Migrations
{
    public partial class FoodMateialCategory_Add_Parent : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<long>(
                name: "ParentId",
                table: "FoodMaterialCategory",
                type: "bigint",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_FoodMaterialCategory_ParentId",
                table: "FoodMaterialCategory",
                column: "ParentId");

            migrationBuilder.AddForeignKey(
                name: "FK_FoodMaterialCategory_FoodMaterialCategory_ParentId",
                table: "FoodMaterialCategory",
                column: "ParentId",
                principalTable: "FoodMaterialCategory",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_FoodMaterialCategory_FoodMaterialCategory_ParentId",
                table: "FoodMaterialCategory");

            migrationBuilder.DropIndex(
                name: "IX_FoodMaterialCategory_ParentId",
                table: "FoodMaterialCategory");

            migrationBuilder.DropColumn(
                name: "ParentId",
                table: "FoodMaterialCategory");
        }
    }
}
