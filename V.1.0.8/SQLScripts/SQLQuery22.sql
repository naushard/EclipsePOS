


USE [possite]
GO

drop procedure [dbo].[Load_Tran_Tax_By_Trans_No]

/****** Object:  StoredProcedure [dbo].[Load_Table_Group_By_Strore_No]    Script Date: 05/27/2011 22:32:43 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE Procedure [dbo].[Load_Tran_Tax_By_Trans_No]
	@organization_no varchar(6),
	@store_no varchar(6),
	@trans_no int,
	@line_no int
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

select * from trans_tax
where organization_no = @organization_no  
and store_no = @store_no
and trans_no = @trans_no
and line_no = @line_no
and state = 2

 
