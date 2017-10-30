CREATE DATABASE EmployeeDB
GO
Use EmployeeDB
GO


Create table Employees
(ID int primary key identity,
FirstName nvarchar(60),
LastName nvarchar(60),
Gender nvarchar(50),
Salary int);
insert into Employees values ('Nguyen An','Minh','Nam',123);
insert into Employees values ('Nguyen An','Hong','Nam',400);
insert into Employees values ('Nguyen An','Bac','Nam',500);
insert into Employees values ('Nguyen An','Giang','Nam',400);
insert into Employees values ('Nguyen An','Manh','Nam',600);
insert into Employees values ('Nguyen An','Hang','Nam',700);
insert into Employees values ('Nguyen An','Thuy','Nam',800);

select * from Employees