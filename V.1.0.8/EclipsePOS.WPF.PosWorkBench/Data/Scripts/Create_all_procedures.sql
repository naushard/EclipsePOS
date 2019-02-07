
Use possite 

/*USE [C:\C#PROJECTS\ECLIPSEPOS.WPF.SYSTEMMANAGER\ECLIPSEPOS.WPF.SYSTEMMANAGER\BIN\DEBUG\RDMS\POSSITE.MDF]
GO*/

go

/*USE [C:\USERS\NAUSHARD\DOCUMENTS\POSSITE.MDF] 
GO
*/
/****** Object:  Table [dbo].[Testing]    Script Date: 06/23/2008 18:35:24 ******/

/*
USE [C:\C#PROJECTS\ECLIPSEPOS.WPF.POSWORKBENCH\DATA\POSSITE.MDF]
*/
GO



SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO


/* 1 */

IF EXISTS (SELECT * FROM sysobjects WHERE type = 'P' AND name = 'Add_BoMap')
	BEGIN
		PRINT 'Dropping Procedure Add_BoMap'
		DROP  Procedure  Add_BoMap
	END

GO

PRINT 'Creating Procedure Add_BoMap'
GO
CREATE Procedure Add_BoMap
	/* Param List */
	@bo_id	int,
	@obj_type int,
	@parent_bo_id int,
	@pobj_type int
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

insert into bo_map
values
(
@bo_id,
@obj_type,
@parent_bo_id,
@pobj_type
)
GO

GRANT EXEC ON Add_BoMap TO PUBLIC

GO


/* 2 */


IF EXISTS (SELECT * FROM sysobjects WHERE type = 'P' AND name = 'Add_Bu')
	BEGIN
		PRINT 'Dropping Procedure Add_Bu'
		DROP  Procedure  Add_Bu
	END

GO

PRINT 'Creating Procedure Add_Bu'
GO
CREATE Procedure Add_Bu
	/* Param List */
	@bu_id int,
	@bu_desc varchar(32),
	@create_date datetime 
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
insert into bu
values
(
@bu_id,
@bu_desc,
@create_date
)
GO

GRANT EXEC ON Add_Bu TO PUBLIC

GO


/* 3 Add_Dialog */
IF EXISTS (SELECT * FROM sysobjects WHERE type = 'P' AND name = 'Add_Dialog')
	BEGIN
		PRINT 'Dropping Procedure Add_Dialog'
		DROP  Procedure  Add_Dialog
	END

GO

PRINT 'Creating Procedure Add_Dialog'
GO
CREATE Procedure Add_Dialog
	@dialog_id int,
	@config_no int,
	@help_id int,
	@dialog_type int,
	@dialog_name varchar(50) 
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

insert into Dialog values
(
	@dialog_id,
	@config_no,
	@help_id,
	@dialog_type,
	@dialog_name 
)

return

GO

GRANT EXEC ON Add_Dialog TO PUBLIC

GO


/* 4 Add_DialogEvent */
IF EXISTS (SELECT * FROM sysobjects WHERE type = 'P' AND name = 'Add_DialogEvent')
	BEGIN
		PRINT 'Dropping Procedure Add_DialogEvent'
		DROP  Procedure  Add_DialogEvent
	END

GO

PRINT 'Creating Procedure Add_DialogEvent'

GO

CREATE Procedure Add_DialogEvent
	@dialog_event_id int,
	@dialog_id int,
	@dialog_seq int,
	@help_id int,
	@dialog_desc varchar(50),
	@state int,
	@event_enabled int,
	@event_required int,
	@event_class varchar(100) 
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

insert into dialog_event values
(
	@dialog_event_id,
	@dialog_id,
	@dialog_seq,
	@help_id,
	@dialog_desc,
	@state,
	@event_enabled,
	@event_required,
	@event_class 
)

return


GO

GRANT EXEC ON Add_DialogEvent TO PUBLIC

GO


/* Add_InputFilter */


IF EXISTS (SELECT * FROM sysobjects WHERE type = 'P' AND name = 'Add_Input_Filter')
	BEGIN
		PRINT 'Dropping Procedure Add_Input_Filter'
		DROP  Procedure  Add_Input_Filter
	END

GO

PRINT 'Creating Procedure Add_Input_Filter'
GO
CREATE Procedure Add_Input_Filter
	/* Param List */
	@filter_id int,
	@filter_type int,
	@filter_sub_type int,
	@filter_name varchar(50),
	@display_name varchar(50),
	@regex varchar(32),
	@check_digit_class varchar(100),
	@filter_class varchar(100)
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
insert into input_filter values
(
	@filter_id,
	@filter_type,
	@filter_sub_type,
	@filter_name,
	@display_name,
	@regex,
	@check_digit_class,
	@filter_class 
)
GO

GRANT EXEC ON Add_Input_Filter TO PUBLIC

GO


/* Add_InputFilterField.sql */
IF EXISTS (SELECT * FROM sysobjects WHERE type = 'P' AND name = 'Add_Input_Filter_Field')
	BEGIN
		PRINT 'Dropping Procedure Add_Input_Filter_Field'
		DROP  Procedure  Add_Input_Filter_Field
	END

GO

PRINT 'Creating Procedure Add_Input_Filter_Field'
GO
CREATE Procedure Add_Input_Filter_Field
	/* Param List */
	@filter_id int,
	@sequence_no int,
	@name varchar(32)
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
insert into input_filter_field values 
(
@filter_id,
@sequence_no,
@name
)

GO

GRANT EXEC ON Add_Input_Filter_Field TO PUBLIC

GO


/* Add_Item */


IF EXISTS (SELECT * FROM sysobjects WHERE type = 'P' AND name = 'Add_Item')
	BEGIN
		PRINT 'Dropping Procedure Add_Item'
		DROP  Procedure  Add_Item
	END

GO

PRINT 'Creating Procedure Add_Item'
GO
CREATE Procedure Add_Item
	@item_id		bigint,
	@retail_store_group_no	int,
	@sku	 		varchar(20),
	@short_desc		varchar(50),
	@amount			decimal(15,2),
	@dept			int,
	@tax_group 		int,
	@pricing_opt	int,
	@act_date		datetime, 
	@deact_date		datetime,
	@tax_inclusive	int,
	@tax_exempt		int,
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

	insert into item  values (
			@item_id,
			@retail_store_group_no,
			@sku,
			@short_desc,
			@amount,
			@dept,
			@tax_group,
			@pricing_opt,
			@act_date, 
			@deact_date,
			@tax_inclusive,
			@tax_exempt,
			@plu
	)
		

return 

end



GO

GRANT EXEC ON Add_Item TO PUBLIC

GO





 /* Add_MenuConfig */
 
 IF EXISTS (SELECT * FROM sysobjects WHERE type = 'P' AND name = 'Add_Menu_Config')
	BEGIN
		PRINT 'Dropping Procedure Add_Menu_Config'
		DROP  Procedure  Add_Menu_Config
	END

GO

PRINT 'Creating Procedure Add_Menu_Config'
GO
CREATE Procedure Add_Menu_Config
	/* Param List */
	@config_id int,
	@menu_id int,
	@panel_id int,
	@x_pos int,
	@y_pos int,
	@width int,
	@height int,
	@foreground_red int,
	@foreground_green int,
	@foreground_bleu int,
	@background_red int,
	@background_green int,
	@background_blue int,
	@font_size int
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

insert into 
menu_config
values
(
@config_id,
@menu_id,
@panel_id,
@x_pos,
@y_pos,
@width,
@height,
@foreground_red,
@foreground_green,
@foreground_bleu,
@background_red,
@background_green,
@background_blue,
@font_size
)
GO

    
GRANT EXEC ON Add_Menu_Config TO PUBLIC

GO




/* Add_plu */

IF EXISTS (SELECT * FROM sysobjects WHERE type = 'P' AND name = 'Add_Plu')
	BEGIN
		PRINT 'Dropping Procedure Add_Plu'
		DROP  Procedure  Add_Plu
	END

GO

PRINT 'Creating Procedure Add_Plu'
GO
CREATE Procedure Add_Plu
	@plu bigint,
	@sku varchar(20) 
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
insert into plu values
(
	@plu,
	@sku
)

GO

GRANT EXEC ON Add_Plu TO PUBLIC

GO




/* Add_PosParam */

