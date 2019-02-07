
use possite

go



/* Update stock balance */

IF EXISTS (SELECT * FROM sysobjects WHERE type = 'P' AND name = 'Update_stock_balance')
	BEGIN
		PRINT 'Dropping Procedure Update_stock_balance'
		DROP  Procedure  Update_stock_balance
	END

GO

PRINT 'Creating Procedure Update_stock_balance'
GO
CREATE Procedure Update_stock_balance
	/* Param List */
	@organization_no varchar(6),
	@store_no varchar(6),
	@sku varchar(24),
	@quantity decimal(15,3)
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
BEGIN
  begin try
	insert into stock_balance 
	values (@organization_no, @store_no, @sku, @quantity, 0, 0, 0 )
    
  end try	
  begin catch 	
	
	update stock_balance set quantity_on_hand = quantity_on_hand + @quantity 
	where organization_no = @organization_no and store_no = @store_no and sku = @sku
 
  end catch 

END


GO



/* Add Trans Stock */

IF EXISTS (SELECT * FROM sysobjects WHERE type = 'P' AND name = 'Add_trans_stock')
	BEGIN
		PRINT 'Dropping Procedure Add_trans_stock'
		DROP  Procedure  Add_trans_stock
	END

GO

PRINT 'Creating Procedure Add_trans_stock'
GO
CREATE Procedure Add_trans_stock
	/* Param List */
	@organization_no varchar(6),
	@store_no varchar(6),
	@sku varchar(24),
	@quantity decimal(15,3),
	@transaction_type smallint,
	@reference_number varchar(20),
	@transaction_time datetime
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
BEGIN
  	insert into trans_stock 
	values (@organization_no, @store_no, @sku, @quantity, @transaction_type, @reference_number, @transaction_time )
END    
GO






