use possite

go

USE [possite]
GO

IF EXISTS (SELECT * FROM sysobjects WHERE type = 'P' AND name = 'Load_Item_By_Item_Group')
	BEGIN
		PRINT 'Dropping Procedure Load_Item_By_Item_Group'
		DROP  Procedure  Load_Item_By_Item_Group
	END

GO

PRINT 'Creating Procedure Load_Item_By_Item_Group'
GO

/****** Object:  StoredProcedure [dbo].[Load_Item_By_Item_Group]    Script Date: 11/28/2013 22:59:10 ******/
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
order by organization_no, short_desc

return

end


go




IF EXISTS (SELECT * FROM sysobjects WHERE type = 'P' AND name = 'Load_ItemGroup_By_Organization_No')
	BEGIN
		PRINT 'Dropping Procedure Load_ItemGroup_By_Organization_No'
		DROP  Procedure  Load_ItemGroup_By_Organization_No
	END

GO


PRINT 'Creating Procedure Load_ItemGroup_By_Organization_No'
GO




CREATE Procedure [dbo].[Load_ItemGroup_By_Organization_No]
	/* Param List */
	@organization_no varchar(6),
	@group_id 		varchar(5) output,
	@group_name		varchar(30) output
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
	
from  itemGroup
where organization_no = @organization_no
order by group_id

return

end








