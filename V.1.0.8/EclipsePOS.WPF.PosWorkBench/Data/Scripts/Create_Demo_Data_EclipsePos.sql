
use possite

go

PRINT 'deleting table data .................'

go


delete from menu_config where config_id = 10
go
delete from menu_panels where config_id =  10
go
delete from menu_config where config_id =  10
go
delete from pos_key where key_id =  10
go


delete from pos_profile where config_no = 10
go
delete from tax_group where config_no =10
go
delete from tax
go
delete from pos_param where config_no= 10
go
delete from dialog where config_no=10
go

delete from dialog_event where dialog_id=1500 
go
delete from dialog_event where dialog_id=1501
go
delete from dialog_event where dialog_id=1502 
go
delete from dialog_event where dialog_id=1503
go
delete from dialog_event where dialog_id=1504 
go
delete from dialog_event where dialog_id=1505 
go
delete from dialog_event where dialog_id=1506 
go
delete from dialog_event where dialog_id=1507 
go
delete from dialog_event where dialog_id=1508
go
delete from dialog_event where dialog_id=1509 
go
delete from dialog_event where dialog_id=1510 
go
delete from dialog_event where dialog_id=1511 
go

delete from currency where config_no=10
go
delete from media where config_no=10
go
delete from pos_config where config_no=10
go
delete from promotion
go


PRINT 'delteing table data completed .................'
go

PRINT 'Creating menu panels data .................'

go


 -- Panel Classes
 insert into menu_panels values ( 10, 101, 'EclipsePos.Apps.Gui.PnlInput')
 go
 insert into menu_panels values ( 10, 102, 'EclipsePos.Apps.Gui.PnlInvoice')
 go
 insert into menu_panels values ( 10, 103, 'EclipsePos.Apps.Gui.PnlInvoiceHeader')
 go
 insert into menu_panels values ( 10, 104, 'EclipsePos.Apps.Gui.PnlInvoiceTotals')
 go
 insert into menu_panels values ( 10, 105, 'EclipsePos.Apps.Gui.PnlCurrency')
 go	
 insert into menu_panels values ( 10, 106, 'EclipsePos.Apps.Gui.PnlFunctions')
 go
 insert into menu_panels values ( 10, 107, 'EclipsePos.Apps.Gui.PnlTransactions')
 go
 insert into menu_panels values ( 10, 108, 'EclipsePos.Apps.Gui.PnlTender')
 go
 insert into menu_panels values ( 10, 109, 'EclipsePos.Apps.Gui.PnlExit')
 go
-- insert into menu_panels values ( 10, 110, 'EclipsePos.Apps.Gui.PnlTools')
-- go
 insert into menu_panels values ( 10, 111, 'EclipsePos.Apps.Gui.PnlHelp')
 go
 insert into menu_panels values ( 10, 112, 'EclipsePos.Apps.Gui.PnlItem')
 go	
 insert into menu_panels values ( 10, 113, 'EclipsePos.Apps.Gui.PnlItemLookup')
 go
 insert into menu_panels values ( 10, 114, 'EclipsePos.Apps.Gui.PnlMain')
 go
 insert into menu_panels values ( 10, 115, 'EclipsePos.Apps.Gui.PnlManager')
 go
 insert into menu_panels values ( 10, 116, 'EclipsePos.Apps.Gui.PnlNavigator')
 go
 insert into menu_panels values ( 10, 117 , 'EclipsePos.Apps.Gui.PnlAlphaNumKeys')
 go

 

PRINT 'Completed menu panels .................'
go
PRINT 'Creating config.................'

go


 -- Configurations
 -- Main 0
 insert into menu_config values ( 10, 0,  101,  10,		20,		600,	75, 0, 0, 0, 0, 0, 0, 12 )
 go
 insert into menu_config values ( 10, 0,  102,  5,		110,	1010,	335, 0, 0, 0, 0, 0, 0, 12 )
 go
 insert into menu_config values ( 10, 0,  103,  625,		10,		320,	95, 0, 0, 0, 0, 0, 0, 12 )
 go
 insert into menu_config values ( 10, 0,  104,  248,		504,		760,	152, 0, 0, 0, 0, 0, 0, 12 )
 go
 insert into menu_config values ( 10, 0,  114,  780,		450,	235,	320, 0, 0, 0, 0, 0, 0, 12 )
 go
 insert into menu_config values ( 10, 0,  116,  5,		450,	770,	310, 0, 0, 0, 0, 0, 0, 12 )
 go
 

--Functions 1 
 insert into menu_config values ( 10, 1,  101,  10,		20,		600,	75, 0, 0, 0, 0, 0, 0, 12 )
 go
 insert into menu_config values ( 10, 1,  102,  5,		110,	1010,	335, 0, 0, 0, 0, 0, 0, 12 )
 go
 insert into menu_config values ( 10, 1,  103,  625,		10,		320,	95, 0, 0, 0, 0, 0, 0, 12 )
 go
 insert into menu_config values ( 10, 1,  104,  248,		504,		760,	152, 0, 0, 0, 0, 0, 0, 12 )
 go
 insert into menu_config values ( 10, 1,  106,  780,		450,	235,	320, 0, 0, 0, 0, 0, 0, 12 )
 go
 insert into menu_config values ( 10, 1,  116,  5,		450,	770,	310, 0, 0, 0, 0, 0, 0, 12 )
 go

 
 --Tender 2
  insert into menu_config values ( 10, 2,  101,  10,		20,		600,	75, 0, 0, 0, 0, 0, 0, 12 )
 go
 insert into menu_config values ( 10, 2,  102,  5,		110,	1010,	335, 0, 0, 0, 0, 0, 0, 12 )
 go
 insert into menu_config values ( 10, 2,  103,  625,		10,		320,	95, 0, 0, 0, 0, 0, 0, 12 )
go	
 insert into menu_config values ( 10, 2,  104,  248,		504,		760,	152, 0, 0, 0, 0, 0, 0, 12 )
 go
 insert into menu_config values ( 10, 2,  108,  780,		450,	235,	320, 0, 0, 0, 0, 0, 0, 12 )
 go
 insert into menu_config values ( 10, 2,  116,  5,		450,	770,	310, 0, 0, 0, 0, 0, 0, 12 )
 go

--Exit 3
 insert into menu_config values ( 10, 3,  101,  10,		20,		600,	75, 0, 0, 0, 0, 0, 0, 12 )
 go
 insert into menu_config values ( 10, 3,  102,  5,		110,	1010,	335, 0, 0, 0, 0, 0, 0, 12 )
 go
 insert into menu_config values ( 10, 3,  103,  625,		10,		320,	95, 0, 0, 0, 0, 0, 0, 12 )
go
  insert into menu_config values ( 10, 3,  104,  248,		504,		760,	152, 0, 0, 0, 0, 0, 0, 12 )
 go
 insert into menu_config values ( 10, 3,  109,  780,		450,	235,	320, 0, 0, 0, 0, 0, 0, 12 )
 go
 insert into menu_config values ( 10, 3,  116,  5,		450,	770,	310, 0, 0, 0, 0, 0, 0, 12 )
 go

--Transactions
 insert into menu_config values ( 10, 4,  101,  10,		20,		600,	75, 0, 0, 0, 0, 0, 0, 12 )
 go
 insert into menu_config values ( 10, 4,  102,  5,		110,	1010,	335, 0, 0, 0, 0, 0, 0, 12 )
 go
 insert into menu_config values ( 10, 4,  103,  625,		10,		320,	95, 0, 0, 0, 0, 0, 0, 12 )
 go
  insert into menu_config values ( 10, 4,  104,  248,		504,		760,	152, 0, 0, 0, 0, 0, 0, 12 )
 go
 insert into menu_config values ( 10, 4,  107,  780,		450,	235,	320, 0, 0, 0, 0, 0, 0, 12 )
 go
 insert into menu_config values ( 10, 4,  116,  5,		450,	770,	310, 0, 0, 0, 0, 0, 0, 12 )
 go


--Help 5
 insert into menu_config values ( 10, 5,  101,  10,		20,		600,	75, 0, 0, 0, 0, 0, 0, 12 )
 go
 insert into menu_config values ( 10, 5,  102,  5,		110,	1010,	335, 0, 0, 0, 0, 0, 0, 12 )
 go
 insert into menu_config values ( 10, 5,  103,  625,		10,		320,	95, 0, 0, 0, 0, 0, 0, 12 )
 go
 insert into menu_config values ( 10, 5,  104,  248,		504,		760,	152, 0, 0, 0, 0, 0, 0, 12 )
 go
 insert into menu_config values ( 10, 5,  111,  780,		450,	235,	320, 0, 0, 0, 0, 0, 0, 12 )
 go
 insert into menu_config values ( 10, 5,  116,  5,		450,	770,	310, 0, 0, 0, 0, 0, 0, 12 )
 go


--Currency
 insert into menu_config values ( 10, 6,  101,  10,		20,		600,	75, 0, 0, 0, 0, 0, 0, 12 )
 go
 insert into menu_config values ( 10, 6,  102,  5,		110,	1010,	335, 0, 0, 0, 0, 0, 0, 12 )
 go
 insert into menu_config values ( 10, 6,  103,  625,		10,		320,	95, 0, 0, 0, 0, 0, 0, 12 )
 go
 insert into menu_config values ( 10, 6,  104,  248,		504,		760,	152, 0, 0, 0, 0, 0, 0, 12 )
 go
 insert into menu_config values ( 10, 6,  105,  780,		450,	235,	320, 0, 0, 0, 0, 0, 0, 12 )
 go
 insert into menu_config values ( 10, 6,  116,  5,		450,	770,	310, 0, 0, 0, 0, 0, 0, 12 )
 go