IF EXISTS (SELECT * FROM sysobjects WHERE type = 'P' AND name = 'Add_pos_param')
	BEGIN
		PRINT 'Dropping Procedure Add_pos_param'
		DROP  Procedure  Add_pos_param
	END

GO

PRINT 'Creating Procedure Add_pos_param'
GO
CREATE Procedure Add_pos_param
	/* Param List */
	@param_id int,
	@config_no int,
	@param_type int,
	@cache_flag int,
	@help_id int,
	@param_name varchar(100),
	@param_value varchar(100)
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
insert into pos_param values(
@config_no,
@param_type,
@cache_flag,
@help_id,
@param_name,
@param_value
)

GO

GRANT EXEC ON Add_pos_param TO PUBLIC

GO

/* Add_Promotion */

IF EXISTS (SELECT * FROM sysobjects WHERE type = 'P' AND name = 'Add_Promotion')
	BEGIN
		PRINT 'Dropping Procedure Add_Promotion'
		DROP  Procedure  Add_Promotion
	END

GO

PRINT 'Creating Procedure Add_Promotion'
GO
CREATE Procedure Add_Promotion
	/* Param List */
	@config_no int,
	@promotion_no int,
	@promotion_type int,
	@promotion_val1 int,
	@promotion_val2 int,
	@promotion_val3 int,
	@promotion_val4 int,
	@promotion_val5 int,
	@promotion_dval1 decimal(15,2),
	@promotion_dval2 decimal(15,2),
	@promotion_dval3 decimal(15,2),
	@promotion_dval4 decimal(15,2),
	@promotion_dval5 decimal(15,2),
	@print_before_item int,
	@valid_times varchar(12),
	@valid_days varchar(12),
	@promotion_string varchar(100),
	@promotion_class varchar(100)
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
insert into promotion values
(
@config_no,
@promotion_no,
@promotion_type,
@promotion_val1,
@promotion_val2,
@promotion_val3,
@promotion_val4,
@promotion_val5,
@promotion_dval1,
@promotion_dval2,
@promotion_dval3,
@promotion_dval4,
@promotion_dval5,
@print_before_item,
@valid_times,
@valid_days,
@promotion_string,
@promotion_class
)



GO

GRANT EXEC ON Add_Promotion TO PUBLIC

GO


/* Add_Promotion_map */
IF EXISTS (SELECT * FROM sysobjects WHERE type = 'P' AND name = 'Add_Promotion_map')
	BEGIN
		PRINT 'Dropping Procedure Add_Promotion_map'
		DROP  Procedure  Add_Promotion_map
	END

GO

PRINT 'Creating Procedure Add_Promotion_map'
GO
CREATE Procedure Add_Promotion_map
	/* Param List */
	@promotion_id int,
	@promotion_map varchar(20),
	@map_type int
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
insert into promotion_map
values
(
@promotion_id,
@promotion_map,
@map_type
)



GO

GRANT EXEC ON Add_Promotion_map TO PUBLIC

GO



/* Add Sub */

IF EXISTS (SELECT * FROM sysobjects WHERE type = 'P' AND name = 'Add_Sub')
	BEGIN
		PRINT 'Dropping Procedure Add_Sub'
		DROP  Procedure  Add_Sub
	END

GO

PRINT 'Creating Procedure Add_Sub'
GO
CREATE Procedure Add_Sub
	@subscriber_id int output,
	@subscriber_name varchar(32), 
	@subscriber_pass varchar(32)
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
insert into sub values
(
	@subscriber_name,
	@subscriber_pass
)


select @subscriber_id = max(subscriber_id) from sub

go

GRANT EXEC ON Add_Sub TO PUBLIC

GO


/* Load Sub by OrganizationId */

IF EXISTS (SELECT * FROM sysobjects WHERE type = 'P' AND name = 'Load_Sub_By_OrganizationId')
	BEGIN
		PRINT 'Dropping Procedure Load_Sub_By_OrganizationId'
		DROP  Procedure  Load_Sub_By_OrganizationId
	END

GO

PRINT 'Creating Procedure Load_Sub_By_OrganizationId'
GO
CREATE Procedure Load_Sub_By_OrganizationId
	@organization_id int
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
select *  from sub as A, sub_map as B  where
A.subscriber_id = B.subscriber_id and B.organization_id = @organization_id 

go

GRANT EXEC ON Load_Sub_By_OrganizationId TO PUBLIC

GO


/* Load All Sub */

IF EXISTS (SELECT * FROM sysobjects WHERE type = 'P' AND name = 'Load_All_Sub')
	BEGIN
		PRINT 'Dropping Procedure Load_All_Sub'
		DROP  Procedure  Load_All_Sub
	END

GO

PRINT 'Creating Procedure Load_All_Sub'
GO
CREATE Procedure Load_All_Sub
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
select *  from sub 
go

GRANT EXEC ON Load_All_Sub TO PUBLIC

GO





/* Add_sub_map */

IF EXISTS (SELECT * FROM sysobjects WHERE type = 'P' AND name = 'Add_Sub_Map')
	BEGIN
		PRINT 'Dropping Procedure Add_Sub_Map'
		DROP  Procedure  Add_Sub_Map
	END

GO

PRINT 'Creating Procedure Add_Sub_Map'
GO
CREATE Procedure Add_Sub_Map
	/* Param List */
	@subscriber_id int,
	@organization_id int,
	@subscriber_priv int
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
insert into sub_map
values
(
@subscriber_id,
@organization_id,
@subscriber_priv
)


GO


GRANT EXEC ON Add_Sub_Map TO PUBLIC

GO



/* Add sub menus */

IF EXISTS (SELECT * FROM sysobjects WHERE type = 'P' AND name = 'Add_SubMenu')
	BEGIN
		PRINT 'Dropping Procedure Add_SubMenu'
		DROP  Procedure  Add_SubMenu
	END

GO

PRINT 'Creating Procedure Add_SubMenu'
GO
CREATE Procedure Add_SubMenu
	@sub_menu_id	int,
	@menu_id		int,		
	@sub_menu_name	varchar(100) 
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

	insert into sub_menu values
	(
		@sub_menu_id,
		@menu_id,
		@sub_menu_name
	)

return

end


GO

GRANT EXEC ON Add_SubMenu TO PUBLIC

GO


/* Add_tax */

IF EXISTS (SELECT * FROM sysobjects WHERE type = 'P' AND name = 'Add_Tax')
	BEGIN
		PRINT 'Dropping Procedure Add_Tax'
		DROP  Procedure  Add_Tax
	END

GO

PRINT 'Creating Procedure Add_Tax'
GO
CREATE Procedure Add_Tax
	/* Param List */
@tax_id int,
@tax_group_id int,
@tax_type int,
@short_desc varchar(32),
@rate decimal(15,2),
@alt_rate decimal(15,2)

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

insert into tax
values
(
@tax_id,
@tax_group_id,
@tax_type,
@short_desc,
@rate,
@alt_rate
)

GO



GRANT EXEC ON Add_Tax TO PUBLIC

GO


/* Add_total */
IF EXISTS (SELECT * FROM sysobjects WHERE type = 'P' AND name = 'Add_Total')
	BEGIN
		PRINT 'Dropping Procedure Add_Total'
		DROP  Procedure  Add_Total
	END

GO

PRINT 'Creating Procedure Add_Total'
GO
CREATE Procedure Add_Total
	/* Param List */
	@total_id int,
	@pos_total_id int,
	@total_type int,
	@total_count int,
	@total_amount decimal(15,2)
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
declare @count int

select @count = count(total_id)  from total
set @total_id = @count+1
insert into total
values
(
0,
@count,
@total_type,
@total_count,
@total_amount
)

GO

GRANT EXEC ON Add_Total TO PUBLIC

GO


/* Add_trans */
IF EXISTS (SELECT * FROM sysobjects WHERE type = 'P' AND name = 'Add_Trans')
	BEGIN
		PRINT 'Dropping Procedure Add_Trans'
		DROP  Procedure  Add_Trans
	END

GO

