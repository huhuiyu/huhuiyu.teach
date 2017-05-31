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
	values('���²�','��Ա������')
insert into TblDept(deptName,deptInfo) 
	values('������','���ǳ���Գ')	
insert into TblDept(deptName,deptInfo) 
	values('Ӫ����','���Ǹ��˰������Ӷ�������ͺ��')
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


insert into TblEmployee(deptId,ename,sex,salary) values(10000,'����','m',1000.99)
insert into TblEmployee(deptId,ename,sex,salary) values(10001,'����','f',1111.99)
insert into TblEmployee(deptId,ename,sex,salary) values(10000,'������','f',2020.99)
insert into TblEmployee(deptId,ename,sex,salary) values(10001,'����','f',1090.99)
insert into TblEmployee(deptId,ename,sex,salary) values(10002,'������','m',1000.99)
insert into TblEmployee(deptId,ename,sex,salary) values(10002,'����','m',3400.99)
insert into TblEmployee(deptId,ename,sex,salary) values(10002,'���','m',1000.99)
insert into TblEmployee(deptId,ename,sex,salary) values(10001,'Ҷ����','f',8000.99)
insert into TblEmployee(deptId,ename,sex,salary) values(10000,'������','m',10000.99)
insert into TblEmployee(deptId,ename,sex,salary) values(10000,'������','m',4000.99)
insert into TblEmployee(deptId,ename,sex,salary) values(10000,'��У��','f',10900.99)
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