-- Item 7
 insert into menu_config values ( 10, 7,  101,  10,		20,		600,	75, 0, 0, 0, 0, 0, 0, 12 )
 go
 insert into menu_config values ( 10, 7,  102,  5,		110,	1010,	335, 0, 0, 0, 0, 0, 0, 12 )
 go
 insert into menu_config values ( 10, 7,  103,  625,		10,		320,	95, 0, 0, 0, 0, 0, 0, 12 )
 go
 insert into menu_config values ( 10, 7,  104,  248,		504,		760,	152, 0, 0, 0, 0, 0, 0, 12 )
 go
 insert into menu_config values ( 10, 7,  112,  780,		450,	235,	320, 0, 0, 0, 0, 0, 0, 12 )
 go
 insert into menu_config values ( 10, 7,  116,  5,		450,	770,	310, 0, 0, 0, 0, 0, 0, 12 )
 go

 --Manager
  insert into menu_config values ( 10, 8,  101,  10,		20,		600,	75, 0, 0, 0, 0, 0, 0, 12 )
 go 
 insert into menu_config values ( 10, 8,  102,  5,		110,	1010,	335, 0, 0, 0, 0, 0, 0, 12 )
 go
 insert into menu_config values ( 10, 8,  103,  625,		10,		320,	95, 0, 0, 0, 0, 0, 0, 12 )
 go
 insert into menu_config values ( 10, 8,  104,  248,		504,		760,	152, 0, 0, 0, 0, 0, 0, 12 )
 go
 insert into menu_config values ( 10, 8,  115,  780,		450,	235,	320, 0, 0, 0, 0, 0, 0, 12 )
 go
 insert into menu_config values ( 10, 8,  116,  5,		450,	770,	310, 0, 0, 0, 0, 0, 0, 12 )
 go


--Item Lookup
 insert into menu_config values ( 10, 9,  101,  10,		20,		600,	75, 0, 0, 0, 0, 0, 0, 12 )
 go 
 insert into menu_config values ( 10, 9,  102,  5,		110,	1010,	335, 0, 0, 0, 0, 0, 0, 12 )
 go
 insert into menu_config values ( 10, 9,  103,  625,		10,		320,	95, 0, 0, 0, 0, 0, 0, 12 )
 go
 insert into menu_config values ( 10, 9,  117,  248,		504,		760,	152, 0, 0, 0, 0, 0, 0, 12 )
 go
 insert into menu_config values ( 10, 9,  113,  780,		450,	235,	320, 0, 0, 0, 0, 0, 0, 12 )
 go

 insert into menu_config values ( 10, 9,  116,  5,		450,	770,	310, 0, 0, 0, 0, 0, 0, 12 )
 go


 PRINT 'Completed menu config .................'
 go


--InvoiceTotals
insert into pos_key values (10 , 104,	'PgUp',				1,   4,   33,	3,	448,	4,		48,		56,		0,	192,	192,	'NNNNNNNN',0, 'EclipsePos.Apps.PosEvents.PageUp',' ', ' ');
go

PRINT ' OK -.................'
go
														  				
insert into pos_key values (10 , 104,	'PgDn',				 1,   4,   34,	3,	448,	52,		48,		56,		0,	192,	192,	'NNNNNNNN',0, 'EclipsePos.Apps.PosEvents.PageDown',' ', ' ');
go
insert into pos_key values (10 , 104,	'Clear',			1,   4,   46,	3,	448,	100,	48,		56,		0,	192,	192,	'NNNNNNNN',0, 'EclipsePos.Apps.PosEvents.ClearKey',' ', ' ');
go
insert into pos_key values (10 , 104,	'Enter',			1,   4,   13,	3,	688,	100,	48,		56,		0,	192,	192,	'NNNNNNNN',0, 'EclipsePos.Apps.PosEvents.EnterKey',' ', ' ');
go
insert into pos_key values (10 , 104,	'00',				1,   4,   110,	3,	688,	4,		48,		56,		0,	192,	192,	'NNNNNNNN',0, 'EclipsePos.Apps.PosEvents.MultKey',' ', ' ');
go
insert into pos_key values (10 , 104,	'0',				1,   4,   96,	3,	688,	52,		48,		56,		0,	192,	192,	'NNNNNNNN',0, 'EclipsePos.Apps.PosEvents.NumKey',' ', ' ');
go
insert into pos_key values (10 , 104,	'1',				1,   4,   97,	3,	512,	100,	48,		56,		0,	192,	192,	'NNNNNNNN',0, 'EclipsePos.Apps.PosEvents.NumKey',' ', ' ');
go
insert into pos_key values (10 , 104,	'2',				1,   4,   98,	3,	568,	100,	48,		56,		0,	192,	192,	'NNNNNNNN',0, 'EclipsePos.Apps.PosEvents.NumKey',' ', ' ');
go														  				
insert into pos_key values (10 , 104,	'3',				1,   4,   99,	3,	624,	100,	48,		56,		0,	192,	192,	'NNNNNNNN',0, 'EclipsePos.Apps.PosEvents.NumKey',' ', ' ');
go
insert into pos_key values (10 , 104,	'4',				1,   4,   100,	3,	512,	52,		48,		56,		0,	192,	192,	'NNNNNNNN',0, 'EclipsePos.Apps.PosEvents.NumKey',' ', ' ');
go														  				
insert into pos_key values (10 , 104,	'5',				1,   4,   101,	3,	568,	52,		48,		56,		0,	192,	192,	'NNNNNNNN',0, 'EclipsePos.Apps.PosEvents.NumKey',' ', ' ');
go
insert into pos_key values (10 , 104,	'6',				1,   4,   102,	3,	624,	52,		48,		56,		0,	192,	192,	'NNNNNNNN',0, 'EclipsePos.Apps.PosEvents.NumKey',' ', ' ');
go														  				
insert into pos_key values (10 , 104,	'7',				1,   4,   103,	3,	512,	4,		48,		56,		0,	192,	192,	'NNNNNNNN',0, 'EclipsePos.Apps.PosEvents.NumKey',' ', ' ');
go
insert into pos_key values (10 , 104,	'8',				1,   4,   104,	3,	568,	4,		48,		56,		0,	192,	192,	'NNNNNNNN',0, 'EclipsePos.Apps.PosEvents.NumKey',' ', ' ');
go														  				
insert into pos_key values (10 , 104,	'9',				1,   4,   105,	3,	624,	4,		48,		56,		0,	192,	192,	'NNNNNNNN',0, 'EclipsePos.Apps.PosEvents.NumKey',' ', ' ');
go


--Navigator
insert into pos_key values (10 , 116,	'Main',				1,   4,   112,	3,	8,		8,	48,		118,		0,	192,	192,	'NNNNNNNN',1, 'EclipsePos.Apps.PosEvents.MainMenu',' ', 'F1');
go														  				
insert into pos_key values (10 , 116,	'Functions',		1,   4,   113,	3,	128,	8,  48,		118,		0,	192,	192,	'NNNNNNNN',1, 'EclipsePos.Apps.PosEvents.FunctionsMenu',' ', 'F2');
go
insert into pos_key values (10 , 116,	'Tender',			1,   4,   114,	3,	248,	8,  48,		118,		0,	192,	192,	'NNNNNNNN',1, 'EclipsePos.Apps.PosEvents.TenderMenu',' ', 'F3');
go
insert into pos_key values (10 , 116,	'Exit',				1,   4,   115,	3,	368,	8,  48,		118,		0,	192,	192,	'NNNNNNNN',1, 'EclipsePos.Apps.PosEvents.ExitMenu',' ', 'F4');
go
insert into pos_key values (10 , 116,	'Transactions',		1,   4,   116,	3,	488,	8,  48,		118,		0,	192,	192,	'NNNNNNNN',1, 'EclipsePos.Apps.PosEvents.TransactionsMenu',' ', 'F5');
go
insert into pos_key values (10 , 116,	'Manager',			1,   4,   117,	3,	608,	8,  48,		118,		0,	192,	192,	'NNNNNNNN',1, 'EclipsePos.Apps.PosEvents.ManagerMenu',' ', 'F6');
go
insert into pos_key values (10 , 116,	'Items',			1,   4,   118,	3,	728,	8,  48,		118,		0,	192,	192,	'NNNNNNNN',1, 'EclipsePos.Apps.PosEvents.ItemsMenu',' ', 'F7');
go
insert into pos_key values (10 , 116,	'Help',				1,   4,   119,	3,	848,	8,  48,		118,		0,	192,	192,	'NNNNNNNN',1, 'EclipsePos.Apps.PosEvents.HelpMenu',' ', 'F8');
go														  				
														  				
														  				
														  				
														  				
PRINT 'Pos key inset OK -.................'														  				
														  				



