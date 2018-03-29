CREATE TABLE `__EFMigrationsHistory` (
    `MigrationId` varchar(95) NOT NULL,
    `ProductVersion` varchar(32) NOT NULL,
    CONSTRAINT `PK___EFMigrationsHistory` PRIMARY KEY (`MigrationId`)
);

CREATE TABLE `AbpAuditLogs` (
    `Id` bigint NOT NULL AUTO_INCREMENT,
    `BrowserInfo` varchar(256),
    `ClientIpAddress` varchar(64),
    `ClientName` varchar(128),
    `CustomData` varchar(2000),
    `Exception` varchar(2000),
    `ExecutionDuration` int NOT NULL,
    `ExecutionTime` datetime(6) NOT NULL,
    `ImpersonatorTenantId` int,
    `ImpersonatorUserId` bigint,
    `MethodName` varchar(256),
    `Parameters` varchar(1024),
    `ServiceName` varchar(256),
    `TenantId` int,
    `UserId` bigint,
    CONSTRAINT `PK_AbpAuditLogs` PRIMARY KEY (`Id`)
);

CREATE TABLE `AbpBackgroundJobs` (
    `Id` bigint NOT NULL AUTO_INCREMENT,
    `CreationTime` datetime(6) NOT NULL,
    `CreatorUserId` bigint,
    `IsAbandoned` bit NOT NULL,
    `JobArgs` longtext NOT NULL,
    `JobType` varchar(512) NOT NULL,
    `LastTryTime` datetime(6),
    `NextTryTime` datetime(6) NOT NULL,
    `Priority` tinyint unsigned NOT NULL,
    `TryCount` smallint NOT NULL,
    CONSTRAINT `PK_AbpBackgroundJobs` PRIMARY KEY (`Id`)
);

CREATE TABLE `AbpEditions` (
    `Id` int NOT NULL AUTO_INCREMENT,
    `CreationTime` datetime(6) NOT NULL,
    `CreatorUserId` bigint,
    `DeleterUserId` bigint,
    `DeletionTime` datetime(6),
    `DisplayName` varchar(64) NOT NULL,
    `IsDeleted` bit NOT NULL,
    `LastModificationTime` datetime(6),
    `LastModifierUserId` bigint,
    `Name` varchar(32) NOT NULL,
    CONSTRAINT `PK_AbpEditions` PRIMARY KEY (`Id`)
);

CREATE TABLE `AbpLanguages` (
    `Id` int NOT NULL AUTO_INCREMENT,
    `CreationTime` datetime(6) NOT NULL,
    `CreatorUserId` bigint,
    `DeleterUserId` bigint,
    `DeletionTime` datetime(6),
    `DisplayName` varchar(64) NOT NULL,
    `Icon` varchar(128),
    `IsDeleted` bit NOT NULL,
    `IsDisabled` bit NOT NULL,
    `LastModificationTime` datetime(6),
    `LastModifierUserId` bigint,
    `Name` varchar(10) NOT NULL,
    `TenantId` int,
    CONSTRAINT `PK_AbpLanguages` PRIMARY KEY (`Id`)
);

CREATE TABLE `AbpLanguageTexts` (
    `Id` bigint NOT NULL AUTO_INCREMENT,
    `CreationTime` datetime(6) NOT NULL,
    `CreatorUserId` bigint,
    `Key` varchar(256) NOT NULL,
    `LanguageName` varchar(10) NOT NULL,
    `LastModificationTime` datetime(6),
    `LastModifierUserId` bigint,
    `Source` varchar(128) NOT NULL,
    `TenantId` int,
    `Value` longtext NOT NULL,
    CONSTRAINT `PK_AbpLanguageTexts` PRIMARY KEY (`Id`)
);

CREATE TABLE `AbpNotificationSubscriptions` (
    `Id` binary(16) NOT NULL,
    `CreationTime` datetime(6) NOT NULL,
    `CreatorUserId` bigint,
    `EntityId` varchar(96),
    `EntityTypeAssemblyQualifiedName` varchar(512),
    `EntityTypeName` varchar(250),
    `NotificationName` varchar(96),
    `TenantId` int,
    `UserId` bigint NOT NULL,
    CONSTRAINT `PK_AbpNotificationSubscriptions` PRIMARY KEY (`Id`)
);

CREATE TABLE `AbpOrganizationUnits` (
    `Id` bigint NOT NULL AUTO_INCREMENT,
    `Code` varchar(95) NOT NULL,
    `CreationTime` datetime(6) NOT NULL,
    `CreatorUserId` bigint,
    `DeleterUserId` bigint,
    `DeletionTime` datetime(6),
    `DisplayName` varchar(128) NOT NULL,
    `IsDeleted` bit NOT NULL,
    `LastModificationTime` datetime(6),
    `LastModifierUserId` bigint,
    `ParentId` bigint,
    `TenantId` int,
    CONSTRAINT `PK_AbpOrganizationUnits` PRIMARY KEY (`Id`),
    CONSTRAINT `FK_AbpOrganizationUnits_AbpOrganizationUnits_ParentId` FOREIGN KEY (`ParentId`) REFERENCES `AbpOrganizationUnits` (`Id`) ON DELETE NO ACTION
);

CREATE TABLE `AbpTenantNotifications` (
    `Id` binary(16) NOT NULL,
    `CreationTime` datetime(6) NOT NULL,
    `CreatorUserId` bigint,
    `Data` longtext,
    `DataTypeName` varchar(512),
    `EntityId` varchar(96),
    `EntityTypeAssemblyQualifiedName` varchar(512),
    `EntityTypeName` varchar(250),
    `NotificationName` varchar(96) NOT NULL,
    `Severity` tinyint unsigned NOT NULL,
    `TenantId` int,
    CONSTRAINT `PK_AbpTenantNotifications` PRIMARY KEY (`Id`)
);

CREATE TABLE `AbpUserAccounts` (
    `Id` bigint NOT NULL AUTO_INCREMENT,
    `CreationTime` datetime(6) NOT NULL,
    `CreatorUserId` bigint,
    `DeleterUserId` bigint,
    `DeletionTime` datetime(6),
    `EmailAddress` varchar(127),
    `IsDeleted` bit NOT NULL,
    `LastLoginTime` datetime(6),
    `LastModificationTime` datetime(6),
    `LastModifierUserId` bigint,
    `TenantId` int,
    `UserId` bigint NOT NULL,
    `UserLinkId` bigint,
    `UserName` varchar(127),
    CONSTRAINT `PK_AbpUserAccounts` PRIMARY KEY (`Id`)
);

CREATE TABLE `AbpUserLoginAttempts` (
    `Id` bigint NOT NULL AUTO_INCREMENT,
    `BrowserInfo` varchar(256),
    `ClientIpAddress` varchar(64),
    `ClientName` varchar(128),
    `CreationTime` datetime(6) NOT NULL,
    `Result` tinyint unsigned NOT NULL,
    `TenancyName` varchar(64),
    `TenantId` int,
    `UserId` bigint,
    `UserNameOrEmailAddress` varchar(255),
    CONSTRAINT `PK_AbpUserLoginAttempts` PRIMARY KEY (`Id`)
);

