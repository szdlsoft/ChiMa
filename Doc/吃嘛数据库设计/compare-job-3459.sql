ALTER TABLE `abppermissions`
 DROP FOREIGN KEY `FK_AbpPermissions_AbpRoles_RoleId`;

ALTER TABLE `abppermissions`
 ADD CONSTRAINT `FK_AbpPermissions_AbpRoles_RoleId` FOREIGN KEY (`RoleId`) REFERENCES `chimanew`.`abproles` (`Id`) ON DELETE CASCADE;

ALTER TABLE `abppermissions`
 DROP FOREIGN KEY `FK_AbpPermissions_AbpUsers_UserId`;

ALTER TABLE `abppermissions`
 ADD CONSTRAINT `FK_AbpPermissions_AbpUsers_UserId` FOREIGN KEY (`UserId`) REFERENCES `chimanew`.`abpusers` (`Id`) ON DELETE CASCADE;

ALTER TABLE `abproleclaims`
 DROP FOREIGN KEY `FK_AbpRoleClaims_AbpRoles_RoleId`;

ALTER TABLE `abproleclaims`
 ADD CONSTRAINT `FK_AbpRoleClaims_AbpRoles_RoleId` FOREIGN KEY (`RoleId`) REFERENCES `chimanew`.`abproles` (`Id`) ON DELETE CASCADE;

ALTER TABLE `abproles`
 DROP FOREIGN KEY `FK_AbpRoles_AbpUsers_CreatorUserId`;

ALTER TABLE `abproles`
 ADD CONSTRAINT `FK_AbpRoles_AbpUsers_CreatorUserId` FOREIGN KEY (`CreatorUserId`) REFERENCES `chimanew`.`abpusers` (`Id`) ON DELETE NO ACTION;

ALTER TABLE `abproles`
 DROP FOREIGN KEY `FK_AbpRoles_AbpUsers_DeleterUserId`;

ALTER TABLE `abproles`
 ADD CONSTRAINT `FK_AbpRoles_AbpUsers_DeleterUserId` FOREIGN KEY (`DeleterUserId`) REFERENCES `chimanew`.`abpusers` (`Id`) ON DELETE NO ACTION;

ALTER TABLE `abproles`
 DROP FOREIGN KEY `FK_AbpRoles_AbpUsers_LastModifierUserId`;

ALTER TABLE `abproles`
 ADD CONSTRAINT `FK_AbpRoles_AbpUsers_LastModifierUserId` FOREIGN KEY (`LastModifierUserId`) REFERENCES `chimanew`.`abpusers` (`Id`) ON DELETE NO ACTION;

ALTER TABLE `abpsettings`
 DROP FOREIGN KEY `FK_AbpSettings_AbpUsers_UserId`;

ALTER TABLE `abpsettings`
 ADD CONSTRAINT `FK_AbpSettings_AbpUsers_UserId` FOREIGN KEY (`UserId`) REFERENCES `chimanew`.`abpusers` (`Id`) ON DELETE NO ACTION;

ALTER TABLE `abptenants`
 DROP FOREIGN KEY `FK_AbpTenants_AbpEditions_EditionId`;

ALTER TABLE `abptenants`
 ADD CONSTRAINT `FK_AbpTenants_AbpEditions_EditionId` FOREIGN KEY (`EditionId`) REFERENCES `chimanew`.`abpeditions` (`Id`) ON DELETE NO ACTION;

ALTER TABLE `abptenants`
 DROP FOREIGN KEY `FK_AbpTenants_AbpUsers_CreatorUserId`;

ALTER TABLE `abptenants`
 ADD CONSTRAINT `FK_AbpTenants_AbpUsers_CreatorUserId` FOREIGN KEY (`CreatorUserId`) REFERENCES `chimanew`.`abpusers` (`Id`) ON DELETE NO ACTION;

ALTER TABLE `abptenants`
 DROP FOREIGN KEY `FK_AbpTenants_AbpUsers_DeleterUserId`;