--Main
insert into pos_key values (10 , 114,	'Ctrl',		1,   0, 5112,		3,  170,   40,		48, 56,	0,	192,	192,	'NNNNNNNN',1,'EclipsePos.Apps.PosEvents.LookupItem','PLU', 'F1');
go
insert into pos_key values (10 , 114,	'Ctrl',		1,   3, 5113,		3,	170,   89,		48, 56,	0,	192,	192,	'NNNNNNNN',1, 'EclipsePos.Apps.PosEvents.Quantity','Quantity','F2');
go
insert into pos_key values (10 , 114,	'Ctrl',		1,   0, 5114,		3,	170,   138,		48, 56,	0,	192,	192,	'NNNNNNNN',1, 'EclipsePos.Apps.PosEvents.SubTotal','Subtotal','F3');
go
insert into pos_key values (10 , 114,	'Ctrl',		1,   1, 5115,		3,	170,   187,		48, 56,	0,	192,	192,	'NNNNNNNN',1, 'EclipsePos.Apps.PosEvents.Total','Total','F4');
go
insert into pos_key values (10 , 114,	'Ctrl',		1,   2, 5116,		3,  170,	236,	48, 56,	0,	192,	192,	'NNNNNNNN',1, 'EclipsePos.Apps.PosEvents.ItemMarkdown','Markdown','F5');
go
insert into pos_key values (10 , 114,	'Ctrl',		1,   0, 5117,		3,	170,	285,	48, 56, 0,	192,	192,	'NNNNNNNN',1, 'EclipsePos.Apps.PosEvents.ItemVoid','Void','F6');
go
insert into pos_key values (10 , 114,	'Ctrl',		1,   0,	5118,		3,	170,	334,	48, 56, 0,	192,	192,	'NNNNNNNN',1, 'EclipsePos.Apps.PosEvents.Discount', 'Discount Sale','F7');
go

--Functions
insert into pos_key values (10 , 106,	'Ctrl',		1,   2, 5112,		3,  170,		40,		48, 56, 0,	0,		-1,		'NNNNNNNN',1, 'EclipsePos.Apps.PosEvents.SaveEj', 'Store','F1');
go
insert into pos_key values (10 , 106,	'Ctrl',		1,   0, 5113,		3,  170,		89,		48, 56, 0,	0,		-1,		'NNNNNNNN',1,'EclipsePos.Apps.PosEvents.RecallEj', 'Recall','F2');
go
insert into pos_key values (10 , 106,	'Ctrl',		1,   1, 5114,		3,  170,		138,	48, 56, 0,	100,	-1,		'NNNNNNNN',1,'EclipsePos.Apps.PosEvents.PaidIn', 'Paid In','F3');
go
insert into pos_key values (10 , 106,	'Ctrl',		1,   2, 5115,		3,  170,		187,	48, 56, 0,	100,	-1,		'NNNNNNNN',1,'EclipsePos.Apps.PosEvents.PaidOut', 'Paid Out','F4');
go     				  		  		
insert into pos_key values (10 , 106,	'Ctrl',		1,   4, 5116,		3,  170,		236,	48, 56, 0,	25,		-1,		'NNNNNNNN',1,'EclipsePos.Apps.PosEvents.PickUp', 'Pickup','F5');
go
insert into pos_key values (10 , 106,	'Ctrl',		1,   4, 5117,		3,  170,		285,	48, 56, 0,	25,		-1,		'NNNNNNNN',1,'EclipsePos.Apps.PosEvents.PettyCash', 'Petty Cash','F5');
go



--Exit
insert into pos_key values (10 , 109,	'Ctrl',		1,   0,	5112,		3, 170,			40,			48, 56,0,50,-1,'NNNNNNNN',1, 'EclipsePos.Apps.PosEvents.TrainingMode', 'Training Mode','F1');
go     		 		  						  
insert into pos_key values (10 , 109,	'Ctrl',		1,   0,	5113,		3, 170,			89,			48, 56,0,	192,	192,	'NNNNNNNN',1, 'EclipsePos.Apps.PosEvents.Lock','Lock','F2');
go
insert into pos_key values (10 , 109,	'Ctrl',		1,   2,	5114,		3,  170,		138,		48, 56,0,0,-1,'NNNNNNNN',1, 'EclipsePos.Apps.PosEvents.LogOff', 'Log Off','F3');
go
insert into pos_key values (10 , 109,	'Ctrl',		1,  -1,	5115,		3,  170,		187,		48, 56,0,50,-1,'NNNNNNNN',0, 'EclipsePos.Apps.PosEvents.Exit', 'Shutdown','F4');
go

--Tender
insert into pos_key values (10 , 108,	'Ctrl' ,	1,  -1, 5112,		3, 170,			40,		48, 56,0,	192,	192,	'NNNNNNNN',1, 'EclipsePos.Apps.PosEvents.CashTender','Cash ','F1');
go
insert into pos_key values (10 , 108,	'Ctrl',		1,   0, 5113,		3, 170,			89,		48, 56,0,	192,	192,	'NNNNNNNN',1, 'EclipsePos.Apps.PosEvents.CheckTender','Check ','F2');
go
insert into pos_key values (10 , 108,	'Ctrl',		1,   0, 5114,		3, 170,			138,	48, 56,0,	192,	192,	'NNNNNNNN',1, 'EclipsePos.Apps.PosEvents.CreditTender','Credit Card ','F3');
go
insert into pos_key values (10 , 108,	'Ctrl',		1,   0, 5115,		3, 170,			187,	48, 56,0,	192,	192,	'NNNNNNNN',1, 'EclipsePos.Apps.PosEvents.AltCurrMenu','Alternate Currency Entry','F4');
go   				 							 		  			

--Transactions
insert into pos_key values (10 , 107,	'Ctrl',		1,   0, 5112,		3, 170,			40,		48, 56,0,	192,	192,	'NNNNNNNN',1, 'EclipsePos.Apps.PosEvents.VoidSale','Void Sale','F1');
go
insert into pos_key values (10 , 107,	'Ctrl',		1,   0, 5113,		3, 170,			89,		48, 56,0,	192,	192,	'NNNNNNNN',1, 'EclipsePos.Apps.PosEvents.ReturnSale','Return Sale','F2');
go   													  		  


--Item
insert into pos_key values (10 , 112,	'Ctrl',		1,   0, 5112,		3, 170,			40,		48, 56,0,	192,	192,	'NNNNNNNN',1, 'EclipsePos.Apps.PosEvents.LookupItemMenu','Description ','F1');
go
insert into pos_key values (10 , 112,	'Ctrl',		1,   0, 5113,		3, 170,			89,		48, 56,0,	192,	192,	'NNNNNNNN',1, 'EclipsePos.Apps.PosEvents.LookupItemMenu','PLU ','F2');
go   													  		  
insert into pos_key values (10 , 112,	'Ctrl',		1,   0, 5114,		3, 170,			138,	48, 56,0,	192,	192,	'NNNNNNNN',1, 'EclipsePos.Apps.PosEvents.LookupItemMenu','SKU ','F3');
go
insert into pos_key values (10 , 112,	'Ctrl',		1,   0, 5115,		3, 170,			187,	48, 56,0,	192,	192,	'NNNNNNNN',1, 'EclipsePos.Apps.PosEvents.LookupItemMenu','Group ','F4');
go   													  		  


--Help
		  			
--Alternate currency entry
insert into pos_key values (10 , 105,	'Ctrl' ,		1,   7,		5112,	3,	 170,	40,   48,  56, 0,	0,-1,'NNNNNNNN',1,'EclipsePos.Apps.PosEvents.AltCurrTender', 'Canadian','F1');
go
insert into pos_key values (10 ,105,	'Ctrl',			1,   7,		5113,	3,	170,		89,   48,  56, 0,	0,-1,'NNNNNNNN',1,'EclipsePos.Apps.PosEvents.AltCurrTender', 'Euro','F2');
go
insert into pos_key values (10 ,105,	'Ctrl',			1,   2,		5114,	3,	170,	138,  48,  56, 0,	0,-1,'NNNNNNNN',1,'EclipsePos.Apps.PosEvents.AltCurrTender', 'Deutch Marks','F3');
go
insert into pos_key values (10 , 105,	'Ctrl',			1,   4,		5115,	3,	170,	187,  48,  56, 0,	0,-1,'NNNNNNNN',1,'EclipsePos.Apps.PosEvents.AltCurrTender', 'French Francs','F4');
go
insert into pos_key values (10 ,105,	'Ctrl',			1,   3,		5116,	3,	170,	236,  48,  56, 0,	25,-1,'NNNNNNNN',1,'EclipsePos.Apps.PosEvents.AltCurrTender', 'Swiss Francs','F5');
go
insert into pos_key values (10 , 105,	'Ctrl',			1,   5,		5117,	3,	170,	285,  48,  56, 0,	25,-1,'NNNNNNNN',1,'EclipsePos.Apps.PosEvents.AltCurrTender', 'Belgian Francs','F6');
go   													  				


--Manager
insert into pos_key values (10 , 115,	'Ctrl',			1,   1,		5112,	3,	170,	40,		48,  56,	0,	25,	-1,	'NNNNNNNN',	1,	'EclipsePos.Apps.PosEvents.TerminalReport', 'X-Report','F1');
go
insert into pos_key values (10 , 115,	'Ctrl',			1,   2,		5113,	3,	170,	89,		48,  56,    0,	0,	-1,	'NNNNNNNN',	1,	'EclipsePos.Apps.PosEvents.TerminalReport', 'Z-Report','F2');
go
insert into pos_key values (10 , 115,	'Ctrl' ,		1,   3,		5114,	3,	170,	138,	48,  56,	0,	0,	-1,	'NNNNNNNN',	1,	'EclipsePos.Apps.PosEvents.ToggleAltTax', 'Toggle Alternate Tax','F3');
go     				  				


