

use possite

go


if OBJECT_ID('dbo.trans_text', 'U') IS NOT NULL
	DROP TABLE dbo.trans_text
go


/* Trans tax	*/


create table trans_text (
trans_no int not null,
line_no integer,
store_no varchar(6) not null ,
organization_no varchar(6) not null references Organization(organization_no),
pos_no int not null,
text_line_no integer,
extended_text varchar(60),
constraint trans_text_key1 primary key (organization_no, store_no, pos_no, trans_no, line_no, text_line_no )						

)

go


/* Add Trans Text */

IF EXISTS (SELECT * FROM sysobjects WHERE type = 'P' AND name = 'Add_trans_text')
	BEGIN
		PRINT 'Dropping Procedure Add_trans_text'
		DROP  Procedure  Add_trans_text
	END

GO

PRINT 'Creating Procedure Add_trans_text'
GO
CREATE Procedure Add_trans_text
	/* Param List */
	@trans_no int,
	@line_no int,
	@store_no varchar(6),
	@organization_no varchar(6),
	@pos_no int,
	@text_line_no int,
	@extended_text varchar(60)
	
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
insert into trans_text values
(
@trans_no,
@line_no,
@store_no,
@organization_no,
@pos_no,
@text_line_no,
@extended_text
)

GO



/* Load Trans Text */

IF EXISTS (SELECT * FROM sysobjects WHERE type = 'P' AND name = 'Load_Trans_text_By_Trans_no')
	BEGIN
		PRINT 'Dropping Procedure Load_Trans_text_By_Trans_no'
		DROP  Procedure  Load_Trans_text_By_Trans_no
	END

GO

PRINT 'Creating Procedure Load_Trans_text_By_Trans_no'
GO
CREATE Procedure Load_Trans_text_By_Trans_no
	/* Param List */
	@trans_no int,
	@line_no int,
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
select * from trans_text
where trans_no = @trans_no and  line_no= @line_no and store_no = @store_no
and organization_no = @organization_no and pos_no = @pos_no
order by line_no

GO






