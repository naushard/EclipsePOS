use possite


/* Load ItemGroup by Organization_no */
IF EXISTS (SELECT * FROM sysobjects WHERE type = 'P' AND name = 'Load_ItemGroup_By_Organization_No')
	BEGIN
		PRINT 'Dropping Procedure Load_ItemGroup_By_Organization_No'
		DROP  Procedure  Load_ItemGroup_By_Organization_No
	END

GO

PRINT 'Creating Procedure Load_ItemGroup_By_Organization_No'

GO

CREATE Procedure Load_ItemGroup_By_Organization_No
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


GO
