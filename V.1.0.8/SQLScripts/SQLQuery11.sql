use possite

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


