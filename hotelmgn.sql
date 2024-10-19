/*
SQLyog Community v13.1.5  (64 bit)
MySQL - 10.4.28-MariaDB : Database - hotelmgn
*********************************************************************
*/

/*!40101 SET NAMES utf8 */;

/*!40101 SET SQL_MODE=''*/;

/*!40014 SET @OLD_UNIQUE_CHECKS=@@UNIQUE_CHECKS, UNIQUE_CHECKS=0 */;
/*!40014 SET @OLD_FOREIGN_KEY_CHECKS=@@FOREIGN_KEY_CHECKS, FOREIGN_KEY_CHECKS=0 */;
/*!40101 SET @OLD_SQL_MODE=@@SQL_MODE, SQL_MODE='NO_AUTO_VALUE_ON_ZERO' */;
/*!40111 SET @OLD_SQL_NOTES=@@SQL_NOTES, SQL_NOTES=0 */;
CREATE DATABASE /*!32312 IF NOT EXISTS*/`hotelmgn` /*!40100 DEFAULT CHARACTER SET utf8mb4 COLLATE utf8mb4_general_ci */;

USE `hotelmgn`;

/*Table structure for table `tblaccount` */

DROP TABLE IF EXISTS `tblaccount`;

CREATE TABLE `tblaccount` (
  `id` int(11) NOT NULL AUTO_INCREMENT,
  `username` varchar(40) NOT NULL,
  `password` varchar(40) NOT NULL,
  `email` varchar(60) NOT NULL,
  `address` varchar(100) NOT NULL,
  `contactNo` varchar(20) NOT NULL,
  `firstName` varchar(40) NOT NULL,
  `lastName` varchar(40) NOT NULL,
  `birthdate` date NOT NULL,
  `gender` varchar(15) NOT NULL,
  `image` text NOT NULL,
  PRIMARY KEY (`id`)
) ENGINE=InnoDB AUTO_INCREMENT=18 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;

/*Data for the table `tblaccount` */

insert  into `tblaccount`(`id`,`username`,`password`,`email`,`address`,`contactNo`,`firstName`,`lastName`,`birthdate`,`gender`,`image`) values 
(11,'z4ynu','zyot','zyhenzo@gmail.com','Tagum City','09324066029','Zy','Henzo','2003-06-04','Enter your pass','C:\\Users\\jazzy\\Downloads\\5c8b18a1d95fce3c7740bed1a49fd7fd.jpg'),
(12,'zy','zy','zy','zy','zy','zy','zy','2020-02-26','Enter your pass','C:\\Users\\jazzy\\Downloads\\4d84bb59074bf2df411c9cb7f2f0ff2c.jpg'),
(13,'Daijiro','mitty','kyrelleaquino@gmail.com','Tagum City','09156855768','Kyrelle Andre','Aquino','2005-11-15','mitty','C:\\Users\\jazzy\\OneDrive\\Pictures\\pfpo.jpg'),
(14,'kashy','admin','kashtorino@gmail.com','Tagum City','09156855768','Kashmir','Torino','2004-05-14','','C:\\Users\\jazzy\\Downloads\\396532cad95b3bcffcf3159ef34ff3e1.jpg'),
(15,'eim','1234','kashtorino@gmail.com','Tagum City','09156855768','Kashmir','Torino','2004-05-14','Male','C:\\Users\\jazzy\\Downloads\\396532cad95b3bcffcf3159ef34ff3e1.jpg'),
(16,'Soggy Cereal','4321','sostino@gmail.com','Mankilam','09123456789','Kyron','Sostino','2003-04-01','Male','C:\\Users\\jazzy\\Downloads\\4d84bb59074bf2df411c9cb7f2f0ff2c.jpg'),
(17,'Space','kys','kyall@gmail.com','Ky City','09ky','Spacial','Kyron','2024-11-15','Male','C:\\Users\\jazzy\\Downloads\\snowy-mountain-peak-starry-galaxy-majesty-generative-ai.jpg');

/*Table structure for table `tblaccount_addons` */

DROP TABLE IF EXISTS `tblaccount_addons`;

CREATE TABLE `tblaccount_addons` (
  `id` int(11) NOT NULL AUTO_INCREMENT,
  `accountid` int(11) NOT NULL,
  `addonsid` int(11) NOT NULL,
  `addons_description` varchar(200) NOT NULL,
  PRIMARY KEY (`id`),
  KEY `accountid` (`accountid`),
  KEY `addonsid` (`addonsid`),
  CONSTRAINT `tblaccount_addons_ibfk_1` FOREIGN KEY (`accountid`) REFERENCES `tblaccount` (`id`),
  CONSTRAINT `tblaccount_addons_ibfk_2` FOREIGN KEY (`addonsid`) REFERENCES `tbladdons` (`id`)
) ENGINE=InnoDB AUTO_INCREMENT=42 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;

/*Data for the table `tblaccount_addons` */

insert  into `tblaccount_addons`(`id`,`accountid`,`addonsid`,`addons_description`) values 
(25,11,1,'Adds a high-quality foam.'),
(26,13,1,'Adds a high-quality foam.'),
(34,13,6,'Grants access to the hotel\'s gym.'),
(35,13,4,'Adds additional towels.'),
(37,14,2,'Adds an additional thick and comfortable blanket.'),
(38,14,1,'Adds a high-quality foam.'),
(39,14,5,'Grants access to all the pools in the hotel\'s vicinity.'),
(40,17,2,'Adds an additional thick and comfortable blanket.'),
(41,17,6,'Grants access to the hotel\'s gym.');

/*Table structure for table `tblaccount_promo` */

DROP TABLE IF EXISTS `tblaccount_promo`;

CREATE TABLE `tblaccount_promo` (
  `id` int(11) NOT NULL AUTO_INCREMENT,
  `accountid` int(11) NOT NULL,
  `promoid` int(11) NOT NULL,
  `promo_description` varchar(200) NOT NULL,
  PRIMARY KEY (`id`),
  KEY `accountid` (`accountid`),
  KEY `promoid` (`promoid`),
  CONSTRAINT `tblaccount_promo_ibfk_1` FOREIGN KEY (`accountid`) REFERENCES `tblaccount` (`id`),
  CONSTRAINT `tblaccount_promo_ibfk_2` FOREIGN KEY (`promoid`) REFERENCES `tblpromo` (`id`)
) ENGINE=InnoDB AUTO_INCREMENT=19 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;

/*Data for the table `tblaccount_promo` */

insert  into `tblaccount_promo`(`id`,`accountid`,`promoid`,`promo_description`) values 
(1,11,1,'Join us this summer and have free access to the hotel\'s pool.'),
(14,13,2,''),
(15,14,3,''),
(16,14,2,'Book 3 nights during the Christmas season and get a discount and a free breakfast for the whole duration of your stay.'),
(18,17,3,'Stay 2 nights during the Halloween season and get a hefty discount.');

