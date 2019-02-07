


use possite1

go

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
	@organization_no varchar(6),
	@store_no varchar(6),
	@pos_no int,
	@total_name int,
	@sequence_no int output,
	@emp_id int output,
	@drawer_no int output,
	@start_date datetime output,
	@end_date datetime output,
	@start_receipt_no int output,
	@end_receipt_no int output
	
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
@sequence_no = sequence_no,
@emp_id = emp_id,
@drawer_no = drawer_no,
@start_date = start_date,
@end_date = end_date,
@start_receipt_no = start_receipt_no,
@end_receipt_no = end_receipt_no
from pos_total
where store_no = @store_no
and organization_no = @organization_no
and pos_no = @pos_no
and total_name = @total_name
and end_date = 0



GO





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
	@organization_no varchar(6),
	@store_no varchar(6),
	@pos_no int,
	@total_name int,
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

declare  @seq int
declare  @totalid int
declare @count int
declare @last_receipt int


select  @last_receipt = last_trans_no from retail_store where organization_no = @organization_no and store_no = @store_no

select  @seq = sequence_no from pos_total where store_no = @store_no and organization_no = @organization_no and end_date = 0 and total_name = @total_name

    if (@seq is not null) 

    	begin
    	
      		select @count = total_count  from total where sequence_no = @seq and  store_no = @store_no and organization_no = @organization_no and total_type = @total_type and total_name = @total_name
      		
      		if ( @count is not null ) 
      			begin
      			
        			update total set total_count = total_count + 1, total_amount = total_amount + @total_amount  where sequence_no = @seq and store_no = @store_no and organization_no = @organization_no and total_type = @total_type and total_name = @total_name
        			update pos_total set end_receipt_no = @last_receipt where organization_no = @organization_no and store_no = @store_no and pos_no = @pos_no

      			end
      		else
      			begin
        		
        			insert into total values (@total_name, @seq, @organization_no, @store_no, @pos_no, @total_type, 1, @total_amount)
        			
      			end
        
   		end
   		
    else
    	
    	begin
    		
			select @seq =  MAX(sequence_no) from pos_total where store_no = @store_no and organization_no = @organization_no and total_name = @total_name
			if (@seq is null)
				begin
					set @seq =1
				end
			else
				begin
					set @seq = @seq+1
				end
			insert into pos_total values (@total_name, @seq, @organization_no, @store_no, @pos_no, 0, 0, GetDate(), 0, @last_receipt, @last_receipt)
      		insert into total values (@total_name, @seq, @organization_no, @store_no, @pos_no,  @total_type, 1, @total_amount) 
       	
       	end






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
	@organization_no varchar(6),
	@store_no varchar(6),
	@pos_no int,
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
declare @last_receipt int


  begin

	select  @last_receipt = last_trans_no from retail_store where organization_no = @organization_no and store_no = @store_no

    select @seq = sequence_no from pos_total where store_no = @store_no and organization_no = @organization_no and end_date = 0 and total_name = @total_name
    
    if (@seq is not null) 
   
		begin
    
			select @count = total_count  from total where sequence_no = @seq and  store_no = @store_no and organization_no = @organization_no and total_type = @total_type  and total_name = @total_name
    
			if (@count > 0)
            
				begin
      
				update total set total_count = total_count + @total_count,  total_amount = total_amount + @total_amount where sequence_no = @seq and store_no = @store_no and organization_no = @organization_no and total_type = @total_type and total_name = @total_name
        
				--update total set total_amount = total_amount + @total_amount where pos_total_id = @postotalid and total_type = @total_type
      
				end
      
			else
      
				begin
      
				insert into total values ( @total_name, @seq, @organization_no, @store_no, @pos_no, @total_type, @total_count, @total_amount)
      
				end

			update pos_total set end_receipt_no = @last_receipt where organization_no = @organization_no and store_no = @store_no and pos_no = @pos_no

      
			return
      
		end

    else

    begin
    
      select @seq =  MAX(sequence_no) from pos_total where store_no = @store_no and organization_no = @organization_no and total_name = @total_name
	  if (@seq is null)
				begin
					set @seq =1
				end
	  else
				begin
					set @seq = @seq+1
				end
	  insert into pos_total values (@total_name, @seq, @organization_no, @store_no, @pos_no, 0, 0, GetDate(), 0, @last_receipt, @last_receipt)
      insert into total values (@total_name, @seq, @organization_no, @store_no, @pos_no,  @total_type, @total_count, @total_amount)
      
      return
          
    end
    
  end 




GO



/* Update pos total end date */

IF EXISTS (SELECT * FROM sysobjects WHERE type = 'P' AND name = 'Update_pos_total_end_date')
	BEGIN
		PRINT 'Dropping Procedure Update_pos_total_end_date'
		DROP  Procedure  Update_pos_total_end_date
	END

GO

PRINT 'Creating Procedure Update_pos_total_end_date'
GO
CREATE Procedure Update_pos_total_end_date
	/* Param List */
	@organization_no varchar(6),
	@store_no varchar(6),
	@pos_no int,
	@total_name int
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

update pos_total set end_date = GetDate()
where organization_no = @organization_no
and store_no = @store_no
and pos_no = @pos_no
and total_name = @total_name
and end_date = 0 



GO