CREATE TABLE `AbpUserNotifications` (
    `Id` binary(16) NOT NULL,
    `CreationTime` datetime(6) NOT NULL,
    `State` int NOT NULL,
    `TenantId` int,
    `TenantNotificationId` binary(16) NOT NULL,
    `UserId` bigint NOT NULL,
    CONSTRAINT `PK_AbpUserNotifications` PRIMARY KEY (`Id`)
);

CREATE TABLE `AbpUserOrganizationUnits` (
    `Id` bigint NOT NULL AUTO_INCREMENT,
    `CreationTime` datetime(6) NOT NULL,
    `CreatorUserId` bigint,
    `IsDeleted` bit NOT NULL,
    `OrganizationUnitId` bigint NOT NULL,
    `TenantId` int,
    `UserId` bigint NOT NULL,
    CONSTRAINT `PK_AbpUserOrganizationUnits` PRIMARY KEY (`Id`)
);

CREATE TABLE `AbpUsers` (
    `Id` bigint NOT NULL AUTO_INCREMENT,
    `AccessFailedCount` int NOT NULL,
    `AuthenticationSource` varchar(64),
    `ConcurrencyStamp` longtext,
    `CreationTime` datetime(6) NOT NULL,
    `CreatorUserId` bigint,
    `DeleterUserId` bigint,
    `DeletionTime` datetime(6),
    `EmailAddress` varchar(256) NOT NULL,
    `EmailConfirmationCode` varchar(328),
    `IsActive` bit NOT NULL,
    `IsDeleted` bit NOT NULL,
    `IsEmailConfirmed` bit NOT NULL,
    `IsLockoutEnabled` bit NOT NULL,
    `IsPhoneNumberConfirmed` bit NOT NULL,
    `IsTwoFactorEnabled` bit NOT NULL,
    `LastLoginTime` datetime(6),
    `LastModificationTime` datetime(6),
    `LastModifierUserId` bigint,
    `LockoutEndDateUtc` datetime(6),
    `Name` varchar(32) NOT NULL,
    `NormalizedEmailAddress` varchar(256) NOT NULL,
    `NormalizedUserName` varchar(32) NOT NULL,
    `Password` varchar(128) NOT NULL,
    `PasswordResetCode` varchar(328),
    `PhoneNumber` longtext,
    `SecurityStamp` longtext,
    `Surname` varchar(32) NOT NULL,
    `TenantId` int,
    `UserName` varchar(32) NOT NULL,
    CONSTRAINT `PK_AbpUsers` PRIMARY KEY (`Id`),
    CONSTRAINT `FK_AbpUsers_AbpUsers_CreatorUserId` FOREIGN KEY (`CreatorUserId`) REFERENCES `AbpUsers` (`Id`) ON DELETE NO ACTION,
    CONSTRAINT `FK_AbpUsers_AbpUsers_DeleterUserId` FOREIGN KEY (`DeleterUserId`) REFERENCES `AbpUsers` (`Id`) ON DELETE NO ACTION,
    CONSTRAINT `FK_AbpUsers_AbpUsers_LastModifierUserId` FOREIGN KEY (`LastModifierUserId`) REFERENCES `AbpUsers` (`Id`) ON DELETE NO ACTION
);

CREATE TABLE `Career` (
    `Id` bigint NOT NULL AUTO_INCREMENT,
    `Code` varchar(50),
    `CreationTime` datetime(6) NOT NULL,
    `CreatorUserId` bigint,
    `DeleterUserId` bigint,
    `DeletionTime` datetime(6),
    `ExtensionData` longtext,
    `IsDeleted` bit NOT NULL,
    `LastModificationTime` datetime(6),
    `LastModifierUserId` bigint,
    `Name` varchar(50) NOT NULL,
    CONSTRAINT `PK_Career` PRIMARY KEY (`Id`)
);

CREATE TABLE `City` (
    `Id` bigint NOT NULL AUTO_INCREMENT,
    `Code` varchar(50),
    `CreationTime` datetime(6) NOT NULL,
    `CreatorUserId` bigint,
    `DeleterUserId` bigint,
    `DeletionTime` datetime(6),
    `ExtensionData` longtext,
    `IsDeleted` bit NOT NULL,
    `LastModificationTime` datetime(6),
    `LastModifierUserId` bigint,
    `Name` varchar(50) NOT NULL,
    `ParentId` bigint,
    CONSTRAINT `PK_City` PRIMARY KEY (`Id`),
    CONSTRAINT `FK_City_City_ParentId` FOREIGN KEY (`ParentId`) REFERENCES `City` (`Id`) ON DELETE NO ACTION
);

CREATE TABLE `Family` (
    `Id` bigint NOT NULL AUTO_INCREMENT,
    `CreationTime` datetime(6) NOT NULL,
    `CreatorUserId` bigint,
    `DeleterUserId` bigint,
    `DeletionTime` datetime(6),
    `ExtensionData` longtext,
    `IsDeleted` bit NOT NULL,
    `LastModificationTime` datetime(6),
    `LastModifierUserId` bigint,
    `UUID` binary(16) NOT NULL,
    CONSTRAINT `PK_Family` PRIMARY KEY (`Id`)
);

CREATE TABLE `FoodMaterialCategory` (
    `Id` bigint NOT NULL AUTO_INCREMENT,
    `Code` varchar(50),
    `CreationTime` datetime(6) NOT NULL,
    `CreatorUserId` bigint,
    `DeleterUserId` bigint,
    `DeletionTime` datetime(6),
    `ExtensionData` longtext,
    `IndexNo` int,
    `IsDeleted` bit NOT NULL,
    `LastModificationTime` datetime(6),
    `LastModifierUserId` bigint,
    `Name` varchar(50) NOT NULL,
    `ParentId` bigint,
    CONSTRAINT `PK_FoodMaterialCategory` PRIMARY KEY (`Id`),
    CONSTRAINT `FK_FoodMaterialCategory_FoodMaterialCategory_ParentId` FOREIGN KEY (`ParentId`) REFERENCES `FoodMaterialCategory` (`Id`) ON DELETE NO ACTION
);

CREATE TABLE `HealthConcernCategory` (
    `Id` bigint NOT NULL AUTO_INCREMENT,
    `Code` varchar(50),
    `CreationTime` datetime(6) NOT NULL,
    `CreatorUserId` bigint,
    `DeleterUserId` bigint,
    `DeletionTime` datetime(6),
    `ExtensionData` longtext,
    `IsDeleted` bit NOT NULL,
    `LastModificationTime` datetime(6),
    `LastModifierUserId` bigint,
    `Name` varchar(50) NOT NULL,
    CONSTRAINT `PK_HealthConcernCategory` PRIMARY KEY (`Id`)
);

