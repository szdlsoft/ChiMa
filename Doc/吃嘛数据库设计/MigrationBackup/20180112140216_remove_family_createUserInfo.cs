using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace SixMan.ChiMa.Migrations
{
    public partial class remove_family_createUserInfo : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            //migrationBuilder.DropForeignKey(
            //    name: "FK_Family_UserInfo_CreateUserInfoId",
            //    table: "Family");

            //migrationBuilder.DropIndex(
            //    name: "IX_Family_CreateUserInfoId",
            //    table: "Family");

            migrationBuilder.DropColumn(
                name: "CreateUserInfoId",
                table: "Family");

            migrationBuilder.AddColumn<bool>(
                name: "IsFamilyCreater",
                table: "UserInfo",
                nullable: false,
                defaultValue: false);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IsFamilyCreater",
                table: "UserInfo");

            migrationBuilder.AddColumn<long>(
                name: "CreateUserInfoId",
                table: "Family",
                nullable: true);

            //migrationBuilder.CreateIndex(
            //    name: "IX_Family_CreateUserInfoId",
            //    table: "Family",
            //    column: "CreateUserInfoId");

            //migrationBuilder.AddForeignKey(
            //    name: "FK_Family_UserInfo_CreateUserInfoId",
            //    table: "Family",
            //    column: "CreateUserInfoId",
            //    principalTable: "UserInfo",
            //    principalColumn: "Id",
            //    onDelete: ReferentialAction.Restrict);
        }
    }
}
