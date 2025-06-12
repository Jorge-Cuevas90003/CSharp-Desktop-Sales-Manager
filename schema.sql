-- phpMyAdmin SQL Dump
-- version 5.1.1
-- https://www.phpmyadmin.net/
--
-- Servidor: 127.0.0.1
-- Tiempo de generación: 12-06-2025 a las 06:22:39
-- Versión del servidor: 10.4.20-MariaDB
-- Versión de PHP: 8.0.9

SET SQL_MODE = "NO_AUTO_VALUE_ON_ZERO";
START TRANSACTION;
SET time_zone = "+00:00";


/*!40101 SET @OLD_CHARACTER_SET_CLIENT=@@CHARACTER_SET_CLIENT */;
/*!40101 SET @OLD_CHARACTER_SET_RESULTS=@@CHARACTER_SET_RESULTS */;
/*!40101 SET @OLD_COLLATION_CONNECTION=@@COLLATION_CONNECTION */;
/*!40101 SET NAMES utf8mb4 */;

--
-- Base de datos: `prueba1`
--

-- --------------------------------------------------------

--
-- Estructura de tabla para la tabla `bodega_empresa`
--

CREATE TABLE `bodega_empresa` (
  `Id_Bodega` int(11) NOT NULL,
  `Direccion` varchar(50) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4;

--
-- Volcado de datos para la tabla `bodega_empresa`
--

INSERT INTO `bodega_empresa` (`Id_Bodega`, `Direccion`) VALUES
(1, 'Zona 6 15avenida 10-2');

-- --------------------------------------------------------

--
-- Estructura de tabla para la tabla `cliente`
--

CREATE TABLE `cliente` (
  `Id_Cliente` int(11) NOT NULL,
  `Nombre_Empresa` varchar(50) DEFAULT NULL,
  `Direccion_Empresa` varchar(50) DEFAULT NULL,
  `Telefono` int(11) DEFAULT NULL,
  `Correo` varchar(50) DEFAULT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4;

--
-- Volcado de datos para la tabla `cliente`
--

INSERT INTO `cliente` (`Id_Cliente`, `Nombre_Empresa`, `Direccion_Empresa`, `Telefono`, `Correo`) VALUES
(223311223, 'Grupo DIVECO', 'Zona 2 1avenida 10-1', 22332233, 'Diveco@gmail.com'),
(665544998, 'AMERICA S.A', 'Zona 10 10avenida ', 22993344, 'AMERICASA@hotmail.com'),
(667700998, 'DIFRATTI, S.A.', 'Zona 1 20avenida 10-11', 88990088, 'DIFRATTI@outlook.es'),
(776688653, 'Acerac', 'Zona 11 15 calle 8-1', 55440098, 'AceracGT@outlook.es'),
(887766445, 'Unicomer', 'Zona 1 9-11', 44553344, 'UnicomerGT@outlook.es'),
(887767543, 'GNC', 'Zona 2 15 Calle', 77886655, 'GNC@gmail.com'),
(889900887, 'REPRINSA', 'Zona 2 9avenida', 99887766, 'REPRINSA23@gmail.com'),
(889977665, 'INSEL', 'Zona 15 23avenida', 77668855, 'INSEL09GT@hotmail.com'),
(998833445, 'Payless', 'Zona 9 1-11', 22334422, 'Payless23@hotmail.com'),
(2147483647, 'Novey', 'Zona 10 15avenida 9-11', 33447788, 'NoveyGT@gmail.com');

-- --------------------------------------------------------

--
-- Estructura de tabla para la tabla `productos_ventas`
--

CREATE TABLE `productos_ventas` (
  `Id_Venta` int(11) NOT NULL,
  `Id_productos` varchar(15) NOT NULL,
  `Marca` varchar(150) DEFAULT NULL,
  `Modelo` varchar(150) DEFAULT NULL,
  `Renta_Mensual` varchar(100) DEFAULT NULL,
  `Cantidad` varchar(100) DEFAULT NULL,
  `Total` double(15,2) DEFAULT NULL,
  `Nit` int(11) NOT NULL,
  `fecha` datetime DEFAULT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4;

--
-- Volcado de datos para la tabla `productos_ventas`
--

INSERT INTO `productos_ventas` (`Id_Venta`, `Id_productos`, `Marca`, `Modelo`, `Renta_Mensual`, `Cantidad`, `Total`, `Nit`, `fecha`) VALUES
(1, '2;3', 'Motorola;Motorola', 'DEP™500e;MOTOTRBO™ ION', '250;250', '22;22', 11000.00, 665544998, '2021-08-09 15:16:26'),
(2, '3;5', 'Motorola;Motorola', 'MOTOTRBO™ ION;MOTOTRBO™DEP™450', '250;290', '45;45', 24300.00, 667700998, '2021-08-09 15:16:43'),
(3, '3;8', 'Motorola;Motorola', 'MOTOTRBO™ ION;MOTOTRBO™SL8550', '250;365', '33;33', 20295.00, 665544998, '2021-08-09 15:17:35'),
(4, '9', 'MAGNUM', 'KT-300S', '260', '43', 11180.00, 2147483647, '2021-08-09 15:17:50'),
(5, '2;2', 'Motorola;Motorola', 'DEP™500e;DEP™500e', '250;250', '43;43', 21500.00, 2147483647, '2021-08-09 15:18:00'),
(6, '5;2;3', 'Motorola;Motorola;Motorola', 'MOTOTRBO™DEP™450;DEP™500e;MOTOTRBO™ ION', '290;250;250', '43;43;43', 33970.00, 2147483647, '2021-08-09 15:18:14'),
(7, '3;4', 'Motorola;Motorola', 'MOTOTRBO™ ION;MOTOTRBO™SL8550e', '250;290', '12;12', 6480.00, 889900887, '2021-08-09 15:18:31'),
(8, '2;4', 'Motorola;Motorola', 'DEP™500e;MOTOTRBO™SL8550e', '250;290', '22;10', 8052.00, 665544998, '2021-08-09 16:31:30'),
(9, '3', 'Motorola', 'MOTOTRBO™ ION', '250', '30', 6375.00, 776688653, '2021-08-12 16:37:22');

-- --------------------------------------------------------

--
-- Estructura de tabla para la tabla `registro_productos`
--

CREATE TABLE `registro_productos` (
  `Id_producto_ingresado` int(11) NOT NULL,
  `Marca` varchar(50) NOT NULL,
  `Modelo` varchar(50) DEFAULT NULL,
  `PrecioU` double(15,4) DEFAULT NULL,
  `cantidad` int(11) NOT NULL,
  `precioTotal` double(15,4) NOT NULL,
  `Renta_Mensual` double(15,4) NOT NULL,
  `Proveedor` varchar(40) NOT NULL,
  `Bodega` int(11) NOT NULL,
  `Descripcion` varchar(500) DEFAULT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4;

--
-- Volcado de datos para la tabla `registro_productos`
--

INSERT INTO `registro_productos` (`Id_producto_ingresado`, `Marca`, `Modelo`, `PrecioU`, `cantidad`, `precioTotal`, `Renta_Mensual`, `Proveedor`, `Bodega`, `Descripcion`) VALUES
(2, 'Motorola', 'DEP™500e', 200.0000, 4827, 1000000.0000, 250.0000, 'Motorola S.A', 1, 'MOTOTRBO Ion reúne el reconocido rendimiento PTT, un ecosistema de aplicaciones abierto en la plataforma Android y acceso a la tecnología unificada de Motorola Solutions, que incluye análisis y seguridad de video y la mejor seguridad de red de su clase. Con MOTOTRBO Ion, los equipos permanecen conectados a través de redes y dispositivos.'),
(3, 'Motorola', 'MOTOTRBO™ ION', 300.0000, 4815, 1500000.0000, 250.0000, 'MotoSolutions', 1, 'MOTOTRBO Ion reúne el reconocido rendimiento PTT, un ecosistema de aplicaciones abierto en la plataforma Android y acceso a la tecnología unificada de Motorola Solutions, que incluye análisis y seguridad de video y la mejor seguridad de red de su clase. Con MOTOTRBO Ion, los equipos permanecen conectados a través de redes y dispositivos.'),
(4, 'Motorola', 'MOTOTRBO™SL8550e', 360.0000, 4978, 1800000.0000, 290.0000, 'MotoSolutions', 1, 'MOTOTRBO™ SL 8550e es un radio portátil liviano y de estándar DMR que lo conecta con la sofisticación. De bolsillo y con un perfil refinado, los radios cuentan con teclado completo y pantalla color de cinco líneas con programas de pantalla personalizables. '),
(5, 'Motorola', 'MOTOTRBO™DEP™450', 240.0000, 4912, 1200000.0000, 290.0000, 'Motorola S.A', 1, 'DEP 450 analógico le brinda muy buenas comunicaciones de voz, con una ruta hacia las comunicaciones de voz digitales mas nítidas y claras cuando usted esté listo. Todo lo que necesitará es una sencilla actualización de software para que el mismo radio le brinde todas las ventajas del mundo Digital.'),
(6, 'Motorola', 'MOTOTRBO™SL500', 250.0000, 5000, 1250000.0000, 300.0000, 'Motorola S.A', 1, 'Equipado con la tecnología más reciente para un óptimo desempeño, el SL500 cuenta con una pantalla LED ActiveView irrompible que opera en conjunto con la funcionalidad de anuncios por voz de MOTOTRBO para iluminar claramente la información importante del radio. Un receptor de comunicaciones ultrasensible y conectividad microUSB proporcionan ciclos de carga y programación del radio más eficientes.'),
(7, 'Motorola', 'DEP 250', 270.0000, 5000, 1350000.0000, 310.0000, 'MotoSolutions', 1, 'El radio MOTOTRBO DEP 250 ofrece los beneficios de la tecnología digital: en modo digital, 40% más de tiempo de conversación, capacidad de doble voz de 12.5kHz de ancho de banda y mejor rendimiento de audio que los equipos analógicos. Su radio MOTOTRBO proporcionará una comunicación de voz más clara en todo el rango de llamadas, eliminando el ruido estático y de fondo en el modelo analógico.'),
(8, 'Motorola', 'MOTOTRBO™SL8550', 300.0000, 4967, 1500000.0000, 365.0000, 'Motorola S.A', 1, 'Con el radio SL8550 MOTOTRBO, hemos logrado reinventar las comunicaciones digitales de dos vías y redefinir todo lo que usted espera de la tecnología de radio. Nuestro extenso y completo portafolio MOTOTRBO de radios móviles y portátiles, repetidores, accesorios, aplicaciones de datos, software y servicios pueden ayudarlo a transformar su empresa y a equipar a su personal con inmejorables comunicaciones discretas de voz y datos en tiempo real para que puedan colaborar como nunca antes.'),
(9, 'MAGNUM', 'KT-300S', 230.0000, 4957, 1150000.0000, 260.0000, 'MAGNUM S.A', 1, ' Carcasa robusta de policarbonato\r\n\r\n- 16 canales programables\r\n\r\n- 2 watts de potencia\r\n\r\n- Linterna LED incorporada (bajo consumo)\r\n\r\n- Frecuencia UHF 400-470 Mhz\r\n\r\n- Sistema de ahorro de energía integrado\r\n\r\n- Batería recargable\r\n\r\n- Cargador de escritorio\r\n\r\n- Antena Standard\r\n\r\n- Clip de cincho flexible\r\n\r\n-Cobertura de 500 a 800 metros'),
(10, 'Motorola', 'MOTOTRBO™DGP™8550EX', 295.0000, 5000, 1475000.0000, 310.0000, 'MotoSolutions', 1, 'Estos portátiles de alto desempeño tienen la más alta clasificación de grupo de explosión de gases ATEX/INMETRO. Son ideales para el trabajo peligroso con mucho ruido, largos turnos, condiciones climáticas y de entorno adversas, incluyendo polvo combustible, productos químicos explosivos, pérdidas de gas, hidrocarbonos inflamables y mucho más. '),
(11, 'Motorola', 'XTS 1500', 150.0000, 5000, 750000.0000, 200.0000, 'MotoSolutions', 1, 'Este radio portátil cumple con los estándares de los Proyectos 16 y 25 y se encuentra disponible en bandas VHF, UHF R1 y UHF R2 de 700/800 MHz. ');

--
-- Índices para tablas volcadas
--

--
-- Indices de la tabla `bodega_empresa`
--
ALTER TABLE `bodega_empresa`
  ADD PRIMARY KEY (`Id_Bodega`);

--
-- Indices de la tabla `cliente`
--
ALTER TABLE `cliente`
  ADD PRIMARY KEY (`Id_Cliente`);

--
-- Indices de la tabla `productos_ventas`
--
ALTER TABLE `productos_ventas`
  ADD PRIMARY KEY (`Id_Venta`),
  ADD KEY `Nit` (`Nit`);

--
-- Indices de la tabla `registro_productos`
--
ALTER TABLE `registro_productos`
  ADD PRIMARY KEY (`Id_producto_ingresado`),
  ADD KEY `Bodega` (`Bodega`);

--
-- AUTO_INCREMENT de las tablas volcadas
--

--
-- AUTO_INCREMENT de la tabla `productos_ventas`
--
ALTER TABLE `productos_ventas`
  MODIFY `Id_Venta` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=10;

--
-- AUTO_INCREMENT de la tabla `registro_productos`
--
ALTER TABLE `registro_productos`
  MODIFY `Id_producto_ingresado` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=12;

--
-- Restricciones para tablas volcadas
--

--
-- Filtros para la tabla `productos_ventas`
--
ALTER TABLE `productos_ventas`
  ADD CONSTRAINT `productos_ventas_ibfk_1` FOREIGN KEY (`Nit`) REFERENCES `cliente` (`Id_Cliente`);

--
-- Filtros para la tabla `registro_productos`
--
ALTER TABLE `registro_productos`
  ADD CONSTRAINT `registro_productos_ibfk_1` FOREIGN KEY (`Bodega`) REFERENCES `bodega_empresa` (`Id_Bodega`) ON DELETE CASCADE;
COMMIT;

/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