ALTER TABLE `abptenants`
 ADD CONSTRAINT `FK_AbpTenants_AbpUsers_DeleterUserId` FOREIGN KEY (`DeleterUserId`) REFERENCES `chimanew`.`abpusers` (`Id`) ON DELETE NO ACTION;

ALTER TABLE `abptenants`
 DROP FOREIGN KEY `FK_AbpTenants_AbpUsers_LastModifierUserId`;

ALTER TABLE `abptenants`
 ADD CONSTRAINT `FK_AbpTenants_AbpUsers_LastModifierUserId` FOREIGN KEY (`LastModifierUserId`) REFERENCES `chimanew`.`abpusers` (`Id`) ON DELETE NO ACTION;

ALTER TABLE `abpuserclaims`
 DROP FOREIGN KEY `FK_AbpUserClaims_AbpUsers_UserId`;

ALTER TABLE `abpuserclaims`
 ADD CONSTRAINT `FK_AbpUserClaims_AbpUsers_UserId` FOREIGN KEY (`UserId`) REFERENCES `chimanew`.`abpusers` (`Id`) ON DELETE CASCADE;

ALTER TABLE `abpuserlogins`
 DROP FOREIGN KEY `FK_AbpUserLogins_AbpUsers_UserId`;

ALTER TABLE `abpuserlogins`
 ADD CONSTRAINT `FK_AbpUserLogins_AbpUsers_UserId` FOREIGN KEY (`UserId`) REFERENCES `chimanew`.`abpusers` (`Id`) ON DELETE CASCADE;

ALTER TABLE `abpuserroles`
 DROP FOREIGN KEY `FK_AbpUserRoles_AbpUsers_UserId`;

ALTER TABLE `abpuserroles`
 ADD CONSTRAINT `FK_AbpUserRoles_AbpUsers_UserId` FOREIGN KEY (`UserId`) REFERENCES `chimanew`.`abpusers` (`Id`) ON DELETE CASCADE;

ALTER TABLE `abpusers`
 DROP FOREIGN KEY `FK_AbpUsers_AbpUsers_CreatorUserId`;

ALTER TABLE `abpusers`
 ADD CONSTRAINT `FK_AbpUsers_AbpUsers_CreatorUserId` FOREIGN KEY (`CreatorUserId`) REFERENCES `chimanew`.`abpusers` (`Id`) ON DELETE NO ACTION;

ALTER TABLE `abpusers`
 DROP FOREIGN KEY `FK_AbpUsers_AbpUsers_DeleterUserId`;

ALTER TABLE `abpusers`
 ADD CONSTRAINT `FK_AbpUsers_AbpUsers_DeleterUserId` FOREIGN KEY (`DeleterUserId`) REFERENCES `chimanew`.`abpusers` (`Id`) ON DELETE NO ACTION;

ALTER TABLE `abpusers`
 DROP FOREIGN KEY `FK_AbpUsers_AbpUsers_LastModifierUserId`;

ALTER TABLE `abpusers`
 ADD CONSTRAINT `FK_AbpUsers_AbpUsers_LastModifierUserId` FOREIGN KEY (`LastModifierUserId`) REFERENCES `chimanew`.`abpusers` (`Id`) ON DELETE NO ACTION;

ALTER TABLE `abpusertokens`
 DROP FOREIGN KEY `FK_AbpUserTokens_AbpUsers_UserId`;

ALTER TABLE `abpusertokens`
 ADD CONSTRAINT `FK_AbpUserTokens_AbpUsers_UserId` FOREIGN KEY (`UserId`) REFERENCES `chimanew`.`abpusers` (`Id`) ON DELETE CASCADE;

ALTER TABLE `city`
 DROP FOREIGN KEY `FK_City_City_ParentId`;

ALTER TABLE `city`
 ADD CONSTRAINT `FK_City_City_ParentId` FOREIGN KEY (`ParentId`) REFERENCES `chimanew`.`city` (`Id`) ON DELETE NO ACTION;

