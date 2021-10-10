-- --------------------------------------------------------
-- Host:                         127.0.0.1
-- Versión del servidor:         8.0.25 - MySQL Community Server - GPL
-- SO del servidor:              Win64
-- HeidiSQL Versión:             11.2.0.6213
-- --------------------------------------------------------

/*!40101 SET @OLD_CHARACTER_SET_CLIENT=@@CHARACTER_SET_CLIENT */;
/*!40101 SET NAMES utf8 */;
/*!50503 SET NAMES utf8mb4 */;
/*!40014 SET @OLD_FOREIGN_KEY_CHECKS=@@FOREIGN_KEY_CHECKS, FOREIGN_KEY_CHECKS=0 */;
/*!40101 SET @OLD_SQL_MODE=@@SQL_MODE, SQL_MODE='NO_AUTO_VALUE_ON_ZERO' */;
/*!40111 SET @OLD_SQL_NOTES=@@SQL_NOTES, SQL_NOTES=0 */;


-- Volcando estructura de base de datos para controlstock
CREATE DATABASE IF NOT EXISTS `controlstock` /*!40100 DEFAULT CHARACTER SET utf8mb4 COLLATE utf8mb4_spanish_ci */ /*!80016 DEFAULT ENCRYPTION='N' */;
USE `controlstock`;

-- Volcando estructura para tabla controlstock.compras
CREATE TABLE IF NOT EXISTS `compras` (
  `id` int NOT NULL AUTO_INCREMENT,
  `fecha_compra` timestamp NULL DEFAULT CURRENT_TIMESTAMP,
  `souvenir_id` int DEFAULT NULL,
  `cantidad` int DEFAULT NULL,
  PRIMARY KEY (`id`),
  KEY `FK__souvenirs` (`souvenir_id`),
  CONSTRAINT `FK__souvenirs` FOREIGN KEY (`souvenir_id`) REFERENCES `souvenirs` (`id`)
) ENGINE=InnoDB AUTO_INCREMENT=3 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_spanish_ci;

-- Volcando datos para la tabla controlstock.compras: ~0 rows (aproximadamente)
/*!40000 ALTER TABLE `compras` DISABLE KEYS */;
INSERT INTO `compras` (`id`, `fecha_compra`, `souvenir_id`, `cantidad`) VALUES
	(1, '2021-10-10 12:21:55', 3, 2),
	(2, '2021-10-10 20:26:49', 1, 5);
/*!40000 ALTER TABLE `compras` ENABLE KEYS */;

-- Volcando estructura para tabla controlstock.souvenirs
CREATE TABLE IF NOT EXISTS `souvenirs` (
  `id` int NOT NULL AUTO_INCREMENT,
  `nombre` varchar(50) COLLATE utf8mb4_spanish_ci DEFAULT NULL,
  `descripcion` varchar(100) COLLATE utf8mb4_spanish_ci DEFAULT NULL,
  `stock` int DEFAULT NULL,
  `precio` decimal(10,2) DEFAULT NULL,
  `fecha_alta` timestamp NULL DEFAULT CURRENT_TIMESTAMP,
  `activo` tinyint DEFAULT '1',
  PRIMARY KEY (`id`)
) ENGINE=InnoDB AUTO_INCREMENT=6 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_spanish_ci;

-- Volcando datos para la tabla controlstock.souvenirs: ~0 rows (aproximadamente)
/*!40000 ALTER TABLE `souvenirs` DISABLE KEYS */;
INSERT INTO `souvenirs` (`id`, `nombre`, `descripcion`, `stock`, `precio`, `fecha_alta`, `activo`) VALUES
	(1, 'Llavero', 'Un llavero', 5, 100.00, '2021-10-09 21:57:03', 0),
	(2, 'Collar', 'un collar largo', 10, 200.00, '2021-10-10 03:00:30', 1),
	(3, 'figurita', 'una figurita importante', 25, 4050.00, '2021-10-10 03:01:10', 1),
	(4, 'preuba', 'ffsdafdgagdfg', 2, 455.00, '2021-10-10 03:16:00', 1),
	(5, 'souvenir 21', 'es un souvenir raro', 1, 10.00, '2021-10-10 03:17:17', 1);
/*!40000 ALTER TABLE `souvenirs` ENABLE KEYS */;

-- Volcando estructura para tabla controlstock.usuarios
CREATE TABLE IF NOT EXISTS `usuarios` (
  `id` int NOT NULL AUTO_INCREMENT,
  `usuario` varchar(20) COLLATE utf8mb4_spanish_ci DEFAULT NULL,
  `password` varchar(100) COLLATE utf8mb4_spanish_ci DEFAULT NULL,
  `baja` timestamp NULL DEFAULT NULL,
  PRIMARY KEY (`id`)
) ENGINE=InnoDB AUTO_INCREMENT=3 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_spanish_ci;

-- Volcando datos para la tabla controlstock.usuarios: ~0 rows (aproximadamente)
/*!40000 ALTER TABLE `usuarios` DISABLE KEYS */;
INSERT INTO `usuarios` (`id`, `usuario`, `password`, `baja`) VALUES
	(1, 'test', '1234', NULL),
	(2, 'mati', 'matias123', NULL);
/*!40000 ALTER TABLE `usuarios` ENABLE KEYS */;

/*!40101 SET SQL_MODE=IFNULL(@OLD_SQL_MODE, '') */;
/*!40014 SET FOREIGN_KEY_CHECKS=IFNULL(@OLD_FOREIGN_KEY_CHECKS, 1) */;
/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40111 SET SQL_NOTES=IFNULL(@OLD_SQL_NOTES, 1) */;
