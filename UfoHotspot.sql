-- MySQL dump 10.13  Distrib 8.0.21, for macos10.15 (x86_64)
--
-- Host: 127.0.0.1    Database: UfoHotspot
-- ------------------------------------------------------
-- Server version	8.0.28

/*!40101 SET @OLD_CHARACTER_SET_CLIENT=@@CHARACTER_SET_CLIENT */;
/*!40101 SET @OLD_CHARACTER_SET_RESULTS=@@CHARACTER_SET_RESULTS */;
/*!40101 SET @OLD_COLLATION_CONNECTION=@@COLLATION_CONNECTION */;
/*!50503 SET NAMES utf8 */;
/*!40103 SET @OLD_TIME_ZONE=@@TIME_ZONE */;
/*!40103 SET TIME_ZONE='+00:00' */;
/*!40014 SET @OLD_UNIQUE_CHECKS=@@UNIQUE_CHECKS, UNIQUE_CHECKS=0 */;
/*!40014 SET @OLD_FOREIGN_KEY_CHECKS=@@FOREIGN_KEY_CHECKS, FOREIGN_KEY_CHECKS=0 */;
/*!40101 SET @OLD_SQL_MODE=@@SQL_MODE, SQL_MODE='NO_AUTO_VALUE_ON_ZERO' */;
/*!40111 SET @OLD_SQL_NOTES=@@SQL_NOTES, SQL_NOTES=0 */;

--
-- Table structure for table `Hotspot`
--

DROP TABLE IF EXISTS `Hotspot`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `Hotspot` (
  `Id` int NOT NULL AUTO_INCREMENT,
  `Name` varchar(255) DEFAULT NULL,
  `Latitude` double DEFAULT NULL,
  `Longitude` double DEFAULT NULL,
  PRIMARY KEY (`Id`)
) ENGINE=InnoDB AUTO_INCREMENT=6 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Table structure for table `Sighting`
--

DROP TABLE IF EXISTS `Sighting`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `Sighting` (
  `Id` int NOT NULL AUTO_INCREMENT,
  `SightingDate` datetime DEFAULT NULL,
  `Shape` varchar(255) DEFAULT NULL,
  `DurationInSeconds` varchar(255) DEFAULT NULL,
  `DurationInHours` varchar(255) DEFAULT NULL,
  `Comments` varchar(1024) DEFAULT NULL,
  `Address` varchar(255) DEFAULT NULL,
  `Latitude` double DEFAULT NULL,
  `Longitude` double DEFAULT NULL,
  PRIMARY KEY (`Id`)
) ENGINE=InnoDB AUTO_INCREMENT=80333 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Temporary view structure for view `VwHotspotSightingDistance`
--

DROP TABLE IF EXISTS `VwHotspotSightingDistance`;
/*!50001 DROP VIEW IF EXISTS `VwHotspotSightingDistance`*/;
SET @saved_cs_client     = @@character_set_client;
/*!50503 SET character_set_client = utf8mb4 */;
/*!50001 CREATE VIEW `VwHotspotSightingDistance` AS SELECT 
 1 AS `HotspotName`,
 1 AS `HotspotLat`,
 1 AS `HotspotLng`,
 1 AS `SightingLat`,
 1 AS `SightingLng`,
 1 AS `SightingDate`,
 1 AS `Shape`,
 1 AS `DurationInSeconds`,
 1 AS `DurationInHours`,
 1 AS `Address`,
 1 AS `Comments`,
 1 AS `Distance`*/;
SET character_set_client = @saved_cs_client;

--
-- Table structure for table `__EFMigrationsHistory`
--

DROP TABLE IF EXISTS `__EFMigrationsHistory`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `__EFMigrationsHistory` (
  `MigrationId` varchar(150) NOT NULL,
  `ProductVersion` varchar(32) NOT NULL,
  PRIMARY KEY (`MigrationId`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Final view structure for view `VwHotspotSightingDistance`
--

/*!50001 DROP VIEW IF EXISTS `VwHotspotSightingDistance`*/;
/*!50001 SET @saved_cs_client          = @@character_set_client */;
/*!50001 SET @saved_cs_results         = @@character_set_results */;
/*!50001 SET @saved_col_connection     = @@collation_connection */;
/*!50001 SET character_set_client      = utf8mb4 */;
/*!50001 SET character_set_results     = utf8mb4 */;
/*!50001 SET collation_connection      = utf8mb4_0900_ai_ci */;
/*!50001 CREATE ALGORITHM=UNDEFINED */
/*!50013 DEFINER=`root`@`%` SQL SECURITY DEFINER */
/*!50001 VIEW `VwHotspotSightingDistance` AS select `Tbl`.`HotspotName` AS `HotspotName`,`Tbl`.`HotspotLat` AS `HotspotLat`,`Tbl`.`HotspotLng` AS `HotspotLng`,`Tbl`.`SightingLat` AS `SightingLat`,`Tbl`.`SightingLng` AS `SightingLng`,`Tbl`.`SightingDate` AS `SightingDate`,`Tbl`.`Shape` AS `Shape`,`Tbl`.`DurationInSeconds` AS `DurationInSeconds`,`Tbl`.`DurationInHours` AS `DurationInHours`,`Tbl`.`Address` AS `Address`,`Tbl`.`Comments` AS `Comments`,(6371 * acos((((cos(radians(`Tbl`.`HotspotLat`)) * cos(radians(`Tbl`.`SightingLat`))) * cos((radians(`Tbl`.`SightingLng`) - radians(`Tbl`.`HotspotLng`)))) + (sin(radians(`Tbl`.`HotspotLat`)) * sin(radians(`Tbl`.`SightingLat`)))))) AS `Distance` from (select `h`.`Name` AS `HotspotName`,`h`.`Latitude` AS `HotspotLat`,`h`.`Longitude` AS `HotspotLng`,`s`.`Latitude` AS `SightingLat`,`s`.`Longitude` AS `SightingLng`,`s`.`SightingDate` AS `SightingDate`,`s`.`Shape` AS `Shape`,`s`.`DurationInSeconds` AS `DurationInSeconds`,`s`.`DurationInHours` AS `DurationInHours`,`s`.`Address` AS `Address`,`s`.`Comments` AS `Comments` from (`Sighting` `s` join `Hotspot` `h`)) `Tbl` */;
/*!50001 SET character_set_client      = @saved_cs_client */;
/*!50001 SET character_set_results     = @saved_cs_results */;
/*!50001 SET collation_connection      = @saved_col_connection */;
/*!40103 SET TIME_ZONE=@OLD_TIME_ZONE */;

/*!40101 SET SQL_MODE=@OLD_SQL_MODE */;
/*!40014 SET FOREIGN_KEY_CHECKS=@OLD_FOREIGN_KEY_CHECKS */;
/*!40014 SET UNIQUE_CHECKS=@OLD_UNIQUE_CHECKS */;
/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
/*!40111 SET SQL_NOTES=@OLD_SQL_NOTES */;

-- Dump completed on 2022-02-20 18:54:33
