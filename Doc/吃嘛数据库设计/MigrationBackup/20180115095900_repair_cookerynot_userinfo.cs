using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace SixMan.ChiMa.Migrations
{
    public partial class repair_cookerynot_userinfo : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CookeryNote_Cookery_CookeryId",
                table: "CookeryNote");

            migrationBuilder.DropForeignKey(
                name: "FK_CookeryNote_UserInfo_UerInfoId",
                table: "CookeryNote");

            migrationBuilder.DropIndex(
                name: "IX_CookeryNote_UerInfoId",
                table: "CookeryNote");

            migrationBuilder.DropColumn(
                name: "UerInfoId",
                table: "CookeryNote");

            migrationBuilder.AlterColumn<long>(
                name: "CookeryId",
                table: "CookeryNote",
                nullable: false,
                oldClrType: typeof(long),
                oldNullable: true);

            migrationBuilder.AddColumn<long>(
                name: "UserInfoId",
                table: "CookeryNote",
                nullable: false,
                defaultValue: 0L);

            migrationBuilder.CreateIndex(
                name: "IX_CookeryNote_UserInfoId",
                table: "CookeryNote",
                column: "UserInfoId");

            migrationBuilder.AddForeignKey(
                name: "FK_CookeryNote_Cookery_CookeryId",
                table: "CookeryNote",
                column: "CookeryId",
                principalTable: "Cookery",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_CookeryNote_UserInfo_UserInfoId",
                table: "CookeryNote",
                column: "UserInfoId",
                principalTable: "UserInfo",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CookeryNote_Cookery_CookeryId",
                table: "CookeryNote");

            migrationBuilder.DropForeignKey(
                name: "FK_CookeryNote_UserInfo_UserInfoId",
                table: "CookeryNote");

            migrationBuilder.DropIndex(
                name: "IX_CookeryNote_UserInfoId",
                table: "CookeryNote");

            migrationBuilder.DropColumn(
                name: "UserInfoId",
                table: "CookeryNote");

            migrationBuilder.AlterColumn<long>(
                name: "CookeryId",
                table: "CookeryNote",
                nullable: true,
                oldClrType: typeof(long));

            migrationBuilder.AddColumn<long>(
                name: "UerInfoId",
                table: "CookeryNote",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_CookeryNote_UerInfoId",
                table: "CookeryNote",
                column: "UerInfoId");

            migrationBuilder.AddForeignKey(
                name: "FK_CookeryNote_Cookery_CookeryId",
                table: "CookeryNote",
                column: "CookeryId",
                principalTable: "Cookery",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_CookeryNote_UserInfo_UerInfoId",
                table: "CookeryNote",
                column: "UerInfoId",
                principalTable: "UserInfo",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
