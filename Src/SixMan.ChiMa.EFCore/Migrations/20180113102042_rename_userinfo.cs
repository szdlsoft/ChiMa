using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace SixMan.ChiMa.Migrations
{
    public partial class rename_userinfo : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            //migrationBuilder.DropForeignKey(
            //    name: "FK_UserBrowseDish_UserInfo_UserId",
            //    table: "UserBrowseDish");

            //migrationBuilder.DropForeignKey(
            //    name: "FK_UserCommentDish_UserInfo_UserId",
            //    table: "UserCommentDish");

            //migrationBuilder.DropForeignKey(
            //    name: "FK_UserFavoriteDish_UserInfo_UserId",
            //    table: "UserFavoriteDish");

            migrationBuilder.RenameColumn(
                name: "UserId",
                table: "UserFavoriteDish",
                newName: "UserInfoId");

            //migrationBuilder.RenameIndex(
            //    name: "IX_UserFavoriteDish_UserId",
            //    table: "UserFavoriteDish",
            //    newName: "IX_UserFavoriteDish_UserInfoId");

            migrationBuilder.RenameColumn(
                name: "UserId",
                table: "UserCommentDish",
                newName: "UserInfoId");

            //migrationBuilder.RenameIndex(
            //    name: "IX_UserCommentDish_UserId",
            //    table: "UserCommentDish",
            //    newName: "IX_UserCommentDish_UserInfoId");

            migrationBuilder.RenameColumn(
                name: "UserId",
                table: "UserBrowseDish",
                newName: "UserInfoId");

            //migrationBuilder.RenameIndex(
            //    name: "IX_UserBrowseDish_UserId",
            //    table: "UserBrowseDish",
            //    newName: "IX_UserBrowseDish_UserInfoId");

            //migrationBuilder.AddForeignKey(
            //    name: "FK_UserBrowseDish_UserInfo_UserInfoId",
            //    table: "UserBrowseDish",
            //    column: "UserInfoId",
            //    principalTable: "UserInfo",
            //    principalColumn: "Id",
            //    onDelete: ReferentialAction.Restrict);

            //    migrationBuilder.AddForeignKey(
            //        name: "FK_UserCommentDish_UserInfo_UserInfoId",
            //        table: "UserCommentDish",
            //        column: "UserInfoId",
            //        principalTable: "UserInfo",
            //        principalColumn: "Id",
            //        onDelete: ReferentialAction.Restrict);

            //    migrationBuilder.AddForeignKey(
            //        name: "FK_UserFavoriteDish_UserInfo_UserInfoId",
            //        table: "UserFavoriteDish",
            //        column: "UserInfoId",
            //        principalTable: "UserInfo",
            //        principalColumn: "Id",
            //        onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_UserBrowseDish_UserInfo_UserInfoId",
                table: "UserBrowseDish");

            migrationBuilder.DropForeignKey(
                name: "FK_UserCommentDish_UserInfo_UserInfoId",
                table: "UserCommentDish");

            migrationBuilder.DropForeignKey(
                name: "FK_UserFavoriteDish_UserInfo_UserInfoId",
                table: "UserFavoriteDish");

            migrationBuilder.RenameColumn(
                name: "UserInfoId",
                table: "UserFavoriteDish",
                newName: "UserId");

            //migrationBuilder.RenameIndex(
            //    name: "IX_UserFavoriteDish_UserInfoId",
            //    table: "UserFavoriteDish",
            //    newName: "IX_UserFavoriteDish_UserId");

            migrationBuilder.RenameColumn(
                name: "UserInfoId",
                table: "UserCommentDish",
                newName: "UserId");

            //migrationBuilder.RenameIndex(
            //    name: "IX_UserCommentDish_UserInfoId",
            //    table: "UserCommentDish",
            //    newName: "IX_UserCommentDish_UserId");

            migrationBuilder.RenameColumn(
                name: "UserInfoId",
                table: "UserBrowseDish",
                newName: "UserId");

            //migrationBuilder.RenameIndex(
            //    name: "IX_UserBrowseDish_UserInfoId",
            //    table: "UserBrowseDish",
            //    newName: "IX_UserBrowseDish_UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_UserBrowseDish_UserInfo_UserId",
                table: "UserBrowseDish",
                column: "UserId",
                principalTable: "UserInfo",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_UserCommentDish_UserInfo_UserId",
                table: "UserCommentDish",
                column: "UserId",
                principalTable: "UserInfo",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_UserFavoriteDish_UserInfo_UserId",
                table: "UserFavoriteDish",
                column: "UserId",
                principalTable: "UserInfo",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
