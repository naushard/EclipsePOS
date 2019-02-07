use possite

IF EXISTS (SELECT * FROM sysobjects WHERE type = 'P' AND name = 'Load_trans_for_Accpac_Shipment_Import')
	BEGIN
		PRINT 'Dropping Procedure Load_trans_for_Accpac_Shipment_Import'
		DROP  Procedure  Load_trans_for_Accpac_Shipment_Import
	END

GO

PRINT 'Creating Procedure Load_trans_for_Accpac_Shipment_Import'

GO
-- =============================================
-- Author:		Naushard
-- Create date: 
-- Description:	
-- =============================================
CREATE PROCEDURE Load_trans_for_Accpac_Shipment_Import 
	-- Add the parameters for the stored procedure here
	@organization_no varchar(12), 
	@upload_session_no int
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

	-- Insert statements for procedure here
	select  trans_item.trans_no, trans_item.line_no as sales_line, trans_item.seq_no, 
    trans_item.sku, item_desc, trans_item.quantity, 
	trans_item.amount, trans_item.ext_amount, trans_promotion.promotion_amount, 
	cast( [dbo].[ufn_GetDateOnly](start_time) as varchar(12 ) ) as sales_date,
	trans.store_no,	trans.customer_tax_id,
	item.catogory, item.shipping_uom,
	customer.customer_first_name, customer.customer_last_name, customer.addr1,
	customer.addr2, customer.postel_code, customer.city, customer.region,
	customer.country, customer.customer_account_set, customer.price_list_code,
	customer.terms_code, customer.rate_type
    from trans_item join trans 
    on (trans_item.trans_no = trans.trans_no and 
    trans_item.organization_no = trans.organization_no and 
    trans_item.store_no = trans.store_no ) 
    left outer join trans_promotion 
    on (trans_item.organization_no = trans_promotion.organization_no and trans_item.store_no = trans_promotion.store_no and trans_item.trans_no = trans_promotion.trans_no and trans_item.line_no = trans_promotion.line_no ) 
    left outer join retail_store on 
    (trans.store_no=retail_store.store_no and trans.organization_no = retail_store.organization_no ) 
    left outer join item on
	(trans_item.organization_no = item.organization_no and trans_item.sku = item.sku )
	left outer join customer on
	(trans.organization_no = customer.organization_no and trans.customer_tax_id = customer.tax_id)
	where trans.state = 2 
    and trans_item.state = 2 
	and trans.organization_no = @organization_no 
    and trans.upload_session_no = @upload_session_no 
    order by store_no, sales_date, trans.customer_tax_id, trans_item.trans_no, trans_item.line_no 
	



END
GO



IF EXISTS (SELECT * FROM sysobjects WHERE type = 'P' AND name = 'Load_retail_store_customer')
	BEGIN
		PRINT 'Dropping Procedure Load_retail_store_customer'
		DROP  Procedure  Load_retail_store_customer
	END

GO

PRINT 'Creating Procedure Load_retail_store_customer'

GO
-- =============================================
-- Author:		Naushard
-- Create date: 
-- Description:	
-- =============================================
CREATE PROCEDURE Load_retail_store_customer 
	-- Add the parameters for the stored procedure here
	@organization_no varchar(12), 
	@store_no varchar(6)
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

	-- Insert statements for procedure here

	select * from retail_store 
	left outer join  customer
	on( retail_store.organization_no = customer.organization_no and
	retail_store.customer_tax_id = customer.tax_id)
	where retail_store.organization_no = @organization_no 
    and retail_store.store_no = @store_no 
   
END
GO
