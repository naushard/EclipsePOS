use master
go
create database possite
on
( name = 'possite_dat',
FILENAME = 'D:\C#Projects\EclipsePOS-R2\data\possite.mdf',
SIZE = 10,
MAXSIZE = 100,
FILEGROWTH = 5 )
LOG ON
( name = 'possite_log',
FILENAME = 'D:\C#Projects\EclipsePOS-R2\data\possitelog.ldf',
SIZE = 5,
MAXSIZE = 50,
FILEGROWTH = 2 )
go
