drop database drivers;
create database drivers;
use drivers;

create table driversTable(
 `id` int not null primary key AUTO_INCREMENT,
 `Name` varchar(45) not null,
 `wayCode` varchar(5),
 `old` int(11) not null,
 `password` varchar(25) not null,
 `timeStart` datetime 
);

select *
from driversTable;
