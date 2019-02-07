use possite


go

USE [possite]

GO
ALTER TABLE [dbo].[retail_store] DROP CONSTRAINT [PK__retail_store__7E6CC920]


go 

Alter table [dbo].[retail_store] constraint primary key (organization_no, store_no)