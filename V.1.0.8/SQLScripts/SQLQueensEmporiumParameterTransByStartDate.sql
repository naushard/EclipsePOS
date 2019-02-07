USE [possite]
GO
/****** Object:  StoredProcedure [dbo].[Load_Trans_by_Start_Date]    Script Date: 10/07/2013 23:45:08 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON


IF EXISTS (SELECT * FROM sysobjects WHERE type = 'P' AND name = 'Load_Trans_by_Start_Date')
	BEGIN
		PRINT 'Dropping Procedure Load_Trans_by_Start_Date'
		DROP  Procedure Load_Trans_by_Start_Date 
	END

GO




GO
CREATE Procedure [dbo].[Load_Trans_by_Start_Date]
	/* Param List */
	@organization_no varchar(6),
	@store_no varchar(6),
	@pos_no int
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

select trans.trans_no, trans_type, trans.state, tendertype, amount, change_amt, amount-change_amt as sales_amt, tender_desc, start_time, complete_time, trans_sales_person.employee_no
from trans 
left outer join trans_tender
on ( trans.trans_no = trans_tender.trans_no and trans.organization_no = trans_tender.organization_no and trans.store_no = trans_tender.store_no and trans.pos_no = trans_tender.pos_no )  
left outer join trans_sales_person
on (trans.trans_no = trans_sales_person.trans_no and trans.organization_no = trans_sales_person.organization_no and trans.store_no = trans_sales_person.store_no and trans.pos_no = trans_sales_person.pos_no )
where trans.organization_no = @organization_no and trans.store_no = @store_no and trans.pos_no = @pos_no and
trans.trans_no >=  ( select top 1 start_receipt_no from pos_total where total_name = 1 and end_date = 0 and pos_total.organization_no = @organization_no and pos_total.store_no = @store_no and pos_total.pos_no = @pos_no )
order by trans.trans_no DESC

