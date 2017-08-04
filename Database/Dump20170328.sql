-- MySQL dump 10.13  Distrib 5.7.17, for macos10.12 (x86_64)
--
-- Host: sql12.freemysqlhosting.net    Database: sql12164903
-- ------------------------------------------------------
-- Server version	5.5.54-0ubuntu0.14.04.1

/*!40101 SET @OLD_CHARACTER_SET_CLIENT=@@CHARACTER_SET_CLIENT */;
/*!40101 SET @OLD_CHARACTER_SET_RESULTS=@@CHARACTER_SET_RESULTS */;
/*!40101 SET @OLD_COLLATION_CONNECTION=@@COLLATION_CONNECTION */;
/*!40101 SET NAMES utf8 */;
/*!40103 SET @OLD_TIME_ZONE=@@TIME_ZONE */;
/*!40103 SET TIME_ZONE='+00:00' */;
/*!40014 SET @OLD_UNIQUE_CHECKS=@@UNIQUE_CHECKS, UNIQUE_CHECKS=0 */;
/*!40014 SET @OLD_FOREIGN_KEY_CHECKS=@@FOREIGN_KEY_CHECKS, FOREIGN_KEY_CHECKS=0 */;
/*!40101 SET @OLD_SQL_MODE=@@SQL_MODE, SQL_MODE='NO_AUTO_VALUE_ON_ZERO' */;
/*!40111 SET @OLD_SQL_NOTES=@@SQL_NOTES, SQL_NOTES=0 */;

--
-- Table structure for table `cash_orders`
--

DROP TABLE IF EXISTS `cash_orders`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `cash_orders` (
  `id` int(11) NOT NULL AUTO_INCREMENT,
  `cash` int(11) DEFAULT NULL,
  `pingback_status` enum('Pending','Paid','Cancel') DEFAULT 'Pending',
  `order_status` enum('Pending','Paid','Cancel') DEFAULT 'Pending',
  `user_id` int(11) DEFAULT NULL,
  `created_at` timestamp NOT NULL DEFAULT CURRENT_TIMESTAMP ON UPDATE CURRENT_TIMESTAMP,
  PRIMARY KEY (`id`)
) ENGINE=InnoDB AUTO_INCREMENT=16 DEFAULT CHARSET=latin1;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `cash_orders`
--