CREATE TABLE `AbpFeatures` (
    `EditionId` int,
    `Id` bigint NOT NULL AUTO_INCREMENT,
    `CreationTime` datetime(6) NOT NULL,
    `CreatorUserId` bigint,
    `Discriminator` longtext NOT NULL,
    `Name` varchar(128) NOT NULL,
    `TenantId` int,
    `Value` varchar(2000) NOT NULL,
    CONSTRAINT `PK_AbpFeatures` PRIMARY KEY (`Id`),
    CONSTRAINT `FK_AbpFeatures_AbpEditions_EditionId` FOREIGN KEY (`EditionId`) REFERENCES `AbpEditions` (`Id`) ON DELETE CASCADE
);

CREATE TABLE `AbpRoles` (
    `Id` int NOT NULL AUTO_INCREMENT,
    `ConcurrencyStamp` longtext,
    `CreationTime` datetime(6) NOT NULL,
    `CreatorUserId` bigint,
    `DeleterUserId` bigint,
    `DeletionTime` datetime(6),
    `Description` varchar(5000),
    `DisplayName` varchar(64) NOT NULL,
    `IsDefault` bit NOT NULL,
    `IsDeleted` bit NOT NULL,
    `IsStatic` bit NOT NULL,
    `LastModificationTime` datetime(6),
    `LastModifierUserId` bigint,
    `Name` varchar(32) NOT NULL,
    `NormalizedName` varchar(32) NOT NULL,
    `TenantId` int,
    CONSTRAINT `PK_AbpRoles` PRIMARY KEY (`Id`),
    CONSTRAINT `FK_AbpRoles_AbpUsers_CreatorUserId` FOREIGN KEY (`CreatorUserId`) REFERENCES `AbpUsers` (`Id`) ON DELETE NO ACTION,
    CONSTRAINT `FK_AbpRoles_AbpUsers_DeleterUserId` FOREIGN KEY (`DeleterUserId`) REFERENCES `AbpUsers` (`Id`) ON DELETE NO ACTION,
    CONSTRAINT `FK_AbpRoles_AbpUsers_LastModifierUserId` FOREIGN KEY (`LastModifierUserId`) REFERENCES `AbpUsers` (`Id`) ON DELETE NO ACTION
);

CREATE TABLE `AbpSettings` (
    `Id` bigint NOT NULL AUTO_INCREMENT,
    `CreationTime` datetime(6) NOT NULL,
    `CreatorUserId` bigint,
    `LastModificationTime` datetime(6),
    `LastModifierUserId` bigint,
    `Name` varchar(256) NOT NULL,
    `TenantId` int,
    `UserId` bigint,
    `Value` varchar(2000),
    CONSTRAINT `PK_AbpSettings` PRIMARY KEY (`Id`),
    CONSTRAINT `FK_AbpSettings_AbpUsers_UserId` FOREIGN KEY (`UserId`) REFERENCES `AbpUsers` (`Id`) ON DELETE NO ACTION
);

CREATE TABLE `AbpTenants` (
    `Id` int NOT NULL AUTO_INCREMENT,
    `ConnectionString` varchar(1024),
    `CreationTime` datetime(6) NOT NULL,
    `CreatorUserId` bigint,
    `DeleterUserId` bigint,
    `DeletionTime` datetime(6),
    `EditionId` int,
    `IsActive` bit NOT NULL,
    `IsDeleted` bit NOT NULL,
    `LastModificationTime` datetime(6),
    `LastModifierUserId` bigint,
    `Name` varchar(128) NOT NULL,
    `TenancyName` varchar(64) NOT NULL,
    CONSTRAINT `PK_AbpTenants` PRIMARY KEY (`Id`),
    CONSTRAINT `FK_AbpTenants_AbpUsers_CreatorUserId` FOREIGN KEY (`CreatorUserId`) REFERENCES `AbpUsers` (`Id`) ON DELETE NO ACTION,
    CONSTRAINT `FK_AbpTenants_AbpUsers_DeleterUserId` FOREIGN KEY (`DeleterUserId`) REFERENCES `AbpUsers` (`Id`) ON DELETE NO ACTION,
    CONSTRAINT `FK_AbpTenants_AbpEditions_EditionId` FOREIGN KEY (`EditionId`) REFERENCES `AbpEditions` (`Id`) ON DELETE NO ACTION,
    CONSTRAINT `FK_AbpTenants_AbpUsers_LastModifierUserId` FOREIGN KEY (`LastModifierUserId`) REFERENCES `AbpUsers` (`Id`) ON DELETE NO ACTION
);

CREATE TABLE `AbpUserClaims` (
    `Id` bigint NOT NULL AUTO_INCREMENT,
    `ClaimType` varchar(127),
    `ClaimValue` longtext,
    `CreationTime` datetime(6) NOT NULL,
    `CreatorUserId` bigint,
    `TenantId` int,
    `UserId` bigint NOT NULL,
    CONSTRAINT `PK_AbpUserClaims` PRIMARY KEY (`Id`),
    CONSTRAINT `FK_AbpUserClaims_AbpUsers_UserId` FOREIGN KEY (`UserId`) REFERENCES `AbpUsers` (`Id`) ON DELETE CASCADE
);

CREATE TABLE `AbpUserLogins` (
    `Id` bigint NOT NULL AUTO_INCREMENT,
    `LoginProvider` varchar(128) NOT NULL,
    `ProviderKey` varchar(256) NOT NULL,
    `TenantId` int,
    `UserId` bigint NOT NULL,
    CONSTRAINT `PK_AbpUserLogins` PRIMARY KEY (`Id`),
    CONSTRAINT `FK_AbpUserLogins_AbpUsers_UserId` FOREIGN KEY (`UserId`) REFERENCES `AbpUsers` (`Id`) ON DELETE CASCADE
);

CREATE TABLE `AbpUserRoles` (
    `Id` bigint NOT NULL AUTO_INCREMENT,
    `CreationTime` datetime(6) NOT NULL,
    `CreatorUserId` bigint,
    `RoleId` int NOT NULL,
    `TenantId` int,
    `UserId` bigint NOT NULL,
    CONSTRAINT `PK_AbpUserRoles` PRIMARY KEY (`Id`),
    CONSTRAINT `FK_AbpUserRoles_AbpUsers_UserId` FOREIGN KEY (`UserId`) REFERENCES `AbpUsers` (`Id`) ON DELETE CASCADE
);

CREATE TABLE `AbpUserTokens` (
    `Id` bigint NOT NULL AUTO_INCREMENT,
    `LoginProvider` longtext,
    `Name` longtext,
    `TenantId` int,
    `UserId` bigint NOT NULL,
    `Value` longtext,
    CONSTRAINT `PK_AbpUserTokens` PRIMARY KEY (`Id`),
    CONSTRAINT `FK_AbpUserTokens_AbpUsers_UserId` FOREIGN KEY (`UserId`) REFERENCES `AbpUsers` (`Id`) ON DELETE CASCADE
);

