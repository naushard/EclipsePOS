use possite;

go



-- Customer receipt print


delete from pos_param where config_no =5 and param_name = 'StartReceiptNo'
go

insert into pos_param values ( 5, 5, 2, 27, 'StartReceiptNo', 'Start receipt : ', null)
go

delete from pos_param where config_no =5 and param_name = 'EndReceiptNo'
go

insert into pos_param values ( 5, 5, 2, 28, 'EndReceiptNo',	 'End receipt   : ', null)
go


delete from pos_param where config_no =5 and param_name = 'SalesStaff'
go

insert into pos_param values ( 5, 5, 2, 29, 'SalesStaff',	 'Sales Staff  : ', null)
go

delete from pos_param where config_no =5 and param_name = 'SalesBySalesman'
go

insert into pos_param values ( 5, 5, 2, 30, 'SalesBySalesman',	 'Sales :' , null)
go




delete from pos_param where config_no =5 and param_name = 'EnterSalesPersonNo'
go

insert into pos_param values ( 5, 5, 4, 103, 'EnterSalesPersonNo', 'Select Sales Staff', null) 
go

delete from pos_param where config_no =5 and param_name = 'PromptExtendedText'
go

insert into pos_param values ( 5, 5, 4, 104, 'PromptExtendedText', 'Enter Text', null) 
go








delete from pos_param where config_no =5 and param_name = 'SalesTotal'
go

insert into pos_param values ( 5, 5, 2, 31, 'SalesTotal',	 'Sales Total :' , null)
go


delete from pos_param where config_no =5 and param_name = 'Collections'
go

insert into pos_param values ( 5, 5, 2, 32, 'Collections',	 'Collections :' , null)
go


delete from pos_param where config_no =5 and param_name = 'CollectionTotal'
go

insert into pos_param values ( 5, 5, 2, 33, 'CollectionTotal',	 'Collection Total :' , null)
go


delete from pos_param where config_no =5 and param_name = 'CashInDrawer'
go

insert into pos_param values ( 5, 5, 2, 34, 'CashInDrawer',	 'Cash in Drawer' , null)
go
