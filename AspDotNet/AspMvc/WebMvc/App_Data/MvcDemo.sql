use master
go
if(DB_ID('MvcDemo') is not null)
	drop database MvcDemo
go
create database MvcDemo
go
use MvcDemo
go

create table TblDept
(
	deptId int identity(10000,1) primary key,
	deptName nvarchar(50) unique not null,
	deptInfo nvarchar(200) not null
)
go
insert into TblDept(deptName,deptInfo) 
	values('人事部','人员管理部门')
insert into TblDept(deptName,deptInfo) 
	values('开发部','都是程序猿')	
insert into TblDept(deptName,deptInfo) 
	values('营销部','都是高人啊，梳子都能卖给秃子')
go

select * from TblDept
go

create table TblEmployee
(
	eid int identity(10000,1) primary key,
	deptId int foreign key references TblDept(deptId) not null,
	ename nvarchar(20) not null,
	sex char(1) check(sex in ('m','f')) not null,
	indate datetime default getdate() not null,
	salary decimal(10,2) check(salary>0) not null
)
go


insert into TblEmployee(deptId,ename,sex,salary) values(10000,'张三','m',1000.99)
insert into TblEmployee(deptId,ename,sex,salary) values(10001,'李四','f',1111.99)
insert into TblEmployee(deptId,ename,sex,salary) values(10000,'张三丰','f',2020.99)
insert into TblEmployee(deptId,ename,sex,salary) values(10001,'王五','f',1090.99)
insert into TblEmployee(deptId,ename,sex,salary) values(10002,'李明旺','m',1000.99)
insert into TblEmployee(deptId,ename,sex,salary) values(10002,'龙文','m',3400.99)
insert into TblEmployee(deptId,ename,sex,salary) values(10002,'深井冰','m',1000.99)
insert into TblEmployee(deptId,ename,sex,salary) values(10001,'叶良辰','f',8000.99)
insert into TblEmployee(deptId,ename,sex,salary) values(10000,'王尼马','m',10000.99)
insert into TblEmployee(deptId,ename,sex,salary) values(10000,'王尼美','m',4000.99)
insert into TblEmployee(deptId,ename,sex,salary) values(10000,'熬校长','f',10900.99)
go

select * from TblEmployee
go

select top 5 * from TblEmployee
go

select top 5 * from TblEmployee
where eid not in
(
	select top 5 eid from TblEmployee
)
go

select top 5 * from TblEmployee
where eid not in
(
	select top 10 eid from TblEmployee
)
go

select top 10 * from TblEmployee
where eid not in
(
	select top 10 eid from TblEmployee
)
go