LOCK TABLES `cash_orders` WRITE;
/*!40000 ALTER TABLE `cash_orders` DISABLE KEYS */;
INSERT INTO `cash_orders` VALUES (2,2,'Paid','Paid',1,'2017-03-27 05:03:36'),(3,4000,'Paid','Paid',1,'2017-03-27 05:03:56'),(4,2000,'Paid','Paid',1,'2017-03-27 05:26:49'),(5,4000,'Paid','Paid',1,'2017-03-27 05:26:58'),(6,4000,'Paid','Paid',1,'2017-03-27 05:27:54'),(7,4000,'Paid','Paid',1,'2017-03-27 05:28:58'),(8,4000,'Paid','Paid',1,'2017-03-27 05:47:36'),(9,1,'Paid','Paid',1,'2017-03-27 05:56:27'),(10,1,'Paid','Paid',1,'2017-03-27 05:56:36'),(11,1,'Paid','Paid',1,'2017-03-27 05:57:47'),(12,1,'Paid','Paid',1,'2017-03-27 07:20:10'),(13,1,'Paid','Paid',1,'2017-03-27 07:23:42'),(14,1,'Paid','Pending',1,'2017-03-27 07:25:00'),(15,-1,'Cancel','Pending',1,'2017-03-27 07:25:50');
/*!40000 ALTER TABLE `cash_orders` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `items`
--

DROP TABLE IF EXISTS `items`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `items` (
  `id` int(11) NOT NULL AUTO_INCREMENT,
  `name` varchar(45) NOT NULL,
  `price` float DEFAULT NULL,
  PRIMARY KEY (`id`),
  UNIQUE KEY `id_UNIQUE` (`id`)
) ENGINE=InnoDB AUTO_INCREMENT=3 DEFAULT CHARSET=latin1;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `items`
--

LOCK TABLES `items` WRITE;
/*!40000 ALTER TABLE `items` DISABLE KEYS */;
INSERT INTO `items` VALUES (1,'m4a1',20),(2,'m700',30);
/*!40000 ALTER TABLE `items` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `orders`
--

DROP TABLE IF EXISTS `orders`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `orders` (
  `id` int(6) unsigned NOT NULL AUTO_INCREMENT,
  `user_id` varchar(30) NOT NULL,
  `item_id` int(11) DEFAULT NULL,
  `reg_date` timestamp NOT NULL DEFAULT CURRENT_TIMESTAMP ON UPDATE CURRENT_TIMESTAMP,
  `order_status` enum('Pending','Paid','Cancel') NOT NULL,
  `pingback_status` enum('Pending','Cancel','UnderReview','Paid') NOT NULL,
  PRIMARY KEY (`id`)
) ENGINE=InnoDB AUTO_INCREMENT=118 DEFAULT CHARSET=utf8;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `orders`
--

LOCK TABLES `orders` WRITE;
/*!40000 ALTER TABLE `orders` DISABLE KEYS */;
INSERT INTO `orders` VALUES (76,'1',1,'2017-03-23 05:27:18','Paid','Paid'),(77,'1',1,'2017-03-23 05:27:42','Paid','Paid'),(84,'1',1,'2017-03-23 11:34:35','Pending','Pending'),(85,'1',1,'2017-03-23 11:36:02','Pending','Pending'),(86,'1',1,'2017-03-23 11:38:19','Paid','Paid'),(87,'1',1,'2017-03-23 11:40:14','Paid','Paid'),(88,'1',1,'2017-03-23 11:42:02','Pending','Pending'),(89,'1',1,'2017-03-23 11:45:29','Paid','Paid'),(90,'1',1,'2017-03-24 03:00:16','Paid','Paid'),(91,'1',1,'2017-03-24 05:08:33','Pending','Pending'),(92,'1',1,'2017-03-24 05:10:09','Pending','Pending'),(93,'1',1,'2017-03-24 05:13:06','Pending','Pending'),(94,'1',1,'2017-03-24 05:15:30','Pending','Pending'),(95,'1',1,'2017-03-24 05:15:48','Pending','Pending'),(96,'1',1,'2017-03-24 05:16:54','Pending','Pending'),(97,'1',1,'2017-03-24 06:01:46','Pending','Pending'),(98,'1',1,'2017-03-24 07:27:40','Pending','Pending'),(99,'1',1,'2017-03-24 11:52:41','Paid','Paid'),(100,'1',1,'2017-03-27 03:26:15','Paid','Paid'),(101,'1',1,'2017-03-27 03:40:16','Pending','Pending'),(102,'1',1,'2017-03-27 03:40:28','Pending','Pending'),(103,'1',1,'2017-03-27 03:40:29','Pending','Pending'),(104,'1',1,'2017-03-27 03:42:15','Pending','Pending'),(105,'1',1,'2017-03-27 03:42:16','Pending','Pending'),(106,'1',1,'2017-03-27 03:42:17','Pending','Pending'),(107,'1',1,'2017-03-27 03:42:19','Pending','Pending'),(108,'1',1,'2017-03-27 03:42:19','Pending','Pending'),(109,'1',1,'2017-03-27 03:42:21','Pending','Pending'),(110,'1',1,'2017-03-27 03:42:22','Pending','Pending'),(111,'1',1,'2017-03-27 03:42:22','Pending','Pending'),(112,'1',1,'2017-03-27 03:47:28','Pending','Pending'),(113,'1',1,'2017-03-27 03:47:30','Pending','Pending'),(114,'1',1,'2017-03-27 03:47:31','Pending','Pending'),(115,'1',1,'2017-03-27 03:47:33','Pending','Pending'),(116,'1',1,'2017-03-27 03:47:33','Pending','Pending'),(117,'1',1,'2017-03-27 03:47:37','Pending','Pending');
/*!40000 ALTER TABLE `orders` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `users`
--

DROP TABLE IF EXISTS `users`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `users` (
  `id` int(11) NOT NULL AUTO_INCREMENT,
  PRIMARY KEY (`id`)
) ENGINE=InnoDB AUTO_INCREMENT=2 DEFAULT CHARSET=latin1;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `users`
--

LOCK TABLES `users` WRITE;
/*!40000 ALTER TABLE `users` DISABLE KEYS */;
INSERT INTO `users` VALUES (1);
/*!40000 ALTER TABLE `users` ENABLE KEYS */;
UNLOCK TABLES;
/*!40103 SET TIME_ZONE=@OLD_TIME_ZONE */;

/*!40101 SET SQL_MODE=@OLD_SQL_MODE */;
/*!40014 SET FOREIGN_KEY_CHECKS=@OLD_FOREIGN_KEY_CHECKS */;
/*!40014 SET UNIQUE_CHECKS=@OLD_UNIQUE_CHECKS */;
/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
/*!40111 SET SQL_NOTES=@OLD_SQL_NOTES */;

-- Dump completed on 2017-03-28 14:57:34
