using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;
using System.IO;

namespace SixMan.ChiMa.EFCore.Migrations
{
    public partial class city_update_to_area : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_UserInfo_City_CityId",
                table: "UserInfo");

            migrationBuilder.DropTable(
                name: "City");

            migrationBuilder.DropIndex(
                name: "IX_UserInfo_CityId",
                table: "UserInfo");

            migrationBuilder.DropColumn(
                name: "CityId",
                table: "UserInfo");

            migrationBuilder.AddColumn<int>(
                name: "AreaId",
                table: "UserInfo",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "Area",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    LATITUDE = table.Column<double>(nullable: false),
                    LEVEL = table.Column<byte>(nullable: false),
                    LONGITUDE = table.Column<double>(nullable: false),
                    Name = table.Column<string>(nullable: true),
                    Parent_Id = table.Column<int>(nullable: true),
                    SHORT_NAME = table.Column<string>(nullable: true),
                    SORT = table.Column<int>(nullable: false),
                    STATUS = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Area", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Area_Area_Parent_Id",
                        column: x => x.Parent_Id,
                        principalTable: "Area",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_UserInfo_AreaId",
                table: "UserInfo",
                column: "AreaId");

            migrationBuilder.CreateIndex(
                name: "IX_Area_Parent_Id",
                table: "Area",
                column: "Parent_Id");

            migrationBuilder.AddForeignKey(
                name: "FK_UserInfo_Area_AreaId",
                table: "UserInfo",
                column: "AreaId",
                principalTable: "Area",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
            //导入全国area 数据
            migrationBuilder.Sql(File.OpenText(@".\Seed\areas.sql").ReadToEnd());
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_UserInfo_Area_AreaId",
                table: "UserInfo");

            migrationBuilder.DropTable(
                name: "Area");

            migrationBuilder.DropIndex(
                name: "IX_UserInfo_AreaId",
                table: "UserInfo");

            migrationBuilder.DropColumn(
                name: "AreaId",
                table: "UserInfo");

            migrationBuilder.AddColumn<long>(
                name: "CityId",
                table: "UserInfo",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "City",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Code = table.Column<string>(maxLength: 50, nullable: true),
                    CreationTime = table.Column<DateTime>(nullable: false),
                    CreatorUserId = table.Column<long>(nullable: true),
                    DeleterUserId = table.Column<long>(nullable: true),
                    DeletionTime = table.Column<DateTime>(nullable: true),
                    ExtensionData = table.Column<string>(nullable: true),
                    IsDeleted = table.Column<bool>(nullable: false),
                    LastModificationTime = table.Column<DateTime>(nullable: true),
                    LastModifierUserId = table.Column<long>(nullable: true),
                    Name = table.Column<string>(maxLength: 50, nullable: false),
                    ParentId = table.Column<long>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_City", x => x.Id);
                    table.ForeignKey(
                        name: "FK_City_City_ParentId",
                        column: x => x.ParentId,
                        principalTable: "City",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_UserInfo_CityId",
                table: "UserInfo",
                column: "CityId");

            migrationBuilder.CreateIndex(
                name: "IX_City_ParentId",
                table: "City",
                column: "ParentId");

            migrationBuilder.AddForeignKey(
                name: "FK_UserInfo_City_CityId",
                table: "UserInfo",
                column: "CityId",
                principalTable: "City",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
