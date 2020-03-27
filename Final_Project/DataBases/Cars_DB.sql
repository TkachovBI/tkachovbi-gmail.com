drop database `Cars`;
create database Cars;

drop table `Cars`.`CarsTable`;

create table `Cars`.`CarsTable`(	
    `CarNumber` varchar(45) not null primary key,
    `Brand_Name` varchar(45) not null,   
    `VIN` varchar(45) not null,
    `yearsOfCreating` int, 
    `WayCode` int,
    `Price` decimal(15, 2) default 100 not null,
    `DriverId` int
);

select * from `Cars`.`Carstable`;


select * from `drivers`.`driverstable`;














