using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace SixMan.ChiMa.Migrations
{
    public partial class add_cookery_content : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Plan_Dish_DishId",
                table: "Plan");

            migrationBuilder.DropForeignKey(
                name: "FK_Plan_Family_FamilyId",
                table: "Plan");

            migrationBuilder.AlterColumn<long>(
                name: "FamilyId",
                table: "Plan",
                nullable: false,
                oldClrType: typeof(long),
                oldNullable: true);

            migrationBuilder.AlterColumn<long>(
                name: "DishId",
                table: "Plan",
                nullable: false,
                oldClrType: typeof(long),
                oldNullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Content",
                table: "Cookery",
                maxLength: 512,
                nullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Plan_Dish_DishId",
                table: "Plan",
                column: "DishId",
                principalTable: "Dish",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Plan_Family_FamilyId",
                table: "Plan",
                column: "FamilyId",
                principalTable: "Family",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Plan_Dish_DishId",
                table: "Plan");

            migrationBuilder.DropForeignKey(
                name: "FK_Plan_Family_FamilyId",
                table: "Plan");

            migrationBuilder.DropColumn(
                name: "Content",
                table: "Cookery");

            migrationBuilder.AlterColumn<long>(
                name: "FamilyId",
                table: "Plan",
                nullable: true,
                oldClrType: typeof(long));

            migrationBuilder.AlterColumn<long>(
                name: "DishId",
                table: "Plan",
                nullable: true,
                oldClrType: typeof(long));

            migrationBuilder.AddForeignKey(
                name: "FK_Plan_Dish_DishId",
                table: "Plan",
                column: "DishId",
                principalTable: "Dish",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Plan_Family_FamilyId",
                table: "Plan",
                column: "FamilyId",
                principalTable: "Family",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