PRINT 'Creating Procedure Add_Trans'
GO
CREATE Procedure Add_Trans
	/* Param List */
	@trans_id int,
	@store_no int,
	@organization_no int,
	@pos_no int,
	@drawer_no int,
	@config_no int,
	@trans_type int,
	@state int,
	@reason_code int,
	@customer_no varchar(20),
	@start_time datetime,
	@complete_time datetime,
	@emp_no int,
	@carry_out int,
	@training_mode int,
	@archive_date datetime,
	@upload_date datetime,
	@replication_date datetime
	
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
insert into trans values
(
	@trans_id,
	@store_no,
	@organization_no,
	@pos_no,
	@drawer_no,
	@config_no,
	@trans_type,
	@state,
	@reason_code,
	@customer_no,
	@start_time,
	@complete_time,
	@emp_no,
	@carry_out,
	@training_mode,
	@archive_date,
	@upload_date,
	@replication_date
)



GO

GRANT EXEC ON Add_Trans TO PUBLIC

GO



/* Add_trans_promotion */
IF EXISTS (SELECT * FROM sysobjects WHERE type = 'P' AND name = 'Add_Trans_Promotion')
	BEGIN
		PRINT 'Dropping Procedure Add_Trans_Promotion'
		DROP  Procedure  Add_Trans_Promotion
	END

GO

PRINT 'Creating Procedure Add_Trans_Promotion'
GO
CREATE Procedure Add_Trans_Promotion
	/* Param List */
	@trans_id int,
	@seq_no int,
	@line_no int,
	@promotion_no int,
	@promotion_type int,
	@promotion_amount decimal(15,2),
	@promotion_quantity decimal(15,3),
	@reason_code int,
	@promotion_data varchar(100),
	@promotion_desc varchar(100),
	@state int
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
insert into trans_promotion values
(
@trans_id,
@seq_no,
@line_no,
@promotion_no,
@promotion_type,
@promotion_amount,
@promotion_quantity,
@reason_code,
@promotion_data,
@promotion_desc,
@state
)
GO

GRANT EXEC ON Add_Trans_Promotion TO PUBLIC

GO


IF EXISTS (SELECT * FROM sysobjects WHERE type = 'P' AND name = 'Add_TransBank')
	BEGIN
		PRINT 'Dropping Procedure Add_TransBank'
		DROP  Procedure  Add_TransBank
	END

GO

PRINT 'Creating Procedure Add_TransBank'
GO
CREATE Procedure Add_TransBank
	/* Param List */
	@trans_id int,
	@seq_no int,
	@pay_type int,
	@deposit_no int,
	@state int,
	@drawer_no int,
	@bank_desc varchar(100),
	@locale_language varchar(2),
	@locale_country varchar(2),
	@amount decimal(15,2) 
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
insert into trans_bank values
(
@trans_id,
@seq_no,
@pay_type,
@deposit_no,
@state,
@drawer_no,
@bank_desc,
@locale_language,
@locale_country,
@amount 
)
GO

GRANT EXEC ON Add_TransBank TO PUBLIC

GO

/* Add Trans Item */

IF EXISTS (SELECT * FROM sysobjects WHERE type = 'P' AND name = 'Add_Trans_item')
	BEGIN
		PRINT 'Dropping Procedure Add_Trans_item'
		DROP  Procedure  Add_Trans_item
	END

GO

PRINT 'Creating Procedure Add_Trans_item'
GO
CREATE Procedure Add_Trans_item
	/* Param List */
	@trans_id int,
	@seq_no int,
	@line_no int,
	@sku varchar(20),
	@sku_link varchar(20),
	@quantity decimal(15,3),
	@amount decimal(15,2),
	@ext_amount decimal(15,2),
	@weight decimal(15,2),
	@item_desc varchar(100),
	@state int,
	@reason_code int,
	@tax_exempt int,
	@tax_incl int,
	@var_amount decimal(15,2)
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
insert into trans_item values
(
@trans_id,
@seq_no,
@line_no,
@sku,
@sku_link,
@quantity,
@amount,
@ext_amount,
@weight,
@item_desc,
@state,
@reason_code,
@tax_exempt,
@tax_incl,
@var_amount
)

GO

GRANT EXEC ON Add_Trans_item TO PUBLIC



/* Add_TransTax */
IF EXISTS (SELECT * FROM sysobjects WHERE type = 'P' AND name = 'Add_TransTax')
	BEGIN
		PRINT 'Dropping Procedure Add_TransTax'
		DROP  Procedure  Add_TransTax
	END

GO

PRINT 'Creating Procedure Add_TransTax'
GO
CREATE Procedure Add_TransTax
	/* Param List */
	@trans_id int,
	@seq_no int,
	@line_no int,
	@tax_id int,
	@tax_desc varchar(30),
	@rate decimal(15,2),
	@taxable_amount decimal(15,2),
	@tax_amount decimal(15,2),
	@state int
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
insert into trans_tax
values
(
@trans_id,
@seq_no,
@line_no,
@tax_id,
@tax_desc,
@rate,
@taxable_amount,
@tax_amount,
@state
)


GO

GRANT EXEC ON Add_TransTax TO PUBLIC

GO



/* Add TransTender */

IF EXISTS (SELECT * FROM sysobjects WHERE type = 'P' AND name = 'Add_Trans_tender')
	BEGIN
		PRINT 'Dropping Add_Trans_tender'
		DROP  Procedure Add_Trans_tender
	END
 
GO

PRINT 'Creating Procedure Add_Trans_tender'
GO
CREATE Procedure Add_Trans_tender
	/* Param List */
	@trans_id int,
	@seq_no int,
	@tendertype int,
	@amount decimal(15,2),
	@change_amount decimal(15,2),
	@tender_desc varchar(100),
	@change_desc varchar(100),
	@locale_language varchar(2),
	@locale_country varchar(2),
	@data_capture varchar(100),
	@state int
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

insert into trans_tender values
(
@trans_id,
@seq_no,
@tendertype,
@amount,
@change_amount,
@tender_desc,
@change_desc,
@locale_language,
@locale_country,
@data_capture,
@state
)



GO

GRANT EXEC ON Add_Trans_tender TO PUBLIC

GO


/* Delete Totals */

IF EXISTS (SELECT * FROM sysobjects WHERE type = 'P' AND name = 'Delete_Total')
	BEGIN
		PRINT 'Dropping Procedure Delete_Total'
		DROP  Procedure  Delete_Total
	END

GO

PRINT 'Creating Procedure Delete_Total'
GO
CREATE Procedure Delete_Total
	/* Param List */
	@total_id int
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

delete from total where total_id = @total_id


GO

GRANT EXEC ON Delete_Total TO PUBLIC

GO


/* Load All items by SKU */
IF EXISTS (SELECT * FROM sysobjects WHERE type = 'P' AND name = 'Load_All_Items')
	BEGIN
		PRINT 'Dropping Procedure Load_All_Items'
		DROP  Procedure  Load_All_Items
	END

GO

PRINT 'Creating Procedure Load_All_Items'
GO
CREATE Procedure Load_All_Items
	/* Param List */
	@sku varchar(20)
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
where sku like  @sku



GO

GRANT EXEC ON Load_All_Items TO PUBLIC

GO


/*Load BOMao */

IF EXISTS (SELECT * FROM sysobjects WHERE type = 'P' AND name = 'Load_BoMap_By_Parent')
	BEGIN
		PRINT 'Dropping Procedure Load_BoMap_By_Parent'
		DROP  Procedure  Load_BoMap_By_Parent
	END

GO

PRINT 'Creating Procedure Load_BoMap_By_Parent'
GO
CREATE Procedure Load_BoMap_By_Parent
	/* Param List */
	@parent_bo_id int,
	@pobj_type int
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

Select * from bo_map where parent_bo_id = @parent_bo_id
and pobj_type = @pobj_type

GO

GRANT EXEC ON Load_BoMap_By_Parent TO PUBLIC

GO





/* Load Bu_by_BUid */

IF EXISTS (SELECT * FROM sysobjects WHERE type = 'P' AND name = 'Load_Bu_By_Buid')
	BEGIN
		PRINT 'Dropping Procedure Load_Bu_By_Buid'
		DROP  Procedure  Load_Bu_By_Buid
	END

GO

PRINT 'Creating Procedure Load_Bu_By_Buid'
GO
CREATE Procedure Load_Bu_By_Buid
	/* Param List */
	@bu_id int,
	@bu_desc varchar(32) output,
	@create_date datetime output 
	
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

select 
@bu_id = bu_id,
@bu_desc = bu_desc,
@create_date = create_date
from bu 
where bu_id = @bu_id


return 


GO