--PnlAlphaNumKeys
insert into pos_key values (10 , 117,	'PgUp',				1,   4,   33,	3,	448,	4,		48,		56,		0,	192,	192,	'NNNNNNNN',0, 'EclipsePos.Apps.PosEvents.PageUp',' ', ' ');
go														  				
insert into pos_key values (10 , 117,	'PgDn',				 1,   4,   34,	3,	448,	52,		48,		56,		0,	192,	192,	'NNNNNNNN',0, 'EclipsePos.Apps.PosEvents.PageDown',' ', ' ');
go
insert into pos_key values (10 , 117,	'Clear',			1,   4,   46,	3,	448,	100,	48,		56,		0,	192,	192,	'NNNNNNNN',0, 'EclipsePos.Apps.PosEvents.ClearKey',' ', ' ');
go
insert into pos_key values (10 , 117,	'Enter',			1,   4,   13,	3,	688,	100,	48,		56,		0,	192,	192,	'NNNNNNNN',0, 'EclipsePos.Apps.PosEvents.EnterKey',' ', ' ');
go
insert into pos_key values (10 , 117,	'00',				1,   4,   110,	3,	688,	4,		48,		56,		0,	192,	192,	'NNNNNNNN',0, 'EclipsePos.Apps.PosEvents.MultKey',' ', ' ');
go
insert into pos_key values (10 , 117,	'0',				1,   4,   96,	3,	688,	52,		48,		56,		0,	192,	192,	'NNNNNNNN',0, 'EclipsePos.Apps.PosEvents.NumKey',' ', ' ');
go
insert into pos_key values (10 , 117,	'1',				1,   4,   97,	3,	512,	100,	48,		56,		0,	192,	192,	'NNNNNNNN',0, 'EclipsePos.Apps.PosEvents.NumKey',' ', ' ');
go
insert into pos_key values (10 , 117,	'2',				1,   4,   98,	3,	568,	100,	48,		56,		0,	192,	192,	'NNNNNNNN',0, 'EclipsePos.Apps.PosEvents.NumKey',' ', ' ');
go														  				
insert into pos_key values (10 , 117,	'3',				1,   4,   99,	3,	624,	100,	48,		56,		0,	192,	192,	'NNNNNNNN',0, 'EclipsePos.Apps.PosEvents.NumKey',' ', ' ');
go
insert into pos_key values (10 , 117,	'4',				1,   4,   100,	3,	512,	52,		48,		56,		0,	192,	192,	'NNNNNNNN',0, 'EclipsePos.Apps.PosEvents.NumKey',' ', ' ');
go														  				
insert into pos_key values (10 , 117,	'5',				1,   4,   101,	3,	568,	52,		48,		56,		0,	192,	192,	'NNNNNNNN',0, 'EclipsePos.Apps.PosEvents.NumKey',' ', ' ');
go
insert into pos_key values (10 , 117,	'6',				1,   4,   102,	3,	624,	52,		48,		56,		0,	192,	192,	'NNNNNNNN',0, 'EclipsePos.Apps.PosEvents.NumKey',' ', ' ');
go														  				
insert into pos_key values (10 , 117,	'7',				1,   4,   103,	3,	512,	4,		48,		56,		0,	192,	192,	'NNNNNNNN',0, 'EclipsePos.Apps.PosEvents.NumKey',' ', ' ');
go
insert into pos_key values (10 , 117,	'8',				1,   4,   104,	3,	568,	4,		48,		56,		0,	192,	192,	'NNNNNNNN',0, 'EclipsePos.Apps.PosEvents.NumKey',' ', ' ');
go														  				
insert into pos_key values (10 , 117,	'9',				1,   4,   105,	3,	624,	4,		48,		56,		0,	192,	192,	'NNNNNNNN',0, 'EclipsePos.Apps.PosEvents.NumKey',' ', ' ');
go

insert into pos_key values (10 , 117,	'Q',				1,   4,   81,	3,	8,		15,		42,		42,		0,	192,	192,	'NNNNNNNN',0, 'EclipsePos.Apps.PosEvents.AlphaKey',' ', ' ');
go
insert into pos_key values (10 , 117,	'W',				1,   4,   87,	3,	50,		15,		42,		42,		0,	192,	192,	'NNNNNNNN',0, 'EclipsePos.Apps.PosEvents.AlphaKey',' ', ' ');
go
insert into pos_key values (10 , 117,	'E',				1,   4,   69,	3,	92,		15,		42,		42,		0,	192,	192,	'NNNNNNNN',0, 'EclipsePos.Apps.PosEvents.AlphaKey',' ', ' ');
go

insert into pos_key values (10 , 117,	'R',				1,   4,   82,	3,	134,	15,		42,		42,		0,	192,	192,	'NNNNNNNN',0, 'EclipsePos.Apps.PosEvents.AlphaKey',' ', ' ');
go
insert into pos_key values (10 , 117,	'T',				1,   4,   84,	3,	176,	15,		42,		42,		0,	192,	192,	'NNNNNNNN',0, 'EclipsePos.Apps.PosEvents.AlphaKey',' ', ' ');
go
insert into pos_key values (10 , 117,	'Y',				1,   4,   89,	3,	218,	15,		42,		42,		0,	192,	192,	'NNNNNNNN',0, 'EclipsePos.Apps.PosEvents.AlphaKey',' ', ' ');
go
insert into pos_key values (10 , 117,	'U',				1,   4,   85,	3,	260,	15,		42,		42,		0,	192,	192,	'NNNNNNNN',0, 'EclipsePos.Apps.PosEvents.AlphaKey',' ', ' ');
go
insert into pos_key values (10 , 117,	'I',				1,   4,   73,	3,	302,	15,		42,		42,		0,	192,	192,	'NNNNNNNN',0, 'EclipsePos.Apps.PosEvents.AlphaKey',' ', ' ');
go
insert into pos_key values (10 , 117,	'O',				1,   4,   79,	3,	344,	15,		42,		42,		0,	192,	192,	'NNNNNNNN',0, 'EclipsePos.Apps.PosEvents.AlphaKey',' ', ' ');
go
insert into pos_key values (10 , 117,	'P',				1,   4,   80,	3,	386,	15,		42,		42,		0,	192,	192,	'NNNNNNNN',0, 'EclipsePos.Apps.PosEvents.AlphaKey',' ', ' ');
go
insert into pos_key values (10 , 117,	'A',				1,   4,   65,	3,	32,		57,		42,		42,		0,	192,	192,	'NNNNNNNN',0, 'EclipsePos.Apps.PosEvents.AlphaKey',' ', ' ');
go
insert into pos_key values (10 , 117,	'S',				1,   4,   83,	3,	74,		57,		42,		42,		0,	192,	192,	'NNNNNNNN',0, 'EclipsePos.Apps.PosEvents.AlphaKey',' ', ' ');
go
insert into pos_key values (10 , 117,	'D',				1,   4,   68,	3,	116,	57,		42,		42,		0,	192,	192,	'NNNNNNNN',0, 'EclipsePos.Apps.PosEvents.AlphaKey',' ', ' ');
go
insert into pos_key values (10 , 117,	'F',				1,   4,   70,	3,	158,	57,		42,		42,		0,	192,	192,	'NNNNNNNN',0, 'EclipsePos.Apps.PosEvents.AlphaKey',' ', ' ');
go
insert into pos_key values (10 , 117,	'G',				1,   4,   71,	3,	200,	57,		42,		42,		0,	192,	192,	'NNNNNNNN',0, 'EclipsePos.Apps.PosEvents.AlphaKey',' ', ' ');
go
insert into pos_key values (10 , 117,	'H',				1,   4,   72,	3,	242,	57,		42,		42,		0,	192,	192,	'NNNNNNNN',0, 'EclipsePos.Apps.PosEvents.AlphaKey',' ', ' ');
go
insert into pos_key values (10 , 117,	'J',				1,   4,   74,	3,	284,	57,		42,		42,		0,	192,	192,	'NNNNNNNN',0, 'EclipsePos.Apps.PosEvents.AlphaKey',' ', ' ');
go
insert into pos_key values (10 , 117,	'K',				1,   4,   75,	3,	326,	57,		42,		42,		0,	192,	192,	'NNNNNNNN',0, 'EclipsePos.Apps.PosEvents.AlphaKey',' ', ' ');
go
insert into pos_key values (10 , 117,	'L',				1,   4,   76,	3,	368,	57,		42,		42,		0,	192,	192,	'NNNNNNNN',0, 'EclipsePos.Apps.PosEvents.AlphaKey',' ', ' ');
go
insert into pos_key values (10 , 117,	'Z',				1,   4,   90,	3,	32,		99,		42,		42,		0,	192,	192,	'NNNNNNNN',0, 'EclipsePos.Apps.PosEvents.AlphaKey',' ', ' ');
go
insert into pos_key values (10 , 117,	'X',				1,   4,   88,	3,	74,		99,		42,		42,		0,	192,	192,	'NNNNNNNN',0, 'EclipsePos.Apps.PosEvents.AlphaKey',' ', ' ');
go
insert into pos_key values (10 , 117,	'C',				1,   4,   67,	3,	116,	99,		42,		42,		0,	192,	192,	'NNNNNNNN',0, 'EclipsePos.Apps.PosEvents.AlphaKey',' ', ' ');
go
insert into pos_key values (10 , 117,	'V',				1,   4,   86,	3,	158,	99,		42,		42,		0,	192,	192,	'NNNNNNNN',0, 'EclipsePos.Apps.PosEvents.AlphaKey',' ', ' ');
go
insert into pos_key values (10 , 117,	'B',				1,   4,   66,	3,	200,	99,		42,		42,		0,	192,	192,	'NNNNNNNN',0, 'EclipsePos.Apps.PosEvents.AlphaKey',' ', ' ');
go
insert into pos_key values (10 , 117,	'N',				1,   4,   78,	3,	242,	99,		42,		42,		0,	192,	192,	'NNNNNNNN',0, 'EclipsePos.Apps.PosEvents.AlphaKey',' ', ' ');
go
insert into pos_key values (10 , 117,	'M',				1,   4,   77,	3,	284,	99,		42,		42,		0,	192,	192,	'NNNNNNNN',0, 'EclipsePos.Apps.PosEvents.AlphaKey',' ', ' ');
go
insert into pos_key values (10 , 117,	'Space',			1,   4,   32,	3,	326,	99,		42,		84,		0,	192,	192,	'NNNNNNNN',0, 'EclipsePos.Apps.PosEvents.AlphaKey',' ', ' ');
go



