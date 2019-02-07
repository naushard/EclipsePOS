use possite

go



-- =============================================
-- Author:		M.S.Naushard
-- Create date: 
-- Description:	
-- =============================================

IF EXISTS (SELECT * FROM sysobjects WHERE type = 'P' AND name = 'Delete_trans_sales_person')
	BEGIN
		PRINT 'Dropping Procedure Delete_trans_sales_person'
		DROP  Procedure  Delete_trans_sales_person
	END

GO

CREATE PROCEDURE Delete_trans_sales_person 
	-- Add the parameters for the stored procedure here
	@trans_no int,	
	@organization_no varchar(6), 
	@store_no varchar(6),
	@pos_no int,
	@employee_no int
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
delete from trans_sales_person  
where trans_no = @trans_no
and organization_no = @organization_no
and store_no = @store_no
and pos_no = @pos_no
and employee_no = @employee_no

END


GO
