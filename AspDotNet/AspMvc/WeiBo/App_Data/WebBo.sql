use master
go
if(DB_ID('WeiBo') is not null)
	drop database WeiBo
go
create database WeiBo
go
use WeiBo
go

create table TblUser
(
	uid int identity primary key not null,
	username nvarchar(20) unique not null,
	password nvarchar(20) not null,
	nickname nvarchar(50) not null,
	regDate datetime default getdate() not null
)
go

insert into TblUser(username,password,nickname) values('admin','abc123','内置管理员')
go

select * from TblUser
go

create table TblMessage
(
	mid int identity primary key not null,
	title nvarchar(50) not null,
	content nvarchar(1000) not null,
	uid int foreign key references TblUser(uid),
	created datetime default getdate() not null,
	deleted char(1) default 'n' not null
)
go

insert into TblMessage(title,content,uid) values('欢迎','欢迎使用微博',1)
go

select * from TblMessage
go

create table TblReturn
(
	rid int identity primary key not null,
	mid int foreign key references TblMessage(mid),
	uid int foreign key references TblUser(uid),
	content nvarchar(1000) not null,
	created datetime default getdate() not null
)
go

insert into TblReturn(mid,uid,content) values(1,1,'自己赞一个')
go

select * from TblReturn
go

select top 1 m.*,u.username,u.nickname
 from TblMessage m
 inner join TblUser u on m.uid=u.uid
 where m.deleted='n' and m.mid not in
 (select top 0 mid from TblMessage order by mid desc)
 order by m.mid desc
go
