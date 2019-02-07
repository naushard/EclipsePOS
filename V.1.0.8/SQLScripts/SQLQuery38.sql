use possite

go

drop table stock_balance

go

drop table trans_stock

go 



create table stock_balance
(
organization_no varchar(6) references organization(organization_no),			
store_no varchar(6) not null,				
sku varchar(24) not null,
quantity_on_hand decimal(15,3),			
cost decimal(15,2),
mininum_quantity decimal(15,3),			
maximum_quantity decimal(15,3),			
constraint  stock_balance_access_key unique(organization_no, store_no, sku )
)

GO

create table trans_stock
(
organization_no varchar(6) references organization(organization_no),			
store_no varchar (6) not null,				
sku varchar (24) not null,
quantity decimal(15,3) not null,
transaction_type smallint,			
transaction_time datetime,
constraint  trans_stock_access_key unique(organization_no, store_no, sku, transaction_time)
)

GO