CREATE TABLE `UserInfo` (
    `Id` bigint NOT NULL AUTO_INCREMENT,
    `BirthDay` datetime(6),
    `CareerId` bigint,
    `CityId` bigint,
    `CreationTime` datetime(6) NOT NULL,
    `CreatorUserId` bigint,
    `Credits` int NOT NULL,
    `DeleterUserId` bigint,
    `DeletionTime` datetime(6),
    `ExtensionData` longtext,
    `FamilyId` bigint NOT NULL,
    `HeadPortrait` varchar(512),
    `IsDeleted` bit NOT NULL,
    `IsFamilyCreater` bit NOT NULL,
    `LastModificationTime` datetime(6),
    `LastModifierUserId` bigint,
    `Mobile` varchar(50),
    `NickName` varchar(50),
    `Sex` bit,
    `Signature` varchar(256),
    `UserId` bigint NOT NULL,
    CONSTRAINT `PK_UserInfo` PRIMARY KEY (`Id`),
    CONSTRAINT `FK_UserInfo_Career_CareerId` FOREIGN KEY (`CareerId`) REFERENCES `Career` (`Id`) ON DELETE NO ACTION,
    CONSTRAINT `FK_UserInfo_City_CityId` FOREIGN KEY (`CityId`) REFERENCES `City` (`Id`) ON DELETE NO ACTION,
    CONSTRAINT `FK_UserInfo_Family_FamilyId` FOREIGN KEY (`FamilyId`) REFERENCES `Family` (`Id`) ON DELETE CASCADE,
    CONSTRAINT `FK_UserInfo_AbpUsers_UserId` FOREIGN KEY (`UserId`) REFERENCES `AbpUsers` (`Id`) ON DELETE CASCADE
);

CREATE TABLE `FoodMaterial` (
    `Id` bigint NOT NULL AUTO_INCREMENT,
    `ASH` double,
    `Audio` varchar(512),
    `CA` double,
    `CHO` double,
    `CU` double,
    `Carotene` double,
    `Cholesterol` double,
    `CreationTime` datetime(6) NOT NULL,
    `CreatorUserId` bigint,
    `DeleterUserId` bigint,
    `DeletionTime` datetime(6),
    `Description` varchar(256) NOT NULL,
    `EdiblePercent` int,
    `EnergyKcal` double,
    `EnergyKj` double,
    `ExtensionData` longtext,
    `FE` double,
    `Fat` double,
    `Fibrin` double,
    `FoodMaterialCategoryId` bigint,
    `ImportId` bigint,
    `IsDeleted` bit NOT NULL,
    `IsMain` bit NOT NULL,
    `K` double,
    `LastModificationTime` datetime(6),
    `LastModifierUserId` bigint,
    `MG` double,
    `MN` double,
    `NA` double,
    `Niacin` double,
    `P` double,
    `Photo` varchar(512),
    `Price` double,
    `Protein` double,
    `Retinol` double,
    `Riboflavin` double,
    `SE` double,
    `Season` varchar(50),
    `StorageMode` varchar(256),
    `Thiamin` double,
    `Unit` varchar(256),
    `Video` varchar(512),
    `VitaminA` double,
    `VitaminC` double,
    `VitaminE` double,
    `Water` double,
    `ZN` double,
    CONSTRAINT `PK_FoodMaterial` PRIMARY KEY (`Id`),
    CONSTRAINT `FK_FoodMaterial_FoodMaterialCategory_FoodMaterialCategoryId` FOREIGN KEY (`FoodMaterialCategoryId`) REFERENCES `FoodMaterialCategory` (`Id`) ON DELETE NO ACTION
);

CREATE TABLE `HealthConcern` (
    `Id` bigint NOT NULL AUTO_INCREMENT,
    `CreationTime` datetime(6) NOT NULL,
    `CreatorUserId` bigint,
    `DeleterUserId` bigint,
    `DeletionTime` datetime(6),
    `Description` varchar(256) NOT NULL,
    `ExtensionData` longtext,
    `HealthConcernCategoryId` bigint,
    `IsDeleted` bit NOT NULL,
    `LastModificationTime` datetime(6),
    `LastModifierUserId` bigint,
    CONSTRAINT `PK_HealthConcern` PRIMARY KEY (`Id`),
    CONSTRAINT `FK_HealthConcern_HealthConcernCategory_HealthConcernCategoryId` FOREIGN KEY (`HealthConcernCategoryId`) REFERENCES `HealthConcernCategory` (`Id`) ON DELETE NO ACTION
);

CREATE TABLE `AbpPermissions` (
    `Id` bigint NOT NULL AUTO_INCREMENT,
    `CreationTime` datetime(6) NOT NULL,
    `CreatorUserId` bigint,
    `Discriminator` longtext NOT NULL,
    `IsGranted` bit NOT NULL,
    `Name` varchar(128) NOT NULL,
    `TenantId` int,
    `RoleId` int,
    `UserId` bigint,
    CONSTRAINT `PK_AbpPermissions` PRIMARY KEY (`Id`),
    CONSTRAINT `FK_AbpPermissions_AbpRoles_RoleId` FOREIGN KEY (`RoleId`) REFERENCES `AbpRoles` (`Id`) ON DELETE CASCADE,
    CONSTRAINT `FK_AbpPermissions_AbpUsers_UserId` FOREIGN KEY (`UserId`) REFERENCES `AbpUsers` (`Id`) ON DELETE CASCADE
);

CREATE TABLE `AbpRoleClaims` (
    `Id` bigint NOT NULL AUTO_INCREMENT,
    `ClaimType` varchar(127),
    `ClaimValue` longtext,
    `CreationTime` datetime(6) NOT NULL,
    `CreatorUserId` bigint,
    `RoleId` int NOT NULL,
    `TenantId` int,
    CONSTRAINT `PK_AbpRoleClaims` PRIMARY KEY (`Id`),
    CONSTRAINT `FK_AbpRoleClaims_AbpRoles_RoleId` FOREIGN KEY (`RoleId`) REFERENCES `AbpRoles` (`Id`) ON DELETE CASCADE
);

