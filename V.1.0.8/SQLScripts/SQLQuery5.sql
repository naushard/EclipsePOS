use possite

drop table employee

go


create table employee
(
organization_no integer not null references Organization(organization_no),							
employee_id integer identity,
employee_no varchar(20),
logon_no integer not null,
logon_pass integer not null,
role_id integer not null references employee_roles(role_id),
fname varchar (32),
lname varchar(32),
mi char(1),
ssn char(9),
sal_grade integer,
constraint employeeKey primary key (organization_no, logon_no) 

)

go