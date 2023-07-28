-- phpMyAdmin SQL Dump
-- version 5.1.1
-- https://www.phpmyadmin.net/
--
-- Host: 127.0.0.1
-- Generation Time: Jul 20, 2023 at 01:26 AM
-- Server version: 10.4.21-MariaDB
-- PHP Version: 7.3.31

SET SQL_MODE = "NO_AUTO_VALUE_ON_ZERO";
START TRANSACTION;
SET time_zone = "+00:00";


/*!40101 SET @OLD_CHARACTER_SET_CLIENT=@@CHARACTER_SET_CLIENT */;
/*!40101 SET @OLD_CHARACTER_SET_RESULTS=@@CHARACTER_SET_RESULTS */;
/*!40101 SET @OLD_COLLATION_CONNECTION=@@COLLATION_CONNECTION */;
/*!40101 SET NAMES utf8mb4 */;

--
-- Database: `uisrael2023`
--

-- --------------------------------------------------------

--
-- Table structure for table `empleado`
--

CREATE TABLE `empleado` (
  `nombre` varchar(200) NOT NULL,
  `apellido` varchar(200) NOT NULL,
  `cedula` varchar(200) NOT NULL,
  `actcodigo` varchar(200) NOT NULL,
  `genero` varchar(200) NOT NULL,
  `observaciones` varchar(200) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4;

--
-- Dumping data for table `empleado`
--

INSERT INTO `empleado` (`nombre`, `apellido`, `cedula`, `actcodigo`, `genero`, `observaciones`) VALUES
('Jorge', 'Chauca', '3423423424', 'AC002', 'Masculino', 'Nuevo empleado');

-- --------------------------------------------------------

--
-- Table structure for table `jefatura`
--

CREATE TABLE `jefatura` (
  `jefatura` varchar(200) NOT NULL,
  `horario` varchar(200) NOT NULL,
  `observaciones` varchar(200) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4;

--
-- Dumping data for table `jefatura`
--

INSERT INTO `jefatura` (`jefatura`, `horario`, `observaciones`) VALUES
('Cumbaya', 'Noche', 'Turno de la noche'),
('Norte', 'Tarde', 'aaaa'),
('Sur', 'Refuerzo', 'Prioridad al sur');

-- --------------------------------------------------------

--
-- Table structure for table `usuario`
--

CREATE TABLE `usuario` (
  `user` varchar(100) NOT NULL,
  `pass` varchar(100) NOT NULL,
  `correo` varchar(100) NOT NULL,
  `rol` varchar(100) NOT NULL,
  `observaciones` varchar(250) NOT NULL,
  `lat` varchar(200) NOT NULL,
  `lng` varchar(200) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4;

--
-- Dumping data for table `usuario`
--

INSERT INTO `usuario` (`user`, `pass`, `correo`, `rol`, `observaciones`, `lat`, `lng`) VALUES
('edison', '000', 'ej@mba3.com4', 'Administrador', 'usuario d ePrueba', 'lat: -0.1806532, long: -78.4678382', 'lat: -0.1806532, long: -78.4678382');

--
-- Indexes for dumped tables
--

--
-- Indexes for table `empleado`
--
ALTER TABLE `empleado`
  ADD PRIMARY KEY (`actcodigo`);

--
-- Indexes for table `jefatura`
--
ALTER TABLE `jefatura`
  ADD PRIMARY KEY (`jefatura`);

--
-- Indexes for table `usuario`
--
ALTER TABLE `usuario`
  ADD PRIMARY KEY (`user`);
COMMIT;

/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