/*Table structure for table `tbladdons` */

DROP TABLE IF EXISTS `tbladdons`;

CREATE TABLE `tbladdons` (
  `id` int(11) NOT NULL AUTO_INCREMENT,
  `name` varchar(60) NOT NULL,
  `price` double NOT NULL,
  `description` varchar(200) NOT NULL,
  PRIMARY KEY (`id`)
) ENGINE=InnoDB AUTO_INCREMENT=9 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;

/*Data for the table `tbladdons` */

insert  into `tbladdons`(`id`,`name`,`price`,`description`) values 
(1,'Extra foam/mattress',30,'Adds a high-quality foam.'),
(2,'Extra blankets',10,'Adds an additional thick and comfortable blanket.'),
(3,'Extra pillows',10,'Adds a pillow.'),
(4,'Extra towels',5,'Adds additional towels.'),
(5,'Pool Access',250,'Grants access to all the pools in the hotel\'s vicinity.'),
(6,'Gym Access',100,'Grants access to the hotel\'s gym.'),
(7,'Extra bathrobes',1500,'Enjoy a plush bathrobe for your comfort while lounging in your room or at the poolside.'),
(8,'Scented Bath Soap',200,'Indulge in our artisanal scented bath soaps made from natural ingredients, perfect for a soothing bathing experience.');

/*Table structure for table `tbladdons_promo` */

DROP TABLE IF EXISTS `tbladdons_promo`;

CREATE TABLE `tbladdons_promo` (
  `id` int(11) NOT NULL AUTO_INCREMENT,
  `accountid` int(11) NOT NULL,
  `addonPrice` double NOT NULL,
  `promoDiscount` double NOT NULL,
  PRIMARY KEY (`id`),
  KEY `promoid` (`addonPrice`),
  KEY `addonsid` (`promoDiscount`),
  KEY `accountid` (`accountid`),
  CONSTRAINT `tbladdons_promo_ibfk_3` FOREIGN KEY (`accountid`) REFERENCES `tblaccount` (`id`)
) ENGINE=InnoDB AUTO_INCREMENT=6 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;

/*Data for the table `tbladdons_promo` */

insert  into `tbladdons_promo`(`id`,`accountid`,`addonPrice`,`promoDiscount`) values 
(2,13,135,20),
(3,14,150,15),
(4,14,290,35),
(5,17,110,15);

/*Table structure for table `tblbooking` */

DROP TABLE IF EXISTS `tblbooking`;

