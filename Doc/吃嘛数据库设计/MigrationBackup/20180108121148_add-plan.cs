using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace SixMan.ChiMa.Migrations
{
    public partial class addplan : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            //migrationBuilder.DropTable(
            //    name: "AbpNotifications");

            //migrationBuilder.AlterColumn<long>(
            //    name: "Id",
            //    table: "UserInfo",
            //    nullable: false,
            //    oldClrType: typeof(long))
            //    .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn);

            //migrationBuilder.AlterColumn<long>(
            //    name: "Id",
            //    table: "UserFavoriteDish",
            //    nullable: false,
            //    oldClrType: typeof(long))
            //    .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn);

            //migrationBuilder.AlterColumn<long>(
            //    name: "Id",
            //    table: "UserCommentDish",
            //    nullable: false,
            //    oldClrType: typeof(long))
            //    .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn);

            //migrationBuilder.AlterColumn<long>(
            //    name: "Id",
            //    table: "UserBrowseDish",
            //    nullable: false,
            //    oldClrType: typeof(long))
            //    .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn);

            //migrationBuilder.AlterColumn<long>(
            //    name: "Id",
            //    table: "UserAttention",
            //    nullable: false,
            //    oldClrType: typeof(long))
            //    .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn);

            //migrationBuilder.AlterColumn<long>(
            //    name: "Id",
            //    table: "PersonHealthAffect",
            //    nullable: false,
            //    oldClrType: typeof(long))
            //    .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn);

            //migrationBuilder.AlterColumn<long>(
            //    name: "Id",
            //    table: "HealthConcernCategory",
            //    nullable: false,
            //    oldClrType: typeof(long))
            //    .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn);

            //migrationBuilder.AlterColumn<long>(
            //    name: "Id",
            //    table: "HealthConcern",
            //    nullable: false,
            //    oldClrType: typeof(long))
            //    .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn);

            //migrationBuilder.AlterColumn<long>(
            //    name: "Id",
            //    table: "FoodMaterialHealthAffect",
            //    nullable: false,
            //    oldClrType: typeof(long))
            //    .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn);

            //migrationBuilder.AlterColumn<long>(
            //    name: "Id",
            //    table: "FoodMaterialCategory",
            //    nullable: false,
            //    oldClrType: typeof(long))
            //    .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn);

            //migrationBuilder.AlterColumn<long>(
            //    name: "Id",
            //    table: "FoodMaterial",
            //    nullable: false,
            //    oldClrType: typeof(long))
            //    .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn);

            //migrationBuilder.AlterColumn<long>(
            //    name: "Id",
            //    table: "FamilyMember",
            //    nullable: false,
            //    oldClrType: typeof(long))
            //    .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn);

            //migrationBuilder.AlterColumn<long>(
            //    name: "Id",
            //    table: "Family",
            //    nullable: false,
            //    oldClrType: typeof(long))
            //    .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn);

            //migrationBuilder.AlterColumn<long>(
            //    name: "Id",
            //    table: "DishBom",
            //    nullable: false,
            //    oldClrType: typeof(long))
            //    .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn);

            //migrationBuilder.AlterColumn<long>(
            //    name: "Id",
            //    table: "Dish",
            //    nullable: false,
            //    oldClrType: typeof(long))
            //    .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn);

            migrationBuilder.AddColumn<string>(
                name: "BPhoto",
                table: "Dish",
                maxLength: 512,
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "Difficulty",
                table: "Dish",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "HPhoto",
                table: "Dish",
                maxLength: 512,
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "Star",
                table: "Dish",
                nullable: true);

            //migrationBuilder.AlterColumn<long>(
            //    name: "Id",
            //    table: "Cookery",
            //    nullable: false,
            //    oldClrType: typeof(long))
            //    .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn);

            //migrationBuilder.AlterColumn<long>(
            //    name: "Id",
            //    table: "City",
            //    nullable: false,
            //    oldClrType: typeof(long))
            //    .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn);

            //migrationBuilder.AlterColumn<long>(
            //    name: "Id",
            //    table: "Career",
            //    nullable: false,
            //    oldClrType: typeof(long))
            //    .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn);

            //migrationBuilder.AlterColumn<long>(
            //    name: "Id",
            //    table: "AbpUserTokens",
            //    nullable: false,
            //    oldClrType: typeof(long))
            //    .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn);

            //migrationBuilder.AlterColumn<long>(
            //    name: "Id",
            //    table: "AbpUsers",
            //    nullable: false,
            //    oldClrType: typeof(long))
            //    .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn);

            //migrationBuilder.AlterColumn<long>(
            //    name: "Id",
            //    table: "AbpUserRoles",
            //    nullable: false,
            //    oldClrType: typeof(long))
            //    .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn);

            //migrationBuilder.AlterColumn<long>(
            //    name: "Id",
            //    table: "AbpUserOrganizationUnits",
            //    nullable: false,
            //    oldClrType: typeof(long))
            //    .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn);

            //migrationBuilder.AlterColumn<long>(
            //    name: "Id",
            //    table: "AbpUserLogins",
            //    nullable: false,
            //    oldClrType: typeof(long))
            //    .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn);

            //migrationBuilder.AlterColumn<long>(
            //    name: "Id",
            //    table: "AbpUserLoginAttempts",
            //    nullable: false,
            //    oldClrType: typeof(long))
            //    .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn);

            //migrationBuilder.AlterColumn<long>(
            //    name: "Id",
            //    table: "AbpUserClaims",
            //    nullable: false,
            //    oldClrType: typeof(long))
            //    .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn);

            //migrationBuilder.AlterColumn<long>(
            //    name: "Id",
            //    table: "AbpUserAccounts",
            //    nullable: false,
            //    oldClrType: typeof(long))
            //    .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn);

            //migrationBuilder.AlterColumn<int>(
            //    name: "Id",
            //    table: "AbpTenants",
            //    nullable: false,
            //    oldClrType: typeof(int))
            //    .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn);

            //migrationBuilder.AlterColumn<long>(
            //    name: "Id",
            //    table: "AbpSettings",
            //    nullable: false,
            //    oldClrType: typeof(long))
            //    .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn);

            //migrationBuilder.AlterColumn<int>(
            //    name: "Id",
            //    table: "AbpRoles",
            //    nullable: false,
            //    oldClrType: typeof(int))
            //    .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn);

            //migrationBuilder.AlterColumn<long>(
            //    name: "Id",
            //    table: "AbpRoleClaims",
            //    nullable: false,
            //    oldClrType: typeof(long))
            //    .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn);

            //migrationBuilder.AlterColumn<long>(
            //    name: "Id",
            //    table: "AbpPermissions",
            //    nullable: false,
            //    oldClrType: typeof(long))
            //    .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn);

            //migrationBuilder.AlterColumn<long>(
            //    name: "Id",
            //    table: "AbpOrganizationUnits",
            //    nullable: false,
            //    oldClrType: typeof(long))
            //    .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn);

            //migrationBuilder.AlterColumn<long>(
            //    name: "Id",
            //    table: "AbpLanguageTexts",
            //    nullable: false,
            //    oldClrType: typeof(long))
            //    .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn);

            //migrationBuilder.AlterColumn<int>(
            //    name: "Id",
            //    table: "AbpLanguages",
            //    nullable: false,
            //    oldClrType: typeof(int))
            //    .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn);

            //migrationBuilder.AlterColumn<long>(
            //    name: "Id",
            //    table: "AbpFeatures",
            //    nullable: false,
            //    oldClrType: typeof(long))
            //    .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn);

            //migrationBuilder.AlterColumn<int>(
            //    name: "Id",
            //    table: "AbpEditions",
            //    nullable: false,
            //    oldClrType: typeof(int))
            //    .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn);

            //migrationBuilder.AlterColumn<long>(
            //    name: "Id",
            //    table: "AbpBackgroundJobs",
            //    nullable: false,
            //    oldClrType: typeof(long))
            //    .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn);

            //migrationBuilder.AlterColumn<long>(
            //    name: "Id",
            //    table: "AbpAuditLogs",
            //    nullable: false,
            //    oldClrType: typeof(long))
            //    .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "BPhoto",
                table: "Dish");

            migrationBuilder.DropColumn(
                name: "Difficulty",
                table: "Dish");

            migrationBuilder.DropColumn(
                name: "HPhoto",
                table: "Dish");

            migrationBuilder.DropColumn(
                name: "Star",
                table: "Dish");

            //migrationBuilder.AlterColumn<long>(
            //    name: "Id",
            //    table: "UserInfo",
            //    nullable: false,
            //    oldClrType: typeof(long))
            //    .OldAnnotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn);

            //migrationBuilder.AlterColumn<long>(
            //    name: "Id",
            //    table: "UserFavoriteDish",
            //    nullable: false,
            //    oldClrType: typeof(long))
            //    .OldAnnotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn);

            //migrationBuilder.AlterColumn<long>(
            //    name: "Id",
            //    table: "UserCommentDish",
            //    nullable: false,
            //    oldClrType: typeof(long))
            //    .OldAnnotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn);

            //migrationBuilder.AlterColumn<long>(
            //    name: "Id",
            //    table: "UserBrowseDish",
            //    nullable: false,
            //    oldClrType: typeof(long))
            //    .OldAnnotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn);

            //migrationBuilder.AlterColumn<long>(
            //    name: "Id",
            //    table: "UserAttention",
            //    nullable: false,
            //    oldClrType: typeof(long))
            //    .OldAnnotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn);

            //migrationBuilder.AlterColumn<long>(
            //    name: "Id",
            //    table: "PersonHealthAffect",
            //    nullable: false,
            //    oldClrType: typeof(long))
            //    .OldAnnotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn);

            //migrationBuilder.AlterColumn<long>(
            //    name: "Id",
            //    table: "HealthConcernCategory",
            //    nullable: false,
            //    oldClrType: typeof(long))
            //    .OldAnnotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn);

            //migrationBuilder.AlterColumn<long>(
            //    name: "Id",
            //    table: "HealthConcern",
            //    nullable: false,
            //    oldClrType: typeof(long))
            //    .OldAnnotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn);

            //migrationBuilder.AlterColumn<long>(
            //    name: "Id",
            //    table: "FoodMaterialHealthAffect",
            //    nullable: false,
            //    oldClrType: typeof(long))
            //    .OldAnnotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn);

            //migrationBuilder.AlterColumn<long>(
            //    name: "Id",
            //    table: "FoodMaterialCategory",
            //    nullable: false,
            //    oldClrType: typeof(long))
            //    .OldAnnotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn);

            //migrationBuilder.AlterColumn<long>(
            //    name: "Id",
            //    table: "FoodMaterial",
            //    nullable: false,
            //    oldClrType: typeof(long))
            //    .OldAnnotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn);

            //migrationBuilder.AlterColumn<long>(
            //    name: "Id",
            //    table: "FamilyMember",
            //    nullable: false,
            //    oldClrType: typeof(long))
            //    .OldAnnotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn);

            //migrationBuilder.AlterColumn<long>(
            //    name: "Id",
            //    table: "Family",
            //    nullable: false,
            //    oldClrType: typeof(long))
            //    .OldAnnotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn);

            //migrationBuilder.AlterColumn<long>(
            //    name: "Id",
            //    table: "DishBom",
            //    nullable: false,
            //    oldClrType: typeof(long))
            //    .OldAnnotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn);

            //migrationBuilder.AlterColumn<long>(
            //    name: "Id",
            //    table: "Dish",
            //    nullable: false,
            //    oldClrType: typeof(long))
            //    .OldAnnotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn);

            //migrationBuilder.AlterColumn<long>(
            //    name: "Id",
            //    table: "Cookery",
            //    nullable: false,
            //    oldClrType: typeof(long))
            //    .OldAnnotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn);

            //migrationBuilder.AlterColumn<long>(
            //    name: "Id",
            //    table: "City",
            //    nullable: false,
            //    oldClrType: typeof(long))
            //    .OldAnnotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn);

            //migrationBuilder.AlterColumn<long>(
            //    name: "Id",
            //    table: "Career",
            //    nullable: false,
            //    oldClrType: typeof(long))
            //    .OldAnnotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn);

            //migrationBuilder.AlterColumn<long>(
            //    name: "Id",
            //    table: "AbpUserTokens",
            //    nullable: false,
            //    oldClrType: typeof(long))
            //    .OldAnnotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn);

            //migrationBuilder.AlterColumn<long>(
            //    name: "Id",
            //    table: "AbpUsers",
            //    nullable: false,
            //    oldClrType: typeof(long))
            //    .OldAnnotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn);

            //migrationBuilder.AlterColumn<long>(
            //    name: "Id",
            //    table: "AbpUserRoles",
            //    nullable: false,
            //    oldClrType: typeof(long))
            //    .OldAnnotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn);

            //migrationBuilder.AlterColumn<long>(
            //    name: "Id",
            //    table: "AbpUserOrganizationUnits",
            //    nullable: false,
            //    oldClrType: typeof(long))
            //    .OldAnnotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn);

            //migrationBuilder.AlterColumn<long>(
            //    name: "Id",
            //    table: "AbpUserLogins",
            //    nullable: false,
            //    oldClrType: typeof(long))
            //    .OldAnnotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn);

            //migrationBuilder.AlterColumn<long>(
            //    name: "Id",
            //    table: "AbpUserLoginAttempts",
            //    nullable: false,
            //    oldClrType: typeof(long))
            //    .OldAnnotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn);

            //migrationBuilder.AlterColumn<long>(
            //    name: "Id",
            //    table: "AbpUserClaims",
            //    nullable: false,
            //    oldClrType: typeof(long))
            //    .OldAnnotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn);

            //migrationBuilder.AlterColumn<long>(
            //    name: "Id",
            //    table: "AbpUserAccounts",
            //    nullable: false,
            //    oldClrType: typeof(long))
            //    .OldAnnotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn);

            //migrationBuilder.AlterColumn<int>(
            //    name: "Id",
            //    table: "AbpTenants",
            //    nullable: false,
            //    oldClrType: typeof(int))
            //    .OldAnnotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn);

            //migrationBuilder.AlterColumn<long>(
            //    name: "Id",
            //    table: "AbpSettings",
            //    nullable: false,
            //    oldClrType: typeof(long))
            //    .OldAnnotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn);

            //migrationBuilder.AlterColumn<int>(
            //    name: "Id",
            //    table: "AbpRoles",
            //    nullable: false,
            //    oldClrType: typeof(int))
            //    .OldAnnotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn);

            //migrationBuilder.AlterColumn<long>(
            //    name: "Id",
            //    table: "AbpRoleClaims",
            //    nullable: false,
            //    oldClrType: typeof(long))
            //    .OldAnnotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn);

            //migrationBuilder.AlterColumn<long>(
            //    name: "Id",
            //    table: "AbpPermissions",
            //    nullable: false,
            //    oldClrType: typeof(long))
            //    .OldAnnotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn);

            //migrationBuilder.AlterColumn<long>(
            //    name: "Id",
            //    table: "AbpOrganizationUnits",
            //    nullable: false,
            //    oldClrType: typeof(long))
            //    .OldAnnotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn);

            //migrationBuilder.AlterColumn<long>(
            //    name: "Id",
            //    table: "AbpLanguageTexts",
            //    nullable: false,
            //    oldClrType: typeof(long))
            //    .OldAnnotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn);

            //migrationBuilder.AlterColumn<int>(
            //    name: "Id",
            //    table: "AbpLanguages",
            //    nullable: false,
            //    oldClrType: typeof(int))
            //    .OldAnnotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn);

            //migrationBuilder.AlterColumn<long>(
            //    name: "Id",
            //    table: "AbpFeatures",
            //    nullable: false,
            //    oldClrType: typeof(long))
            //    .OldAnnotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn);

            //migrationBuilder.AlterColumn<int>(
            //    name: "Id",
            //    table: "AbpEditions",
            //    nullable: false,
            //    oldClrType: typeof(int))
            //    .OldAnnotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn);

            //migrationBuilder.AlterColumn<long>(
            //    name: "Id",
            //    table: "AbpBackgroundJobs",
            //    nullable: false,
            //    oldClrType: typeof(long))
            //    .OldAnnotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn);

            //migrationBuilder.AlterColumn<long>(
            //    name: "Id",
            //    table: "AbpAuditLogs",
            //    nullable: false,
            //    oldClrType: typeof(long))
            //    .OldAnnotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn);

            //migrationBuilder.CreateTable(
            //    name: "AbpNotifications",
            //    columns: table => new
            //    {
            //        Id = table.Column<Guid>(nullable: false),
            //        CreationTime = table.Column<DateTime>(nullable: false),
            //        CreatorUserId = table.Column<long>(nullable: true),
            //        Data = table.Column<string>(maxLength: 1048576, nullable: true),
            //        DataTypeName = table.Column<string>(maxLength: 512, nullable: true),
            //        EntityId = table.Column<string>(maxLength: 96, nullable: true),
            //        EntityTypeAssemblyQualifiedName = table.Column<string>(maxLength: 512, nullable: true),
            //        EntityTypeName = table.Column<string>(maxLength: 250, nullable: true),
            //        ExcludedUserIds = table.Column<string>(maxLength: 131072, nullable: true),
            //        NotificationName = table.Column<string>(maxLength: 96, nullable: false),
            //        Severity = table.Column<byte>(nullable: false),
            //        TenantIds = table.Column<string>(maxLength: 131072, nullable: true),
            //        UserIds = table.Column<string>(maxLength: 131072, nullable: true)
            //    },
            //    constraints: table =>
            //    {
            //        table.PrimaryKey("PK_AbpNotifications", x => x.Id);
            //    });
        }
    }
}
