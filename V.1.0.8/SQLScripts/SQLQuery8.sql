
use possite

go




-- =============================================
-- Author:		M.S.Naushard
-- Create date: 
-- Description:	
-- =============================================

IF EXISTS (SELECT * FROM sysobjects WHERE type = 'P' AND name = 'Update_trans_item_state')
	BEGIN
		PRINT 'Dropping Procedure Update_trans_item_state'
		DROP  Procedure  Update_trans_item_state
	END

GO

CREATE PROCEDURE Update_trans_item_state 
	-- Add the parameters for the stored procedure here
	@organization_no int, 
	@seq_no int,
	@store_no int,
	@trans_no int,
	@state int
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
update trans_item  
set state = @state
where trans_no = @trans_no
and organization_no = @organization_no
and store_no = @store_no
and seq_no = @seq_no

END


GO



-- =============================================
-- Author:		M.S.Naushard
-- Create date: 
-- Description:	
-- =============================================

IF EXISTS (SELECT * FROM sysobjects WHERE type = 'P' AND name = 'Update_trans_tax_state')
	BEGIN
		PRINT 'Dropping Procedure Update_trans_tax_state'
		DROP  Procedure  Update_trans_tax_state
	END

GO

CREATE PROCEDURE Update_trans_tax_state 
	-- Add the parameters for the stored procedure here
	@organization_no int, 
	@seq_no int,
	@store_no int,
	@trans_no int,
	@state int
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
update trans_tax  
set state = @state
where trans_no = @trans_no
and organization_no = @organization_no
and store_no = @store_no
and seq_no = @seq_no

END


GO



-- =============================================
-- Author:		M.S.Naushard
-- Create date: 
-- Description:	
-- =============================================

IF EXISTS (SELECT * FROM sysobjects WHERE type = 'P' AND name = 'Update_trans_promotion_state')
	BEGIN
		PRINT 'Dropping Procedure Update_trans_promotion_state'
		DROP  Procedure  Update_trans_promotion_state
	END

GO

CREATE PROCEDURE Update_trans_promotion_state 
	-- Add the parameters for the stored procedure here
	@organization_no int, 
	@seq_no int,
	@store_no int,
	@trans_no int,
	@state int
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
update trans_promotion  
set state = @state
where trans_no = @trans_no
and organization_no = @organization_no
and store_no = @store_no
and seq_no = @seq_no

END


GO



-- =============================================
-- Author:		M.S.Naushard
-- Create date: 
-- Description:	
-- =============================================

IF EXISTS (SELECT * FROM sysobjects WHERE type = 'P' AND name = 'Update_trans_tender_state')
	BEGIN
		PRINT 'Dropping Procedure Update_trans_tender_state'
		DROP  Procedure  Update_trans_tender_state
	END

GO

CREATE PROCEDURE Update_trans_tender_state 
	-- Add the parameters for the stored procedure here
	@organization_no int, 
	@seq_no int,
	@store_no int,
	@trans_no int,
	@state int
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
update trans_tender  
set state = @state
where trans_no = @trans_no
and organization_no = @organization_no
and store_no = @store_no
and seq_no = @seq_no

END


GO



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
	@organization_no int, 
	@seq_no int,
	@store_no int,
	@trans_no int,
	@amount decimal(15,2), 
	@ext_amount decimal(15,2)	
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
update trans_item  
set amount = @amount, ext_amount = @ext_amount
where trans_no = @trans_no
and organization_no = @organization_no
and store_no = @store_no
and seq_no = @seq_no
and state = 1

END


GO