ALTER TABLE `cookery` 
	--ADD COLUMN `Content` varchar(512) CHARACTER SET latin1 COLLATE latin1_swedish_ci NULL AFTER `Video`;

ALTER TABLE `cookery`
 DROP FOREIGN KEY `FK_Cookery_Dish_DishId`;

ALTER TABLE `cookery`
 ADD CONSTRAINT `FK_Cookery_Dish_DishId` FOREIGN KEY (`DishId`) REFERENCES `chimanew`.`dish` (`Id`) ON DELETE NO ACTION;

ALTER TABLE `dish` 
	ADD COLUMN `BPhoto` varchar(512) CHARACTER SET latin1 COLLATE latin1_swedish_ci NULL AFTER `Taste`,
	ADD COLUMN `Difficulty` int(11) NULL AFTER `BPhoto`,
	ADD COLUMN `HPhoto` varchar(512) CHARACTER SET latin1 COLLATE latin1_swedish_ci NULL AFTER `Difficulty`,
	ADD COLUMN `Star` int(11) NULL AFTER `HPhoto`;

ALTER TABLE `dish`
 DROP FOREIGN KEY `FK_Dish_UserInfo_HomeMadeUserId`;

ALTER TABLE `dish`
 ADD CONSTRAINT `FK_Dish_UserInfo_HomeMadeUserId` FOREIGN KEY (`HomeMadeUserId`) REFERENCES `chimanew`.`userinfo` (`Id`) ON DELETE NO ACTION;

ALTER TABLE `dishbom`
 DROP FOREIGN KEY `FK_DishBom_Dish_DishId`;

ALTER TABLE `dishbom`
 ADD CONSTRAINT `FK_DishBom_Dish_DishId` FOREIGN KEY (`DishId`) REFERENCES `chimanew`.`dish` (`Id`) ON DELETE CASCADE;

ALTER TABLE `dishbom`
 DROP FOREIGN KEY `FK_DishBom_FoodMaterial_FoodMaterialId`;

ALTER TABLE `dishbom`
 ADD CONSTRAINT `FK_DishBom_FoodMaterial_FoodMaterialId` FOREIGN KEY (`FoodMaterialId`) REFERENCES `chimanew`.`foodmaterial` (`Id`) ON DELETE CASCADE;

ALTER TABLE `familymember` 
	ADD COLUMN `UserInfoId` bigint(20) NULL AFTER `Age_To`,
	ADD KEY `IX_FamilyMember_UserInfoId`(`UserInfoId`) USING BTREE;

ALTER TABLE `familymember`
 DROP FOREIGN KEY `FK_FamilyMember_Career_CareerId`;

ALTER TABLE `familymember`
 ADD CONSTRAINT `FK_FamilyMember_Career_CareerId` FOREIGN KEY (`CareerId`) REFERENCES `chimanew`.`career` (`Id`) ON DELETE NO ACTION;

ALTER TABLE `familymember`
 DROP FOREIGN KEY `FK_FamilyMember_Family_FamilyId`;

ALTER TABLE `familymember`
 ADD CONSTRAINT `FK_FamilyMember_Family_FamilyId` FOREIGN KEY (`FamilyId`) REFERENCES `chimanew`.`family` (`Id`) ON DELETE NO ACTION;

ALTER TABLE `familymember`
 ADD CONSTRAINT `FK_FamilyMember_UserInfo_UserInfoId` FOREIGN KEY (`UserInfoId`) REFERENCES `chimanew`.`userinfo` (`Id`) ON DELETE NO ACTION;

ALTER TABLE `foodmaterial` 
	ADD COLUMN `IsMain` bit(1) NOT NULL AFTER `ImportId`,
	ADD COLUMN `Price` double NULL AFTER `IsMain`,
	ADD COLUMN `Unit` varchar(256) CHARACTER SET latin1 COLLATE latin1_swedish_ci NULL AFTER `Price`,
	ADD COLUMN `StorageMode` varchar(256) CHARACTER SET latin1 COLLATE latin1_swedish_ci NULL AFTER `Unit`;