--PnlItemLookup 

insert into pos_key values (10 , 113,	'Ctrl',		1,   0, 5080,		3, 184,		415,		42,		42,		0,	192,	192,	'NNNNNNNN',1, 'EclipsePos.Apps.PosEvents.LookupEvent','Position to first item','P');
go
insert into pos_key values (10 , 113,	'Ctrl',		1,   0, 5088,		3, 184,		457,		42,		42,		0,	192,	192,	'NNNNNNNN',1, 'EclipsePos.Apps.PosEvents.LookupEvent','Expand/Contract columns','X');
go   													  		  
insert into pos_key values (10 , 113,	'Ctrl',		1,   0, 5083,		3, 184,		499,		42,		42,		0,	192,	192,	'NNNNNNNN',1, 'EclipsePos.Apps.PosEvents.LookupEvent','Search','S');

--Pos profile

insert into pos_profile values (10, 0, 'Manager') 
go
insert into pos_profile values ( 10, 0, 'Cashier') 
go

Print 'Pos_profile OK------'

go



insert into tax_group values (1, 10) 
go
insert into tax values (0, 1, 1, 'GST', 0.05, 0.05) 
go
insert into tax values (0, 2, 1, 'GST', 0.050, 0.050) 
go


insert into pos_param values (   10, 3, 0, 0, 'CustWelcome', 'Welcome') 
go
insert into pos_param values (   10, 3, 0, 0, 'ReceiptLine1', 'Thank you for shopping') 
go
insert into pos_param values (   10, 3, 0, 0, 'OperTitle', 'Operator Display') 
go
insert into pos_param values (   10, 3, 0, 0, 'Total', 'Total') 
go
insert into pos_param values (  10, 3, 0, 0, 'TotalTax', 'Total Tax') 
go
insert into pos_param values (  10, 3, 0, 0, 'SubTotal', 'SubTotal') 
go
insert into pos_param values (  10, 3, 0, 0, 'CashTender', 'Cash Tender') 
go
insert into pos_param values (  10, 3, 0, 0, 'CheckTender', 'Check Tender') 
go
insert into pos_param values (  10, 3, 0, 0, 'CreditCard', 'Credit Card Tender') 
go
insert into pos_param values (  10, 3, 0, 0, 'Discount', 'Discount') 
go
insert into pos_param values (  10, 3, 0, 0, 'Markout', 'Markout') 
go
insert into pos_param values (  10, 3, 0, 0, 'Change', 'Change Due') 
go
insert into pos_param values (  10, 3, 0, 0, 'CashBack', 'Cash Back') 
go
insert into pos_param values (  10, 3, 0, 0, 'CloseDrawer', 'Close Cash Drawer') 
go
insert into pos_param values (  10, 3, 0, 0, 'InsertCheck', 'Insert check') 
go
insert into pos_param values (  10, 3, 0, 0, 'InsertValidation', 'Insert Validation') 
go
insert into pos_param values (  10, 3, 0, 0, 'InsertCCValidation', 'Insert credit card receipt') 
go
insert into pos_param values (  10, 3, 0, 0, 'BadName', 'Bad user ID, press clear') 
go
insert into pos_param values ( 10, 3, 0, 0, 'BadPass', 'Invalid password, press clear') 
go
insert into pos_param values (  10, 3, 0, 0, 'InvalidCustomer', 'Invalid customer number, press clear') 
go
insert into pos_param values (  10, 3, 0, 0, 'TooMany', 'Too many logon attempts, press clear-') 
go
insert into pos_param values (  10, 3, 0, 0, 'GoodLogin', 'Logon successful') 
go
insert into pos_param values (  10, 3, 0, 0, 'OkText', 'OK') 
go
insert into pos_param values (  10, 3, 0, 0, 'CancelText', 'Cancel') 
go
insert into pos_param values (  10, 3, 0, 0, 'ClearText', 'Clear') 
go
insert into pos_param values (  10, 3, 0, 0, 'InvalidInput', 'Invalid Input, press clear') 
go
insert into pos_param values (  10, 3, 0, 0, 'PromptOpenAmount', 'Enter open amount: ') 
go
insert into pos_param values (  10, 3, 0, 0, 'PromptAmount', 'Enter amount: ') 
go
insert into pos_param values (  10, 3, 0, 0, 'PromptCashBack', 'Cash back amount:') 
go
insert into pos_param values (  10, 3, 0, 0, 'ConfirmOpenAmount', 'Confirm (enter/clear)') 
go
insert into pos_param values (  10, 3, 0, 0, 'RegOpen', 'Register Open') 
go
insert into pos_param values (  10, 3, 0, 0, 'ReturnSale', 'Return Sale') 
go
insert into pos_param values ( 10, 3, 0, 0, 'TotalRequired', 'Total Required, press clear') 
go
insert into pos_param values (  10, 3, 0, 0, 'InsufficientFunds', 'Insufficient Funds, press clear') 
go
insert into pos_param values (  10, 3, 0, 0, 'BalanceDue', 'Balance Due:') 
go
insert into pos_param values (  10, 3, 0, 0, 'MgrIntervention', 'Manager intervention required') 
go
insert into pos_param values (  10, 3, 0, 0, 'EnterUser', 'Enter User ID: ') 
go
insert into pos_param values (  10, 3, 0, 0, 'EnterPass', 'Enter Password: ') 
go
insert into pos_param values (  10, 3, 0, 0, 'LoginTab', 'Login') 
go
insert into pos_param values (  10, 3, 0, 0, 'PromptDrawerNo', 'Enter drawer number: ') 
go
insert into pos_param values (  10, 3, 0, 0, 'ConfirmDrawerNo', 'Confirm (enter/clear)') 
go
insert into pos_param values (  10, 3, 0, 0, 'BadDrawerNo', 'Invalid drawer number') 
go
insert into pos_param values (  10, 3, 0, 0, 'BadCheckNo', 'Invalid check number') 
go
insert into pos_param values (  10, 3, 0, 0, 'BadCCNo', 'Invalid credit card') 
go
insert into pos_param values (  10, 3, 0, 0, 'BadExpr', 'Bad expiration date') 
go
insert into pos_param values (  10, 3, 0, 0, 'PromptCustomer', 'Enter Customer Number: ') 
go
insert into pos_param values (  10, 3, 0, 0, 'VoidSale', 'Sale Voided, press enter') 
go
insert into pos_param values (  10, 3, 0, 0, 'ConvertedAltCurrency', 'Converted total') 
go
insert into pos_param values (  10, 3, 0, 0, 'AltCurrTenderPrompt', 'Enter alternate currency amount: ') 
go
insert into pos_param values (  10, 3, 0, 0, 'AltCurrencyDescription', 'Alternate Currency Tender') 
go
insert into pos_param values (  10, 3, 0, 0, 'TenderTotal', 'Amount Tendered') 
go
insert into pos_param values (  10, 3, 0, 0, 'TerminalLocked', 'Terminal locked, press enter') 
go
insert into pos_param values (  10, 3, 0, 0, 'EnterItem', 'Enter item') 
go
insert into pos_param values (  10, 3, 0, 0, 'EnterWeight', 'Enter weight') 
go
insert into pos_param values (  10, 3, 0, 0, 'Pause', 'Press enter to continue...') 
go
insert into pos_param values (  10, 3, 0, 0, 'CloaeCash', 'Close cash drawer.') 
go
insert into pos_param values (  10, 3, 0, 0, 'RecallFailed', 'Transaction not found') 
go
insert into pos_param values (  10, 3, 0, 0, 'CashLimitExceeded', 'Cash in drawer limit exceeded') 
go
insert into pos_param values (  10, 3, 0, 0, 'EnterNewPrice', 'Enter new price:') 
go
insert into pos_param values (  10, 3, 0, 0, 'PosPrinterFailed', 'PRINTER FAILURE') 
go
insert into pos_param values (  10, 3, 0, 0, 'PosPrinterError', 'PRINTER ERROR') 
go
insert into pos_param values (  10, 3, 0, 0, 'ReceiptTopMOD', 'Welcome to Mercator') 
go
insert into pos_param values (  10, 3, 0, 0, 'ReceiptBottomMOD', 'Thank you for shopping') 
go
insert into pos_param values (  10, 3, 0, 0, 'ReceiptTrxTag', 'TAX') 
go
insert into pos_param values (  10, 3, 0, 0, 'ReceiptPosTag', 'REG') 
go
insert into pos_param values (  10, 3, 0, 0, 'ReceiptEmpTag', 'EMP') 
go
insert into pos_param values (  10, 3, 0, 0, 'SavedReceipt', 'Sale Saved') 
go
insert into pos_param values (  10, 3, 0, 0, 'TrxNo', 'TRX: ') 
go
insert into pos_param values (  10, 3, 0, 0, 'PosNo', 'POS: ') 
go
-- insert into pos_param values (  10, 3, 0, 0, 'PosPrinterError', 'Printer Error') 
--go
insert into pos_param values (  10, 3, 0, 0, 'CashDrawerError', 'Cash Drawer Error') 
go
insert into pos_param values (  10, 3, 0, 0, 'PosLineDisplayError', 'Line Display Error') 
go
insert into pos_param values (  10, 4, 0, 0, 'SpeedDrawer', 'false') 
go
insert into pos_param values (  10, 3, 0, 0, 'ReceiptClass', 'com.globalretailtech.pos.devices.Receipt')
 
