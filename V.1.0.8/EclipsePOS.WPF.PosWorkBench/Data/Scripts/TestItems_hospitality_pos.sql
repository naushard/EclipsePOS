/*
USE [C:\DOCUMENTS AND SETTINGS\NAUSHARD\MY DOCUMENTS\POSSITE.MDF]
*/

use possite 

go


/*USE [C:\C#PROJECTS\ECLIPSEPOS.WPF.SYSTEMMANAGER\ECLIPSEPOS.WPF.SYSTEMMANAGER\BIN\DEBUG\RDMS\POSSITE.MDF]

GO
*/
/*
use  [C:\C#PROJECTS\ECLIPSEPOS.WPF.POSWORKBENCH\DATA\POSSITE.MDF]
*/
go



GO
/****** Object:  Table [dbo].[Testing]    Script Date: 06/23/2008 18:35:24 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO


delete from item
INSERT INTO ITEM VALUES(1, '11000001' ,'Buffalo Wings' ,1.75,  '', '', 10, '1', '', '', 1, 0, 11000001)
go
INSERT INTO ITEM VALUES(1, '11000002' ,'Onion Rings' , 1.00,  '', '', 10, '1', '', '', 1, 0, 11000002)
go
INSERT INTO ITEM VALUES(1, '11000003' ,'Nachos' , 5.10,  '', '', 10, '1', '', '', 1, 0,  11000003)
go
INSERT INTO ITEM VALUES(1, '11000004' ,'Potato Skins' , 00.75,  '', '', 10, '1', '', '', 1, 0, 11000004)
go
INSERT INTO ITEM VALUES(1, '11000005' ,'Shrimp Cocktail' , 7.57,  '', '', 10, '1', '', '', 1, 0, 11000005)
go
INSERT INTO ITEM VALUES(1, '11000006' ,'Fried Mozzarella' , 4.50,  '', '', 10, '1', '', '', 1, 0,  11000006)
go
INSERT INTO ITEM VALUES(1, '11000007' ,'Quesadilla' , 8.25,  '', '', 10, '1', '', '', 1, 0, 11000007)
go
INSERT INTO ITEM VALUES(1, '11000008' ,'Chicken Tebders' , 4.95,  '', '', 10, '1', '', '', 1, 0, 11000008)
go
INSERT INTO ITEM VALUES(1, '11000009' ,'Lemon Pep Shrimp' ,5.10,  '', '', 10, '1', '', '', 1, 0,  11000009)
go
INSERT INTO ITEM VALUES(1, '11000010' ,'Baked Potato' ,1.75,  '', '', 10, '1', '', '', 1, 0, 11000010)
go
INSERT INTO ITEM VALUES(1, '11000011' ,'Cole Staw' , 1.00,  '', '', 10, '1', '', '', 1, 0, 11000011)
go
INSERT INTO ITEM VALUES(1, '11000012' ,'Steamed Vegi.' , 5.10,  '', '', 10, '1', '', '', 1, 0,  11000012)
go
INSERT INTO ITEM VALUES(1, '11000013' ,'Side Salad' , 00.75,  '', '', 10, '1', '', '', 1, 0, 11000013)
go
INSERT INTO ITEM VALUES(1, '11000014' ,'French Fries' , 7.57,  '', '', 10, '1', '', '', 1, 0, 11000014)
go
INSERT INTO ITEM VALUES(1, '11000015' ,'Special Beans' , 4.50,  '', '', 10, '1', '', '', 1, 0,  11000015)
go
INSERT INTO ITEM VALUES(1, '11000016' ,'Marshed Potato' , 8.25,  '', '', 10, '1', '', '', 1, 0, 11000016)
go
INSERT INTO ITEM VALUES(1, '11000017' ,'Gourment Muffins' , 4.95,  '', '', 10, '1', '', '', 1, 0, 11000017)
go
INSERT INTO ITEM VALUES(1, '11000018' ,'Frech Onion clam chowder' ,5.10,  '', '', 10, '1', '', '', 1, 0,  11000018)
go



delete from sub
go
insert into sub values('test1', 'test1')
go
