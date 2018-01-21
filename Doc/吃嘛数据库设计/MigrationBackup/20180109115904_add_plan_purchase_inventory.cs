using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace SixMan.ChiMa.Migrations
{
    public partial class add_plan_purchase_inventory : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "IndexNo",
                table: "FoodMaterialCategory",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "IsMain",
                table: "FoodMaterial",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<double>(
                name: "Price",
                table: "FoodMaterial",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Unit",
                table: "FoodMaterial",
                maxLength: 256,
                nullable: true);

            migrationBuilder.CreateTable(
                name: "FoodMaterialInventory",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    CreationTime = table.Column<DateTime>(nullable: false),
                    CreatorUserId = table.Column<long>(nullable: true),
                    DeleterUserId = table.Column<long>(nullable: true),
                    DeletionTime = table.Column<DateTime>(nullable: true),
                    ExtensionData = table.Column<string>(nullable: true),
                    FamilyId = table.Column<long>(nullable: true),
                    FoodMaterialId = table.Column<long>(nullable: true),
                    Inventory = table.Column<int>(nullable: true),
                    IsDeleted = table.Column<bool>(nullable: false),
                    LastModificationTime = table.Column<DateTime>(nullable: true),
                    LastModifierUserId = table.Column<long>(nullable: true),
                    StorageMode = table.Column<string>(maxLength: 256, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FoodMaterialInventory", x => x.Id);
                    table.ForeignKey(
                        name: "FK_FoodMaterialInventory_Family_FamilyId",
                        column: x => x.FamilyId,
                        principalTable: "Family",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_FoodMaterialInventory_FoodMaterial_FoodMaterialId",
                        column: x => x.FoodMaterialId,
                        principalTable: "FoodMaterial",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Plan",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    CreationTime = table.Column<DateTime>(nullable: false),
                    CreatorUserId = table.Column<long>(nullable: true),
                    DeleterUserId = table.Column<long>(nullable: true),
                    DeletionTime = table.Column<DateTime>(nullable: true),
                    DishId = table.Column<long>(nullable: true),
                    ExtensionData = table.Column<string>(nullable: true),
                    FamilyId = table.Column<long>(nullable: true),
                    IsDeleted = table.Column<bool>(nullable: false),
                    KindNO = table.Column<int>(nullable: false),
                    Kinds = table.Column<string>(maxLength: 256, nullable: true),
                    LastModificationTime = table.Column<DateTime>(nullable: true),
                    LastModifierUserId = table.Column<long>(nullable: true),
                    PlanDate = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Plan", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Plan_Dish_DishId",
                        column: x => x.DishId,
                        principalTable: "Dish",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Plan_Family_FamilyId",
                        column: x => x.FamilyId,
                        principalTable: "Family",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Purchase",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    CreationTime = table.Column<DateTime>(nullable: false),
                    CreatorUserId = table.Column<long>(nullable: true),
                    DeleterUserId = table.Column<long>(nullable: true),
                    DeletionTime = table.Column<DateTime>(nullable: true),
                    ExtensionData = table.Column<string>(nullable: true),
                    FamilyId = table.Column<long>(nullable: true),
                    FoodMaterialId = table.Column<long>(nullable: true),
                    HasPurchased = table.Column<bool>(nullable: false),
                    IsDeleted = table.Column<bool>(nullable: false),
                    LastModificationTime = table.Column<DateTime>(nullable: true),
                    LastModifierUserId = table.Column<long>(nullable: true),
                    MakeTime = table.Column<DateTime>(nullable: true),
                    PurchaseTime = table.Column<DateTime>(nullable: true),
                    Volume = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Purchase", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Purchase_Family_FamilyId",
                        column: x => x.FamilyId,
                        principalTable: "Family",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Purchase_FoodMaterial_FoodMaterialId",
                        column: x => x.FoodMaterialId,
                        principalTable: "FoodMaterial",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_FoodMaterialInventory_FamilyId",
                table: "FoodMaterialInventory",
                column: "FamilyId");

            migrationBuilder.CreateIndex(
                name: "IX_FoodMaterialInventory_FoodMaterialId",
                table: "FoodMaterialInventory",
                column: "FoodMaterialId");

            migrationBuilder.CreateIndex(
                name: "IX_Plan_DishId",
                table: "Plan",
                column: "DishId");

            migrationBuilder.CreateIndex(
                name: "IX_Plan_FamilyId",
                table: "Plan",
                column: "FamilyId");

            migrationBuilder.CreateIndex(
                name: "IX_Purchase_FamilyId",
                table: "Purchase",
                column: "FamilyId");

            migrationBuilder.CreateIndex(
                name: "IX_Purchase_FoodMaterialId",
                table: "Purchase",
                column: "FoodMaterialId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "FoodMaterialInventory");

            migrationBuilder.DropTable(
                name: "Plan");

            migrationBuilder.DropTable(
                name: "Purchase");

            migrationBuilder.DropColumn(
                name: "IndexNo",
                table: "FoodMaterialCategory");

            migrationBuilder.DropColumn(
                name: "IsMain",
                table: "FoodMaterial");

            migrationBuilder.DropColumn(
                name: "Price",
                table: "FoodMaterial");

            migrationBuilder.DropColumn(
                name: "Unit",
                table: "FoodMaterial");
        }
    }
}