ALTER TABLE `foodmaterial`
 DROP FOREIGN KEY `FK_FoodMaterial_FoodMaterialCategory_FoodMaterialCategoryId`;

ALTER TABLE `foodmaterial`
 ADD CONSTRAINT `FK_FoodMaterial_FoodMaterialCategory_FoodMaterialCategoryId` FOREIGN KEY (`FoodMaterialCategoryId`) REFERENCES `chimanew`.`foodmaterialcategory` (`Id`) ON DELETE NO ACTION;

ALTER TABLE `foodmaterialcategory` 
	ADD COLUMN `IndexNo` int(11) NULL AFTER `ParentId`;

ALTER TABLE `foodmaterialcategory`
 DROP FOREIGN KEY `FK_FoodMaterialCategory_FoodMaterialCategory_ParentId`;

ALTER TABLE `foodmaterialcategory`
 ADD CONSTRAINT `FK_FoodMaterialCategory_FoodMaterialCategory_ParentId` FOREIGN KEY (`ParentId`) REFERENCES `chimanew`.`foodmaterialcategory` (`Id`) ON DELETE NO ACTION;

ALTER TABLE `foodmaterialhealthaffect`
 DROP FOREIGN KEY `FK_FoodMaterialHealthAffect_FoodMaterial_FoodMaterialId`;

ALTER TABLE `foodmaterialhealthaffect`
 ADD CONSTRAINT `FK_FoodMaterialHealthAffect_FoodMaterial_FoodMaterialId` FOREIGN KEY (`FoodMaterialId`) REFERENCES `chimanew`.`foodmaterial` (`Id`) ON DELETE NO ACTION;

ALTER TABLE `foodmaterialhealthaffect`
 DROP FOREIGN KEY `FK_FoodMaterialHealthAffect_HealthConcern_HealthConcernId`;

ALTER TABLE `foodmaterialhealthaffect`
 ADD CONSTRAINT `FK_FoodMaterialHealthAffect_HealthConcern_HealthConcernId` FOREIGN KEY (`HealthConcernId`) REFERENCES `chimanew`.`healthconcern` (`Id`) ON DELETE NO ACTION;

ALTER TABLE `healthconcern`
 DROP FOREIGN KEY `FK_HealthConcern_HealthConcernCategory_HealthConcernCategoryId`;

ALTER TABLE `healthconcern`
 ADD CONSTRAINT `FK_HealthConcern_HealthConcernCategory_HealthConcernCategoryId` FOREIGN KEY (`HealthConcernCategoryId`) REFERENCES `chimanew`.`healthconcerncategory` (`Id`) ON DELETE NO ACTION;

ALTER TABLE `personhealthaffect`
 DROP FOREIGN KEY `FK_PersonHealthAffect_FamilyMember_FamilyMemberId`;

ALTER TABLE `personhealthaffect`
 ADD CONSTRAINT `FK_PersonHealthAffect_FamilyMember_FamilyMemberId` FOREIGN KEY (`FamilyMemberId`) REFERENCES `chimanew`.`familymember` (`Id`) ON DELETE NO ACTION;

ALTER TABLE `personhealthaffect`
 DROP FOREIGN KEY `FK_PersonHealthAffect_HealthConcern_HealthConcernId`;

ALTER TABLE `personhealthaffect`
 ADD CONSTRAINT `FK_PersonHealthAffect_HealthConcern_HealthConcernId` FOREIGN KEY (`HealthConcernId`) REFERENCES `chimanew`.`healthconcern` (`Id`) ON DELETE NO ACTION;

ALTER TABLE `userattention`
 DROP FOREIGN KEY `FK_UserAttention_UserInfo_AttentionId`;

ALTER TABLE `userattention`
 ADD CONSTRAINT `FK_UserAttention_UserInfo_AttentionId` FOREIGN KEY (`AttentionId`) REFERENCES `chimanew`.`userinfo` (`Id`) ON DELETE NO ACTION;

