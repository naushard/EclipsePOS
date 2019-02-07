use possite

go



-- =============================================
-- Author:		M.S.Naushard
-- Create date: 
-- Description:	
-- =============================================

IF EXISTS (SELECT * FROM sysobjects WHERE type = 'P' AND name = 'Update_trans_item_amounts')
	BEGIN
		PRINT 'Dropping Procedure Update_trans_item_amounts'
		DROP  Procedure  Update_trans_item_amounts
	END

GO

CREATE PROCEDURE Update_trans_item_amounts 
	-- Add the parameters for the stored procedure here
	@organization_no varchar(6), 
	@seq_no int,
	@store_no varchar(6),
	@pos_no int,
	@trans_no int,
	@quantity decimal(15,3),
	@amount decimal(15,2), 
	@ext_amount decimal(15,2)	
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
update trans_item  
set amount = @amount, ext_amount = @ext_amount, quantity = @quantity
where trans_no = @trans_no
and organization_no = @organization_no
and store_no = @store_no
and pos_no = @pos_no
and seq_no = @seq_no
and state = 1

END


GO
