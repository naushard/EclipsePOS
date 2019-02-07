use possite

go

delete from pos_param where config_no = 5 and param_name = 'PromptForReceiptPrint' 

go


insert into pos_param values ( 5, 3, 6, 22, 'PromptForReceiptPrint', 'FALSE', null) 
go




delete from pos_param where config_no = 5 and param_name = 'PressPrintKey' 

go


insert into pos_param values ( 5, 5, 4, 106, 'PressPrintKey', 'Press Print Key', null) 
go



delete from pos_param where config_no = 5 and param_name = 'InsufficientTenderAmount' 

go


insert into pos_param values ( 5, 5, 4, 107, 'InsufficientTenderAmount', 'Insuf. Tender Amt', null) 
go



delete from pos_param where config_no = 5 and param_name = 'QuickSalePLU' 

go


insert into pos_param values ( 5, 5, 6, 107, 'QuickSalePLU', '100', null) 
go




delete from pos_param where config_no = 5 and param_name = 'SalePrompt' 
go
insert into pos_param values ( 5, 5, 4, 107, 'SalePrompt', 'Sales', null) 
go

delete from pos_param where config_no = 5 and param_name = 'ReturnSalePrompt' 
go
insert into pos_param values ( 5, 5, 4, 108, 'ReturnSalePrompt', 'Return', null) 
go

delete from pos_param where config_no = 5 and param_name = 'PaidInPrompt' 
go
insert into pos_param values ( 5, 5, 4, 109, 'PaidInPrompt', 'Paid/IN', null) 
go

delete from pos_param where config_no = 5 and param_name = 'PaidOutPrompt' 
go
insert into pos_param values ( 5, 5, 4, 110, 'PaidOutPrompt', 'Paid/OUT', null) 
go