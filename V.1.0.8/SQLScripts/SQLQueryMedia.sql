use possite

go


if OBJECT_ID('dbo.card_media', 'U') IS NOT NULL
	DROP TABLE dbo.card_media

go



/*  Media	*/

create table card_media
(		
organization_no varchar(6) references organization(organization_no),
media_id int not null,
media_name varchar(10) not null,
media_type int not null,
media_desc varchar(50) not null,
media_class varchar(100) null,
total_type int null,
constraint media_key primary key  (organization_no, media_id)
)

go


IF EXISTS (SELECT * FROM sysobjects WHERE type = 'P' AND name = 'Load_card_media_by_media_id')
	BEGIN
		PRINT 'Dropping Procedure Load_card_media_by_media_id'
		DROP  Procedure  Load_card_media_by_media_id
	END

GO

PRINT 'Creating Procedure Load_card_media_by_media_id'
GO


-- =============================================
-- Author:		Naushard
-- Create date: 
-- Description:	
-- =============================================
CREATE PROCEDURE [dbo].[Load_card_media_by_media_id] 
	-- Add the parameters for the stored procedure here
	@organization_no varchar(6),
	@media_id int,   
	@media_name varchar(10) output,
	@media_type int output,
	@media_desc varchar(50) output,
	@media_class varchar(100) output,
	@total_type int output
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

	-- Insert statements for procedure here

select 
@organization_no = organization_no,
@media_id = media_id,
@media_name = media_name,
@media_type = media_type,
@media_desc  = media_desc,
@media_class = media_class,
@total_type = total_type
from card_media 
where organization_no = @organization_no 
and media_id = @media_id 
   
END


go




IF EXISTS (SELECT * FROM sysobjects WHERE type = 'P' AND name = 'Load_card_Media_by_Organization_No')
	BEGIN
		PRINT 'Dropping Procedure Load_card_Media_by_Organization_No'
		DROP  Procedure  Load_card_Media_by_Organization_No
	END

GO

PRINT 'Creating Procedure Load_card_Media_by_Organization_No'
GO


-- =============================================
-- Author:		Naushard
-- Create date: 
-- Description:	
-- =============================================
CREATE PROCEDURE [dbo].[Load_card_Media_by_Organization_No] 
	-- Add the parameters for the stored procedure here
	@organization_no varchar(6)
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	--SET NOCOUNT ON;

	-- Insert statements for procedure here

select * from card_media 
where organization_no = @organization_no 
   
END


go



insert into card_media values ('40', 1, 'NETS', 1, 'Network for electroic transfers (S) Pte Ltd', Null,  401)
go
insert into card_media values ('40', 2, 'Ez-Link', 1, 'Ez-Link', Null,  402)
go
insert into card_media values ('40', 3, 'VISA', 2, 'Visa International', Null,  421)
go
insert into card_media values ('40', 4, 'MASTER', 2, 'Master International', null, 422)
go
insert into card_media values ('40', 5, 'DINNERS', 2, 'Dinners International', Null,  423);
go
insert into card_media values ('40', 6, 'AMEX', 2, 'American Express', Null,  424);
go
insert into card_media values ('40', 7, 'DISCOVER', 2, 'Discover', Null,  425);
go