goinsert into pos_param values ( 10, 3, 0, 0, 'OperPromptClass', 'com.globalretailtech.pos.devices.OperPrompt')
 
goinsert into pos_param values ( 10, 3, 0, 0, 'InitDialog', 'Open') 
go
insert into pos_param values (  10, 4, 0, 0, 'PromptForReceipt', 'false') 
go
insert into pos_param values (  10, 3, 0, 0, 'MathClass', 'com.globalretailtech.pos.operators.SimpleMath') 
go
insert into pos_param values (  10, 3, 0, 0, 'FieldsClass', 'com.globalretailtech.pos.operators.SimpleFields') 
go
insert into pos_param values (  10, 4, 0, 0, 'ReceiptPrintAddr1', 'true') 
go
insert into pos_param values (  10, 4, 0, 0, 'ReceiptPrintAddr2', 'true') 
go
insert into pos_param values (  10, 4, 0, 0, 'ReceiptPrintAddr3', 'true') 
go
insert into pos_param values (  10, 4, 0, 0, 'ReceiptPrintAddr4', 'true') 
go
insert into pos_param values (  10, 4, 0, 0, 'ReceiptPrintAddr5', 'true') 
go
insert into pos_param values (  10, 4, 0, 0, 'ReceiptPrintTel', 'true') 
go

insert into pos_param values (  10, 4, 0, 0, 'NavigateButtons', 'true') 
go
insert into pos_param values (  10, 3, 0, 0, 'OperReceiptFont', 'Lucida Sans Typewriter Regular') 
go
insert into pos_param values (  10, 3, 0, 0, 'HeaderFont', 'Courier') 
go
insert into pos_param values (  10, 3, 0, 0, 'HeaderTitleFont', 'Helvetica') 
go
insert into pos_param values (  10, 1, 0, 0, 'OperReceiptFontSize', '15') 
go
insert into pos_param values (  10, 1, 0, 0, 'HeaderFontSize', '12') 
go
insert into pos_param values (  10, 1, 0, 0, 'HeaderTitleFontSize', '14') 
go
insert into pos_param values (  10, 1, 0, 0, 'RowHeight', '30') 
go
insert into pos_param values (  10, 1, 0, 0, 'QtyWidth', '55') 
go
insert into pos_param values (  10, 1, 0, 0, 'DescWidth', '250') 
go
insert into pos_param values (  10, 1, 0, 0, 'ValueWidth', '112') 
go
insert into pos_param values (  10, 1, 0, 0, 'TableRows', '200') 
go
insert into pos_param values (  10, 1, 0, 0, 'TrxWidth', '10') 
go
insert into pos_param values (  10, 1, 0, 0, 'PosWidth', '4') 
go
insert into pos_param values (  10, 1, 0, 0, 'EmpWidth', '4') 
go
insert into pos_param values (  10, 1, 0, 0, 'DateWidth', '14') 
go



insert into pos_param values (  10, 3, 0, 0, 'MarkdownLiteral1', 'Take ') 
go
insert into pos_param values (  10, 3, 0, 0, 'MarkdownLiteral2', '% Off') 
go


insert into pos_param values (  10, 3, 0, 0, 'NonTaxCount', 'Non-Tax transactions') 
go
insert into pos_param values (  10, 3, 0, 0, 'NonTaxAmount', 'Non-Tax amount') 
go
insert into pos_param values (  10, 3, 0, 0, 'TaxCount', 'Tax transactions ') 
go
insert into pos_param values (  10, 3, 0, 0, 'TaxAmount', 'Tax amount ') 
go
insert into pos_param values (  10, 3, 0, 0, 'VoidCount', 'Void transactions') 
go
insert into pos_param values (  10, 3, 0, 0, 'VoidAmount', 'Void amount') 
go
insert into pos_param values (  10, 3, 0, 0, 'ReturnCount', 'Return transactions') 
go
insert into pos_param values (  10, 3, 0, 0, 'ReturnAmount', 'Return amount') 
go
insert into pos_param values (  10, 3, 0, 0, 'CouponCount', 'Coupon transactions') 
go
insert into pos_param values (  10, 3, 0, 0, 'CouponAmount', 'Coupon amount') 
go
insert into pos_param values (  10, 3, 0, 0, 'CreditCount', 'Credit transactions') 
go
insert into pos_param values (  10, 3, 0, 0, 'CreditAmount', 'Credit amount') 
go
insert into pos_param values (  10, 3, 0, 0, 'CheckCount', 'Check transactions') 
go
insert into pos_param values (  10, 3, 0, 0, 'CheckAmount', 'Check amount') 
go
insert into pos_param values (  10, 3, 0, 0, 'RecdOnAcctCount', 'Received on account transactions') 
go
insert into pos_param values (  10, 3, 0, 0, 'RecdOnAcctAmount', 'Received on account amount') 
go
insert into pos_param values (  10, 3, 0, 0, 'PaidInCount', 'Paid in transactions') 
go
insert into pos_param values (  10, 3, 0, 0, 'PaidInAmount', 'Paid in Amount') 
go
insert into pos_param values (  10, 3, 0, 0, 'PaidOutCount', 'Paid out transactions') 
go
insert into pos_param values (  10, 3, 0, 0, 'PaidOutAmount', 'Paid out Amount') 
go
insert into pos_param values (  10, 3, 0, 0, 'CashInDrCount', 'Cash transactions') 
go
insert into pos_param values (  10, 3, 0, 0, 'CashInDrAmount', 'Cash in Drawer Amount') 
go
insert into pos_param values (  10, 3, 0, 0, 'LoanCount', 'Loan transactions') 
go
insert into pos_param values (  10, 3, 0, 0, 'LoanAmount', 'Loans amount') 
go
insert into pos_param values (  10, 3, 0, 0, 'PickupCount', 'Pickup transactions') 
go
insert into pos_param values (  10, 3, 0, 0, 'PickupAmount', 'Pickup amount') 
go
insert into pos_param values (  10, 3, 0, 0, 'PickupAmount1', ' transactions') 
go
insert into pos_param values (  10, 3, 0, 0, 'PickupAmount2', ' amount') 
go
insert into pos_param values (  10, 2, 0, 0, 'CashPickup', '10000.0') 
go
insert into pos_param values (  10, 1, 0, 0, 'NumCashDrawers', '2') 
go
insert into pos_param values (  10, 3, 0, 0, 'DailyXHeader', 'X-Daily Report') 
go
insert into pos_param values (  10, 3, 0, 0, 'DailyZHeader', 'Z-Daily Report') 
go
insert into pos_param values (  10, 3, 0, 0, 'WeeklyXHeader', 'X-Weekly Report') 
go
insert into pos_param values (  10, 3, 0, 0, 'WeeklyZHeader', 'Z-Weekly Report') 
go
insert into pos_param values (  10, 3, 0, 0, 'MonthlyXHeader', 'X-Monthly Report') 
go
insert into pos_param values (  10, 3, 0, 0, 'MonthlyZHeader', 'Z-Monthly Report') 
go


insert into pos_param values (  10, 3, 0, 0, 'PromptPosNo', 'Enter POS Number: ') 
go
insert into pos_param values (  10, 3, 0, 0, 'PromptTransNo', 'Enter Transaction Number:') 
go
insert into pos_param values (  10, 3, 0, 0, 'NoSaleCount', 'No sale transactions') 
go
insert into pos_param values (  10, 3, 0, 0, 'TransNo', 'TRANS#') 
go
insert into pos_param values (  10, 3, 0, 0, 'TransType', 'TRANS TYPE') 
go
insert into pos_param values (  10, 3, 0, 0, 'OperLogon', 'Operator logon') 
go
insert into pos_param values (  10, 3, 0, 0, 'OperLogoff', 'Operator logoff') 
go
insert into pos_param values (  10, 3, 0, 0, 'BankTrans', 'Bank transaction') 
go
insert into pos_param values (  10, 3, 0, 0, 'PromptCheckNo', 'Enter check number:') 
go
insert into pos_param values (  10, 3, 0, 0, 'PromptCCNo', 'Enter credit card number:') 
go
insert into pos_param values (  10, 3, 0, 0, 'PromptCCExpr', 'Enter expiration data:') 
go
insert into pos_param values (  10, 3, 0, 0, 'Confirm', 'Press enter') 
go
insert into pos_param values (  10, 3, 0, 0, 'GroupDiscount', '10% off third item') 
go