GRANT EXEC ON Load_Bu_By_Buid TO PUBLIC

GO


/* Load Currency */
IF EXISTS (SELECT * FROM sysobjects WHERE type = 'P' AND name = 'Load_Currency_By_Currency_code_id')
	BEGIN
		PRINT 'Dropping Procedure Load_Currency_By_Currency_code_id'
		DROP  Procedure  Load_Currency_By_Currency_code_id
	END

GO

PRINT 'Creating Procedure Load_Currency_By_Currency_code_id'
GO
CREATE Procedure Load_Currency_By_Currency_code_id
	/* Param List */
	@currency_id int output,
	@organization_no int,
	@currency_code_id int,
	@conversion_rate decimal(15,5) output,
	@smallest_denom int output,
	@decimal_digits int output,
	@locale varchar(32) output,
	@is_base int output,
	@is_local int output,
	@last_update datetime output,
	@currency_class varchar(100) output
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
  

select
@currency_id = currency_id,
@organization_no = organization_no,
@currency_code_id = currency_code_id,
@conversion_rate = conversion_rate,
@smallest_denom = smallest_denom,
@decimal_digits = decimal_digits,
@locale = locale,
@is_base = is_base,
@is_local = is_local,
@last_update = last_update,
@currency_class = currency_class
from currency where organization_no = @organization_no and currency_code_id = @currency_code_id

GO

GRANT EXEC ON Load_Currency_By_Currency_code_id TO PUBLIC

GO


/* Load dialog by config no */

IF EXISTS (SELECT * FROM sysobjects WHERE type = 'P' AND name = 'Load_Dialog_By_ConfigNo')
	BEGIN
		PRINT 'Dropping Procedure Load_Dialog_By_ConfigNo'
		DROP  Procedure  Load_Dialog_By_ConfigNo
	END

GO

PRINT 'Creating Procedure Load_Dialog_By_ConfigNo'
GO
CREATE Procedure Load_Dialog_By_ConfigNo
	@config_no int
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

select * from dialog where config_no = @config_no

--return

GO

GRANT EXEC ON Load_Dialog_By_ConfigNo TO PUBLIC

GO


/* Load dialog by dialog name */
IF EXISTS (SELECT * FROM sysobjects WHERE type = 'P' AND name = 'Load_Dialog_By_DialogName')
	BEGIN
		PRINT 'Dropping Procedure Load_Dialog_By_DialogName'
		DROP  Procedure  Load_Dialog_By_DialogName
	END

GO

PRINT 'Creating Procedure Load_Dialog_By_DialogName'
GO
CREATE Procedure Load_Dialog_By_DialogName
	@dialog_id int output,
	@config_no int,
	@help_id	int output,
	@dialog_type int output,
	@dialog_name varchar(50) /* Param List */
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
select 
	@dialog_id = dialog_id,
	@config_no = config_no,
	@help_id = help_id,
	@dialog_type = dialog_type,
	@dialog_name =	dialog_name	
	from dialog 
where dialog_name = @dialog_name and config_no = @config_no


GO

GRANT EXEC ON Load_Dialog_By_DialogName TO PUBLIC

GO

/* Load Dialog Events */

IF EXISTS (SELECT * FROM sysobjects WHERE type = 'P' AND name = 'Load_DialogEvent_By_DialogID')
	BEGIN
		PRINT 'Dropping Procedure Load_DialogEvent_By_DialogID'
		DROP  Procedure  Load_DialogEvent_By_DialogID
	END

GO

PRINT 'Creating Procedure Load_DialogEvent_By_DialogID'
GO
CREATE Procedure Load_DialogEvent_By_DialogID
	@dialog_id int
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

select * from dialog_event where dialog_id = @dialog_id
order by dialog_id, dialog_seq

--return
 
GO

GRANT EXEC ON Load_DialogEvent_By_DialogID TO PUBLIC

GO

  
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
@logon_no 	int ,
@logon_pass	 	int output,
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

GRANT EXEC ON Load_Employee_by_Logon TO PUBLIC

GO


/* Load input filter */

IF EXISTS (SELECT * FROM sysobjects WHERE type = 'P' AND name = 'Load_Input_Filter_By_Filter_Type')
	BEGIN
		PRINT 'Dropping Procedure Load_Input_Filter_By_Filter_Type'
		DROP  Procedure  Load_Input_Filter_By_Filter_Type
	END

GO

PRINT 'Creating Procedure Load_Input_Filter_By_Filter_Type'
GO
CREATE Procedure Load_Input_Filter_By_Filter_Type
	/* Param List */
	@filter_type int
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

select * from input_filter where filter_type = @filter_type

GO

GRANT EXEC ON Load_Input_Filter_By_Filter_Type TO PUBLIC

GO


/* Load Input filter field */
IF EXISTS (SELECT * FROM sysobjects WHERE type = 'P' AND name = 'Load_Input_Filter_Field_By_Filter_Id')
	BEGIN
		PRINT 'Dropping Procedure Load_Input_Filter_Field_By_Filter_Id'
		DROP  Procedure  Load_Input_Filter_Field_By_Filter_Id
	END

GO

PRINT 'Creating Procedure Load_Input_Filter_Field_By_Filter_Id'
GO
CREATE Procedure Load_Input_Filter_Field_By_Filter_Id
	/* Param List */
	@filter_id int
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

select * from input_filter_field where filter_id = @filter_id


GO

GRANT EXEC ON Load_Input_Filter_Field_By_Filter_Id TO PUBLIC

GO


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
	@short_desc varchar(50)
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


GO

GRANT EXEC ON Load_Item_By_Desc TO PUBLIC

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
	@organization_no int output,
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

return

end


GO

GRANT EXEC ON Load_Item_By_Plu TO PUBLIC

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

return

end

GO

GRANT EXEC ON Load_Item_By_SKU TO PUBLIC

GO



/* Load Menu Config by Menu Id */
 IF EXISTS (SELECT * FROM sysobjects WHERE type = 'P' AND name = 'Load_Menu_Config_By_Menu_Id')
	BEGIN
		PRINT 'Dropping Procedure Load_Menu_Config_By_Menu_Id'
		DROP  Procedure  Load_Menu_Config_By_Menu_Id
	END

GO

PRINT 'Creating Procedure Load_Menu_Config_By_Menu_Id'
GO
CREATE Procedure Load_Menu_Config_By_Menu_Id
	/* Param List */
	@config_no int,
	@menu_id int 
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

select * from
menu_config
where 
config_no = @config_no and
menu_id = @menu_id  

return

end

GO

GRANT EXEC ON Load_Menu_Config_By_Menu_Id TO PUBLIC

GO


/* Load Menu Panels */
 IF EXISTS (SELECT * FROM sysobjects WHERE type = 'P' AND name = 'Load_Menu_Panels_By_Config_no')
	BEGIN
		PRINT 'Dropping Procedure Stored_Procedure_Name'
		DROP  Procedure  Load_Menu_Panels_By_Config_no
	END

GO

PRINT 'Creating Procedure Load_Menu_Panels_By_Config_no'
GO
CREATE Procedure Load_Menu_Panels_By_Config_no
	/* Param List */
	@config_no int
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


select * 
from 
menu_panels
where config_no = @config_no

return

GO

GRANT EXEC ON Load_Menu_Panels_By_Config_no TO PUBLIC

GO




/*Load Menus by Config no */

IF EXISTS (SELECT * FROM sysobjects WHERE type = 'P' AND name = 'Load_Menus_By_Config_No')
	BEGIN
		PRINT 'Dropping Procedure Load_Menus_By_Config_No'
		DROP  Procedure  Load_Menus_By_Config_No
	END

GO

PRINT 'Creating Procedure Load_Menus_By_Config_No'
GO
CREATE Procedure Load_Menus_By_Config_No
	@config_no int
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

select *
from menu_root
where config_no = @config_no


GO

GRANT EXEC ON Load_Menus_By_Config_No TO PUBLIC

GO



/* Load Pos Config By Config Name */
IF EXISTS (SELECT * FROM sysobjects WHERE type = 'P' AND name = 'Load_Pos_Config_By_Config_Name')
	BEGIN
		PRINT 'Dropping Procedure Load_Pos_Config_By_Config_Name'
		DROP  Procedure  Load_Pos_Config_By_Config_Name
	END

GO

