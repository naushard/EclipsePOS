use possite1;


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


