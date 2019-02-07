
USE [possite1]

GO
/****** Object:  StoredProcedure [dbo].[Add_trans_text]    Script Date: 07/28/2013 14:40:47 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO


if OBJECT_ID('dbo.trans_sales_person', 'U') IS NOT NULL
	DROP TABLE dbo.trans_sales_person
go



/* Trans sales person	*/


create table trans_sales_person (
trans_no int not null,
store_no varchar(6) not null ,
organization_no varchar(6) not null references Organization(organization_no),
pos_no int not null,
employee_no integer,
constraint trans_sales_person_key1 primary key (organization_no, store_no, pos_no, trans_no, employee_no )						
)

go


/* Add Trans sales person */

IF EXISTS (SELECT * FROM sysobjects WHERE type = 'P' AND name = 'Add_trans_sales_person')
	BEGIN
		PRINT 'Dropping Procedure Add_trans_sales_person'
		DROP  Procedure  Add_trans_sales_person
	END

GO

PRINT 'Creating Procedure Add_trans_sales_peron'
GO

CREATE Procedure [dbo].[Add_trans_sales_person]
	/* Param List */
	@trans_no int,
	@store_no varchar(6),
	@organization_no varchar(6),
	@pos_no int,
	@employee_no int
	
AS

/******************************************************************************
**		File: 
**		Name: Stored_Procedure_Name
**		Desc: 
**
**		This template can be customized:
**              
**		Return values:
** 
**		Called by:   
**              
**		Parameters:
**		Input							Output
**     ----------							-----------
**
**		Auth: 
**		Date: 
*******************************************************************************
**		Change History
*******************************************************************************
**		Date:		Author:				Description:
**		--------		--------				-------------------------------------------
**    
*******************************************************************************/
insert into trans_sales_person values
(
@trans_no,
@store_no,
@organization_no,
@pos_no,
@employee_no
)

go



IF EXISTS (SELECT * FROM sysobjects WHERE type = 'P' AND name = 'Load_trans_sales_person')
	BEGIN
		PRINT 'Dropping Procedure Load_trans_sales_person'
		DROP  Procedure  Load_trans_sales_person
	END

GO

PRINT 'Creating Procedure Load_trans_sales_person'
GO




CREATE Procedure [dbo].[Load_trans_sales_person]
	/* Param List */
	@trans_no int,
	@store_no varchar(6),
	@organization_no varchar(6),
	@pos_no int
	
AS

/******************************************************************************
**		File: 
**		Name: Stored_Procedure_Name
**		Desc: 
**
**		This template can be customized:
**              
**		Return values:
** 
**		Called by:   
**              
**		Parameters:
**		Input							Output
**     ----------							-----------
**
**		Auth: 
**		Date: 
*******************************************************************************
**		Change History
*******************************************************************************
**		Date:		Author:				Description:
**		--------		--------				-------------------------------------------
**    
*******************************************************************************/
select * from trans_sales_person
where trans_no = @trans_no and store_no = @store_no
and organization_no = @organization_no and pos_no = @pos_no

go


