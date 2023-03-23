CREATE DATABASE  IF NOT EXISTS `listasdereproduccion` /*!40100 DEFAULT CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci */ /*!80016 DEFAULT ENCRYPTION='N' */;
USE `listasdereproduccion`;
-- MySQL dump 10.13  Distrib 8.0.28, for Win64 (x86_64)
--
-- Host: localhost    Database: listasdereproduccion
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
-- Table structure for table `canciones`
--

DROP TABLE IF EXISTS `canciones`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `canciones` (
  `Id` int NOT NULL AUTO_INCREMENT,
  `Titulo` varchar(60) NOT NULL,
  `Artista` varchar(60) NOT NULL,
  `Duracion` varchar(10) DEFAULT NULL,
  `Genero` varchar(60) NOT NULL,
  `ListaId` int NOT NULL,
  PRIMARY KEY (`Id`),
  KEY `ListaId` (`ListaId`),
  CONSTRAINT `canciones_ibfk_1` FOREIGN KEY (`ListaId`) REFERENCES `listas` (`Id`)
) ENGINE=InnoDB AUTO_INCREMENT=62 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `canciones`
--

LOCK TABLES `canciones` WRITE;
/*!40000 ALTER TABLE `canciones` DISABLE KEYS */;
INSERT INTO `canciones` VALUES (1,'Eye of the Tiger','Survivor','4:05','Rock',1),(2,'Can\'t Hold Us','Macklemore & Ryan Lewis','4:18','Hip Hop',1),(3,'Lose Control','Missy Elliott','3:47','Hip Hop',1),(4,'Remember the Name','Fort Minor','3:50','Hip Hop',1),(5,'Bohemian Rhapsody','Queen','5:55','Rock',2),(6,'Stairway to Heaven','Led Zeppelin','8:02','Rock',2),(7,'Sweet Child o\' Mine','Guns N\' Roses','5:56','Rock',2),(8,'Hotel California','Eagles','6:30','Rock',2),(9,'Ho Hey','The Lumineers','2:43','Indie Folk',3),(10,'Pumped Up Kicks','Foster the People','3:58','Indie Pop',3),(11,'Somebody That I Used to Know','Gotye ft. Kimbra','4:04','Indie Pop',3),(12,'Take Me to Church','Hozier','4:02','Indie Rock',3),(13,'Weightless','Marconi Union','8:09','Ambient',4),(14,'Clair de Lune','Debussy','5:24','Classical',4),(15,'Nocturne in E-flat Major, Op. 9, No. 2','Chopin','4:27','Classical',4),(16,'Moon River','Audrey Hepburn','2:06','Soundtrack',4),(17,'Come and Get Your Love','Redbone','3:27','Rock',5),(18,'Ain\'t No Mountain High Enough','Marvin Gaye, Tammi Terrell','2:29','R&B',5),(19,'Escape (The Piña Colada Song)','Rupert Holmes','4:37','Pop',5),(20,'Moonage Daydream','David Bowie','4:41','Rock',5),(21,'Levels','Avicii','3:22','Electrónica',6),(22,'The Middle','Zedd, Maren Morris, Grey','3:04','Electrónica',6),(23,'I Wanna Dance With Somebody (Who Loves Me)','Whitney Houston','4:51','Pop',6),(24,'Closer','The Chainsmokers ft. Halsey','4:05','Electrónica',6),(25,'Fly Away','Lenny Kravitz','3:41','Rock',7),(26,'Im Gonna Be (500 Miles)','The Proclaimers','3:39','Pop',7),(27,'Take Me Home, Country Roads','John Denver','3:07','Country',7),(28,'Life is a Highway','Tom Cochrane','4:27','Rock',7),(29,'September','Earth, Wind & Fire','3:34','Disco',8),(30,'La Vida Es Un Carnaval','Celia Cruz','4:37','Salsa',8),(31,'Uptown Funk','Mark Ronson ft. Bruno Mars','4:31','Funk',8),(32,'I Like to Move It','Reel 2 Real ft. The Mad Stuntman','3:50','Dance',8),(33,'My Heart Will Go On','Celine Dion','4:40','Pop',9),(34,'I Will Always Love You','Whitney Houston','4:35','Pop',9),(35,'Perfect','Ed Sheeran','4:23','Pop',9),(36,'Thinking Out Loud','Ed Sheeran','4:41','Pop',9),(37,'TED Talks Daily','TED','15:00','Podcast',10),(38,'The Daily','The New York Times','25:00','Podcast',10),(39,'Freakonomics Radio','Stephen Dubner','45:00','Podcast',10),(40,'Serial','Sarah Koenig','35:00','Podcast',10),(41,'Eye of the Tiger','Survivor','4:06','Rock',11),(42,'Don\'t Stop Believin\'','Journey','4:09','Rock',11),(43,'Stronger','Kanye West','5:12','Hip-Hop',11),(44,'Believer','Imagine Dragons','3:24','Pop',11),(45,'Space Oddity','David Bowie','5:14','Rock',12),(46,'Starman','David Bowie','4:13','Rock',12),(47,'Life on Mars?','David Bowie','3:54','Rock',12),(48,'Rocket Man','Elton John','4:41','Pop',12),(49,'Strobe','Deadmau5','10:37','Electronica',13),(50,'Adagio for Strings','Tiesto','7:24','Trance',13),(51,'Flim','Aphex Twin','2:57','Electronica',13),(52,'Computer Love','Kraftwerk','7:14','Electronic',13),(53,'Levitating','Dua Lipa','3:23','Pop',14),(54,'Mood','24kGoldn ft. Iann Dior','2:20','Hip-Hop',14),(55,'Driver\'s License','Olivia Rodrigo','4:02','Pop',14),(56,'Renegade','K Camp','2:12','Hip-Hop',14),(57,'Hakuna Matata','Nathan Lane, Ernie Sabella','3:33','Soundtrack',15),(58,'Circle of Life','Carmen Twillie & Lebo M.','4:51','Soundtrack',15),(59,'Let It Go','Idina Menzel','3:44','Soundtrack',15),(60,'A Whole New World','Brad Kane & Lea Salonga','2:40','Soundtrack',15),(61,'a','aaaaaa','a','aa',17);
/*!40000 ALTER TABLE `canciones` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `listas`
--

DROP TABLE IF EXISTS `listas`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `listas` (
  `Id` int NOT NULL AUTO_INCREMENT,
  `Nombre` varchar(60) NOT NULL,
  `Descripcion` text,
  `FechaCreacion` datetime DEFAULT CURRENT_TIMESTAMP,
  `Creador` varchar(60) DEFAULT NULL,
  PRIMARY KEY (`Id`)
) ENGINE=InnoDB AUTO_INCREMENT=18 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `listas`
--

LOCK TABLES `listas` WRITE;
/*!40000 ALTER TABLE `listas` DISABLE KEYS */;
INSERT INTO `listas` VALUES (1,'Lista para hacer ejercicio','','2023-03-22 08:13:26','Daniel Maldonado'),(2,'Clasicos de Rock','','2023-03-22 08:13:26','Angel Pineda'),(3,'Indie','Lista de musica indie','2023-03-22 08:13:26','Antonio Reyes'),(4,'Musica para dormir','Lista con musica relajante','2023-03-22 08:13:26','Luis Mendes'),(5,'Soundtracks de los Good','Lista con musica que ha salido en peliculas','2023-03-22 08:13:26','Luis Alvares'),(6,'Electrifying Mood','','2023-03-22 08:13:26','Angel Pineda'),(7,'Musica para viajar','','2023-03-22 08:13:26','Luis Suarez'),(8,'Musica bailar','Musica para bailar','2023-03-22 08:13:26','Alfonso Perez'),(9,'Musica de amor','Lista con musica de amor','2023-03-22 08:13:26','America Hernandez'),(10,'Podcasts','Musica perfecta para tus podcasts','2023-03-22 08:13:26','Eduardo Mendoza'),(11,'Motivacion','Musica perfecta para motivarte','2023-03-22 08:13:26','Angel Pineda'),(12,'Viajar a otra dimension','Musica que te hace sentir en otra dimension','2023-03-22 08:13:26','Manuel Perez'),(13,'Musica para programar','','2023-03-22 08:13:26','Cristian'),(14,'Musica de tiktok','','2023-03-22 08:13:26','Abigail'),(15,'Musica de Disney','Lista con canciones de tu infancia','2023-03-22 08:13:26','Pedro'),(17,'asdas','asd','2023-03-22 21:10:54','ass');
/*!40000 ALTER TABLE `listas` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Dumping events for database 'listasdereproduccion'
--

--
-- Dumping routines for database 'listasdereproduccion'
--
/*!50003 DROP PROCEDURE IF EXISTS `spAgregarCancion` */;
/*!50003 SET @saved_cs_client      = @@character_set_client */ ;
/*!50003 SET @saved_cs_results     = @@character_set_results */ ;
/*!50003 SET @saved_col_connection = @@collation_connection */ ;
/*!50003 SET character_set_client  = utf8mb4 */ ;
/*!50003 SET character_set_results = utf8mb4 */ ;
/*!50003 SET collation_connection  = utf8mb4_0900_ai_ci */ ;
/*!50003 SET @saved_sql_mode       = @@sql_mode */ ;
/*!50003 SET sql_mode              = 'STRICT_TRANS_TABLES,NO_ENGINE_SUBSTITUTION' */ ;
DELIMITER ;;
CREATE DEFINER=`root`@`localhost` PROCEDURE `spAgregarCancion`(ptitulo varchar(60) ,partista varchar(60) ,pduracion varchar(10) , pgenero varchar(60), plistaid int)
BEGIN
if(plistaid =null)then
begin
insert into canciones(titulo,artista,duracion,genero,listaid) values (ptitulo,partista,pduracion,pgenero,(select Id from Listas where Nombre = ListaCompleta));

