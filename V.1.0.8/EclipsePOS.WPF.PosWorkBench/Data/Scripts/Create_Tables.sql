USE [possite] 
/*USE [C:\C#PROJECTS\ECLIPSEPOS.WPF.SYSTEMMANAGER\ECLIPSEPOS.WPF.SYSTEMMANAGER\BIN\DEBUG\RDMS\POSSITE.MDF]
GO
*/

/*
USE [C:\C#PROJECTS\ECLIPSEPOS.WPF.POSWORKBENCH\DATA\POSSITE.MDF]
*/

GO

/****** Object:  Table [dbo].[RetailStore]    Script Date: 02/18/2009 11:24:53 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO





/*USE [C:\C#Projects\POSDatabase\POSSITE.MDF] */

GO
/****** Object:  Table [dbo].[Testing]    Script Date: 06/23/2008 18:35:24 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO


/* Drop tables */
if OBJECT_ID('dbo.trans_bank', 'U') IS NOT NULL
	DROP TABLE dbo.trans_bank
go


if OBJECT_ID('dbo.trans_tax', 'U') IS NOT NULL
	DROP TABLE dbo.trans_tax
go


if OBJECT_ID('dbo.trans_customer', 'U') IS NOT NULL
	DROP TABLE dbo.trans_customer
go


if OBJECT_ID('dbo.trans_exception', 'U') IS NOT NULL
	DROP TABLE dbo.trans_exception
go


if OBJECT_ID('dbo.trans_tender', 'U') IS NOT NULL
	DROP TABLE dbo.trans_tender
go


if OBJECT_ID('dbo.trans_promotion', 'U') IS NOT NULL
	DROP TABLE dbo.trans_promotion
go


if OBJECT_ID('dbo.trans_item_link', 'U') IS NOT NULL
	DROP TABLE dbo.trans_item_link
go


if OBJECT_ID('dbo.trans_item', 'U') IS NOT NULL
	DROP TABLE dbo.trans_item
go


if OBJECT_ID('dbo.trans_count', 'U') IS NOT NULL
	DROP TABLE dbo.trans_count
go


if OBJECT_ID('dbo.trans', 'U') IS NOT NULL
	DROP TABLE dbo.trans
go


if OBJECT_ID('dbo.station_trans_upload', 'U') IS NOT NULL
	DROP TABLE dbo.station_trans_upload
go


if OBJECT_ID('dbo.station_session', 'U') IS NOT NULL
	DROP TABLE dbo.station_session
go


if OBJECT_ID('dbo.station_total', 'U') IS NOT NULL
	DROP TABLE dbo.station_total
go


if OBJECT_ID('dbo.station_close', 'U') IS NOT NULL
	DROP TABLE dbo.station_close
go


if OBJECT_ID('dbo.station_close_detail', 'U') IS NOT NULL
	DROP TABLE dbo.station_close_detail
go


if OBJECT_ID('dbo.station_balance_detail', 'U') IS NOT NULL
	DROP TABLE dbo.station_balance_detail
go

if OBJECT_ID('dbo.station_session', 'U') IS NOT NULL
	DROP TABLE dbo.station_session
go



if OBJECT_ID('dbo.input_filter_field', 'U') IS NOT NULL
	DROP TABLE dbo.input_filter_field
go


if OBJECT_ID('dbo.input_filter', 'U') IS NOT NULL
	DROP TABLE dbo.input_filter
go

if OBJECT_ID('dbo.dialog_event', 'U') IS NOT NULL
	DROP TABLE dbo.dialog_event
go


if OBJECT_ID('dbo.dialog', 'U') IS NOT NULL
	DROP TABLE dbo.dialog
go

if OBJECT_ID('dbo.pos_param', 'U') IS NOT NULL
	DROP TABLE dbo.pos_param
go

if OBJECT_ID('dbo.plu', 'U') IS NOT NULL
	DROP TABLE dbo.plu
go

if OBJECT_ID('dbo.item_link', 'U') IS NOT NULL
	DROP TABLE dbo.item_link
go
if OBJECT_ID('dbo.item', 'U') IS NOT NULL
	DROP TABLE dbo.item
go

if OBJECT_ID('dbo.department', 'U') IS NOT NULL
	DROP TABLE dbo.department
go