PRINT 'Creating Procedure Load_Pos_Config_By_Config_Name'
GO
CREATE Procedure Load_Pos_Config_By_Config_Name
	/* Param List */
	@config_no int output,
	@name varchar(50)
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

select
@config_no = config_no,
@name = name
from pos_config
where name = @name


GO

GRANT EXEC ON Load_Pos_Config_By_Config_Name TO PUBLIC

GO


/* Load Pos Param */
IF EXISTS (SELECT * FROM sysobjects WHERE type = 'P' AND name = 'Load_pos_param')
	BEGIN
		PRINT 'Dropping Procedure Load_pos_param'
		DROP  Procedure  Load_pos_param
	END

GO

PRINT 'Creating Procedure Load_pos_param'
GO
CREATE Procedure Load_pos_param
	/* Param List */
	@param_id int output,
	@config_no int output,
	@param_type int output,
	@cache_flag int output,
	@help_id int output,
	@param_name varchar(100),
	@param_value varchar(100) output
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
select 
@param_id = param_id,
@config_no = config_no,
@param_type = param_type,
@cache_flag = cache_flag,
@help_id = help_id,
@param_name = param_name,
@param_value = param_value
from pos_param
where 
param_name = @param_name


GO

GRANT EXEC ON Load_pos_param TO PUBLIC

GO


/* Load pos param by config no */
 
IF EXISTS (SELECT * FROM sysobjects WHERE type = 'P' AND name = 'Load_pos_param_by_config_no')
	BEGIN
		PRINT 'Dropping Procedure Load_pos_param_by_config_no'
		DROP  Procedure  Load_pos_param_by_config_no
	END

GO

PRINT 'Creating Procedure Load_pos_param_by_config_no'
GO
CREATE Procedure Load_pos_param_by_config_no
	/* Param List */
	@config_no int
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

select *
from pos_param
where config_no = @config_no


GO

GRANT EXEC ON Load_pos_param_by_config_no TO PUBLIC

GO


/* Load pos Total */
IF EXISTS (SELECT * FROM sysobjects WHERE type = 'P' AND name = 'Load_Pos_Total')
	BEGIN
		PRINT 'Dropping Procedure Load_Pos_Total'
		DROP  Procedure  Load_Pos_Total
	END

GO

PRINT 'Creating Procedure Load_Pos_Total'
GO
CREATE Procedure Load_Pos_Total
	/* Param List */
	@store_id int,
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

select * from pos_total where store_id = @store_id and pos_no = @pos_no


GO

GRANT EXEC ON Load_Pos_Total TO PUBLIC

GO


/* Load Pos Config */
IF EXISTS (SELECT * FROM sysobjects WHERE type = 'P' AND name = 'Load_PosConfig_by_Name')
	BEGIN
		PRINT 'Dropping Procedure Load_PosConfig_by_Name'
		DROP  Procedure Load_PosConfig_by_Name  
	END

GO

PRINT 'Creating Procedure Load_PosConfig_by_Name'
GO
CREATE Procedure Load_PosConfig_by_Name
	/* Param List */
	@config_no int output,
	@name varchar(50),
	@retail_store_group_id int output
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
select config_no=@config_no, name = @name, retail_store_group_id = @retail_store_group_id 
from pos_config
where @name = name

GO

/* Load posConfig by ConfigNo */


GRANT EXEC ON Load_PosConfig_by_ConfigNo  TO PUBLIC

GO

IF EXISTS (SELECT * FROM sysobjects WHERE type = 'P' AND name = 'Load_PosConfig_by_ConfigNo')
	BEGIN
		PRINT 'Dropping Procedure Load_PosConfig_by_ConfigNo'
		DROP  Procedure Load_PosConfig_by_ConfigNo  
	END

GO

PRINT 'Creating Procedure Load_PosConfig_by_ConfigNo'
GO
CREATE Procedure Load_PosConfig_by_ConfigNo
	/* Param List */
	@config_no int,
	@name varchar(50)output
	
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
select config_no=@config_no, name = @name
from pos_config
where @config_no = config_no

GO

GRANT EXEC ON Load_PosConfig_by_ConfigNo  TO PUBLIC

GO



/* Load Pos Key */
IF EXISTS (SELECT * FROM sysobjects WHERE type = 'P' AND name = 'Load_PosKey_By_Panel_id')
	BEGIN
		PRINT 'Dropping Procedure Load_PosKey_By_Panel_id'
		DROP  Procedure  Load_PosKey_By_Panel_id
	END

GO

PRINT 'Creating Procedure Load_PosKey_By_Panel_id'
GO
CREATE Procedure Load_PosKey_By_Panel_id
@config_no int,
@panel_id	int

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

select *
from pos_key 
where panel_id  = @panel_id	and config_no = @config_no

return 

end


GO

GRANT EXEC ON Load_PosKey_By_Panel_id TO PUBLIC

GO



/* Load Promotion by Promotion number */
IF EXISTS (SELECT * FROM sysobjects WHERE type = 'P' AND name = 'Load_Promotion_By_Promotion_No')
	BEGIN
		PRINT 'Dropping Load_Promotion_By_Promotion_No'
		DROP  Procedure  Load_Promotion_By_Promotion_No
	END

GO

PRINT 'Creating Procedure Load_Promotion_By_Promotion_No'
GO
CREATE Procedure Load_Promotion_By_Promotion_No
	/* Param List */
	@promotion_id int output,
	@config_no int,
	@promotion_no int,
	@promotion_type int output,
	@promotion_val1 int output,
	@promotion_val2 int output,
	@promotion_val3 int output,
	@promotion_val4 int output,
	@promotion_val5 int output,
	@promotion_dval1 decimal(15,2) output,
	@promotion_dval2 decimal(15,2) output,
	@promotion_dval3 decimal(15,2) output,
	@promotion_dval4 decimal(15,2)  output,
	@promotion_dval5 decimal(15,2) output,
	@print_before_item int output,
	@valid_times varchar(12) output,
	@valid_days varchar(12) output,
	@promotion_string varchar(100) output,
	@promotion_class varchar(100) output
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
select 

	@promotion_id = promotion_id,
	@config_no = config_no,
	@promotion_no = promotion_no,
	@promotion_type = promotion_type,
	@promotion_val1 = promotion_val1,
	@promotion_val2  = promotion_val2,
	@promotion_val3  = promotion_val3,
	@promotion_val4  = promotion_val4,
	@promotion_val5 = promotion_val5,
	@promotion_dval1 = promotion_dval1,
	@promotion_dval2 = promotion_dval2,
	@promotion_dval3 = promotion_dval3,
	@promotion_dval4 = promotion_dval4,
	@promotion_dval5 = promotion_dval5,
	@print_before_item = print_before_item,
	@valid_times = valid_times,
	@valid_days  = valid_days,
	@promotion_string = promotion_string,
	@promotion_class  = promotion_class
	
from promotion where @promotion_no = promotion_no and @config_no=config_no	

GO

GRANT EXEC ON Load_Promotion_By_Promotion_No TO PUBLIC

GO


/* Load Promotion Map */
IF EXISTS (SELECT * FROM sysobjects WHERE type = 'P' AND name = 'Load_PromotionMap_By_Map')
	BEGIN
		PRINT 'Dropping Procedure Load_PromotionMap_By_Map'
		DROP  Procedure  Load_PromotionMap_By_Map
	END

GO

PRINT 'Creating Procedure Load_PromotionMap_By_Map'
GO
CREATE Procedure Load_PromotionMap_By_Map
	/* Param List */
	@promotion_map varchar(20)
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
select * from promotion_map where promotion_map = @promotion_map



GO

GRANT EXEC ON Load_PromotionMap_By_Map TO PUBLIC

GO


/* Add Retatil Store */

IF EXISTS (SELECT * FROM sysobjects WHERE type = 'P' AND name = 'Add_RetailStore')
	BEGIN
		PRINT 'Dropping Procedure Add_RetailStore'
		DROP  Procedure  Add_RetailStore
	END

GO

PRINT 'Creating Procedure Add_RetailStore'
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

Create Proc Add_RetailStore 
(
@store_no		int 		,
@organization_no int,
@store_name 	varchar(40) 	,
@closing_date	 	datetime 	,
@open_date		datetime 	,
@selling_area_size	decimal(15,2)	,
@size	    	   	decimal(15,2)	,
@address1		varchar(40)	,
@address2		varchar(40)	, 	
@address3		varchar(40)	,
@address4		varchar(40)	,
@address5		varchar(40)	,
@postal_code		varchar(15)	,
@phone			varchar(20)	, 
@ip			varchar(20)	,
@port_number		varchar(20),
@last_trans_no	int	
)