end;
else 
begin
insert into canciones(titulo,artista,duracion,genero,listaid) values (ptitulo,partista,pduracion,pgenero,plistaid);
end ;
end if;
END ;;
DELIMITER ;
/*!50003 SET sql_mode              = @saved_sql_mode */ ;
/*!50003 SET character_set_client  = @saved_cs_client */ ;
/*!50003 SET character_set_results = @saved_cs_results */ ;
/*!50003 SET collation_connection  = @saved_col_connection */ ;
/*!50003 DROP PROCEDURE IF EXISTS `spAgregarLista` */;
/*!50003 SET @saved_cs_client      = @@character_set_client */ ;
/*!50003 SET @saved_cs_results     = @@character_set_results */ ;
/*!50003 SET @saved_col_connection = @@collation_connection */ ;
/*!50003 SET character_set_client  = utf8mb4 */ ;
/*!50003 SET character_set_results = utf8mb4 */ ;
/*!50003 SET collation_connection  = utf8mb4_0900_ai_ci */ ;
/*!50003 SET @saved_sql_mode       = @@sql_mode */ ;
/*!50003 SET sql_mode              = 'STRICT_TRANS_TABLES,NO_ENGINE_SUBSTITUTION' */ ;
DELIMITER ;;
CREATE DEFINER=`root`@`localhost` PROCEDURE `spAgregarLista`(pnombre varchar(60), pdescripcion text, pcreador varchar(60))
BEGIN
insert into Listas(Nombre,Descripcion,Creador) values (pnombre,pdescripcion,pcreador);
END ;;
DELIMITER ;
/*!50003 SET sql_mode              = @saved_sql_mode */ ;
/*!50003 SET character_set_client  = @saved_cs_client */ ;
/*!50003 SET character_set_results = @saved_cs_results */ ;
/*!50003 SET collation_connection  = @saved_col_connection */ ;
/*!50003 DROP PROCEDURE IF EXISTS `spEliminarCancion` */;
/*!50003 SET @saved_cs_client      = @@character_set_client */ ;
/*!50003 SET @saved_cs_results     = @@character_set_results */ ;
/*!50003 SET @saved_col_connection = @@collation_connection */ ;
/*!50003 SET character_set_client  = utf8mb4 */ ;
/*!50003 SET character_set_results = utf8mb4 */ ;
/*!50003 SET collation_connection  = utf8mb4_0900_ai_ci */ ;
/*!50003 SET @saved_sql_mode       = @@sql_mode */ ;
/*!50003 SET sql_mode              = 'STRICT_TRANS_TABLES,NO_ENGINE_SUBSTITUTION' */ ;
DELIMITER ;;
CREATE DEFINER=`root`@`localhost` PROCEDURE `spEliminarCancion`(pid int)
BEGIN
delete from Canciones where id = pid;
END ;;
DELIMITER ;
/*!50003 SET sql_mode              = @saved_sql_mode */ ;
/*!50003 SET character_set_client  = @saved_cs_client */ ;
/*!50003 SET character_set_results = @saved_cs_results */ ;
/*!50003 SET collation_connection  = @saved_col_connection */ ;
/*!50003 DROP PROCEDURE IF EXISTS `spEliminarLista` */;
/*!50003 SET @saved_cs_client      = @@character_set_client */ ;
/*!50003 SET @saved_cs_results     = @@character_set_results */ ;
/*!50003 SET @saved_col_connection = @@collation_connection */ ;
/*!50003 SET character_set_client  = utf8mb4 */ ;
/*!50003 SET character_set_results = utf8mb4 */ ;
/*!50003 SET collation_connection  = utf8mb4_0900_ai_ci */ ;
/*!50003 SET @saved_sql_mode       = @@sql_mode */ ;
/*!50003 SET sql_mode              = 'STRICT_TRANS_TABLES,NO_ENGINE_SUBSTITUTION' */ ;
DELIMITER ;;
CREATE DEFINER=`root`@`localhost` PROCEDURE `spEliminarLista`(pid int)
BEGIN
delete from Listas where id = pid;
END ;;
DELIMITER ;
/*!50003 SET sql_mode              = @saved_sql_mode */ ;
/*!50003 SET character_set_client  = @saved_cs_client */ ;
/*!50003 SET character_set_results = @saved_cs_results */ ;
/*!50003 SET collation_connection  = @saved_col_connection */ ;
/*!40103 SET TIME_ZONE=@OLD_TIME_ZONE */;

/*!40101 SET SQL_MODE=@OLD_SQL_MODE */;
/*!40014 SET FOREIGN_KEY_CHECKS=@OLD_FOREIGN_KEY_CHECKS */;
/*!40014 SET UNIQUE_CHECKS=@OLD_UNIQUE_CHECKS */;
/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
/*!40111 SET SQL_NOTES=@OLD_SQL_NOTES */;

-- Dump completed on 2023-03-22 21:32:51
