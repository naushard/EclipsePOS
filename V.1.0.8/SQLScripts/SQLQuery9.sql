

use possite

go

drop table department
go 

drop table ItemGroup
go

/* -------------- Item group ------------------------ */

create table ItemGroup
(
organization_no int not null references organization(organization_no),
group_id varchar(5) not null,
group_name varchar (30)not null,
constraint item_group_key primary key (organization_no, group_id)
)
GO


/* --------------- Department ----------------------- */ 

create table department
(
organization_no int not null references organization(organization_no),	
department_id varchar(5) not null,
department_name varchar(30) not null,
constraint department__key primary key (organization_no, department_id)
)

GO


