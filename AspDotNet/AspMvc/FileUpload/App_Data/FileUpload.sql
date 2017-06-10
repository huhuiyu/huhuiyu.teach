use master
go
if(DB_ID('FileUpload') is not null)
	drop database FileUpload
go
create database FileUpload
go
use FileUpload
go
create table TblFiles
(
	fid int identity primary key not null,
	filepath varchar(36) unique not null,
	filename nvarchar(255) not null,
	contentType varchar(50) not null,
	size int not null,
	description nvarchar(200) not null,
	uploadDate datetime default getdate() not null
)
go
select * from TblFiles
go