CREATE TABLE `Dish` (
    `Id` bigint NOT NULL AUTO_INCREMENT,
    `Audio` varchar(512),
    `BPhoto` varchar(512),
    `CookMethod` longtext,
    `CookTime` int,
    `CreationTime` datetime(6) NOT NULL,
    `CreatorUserId` bigint,
    `DeleterUserId` bigint,
    `DeletionTime` datetime(6),
    `Description` varchar(256) NOT NULL,
    `Difficulty` int,
    `DishCategory` longtext,
    `EnglishName` longtext,
    `ExtensionData` longtext,
    `HPhoto` varchar(512),
    `HomeMadeUserId` bigint,
    `ImportId` bigint,
    `IsDeleted` bit NOT NULL,
    `LastModificationTime` datetime(6),
    `LastModifierUserId` bigint,
    `Photo` varchar(512),
    `PreProcessTime` int,
    `Public` bit NOT NULL,
    `Star` int,
    `Taste` longtext,
    `Video` varchar(512),
    CONSTRAINT `PK_Dish` PRIMARY KEY (`Id`),
    CONSTRAINT `FK_Dish_UserInfo_HomeMadeUserId` FOREIGN KEY (`HomeMadeUserId`) REFERENCES `UserInfo` (`Id`) ON DELETE NO ACTION
);

CREATE TABLE `FamilyMember` (
    `Id` bigint NOT NULL AUTO_INCREMENT,
    `AvoidFoods` varchar(256),
    `CareerId` bigint,
    `Chronic` varchar(256),
    `CreationTime` datetime(6) NOT NULL,
    `CreatorUserId` bigint,
    `DeleterUserId` bigint,
    `DeletionTime` datetime(6),
    `ExtensionData` longtext,
    `FamilyId` bigint,
    `Height` int NOT NULL,
    `IsDeleted` bit NOT NULL,
    `LastModificationTime` datetime(6),
    `LastModifierUserId` bigint,
    `NickName` varchar(50),
    `PersonKind` int NOT NULL,
    `Sex` bit,
    `UserInfoId` bigint,
    `Weight` int NOT NULL,
    `Age_From` int,
    `Age_To` int,
    `Income_From` int,
    `Income_To` int,
    CONSTRAINT `PK_FamilyMember` PRIMARY KEY (`Id`),
    CONSTRAINT `FK_FamilyMember_Career_CareerId` FOREIGN KEY (`CareerId`) REFERENCES `Career` (`Id`) ON DELETE NO ACTION,
    CONSTRAINT `FK_FamilyMember_Family_FamilyId` FOREIGN KEY (`FamilyId`) REFERENCES `Family` (`Id`) ON DELETE NO ACTION,
    CONSTRAINT `FK_FamilyMember_UserInfo_UserInfoId` FOREIGN KEY (`UserInfoId`) REFERENCES `UserInfo` (`Id`) ON DELETE NO ACTION
);

CREATE TABLE `UserAttention` (
    `Id` bigint NOT NULL AUTO_INCREMENT,
    `AttentionId` bigint,
    `CreationTime` datetime(6) NOT NULL,
    `CreatorUserId` bigint,
    `DeleterUserId` bigint,
    `DeletionTime` datetime(6),
    `ExtensionData` longtext,
    `FanId` bigint,
    `IsDeleted` bit NOT NULL,
    `LastModificationTime` datetime(6),
    `LastModifierUserId` bigint,
    CONSTRAINT `PK_UserAttention` PRIMARY KEY (`Id`),
    CONSTRAINT `FK_UserAttention_UserInfo_AttentionId` FOREIGN KEY (`AttentionId`) REFERENCES `UserInfo` (`Id`) ON DELETE NO ACTION,
    CONSTRAINT `FK_UserAttention_UserInfo_FanId` FOREIGN KEY (`FanId`) REFERENCES `UserInfo` (`Id`) ON DELETE NO ACTION
);

CREATE TABLE `FoodMaterialInventory` (
    `Id` bigint NOT NULL AUTO_INCREMENT,
    `CreationTime` datetime(6) NOT NULL,
    `CreatorUserId` bigint,
    `DeleterUserId` bigint,
    `DeletionTime` datetime(6),
    `ExtensionData` longtext,
    `FamilyId` bigint NOT NULL,
    `FoodMaterialId` bigint,
    `Inventory` int,
    `IsDeleted` bit NOT NULL,
    `LastModificationTime` datetime(6),
    `LastModifierUserId` bigint,
    CONSTRAINT `PK_FoodMaterialInventory` PRIMARY KEY (`Id`),
    CONSTRAINT `FK_FoodMaterialInventory_Family_FamilyId` FOREIGN KEY (`FamilyId`) REFERENCES `Family` (`Id`) ON DELETE CASCADE,
    CONSTRAINT `FK_FoodMaterialInventory_FoodMaterial_FoodMaterialId` FOREIGN KEY (`FoodMaterialId`) REFERENCES `FoodMaterial` (`Id`) ON DELETE NO ACTION
);

CREATE TABLE `Purchase` (
    `Id` bigint NOT NULL AUTO_INCREMENT,
    `CreationTime` datetime(6) NOT NULL,
    `CreatorUserId` bigint,
    `DeleterUserId` bigint,
    `DeletionTime` datetime(6),
    `ExtensionData` longtext,
    `FamilyId` bigint NOT NULL,
    `FoodMaterialId` bigint,
    `HasPurchased` bit NOT NULL,
    `IsDeleted` bit NOT NULL,
    `LastModificationTime` datetime(6),
    `LastModifierUserId` bigint,
    `MakeTime` datetime(6),
    `PurchaseTime` datetime(6),
    `Volume` int,
    CONSTRAINT `PK_Purchase` PRIMARY KEY (`Id`),
    CONSTRAINT `FK_Purchase_Family_FamilyId` FOREIGN KEY (`FamilyId`) REFERENCES `Family` (`Id`) ON DELETE CASCADE,
    CONSTRAINT `FK_Purchase_FoodMaterial_FoodMaterialId` FOREIGN KEY (`FoodMaterialId`) REFERENCES `FoodMaterial` (`Id`) ON DELETE NO ACTION
);

CREATE TABLE `FoodMaterialHealthAffect` (
    `Id` bigint NOT NULL AUTO_INCREMENT,
    `AffectDegree` int NOT NULL,
    `CreationTime` datetime(6) NOT NULL,
    `CreatorUserId` bigint,
    `DeleterUserId` bigint,
    `DeletionTime` datetime(6),
    `ExtensionData` longtext,
    `FoodMaterialId` bigint,
    `HealthConcernId` bigint,
    `IsDeleted` bit NOT NULL,
    `LastModificationTime` datetime(6),
    `LastModifierUserId` bigint,
    CONSTRAINT `PK_FoodMaterialHealthAffect` PRIMARY KEY (`Id`),
    CONSTRAINT `FK_FoodMaterialHealthAffect_FoodMaterial_FoodMaterialId` FOREIGN KEY (`FoodMaterialId`) REFERENCES `FoodMaterial` (`Id`) ON DELETE NO ACTION,
    CONSTRAINT `FK_FoodMaterialHealthAffect_HealthConcern_HealthConcernId` FOREIGN KEY (`HealthConcernId`) REFERENCES `HealthConcern` (`Id`) ON DELETE NO ACTION
);

