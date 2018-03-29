using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace SixMan.ChiMa.Migrations
{
    public partial class Add_mha_Foreign_Key : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateIndex(
                name: "IX_FoodMaterialHealthAffect_HealthConcernId",
                table: "FoodMaterialHealthAffect",
                column: "HealthConcernId");

            migrationBuilder.AddForeignKey(
                name: "FK_FoodMaterialHealthAffect_HealthConcern_HealthConcernId",
                table: "FoodMaterialHealthAffect",
                column: "HealthConcernId",
                principalTable: "HealthConcern",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_FoodMaterialHealthAffect_HealthConcern_HealthConcernId",
                table: "FoodMaterialHealthAffect");

            migrationBuilder.DropIndex(
                name: "IX_FoodMaterialHealthAffect_HealthConcernId",
                table: "FoodMaterialHealthAffect");
        }
    }
}
