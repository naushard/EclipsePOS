use possite1

go


if OBJECT_ID('dbo.pos_total', 'U') IS NOT NULL
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


