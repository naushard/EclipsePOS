/* USE [C:\DOCUMENTS AND SETTINGS\NAUSHARD\MY DOCUMENTS\POSSITE.MDF] */
use  possite 
/*USE [C:\C#PROJECTS\ECLIPSEPOS.WPF.SYSTEMMANAGER\ECLIPSEPOS.WPF.SYSTEMMANAGER\BIN\DEBUG\RDMS\POSSITE.MDF]
GO
*/
/*
use  [C:\C#PROJECTS\ECLIPSEPOS.WPF.POSWORKBENCH\DATA\POSSITE.MDF]
*/
go 


/****** Object:  Table [dbo].[Testing]    Script Date: 06/23/2008 18:35:24 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO



delete from tax
go

delete from tax_group
go

delete from input_filter
go
delete from input_filter_field
go

delete from employee
go
delete from employee_role_event
go
delete from employee_roles
go

delete from pos
go

delete from retail_store
go




delete from currency 
go

delete from currency_code
go

delete from organization
go


print 'Delete complete'

go





INSERT INTO organization
           ([Organization_no]
		   ,[Organization_name]
           ,[Federal_tax_id]
           ,[Legal_status_code]
           ,[State_tax_id]
           ,[Tax_id])
     VALUES
           (1
		   ,'Eclipse Holding'
           ,'XXXBBXX'
           ,'ACTIVE'
           ,'GSTXBBB'
           ,'RMVXXX')
go







insert into input_filter values (1, 1, 1, 'Visa', 'Visa', '^;(4\d{15})=(\d{2})(\d{2})', null, null )
go
insert into input_filter_field values (1, 1, 'AccountNum')
go
insert into input_filter_field values (1, 2, 'ExprYear')
go
insert into input_filter_field values (1, 3, 'ExprMonth')
go
insert into input_filter values (2, 1, 1, 'MC', 'MC', '^;(5\d{15})=(\d{2})(\d{2})', null, null )
go
insert into input_filter_field values (2, 1, 'AccountNum')
go
insert into input_filter_field values (2, 2, 'ExprYear')
go
insert into input_filter_field values (2, 3, 'ExprMonth')
go
insert into input_filter values (3, 1, 1, 'Amex', 'AMEX', '^;(3\d{14})=(\d{2})(\d{2})', null, null )
go
insert into input_filter_field values (3, 1, 'AccountNum')
go
insert into input_filter_field values (3, 2, 'ExprYear')
go
insert into input_filter_field values (3, 3, 'ExprMonth')
go

insert into input_filter values (4, 1, 1, 'Costco', 'Costco', '^(;7\d{15})=(\d{2})(\d{2})', null, null )
go
insert into input_filter_field values (4, 1, 'AccountNum')
go
insert into input_filter_field values (4, 2, 'ExprYear')
go
insert into input_filter_field values (4, 3, 'ExprMonth')
go
insert into input_filter values (5, 1, 1, 'Discover', 'Discover', '^;(6\d{15})=(\d{2})(\d{2})', null, null )
go
insert into input_filter_field values (5, 1, 'AccountNum')
go
insert into input_filter_field values (5, 2, 'ExprYear')
go
insert into input_filter_field values (5, 3, 'ExprMonth')
go
insert into input_filter values (6, 1, 1, 'Diners Club', 'Diners Club', '^;(3\d{13})=(\d{2})(\d{2})', null, null )
go
insert into input_filter_field values (6, 1, 'AccountNum')
go
insert into input_filter_field values (6, 2, 'ExprYear')
go
insert into input_filter_field values (6, 3, 'ExprMonth')
go
insert into input_filter values (7, 1, 1, 'JCB', 'JCB', '^;(35\d{14})=(\d{2})(\d{2})', null, null )
go
insert into input_filter_field values (7, 1, 'AccountNum')
go
insert into input_filter_field values (7, 2, 'ExprYear')
go
insert into input_filter_field values (7, 3, 'ExprMonth')
go
insert into input_filter values (8, 1, 1, 'HSBC', 'HSBC', '^(5\d{17})=(\d{2})(\d{2})', null, null )
go
insert into input_filter_field values (8, 1, 'AccountNum')
go
insert into input_filter_field values (8, 2, 'ExprYear')
go
insert into input_filter_field values (8, 3, 'ExprMonth')
go
insert into input_filter values (9, 1, 1, 'NETS-DBS', 'NETS-DBS', '^(4\d{15})=(\d{2})(\d{2})', null, null )
go
insert into input_filter_field values (9, 1, 'AccountNum')
go
insert into input_filter_field values (9, 2, 'ExprYear')
go 
insert into input_filter_field values (9, 3, 'ExprMonth')
go



-- PosProfileEvent
--insert into pos_profile_event values(1, 0, 'AlphaKey' )
--go
--insert into pos_profile_event values(1, 0, 'AltCurrTender' )
--go
--insert into pos_profile_event values(1, 0, 'CashTender' )
--go

SET IDENTITY_INSERT tax_group OFF
GO

-- employee roles
SET IDENTITY_INSERT employee_roles ON
GO

INSERT INTO employee_roles
           ([role_id]
			,[role_name]
           ,[organization_no])
     VALUES
           (
			1001
			,'Manager'
			,1
			)

go

SET IDENTITY_INSERT employee_roles OFF
GO


-- employee
--insert into employee values (100, 101, 1, 'Eclipse', 'ES', '', '', 0 )
--go 
INSERT INTO employee
           ([organization_no]
           ,[employee_no]
           ,[logon_no]
           ,[logon_pass]
           ,[role_id]
           ,[fname]
           ,[lname]
           ,[mi]
           ,[ssn]
           ,[sal_grade])
     VALUES
           (1
           ,'Eclipse100'
           ,100
           ,101
           ,1001
           ,'Eclipse'
           ,'ES'
           ,''
           ,''
           ,0)
 
go




INSERT INTO Retail_Store
           ([store_no]
			,[organization_no]
		   ,[store_name]
           ,[closing_date]
           ,[open_date]
           ,[selling_area_size]
           ,[size]
           ,[address1]
           ,[address2]
           ,[address3]
           ,[address4]
           ,[address5]
           ,[postal_code]
           ,[phone]
           ,[ip]
           ,[port_number]
           ,[last_trans_no])
     VALUES
           (2
			,1
		   ,'WOS Plaza'
           ,'18-April-2008'
           ,'18-April-2008'
           ,25.40
           ,50.00
           ,'BLK 112, Deport Road'
           ,'#05-113'
           ,'Singapore 102111'
           ,'TTC'
           ,'TTXX'
           ,'102111'
           ,'74566'
           ,'10.0.0.101'
           ,'10'
           ,10
			)


GO


SET IDENTITY_INSERT tax_group ON
GO

INSERT INTO tax_group
           ([tax_group_id]
			,[organization_no]
           ,[tax_group_name])
     VALUES
           (10
			,1
           ,'GST')

SET IDENTITY_INSERT tax_group OFF
GO


insert into tax values (1, 10, 0, 'GST 7%', 7.0, 7.0) 
go

/*use  [C:\C#PROJECTS\ECLIPSEPOS.WPF.POSWORKBENCH\DATA\POSSITE.MDF]
go
*/ 