if OBJECT_ID('dbo.item_group', 'U') IS NOT NULL
	DROP TABLE dbo.item_group
go

if OBJECT_ID('dbo.employee', 'U') IS NOT NULL
	DROP TABLE dbo.employee
go

if OBJECT_ID('dbo.employee_role_event', 'U') IS NOT NULL
	DROP TABLE dbo.employee_role_event
go

if OBJECT_ID('dbo.employee_roles', 'U') IS NOT NULL
	DROP TABLE dbo.employee_roles
go

if OBJECT_ID('dbo.customer', 'U') IS NOT NULL
	DROP TABLE dbo.customer
go

if OBJECT_ID('dbo.currency_denomination', 'U') IS NOT NULL
	DROP TABLE dbo.currency_denomination
go


if OBJECT_ID('dbo.currency', 'U') IS NOT NULL
	DROP TABLE dbo.currency
go

if OBJECT_ID('dbo.currency_code', 'U') IS NOT NULL
	DROP TABLE dbo.currency_code
go


if OBJECT_ID('dbo.media', 'U') IS NOT NULL
	DROP TABLE dbo.media
go


if OBJECT_ID('dbo.promotion_map', 'U') IS NOT NULL
	DROP TABLE dbo.promotion_map
go

if OBJECT_ID('dbo.promotion', 'U') IS NOT NULL
	DROP TABLE dbo.promotion
go

if OBJECT_ID('dbo.pos_key', 'U') IS NOT NULL
	DROP TABLE dbo.pos_key
go




if OBJECT_ID('dbo.tax', 'U') IS NOT NULL
	DROP TABLE dbo.tax
go

if OBJECT_ID('dbo.tax_group', 'U') IS NOT NULL
	DROP TABLE dbo.tax_group
go




if OBJECT_ID('dbo.sub', 'U') IS NOT NULL
	DROP TABLE dbo.sub
go

if OBJECT_ID('dbo.sub_map', 'U') IS NOT NULL
	DROP TABLE dbo.sub_map
go

if OBJECT_ID('dbo.pos', 'U') IS NOT NULL
	DROP TABLE dbo.pos
go

if OBJECT_ID('dbo.retail_store', 'U') IS NOT NULL
	DROP TABLE dbo.retail_store
go

if OBJECT_ID('dbo.menu_config', 'U') IS NOT NULL
	DROP TABLE dbo.menu_config
go

if OBJECT_ID('dbo.menu_panels', 'U') IS NOT NULL
	DROP TABLE dbo.menu_panels
go

if OBJECT_ID('dbo.sub_map', 'U') IS NOT NULL
	DROP TABLE dbo.sub_map
go

if OBJECT_ID('dbo.ItemGroup', 'U') IS NOT NULL
	DROP TABLE dbo.ItemGroup
go

if OBJECT_ID('dbo.employee_role_event', 'U') IS NOT NULL
	DROP TABLE dbo.employee_role_event
go

if OBJECT_ID('dbo.employee_roles', 'U') IS NOT NULL
	DROP TABLE dbo.employee_roles
go

if OBJECT_ID('dbo.menu_root', 'U') IS NOT NULL
	DROP TABLE dbo.menu_root
go

if OBJECT_ID('dbo.pos_balance_detail', 'U') IS NOT NULL
	DROP TABLE dbo.pos_balance_detail
go

if OBJECT_ID('dbo.pos_close', 'U') IS NOT NULL
	DROP TABLE dbo.pos_close
go

if OBJECT_ID('dbo.pos_close_detail', 'U') IS NOT NULL
	DROP TABLE dbo.pos_close_detail
go

if OBJECT_ID('dbo.pos_total', 'U') IS NOT NULL
	DROP TABLE dbo.pos_total
go

if OBJECT_ID('dbo.pos_trans_upload', 'U') IS NOT NULL
	DROP TABLE dbo.pos_trans_upload
go


if OBJECT_ID('dbo.pos_session', 'U') IS NOT NULL
	DROP TABLE dbo.pos_session
go

if OBJECT_ID('dbo.reason_code', 'U') IS NOT NULL
	DROP TABLE dbo.reason_code
go

if OBJECT_ID('dbo.reason_code_category', 'U') IS NOT NULL
	DROP TABLE dbo.reason_code_category
