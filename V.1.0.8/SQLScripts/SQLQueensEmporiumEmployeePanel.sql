
use possite1

go 



/* Load Trans Item */

IF EXISTS (SELECT * FROM sysobjects WHERE type = 'P' AND name = 'Load_All_Employees')
	BEGIN
		PRINT 'Dropping Procedure Load_All_Employees'
		DROP  Procedure  Load_All_Employees
	END

GO

PRINT 'Creating Procedure Load_All_Employees'
GO
CREATE Procedure Load_All_Employees
	/* Param List */
	@organization_no varchar(6)
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
select * from employee
where  organization_no = @organization_no 

GO




-- employee menu



delete from pos_param where config_no = 5 and param_name = 'PromptForEmployee' 
go
delete from pos_param where config_no = 5 and param_name = 'InputEmployeeId' 
go
delete from pos_param where config_no = 5 and param_name = 'EmployeeId' 
go




insert into pos_param values ( 5, 5, 6, 21, 'PromptForEmployee', 'TRUE', null) 
go

insert into pos_param values ( 5, 5, 4, 105, 'InputEmployeeId', 'Staff Id?', null) 
go

insert into pos_param values ( 5, 5, 2, 27, 'EmployeeId', 'Sales Staff', null)
go




