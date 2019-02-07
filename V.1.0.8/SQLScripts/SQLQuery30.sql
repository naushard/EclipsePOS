use possite

go 

drop table surcharge

go


/* ----------------- Item ---------------------------- */

create table surcharge
(
organization_no varchar(6) references organization(organization_no),			
surcharge_code varchar (6) not null,				
surcharge_desc varchar (60) not null,
amount decimal(15,2),			
method smallint,
surcharge_account varchar(45),			
tax_group_id varchar(12),			
tax_inclusive smallint,		
tax_exempt smallint,
surcharge_key_id smallint,
constraint surcharge_key primary key (organization_no, surcharge_code),
constraint  surcharge_access_key unique(organization_no, surcharge_key_id)
)

GO




IF EXISTS (SELECT * FROM sysobjects WHERE type = 'P' AND name = 'Load_surcharge_by_surcharge_key')
	BEGIN
		PRINT 'Dropping Procedure Load_surcharge_by_surcharge_key'
		DROP  Procedure  Load_surcharge_by_surcharge_key
	END

GO

PRINT 'Creating Procedure Load_surcharge_by_surcharge_key'

GO
-- =============================================
-- Author:		Naushard
-- Create date: 
-- Description:	
-- =============================================
CREATE PROCEDURE Load_surcharge_by_surcharge_key 
	-- Add the parameters for the stored procedure here
	@organization_no varchar(6), 
	@surcharge_code varchar(6) output,
	@surcharge_desc varchar(60) output,
	@amount decimal(15,2) output,
	@method smallint output,
	@surcharge_account varchar(45) output,
	@tax_group_id varchar(12) output,
	@tax_inclusive smallint output,
	@tax_exempt smallint output,
	@surcharge_key_id int
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
and surcharge_key_id = @surcharge_key_id 
   
END
GO
