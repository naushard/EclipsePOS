

use possite1

go

delete from pos_param where config_no = 5 and param_name = 'FontFamily' 

go


insert into pos_param values ( 5, 3, 6, 18, 'FontFamily', 'Calibri', null) 
go



if OBJECT_ID('dbo.pos_employee_total', 'U') IS NOT NULL
	DROP TABLE dbo.pos_employee_total
go


go 

create table pos_employee_total
(
total_name int not null,
sequence_no int not null,
organization_no varchar(6) not null references Organization(organization_no),
store_no varchar(6) not null ,
pos_no int,
employee_no varchar(20),
drawer_no int,
total_type int,
total_count int,
total_amount decimal(15,2)
constraint pos_employee_total_key primary key (organization_no, store_no, pos_no, total_name, sequence_no, employee_no, total_type),
)

go




/* Add_total */

IF EXISTS (SELECT * FROM sysobjects WHERE type = 'P' AND name = 'Add_Pos_Employee_Total')
	BEGIN
		PRINT 'Dropping Procedure Add_Pos_Employee_Total'
		DROP  Procedure  Add_Pos_Employee_Total
	END

GO

PRINT 'Creating Procedure Add_Pos_Employee_Total'
GO
CREATE Procedure Add_Pos_Employee_Total
	/* Param List */
	@total_name int,
	@sequence_no int,
	@organization_no varchar(6),
	@store_no varchar(6),
	@pos_no int,
	@employee_no varchar(20),
	@drawer_no int,
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
/** declare @count int

--select @count = count(total_id)  from total
--set @total_id = @count+1 **/

insert into pos_employee_total
values
(
@total_name,
@sequence_no,
@organization_no,
@store_no,
@pos_no,
@employee_no,
@drawer_no,
@total_type,
@total_count,
@total_amount
)


GO




/* Load totals by total id*/
IF EXISTS (SELECT * FROM sysobjects WHERE type = 'P' AND name = 'Load_Pos_Employee_Total')
	BEGIN
		PRINT 'Dropping Load_Pos_Employee_Total'
		DROP  Procedure  Load_Pos_Employee_Total
	END

GO

PRINT 'Creating Procedure Load_Pos_Employee_Total'
GO
CREATE Procedure Load_Pos_Employee_Total
	/* Param List */
	@organization_no varchar(6),
	@store_no varchar(6),
	@pos_no int,
	@sequence_no int
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

select * from pos_employee_total
where sequence_no = @sequence_no
and organization_no = @organization_no
and store_no = @store_no
and pos_no = @pos_no
order by employee_no, drawer_no, total_name, total_type


GO




/* Update total amount count */

IF EXISTS (SELECT * FROM sysobjects WHERE type = 'P' AND name = 'Update_Pos_Employee_Total_Amount_Count')
	BEGIN
		PRINT 'Dropping Procedure Update_Pos_Employee_Total_Amount_Count'
		DROP  Procedure  Update_Pos_Employee_Total_Amount_Count
	END

GO

PRINT 'Creating Procedure Update_Pos_Employee_Total_Amount_Count'
GO
CREATE Procedure Update_Pos_Employee_Total_Amount_Count
	/* Param List */
	@organization_no varchar(6),
	@store_no varchar(6),
	@pos_no int,
	@employee_no varchar(20),
	@drawer_no int,
	@total_name int,
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
declare @seq int
declare @count int

  begin

    select @seq = sequence_no from pos_total where store_no = @store_no and organization_no = @organization_no and end_date = 0 and total_name = @total_name and end_date = 0
    
		if (@seq is not null) 
   
			begin
    
				select @count = total_count  from pos_employee_total where sequence_no = @seq and  store_no = @store_no and organization_no = @organization_no and total_type = @total_type  and total_name = @total_name and employee_no = @employee_no and drawer_no = @drawer_no
    
				if (@count > 0)
            
					begin
      
						update pos_employee_total set total_count = total_count + @total_count,  total_amount = total_amount + @total_amount where sequence_no = @seq and store_no = @store_no and organization_no = @organization_no and total_type = @total_type and total_name = @total_name and employee_no = @employee_no and drawer_no = @drawer_no
        
       
					end
      
				else
      
					begin
      
						insert into pos_employee_total values ( @total_name, @seq, @organization_no, @store_no, @pos_no, @employee_no, @drawer_no, @total_type, @total_count, @total_amount)
      
					end
      
					return
      
				
        
  
			end 

	end
GO





/* Load_Trans_by_Start_Date */

IF EXISTS (SELECT * FROM sysobjects WHERE type = 'P' AND name = 'Load_Trans_by_Start_Date')
	BEGIN
		PRINT 'Dropping Procedure Load_Trans_by_Start_Date'
		DROP  Procedure  Load_Trans_by_Start_Date
	END

GO

PRINT 'Creating Procedure Load_Trans_by_Start_Date'
GO
CREATE Procedure Load_Trans_by_Start_Date
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

select trans.trans_no, trans_type, trans.state, tendertype, amount, change_amt, tender_desc, start_time, complete_time, trans_sales_person.employee_no
from trans 
left outer join trans_tender
on ( trans.trans_no = trans_tender.trans_no and trans.organization_no = trans_tender.organization_no and trans.store_no = trans_tender.store_no and trans.pos_no = trans_tender.pos_no )  
left outer join trans_sales_person
on (trans.trans_no = trans_sales_person.trans_no and trans.organization_no = trans_sales_person.organization_no and trans.store_no = trans_sales_person.store_no and trans.pos_no = trans_sales_person.pos_no )
where trans.organization_no = @organization_no and trans.store_no = @store_no and trans.pos_no = @pos_no and
start_time >  ( select start_date from pos_total where total_name = 1 and end_date = 0 )
order by trans.trans_no DESC

GO