go

if OBJECT_ID('dbo.trans_time_punch', 'U') IS NOT NULL
	DROP TABLE dbo.trans_time_punch
go

if OBJECT_ID('dbo.trans_total', 'U') IS NOT NULL
	DROP TABLE dbo.trans_total
go

if OBJECT_ID('dbo.total', 'U') IS NOT NULL
	DROP TABLE dbo.total
go



if OBJECT_ID('dbo.pos_config', 'U') IS NOT NULL
	DROP TABLE dbo.pos_config
go



if OBJECT_ID('dbo.organization', 'U') IS NOT NULL
	DROP TABLE dbo.organization
go

if OBJECT_ID('dbo.help', 'U') IS NOT NULL
	DROP TABLE dbo.help
go

/* ------------------ Organizations ---------------------*/



Create table organization
(

organization_no		int not null primary key,
organization_name	varchar(50) not null,
federal_tax_id		varchar(40) not null,
legal_status_code	varchar(10) not null,
state_tax_id		varchar(40) not null,
tax_id				varchar(40) not null

)

GO




/* RetailStore */



IF EXISTS (SELECT * FROM sysobjects WHERE type = 'U' AND name = 'retail_store')
	BEGIN
		PRINT 'Dropping Table retail_store'
		DROP  Table retail_store
	END
GO

/******************************************************************************
**		File: 
**		Name: Table_Name
**		Desc: 
**
**		This template can be customized:
**              
**
**		Auth: 
**		Date: 
*******************************************************************************
**		Change History
*******************************************************************************
**		Date:		Author:				Description:
**		--------		--------				-------------------------------------------
**    
*******************************************************************************/

PRINT 'Creating Table retail_store'
GO
CREATE TABLE retail_store
(
store_no			int not null primary key,
organization_no		integer not null references Organization(organization_no),
store_name			varchar(40) not null,
closing_date		datetime,
open_date			datetime not null,
selling_area_size	decimal(15,2),
size	    	   	decimal(15,2),
address1			varchar(40) not null,
address2			varchar(40) not null, 	
address3			varchar(40) not null,
address4			varchar(40),
address5			varchar(40),
postal_code			varchar(15),
phone				varchar(20), 
ip					varchar(20),
port_number			varchar (20),
last_trans_no		bigint
)

GO

GRANT ALL ON retail_store TO PUBLIC

GO








/* ---------------------- employee_roles	---------------------- */


create table employee_roles
(
role_id integer identity primary key not null,
role_name varchar (100) not null unique,
organization_no integer not null references Organization(organization_no)
)

go



/* ----------------- employee_role_event ----------------------- */


create table employee_role_event
(
role_event_id integer identity primary key,
role_id integer not null references employee_roles(role_id),
role_event_name varchar (100) not null
)

go



/* ------------------ Employee -------------------------------- */

create table employee
(
organization_no integer not null references Organization(organization_no),							
employee_id integer identity not null primary key,
employee_no varchar(20) not null,
logon_no integer not null,
logon_pass integer not null,
role_id integer not null references employee_roles(role_id),
fname varchar (32),
lname varchar(32),
mi char(1),
ssn char(9),
sal_grade integer
)

go




/*------------------ Subscriber --------------------*/

create table sub
(	
subscriber_id integer identity primary key,
subscriber_name varchar(32) not null,
subscriber_pass varchar(32) not null
)
go


GRANT ALL ON sub TO PUBLIC
GO


/* ---------------- Subscriber map---------------------*/

create table sub_map 
(	
subscriber_id integer not null,
organization_id integer not null,
subscriber_priv integer not null
)
go

GRANT ALL ON sub_map TO PUBLIC
GO




/* -------------- Item group ------------------------ */

create table ItemGroup
(
organization_no int references organization(organization_no),
group_id varchar(5) not null primary key,
group_name varchar (30)not null
)
GO

GRANT ALL ON ItemGroup TO PUBLIC
GO

/* --------------- Department ----------------------- */ 

create table department
(
organization_no int references organization(organization_no),	
department_id varchar(5) not null primary key,
department_name varchar(30) not null
)

GO

GRANT ALL ON department TO PUBLIC
GO

/* ----------------- Item ---------------------------- */

