

use possite

delete from sub

go

insert into sub values ('admin', '21232F297A57A5A743894A0E4A801FC3' )

go


go

/* Load items by description */
IF EXISTS (SELECT * FROM sysobjects WHERE type = 'P' AND name = 'Load_Item_By_Desc')
	BEGIN
		PRINT 'Dropping Procedure Load_Item_By_Desc'
		DROP  Procedure  Load_Item_By_Desc
	END

GO

PRINT 'Creating Procedure Load_Item_By_Desc'
GO
CREATE Procedure Load_Item_By_Desc
	/* Param List */
	@short_desc varchar(50),
	@organization_no int
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

select * from item
where short_desc like  @short_desc
and organization_no = @organization_no
order by short_desc


GO



/* Load Items by PLU */
IF EXISTS (SELECT * FROM sysobjects WHERE type = 'P' AND name = 'Load_Item_By_Plu')
	BEGIN
		PRINT 'Dropping Procedure Load_Item_By_Plu'
		DROP  Procedure  Load_Item_By_Plu
	END

GO

PRINT 'Creating Procedure Load_Item_By_Plu'
GO
CREATE Procedure Load_Item_By_Plu
	/* Param List */
	@item_id		bigint	output,
	@organization_no int ,
	@sku	 		varchar(20) output,
	@short_desc		varchar(50) output,
	@amount			decimal(15,2) output,
	@dept			varchar(5) output,
	@item_group		varchar(5) output,
	@tax_group 		int output,
	@pricing_opt	int output,
	@active_date	datetime output, 
	@deactive_date	datetime output,
	@tax_inclusive	int output,
	@tax_exempt		int output,
	@plu			bigint
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


select 
	@item_id = item_id,
	@organization_no = organization_no,
	@sku = item.sku,
	@short_desc = short_desc,
	@amount = amount,
	@dept = dept,
	@item_group = item_group,
	@tax_group = tax_group,
	@pricing_opt = pricing_opt,
	@active_date = active_date, 
	@deactive_date = deactive_date,
	@tax_inclusive = tax_inclusive,
	@tax_exempt = tax_exempt,
	@plu = plu
from  item
where plu = @plu 
and organization_no = @organization_no
order by short_desc

return

end


GO



/* Load Item by SKU */

IF EXISTS (SELECT * FROM sysobjects WHERE type = 'P' AND name = 'Load_Item_By_SKU')
	BEGIN
		PRINT 'Dropping Procedure Load_Item_By_SKU'
		DROP  Procedure  Load_Item_By_SKU
	END

GO

PRINT 'Creating Procedure Load_Item_By_SKU'
GO
CREATE Procedure Load_Item_By_SKU
	@item_id				bigint	output,
	@organization_no 		int,
	@sku	 				varchar(20),
	@short_desc				varchar(50) output,
	@amount					decimal(15,2) output,
	@dept					varchar(5) output,
	@item_group				varchar(5) output,
	@tax_group 				int output,
	@pricing_opt			int output,
	@active_date			datetime output, 
	@deactive_date			datetime output,
	@tax_inclusive			int output,
	@tax_exempt				int output,
	@plu					bigint output
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


select 
	@item_id = item_id,
	@organization_no = organization_no,
	@sku = sku,
	@short_desc = short_desc,
	@amount = amount,
	@dept = dept,
	@item_group = item_group,
	@tax_group = tax_group,
	@pricing_opt = pricing_opt,
	@active_date = active_date, 
	@deactive_date = deactive_date,
	@tax_inclusive = tax_inclusive,
	@tax_exempt = tax_exempt,
	@plu   = plu
from  item
where sku = @sku
and organization_no = @organization_no
order by short_desc

return

end

GO






drop table employee



/* ------------------ Employee -------------------------------- */

create table employee
(
organization_no integer not null references Organization(organization_no),							
employee_id integer identity,
employee_no varchar(20),
logon_no varchar(32) not null,
logon_pass varchar(32) not null,
role_id integer not null references employee_roles(role_id),
fname varchar (32),
lname varchar(32),
mi char(1),
ssn char(9),
sal_grade integer,
constraint employeeKey primary key (organization_no, logon_no) 

)

go



  
/* Load Employee logon */
IF EXISTS (SELECT * FROM sysobjects WHERE type = 'P' AND name = 'Load_Employee_by_Logon')
	BEGIN
		PRINT 'Dropping Procedure Stored_Procedure_Name'
		DROP  Procedure  Load_Employee_by_Logon
	END

GO

PRINT 'Creating Procedure Load_Employee_by_Logon'
GO


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
Create Proc Load_Employee_by_Logon 
(
@organization_no int,
@employee_id	int output,
@employee_no varchar(20) output,
@logon_no 		varchar(32) ,
@logon_pass	 	varchar(32) output,
@role_id		int output,
@fname 			varchar(40) output,
@lname			varchar(40) output,
@mi     	   	varchar(10) output,
@ssn 			varchar(10) output,
@sal_grade		int output
)

as 

begin

	select 
	@employee_id = employee_id,
	@employee_no = employee_no,
	@logon_no = logon_no,
	@logon_pass = logon_pass,
	@role_id = role_id,
	@fname =	fname,
	@lname = lname,
	@mi = mi,
	@ssn = ssn,
	@sal_grade = sal_grade	
	from employee 
where logon_no = @logon_no	and organization_no = @organization_no

return 

end





GO



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
           ,'100'
           ,'F899139DF5E1059396431415E770C6DD'
           ,1001
           ,'Eclipse'
           ,'ES'
           ,null
           ,null
           ,0)
 
go


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
           (12
           ,'Eclipse100'
           ,'200'
           ,'3644A684F98EA8FE223C713B77189A77'
           ,1025
           ,'Eclipse'
           ,'ES'
           ,null
           ,null
           ,0)
 
go



