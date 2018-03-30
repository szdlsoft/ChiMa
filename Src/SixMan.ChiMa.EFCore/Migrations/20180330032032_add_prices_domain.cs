using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace SixMan.ChiMa.EFCore.Migrations
{
    public partial class add_prices_domain : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "Content",
                table: "Cookery",
                maxLength: 4096,
                nullable: true,
                oldClrType: typeof(string),
                oldMaxLength: 512,
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "SHORT_NAME",
                table: "Area",
                maxLength: 50,
                nullable: true,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "Area",
                maxLength: 150,
                nullable: false,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.CreateTable(
                name: "AreaFMPrice",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    AreaId = table.Column<int>(nullable: true),
                    PublishTime = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AreaFMPrice", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AreaFMPrice_Area_AreaId",
                        column: x => x.AreaId,
                        principalTable: "Area",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "FMAlias",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    FoodMaterialId = table.Column<long>(nullable: true),
                    Name = table.Column<string>(maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FMAlias", x => x.Id);
                    table.ForeignKey(
                        name: "FK_FMAlias_FoodMaterial_FoodMaterialId",
                        column: x => x.FoodMaterialId,
                        principalTable: "FoodMaterial",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "FMPriceItem",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    AreaFMPriceId = table.Column<long>(nullable: true),
                    FoodMaterialId = table.Column<long>(nullable: true),
                    Price = table.Column<double>(nullable: false),
                    Unit = table.Column<string>(maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FMPriceItem", x => x.Id);
                    table.ForeignKey(
                        name: "FK_FMPriceItem_AreaFMPrice_AreaFMPriceId",
                        column: x => x.AreaFMPriceId,
                        principalTable: "AreaFMPrice",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_FMPriceItem_FoodMaterial_FoodMaterialId",
                        column: x => x.FoodMaterialId,
                        principalTable: "FoodMaterial",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_AreaFMPrice_AreaId",
                table: "AreaFMPrice",
                column: "AreaId");

            migrationBuilder.CreateIndex(
                name: "IX_FMAlias_FoodMaterialId",
                table: "FMAlias",
                column: "FoodMaterialId");

            migrationBuilder.CreateIndex(
                name: "IX_FMPriceItem_AreaFMPriceId",
                table: "FMPriceItem",
                column: "AreaFMPriceId");

            migrationBuilder.CreateIndex(
                name: "IX_FMPriceItem_FoodMaterialId",
                table: "FMPriceItem",
                column: "FoodMaterialId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "FMAlias");

            migrationBuilder.DropTable(
                name: "FMPriceItem");

            migrationBuilder.DropTable(
                name: "AreaFMPrice");

            migrationBuilder.AlterColumn<string>(
                name: "Content",
                table: "Cookery",
                maxLength: 512,
                nullable: true,
                oldClrType: typeof(string),
                oldMaxLength: 4096,
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "SHORT_NAME",
                table: "Area",
                nullable: true,
                oldClrType: typeof(string),
                oldMaxLength: 50,
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "Area",
                nullable: true,
                oldClrType: typeof(string),
                oldMaxLength: 150);
        }
    }
}