CREATE TABLE `tblbooking` (
  `id` int(11) NOT NULL AUTO_INCREMENT,
  `tenantid` int(11) NOT NULL,
  `bookingStatus` varchar(30) NOT NULL,
  `hotelroomid` int(11) NOT NULL,
  `apid` int(11) NOT NULL,
  `bookingDate` date NOT NULL,
  `numberOfDays` int(11) NOT NULL,
  `totalPrice` double NOT NULL,
  `payment` double NOT NULL,
  PRIMARY KEY (`id`),
  KEY `tenantid` (`tenantid`),
  KEY `hotelroomid` (`hotelroomid`),
  KEY `apid` (`apid`),
  CONSTRAINT `tblbooking_ibfk_1` FOREIGN KEY (`tenantid`) REFERENCES `tbltenant` (`id`),
  CONSTRAINT `tblbooking_ibfk_2` FOREIGN KEY (`hotelroomid`) REFERENCES `tblhotelroom` (`id`),
  CONSTRAINT `tblbooking_ibfk_3` FOREIGN KEY (`apid`) REFERENCES `tbladdons_promo` (`id`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;

/*Data for the table `tblbooking` */

/*Table structure for table `tblhotelroom` */

DROP TABLE IF EXISTS `tblhotelroom`;

CREATE TABLE `tblhotelroom` (
  `id` int(11) NOT NULL AUTO_INCREMENT,
  `roomName` varchar(50) NOT NULL,
  `roomGrade` varchar(30) NOT NULL,
  `roomStatus` varchar(30) NOT NULL,
  `description` varchar(200) NOT NULL,
  `initialPricePerDay` double NOT NULL,
  PRIMARY KEY (`id`)
) ENGINE=InnoDB AUTO_INCREMENT=22 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;

/*Data for the table `tblhotelroom` */

insert  into `tblhotelroom`(`id`,`roomName`,`roomGrade`,`roomStatus`,`description`,`initialPricePerDay`) values 
(1,'D100','Deluxe Room','','Standard luxury room with upscale décor, modern amenities, and often a city or garden view.',4000),
(2,'D101','Deluxe Room','','Standard luxury room with upscale décor, modern amenities, and often a city or garden view.',4000),
(3,'D102','Deluxe Room','','Standard luxury room with upscale décor, modern amenities, and often a city or garden view.',4000),
(4,'D103','Deluxe Room','','Standard luxury room with upscale décor, modern amenities, and often a city or garden view.',4000),
(5,'P200','Premier Room','','A step up from the Deluxe Room, usually featuring better views and more space.',6500),
(6,'P201','Premier Room','','A step up from the Deluxe Room, usually featuring better views and more space.',6500),
(7,'P202','Premier Room','','A step up from the Deluxe Room, usually featuring better views and more space.',6500),
(8,'P203','Premier Room','','A step up from the Deluxe Room, usually featuring better views and more space.',6500),
(9,'J300','Junior Suite','','Spacious room with a separate sitting area, but not necessarily a fully divided space. Ideal for guests seeking a bit more comfort.',9000),
(10,'J301','Junior Suite','','Spacious room with a separate sitting area, but not necessarily a fully divided space. Ideal for guests seeking a bit more comfort.',9000),
(11,'J302','Junior Suite','','Spacious room with a separate sitting area, but not necessarily a fully divided space. Ideal for guests seeking a bit more comfort.',9000),
(12,'J303','Junior Suite','','Spacious room with a separate sitting area, but not necessarily a fully divided space. Ideal for guests seeking a bit more comfort.',9000),
(13,'E400','Executive Suite','','Larger than the Junior Suite with a fully separate living room and bedroom, often used by business travelers or families.',15000),
(14,'E401','Executive Suite','','Larger than the Junior Suite with a fully separate living room and bedroom, often used by business travelers or families.',15000),
(15,'E402','Executive Suite','','Larger than the Junior Suite with a fully separate living room and bedroom, often used by business travelers or families.',15000),
(16,'E403','Executive Suite','','Larger than the Junior Suite with a fully separate living room and bedroom, often used by business travelers or families.',15000),
(17,'R500','Royal Suite','','The pinnacle of luxury, often with multiple rooms, private dining areas, and sometimes private pools or terraces. This suite is usually reserved for VIP guests.',35000),
(18,'R501','Royal Suite','','The pinnacle of luxury, often with multiple rooms, private dining areas, and sometimes private pools or terraces. This suite is usually reserved for VIP guests.',35000),
(19,'R502','Royal Suite','','The pinnacle of luxury, often with multiple rooms, private dining areas, and sometimes private pools or terraces. This suite is usually reserved for VIP guests.',35000),
(20,'I600','Imperial Suite','','Located on the top two floors, offering the best views and sometimes featuring exclusive facilities like a private terrace or pool.',60000),
(21,'I700','Imperial Suite','','Located on the top two floors, offering the best views and sometimes featuring exclusive facilities like a private terrace or pool.',60000);

/*Table structure for table `tblpersonnel` */

DROP TABLE IF EXISTS `tblpersonnel`;

CREATE TABLE `tblpersonnel` (
  `id` int(11) NOT NULL AUTO_INCREMENT,
  `accountid` int(11) NOT NULL,
  `position` varchar(30) NOT NULL,
  `workShift` varchar(45) NOT NULL,
  `workName` varchar(45) NOT NULL,
  PRIMARY KEY (`id`),
  KEY `accountid` (`accountid`),
  CONSTRAINT `tblpersonnel_ibfk_1` FOREIGN KEY (`accountid`) REFERENCES `tblaccount` (`id`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;

/*Data for the table `tblpersonnel` */

/*Table structure for table `tblpromo` */

DROP TABLE IF EXISTS `tblpromo`;

CREATE TABLE `tblpromo` (
  `id` int(11) NOT NULL AUTO_INCREMENT,
  `promoName` varchar(50) NOT NULL,
  `description` varchar(200) NOT NULL,
  `percentageDiscount` double NOT NULL,
  `dateStart` date NOT NULL,
  `dateExpiry` date NOT NULL,
  PRIMARY KEY (`id`)
) ENGINE=InnoDB AUTO_INCREMENT=10 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;

/*Data for the table `tblpromo` */

insert  into `tblpromo`(`id`,`promoName`,`description`,`percentageDiscount`,`dateStart`,`dateExpiry`) values 
(1,'Summer Pool Paradise - Summer Season Promo','Join us this summer and have free access to the hotel\'s pool.',0,'2024-06-01','2024-08-31'),
(2,'Merry Stays & Cozy Nights - Christmas Eve Deal','Book 3 nights during the Christmas season and get a discount and a free breakfast for the whole duration of your stay.',20,'2024-12-01','2024-12-30'),
(3,'Spooktacular Staycation - Halloween Spooky Deal','Stay 2 nights during the Halloween season and get a hefty discount.',15,'2024-11-01','2024-11-30'),
(4,'Work Hard, Relax Harder - Labor Day Deal','Celebrate Labor Day by rewarding hard-working guests with a special discounted stay package.',20,'2024-04-27','2024-05-03'),
(5,'Enchanted Evenings - Valentines Day Deal','Enjoy a cozy-night in with a romantic partner and feel the love with this discount.',20,'2024-02-10','2024-02-17'),
(6,'Birthday Bliss Staycation - Birthday Deal','Celebrate in style with a luxurious stay and enjoy the discount.',15,'0000-00-00','0000-00-00'),
(7,'New Year, New Staycation - New Year\'s Eve Deal','Celebrate the start of the year with a relaxing retreat. Enjoy festive decorations, special New Year\'s Eve dining, and a complimentary champagne toast at midnight.',20,'2024-12-31','2025-01-03'),
(8,'Thankful Family Staycation - Thanksgiving Deal','Give thanks and enjoy a warm and welcoming holiday experience with a special Thanksgiving dinner included with your stay.',15,'2024-11-21','2024-11-30'),
(9,'Leap into Spring - Spring Season Promo','',0,'0000-00-00','0000-00-00');

/*Table structure for table `tblreservation` */

DROP TABLE IF EXISTS `tblreservation`;

CREATE TABLE `tblreservation` (
  `id` int(11) NOT NULL AUTO_INCREMENT,
  `accountid` int(11) NOT NULL,
  `roomGrade` varchar(30) NOT NULL,
  `checkInDate` date NOT NULL,
  `checkOutDate` date NOT NULL,
  `totalDays` int(11) NOT NULL,
  `estimatedAmount` double NOT NULL,
  `reservationStatus` varchar(50) NOT NULL,
  PRIMARY KEY (`id`),
  KEY `accountid` (`accountid`),
  CONSTRAINT `tblreservation_ibfk_1` FOREIGN KEY (`accountid`) REFERENCES `tblaccount` (`id`)
) ENGINE=InnoDB AUTO_INCREMENT=6 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;

/*Data for the table `tblreservation` */

insert  into `tblreservation`(`id`,`accountid`,`roomGrade`,`checkInDate`,`checkOutDate`,`totalDays`,`estimatedAmount`,`reservationStatus`) values 
(2,14,'Imperial Suite','2024-11-14','2024-11-16',2,120000,'For Approval'),
(3,14,'Imperial Suite','2024-11-14','2024-11-16',2,120000,'For Approval'),
(4,14,'Royal Suite','2024-12-01','2024-12-31',30,1050000,'For Approval'),
(5,14,'Royal Suite','2025-05-14','2024-10-20',6,210000,'For Approval');

/*Table structure for table `tbltenant` */

DROP TABLE IF EXISTS `tbltenant`;

CREATE TABLE `tbltenant` (
  `id` int(11) NOT NULL AUTO_INCREMENT,
  `accountid` int(11) NOT NULL,
  `membership` varchar(50) DEFAULT NULL,
  PRIMARY KEY (`id`),
  KEY `accountid` (`accountid`),
  CONSTRAINT `tbltenant_ibfk_1` FOREIGN KEY (`accountid`) REFERENCES `tblaccount` (`id`)
) ENGINE=InnoDB AUTO_INCREMENT=10 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;

/*Data for the table `tbltenant` */

insert  into `tbltenant`(`id`,`accountid`,`membership`) values 
(4,11,'Normal'),
(5,13,'Normal'),
(6,14,'Normal'),
(7,15,'Normal'),
(8,16,'Normal'),
(9,17,'Normal');

/* Procedure structure for procedure `procAccountLogIn` */

/*!50003 DROP PROCEDURE IF EXISTS  `procAccountLogIn` */;

DELIMITER $$

/*!50003 CREATE DEFINER=`root`@`localhost` PROCEDURE `procAccountLogIn`(p_username varchar(45),
						p_password varchar(45))
BEGIN
		select * from view_allaccount where username = p_username and password = p_password;
	END */$$
DELIMITER ;

/* Procedure structure for procedure `procAddAccount` */

/*!50003 DROP PROCEDURE IF EXISTS  `procAddAccount` */;

DELIMITER $$

/*!50003 CREATE DEFINER=`root`@`localhost` PROCEDURE `procAddAccount`(p_username varchar(40),
					p_password varchar(40),
					p_email varchar(60),
					p_address varchar(100),
					p_firstName varchar(40),
					p_lastName varchar(40),
					p_contactNo varchar(15),
					p_birthdate date,
					p_gender varchar(15),
					p_image text)
BEGIN
		insert into hotelmgn.tblaccount	(username,
						password,
						email,
						address,
						firstName,
						lastName,
						contactNo,
						birthdate,
						gender,
						image)
					values	(p_username,
						p_password,
						p_email,
						p_address,
						p_firstName,
						p_lastName,
						p_contactNo,
						p_birthdate,
						p_gender,
						p_image);
	END */$$
DELIMITER ;

/* Procedure structure for procedure `procAddAccountAddons` */

/*!50003 DROP PROCEDURE IF EXISTS  `procAddAccountAddons` */;

DELIMITER $$

/*!50003 CREATE DEFINER=`root`@`localhost` PROCEDURE `procAddAccountAddons`(
						p_accountid int,
						p_addonsid int,
						p_addons_description varchar(200))
BEGIN
		insert into hotelmgn.tblaccount_addons (
							accountid,
							addonsid,
							addons_description)
						values (
							p_accountid,
							p_addonsid,
							p_addons_description);
	END */$$
DELIMITER ;

/* Procedure structure for procedure `procAddAccountPromo` */

/*!50003 DROP PROCEDURE IF EXISTS  `procAddAccountPromo` */;

DELIMITER $$

/*!50003 CREATE DEFINER=`root`@`localhost` PROCEDURE `procAddAccountPromo`(
						p_accountid int,
						p_promoid int,
						p_promo_description varchar(200))
BEGIN
		insert into hotelmgn.tblaccount_promo (
							accountid,
							promoid,
							promo_description)
						values (
							p_accountid,
							p_promoid,
							p_promo_description);
	END */$$
DELIMITER ;

/* Procedure structure for procedure `procAddAddons` */

/*!50003 DROP PROCEDURE IF EXISTS  `procAddAddons` */;

DELIMITER $$

/*!50003 CREATE DEFINER=`root`@`localhost` PROCEDURE `procAddAddons`(p_name varchar(60),
					p_price double,
					p_description varchar(200))
BEGIN
		insert into hotelmgn.tbladdons	(name,
						price,
						description)
					values	(p_name,
						p_price,
						p_description);
	END */$$
DELIMITER ;

/* Procedure structure for procedure `procAddAddons_Promo` */

/*!50003 DROP PROCEDURE IF EXISTS  `procAddAddons_Promo` */;

DELIMITER $$

/*!50003 CREATE DEFINER=`root`@`localhost` PROCEDURE `procAddAddons_Promo`(p_accountid int,
								p_addonPrice double,
								p_promoDiscount double)
BEGIN
		insert into hotelmgn.tbladdons_promo	(accountid,
							addonPrice,
							promoDiscount)
						values	(p_accountid,
							p_addonPrice,
							p_promoDiscount);
	END */$$
DELIMITER ;

/* Procedure structure for procedure `procAddBooking` */

/*!50003 DROP PROCEDURE IF EXISTS  `procAddBooking` */;

DELIMITER $$

/*!50003 CREATE DEFINER=`root`@`localhost` PROCEDURE `procAddBooking`(p_tenantid int,
					p_bookingStatus varchar(30),
					p_hotelroomid int,
					p_apid int,
					p_bookingDate date,
					p_numberOfDays int,
					p_totalPrice double,
					p_payment double)
BEGIN
		insert into hotelmgn.tblbooking	(tenantid,
						bookingStatus,
						hotelroomid,
						apid,
						bookingDate,
						numberOfDays,
						totalPrice,
						payment)
					values	(p_tenantid,
						p_bookingStatus,
						p_hotelroomid,
						p_apid,
						p_bookingDate,
						p_numberOfDays,
						p_totalPrice,
						p_payment);
	END */$$
DELIMITER ;

/* Procedure structure for procedure `procAddHotelRoom` */

/*!50003 DROP PROCEDURE IF EXISTS  `procAddHotelRoom` */;

DELIMITER $$

/*!50003 CREATE DEFINER=`root`@`localhost` PROCEDURE `procAddHotelRoom`(p_roomName varchar(50),
					p_roomGrade varchar(30),
					p_roomStatus varchar(30),
					p_hotelid int,
					p_description varchar(200),
					p_initialPricePerDay double)
BEGIN
		insert into hotelmgn.tblhotelroom	(roomName,
							roomGrade,
							roomStatus,
							hotelid,
							description,
							initialPricePerDay)
						values	(p_roomName,
							p_roomGrade,
							p_roomStatus,
							p_hotelid,
							p_description,
							p_initialPricePerDay);
	END */$$
DELIMITER ;

/* Procedure structure for procedure `procAddPersonnel` */

/*!50003 DROP PROCEDURE IF EXISTS  `procAddPersonnel` */;

DELIMITER $$

/*!50003 CREATE DEFINER=`root`@`localhost` PROCEDURE `procAddPersonnel`(p_accountid int,
					p_position varchar(30),
					p_workShift varchar(45),
					p_workName varchar(45))
BEGIN
		insert into hotelmgn.tblpersonnel	(accountid,
							position,
							workShift,
							workName)
						values	(p_accountid,
							p_position,
							p_workShift,
							p_workNam);
	END */$$
DELIMITER ;

/* Procedure structure for procedure `procAddPromo` */

/*!50003 DROP PROCEDURE IF EXISTS  `procAddPromo` */;

DELIMITER $$

/*!50003 CREATE DEFINER=`root`@`localhost` PROCEDURE `procAddPromo`(p_promoName varchar(50),
					p_description varchar(200),
					p_percentageDiscount double,
					p_dateStart date,
					p_dateExpiry date)
BEGIN
		insert into hotelmgn.tblpromo	(promoName,
						description,
						percentageDiscount,
						dateStart,
						dateExpiry)
					values	(p_promoName,
						p_description,
						p_percentageDiscount,
						p_dateStart,
						p_dateExpiry);
	END */$$
DELIMITER ;

/* Procedure structure for procedure `procAddReservation` */

/*!50003 DROP PROCEDURE IF EXISTS  `procAddReservation` */;

DELIMITER $$

/*!50003 CREATE DEFINER=`root`@`localhost` PROCEDURE `procAddReservation`(p_accountid int,
						p_roomGrade varchar(30),
						p_checkInDate date,
						p_checkOutDate date,
						p_totalDays int,
						p_estimatedAmount double)
BEGIN
		insert into hotelmgn.tblreservation	(accountid,
							roomGrade,
							checkInDate,
							checkOutDate,
							totalDays,
							estimatedAmount,
							reservationStatus)
						values	(p_accountid,
							p_roomGrade,
							p_checkInDate,
							p_checkOutDate,
							p_totalDays,
							p_estimatedAmount,
							"For Approval");
	END */$$
DELIMITER ;

/* Procedure structure for procedure `procAddTenant` */

/*!50003 DROP PROCEDURE IF EXISTS  `procAddTenant` */;

DELIMITER $$

/*!50003 CREATE DEFINER=`root`@`localhost` PROCEDURE `procAddTenant`(p_accountid int,
					p_membership varchar(50))
BEGIN
		insert into hotelmgn.tbltenant	(accountid,
						membership)
					values	(p_accountid,
						p_membership);
	END */$$
DELIMITER ;

/* Procedure structure for procedure `procCheckTenant` */

/*!50003 DROP PROCEDURE IF EXISTS  `procCheckTenant` */;

DELIMITER $$

/*!50003 CREATE DEFINER=`root`@`localhost` PROCEDURE `procCheckTenant`(p_id int)
BEGIN
		select * from tblaccount acc join
				tbltenant tenant 
			on acc.id = tenant.accountid
			where acc.id = p_id;
	END */$$
DELIMITER ;

/* Procedure structure for procedure `procDeleteAccount` */

/*!50003 DROP PROCEDURE IF EXISTS  `procDeleteAccount` */;

DELIMITER $$

/*!50003 CREATE DEFINER=`root`@`localhost` PROCEDURE `procDeleteAccount`(p_id int)
BEGIN
		delete from hotelmgn.tblaccount where id = p_id;
	END */$$
DELIMITER ;

/* Procedure structure for procedure `procDeleteAccountAddons` */

/*!50003 DROP PROCEDURE IF EXISTS  `procDeleteAccountAddons` */;

DELIMITER $$

/*!50003 CREATE DEFINER=`root`@`localhost` PROCEDURE `procDeleteAccountAddons`(p_id int)
BEGIN
		delete from tblaccount_addons where id = p_id;
	END */$$
DELIMITER ;

/* Procedure structure for procedure `procDeleteAccountPromo` */

/*!50003 DROP PROCEDURE IF EXISTS  `procDeleteAccountPromo` */;

DELIMITER $$

/*!50003 CREATE DEFINER=`root`@`localhost` PROCEDURE `procDeleteAccountPromo`(p_id int)
BEGIN
		delete from tblaccount_promo where id = p_id;
	END */$$
DELIMITER ;

/* Procedure structure for procedure `procDeleteAddons` */

/*!50003 DROP PROCEDURE IF EXISTS  `procDeleteAddons` */;

DELIMITER $$

/*!50003 CREATE DEFINER=`root`@`localhost` PROCEDURE `procDeleteAddons`(p_id int)
BEGIN
		delete from hotelmgn.tbladdons where id = p_id;
	END */$$
DELIMITER ;

/* Procedure structure for procedure `procDeleteAddons_Promo` */

/*!50003 DROP PROCEDURE IF EXISTS  `procDeleteAddons_Promo` */;

DELIMITER $$

/*!50003 CREATE DEFINER=`root`@`localhost` PROCEDURE `procDeleteAddons_Promo`(p_id int)
BEGIN
		delete from hotelmgn.tbladdons_promo where id = p_id;
	END */$$
DELIMITER ;

/* Procedure structure for procedure `procDeleteBooking` */

/*!50003 DROP PROCEDURE IF EXISTS  `procDeleteBooking` */;

DELIMITER $$

/*!50003 CREATE DEFINER=`root`@`localhost` PROCEDURE `procDeleteBooking`(p_id int)
BEGIN
		delete from hotelmgn.tblbooking where id = p_id;
	END */$$
DELIMITER ;

/* Procedure structure for procedure `procDeleteHotelRoom` */

/*!50003 DROP PROCEDURE IF EXISTS  `procDeleteHotelRoom` */;

DELIMITER $$

/*!50003 CREATE DEFINER=`root`@`localhost` PROCEDURE `procDeleteHotelRoom`(p_id int)
BEGIN
		delete from hotelmgn.tblHotelRoom where id = p_id;
	END */$$
DELIMITER ;

/* Procedure structure for procedure `procDeletePersonnel` */

/*!50003 DROP PROCEDURE IF EXISTS  `procDeletePersonnel` */;

DELIMITER $$

/*!50003 CREATE DEFINER=`root`@`localhost` PROCEDURE `procDeletePersonnel`(p_id int)
BEGIN
		delete from hotelmgn.tblpersonnel where id = p_id;
	END */$$
DELIMITER ;

/* Procedure structure for procedure `procDeletePromo` */

/*!50003 DROP PROCEDURE IF EXISTS  `procDeletePromo` */;

DELIMITER $$

/*!50003 CREATE DEFINER=`root`@`localhost` PROCEDURE `procDeletePromo`(p_id int)
BEGIN
		delete from hotelmgn.tblpromo where id = p_id;
	END */$$
DELIMITER ;

/* Procedure structure for procedure `procDeleteReservation` */

/*!50003 DROP PROCEDURE IF EXISTS  `procDeleteReservation` */;

DELIMITER $$

/*!50003 CREATE DEFINER=`root`@`localhost` PROCEDURE `procDeleteReservation`(p_id int)
BEGIN
		delete from hotelmgn.tblreservation where id = p_id;
	END */$$
DELIMITER ;

/* Procedure structure for procedure `procDeleteTenant` */

/*!50003 DROP PROCEDURE IF EXISTS  `procDeleteTenant` */;

DELIMITER $$

/*!50003 CREATE DEFINER=`root`@`localhost` PROCEDURE `procDeleteTenant`(p_id int)
BEGIN
		delete from hotelmgn.tbltenant where id = p_id;
	END */$$
DELIMITER ;

/* Procedure structure for procedure `procGetAccount` */

/*!50003 DROP PROCEDURE IF EXISTS  `procGetAccount` */;

DELIMITER $$

/*!50003 CREATE DEFINER=`root`@`localhost` PROCEDURE `procGetAccount`(p_id int)
BEGIN
		select * from view_allaccount where id = p_id;
	END */$$
DELIMITER ;

/* Procedure structure for procedure `procGetAccountAddons` */

/*!50003 DROP PROCEDURE IF EXISTS  `procGetAccountAddons` */;

DELIMITER $$

/*!50003 CREATE DEFINER=`root`@`localhost` PROCEDURE `procGetAccountAddons`(p_id int)
BEGIN
		SELECT 	aa.id as "ID",
			acc.username AS "USERNAME",
			addons.name AS "ADDON NAME",
			addons.price as "ADDON PRICE",
			addons.description AS "DESCRIPTION"
				FROM tblaccount acc 
				JOIN tblaccount_addons aa 
				ON acc.id = aa.accountid 
				JOIN tbladdons addons 
				ON aa.addonsid = addons.id
				WHERE acc.id = p_id; 
	END */$$
DELIMITER ;

/* Procedure structure for procedure `procGetAccountPromo` */

/*!50003 DROP PROCEDURE IF EXISTS  `procGetAccountPromo` */;

DELIMITER $$

/*!50003 CREATE DEFINER=`root`@`localhost` PROCEDURE `procGetAccountPromo`(p_id int)
BEGIN
		SELECT 	ap.id AS "ID",
			acc.username AS "USERNAME",
			promo.promoName AS "PROMO NAME",
			promo.percentageDiscount AS "PROMO DISCOUNT",
			promo.description AS "DESCRIPTION"
				FROM tblaccount acc 
				JOIN tblaccount_promo ap 
				ON acc.id = ap.accountid 
				JOIN tblpromo promo
				ON ap.promoid = promo.id
				WHERE acc.id = p_id;
	END */$$
DELIMITER ;

/* Procedure structure for procedure `procGetAddons` */

/*!50003 DROP PROCEDURE IF EXISTS  `procGetAddons` */;

DELIMITER $$

/*!50003 CREATE DEFINER=`root`@`localhost` PROCEDURE `procGetAddons`()
BEGIN
		select * from view_alladdons;
	END */$$
DELIMITER ;

/* Procedure structure for procedure `procGetPromos` */

/*!50003 DROP PROCEDURE IF EXISTS  `procGetPromos` */;

DELIMITER $$

/*!50003 CREATE DEFINER=`root`@`localhost` PROCEDURE `procGetPromos`()
BEGIN
		select * from view_allpromo;
	END */$$
DELIMITER ;

/* Procedure structure for procedure `procGetRoomPrice` */

/*!50003 DROP PROCEDURE IF EXISTS  `procGetRoomPrice` */;

DELIMITER $$

/*!50003 CREATE DEFINER=`root`@`localhost` PROCEDURE `procGetRoomPrice`(p_roomGrade varchar(25))
BEGIN
		select initialPricePerDay from tblhotelroom where roomGrade = p_roomGrade;
	END */$$
DELIMITER ;

/* Procedure structure for procedure `procSearchAddons` */

/*!50003 DROP PROCEDURE IF EXISTS  `procSearchAddons` */;

DELIMITER $$

/*!50003 CREATE DEFINER=`root`@`localhost` PROCEDURE `procSearchAddons`(p_id int)
BEGIN
		select * from view_alladdons where id = p_id;
	END */$$
DELIMITER ;

/* Procedure structure for procedure `procSearchHotelRoom` */

/*!50003 DROP PROCEDURE IF EXISTS  `procSearchHotelRoom` */;

DELIMITER $$

/*!50003 CREATE DEFINER=`root`@`localhost` PROCEDURE `procSearchHotelRoom`(p_roomGrade varchar(25))
BEGIN
		select * from view_allhotelroom where roomGrade = p_roomGrade;
	END */$$
DELIMITER ;

/* Procedure structure for procedure `procSearchPromo` */

/*!50003 DROP PROCEDURE IF EXISTS  `procSearchPromo` */;

DELIMITER $$

/*!50003 CREATE DEFINER=`root`@`localhost` PROCEDURE `procSearchPromo`(p_id int)
BEGIN
		select * from view_allpromo where id = p_id;
	END */$$
DELIMITER ;

/* Procedure structure for procedure `procTotalAddons` */

/*!50003 DROP PROCEDURE IF EXISTS  `procTotalAddons` */;

DELIMITER $$

/*!50003 CREATE DEFINER=`root`@`localhost` PROCEDURE `procTotalAddons`(p_id int)
BEGIN
		select sum(addons.price) aS "TOTAL PRICE"
				FROM tblaccount acc 
				JOIN tblaccount_addons aa 
				ON acc.id = aa.accountid 
				JOIN tbladdons addons 
				ON aa.addonsid = addons.id
				WHERE acc.id = p_id; 
	END */$$
DELIMITER ;

/* Procedure structure for procedure `procTotalDiscount` */

/*!50003 DROP PROCEDURE IF EXISTS  `procTotalDiscount` */;

DELIMITER $$

/*!50003 CREATE DEFINER=`root`@`localhost` PROCEDURE `procTotalDiscount`(p_id int)
BEGIN
		SELECT 	sum(promo.percentageDiscount) as "TOTAL DISCOUNT"
				FROM tblaccount acc 
				JOIN tblaccount_promo ap 
				ON acc.id = ap.accountid 
				JOIN tblpromo promo
				ON ap.promoid = promo.id
				WHERE acc.id = p_id;
	END */$$
DELIMITER ;

/* Procedure structure for procedure `procUpdateAccount` */

/*!50003 DROP PROCEDURE IF EXISTS  `procUpdateAccount` */;

DELIMITER $$

/*!50003 CREATE DEFINER=`root`@`localhost` PROCEDURE `procUpdateAccount`(p_id INT,
					p_username VARCHAR(40),
					p_password VARCHAR(40),
					p_email VARCHAR(60),
					p_address VARCHAR(100),
					p_firstName VARCHAR(40),
					p_lastName VARCHAR(40),
					p_birthdate DATE,
					p_gender VARCHAR(15),
					p_image TEXT,
					p_contactNo VARCHAR(20))
BEGIN
		UPDATE hotelmgn.tblaccount SET  username = p_username,
						PASSWORD = p_password,
						email = p_email,
						address = p_address,
						firstName = p_firstName,
						lastName = p_lastName,
						birthdate = p_birthdate,
						gender = p_gender,
						image = p_image,
						contactNo = p_contactNo
					WHERE	id = p_id;
	END */$$
DELIMITER ;

/* Procedure structure for procedure `procUpdateAddons` */

/*!50003 DROP PROCEDURE IF EXISTS  `procUpdateAddons` */;

DELIMITER $$

/*!50003 CREATE DEFINER=`root`@`localhost` PROCEDURE `procUpdateAddons`(p_id int,
					p_name varchar(60),
					p_price double,
					p_description varchar(200))
BEGIN
		update tbladdons set name = p_name,
				price = p_price,
				description = p_description
			where id = p_id;
	END */$$
DELIMITER ;

/* Procedure structure for procedure `procUpdateBooking` */

/*!50003 DROP PROCEDURE IF EXISTS  `procUpdateBooking` */;

DELIMITER $$

/*!50003 CREATE DEFINER=`root`@`localhost` PROCEDURE `procUpdateBooking`(p_id int,
						p_tenantid int,
						p_bookingStatus varchar(30),
						p_hotelroomid int,
						p_apid int,
						p_bookingDate date,
						p_numberOfDays int,
						p_totalPrice double,
						p_payment double)
BEGIN
		update tblbooking set tenantid = p_tenantid,
					bookingStatus = p_bookingStatus,
					hotelroomid = p_hotelroomid,
					apid = p_apid,
					bookingDate = p_bookingDate,
					numberOfDays = p_numberOfDays,
					totalPrice = p_totalPrice,
					payment = p_payment
			where id = p_id;
	END */$$
DELIMITER ;

/* Procedure structure for procedure `procUpdateHotelRoom` */

/*!50003 DROP PROCEDURE IF EXISTS  `procUpdateHotelRoom` */;

DELIMITER $$

/*!50003 CREATE DEFINER=`root`@`localhost` PROCEDURE `procUpdateHotelRoom`(p_id int,
						p_roomName varchar(50),
						p_roomGrade varchar(30),
						p_roomStatus varchar(30),
						p_hotelid int,
						p_description varchar(200),
						p_initialPricePerDay double)
BEGIN
		update tblhotelroom set roomName = p_roomName,
					roomGrade = p_roomGrade,
					roomStatus = p_roomStatus,
					hotelid = p_hotelid,
					description = p_description,
					initialPricePerDay = p_initialPricePerDay
			where id = p_id;
	END */$$
DELIMITER ;

/* Procedure structure for procedure `procUpdatePersonnel` */

/*!50003 DROP PROCEDURE IF EXISTS  `procUpdatePersonnel` */;

DELIMITER $$

/*!50003 CREATE DEFINER=`root`@`localhost` PROCEDURE `procUpdatePersonnel`(p_id int,
						p_accountid int,
						p_position varchar(30),
						p_workShift varchar(45),
						p_workName varchar(45))
BEGIN
		update tblpersonnel set accountid = p_accountid,
					position = p_postion,
					workShift = p_workShift,
					workName = p_workName
			where id = p_id;
	END */$$
DELIMITER ;

/* Procedure structure for procedure `procUpdatePromo` */

/*!50003 DROP PROCEDURE IF EXISTS  `procUpdatePromo` */;

DELIMITER $$

/*!50003 CREATE DEFINER=`root`@`localhost` PROCEDURE `procUpdatePromo`(p_id int,
					p_promoName varchar(50),
					p_description varchar(200),
					p_percentageDiscount double)
BEGIN
		update tblpromo set promoName = p_promoName,
				description = p_description,
				percentageDiscount = p_percentageDiscount
			where id = p_id;
	END */$$
DELIMITER ;

/* Procedure structure for procedure `procUpdateReservation` */

/*!50003 DROP PROCEDURE IF EXISTS  `procUpdateReservation` */;

DELIMITER $$

/*!50003 CREATE DEFINER=`root`@`localhost` PROCEDURE `procUpdateReservation`(p_id int,
						p_roomGrade VARCHAR(20),
						p_checkInDate DATE,
						p_checkOutDate DATE,
						p_totalDays INT,
						p_estimatedAmount DOUBLE)
BEGIN
		update tblreservation set roomGrade = p_roomGrade,
					checkInDate = p_checkInDate,
					checkOutDate = p_checkOutDate,
					totalDays = p_totalDays,
					estimatedAmount = p_estimatedAmount
			where id = p_id;
	END */$$
DELIMITER ;

/* Procedure structure for procedure `procUpdateTenant` */

/*!50003 DROP PROCEDURE IF EXISTS  `procUpdateTenant` */;

DELIMITER $$

/*!50003 CREATE DEFINER=`root`@`localhost` PROCEDURE `procUpdateTenant`(p_id int,
						p_accountid int,
						p_membership varchar(50))
BEGIN
		update tbltenant set accountid = p_accountid,
					membership = p_membership
			where id = p_id;
	END */$$
DELIMITER ;

/*Table structure for table `view_allaccount` */

DROP TABLE IF EXISTS `view_allaccount`;

/*!50001 DROP VIEW IF EXISTS `view_allaccount` */;
/*!50001 DROP TABLE IF EXISTS `view_allaccount` */;

/*!50001 CREATE TABLE  `view_allaccount`(
 `id` int(11) ,
 `username` varchar(40) ,
 `password` varchar(40) ,
 `email` varchar(60) ,
 `address` varchar(100) ,
 `contactNo` varchar(20) ,
 `firstName` varchar(40) ,
 `lastName` varchar(40) ,
 `birthdate` date ,
 `gender` varchar(15) ,
 `image` text 
)*/;

/*Table structure for table `view_alladdons` */

DROP TABLE IF EXISTS `view_alladdons`;

/*!50001 DROP VIEW IF EXISTS `view_alladdons` */;
/*!50001 DROP TABLE IF EXISTS `view_alladdons` */;

/*!50001 CREATE TABLE  `view_alladdons`(
 `id` int(11) ,
 `name` varchar(60) ,
 `price` double ,
 `description` varchar(200) 
)*/;

/*Table structure for table `view_allbooking` */

DROP TABLE IF EXISTS `view_allbooking`;

/*!50001 DROP VIEW IF EXISTS `view_allbooking` */;
/*!50001 DROP TABLE IF EXISTS `view_allbooking` */;

/*!50001 CREATE TABLE  `view_allbooking`(
 `id` int(11) ,
 `tenantid` int(11) ,
 `bookingStatus` varchar(30) ,
 `hotelroomid` int(11) ,
 `apid` int(11) ,
 `bookingDate` date ,
 `numberOfDays` int(11) ,
 `totalPrice` double ,
 `payment` double 
)*/;

/*Table structure for table `view_allhotelroom` */

DROP TABLE IF EXISTS `view_allhotelroom`;

/*!50001 DROP VIEW IF EXISTS `view_allhotelroom` */;
/*!50001 DROP TABLE IF EXISTS `view_allhotelroom` */;

/*!50001 CREATE TABLE  `view_allhotelroom`(
 `id` int(11) ,
 `roomName` varchar(50) ,
 `roomGrade` varchar(30) ,
 `roomStatus` varchar(30) ,
 `description` varchar(200) ,
 `initialPricePerDay` double 
)*/;

/*Table structure for table `view_allpersonnel` */

DROP TABLE IF EXISTS `view_allpersonnel`;

/*!50001 DROP VIEW IF EXISTS `view_allpersonnel` */;
/*!50001 DROP TABLE IF EXISTS `view_allpersonnel` */;

/*!50001 CREATE TABLE  `view_allpersonnel`(
 `id` int(11) ,
 `accountid` int(11) ,
 `position` varchar(30) ,
 `workShift` varchar(45) ,
 `workName` varchar(45) 
)*/;

/*Table structure for table `view_allpromo` */

DROP TABLE IF EXISTS `view_allpromo`;

/*!50001 DROP VIEW IF EXISTS `view_allpromo` */;
/*!50001 DROP TABLE IF EXISTS `view_allpromo` */;

/*!50001 CREATE TABLE  `view_allpromo`(
 `id` int(11) ,
 `promoName` varchar(50) ,
 `description` varchar(200) ,
 `percentageDiscount` double 
)*/;

/*Table structure for table `view_allreservation` */

DROP TABLE IF EXISTS `view_allreservation`;

/*!50001 DROP VIEW IF EXISTS `view_allreservation` */;
/*!50001 DROP TABLE IF EXISTS `view_allreservation` */;

/*!50001 CREATE TABLE  `view_allreservation`(
 `id` int(11) ,
 `accountid` int(11) ,
 `roomGrade` varchar(30) ,
 `checkInDate` date ,
 `checkOutDate` date ,
 `totalDays` int(11) ,
 `estimatedAmount` double ,
 `reservationStatus` varchar(50) 
)*/;

/*Table structure for table `view_alltenant` */

DROP TABLE IF EXISTS `view_alltenant`;

/*!50001 DROP VIEW IF EXISTS `view_alltenant` */;
/*!50001 DROP TABLE IF EXISTS `view_alltenant` */;

/*!50001 CREATE TABLE  `view_alltenant`(
 `id` int(11) ,
 `accountid` int(11) ,
 `membership` varchar(50) 
)*/;

/*View structure for view view_allaccount */

/*!50001 DROP TABLE IF EXISTS `view_allaccount` */;
/*!50001 DROP VIEW IF EXISTS `view_allaccount` */;

/*!50001 CREATE ALGORITHM=UNDEFINED DEFINER=`root`@`localhost` SQL SECURITY DEFINER VIEW `view_allaccount` AS (select `tblaccount`.`id` AS `id`,`tblaccount`.`username` AS `username`,`tblaccount`.`password` AS `password`,`tblaccount`.`email` AS `email`,`tblaccount`.`address` AS `address`,`tblaccount`.`contactNo` AS `contactNo`,`tblaccount`.`firstName` AS `firstName`,`tblaccount`.`lastName` AS `lastName`,`tblaccount`.`birthdate` AS `birthdate`,`tblaccount`.`gender` AS `gender`,`tblaccount`.`image` AS `image` from `tblaccount`) */;

/*View structure for view view_alladdons */

/*!50001 DROP TABLE IF EXISTS `view_alladdons` */;
/*!50001 DROP VIEW IF EXISTS `view_alladdons` */;

/*!50001 CREATE ALGORITHM=UNDEFINED DEFINER=`root`@`localhost` SQL SECURITY DEFINER VIEW `view_alladdons` AS (select `tbladdons`.`id` AS `id`,`tbladdons`.`name` AS `name`,`tbladdons`.`price` AS `price`,`tbladdons`.`description` AS `description` from `tbladdons`) */;

/*View structure for view view_allbooking */

/*!50001 DROP TABLE IF EXISTS `view_allbooking` */;
/*!50001 DROP VIEW IF EXISTS `view_allbooking` */;

/*!50001 CREATE ALGORITHM=UNDEFINED DEFINER=`root`@`localhost` SQL SECURITY DEFINER VIEW `view_allbooking` AS (select `tblbooking`.`id` AS `id`,`tblbooking`.`tenantid` AS `tenantid`,`tblbooking`.`bookingStatus` AS `bookingStatus`,`tblbooking`.`hotelroomid` AS `hotelroomid`,`tblbooking`.`apid` AS `apid`,`tblbooking`.`bookingDate` AS `bookingDate`,`tblbooking`.`numberOfDays` AS `numberOfDays`,`tblbooking`.`totalPrice` AS `totalPrice`,`tblbooking`.`payment` AS `payment` from `tblbooking`) */;

/*View structure for view view_allhotelroom */

/*!50001 DROP TABLE IF EXISTS `view_allhotelroom` */;
/*!50001 DROP VIEW IF EXISTS `view_allhotelroom` */;

/*!50001 CREATE ALGORITHM=UNDEFINED DEFINER=`root`@`localhost` SQL SECURITY DEFINER VIEW `view_allhotelroom` AS (select `tblhotelroom`.`id` AS `id`,`tblhotelroom`.`roomName` AS `roomName`,`tblhotelroom`.`roomGrade` AS `roomGrade`,`tblhotelroom`.`roomStatus` AS `roomStatus`,`tblhotelroom`.`description` AS `description`,`tblhotelroom`.`initialPricePerDay` AS `initialPricePerDay` from `tblhotelroom`) */;

/*View structure for view view_allpersonnel */

/*!50001 DROP TABLE IF EXISTS `view_allpersonnel` */;
/*!50001 DROP VIEW IF EXISTS `view_allpersonnel` */;

/*!50001 CREATE ALGORITHM=UNDEFINED DEFINER=`root`@`localhost` SQL SECURITY DEFINER VIEW `view_allpersonnel` AS (select `tblpersonnel`.`id` AS `id`,`tblpersonnel`.`accountid` AS `accountid`,`tblpersonnel`.`position` AS `position`,`tblpersonnel`.`workShift` AS `workShift`,`tblpersonnel`.`workName` AS `workName` from `tblpersonnel`) */;

/*View structure for view view_allpromo */

/*!50001 DROP TABLE IF EXISTS `view_allpromo` */;
/*!50001 DROP VIEW IF EXISTS `view_allpromo` */;

/*!50001 CREATE ALGORITHM=UNDEFINED DEFINER=`root`@`localhost` SQL SECURITY DEFINER VIEW `view_allpromo` AS (select `tblpromo`.`id` AS `id`,`tblpromo`.`promoName` AS `promoName`,`tblpromo`.`description` AS `description`,`tblpromo`.`percentageDiscount` AS `percentageDiscount` from `tblpromo`) */;

/*View structure for view view_allreservation */

/*!50001 DROP TABLE IF EXISTS `view_allreservation` */;
/*!50001 DROP VIEW IF EXISTS `view_allreservation` */;

/*!50001 CREATE ALGORITHM=UNDEFINED DEFINER=`root`@`localhost` SQL SECURITY DEFINER VIEW `view_allreservation` AS (select `tblreservation`.`id` AS `id`,`tblreservation`.`accountid` AS `accountid`,`tblreservation`.`roomGrade` AS `roomGrade`,`tblreservation`.`checkInDate` AS `checkInDate`,`tblreservation`.`checkOutDate` AS `checkOutDate`,`tblreservation`.`totalDays` AS `totalDays`,`tblreservation`.`estimatedAmount` AS `estimatedAmount`,`tblreservation`.`reservationStatus` AS `reservationStatus` from `tblreservation`) */;

/*View structure for view view_alltenant */

/*!50001 DROP TABLE IF EXISTS `view_alltenant` */;
/*!50001 DROP VIEW IF EXISTS `view_alltenant` */;

/*!50001 CREATE ALGORITHM=UNDEFINED DEFINER=`root`@`localhost` SQL SECURITY DEFINER VIEW `view_alltenant` AS (select `tbltenant`.`id` AS `id`,`tbltenant`.`accountid` AS `accountid`,`tbltenant`.`membership` AS `membership` from `tbltenant`) */;

/*!40101 SET SQL_MODE=@OLD_SQL_MODE */;
/*!40014 SET FOREIGN_KEY_CHECKS=@OLD_FOREIGN_KEY_CHECKS */;
/*!40014 SET UNIQUE_CHECKS=@OLD_UNIQUE_CHECKS */;
/*!40111 SET SQL_NOTES=@OLD_SQL_NOTES */;