as 

begin

	insert into retail_store values (
			@store_no,
			@organization_no,
			@store_name,
			@closing_date,
			@open_date,
			@selling_area_size,
			@size,
			@address1,
			@address2, 	
			@address3,
			@address4,				
			@address5,
			@postal_code,
			@phone, 
			@ip,
			@port_number,
			@last_trans_no
	)
		

return 

end



GO

GRANT EXEC ON Add_RetailStore TO PUBLIC

GO


/* Load Retail Store by Retail Store Id */


IF EXISTS (SELECT * FROM sysobjects WHERE type = 'P' AND name = 'Load_Retail_Store_By_Retail_Store_no')
	BEGIN
		PRINT 'Dropping Procedure Load_RetailStore_By_Retail_Store_no'
		DROP  Procedure  Load_Retail_Store_By_Retail_Store_no
	END

GO

PRINT 'Creating Procedure Load_Retail_Store_By_Retail_Store_no'

GO

CREATE Procedure Load_Retail_Store_By_Retail_Store_no
	/* Param List */ 
	@store_no int,
	@organization_no int,
	@store_name varchar(40) output,
	@closing_date	datetime	output,
	@open_date		datetime	output,
	@selling_area_size	decimal(9)	output,
	@size	decimal(9)	output,
	@address1	varchar(40)	output,					
	@address2	varchar(40)	output,
	@address3	varchar(40)	output,
	@address4	varchar(40)	output,
	@address5	varchar(40)	output,
	@postal_code	varchar(15)	output,
	@phone	varchar(20)	output,
	@ip	varchar(20)	output,
	@port_number	varchar(20)	output,
	@last_trans_no	int		output
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

select 
	@store_no = store_no,
	@store_name = store_name,
	@closing_date = closing_date,
	@open_date = open_date,
	@selling_area_size =	selling_area_size,
	@size = size,
	@address1 = address1,
	@address2 = address2,
	@address3 = address3,
	@address4 = address4,
	@address5 = address5,
	@postal_code = postal_code,
	@phone = phone,
	@ip = ip,
	@port_number = port_number,
	@last_trans_no = last_trans_no	
	from retail_store 
where store_no = @store_no 
and organization_no = @organization_no

return

GO
 
GRANT EXEC ON Load_Retail_Store_By_Retail_Store_no TO PUBLIC

GO




/* Save Retail Store */
IF EXISTS (SELECT * FROM sysobjects WHERE type = 'P' AND name = 'Save_Retail_Store_By_Retail_store_no')
	BEGIN
		PRINT 'Dropping Procedure Save_Retail_Store_By_Retail_store_no'
		DROP  Procedure  Save_Retail_Store_By_Retail_store_no
	END

GO

PRINT 'Creating Procedure Save_Retail_Store_By_Retail_store_no'
GO
CREATE Procedure Save_Retail_Store_By_Retail_store_no
	/* Param List */
	@store_no int,
	@organization_no int,
	@last_trans_no	int
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
update retail_store
set  
last_trans_no = @last_trans_no	
where store_no = @store_no
and organization_no = @organization_no



GO

GRANT EXEC ON Save_Retail_Store_By_Retail_store_no TO PUBLIC

GO




/* Load subsriber by subscriber name */
IF EXISTS (SELECT * FROM sysobjects WHERE type = 'P' AND name = 'Load_Sub_By_Subscriber_Name')
	BEGIN
		PRINT 'Dropping Procedure Load_Sub_By_Subscriber_Name'
		DROP  Procedure  Load_Sub_By_Subscriber_Name
	END

GO

PRINT 'Creating Procedure Load_Sub_By_Subscriber_Name'
GO
CREATE Procedure Load_Sub_By_Subscriber_Name
	/* Param List */
	@subscriber_id int output,
	@subscriber_name varchar(32),
	@subscriber_pass varchar(32) output
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
select 
@subscriber_id = subscriber_id,
@subscriber_name = subscriber_name,
@subscriber_pass = subscriber_pass 
from sub
where 
@subscriber_name = subscriber_name



GO

GRANT EXEC ON Load_Sub_By_Subscriber_Name TO PUBLIC

GO


/*Load sub map by Subscriber */
IF EXISTS (SELECT * FROM sysobjects WHERE type = 'P' AND name = 'Load_Sub_Map_By_Subsriberid')
	BEGIN
		PRINT 'Dropping Procedure Load_Sub_Map_By_Subsriberid'
		DROP  Procedure  Load_Sub_Map_By_Subsriberid
	END

GO

PRINT 'Creating Procedure Load_Sub_Map_By_Subsriberid'
GO
CREATE Procedure Load_Sub_Map_By_Subsriberid
	/* Param List */
	@subscriber_id int
	
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

select * from sub_map where subscriber_id = @subscriber_id


GO

GRANT EXEC ON Load_Sub_Map_By_Subsriberid TO PUBLIC

GO


/*Load sub menu by menuid */
IF EXISTS (SELECT * FROM sysobjects WHERE type = 'P' AND name = 'Load_SubMenu_By_MenuID')
	BEGIN
		PRINT 'Dropping Procedure Load_SubMenu_By_MenuID'
		DROP  Procedure  Load_SubMenu_By_MenuID
	END

GO

PRINT 'Creating Procedure Load_SubMenu_By_MenuID'
GO
CREATE Procedure Load_SubMenu_By_MenuID
	@menu_id		int		
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
-- begin

	select 
		* 
	from sub_menu
	where menu_id = @menu_id
	
	
-- return
-- end 
GO

GRANT EXEC ON Load_SubMenu_By_MenuID TO PUBLIC

GO

IF EXISTS (SELECT * FROM sysobjects WHERE type = 'P' AND name = 'Load_Tax_By_Tax_Group_Id')
	BEGIN
		PRINT 'Dropping Procedure Load_Tax_By_Tax_Group_Id'
		DROP  Procedure  Load_Tax_By_Tax_Group_Id
	END

GO

PRINT 'Creating Procedure Load_Tax_By_Tax_Group_Id'
GO
CREATE Procedure Load_Tax_By_Tax_Group_Id
	/* Param List */
	@tax_group_id int
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
select * from tax
where tax_group_id = @tax_group_id

GO

GRANT EXEC ON Load_Tax_By_Tax_Group_Id TO PUBLIC

GO


/* Load Tax group by config no */
IF EXISTS (SELECT * FROM sysobjects WHERE type = 'P' AND name = 'Load_Tax_Group_By_Organization_id')
	BEGIN
		PRINT 'Dropping Procedure Load_Tax_Group_By_Organization_id'
		DROP  Procedure  Load_Tax_Group_By_Organization_id
	END

GO

PRINT 'Creating Procedure Load_Tax_Group_By_Organization_id'
GO
CREATE Procedure Load_Tax_Group_By_Organization_id
	/* Param List */
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

select * from tax_group
where organization_no = @organization_no


GO

GRANT EXEC ON Load_Tax_Group_By_Organization_id TO PUBLIC

GO


/* Load totals by total id*/
IF EXISTS (SELECT * FROM sysobjects WHERE type = 'P' AND name = 'Load_Total_By_Total_id')
	BEGIN
		PRINT 'Dropping Procedure Load_Total_By_Total_id'
		DROP  Procedure  Load_Total_By_Total_id
	END

GO

PRINT 'Creating Procedure Load_Total_By_Total_id'
GO
CREATE Procedure Load_Total_By_Total_id
	/* Param List */
	@total_id int
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

select * from total where total_id = @total_id


GO

GRANT EXEC ON Load_Total_By_Total_id TO PUBLIC

GO


/* Load trans bank by trans id */

IF EXISTS (SELECT * FROM sysobjects WHERE type = 'P' AND name = 'Load_Trans_Bank_By_Trans_id')
	BEGIN
		PRINT 'Dropping Procedure Load_Trans_Bank_By_Trans_id'
		DROP  Procedure  Load_Trans_Bank_By_Trans_id
	END

GO

