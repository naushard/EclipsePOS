USE [possite1]
GO
/****** Object:  StoredProcedure [dbo].[Load_Item_By_Item_Group]    Script Date: 10/25/2012 23:12:20 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE Procedure [dbo].[Load_Item_By_Item_Group]
	/* Param List */
	@organization_no varchar(6),
	@item_group varchar(5)
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

begin


select *  
from  item
where organization_no = @organization_no
and item_group = @item_group

return

end


