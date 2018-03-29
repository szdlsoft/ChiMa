using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace SixMan.ChiMa.Migrations
{
    public partial class add_CokeryNote : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            //migrationBuilder.DropForeignKey(
            //    name: "FK_UserFavoriteDish_UserInfo_UserInfoId",
            //    table: "UserFavoriteDish");

            migrationBuilder.AlterColumn<long>(
                name: "UserInfoId",
                table: "UserFavoriteDish",
                nullable: false,
                oldClrType: typeof(long),
                oldNullable: true);

            migrationBuilder.CreateTable(
                name: "CookeryNote",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Audio = table.Column<string>(maxLength: 512, nullable: true),
                    CookeryId = table.Column<long>(nullable: true),
                    CreationTime = table.Column<DateTime>(nullable: false),
                    CreatorUserId = table.Column<long>(nullable: true),
                    DeleterUserId = table.Column<long>(nullable: true),
                    DeletionTime = table.Column<DateTime>(nullable: true),
                    Description = table.Column<string>(maxLength: 256, nullable: false),
                    ExtensionData = table.Column<string>(nullable: true),
                    IsDeleted = table.Column<bool>(nullable: false),
                    LastModificationTime = table.Column<DateTime>(nullable: true),
                    LastModifierUserId = table.Column<long>(nullable: true),
                    Photo = table.Column<string>(maxLength: 512, nullable: true),
                    UerInfoId = table.Column<long>(nullable: true),
                    Video = table.Column<string>(maxLength: 512, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CookeryNote", x => x.Id);
                    table.ForeignKey(
                        name: "FK_CookeryNote_Cookery_CookeryId",
                        column: x => x.CookeryId,
                        principalTable: "Cookery",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_CookeryNote_UserInfo_UerInfoId",
                        column: x => x.UerInfoId,
                        principalTable: "UserInfo",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_CookeryNote_CookeryId",
                table: "CookeryNote",
                column: "CookeryId");

            migrationBuilder.CreateIndex(
                name: "IX_CookeryNote_UerInfoId",
                table: "CookeryNote",
                column: "UerInfoId");

            migrationBuilder.AddForeignKey(
                name: "FK_UserFavoriteDish_UserInfo_UserInfoId",
                table: "UserFavoriteDish",
                column: "UserInfoId",
                principalTable: "UserInfo",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_UserFavoriteDish_UserInfo_UserInfoId",
                table: "UserFavoriteDish");

            migrationBuilder.DropTable(
                name: "CookeryNote");

            migrationBuilder.AlterColumn<long>(
                name: "UserInfoId",
                table: "UserFavoriteDish",
                nullable: true,
                oldClrType: typeof(long));

            //migrationBuilder.AddForeignKey(
            //    name: "FK_UserFavoriteDish_UserInfo_UserInfoId",
            //    table: "UserFavoriteDish",
            //    column: "UserInfoId",
            //    principalTable: "UserInfo",
            //    principalColumn: "Id",
            //    onDelete: ReferentialAction.Restrict);
        }
    }
}