CREATE TABLE `Cookery` (
    `Id` bigint NOT NULL AUTO_INCREMENT,
    `Audio` varchar(512),
    `Content` varchar(512),
    `CreationTime` datetime(6) NOT NULL,
    `CreatorUserId` bigint,
    `DeleterUserId` bigint,
    `DeletionTime` datetime(6),
    `Description` varchar(256) NOT NULL,
    `DishId` bigint,
    `ExtensionData` longtext,
    `IsDeleted` bit NOT NULL,
    `LastModificationTime` datetime(6),
    `LastModifierUserId` bigint,
    `Order` int NOT NULL,
    `Photo` varchar(512),
    `Time` int,
    `Video` varchar(512),
    CONSTRAINT `PK_Cookery` PRIMARY KEY (`Id`),
    CONSTRAINT `FK_Cookery_Dish_DishId` FOREIGN KEY (`DishId`) REFERENCES `Dish` (`Id`) ON DELETE NO ACTION
);

CREATE TABLE `DishBom` (
    `Id` bigint NOT NULL AUTO_INCREMENT,
    `CreationTime` datetime(6) NOT NULL,
    `CreatorUserId` bigint,
    `DeleterUserId` bigint,
    `DeletionTime` datetime(6),
    `DishId` bigint NOT NULL,
    `ExtensionData` longtext,
    `FoodMaterialId` bigint NOT NULL,
    `IsDeleted` bit NOT NULL,
    `LastModificationTime` datetime(6),
    `LastModifierUserId` bigint,
    `Matching` double NOT NULL,
    `MatchingDescription` longtext,
    `Order` int NOT NULL,
    `PreProcess` longtext,
    CONSTRAINT `PK_DishBom` PRIMARY KEY (`Id`),
    CONSTRAINT `FK_DishBom_Dish_DishId` FOREIGN KEY (`DishId`) REFERENCES `Dish` (`Id`) ON DELETE CASCADE,
    CONSTRAINT `FK_DishBom_FoodMaterial_FoodMaterialId` FOREIGN KEY (`FoodMaterialId`) REFERENCES `FoodMaterial` (`Id`) ON DELETE CASCADE
);

CREATE TABLE `Plan` (
    `Id` bigint NOT NULL AUTO_INCREMENT,
    `CreationTime` datetime(6) NOT NULL,
    `CreatorUserId` bigint,
    `DeleterUserId` bigint,
    `DeletionTime` datetime(6),
    `DishId` bigint NOT NULL,
    `ExtensionData` longtext,
    `FamilyId` bigint NOT NULL,
    `IsDeleted` bit NOT NULL,
    `LastModificationTime` datetime(6),
    `LastModifierUserId` bigint,
    `MealNo` int NOT NULL,
    `MealType` int NOT NULL,
    `PlanDate` datetime(6) NOT NULL,
    CONSTRAINT `PK_Plan` PRIMARY KEY (`Id`),
    CONSTRAINT `FK_Plan_Dish_DishId` FOREIGN KEY (`DishId`) REFERENCES `Dish` (`Id`) ON DELETE CASCADE,
    CONSTRAINT `FK_Plan_Family_FamilyId` FOREIGN KEY (`FamilyId`) REFERENCES `Family` (`Id`) ON DELETE CASCADE
);

CREATE TABLE `UserBrowseDish` (
    `Id` bigint NOT NULL AUTO_INCREMENT,
    `BrowseTime` datetime(6) NOT NULL,
    `CreationTime` datetime(6) NOT NULL,
    `CreatorUserId` bigint,
    `DeleterUserId` bigint,
    `DeletionTime` datetime(6),
    `DishId` bigint,
    `ExtensionData` longtext,
    `IsDeleted` bit NOT NULL,
    `LastModificationTime` datetime(6),
    `LastModifierUserId` bigint,
    `UserInfoId` bigint,
    CONSTRAINT `PK_UserBrowseDish` PRIMARY KEY (`Id`),
    CONSTRAINT `FK_UserBrowseDish_Dish_DishId` FOREIGN KEY (`DishId`) REFERENCES `Dish` (`Id`) ON DELETE NO ACTION,
    CONSTRAINT `FK_UserBrowseDish_UserInfo_UserInfoId` FOREIGN KEY (`UserInfoId`) REFERENCES `UserInfo` (`Id`) ON DELETE NO ACTION
);

CREATE TABLE `UserCommentDish` (
    `Id` bigint NOT NULL AUTO_INCREMENT,
    `Content` varchar(256),
    `CreationTime` datetime(6) NOT NULL,
    `CreatorUserId` bigint,
    `DeleterUserId` bigint,
    `DeletionTime` datetime(6),
    `DishId` bigint,
    `ExtensionData` longtext,
    `IsDeleted` bit NOT NULL,
    `LastModificationTime` datetime(6),
    `LastModifierUserId` bigint,
    `Rate` int,
    `UserInfoId` bigint,
    CONSTRAINT `PK_UserCommentDish` PRIMARY KEY (`Id`),
    CONSTRAINT `FK_UserCommentDish_Dish_DishId` FOREIGN KEY (`DishId`) REFERENCES `Dish` (`Id`) ON DELETE NO ACTION,
    CONSTRAINT `FK_UserCommentDish_UserInfo_UserInfoId` FOREIGN KEY (`UserInfoId`) REFERENCES `UserInfo` (`Id`) ON DELETE NO ACTION
);

CREATE TABLE `UserFavoriteDish` (
    `Id` bigint NOT NULL AUTO_INCREMENT,
    `CreationTime` datetime(6) NOT NULL,
    `CreatorUserId` bigint,
    `DeleterUserId` bigint,
    `DeletionTime` datetime(6),
    `DishId` bigint,
    `ExtensionData` longtext,
    `IsDeleted` bit NOT NULL,
    `LastModificationTime` datetime(6),
    `LastModifierUserId` bigint,
    `UserInfoId` bigint NOT NULL,
    CONSTRAINT `PK_UserFavoriteDish` PRIMARY KEY (`Id`),
    CONSTRAINT `FK_UserFavoriteDish_Dish_DishId` FOREIGN KEY (`DishId`) REFERENCES `Dish` (`Id`) ON DELETE NO ACTION,
    CONSTRAINT `FK_UserFavoriteDish_UserInfo_UserInfoId` FOREIGN KEY (`UserInfoId`) REFERENCES `UserInfo` (`Id`) ON DELETE CASCADE
);

CREATE TABLE `PersonHealthAffect` (
    `Id` bigint NOT NULL AUTO_INCREMENT,
    `AffectDegree` int NOT NULL,
    `CreationTime` datetime(6) NOT NULL,
    `CreatorUserId` bigint,
    `DeleterUserId` bigint,
    `DeletionTime` datetime(6),
    `ExtensionData` longtext,
    `FamilyMemberId` bigint,
    `HealthConcernId` bigint,
    `IsDeleted` bit NOT NULL,
    `LastModificationTime` datetime(6),
    `LastModifierUserId` bigint,
    CONSTRAINT `PK_PersonHealthAffect` PRIMARY KEY (`Id`),
    CONSTRAINT `FK_PersonHealthAffect_FamilyMember_FamilyMemberId` FOREIGN KEY (`FamilyMemberId`) REFERENCES `FamilyMember` (`Id`) ON DELETE NO ACTION,
    CONSTRAINT `FK_PersonHealthAffect_HealthConcern_HealthConcernId` FOREIGN KEY (`HealthConcernId`) REFERENCES `HealthConcern` (`Id`) ON DELETE NO ACTION
);

