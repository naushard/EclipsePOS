
use possite1

go 

IF EXISTS (SELECT * FROM sysobjects WHERE type = 'P' AND name = 'Load_Menu_Config_By_Config_No')
	BEGIN
		PRINT 'Dropping Procedure Load_Menu_Config_By_Config_No'
		DROP  Procedure  Load_Menu_Config_By_Config_No
	END

GO

PRINT 'Creating Procedure Load_Menu_Config_By_Config_No'

GO

CREATE Procedure Load_Menu_Config_By_Config_No
	/* Param List */
	@config_no varchar(6)
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
from  menu_config
where config_no = @config_no


return

end


GO
