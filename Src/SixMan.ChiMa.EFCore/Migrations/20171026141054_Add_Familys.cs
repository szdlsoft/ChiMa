using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace SixMan.ChiMa.Migrations
{
    public partial class Add_Familys : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            //migrationBuilder.DropForeignKey(
            //    name: "FK_FoodMaterial_FoodMaterialCategory_FoodMaterialCategoryId",
            //    table: "FoodMaterial");

            //migrationBuilder.DropForeignKey(
            //    name: "FK_FoodMaterialHealthAffect_FoodMaterial_FoodMaterialId",
            //    table: "FoodMaterialHealthAffect");

            //migrationBuilder.DropForeignKey(
            //    name: "FK_FoodMaterialHealthAffect_HealthConcern_HealthConcernId",
            //    table: "FoodMaterialHealthAffect");

            //migrationBuilder.DropForeignKey(
            //    name: "FK_HealthConcern_HealthConcernCategory_HealthConcernCategoryId",
            //    table: "HealthConcern");

            migrationBuilder.AlterColumn<long>(
                name: "HealthConcernCategoryId",
                table: "HealthConcern",
                type: "bigint",
                nullable: true,
                oldClrType: typeof(long));

            migrationBuilder.AlterColumn<long>(
                name: "HealthConcernId",
                table: "FoodMaterialHealthAffect",
                type: "bigint",
                nullable: true,
                oldClrType: typeof(long));

            migrationBuilder.AlterColumn<long>(
                name: "FoodMaterialId",
                table: "FoodMaterialHealthAffect",
                type: "bigint",
                nullable: true,
                oldClrType: typeof(long));

            migrationBuilder.AlterColumn<long>(
                name: "FoodMaterialCategoryId",
                table: "FoodMaterial",
                type: "bigint",
                nullable: true,
                oldClrType: typeof(long));

            migrationBuilder.CreateTable(
                name: "Family",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    CreationTime = table.Column<DateTime>( nullable: false),
                    CreatorUserId = table.Column<long>(type: "bigint", nullable: true),
                    DeleterUserId = table.Column<long>(type: "bigint", nullable: true),
                    DeletionTime = table.Column<DateTime>( nullable: true),
                    ExtensionData = table.Column<string>( nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    LastModificationTime = table.Column<DateTime>( nullable: true),
                    LastModifierUserId = table.Column<long>(type: "bigint", nullable: true),
                    UUID = table.Column<Guid>( nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Family", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "FamilyMember",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    CreationTime = table.Column<DateTime>( nullable: false),
                    CreatorUserId = table.Column<long>(type: "bigint", nullable: true),
                    DeleterUserId = table.Column<long>(type: "bigint", nullable: true),
                    DeletionTime = table.Column<DateTime>( nullable: true),
                    ExtensionData = table.Column<string>( nullable: true),
                    FamilyId = table.Column<long>(type: "bigint", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    LastModificationTime = table.Column<DateTime>( nullable: true),
                    LastModifierUserId = table.Column<long>(type: "bigint", nullable: true),
                    PersonKind = table.Column<int>(type: "int", nullable: false),
                    Sex = table.Column<bool>(type: "bit", nullable: true),
                    Age_From = table.Column<int>(type: "int", nullable: true),
                    Age_To = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FamilyMember", x => x.Id);
                    table.ForeignKey(
                        name: "FK_FamilyMember_Family_FamilyId",
                        column: x => x.FamilyId,
                        principalTable: "Family",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "PersonHealthAffect",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    AffectDegree = table.Column<int>(type: "int", nullable: false),
                    CreationTime = table.Column<DateTime>( nullable: false),
                    CreatorUserId = table.Column<long>(type: "bigint", nullable: true),
                    DeleterUserId = table.Column<long>(type: "bigint", nullable: true),
                    DeletionTime = table.Column<DateTime>( nullable: true),
                    ExtensionData = table.Column<string>( nullable: true),
                    FamilyMemberId = table.Column<long>(type: "bigint", nullable: true),
                    HealthConcernId = table.Column<long>(type: "bigint", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    LastModificationTime = table.Column<DateTime>( nullable: true),
                    LastModifierUserId = table.Column<long>(type: "bigint", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PersonHealthAffect", x => x.Id);
                    table.ForeignKey(
                        name: "FK_PersonHealthAffect_FamilyMember_FamilyMemberId",
                        column: x => x.FamilyMemberId,
                        principalTable: "FamilyMember",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_PersonHealthAffect_HealthConcern_HealthConcernId",
                        column: x => x.HealthConcernId,
                        principalTable: "HealthConcern",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_FamilyMember_FamilyId",
                table: "FamilyMember",
                column: "FamilyId");

            migrationBuilder.CreateIndex(
                name: "IX_PersonHealthAffect_FamilyMemberId",
                table: "PersonHealthAffect",
                column: "FamilyMemberId");

            migrationBuilder.CreateIndex(
                name: "IX_PersonHealthAffect_HealthConcernId",
                table: "PersonHealthAffect",
                column: "HealthConcernId");

            migrationBuilder.AddForeignKey(
                name: "FK_FoodMaterial_FoodMaterialCategory_FoodMaterialCategoryId",
                table: "FoodMaterial",
                column: "FoodMaterialCategoryId",
                principalTable: "FoodMaterialCategory",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_FoodMaterialHealthAffect_FoodMaterial_FoodMaterialId",
                table: "FoodMaterialHealthAffect",
                column: "FoodMaterialId",
                principalTable: "FoodMaterial",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_FoodMaterialHealthAffect_HealthConcern_HealthConcernId",
                table: "FoodMaterialHealthAffect",
                column: "HealthConcernId",
                principalTable: "HealthConcern",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_HealthConcern_HealthConcernCategory_HealthConcernCategoryId",
                table: "HealthConcern",
                column: "HealthConcernCategoryId",
                principalTable: "HealthConcernCategory",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_FoodMaterial_FoodMaterialCategory_FoodMaterialCategoryId",
                table: "FoodMaterial");

            migrationBuilder.DropForeignKey(
                name: "FK_FoodMaterialHealthAffect_FoodMaterial_FoodMaterialId",
                table: "FoodMaterialHealthAffect");

            migrationBuilder.DropForeignKey(
                name: "FK_FoodMaterialHealthAffect_HealthConcern_HealthConcernId",
                table: "FoodMaterialHealthAffect");

            migrationBuilder.DropForeignKey(
                name: "FK_HealthConcern_HealthConcernCategory_HealthConcernCategoryId",
                table: "HealthConcern");

            migrationBuilder.DropTable(
                name: "PersonHealthAffect");

            migrationBuilder.DropTable(
                name: "FamilyMember");

            migrationBuilder.DropTable(
                name: "Family");

            migrationBuilder.AlterColumn<long>(
                name: "HealthConcernCategoryId",
                table: "HealthConcern",
                nullable: false,
                oldClrType: typeof(long),
                oldType: "bigint",
                oldNullable: true);

            migrationBuilder.AlterColumn<long>(
                name: "HealthConcernId",
                table: "FoodMaterialHealthAffect",
                nullable: false,
                oldClrType: typeof(long),
                oldType: "bigint",
                oldNullable: true);

            migrationBuilder.AlterColumn<long>(
                name: "FoodMaterialId",
                table: "FoodMaterialHealthAffect",
                nullable: false,
                oldClrType: typeof(long),
                oldType: "bigint",
                oldNullable: true);

            migrationBuilder.AlterColumn<long>(
                name: "FoodMaterialCategoryId",
                table: "FoodMaterial",
                nullable: false,
                oldClrType: typeof(long),
                oldType: "bigint",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_FoodMaterial_FoodMaterialCategory_FoodMaterialCategoryId",
                table: "FoodMaterial",
                column: "FoodMaterialCategoryId",
                principalTable: "FoodMaterialCategory",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_FoodMaterialHealthAffect_FoodMaterial_FoodMaterialId",
                table: "FoodMaterialHealthAffect",
                column: "FoodMaterialId",
                principalTable: "FoodMaterial",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_FoodMaterialHealthAffect_HealthConcern_HealthConcernId",
                table: "FoodMaterialHealthAffect",
                column: "HealthConcernId",
                principalTable: "HealthConcern",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_HealthConcern_HealthConcernCategory_HealthConcernCategoryId",
                table: "HealthConcern",
                column: "HealthConcernCategoryId",
                principalTable: "HealthConcernCategory",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
