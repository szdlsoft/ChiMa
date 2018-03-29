using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace SixMan.ChiMa.Migrations
{
    public partial class rename_family_userinfo : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            //migrationBuilder.DropForeignKey(
            //    name: "FK_Family_UserInfo_CreaterId",
            //    table: "Family");

            //migrationBuilder.RenameColumn(
            //    name: "CreaterId",
            //    table: "Family",
            //    newName: "CreateUserInfoId");

            //migrationBuilder.RenameIndex(
            //    name: "IX_Family_CreaterId",
            //    table: "Family",
            //    newName: "IX_Family_CreateUserInfoId");

            migrationBuilder.AddForeignKey(
                name: "FK_Family_UserInfo_CreateUserInfoId",
                table: "Family",
                column: "CreateUserInfoId",
                principalTable: "UserInfo",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Family_UserInfo_CreateUserInfoId",
                table: "Family");

            //migrationBuilder.RenameColumn(
            //    name: "CreateUserInfoId",
            //    table: "Family",
            //    newName: "CreaterId");

            //migrationBuilder.RenameIndex(
            //    name: "IX_Family_CreateUserInfoId",
            //    table: "Family",
            //    newName: "IX_Family_CreaterId");

            //migrationBuilder.AddForeignKey(
            //    name: "FK_Family_UserInfo_CreaterId",
            //    table: "Family",
            //    column: "CreaterId",
            //    principalTable: "UserInfo",
            //    principalColumn: "Id",
            //    onDelete: ReferentialAction.Restrict);
        }
    }
}
