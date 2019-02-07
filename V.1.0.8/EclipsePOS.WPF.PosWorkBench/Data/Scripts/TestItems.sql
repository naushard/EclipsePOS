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
go
INSERT INTO ITEM VALUES(1, '3CL000038S  10' ,'Testing 1' ,100.01,  '', '', 10, '1', '', '', 1, 0, 1001)
go
INSERT INTO ITEM VALUES(1, 'SNK000071STD06' ,'Testing 2' ,125.57,  '', '', 10, '1', '', '', 1, 0, 1002)
go
INSERT INTO ITEM VALUES(1, 'AAW00009STX10' ,'Testing 3' ,75.10,  '', '', 10, '1', '', '', 1, 0, 1003)
go


delete from sub
go
insert into sub values('test1', 'test1')
go
