using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace SixMan.ChiMa.Migrations
{
    public partial class add_familymenber_userinfo : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<long>(
                name: "UserInfoId",
                table: "FamilyMember",
                nullable: true);

            migrationBuilder.AddColumn<long>(
                name: "CreaterId",
                table: "Family",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_FamilyMember_UserInfoId",
                table: "FamilyMember",
                column: "UserInfoId");

            migrationBuilder.CreateIndex(
                name: "IX_Family_CreaterId",
                table: "Family",
                column: "CreaterId");

            migrationBuilder.AddForeignKey(
                name: "FK_Family_UserInfo_CreaterId",
                table: "Family",
                column: "CreaterId",
                principalTable: "UserInfo",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_FamilyMember_UserInfo_UserInfoId",
                table: "FamilyMember",
                column: "UserInfoId",
                principalTable: "UserInfo",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Family_UserInfo_CreaterId",
                table: "Family");

            migrationBuilder.DropForeignKey(
                name: "FK_FamilyMember_UserInfo_UserInfoId",
                table: "FamilyMember");

            migrationBuilder.DropIndex(
                name: "IX_FamilyMember_UserInfoId",
                table: "FamilyMember");

            migrationBuilder.DropIndex(
                name: "IX_Family_CreaterId",
                table: "Family");

            migrationBuilder.DropColumn(
                name: "UserInfoId",
                table: "FamilyMember");

            migrationBuilder.DropColumn(
                name: "CreaterId",
                table: "Family");
        }
    }
}