PRINT 'Creating Procedure Load_Trans_Bank_By_Trans_id'
GO
CREATE Procedure Load_Trans_Bank_By_Trans_id
	/* Param List */
	@trans_id int
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
select * from trans_bank where trans_id = @trans_id


GO

GRANT EXEC ON Load_Trans_Bank_By_Trans_id TO PUBLIC

GO


/* Load Trans by Trans no */
IF EXISTS (SELECT * FROM sysobjects WHERE type = 'P' AND name = 'Load_Trans_By_Trans_id')
	BEGIN
		PRINT 'Dropping Procedure Load_Trans_By_Trans_id'
		DROP  Procedure  Load_Trans_By_Trans_id
	END

GO

PRINT 'Creating Procedure Load_Trans_By_Trans_id'
GO
CREATE Procedure Load_Trans_By_Trans_id
	/* Param List */
	@trans_no int output,
	@trans_id int,
	@store_no int,
	@organization_no int,
	@pos_no int,
	@drawer_no int output,
	@config_no int output,
	@trans_type int output,
	@state int output,
	@reason_code int output,
	@customer_no varchar(20) output,
	@start_time datetime output,
	@complete_time datetime output,
	@emp_no int output,
	@carry_out int output,
	@training_mode int output,
	@archive_date datetime output,
	@upload_date datetime output,
	@replication_date datetime output
	
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

select
	@trans_no = trans_no,
	@trans_id  = trans_id,
	@store_no  = store_no,
	@organization_no = organization_no,
	@pos_no = pos_no,
	@drawer_no =  drawer_no,
	@config_no = config_no,
	@trans_type =  trans_type,
	@state = state,
	@reason_code = reason_code,
	@customer_no = customer_no,
	@start_time = start_time,
	@complete_time = complete_time,
	@emp_no  = emp_no,
	@carry_out = carry_out,
	@training_mode = training_mode,
	@archive_date = archive_date,
	@upload_date = upload_date,
	@replication_date = replication_date

from trans
where trans_id = @trans_id
and store_no = @store_no
and pos_no = @pos_no
and organization_no = @organization_no


GO

GRANT EXEC ON Load_Trans_By_Trans_id TO PUBLIC

GO


/* Load Trans Promotion by Trans id */ 

 IF EXISTS (SELECT * FROM sysobjects WHERE type = 'P' AND name = 'Load_Trans_Promotion_By_Trans_Id')
	BEGIN
		PRINT 'Dropping Procedure Load_Trans_Promotion_By_Trans_Id'
		DROP  Procedure  Load_Trans_Promotion_By_Trans_Id
	END

GO

PRINT 'Creating Procedure Load_Trans_Promotion_By_Trans_Id'
GO
CREATE Procedure Load_Trans_Promotion_By_Trans_Id
	/* Param List */
	@trans_id int
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

select * from trans_promotion where trans_id = @trans_id


GO

GRANT EXEC ON Load_Trans_Promotion_By_Trans_Id TO PUBLIC

GO



/* Load Trans Tax */
IF EXISTS (SELECT * FROM sysobjects WHERE type = 'P' AND name = 'Load_Trans_Tax_By_Trans_id')
	BEGIN
		PRINT 'Dropping Procedure Load_Trans_Tax_By_Trans_id'
		DROP  Procedure  Load_Trans_Tax_By_Trans_id
	END

GO

PRINT 'Creating Procedure Load_Trans_Tax_By_Trans_id'
GO
CREATE Procedure Load_Trans_Tax_By_Trans_id
	/* Param List */
	@trans_id int
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

select * from trans_tax where trans_id = @trans_id

GO

GRANT EXEC ON Load_Trans_Tax_By_Trans_id TO PUBLIC

GO



/* Update_Trans_Tax */

IF EXISTS (SELECT * FROM sysobjects WHERE type = 'P' AND name = 'Update_TransTax')
	BEGIN
		PRINT 'Dropping Procedure Update_TransTax'
		DROP  Procedure  Update_TransTax
	END

GO

PRINT 'Creating Procedure Update_TransTax'
GO
CREATE Procedure Update_TransTax
	/* Param List */
	@trans_id int,
	@seq_no int,
	@taxable_amount decimal(20,2),
	@tax_amount decimal(10,2),
	@state int
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

update trans_tax
set 
taxable_amount = @taxable_amount,
tax_amount = @tax_amount,
state = @state
where trans_id = @trans_id and seq_no = @seq_no

GO




/* Load Trans Tender */

IF EXISTS (SELECT * FROM sysobjects WHERE type = 'P' AND name = 'Load_Trans_Tender_By_Transid')
	BEGIN
		PRINT 'Dropping Procedure Load_Trans_Tender_By_Transid'
		DROP  Procedure  Load_Trans_Tender_By_Transid
	END

GO

PRINT 'Creating Procedure Load_Trans_Tender_By_Transid'
GO
CREATE Procedure Load_Trans_Tender_By_Transid
	/* Param List */
	@trans_id int
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
select * from trans_tender where trans_id = @trans_id


GO

GRANT EXEC ON  Load_Trans_Tender_By_Transid TO PUBLIC

GO

/* Load Trans Item */

IF EXISTS (SELECT * FROM sysobjects WHERE type = 'P' AND name = 'Load_TransItem_By_Trans_no')
	BEGIN
		PRINT 'Dropping Procedure Load_TransItem_By_Trans_no'
		DROP  Procedure  Load_TransItem_By_Trans_no
	END

GO

PRINT 'Creating Procedure Load_TransItem_By_Trans_no'
GO
CREATE Procedure Load_TransItem_By_Trans_no
	/* Param List */
	@trans_id int
	
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
select * from trans_item
where trans_id = @trans_id



GO

GRANT EXEC ON Load_TransItem_By_Trans_no TO PUBLIC

GO

/*
IF EXISTS (SELECT * FROM sysobjects WHERE type = 'P' AND name = 'Save_RetailStore_By_Retail_Store_no')
	BEGIN
		PRINT 'Dropping Procedure Save_RetailStore_By_Retail_Store_no'
		DROP  Procedure  Save_RetailStore_By_Retail_Store_no
	END

GO

PRINT 'Creating Procedure Save_RetailStore_By_Retail_Store_no'
GO
CREATE Procedure Save_RetailStore_By_Retail_Store_no
	 Param List 
	@Retail_Store_no int,
	@RetailStoreName varchar(40),
	@ClosingDate	datetime,
	@OpenDate		datetime,
	@organization_no int,
	@SellingAreaSize	decimal(9),
	@Size	decimal(9),
	@Address1	varchar(40),					
	@Address2	varchar(40),
	@Address3	varchar(40),
	@Address4	varchar(40),
	@Address5	varchar(40),
	@PostalCode	varchar(15),
	@Phone	varchar(20),
	@Ip	varchar(20),
	@PortNumber	varchar(20),
	@Last_trans_no	int
AS
*/
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
/*
update RetailStore
set  
RetailStoreName = @RetailStoreName,
ClosingDate = @ClosingDate,
OpenDate = @OpenDate,
organization_no = @organization_no,
SellingAreaSize =	@SellingAreaSize,
Size = @Size,
Address1 = @Address1,
Address2 = @Address2,
Address3 = @Address3,
Address4 = @Address4,
Address5 = @Address5,
PostalCode = @PostalCode,
Phone = @Phone,
Ip = @Ip,
PortNumber = @PortNumber,
Last_trans_no = @Last_trans_no	
where Retail_Store_no = @Retail_Store_no



GO

GRANT EXEC ON Save_RetailStore_By_Retail_Store_no TO PUBLIC

GO
*/

/* Update Total */
IF EXISTS (SELECT * FROM sysobjects WHERE type = 'P' AND name = 'Update_Total')
	BEGIN
		PRINT 'Dropping Procedure Update_Total'
		DROP  Procedure  Update_Total
	END

GO

PRINT 'Creating Procedure Update_Total'
GO
CREATE Procedure Update_Total
	/* Param List */
	@store_id int,
	@pos_no int,
	@total_type int,
	@total_amount decimal(15,2)
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

declare  @postotalid int
declare  @totalid int
declare @count int