ALTER TABLE `userattention`
 DROP FOREIGN KEY `FK_UserAttention_UserInfo_FanId`;

ALTER TABLE `userattention`
 ADD CONSTRAINT `FK_UserAttention_UserInfo_FanId` FOREIGN KEY (`FanId`) REFERENCES `chimanew`.`userinfo` (`Id`) ON DELETE NO ACTION;

ALTER TABLE `userbrowsedish` 
	DROP COLUMN `UserId`,
	ADD COLUMN `UserInfoId` bigint(20) NULL AFTER `LastModifierUserId`,
	DROP KEY `IX_UserBrowseDish_UserId`,
	ADD KEY `IX_UserBrowseDish_UserId`(`UserInfoId`) USING BTREE;

ALTER TABLE `userbrowsedish`
 DROP FOREIGN KEY `FK_UserBrowseDish_Dish_DishId`;

ALTER TABLE `userbrowsedish`
 ADD CONSTRAINT `FK_UserBrowseDish_Dish_DishId` FOREIGN KEY (`DishId`) REFERENCES `chimanew`.`dish` (`Id`) ON DELETE NO ACTION;

ALTER TABLE `userbrowsedish`
 DROP FOREIGN KEY `FK_UserBrowseDish_UserInfo_UserId`;

ALTER TABLE `usercommentdish` 
	DROP COLUMN `UserId`,
	ADD COLUMN `UserInfoId` bigint(20) NULL AFTER `Rate`,
	DROP KEY `IX_UserCommentDish_UserId`,
	ADD KEY `IX_UserCommentDish_UserId`(`UserInfoId`) USING BTREE;

ALTER TABLE `usercommentdish`
 DROP FOREIGN KEY `FK_UserCommentDish_Dish_DishId`;

ALTER TABLE `usercommentdish`
 ADD CONSTRAINT `FK_UserCommentDish_Dish_DishId` FOREIGN KEY (`DishId`) REFERENCES `chimanew`.`dish` (`Id`) ON DELETE NO ACTION;

ALTER TABLE `usercommentdish`
 DROP FOREIGN KEY `FK_UserCommentDish_UserInfo_UserId`;

ALTER TABLE `userfavoritedish` 
	DROP COLUMN `UserId`,
	ADD COLUMN `UserInfoId` bigint(20) NOT NULL AFTER `LastModifierUserId`,
	ADD KEY `FK_UserFavoriteDish_UserInfo_UserInfoId`(`UserInfoId`) USING BTREE,
	DROP KEY `IX_UserFavoriteDish_UserId`;

ALTER TABLE `userfavoritedish`
 DROP FOREIGN KEY `FK_UserFavoriteDish_Dish_DishId`;

ALTER TABLE `userfavoritedish`
 ADD CONSTRAINT `FK_UserFavoriteDish_Dish_DishId` FOREIGN KEY (`DishId`) REFERENCES `chimanew`.`dish` (`Id`) ON DELETE NO ACTION;

ALTER TABLE `userfavoritedish`
 ADD CONSTRAINT `FK_UserFavoriteDish_UserInfo_UserInfoId` FOREIGN KEY (`UserInfoId`) REFERENCES `chimanew`.`userinfo` (`Id`) ON DELETE CASCADE;

ALTER TABLE `userfavoritedish`
 DROP FOREIGN KEY `FK_UserFavoriteDish_UserInfo_UserId`;

ALTER TABLE `userinfo` 
	MODIFY COLUMN `FamilyId` bigint(20) NOT NULL AFTER `ExtensionData`,
	ADD COLUMN `IsFamilyCreater` bit(1) NOT NULL AFTER `UserId`;

ALTER TABLE `userinfo`
 DROP FOREIGN KEY `FK_UserInfo_AbpUsers_UserId`;

ALTER TABLE `userinfo`
 ADD CONSTRAINT `FK_UserInfo_AbpUsers_UserId` FOREIGN KEY (`UserId`) REFERENCES `chimanew`.`abpusers` (`Id`) ON DELETE CASCADE;