CREATE TABLE `CookeryNote` (
    `Id` bigint NOT NULL AUTO_INCREMENT,
    `Audio` varchar(512),
    `CookeryId` bigint NOT NULL,
    `CreationTime` datetime(6) NOT NULL,
    `CreatorUserId` bigint,
    `DeleterUserId` bigint,
    `DeletionTime` datetime(6),
    `Description` varchar(256) NOT NULL,
    `ExtensionData` longtext,
    `IsDeleted` bit NOT NULL,
    `LastModificationTime` datetime(6),
    `LastModifierUserId` bigint,
    `Photo` varchar(512),
    `UserInfoId` bigint NOT NULL,
    `Video` varchar(512),
    CONSTRAINT `PK_CookeryNote` PRIMARY KEY (`Id`),
    CONSTRAINT `FK_CookeryNote_Cookery_CookeryId` FOREIGN KEY (`CookeryId`) REFERENCES `Cookery` (`Id`) ON DELETE CASCADE,
    CONSTRAINT `FK_CookeryNote_UserInfo_UserInfoId` FOREIGN KEY (`UserInfoId`) REFERENCES `UserInfo` (`Id`) ON DELETE CASCADE
);

CREATE INDEX `IX_AbpAuditLogs_TenantId_ExecutionDuration` ON `AbpAuditLogs` (`TenantId`, `ExecutionDuration`);

CREATE INDEX `IX_AbpAuditLogs_TenantId_ExecutionTime` ON `AbpAuditLogs` (`TenantId`, `ExecutionTime`);

CREATE INDEX `IX_AbpAuditLogs_TenantId_UserId` ON `AbpAuditLogs` (`TenantId`, `UserId`);

CREATE INDEX `IX_AbpBackgroundJobs_IsAbandoned_NextTryTime` ON `AbpBackgroundJobs` (`IsAbandoned`, `NextTryTime`);

CREATE INDEX `IX_AbpFeatures_EditionId_Name` ON `AbpFeatures` (`EditionId`, `Name`);

CREATE INDEX `IX_AbpFeatures_TenantId_Name` ON `AbpFeatures` (`TenantId`, `Name`);

CREATE INDEX `IX_AbpLanguages_TenantId_Name` ON `AbpLanguages` (`TenantId`, `Name`);

CREATE INDEX `IX_AbpLanguageTexts_TenantId_Source_LanguageName_Key` ON `AbpLanguageTexts` (`TenantId`, `Source`, `LanguageName`, `Key`);

CREATE INDEX `IX_AbpNotificationSubscriptions_NotificationName_EntityTypeName_` ON `AbpNotificationSubscriptions` (`NotificationName`, `EntityTypeName`, `EntityId`, `UserId`);

CREATE INDEX `IX_AbpNotificationSubscriptions_TenantId_NotificationName_Entity` ON `AbpNotificationSubscriptions` (`TenantId`, `NotificationName`, `EntityTypeName`, `EntityId`, `UserId`);

CREATE INDEX `IX_AbpOrganizationUnits_ParentId` ON `AbpOrganizationUnits` (`ParentId`);

CREATE INDEX `IX_AbpOrganizationUnits_TenantId_Code` ON `AbpOrganizationUnits` (`TenantId`, `Code`);

CREATE INDEX `IX_AbpPermissions_TenantId_Name` ON `AbpPermissions` (`TenantId`, `Name`);

CREATE INDEX `IX_AbpPermissions_RoleId` ON `AbpPermissions` (`RoleId`);

CREATE INDEX `IX_AbpPermissions_UserId` ON `AbpPermissions` (`UserId`);

CREATE INDEX `IX_AbpRoleClaims_RoleId` ON `AbpRoleClaims` (`RoleId`);

CREATE INDEX `IX_AbpRoleClaims_TenantId_ClaimType` ON `AbpRoleClaims` (`TenantId`, `ClaimType`);

CREATE INDEX `IX_AbpRoles_CreatorUserId` ON `AbpRoles` (`CreatorUserId`);

CREATE INDEX `IX_AbpRoles_DeleterUserId` ON `AbpRoles` (`DeleterUserId`);

CREATE INDEX `IX_AbpRoles_LastModifierUserId` ON `AbpRoles` (`LastModifierUserId`);

CREATE INDEX `IX_AbpRoles_TenantId_NormalizedName` ON `AbpRoles` (`TenantId`, `NormalizedName`);

CREATE INDEX `IX_AbpSettings_UserId` ON `AbpSettings` (`UserId`);

CREATE INDEX `IX_AbpSettings_TenantId_Name` ON `AbpSettings` (`TenantId`, `Name`);

CREATE INDEX `IX_AbpTenantNotifications_TenantId` ON `AbpTenantNotifications` (`TenantId`);

CREATE INDEX `IX_AbpTenants_CreatorUserId` ON `AbpTenants` (`CreatorUserId`);

CREATE INDEX `IX_AbpTenants_DeleterUserId` ON `AbpTenants` (`DeleterUserId`);

CREATE INDEX `IX_AbpTenants_EditionId` ON `AbpTenants` (`EditionId`);

CREATE INDEX `IX_AbpTenants_LastModifierUserId` ON `AbpTenants` (`LastModifierUserId`);

CREATE INDEX `IX_AbpTenants_TenancyName` ON `AbpTenants` (`TenancyName`);

CREATE INDEX `IX_AbpUserAccounts_EmailAddress` ON `AbpUserAccounts` (`EmailAddress`);

CREATE INDEX `IX_AbpUserAccounts_UserName` ON `AbpUserAccounts` (`UserName`);

CREATE INDEX `IX_AbpUserAccounts_TenantId_EmailAddress` ON `AbpUserAccounts` (`TenantId`, `EmailAddress`);

CREATE INDEX `IX_AbpUserAccounts_TenantId_UserId` ON `AbpUserAccounts` (`TenantId`, `UserId`);

CREATE INDEX `IX_AbpUserAccounts_TenantId_UserName` ON `AbpUserAccounts` (`TenantId`, `UserName`);

CREATE INDEX `IX_AbpUserClaims_UserId` ON `AbpUserClaims` (`UserId`);

CREATE INDEX `IX_AbpUserClaims_TenantId_ClaimType` ON `AbpUserClaims` (`TenantId`, `ClaimType`);

CREATE INDEX `IX_AbpUserLoginAttempts_UserId_TenantId` ON `AbpUserLoginAttempts` (`UserId`, `TenantId`);

