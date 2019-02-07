USE [possite]


IF EXISTS (SELECT * FROM sysobjects WHERE type = 'P' AND name = 'Load_surcharge_by_surcharge_code')
	BEGIN
		PRINT 'Dropping Procedure Load_surcharge_by_surcharge_code'
		DROP  Procedure  Load_surcharge_by_surcharge_code
	END

GO

PRINT 'Creating Procedure Load_surcharge_by_surcharge_code'
GO


-- =============================================
-- Author:		Naushard
-- Create date: 
-- Description:	
-- =============================================
CREATE PROCEDURE [dbo].[Load_surcharge_by_surcharge_code] 
	-- Add the parameters for the stored procedure here
	@organization_no varchar(6), 
	@surcharge_code varchar(6),
	@surcharge_desc varchar(60) output,
	@amount decimal(15,2) output,
	@method smallint output,
	@surcharge_account varchar(45) output,
	@tax_group_id varchar(12) output,
	@tax_inclusive smallint output,
	@tax_exempt smallint output,
	@surcharge_key_id int output
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

	-- Insert statements for procedure here

select 
@organization_no = organization_no, 
@surcharge_code =surcharge_code,
@surcharge_desc =surcharge_desc,
@amount = amount,
@method  = method,
@surcharge_account  = surcharge_account,
@tax_group_id  = tax_group_id,
@tax_inclusive = tax_inclusive,
@tax_exempt  = tax_exempt,
@surcharge_key_id  = surcharge_key_id
from surcharge 
where organization_no = @organization_no 
and surcharge_code = @surcharge_code 
   
END