insert into pos_param values (  10, 3, 0, 0, 'SiteName', 'Eclipse Retailers, Inc.') 
go
insert into pos_param values (  10, 3, 0, 0, 'SiteAddr1', '9601 Provost Road') 
go
insert into pos_param values (  10, 3, 0, 0, 'SiteAddr2', 'Silverdale') 
go
insert into pos_param values (  10, 3, 0, 0, 'SiteAddr3', 'Singapore') 
go
insert into pos_param values (  10, 3, 0, 0, 'SiteAddr4', '111113') 
go
insert into pos_param values (  10, 3, 0, 0, 'SiteAddr5', '') 
go
insert into pos_param values (  10, 3, 0, 0, 'SiteAddr6', '') 
go
insert into pos_param values (  10, 3, 0, 0, 'SitePhone', '(555) 555-1234') 
go
insert into pos_param values (  10, 3, 0, 0, 'SiteFax', '(555) 555-4321') 
go
insert into pos_param values (  10, 3, 0, 0, 'TrxTag', 'Transaction') 
go
insert into pos_param values (  10, 3, 0, 0, 'PosTag', 'Register') 
go
insert into pos_param values (  10, 3, 0, 0, 'EmpTag', 'Employee') 
go
insert into pos_param values (  10, 3, 0, 0, 'DateTag', 'Time/Date') 
go
insert into pos_param values (  10, 3, 0, 0, 'TimeTag', 'Time ') 
go
insert into pos_param values (  10, 3, 0, 0, 'QtyHeader', 'Qty') 
go
insert into pos_param values (  10, 3, 0, 0, 'ItemWidth', '168') 
go
--insert into pos_param values (  10, 3, 0, 0, 'DescWidth', '280') 
--go
--insert into pos_param values (  10, 3, 0, 0, 'QtyWidth', '73')
--go
insert into pos_param values (  10, 3, 0, 0, 'PriceWidth', '105') 
go
--insert into pos_param values (  10, 3, 0, 0, 'ValueWidth', '130')
--go
--insert into pos_param values (  10, 3, 0, 0, 'QtyWidth', '73')
go 
insert into pos_param values (  10, 3, 0, 0, 'DescHeader', 'Description') 
go
insert into pos_param values (  10, 3, 0, 0, 'PriceHeader', 'Price') 
go
insert into pos_param values (  10, 3, 0, 0, 'PLUHeader', 'PLU') 
go
insert into pos_param values (  10, 3, 0, 0, 'ValueHeader', 'Value') 
go
insert into pos_param values (  10, 3, 0, 0, 'CustNoTag', 'Number') 
go
insert into pos_param values (  10, 3, 0, 0, 'CustNameTag', 'Name') 
go
insert into pos_param values (  10, 3, 0, 0, 'CustAddrTag', 'Address') 
go
insert into pos_param values (  10, 3, 0, 0, 'CustCityTag', 'City') 
go
insert into pos_param values (  10, 3, 0, 0, 'CustStateTag', 'State') 
go
insert into pos_param values (  10, 3, 0, 0, 'CustZipTag', 'Zip') 
go
insert into pos_param values (  10, 3, 0, 0, 'CustPhoneTag', 'Phone') 
go
insert into pos_param values (  10, 3, 0, 0, 'CustFaxTag', 'Fax') 
go
insert into pos_param values (  10, 3, 0, 0, 'CustEmailTag', 'E-Mail') 
go
insert into pos_param values (  10, 3, 0, 0, 'OverMeiaLimit', 'Over Media Limit') 
go
insert into pos_param values (  10, 3, 0, 0, 'UnderMediaLimit', 'Under Media Limit') 
go
insert into pos_param values (  10, 3, 0, 0, 'ConvertedTotal', 'Converted Total') 
go
insert into pos_param values (  10, 3, 0, 0, 'AltCurrTotal', 'Alternate Currency Total') 
go



insert into pos_param values (  10, 3, 0, 0, 'LocaleLanguage', 'en') 
go
insert into pos_param values (  10, 3, 0, 0, 'LocaleCountry', 'US') 
go
insert into pos_param values (  10, 3, 0, 0, 'LocaleVariant', '') 
go

insert into pos_param values (  10, 2, 0, 0, 'DecimalPlaces', '2') 
go
insert into pos_param values (  10, 4, 0, 0, 'PromptForCashBack', 'TRUE') 
go
insert into pos_param values (  10, 1, 0, 0, 'DefaultDrawerNo', '1') 
go
insert into pos_param values (  10, 3, 0, 0, 'Idle1', ' Welcome to         ') 
go
insert into pos_param values (  10, 3, 0, 0, 'Idle2', '       my shop......') 
go
insert into pos_param values (  10, 3, 0, 0, 'MaximumPluLength', '13') 
go

insert into pos_param values (  10, 3, 0, 0, 'ReturnSalePrompt', 'Return Sale') 
go

print 'pos_param-----OK'

go

insert into dialog values (1500, 10, 0, 1, 'Open') 
go
insert into dialog_event values (10,  1500, 1, 0, 'Register Open', 0,  1, 1, 'EclipsePos.Apps.PosEvents.RegisterOpen') 
go
insert into dialog_event values (10, 1500, 2, 0, null, 0,  1, 1, 'EclipsePos.Apps.PosEvents.StartTransaction') 
go
insert into dialog_event values (10, 1500, 3, 0, null, 0,  1, 1, 'EclipsePos.Apps.PosEvents.NewLogon') 
go
insert into dialog_event values (10, 1500, 4, 0, 'Complete logon', 8,  1, 1, 'EclipsePos.Apps.PosEvents.Logon') 
go
insert into dialog_event values (10, 1500, 5, 0, 'Get Open Amount', 3,  0, 0, null) 
go
insert into dialog_event values (10, 1500, 6, 0, 'Get Drawer', 2,  0, 0, null) 
go
insert into dialog_event values (10, 1500, 7, 0, null, 0,  1, 1, 'EclipsePos.Apps.PosEvents.StartTransaction') 
go




insert into dialog values (1501, 10, 0, 1, 'Logon') 
go


-- insert into dialog_event values (10,  1501, 1, 0, null, 0,  1, 1, 'EclipsePos.Apps.PosEvents.RegisterOpen') 
-- go
-- insert into dialog_event values (10,  1501, 2, 0, null, 0,  1, 1, 'EclipsePos.Apps.PosEvents.StartTransaction') 
-- go
-- insert into dialog_event values (10,  1501, 3, 0, null, 0,  1, 1, 'EclipsePos.Apps.PosEvents.NewLogon') 
-- go
-- insert into dialog_event values (10,  1501, 4, 0, null, 0,  1, 1, 'EclipsePos.Apps.PosEvents.Logon') 
-- go

insert into dialog_event values (10,  1501, 1, 0, null, 0,  1, 1, 'EclipsePos.Apps.PosEvents.RegisterOpen') 
go
insert into dialog_event values (10,  1501, 2, 0, null, 0,  1, 1, 'EclipsePos.Apps.PosEvents.StartTransaction') 
go
insert into dialog_event values (10,  1501, 3, 0, null, 0,  1, 1, 'EclipsePos.Apps.PosEvents.NewLogon') 
go
insert into dialog_event values (10,  1501, 4, 0, null, 0,  1, 1, 'EclipsePos.Apps.PosEvents.LogOn') 
go
insert into dialog_event values (10,  1501, 9, 0, null, 0,  1, 1, 'EclipsePos.Apps.PosEvents.StartTransaction') 
go



insert into dialog values (1502, 10, 0, 1, 'ManagerRequired') 
go


insert into dialog_event values (10,  1502, 1,  0, null, 1005, 1, 1, 'EclipsePos.Apps.PosEvents.Error') 
go
insert into dialog_event values (10,  1502, 2,  0, null, 29,   1, 1, 'EclipsePos.Apps.PosEvents.UserValidation') 
go
insert into dialog_event values (10,  1502, 4,  0, null, 30,   1, 1, null) 
go
insert into dialog_event values (10,  1502, 4,  0, null, 70,   1, 1, null) 
go



insert into dialog values (1503, 10, 0, 1, 'CashTender') 
go



insert into dialog_event values (10,  1503, 1, 0, null, 0,  1, 1, 'EclipsePos.Apps.PosEvents.RegisterOpen') 
go
insert into dialog_event values (10,  1503, 2, 0, null, 0,  1, 1, 'EclipsePos.Apps.PosEvents.StartTransaction') 
go
insert into dialog_event values (10,  1503, 3, 0, null, 0, 1, 1, 'EclipsePos.Apps.PosEvents.FinishTransaction') 
go
insert into dialog_event values (10,  1503, 4, 0, null, 0, 1, 1, 'EclipsePos.Apps.PosEvents.CloseCashDrawer') 
go
insert into dialog_event values (10,  1503, 5, 0, null, 0, 1, 1, 'EclipsePos.Apps.PosEvents.PromptPrintReceipt') 
go
insert into dialog_event values (10,  1503, 6, 0, null, 0, 1, 1, 'EclipsePos.Apps.EJournal.EjTender') 
go
insert into dialog_event values (10,  1503, 7, 0, null, 0, 1, 1, 'EclipsePos.Apps.PosEvents.CheckHardware') 
go



insert into dialog values (1504, 10, 0, 1, 'CheckTender') 
go