CREATE INDEX `IX_AbpUserLoginAttempts_TenancyName_UserNameOrEmailAddress_Resul` ON `AbpUserLoginAttempts` (`TenancyName`, `UserNameOrEmailAddress`, `Result`);

CREATE INDEX `IX_AbpUserLogins_UserId` ON `AbpUserLogins` (`UserId`);

CREATE INDEX `IX_AbpUserLogins_TenantId_UserId` ON `AbpUserLogins` (`TenantId`, `UserId`);

CREATE INDEX `IX_AbpUserLogins_TenantId_LoginProvider_ProviderKey` ON `AbpUserLogins` (`TenantId`, `LoginProvider`, `ProviderKey`);

CREATE INDEX `IX_AbpUserNotifications_UserId_State_CreationTime` ON `AbpUserNotifications` (`UserId`, `State`, `CreationTime`);

CREATE INDEX `IX_AbpUserOrganizationUnits_TenantId_OrganizationUnitId` ON `AbpUserOrganizationUnits` (`TenantId`, `OrganizationUnitId`);

CREATE INDEX `IX_AbpUserOrganizationUnits_TenantId_UserId` ON `AbpUserOrganizationUnits` (`TenantId`, `UserId`);

CREATE INDEX `IX_AbpUserRoles_UserId` ON `AbpUserRoles` (`UserId`);

CREATE INDEX `IX_AbpUserRoles_TenantId_RoleId` ON `AbpUserRoles` (`TenantId`, `RoleId`);

CREATE INDEX `IX_AbpUserRoles_TenantId_UserId` ON `AbpUserRoles` (`TenantId`, `UserId`);

CREATE INDEX `IX_AbpUsers_CreatorUserId` ON `AbpUsers` (`CreatorUserId`);

CREATE INDEX `IX_AbpUsers_DeleterUserId` ON `AbpUsers` (`DeleterUserId`);

CREATE INDEX `IX_AbpUsers_LastModifierUserId` ON `AbpUsers` (`LastModifierUserId`);

CREATE INDEX `IX_AbpUsers_TenantId_NormalizedEmailAddress` ON `AbpUsers` (`TenantId`, `NormalizedEmailAddress`);

CREATE INDEX `IX_AbpUsers_TenantId_NormalizedUserName` ON `AbpUsers` (`TenantId`, `NormalizedUserName`);

CREATE INDEX `IX_AbpUserTokens_UserId` ON `AbpUserTokens` (`UserId`);

CREATE INDEX `IX_AbpUserTokens_TenantId_UserId` ON `AbpUserTokens` (`TenantId`, `UserId`);

CREATE INDEX `IX_City_ParentId` ON `City` (`ParentId`);

CREATE INDEX `IX_Cookery_DishId` ON `Cookery` (`DishId`);

CREATE INDEX `IX_CookeryNote_CookeryId` ON `CookeryNote` (`CookeryId`);

CREATE INDEX `IX_CookeryNote_UserInfoId` ON `CookeryNote` (`UserInfoId`);

CREATE INDEX `IX_Dish_HomeMadeUserId` ON `Dish` (`HomeMadeUserId`);

CREATE INDEX `IX_DishBom_DishId` ON `DishBom` (`DishId`);

CREATE INDEX `IX_DishBom_FoodMaterialId` ON `DishBom` (`FoodMaterialId`);

CREATE INDEX `IX_FamilyMember_CareerId` ON `FamilyMember` (`CareerId`);

CREATE INDEX `IX_FamilyMember_FamilyId` ON `FamilyMember` (`FamilyId`);

CREATE INDEX `IX_FamilyMember_UserInfoId` ON `FamilyMember` (`UserInfoId`);

CREATE INDEX `IX_FoodMaterial_FoodMaterialCategoryId` ON `FoodMaterial` (`FoodMaterialCategoryId`);

CREATE INDEX `IX_FoodMaterialCategory_ParentId` ON `FoodMaterialCategory` (`ParentId`);

CREATE INDEX `IX_FoodMaterialHealthAffect_FoodMaterialId` ON `FoodMaterialHealthAffect` (`FoodMaterialId`);

CREATE INDEX `IX_FoodMaterialHealthAffect_HealthConcernId` ON `FoodMaterialHealthAffect` (`HealthConcernId`);

CREATE INDEX `IX_FoodMaterialInventory_FamilyId` ON `FoodMaterialInventory` (`FamilyId`);

CREATE INDEX `IX_FoodMaterialInventory_FoodMaterialId` ON `FoodMaterialInventory` (`FoodMaterialId`);

CREATE INDEX `IX_HealthConcern_HealthConcernCategoryId` ON `HealthConcern` (`HealthConcernCategoryId`);

CREATE INDEX `IX_PersonHealthAffect_FamilyMemberId` ON `PersonHealthAffect` (`FamilyMemberId`);

CREATE INDEX `IX_PersonHealthAffect_HealthConcernId` ON `PersonHealthAffect` (`HealthConcernId`);

CREATE INDEX `IX_Plan_DishId` ON `Plan` (`DishId`);

CREATE INDEX `IX_Plan_FamilyId` ON `Plan` (`FamilyId`);

CREATE INDEX `IX_Purchase_FamilyId` ON `Purchase` (`FamilyId`);

CREATE INDEX `IX_Purchase_FoodMaterialId` ON `Purchase` (`FoodMaterialId`);

CREATE INDEX `IX_UserAttention_AttentionId` ON `UserAttention` (`AttentionId`);

CREATE INDEX `IX_UserAttention_FanId` ON `UserAttention` (`FanId`);

CREATE INDEX `IX_UserBrowseDish_DishId` ON `UserBrowseDish` (`DishId`);

CREATE INDEX `IX_UserBrowseDish_UserInfoId` ON `UserBrowseDish` (`UserInfoId`);

CREATE INDEX `IX_UserCommentDish_DishId` ON `UserCommentDish` (`DishId`);

CREATE INDEX `IX_UserCommentDish_UserInfoId` ON `UserCommentDish` (`UserInfoId`);

CREATE INDEX `IX_UserFavoriteDish_DishId` ON `UserFavoriteDish` (`DishId`);

CREATE INDEX `IX_UserFavoriteDish_UserInfoId` ON `UserFavoriteDish` (`UserInfoId`);

CREATE INDEX `IX_UserInfo_CareerId` ON `UserInfo` (`CareerId`);

CREATE INDEX `IX_UserInfo_CityId` ON `UserInfo` (`CityId`);

CREATE INDEX `IX_UserInfo_FamilyId` ON `UserInfo` (`FamilyId`);

CREATE UNIQUE INDEX `IX_UserInfo_UserId` ON `UserInfo` (`UserId`);

INSERT INTO `__EFMigrationsHistory` (`MigrationId`, `ProductVersion`)
VALUES ('20180121061339_new_reset', '2.0.1-rtm-125');

