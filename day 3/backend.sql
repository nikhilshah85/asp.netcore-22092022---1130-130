create database bankingMangementDB

use bankingMangementDB

create table branchInfo
(
	branchNo int primary key,
	branchName varchar(20),
	branchCity varchar(20)
)


insert into branchInfo values(10,'Hi-Tech','Hyderabad')
insert into branchInfo values(20,'BKC','Mumbai')
insert into branchInfo values(30,'Sipcot','Chennai')
insert into branchInfo values(40,'Koramangala','Bangalore');
insert into branchInfo values(50,'Aundh','Pune');

--------------------------
create table accountsInfo
(
	accNo int primary key,
	accName varchar(20),
	accType varchar(20),
	accBalance int,
	accBranch int,

	constraint fk_branchNo foreign key(accBranch) references branchInfo
)
insert into accountsInfo values(1,'Nikhil','Savings',9000,20)
insert into accountsInfo values(2,'Rahul','Current',19000,10)
insert into accountsInfo values(3,'Mohan','Savings',29000,20)
insert into accountsInfo values(4,'Santosh','Current',39000,20)
insert into accountsInfo values(5,'Sunil','Savings',49000,30)
insert into accountsInfo values(6,'Amay','Savings',59000,20)


select * from accountsInfo