create table item
(
item_id int identity not null,
organization_no int references organization(organization_no),			
sku varchar (20) primary key,				
short_desc varchar (50),
amount decimal(15,2),			
dept varchar(5),
item_group varchar(5),			
tax_group integer,			
pricing_opt integer,			
active_date datetime,			
deactive_date datetime,			
tax_inclusive integer,		
tax_exempt integer,
plu bigint unique
)

GO


/* -------------------- item link ------------------------ */
create table item_link
(
sku varchar (20) references item(sku) not null,
sku_link varchar(20) primary key not null
)

go




/* ------------------- PosConfig ------------------ */


create table pos_config
(
config_no int  primary key,
name varchar(50) not null unique,
)


GO

GRANT ALL ON pos_config TO PUBLIC
GO




/* ------------------ Pos_param ------------------------ */

create table pos_param
(
param_id integer identity primary key, 	
config_no integer not null references pos_config(config_no),
param_type integer,
cache_flag integer,
help_id integer,
param_name varchar (100),
param_value varchar (100)
)


GRANT ALL ON pos_param TO PUBLIC
GO

/* ------------------ currency_code ------------------------ */

create table currency_code
(
currency_code_id int identity primary key,
currency_code integer not null,
language char (2),
country char (2),
currency_desc varchar (50) not null
)

go

/* ------------------ currency ------------------------ */


create table currency
(
currency_id int identity primary key,
organization_no int not null references organization(organization_no),
currency_code_id int references currency_code(currency_code_id),
conversion_rate decimal(15,5) not null,
smallest_denom int ,
decimal_digits int,
locale varchar (32),
is_base int,   
is_local int,  
last_update datetime,
currency_class varchar (100)
)

go




/* ------------------ currency_denomination ------------------------ */


create table currency_denomination
(
currency_denom_id integer,
currency_id integer,
denom_amount decimal(15,2),
denom_desc varchar (32)
)

go



create table customer (
					   customer_id integer,
					   customer_no varchar (20),
					   customer_name varchar (50),
					   addr1 varchar(50),
					   addr2 varchar(50),
					   addr3 varchar(50),
					   addr4 varchar(50),
					   addr5 varchar(50),
					   phone varchar(20),			
					   fax varchar (20),
					   email varchar (50));

go



------------------------ done ----------------------




 


create table dialog
(
dialog_id integer,
config_no integer,
help_id integer,
dialog_type integer,
 dialog_name varchar (50)
)

 go



create table dialog_event (
						dialog_event_id integer,
						dialog_id integer,
						dialog_seq integer,
						help_id integer,
						dialog_desc varchar (50),
						state integer,
						event_enabled integer,
						event_required integer,
						event_class varchar (100));


 go




create table input_filter (
	filter_id integer,
	filter_type integer,
	filter_sub_type integer,
	filter_name varchar (50),
	display_name varchar (50),
	regex varchar (32),
	check_digit_class varchar (100),
	filter_class varchar (100));

 go



create table input_filter_field (
	filter_id integer,
	sequence_no integer,
	name varchar (32));


 go











-------------- done --------------------------------------






/* 18 Media	*/
 create table media (		
					config_no int not null references pos_config(config_no),
					media_type integer,
					halo integer,
					lalo integer,
					media_desc varchar (50),
					media_class varchar (100));

   go







/* 21 POS	*/

create table pos
(	
pos_no int not null primary key,
organization_no int not null references Organization(organization_no),
store_no int not null references retail_store(store_no),
num_drawers integer,
short_desc varchar(32) not null,
create_date datetime,
modify_date datetime
)
				  
GO




/* 22 POS balance detail	*/

 create table pos_balance_detail (
								 pos_balance_id integer not null,
								 media_type integer,
								 media_amount decimal(15,2) );



   go



/* 23 POS Close	*/

 create table pos_close (
						pos_balance_id integer not null,
						pos_transport_id integer not null,
						site_id integer not null,
						pos_no integer not null,
						create_date timestamp);

   go



/* 24 POS close detail	*/

 create table pos_close_detail (
						   pos_balance_id integer not null,
							   currency_type integer,
							   denomination integer,
							   denom_count integer);

   go


/* ------------------------ Menu root ----------------------*/
create table menu_root 
(
menu_no integer identity primary key,
menu_id int unique,
config_no int references pos_config(config_no),
menu_name varchar (50)
)