SET IDENTITY_INSERT currency_code ON

GO


INSERT INTO currency_code
			([currency_code_id]
			,[currency_code]
           ,[language]
           ,[country]
           ,[currency_desc])
     VALUES ( 1, 1, 'US', 'US', 'US Dollars')

go

INSERT INTO currency_code
			([currency_code_id]
			,[currency_code]
           ,[language]
           ,[country]
           ,[currency_desc])
     VALUES (2, 2, 'EU', 'EU', 'Euro' )

go


INSERT INTO currency_code
			([currency_code_id]
			,[currency_code]
           ,[language]
           ,[country]
           ,[currency_desc])
     VALUES (3, 3, 'BP', 'UK', 'British Pounds')

go


INSERT INTO currency_code
			([currency_code_id]
			,[currency_code]
           ,[language]
           ,[country]
           ,[currency_desc])
     VALUES (4, 4, 'AD', 'AU', 'Australian Dollars')

go

INSERT INTO currency_code
			([currency_code_id]
			,[currency_code]
           ,[language]
           ,[country]
           ,[currency_desc])
     VALUES (5, 5, 'HK', 'HK', 'HongKong Dollars')

go

INSERT INTO currency_code
			([currency_code_id]
			,[currency_code]
           ,[language]
           ,[country]
           ,[currency_desc])
     VALUES (6, 6, 'YE', 'JP', 'Japanease Yen')

go


INSERT INTO currency_code
			([currency_code_id]
			,[currency_code]
           ,[language]
           ,[country]
           ,[currency_desc])
     VALUES (7, 7, 'TS', 'TS', 'Testing')

go

SET IDENTITY_INSERT currency_code  OFF
GO



insert into currency values ( 1, 1,   1.5195, 1, 2, 'US', 1, 1, 'Apr 25 2007 08:00AM', null) 
go
insert into currency values ( 1, 2,  2.0411,  1, 2, 'EU', 0, 0, 'Apr 25 2007 08:00AM', null) 
go
insert into currency values ( 1, 3,  3.0164,  1, 2, 'BP', 0, 0, 'Apr 25 2007 08:00AM', null) 
go
insert into currency values ( 1, 4,  1.2688,  1, 2, 'AD', 0, 0, 'Apr 25 2007 08:00AM', null) 
go
insert into currency values ( 1, 5,  0.1932,  1, 2, 'HKD', 0, 0, 'Apr 25 2007 08:00AM', null) 
go
insert into currency values ( 1, 6,  0.012454,  1, 2, 'YEN', 0, 0, 'Apr 25 2007 08:00AM', null) 
go
insert into currency values ( 1, 7,  1.13236,  1, 2, 'EU', 0, 0, 'Apr 25 2007 08:00AM', null) 
go




INSERT into pos VALUES( 105, 1, 2, 0, 'Corner store', '8-12-08', '8-12-08' )

go

INSERT into pos VALUES( 110, 1, 2, 0, 'Happy Resturent', '8-12-08', '8-12-08' )

go