insert into dialog_event values (10,  1504, 1, 0, null, 0,  1, 1, 'EclipsePos.Apps.PosEvents.RegisterOpen') 
go
insert into dialog_event values (10,  1504, 2, 0, null, 0,  1, 1, 'EclipsePos.Apps.PosEvents.StartTransaction') 
go
insert into dialog_event values (10,  1504, 3, 0, null, 0, 1, 1, 'EclipsePos.Apps.PosEvents.FinishTransaction') 
go
insert into dialog_event values (10,  1504, 4, 0, null, 0, 1, 1, 'EclipsePos.Apps.PosEvents.CloseCashDrawer') 
go
insert into dialog_event values (10,  1504, 5, 0, null, 0, 1, 1, 'EclipsePos.Apps.PosEvents.PromptPrintReceipt') 
go
insert into dialog_event values (10,  1504, 6, 0, null, 5, 1, 1, 'EclipsePos.Apps.EJournal.EjCheckTender')  
go
insert into dialog_event values (10,  1504, 7, 0, null, 2, 1, 1, null) 
go
insert into dialog_event values (10,  1504, 8, 0, null, 1, 1, 1, null) 
go
insert into dialog_event values (10,  1504, 9, 0, null, 0, 1, 1, 'EclipsePos.Apps.PosEvents.CheckHardware') 
go


insert into dialog values (1505, 10, 0, 1, 'CreditTender') 
go



insert into dialog_event values (10,  1505, 1, 0, null, 0,  1, 1, 'EclipsePos.Apps.PosEvents.RegisterOpen') 
go
insert into dialog_event values (10,  1505, 2, 0, null, 0, 1, 1, 'EclipsePos.Apps.PosEvents.StartTransaction') 
go
insert into dialog_event values (10,  1505, 3, 0, null, 0, 1, 1, 'EclipsePos.Apps.PosEvents.FinishTransaction') 
go
insert into dialog_event values (10,  1505, 4, 0, null, 0, 1, 1, 'EclipsePos.Apps.PosEvents.CloseCashDrawer') 
go
insert into dialog_event values (10,  1505, 5, 0, null, 0, 1, 1, 'EclipsePos.Apps.PosEvents.PromptPrintReceipt') 
go
insert into dialog_event values (10,  1505, 6, 0, null, 8, 1, 1, 'EclipsePos.Apps.EJournal.EjCCTender') 
go
insert into dialog_event values (10,  1505, 7, 0, null, 7, 1, 1, null) 
go
insert into dialog_event values (10,  1505, 8, 0, null, 3, 1, 1, null) 
go
insert into dialog_event values (10,  1505, 9, 0, null, 2, 1, 1, null) 
go
insert into dialog_event values (10,  1505, 10 , 0, null, 1, 1, 1, null) 
go
insert into dialog_event values (10,  1505, 11, 0, null, 0, 1, 1, 'EclipsePos.Apps.PosEvents.CheckHardware') 
go




insert into dialog values (1506, 10, 0, 1, 'AltCurrTender') 
go



insert into dialog_event values (10,  1506, 1, 0, null, 0, 1, 1, 'EclipsePos.Apps.PosEvents.RegisterOpen') 
go
insert into dialog_event values (10,  1506, 2, 0, null, 0, 1, 1, 'EclipsePos.Apps.PosEvents.StartTransaction') 
go
insert into dialog_event values (10,  1506, 3, 0, null, 0, 1, 1, 'EclipsePos.Apps.PosEvents.FinishTransaction') 
go
insert into dialog_event values (10,  1506, 4, 0, null, 0, 1, 1, 'EclipsePos.Apps.PosEvents.CloseCashDrawer') 
go
insert into dialog_event values (10,  1506, 5, 0, null, 0, 1, 1, 'EclipsePos.Apps.PosEvents.PromptPrintReceipt') 
go
insert into dialog_event values (10,  1506, 5, 0, null, 1, 1, 1, 'EclipsePos.Apps.EJournal.EjAltCurrTender') 
go



insert into dialog values (1507, 10, 0, 1, 'RecallEj') 
go


insert into dialog_event values (10,  1507, 1, 0, null, 5, 1, 1, 'EclipsePos.Apps.PosEvents.RecallEj') 
go
insert into dialog_event values (10,  1507, 2, 0, null, 2, 1, 1, null) 
go
insert into dialog_event values (10,  1507, 3, 0, null, 1, 1, 1, null) 
go
insert into dialog_event values (10,  1507, 4, 0, null, 0, 1, 1, null) 
go



insert into dialog values (1508, 10, 0, 1, 'PaidIn') 
go


insert into dialog_event values (10,  1508, 1, 0, null, 0, 1, 1, 'EclipsePos.Apps.PosEvents.RegisterOpen') 
go
insert into dialog_event values (10,  1508, 2, 0, null, 0, 1, 1, 'EclipsePos.Apps.PosEvents.StartTransaction') 
go
insert into dialog_event values (10,  1508, 3, 0, null, 0, 1, 1, 'EclipsePos.Apps.PosEvents.FinishTransaction') 
go
insert into dialog_event values (10,  1508, 4, 0, null, 0, 1, 1, 'EclipsePos.Apps.PosEvents.CloseCashDrawer') 
go
insert into dialog_event values (10,  1508, 5, 0, null, 1, 1, 1, 'EclipsePos.Apps.EJournal.EjBank') 
go


insert into dialog values (1509, 10,  0, 1, 'PaidOut') 
go


insert into dialog_event values (10,  1509, 1, 0, null, 0, 1, 1, 'EclipsePos.Apps.PosEvents.RegisterOpen') 
go
insert into dialog_event values (10,  1509, 2, 0, null, 0, 1, 1, 'EclipsePos.Apps.PosEvents.StartTransaction') 
go
insert into dialog_event values (10,  1509, 3, 0, null, 0, 1, 1, 'EclipsePos.Apps.PosEvents.FinishTransaction') 
go
insert into dialog_event values (10,  1509, 4, 0, null, 0, 1, 1, 'EclipsePos.Apps.PosEvents.CloseCashDrawer') 
go
insert into dialog_event values (10,  1509, 5, 0, null, 2, 1, 1, 'EclipsePos.Apps.EJournal.EjBank') 
go



insert into dialog values (1511, 10, 0, 1, 'PettyCash') 
go


insert into dialog_event values (10,  1511, 1, 0, null, 0, 1, 1, 'EclipsePos.Apps.PosEvents.RegisterOpen') 
go
insert into dialog_event values (10,  1511, 2, 0, null, 0, 1, 1, 'EclipsePos.Apps.PosEvents.StartTransaction') 
go
insert into dialog_event values (10,  1511, 3, 0, null, 0, 1, 1, 'EclipsePos.Apps.PosEvents.FinishTransaction') 
go
insert into dialog_event values (10,  1511, 4, 0, null, 0, 1, 1, 'EclipsePos.Apps.PosEvents.CloseCashDrawer') 
go
insert into dialog_event values (10,  1511, 5, 0, null, 1, 1, 1, 'EclipsePos.Apps.EJournal.EjBank') 
go


insert into dialog values (1510, 10, 0, 1, 'UnLock') 
go



insert into dialog_event values (10,  1510, 1, 0, null, 2, 1, 1, 'EclipsePos.Apps.PosEvents.UnLock') 
go
insert into dialog_event values (10,  1510, 2, 0, null, 0, 1, 1, null) 
go



insert into currency values ( 10, 1,   1.0,      1, 2, 'US', 1, 1, 'Apr 25 2007 08:00AM', null) 
go
insert into currency values ( 10, 28,  2.12868,  1, 2, 'DE', 0, 0, 'Apr 25 2007 08:00AM', null) 
go
insert into currency values ( 10, 30,  1.610400,  1, 2, 'CH', 0, 0, 'Apr 25 2007 08:00AM', null) 
go
insert into currency values ( 10, 69,  7.13928,  1, 2, 'FR', 0, 0, 'Apr 25 2007 08:00AM', null) 
go
insert into currency values ( 10, 36,  43.9050,  1, 2, 'BE', 0, 0, 'Apr 25 2007 08:00AM', null) 
go
insert into currency values ( 10, 37,  1.58014,  1, 2, 'CA', 0, 0, 'Apr 25 2007 08:00AM', null) 
go
insert into currency values ( 10, 89,  1.13236,  1, 2, 'EU', 0, 0, 'Apr 25 2007 08:00AM', null) 
go


insert into media values ( 10, 1, 20000, 0, 'Cash', null) 
go
insert into media values ( 10, 2, 100, 0, 'Check', null) 
go
insert into media values ( 10, 3, 100000, 0, 'Visa', null) 
go
insert into media values ( 10, 4, 100000, 0, 'Master Card', null) 
go
insert into media values ( 10, 5, 100000, 0, 'American Express', null) 
go
insert into media values ( 10, 6, 100000, 0, 'Debit Card', null) 
go
insert into media values ( 10, 7, 100000, 0, 'Euro', null) 
go
insert into media values ( 10, 8, 100000, 0, 'DEM', null) 
go
insert into media values ( 10, 9, 100000, 0, 'DKK', null) 
go

insert into pos_config values (  10, 'Pos Configuration' ) 

go

insert into promotion values ( 1, 5118, 1,   3, 0, 0, 0, 0,    30,  0, 0, 0, 0,   0,	 ' ', ' ', 'Group Discount',	'EclipsePos.Apps.Operators.GroupDiscount' )
go
insert into promotion values ( 2, 2, 1,   3, 0, 0, 0, 0,   500,  0, 0, 0, 0,   0,	 ' ', ' ', ' ',	'EclipsePos.Apps.Operators.NForX' )
go
insert into promotion values ( 3, 3, 1,   3, 0, 0, 0, 0,   100,  0, 0, 0, 0,   0,	 ' ', ' ', ' ',	'EclipsePos.Apps.Operators.NForX' )
go 

insert into promotion values ( 1, 5116, 1,   1, 0, 0, 0, 0,    5,  0, 0, 0, 0,   0,	 ' ', ' ', 'Item markdown ',	'EclipsePos.Apps.Operators.ItemDiscount' )
go