go




/*----------------------- menu panels ---------------------*/

create table menu_panels
(
config_no int not null references pos_config(config_no),
panel_id int not null,
panel_name varchar(100) not null,
panel_class_name varchar(500) not null,
constraint menukey primary key (config_no, panel_id)	
)
 
GO


GRANT ALL ON menu_panels  TO PUBLIC

GO

/*------------------- menu config ----------------------*/

/*
create table menu_config
(
menu_config_no int identity primary key,
config_no int references pos_config(config_no),
menu_id int  references menu_root(menu_id),
panel_id int references menu_panels(panel_id),
x_pos int,
y_pos int,
width int,
height int,
foreground_red int,  
foreground_green int,  
foreground_blue int,  
background_red int,
background_green int,
background_blue int,
font_size int
)
					   
					   
GO
GRANT ALL ON menu_config TO PUBLIC
*/

/* ------------------ POS key ------------------------*/

create table pos_key 
(
key_id integer identity primary key,
config_no int references pos_config(config_no),
panel_id int not null,
key_text varchar(100) not null,
key_type integer,
key_val integer,
key_code integer,
device_type integer,
x_loc integer not null,
y_loc integer not null,
key_height integer,
key_width integer,
fg_color integer,
bg_color integer,
attr integer,
flags varchar(100),
logout_disable integer,
key_class varchar(100) not null,
param varchar(100),
image varchar(100)
)

go




/* 30  POS session	*/

 create table pos_session (
						  
						 site_id integer not null,
						  pos_no integer not null,
						  session_type integer not null,
						  status integer,
						  start_date datetime,
						  end_date datetime);
   go



/* 31  POS total	*/

create table pos_total
(
	pos_total_id int,
	store_id int,
	pos_no int,
	emp_id int,
	drawer_no int
)

go

GRANT ALL ON pos_total TO PUBLIC
GO


/* 32 POS trans upload	*/

 create table pos_trans_upload (
							   upload_session_id integer not null,
							   pos_session_id integer not null,
							   trans_start integer,
							   trans_end integer);

   go



/* --------------------- Promotion ---------------------	*/ 

create table promotion
(
promotion_id int identity primary key,
config_no int not null references pos_config(config_no),						
promotion_no int,
promotion_type int,
promotion_val1 int,
promotion_val2 int,
promotion_val3 int,
promotion_val4 int,
promotion_val5 int,
promotion_dval1 decimal(15,2),
promotion_dval2 decimal(15,2),
promotion_dval3 decimal(15,2),
promotion_dval4 decimal(15,2),
promotion_dval5 decimal(15,2),
print_before_item int,
valid_times varchar (12),
valid_days varchar (12),
promotion_string varchar (100),
promotion_class varchar (100)
)

go



/* 34 Promotion map	*/

 create table promotion_map (
						   promotion_id integer,
						   promotion_map varchar (20),
						   map_type integer);


   go



/* 35 Reason codes	*/

 create table reason_code_category (
					   category_id integer,
					   category_desc varchar (100));

   go





/* 36 */
 create table reason_code (
					   reason_code_id integer,
					   category_id integer,
					   reason_code integer,
					   code_desc varchar (100));

   go



/* Site	*/

 
/* Sub menu	*/

/* create table sub_menu (
					   sub_menu_id integer,
					   menu_id integer,
					   sub_menu_name varchar (100));
	
   go
*/

 
/* ---------------- Tax group ---------------------*/

create table tax_group
(	
tax_group_id int not null identity primary key,
organization_no int not null references Organization(organization_no),
tax_group_name varchar(50) not null unique 
)

go



/*---------------------- Tax -----------------------*/

create table tax
(	
tax_id int not null primary key,
tax_group_id int not null references tax_group(tax_group_id),
tax_type int,
short_desc varchar(32) not null,
rate decimal(15,2)  not null, 
alt_rate decimal(15,2) 
)

go



/* Total	*/

 create table total (
					total_id int,  
					pos_total_id int,
					total_type int,
					total_count int,
					total_amount decimal(15,2));
   go

GRANT ALL ON total TO PUBLIC
GO


/* transactions	*/

/* transactions	*/