select  @postotalid = pos_total_id from pos_total where store_id = @store_id and pos_no = @pos_no

    if (@postotalid is not null) 

    	begin
    	
      		select @totalid = pos_total_id  from total where pos_total_id = @postotalid and total_type = @total_type 
      		
      		if ( @totalid is not null ) 
      			begin
      			
        			update total set total_count = total_count + 1, total_amount = total_amount + @total_amount  where pos_total_id = @postotalid and total_type = @total_type
        			--update total set total_amount = total_amount + @total_amount where pos_total_id = @postotalid and total_type = @total_type
      		
      			end
      		else
      			begin
        		
        			insert into total values (0, @postotalid, @total_type, 1, @total_amount)
        			
      			end
        
   		end
   		
    else
    	
    	begin
    		select @count = count(*)  from total
			set @count = @count+1

      		
      		insert into pos_total values (@count, @store_id, @pos_no, 0, 0)
      		insert into total values (0, @count, @total_type, 1, @total_amount)
       	
       	end






GO

GRANT EXEC ON Update_Total TO PUBLIC

GO



/* Update total amount count */

IF EXISTS (SELECT * FROM sysobjects WHERE type = 'P' AND name = 'Update_total_Amount_Count')
	BEGIN
		PRINT 'Dropping Procedure Update_total_Amount_Count'
		DROP  Procedure  Update_total_Amount_Count
	END

GO

PRINT 'Creating Procedure Update_total_Amount_Count'
GO
CREATE Procedure Update_total_Amount_Count
	/* Param List */
	@store_id int,
	@pos_no int,
	@total_type int,
	@total_count int,
	@total_amount decimal(15,2)
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
declare @postotalid int
declare @totalid int
declare @count int

select @count = count(total_id)  from total
set @count = @count+1



  begin

    select pos_total_id=@postotalid from pos_total where store_id = @store_id and pos_no = @pos_no 
    
    if (@postotalid is not null) 
   
    begin
    
      select pos_total_id = @totalid from total where pos_total_id = @postotalid and total_type = @total_type 
    
      if (@totalid > 0)
            
      begin
      
        update total set total_count = total_count + @total_count where pos_total_id = @postotalid and total_type = @total_type
        
        update total set total_amount = total_amount + @total_amount where pos_total_id = @postotalid and total_type = @total_type
      
      end
      
      else
      
      begin
      
        insert into total values (0, @postotalid, @total_type, @total_count, @total_amount);
      
      end
      
      return
      
    end

    else

    begin
    
      insert into pos_total values (@count, @store_id, @pos_no, 0, 0)
      insert into total values (0, @count, @total_type, @total_count, @total_amount)
      
      return
          
    end
    
  end 




GO

GRANT EXEC ON Update_total_Amount_Count TO PUBLIC

GO


/* Update trans state */
IF EXISTS (SELECT * FROM sysobjects WHERE type = 'P' AND name = 'Update_Trans_State')
	BEGIN
		PRINT 'Dropping Procedure Update_Trans_State'
		DROP  Procedure  Update_Trans_State
	END

GO

PRINT 'Creating Procedure Update_Trans_State'
GO
CREATE Procedure Update_Trans_State
	/* Param List */
	@trans_id int,
	@store_no int,
	@organization_no int,
	@pos_no int,
	@state int 
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
Update trans set state = @state
where trans_id = @trans_id
and store_no = @store_no
and organization_no = @organization_no
and pos_no = @pos_no

GO

GRANT EXEC ON Update_Trans_State TO PUBLIC

GO


/* Update Trans state and Type */

IF EXISTS (SELECT * FROM sysobjects WHERE type = 'P' AND name = 'Update_Trans_State_and_Type')
	BEGIN
		PRINT 'Dropping Procedure Update_Trans_State_and_Type'
		DROP  Procedure  Update_Trans_State_and_Type
	END

GO

PRINT 'Creating Procedure Update_Trans_State_and_Type'
GO
CREATE Procedure Update_Trans_State_and_Type
	/* Param List */
	@trans_id int,
	@store_no int,
	@organization_no int,
	@pos_no int,
	@state int, 
	@trans_type int
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

Update trans set state = @state, trans_type = @trans_type
where trans_id = @trans_id
and store_no = @store_no
and organization_no = @organization_no
and pos_no = @pos_no




GO

GRANT EXEC ON Update_Trans_State_and_Type TO PUBLIC

GO



/*
** Organization
*/

/* Add */

IF EXISTS (SELECT * FROM sysobjects WHERE type = 'P' AND name = 'Add_Organization')
	BEGIN
		PRINT 'Dropping Procedure Add_Organization'
		DROP  Procedure  Add_Organization
	END

GO

PRINT 'Creating Procedure Add_Organization'
GO
CREATE Procedure Add_Organization

/* Param List */
@organization_id int,
@organization_name varchar(50),
@federal_tax_id varchar(40),
@legal_status_code varchar(10),
@state_tax_id varchar(40),
@tax_id varchar(40)

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

insert into organization values 
(
@organization_id,
@organization_name,
@federal_tax_id,
@legal_status_code,
@state_tax_id,
@tax_id
)


GO

GRANT EXEC ON Add_Organization TO PUBLIC

GO

/* Load Organization */

IF EXISTS (SELECT * FROM sysobjects WHERE type = 'P' AND name = 'Load_Organization')
	BEGIN
		PRINT 'Dropping Procedure Load_Organization'
		DROP  Procedure  Load_Organization
	END

GO

PRINT 'Creating Procedure Load_Organization'
GO
CREATE Procedure Load_Organization
	/* Param List */
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

select * from organization  
order by Organization_no 

GO


GRANT EXEC ON Load_Organization TO PUBLIC

GO



/* Dialogs */

IF EXISTS (SELECT * FROM sysobjects WHERE type = 'P' AND name = 'Load_Dialog_By_ConfigNo')
	BEGIN
		PRINT 'Dropping Procedure Load_Dialog_By_ConfigNo'
		DROP  Procedure  Load_Dialog_By_ConfigNo
	END

GO

PRINT 'Creating Procedure Load_Dialog_By_ConfigNo'
GO
CREATE Procedure Load_Dialog_By_ConfigNo
	@config_no int
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

select * from dialog where config_no = @config_no

--return

GO

GRANT EXEC ON Load_Dialog_By_ConfigNo TO PUBLIC

GO




IF EXISTS (SELECT * FROM sysobjects WHERE type = 'P' AND name = 'Load_Dialog_By_DialogName')
	BEGIN
		PRINT 'Dropping Procedure Load_Dialog_By_DialogName'
		DROP  Procedure  Load_Dialog_By_DialogName
	END

GO

PRINT 'Creating Procedure Load_Dialog_By_DialogName'
GO
CREATE Procedure Load_Dialog_By_DialogName
	@dialog_id int output,
	@config_no int,
	@help_id	int output,
	@dialog_type int output,
	@dialog_name varchar(50) /* Param List */
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
select 
	@dialog_id = dialog_id,
	@config_no = config_no,
	@help_id = help_id,
	@dialog_type = dialog_type,
	@dialog_name =	dialog_name	
	from dialog 
where dialog_name = @dialog_name and config_no = @config_no


GO

GRANT EXEC ON Load_Dialog_By_DialogName TO PUBLIC

GO





IF EXISTS (SELECT * FROM sysobjects WHERE type = 'P' AND name = 'Load_DialogEvent_By_DialogID')
	BEGIN
		PRINT 'Dropping Procedure Load_DialogEvent_By_DialogID'
		DROP  Procedure  Load_DialogEvent_By_DialogID
	END

GO

PRINT 'Creating Procedure Load_DialogEvent_By_DialogID'
GO
CREATE Procedure Load_DialogEvent_By_DialogID
	@dialog_event_id int,
	@dialog_id int
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

select * from dialog_event where dialog_id = @dialog_id  and  dialog_event_id = @dialog_event_id
order by dialog_event_id, dialog_id, dialog_seq

--return
 
GO

GRANT EXEC ON Load_DialogEvent_By_DialogID TO PUBLIC

GO





IF EXISTS (SELECT * FROM sysobjects WHERE type = 'P' AND name = 'Load_Employee_Role_Event')
	BEGIN
		PRINT 'Dropping Procedure Load_Employee_Role_Event'
		DROP  Procedure  Load_Employee_Role_Event
	END

GO

PRINT 'Creating Procedure Load_Employee_Role_Event'
GO
CREATE Procedure Load_Employee_Role_Event
	@role_id int
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

select * from employee_role_event
where role_id = @role_id 

 
GO

GRANT EXEC ON Load_Employee_Role_Event TO PUBLIC

GO


