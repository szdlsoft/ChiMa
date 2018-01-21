using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace SixMan.ChiMa.Migrations
{
    public partial class add_MealType_MealNo : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Kinds",
                table: "Plan");

            migrationBuilder.RenameColumn(
                name: "KindNO",
                table: "Plan",
                newName: "MealNo");

            migrationBuilder.AddColumn<int>(
                name: "MealType",
                table: "Plan",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "MealType",
                table: "Plan");

            migrationBuilder.RenameColumn(
                name: "MealNo",
                table: "Plan",
                newName: "KindNO");

            migrationBuilder.AddColumn<string>(
                name: "Kinds",
                table: "Plan",
                maxLength: 256,
                nullable: true);
        }
    }
}