create table trans (
trans_no int not null identity,
trans_id int not null primary key,
store_no int not null references retail_store(store_no),
organization_no int not null references Organization(organization_no),
pos_no int not null references pos(pos_no),
drawer_no integer,
config_no int, 
trans_type int not null,
state int,
reason_code int,
customer_no varchar (20),
start_time datetime,
complete_time datetime,
emp_no int not null,
carry_out int,
training_mode int,
archive_date datetime,
upload_date datetime,
replication_date datetime
)


go

GRANT ALL ON trans TO PUBLIC
GO



/* Bank transactions	*/

 create table trans_bank (
						 	trans_id integer not null primary key,
						 	seq_no integer,
						 	pay_type integer,
						 	deposit_no integer,
						 	state integer,
						 	drawer_no integer,
						 	bank_desc varchar (100),
							locale_language varchar (2),
							locale_country varchar (2),
						 	amount decimal(15,2)
					 	)
						 	
   go

GRANT ALL ON trans_bank TO PUBLIC
GO


/* Transa count	*/

 create table trans_count (
						 	trans_id integer not null,
						 	seq_no integer,
							currency_denom_id integer,
						 	amount decimal(15,2) );



go


/* Trans Customer	*/

 create table trans_customer (
							 trans_id integer not null,
							 total_type integer,
							 customer_id integer
							 )

go

GRANT ALL ON trans_customer TO PUBLIC

GO



/* Trans exception	*/

 create table trans_exception (
					 		trans_id integer not null,
						 	seq_no integer,
							type integer,
						 	reason_code integer,
						 	amount decimal(15,2) 
						 	);

go

GRANT ALL ON trans_exception TO PUBLIC
GO



/* Trans item	*/

 create table trans_item (
						 trans_id int not null,
						 seq_no int not null,
						 line_no int not null,
						 sku varchar (20),
						 sku_link varchar (20),
						 quantity decimal(15,3),
						 amount decimal(15,2),
						 ext_amount decimal(15,2),
						 weight decimal(15,3),
						 item_desc varchar (100),
						 state int,
						 reason_code int,
						 tax_exempt int,
						 tax_incl int,
						 var_amount decimal(15,3) );

   go

GRANT ALL ON trans_item TO PUBLIC
GO




/* Trans item link	*/

 create table trans_item_link (
							  trans_id int not null,
							  seq_no int,
							  item_id int,
							  item_link_id int,
							  item_link_desc varchar(100),
							  amount decimal (15,2),
							  state integer
							  )


   go


GRANT ALL ON trans_item_link TO PUBLIC
GO


/* Trans promotion	*/

create table trans_promotion (
trans_id int not null,
seq_no int,
line_no int not null,
promotion_no int,
promotion_type int,
promotion_amount decimal(15,2),
promotion_quantity decimal(15,3),
reason_code int,
promotion_data varchar(100),
promotion_desc varchar(100),
state int
)

go


GRANT ALL ON trans_promotion TO PUBLIC
GO


/* Trans tax	*/


create table trans_tax (
trans_id int not null,
seq_no integer,
line_no int not null,
tax_id integer,
tax_desc varchar(30),
rate decimal(15,2),
taxable_amount decimal(15,2),
tax_amount decimal(15,2),
state int
)


   go

GRANT ALL ON trans_tax TO PUBLIC
GO




/* Trans tender	*/


create table trans_tender
(
trans_id int not null,
seq_no int,
tendertype int,
amount decimal(15,2),
change_amt decimal(15,2),
tender_desc varchar(100),
change_desc varchar(100),
locale_language varchar (2),
locale_country varchar (2),
data_capture varchar (100),
state int,
constraint transkey primary key (trans_id, seq_no)						
)


go


GRANT ALL ON trans_tender TO PUBLIC
GO



/* Trans time punch	*/

 create table trans_time_punch ( 
							   trans_id integer not null,
							   seq_no integer,
							   emp_id integer,
							   punch_type integer,   
							   punch_time timestamp);

   go



/* trans total	*/

 create table trans_total (
						  trans_id int not null,
						  seq_no int,
						  total_type int,
						  amount decimal(15,2),
						  total_desc varchar (100));


  go



/* Help	*/

create table help
(
help_id int not null primary key,
display_name varchar(50),
display_text varchar(256)
)


  go


 








