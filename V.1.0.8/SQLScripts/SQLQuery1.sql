use possite
go
delete from help
go 
INSERT INTO [possite].[dbo].[help]
           ([help_id]
           ,[display_name]
           ,[display_text])
     VALUES
           (21
           ,''
           ,'Welcome Message <br> POS Line display displays a welcome message at startup and between transactions')
go