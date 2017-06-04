use master
go
if(DB_ID('AspMvcExam') is not null)
	drop database AspMvcExam
go
create database AspMvcExam
go
use AspMvcExam
go

create table TblUser
(
	uid int identity primary key not null,
	username nvarchar(20) unique not null,
	password nvarchar(20) not null,
	nickname nvarchar(50) not null
)
go

insert into TblUser(username,password,nickname) values('admin','abc123','内置管理员')
insert into TblUser(username,password,nickname) values('u9527','abc123','9527')
go

select * from TblUser
go

create table TblGoods
(
	gid int identity primary key not null,
	operator int foreign key references TblUser(uid) not null,
	gname nvarchar(50) unique not null,
	cost decimal(10,2) check(cost>=0) not null,
	price decimal(10,2) check(price>=0) not null
)
go
 
select * from TblGoods
go