ALTER TABLE `userinfo`
 DROP FOREIGN KEY `FK_UserInfo_Career_CareerId`;

ALTER TABLE `userinfo`
 ADD CONSTRAINT `FK_UserInfo_Career_CareerId` FOREIGN KEY (`CareerId`) REFERENCES `chimanew`.`career` (`Id`) ON DELETE NO ACTION;

ALTER TABLE `userinfo`
 DROP FOREIGN KEY `FK_UserInfo_City_CityId`;

ALTER TABLE `userinfo`
 ADD CONSTRAINT `FK_UserInfo_City_CityId` FOREIGN KEY (`CityId`) REFERENCES `chimanew`.`city` (`Id`) ON DELETE NO ACTION;

ALTER TABLE `userinfo`
 DROP FOREIGN KEY `FK_UserInfo_Family_FamilyId`;

ALTER TABLE `abpfeatures`
 DROP FOREIGN KEY `FK_AbpFeatures_AbpEditions_EditionId`;

ALTER TABLE `abpfeatures`
 ADD CONSTRAINT `FK_AbpFeatures_AbpEditions_EditionId` FOREIGN KEY (`EditionId`) REFERENCES `chimanew`.`abpeditions` (`Id`) ON DELETE CASCADE;

ALTER TABLE `abporganizationunits`
 DROP FOREIGN KEY `FK_AbpOrganizationUnits_AbpOrganizationUnits_ParentId`;

ALTER TABLE `abporganizationunits`
 ADD CONSTRAINT `FK_AbpOrganizationUnits_AbpOrganizationUnits_ParentId` FOREIGN KEY (`ParentId`) REFERENCES `chimanew`.`abporganizationunits` (`Id`) ON DELETE NO ACTION;

CREATE TABLE `cookerynote` (
  `Id` bigint(20) NOT NULL AUTO_INCREMENT,
  `Audio` varchar(512) DEFAULT NULL,
  `CookeryId` bigint(20) NOT NULL,
  `CreationTime` datetime(6) NOT NULL,
  `CreatorUserId` bigint(20) DEFAULT NULL,
  `DeleterUserId` bigint(20) DEFAULT NULL,
  `DeletionTime` datetime(6) DEFAULT NULL,
  `Description` varchar(256) NOT NULL,
  `ExtensionData` longtext,
  `IsDeleted` bit(1) NOT NULL,
  `LastModificationTime` datetime(6) DEFAULT NULL,
  `LastModifierUserId` bigint(20) DEFAULT NULL,
  `Photo` varchar(512) DEFAULT NULL,
  `Video` varchar(512) DEFAULT NULL,
  `UserInfoId` bigint(20) NOT NULL DEFAULT '0',
  PRIMARY KEY (`Id`),
  KEY `IX_CookeryNote_CookeryId` (`CookeryId`),
  KEY `IX_CookeryNote_UserInfoId` (`UserInfoId`),
  CONSTRAINT `FK_CookeryNote_Cookery_CookeryId` FOREIGN KEY (`CookeryId`) REFERENCES `cookery` (`Id`) ON DELETE CASCADE,
  CONSTRAINT `FK_CookeryNote_UserInfo_UserInfoId` FOREIGN KEY (`UserInfoId`) REFERENCES `userinfo` (`Id`) ON DELETE CASCADE
) ENGINE=InnoDB AUTO_INCREMENT=4 DEFAULT CHARSET=utf8;

CREATE TABLE `foodmaterialinventory` (
  `Id` bigint(20) NOT NULL AUTO_INCREMENT,
  `CreationTime` datetime(6) NOT NULL,
  `CreatorUserId` bigint(20) DEFAULT NULL,
  `DeleterUserId` bigint(20) DEFAULT NULL,
  `DeletionTime` datetime(6) DEFAULT NULL,
  `ExtensionData` longtext,
  `FamilyId` bigint(20) NOT NULL,
  `FoodMaterialId` bigint(20) DEFAULT NULL,
  `Inventory` int(11) DEFAULT NULL,
  `IsDeleted` bit(1) NOT NULL,
  `LastModificationTime` datetime(6) DEFAULT NULL,
  `LastModifierUserId` bigint(20) DEFAULT NULL,
  PRIMARY KEY (`Id`),
  KEY `IX_FoodMaterialInventory_FamilyId` (`FamilyId`),
  KEY `IX_FoodMaterialInventory_FoodMaterialId` (`FoodMaterialId`),
  CONSTRAINT `FK_FoodMaterialInventory_FoodMaterial_FoodMaterialId` FOREIGN KEY (`FoodMaterialId`) REFERENCES `foodmaterial` (`Id`) ON DELETE NO ACTION
) ENGINE=InnoDB AUTO_INCREMENT=6 DEFAULT CHARSET=latin1;

CREATE TABLE `plan` (
  `Id` bigint(20) NOT NULL AUTO_INCREMENT,
  `CreationTime` datetime(6) NOT NULL,
  `CreatorUserId` bigint(20) DEFAULT NULL,
  `DeleterUserId` bigint(20) DEFAULT NULL,
  `DeletionTime` datetime(6) DEFAULT NULL,
  `DishId` bigint(20) NOT NULL,
  `ExtensionData` longtext,
  `FamilyId` bigint(20) NOT NULL,
  `IsDeleted` bit(1) NOT NULL,
  `MealNo` int(11) NOT NULL,
  `LastModificationTime` datetime(6) DEFAULT NULL,
  `LastModifierUserId` bigint(20) DEFAULT NULL,
  `PlanDate` datetime(6) NOT NULL,
  `MealType` int(11) NOT NULL DEFAULT '0',
  PRIMARY KEY (`Id`),
  KEY `IX_Plan_DishId` (`DishId`),
  KEY `IX_Plan_FamilyId` (`FamilyId`),
  CONSTRAINT `FK_Plan_Dish_DishId` FOREIGN KEY (`DishId`) REFERENCES `dish` (`Id`) ON DELETE CASCADE,
  CONSTRAINT `FK_Plan_Family_FamilyId` FOREIGN KEY (`FamilyId`) REFERENCES `family` (`Id`) ON DELETE CASCADE
) ENGINE=InnoDB AUTO_INCREMENT=64 DEFAULT CHARSET=latin1;

CREATE TABLE `purchase` (
  `Id` bigint(20) NOT NULL AUTO_INCREMENT,
  `CreationTime` datetime(6) NOT NULL,
  `CreatorUserId` bigint(20) DEFAULT NULL,
  `DeleterUserId` bigint(20) DEFAULT NULL,
  `DeletionTime` datetime(6) DEFAULT NULL,
  `ExtensionData` longtext,
  `FamilyId` bigint(20) NOT NULL,
  `FoodMaterialId` bigint(20) DEFAULT NULL,
  `HasPurchased` bit(1) NOT NULL,
  `IsDeleted` bit(1) NOT NULL,
  `LastModificationTime` datetime(6) DEFAULT NULL,
  `LastModifierUserId` bigint(20) DEFAULT NULL,
  `MakeTime` datetime(6) DEFAULT NULL,
  `PurchaseTime` datetime(6) DEFAULT NULL,
  `Volume` int(11) DEFAULT NULL,
  PRIMARY KEY (`Id`),
  KEY `IX_Purchase_FamilyId` (`FamilyId`),
  KEY `IX_Purchase_FoodMaterialId` (`FoodMaterialId`),
  CONSTRAINT `FK_Purchase_FoodMaterial_FoodMaterialId` FOREIGN KEY (`FoodMaterialId`) REFERENCES `foodmaterial` (`Id`) ON DELETE NO ACTION
) ENGINE=InnoDB AUTO_INCREMENT=9 DEFAULT CHARSET=latin1;

DROP TABLE `abpnotifications`;

