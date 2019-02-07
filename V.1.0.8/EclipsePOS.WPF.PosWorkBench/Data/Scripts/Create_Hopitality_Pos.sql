/*USE [C:\DOCUMENTS AND SETTINGS\NAUSHARD\MY DOCUMENTS\POSSITE.MDF] */
 use possite 
/*USE [C:\C#PROJECTS\ECLIPSEPOS.WPF.SYSTEMMANAGER\ECLIPSEPOS.WPF.SYSTEMMANAGER\BIN\DEBUG\RDMS\POSSITE.MDF]
GO
*/
/*
use  [C:\C#PROJECTS\ECLIPSEPOS.WPF.POSWORKBENCH\DATA\POSSITE.MDF]
*/
go
 
/* use possite
go
*/

/****** Object:  Table [dbo].[Testing]    Script Date: 06/23/2008 18:35:24 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

delete from pos_key where config_no = 2
go




delete from menu_panels where config_no =  2
go



print('ok1')
go


--delete from pos_profile where config_no = 0
--go

--delete from tax_group where config_no =0
--go
delete from pos_param where config_no= 2
go
delete from dialog where config_no=2
go
delete from dialog_event where dialog_event_id = 2
go

delete from promotion where config_no = 2;
go

delete from media where config_no=2
go


delete from pos_config where config_no=2
go

delete from pos where pos_no =110

go


print 'delete OK'
go

/* SET IDENTITY_INSERT pos_config ON
GO
*/

INSERT INTO pos_config
           ([config_no]
			,[name]
           )
  VALUES
           (2
			,'Hospitality'
           )

go

/*
SET IDENTITY_INSERT pos_config OFF
GO
 */


 -- Panel Classes
 
 insert into menu_panels values ( 2, 90, 'Common tasks', 'EclipsePos.Apps.Views.LeftMenu.LeftMenuView')
 go
 insert into menu_panels values ( 2, 91, 'Discounts', 'EclipsePos.Apps.Views.LeftMenu.LeftMenuView')
 go
 insert into menu_panels values ( 2, 92, 'Promotions', 'EclipsePos.Apps.Views.LeftMenu.LeftMenuView')
 go
 insert into menu_panels values ( 2, 93, 'Tender', 'EclipsePos.Apps.Views.LeftMenu.LeftMenuView')
 go
 insert into menu_panels values ( 2, 94, 'Manager tasks', 'EclipsePos.Apps.Views.LeftMenu.LeftMenuView')
 go
 insert into menu_panels values ( 2, 95, 'Menus', 'EclipsePos.Apps.Views.LeftMenu.LeftMenuView')
 go
 insert into menu_panels values ( 2, 96, 'Alt Currency', 'EclipsePos.Apps.Views.LeftMenu.LeftMenuView')
 go
 insert into menu_panels values ( 2, 97, 'Exit', 'EclipsePos.Apps.Views.LeftMenu.LeftMenuView')
 go
 insert into menu_panels values ( 2, 98, 'Appertizer Menu', 'EclipsePos.Apps.Views.LeftMenu.LeftMenuView')
 go
 insert into menu_panels values ( 2, 99, 'Sides', 'EclipsePos.Apps.Views.LeftMenu.LeftMenuView')
 go
 insert into menu_panels values ( 2, 100, 'Soups and Salads', 'EclipsePos.Apps.Views.LeftMenu.LeftMenuView')
 go
 insert into menu_panels values ( 2, 101, 'Kinds menu', 'EclipsePos.Apps.Views.LeftMenu.LeftMenuView')
 go
 insert into menu_panels values ( 2, 102, 'Sandwiches', 'EclipsePos.Apps.Views.LeftMenu.LeftMenuView')
 go
 insert into menu_panels values ( 2, 103, 'Burgers', 'EclipsePos.Apps.Views.LeftMenu.LeftMenuView')
 go
 insert into menu_panels values ( 2, 104, 'Entrees', 'EclipsePos.Apps.Views.LeftMenu.LeftMenuView')
 go
 insert into menu_panels values ( 2, 105, 'Pastas', 'EclipsePos.Apps.Views.LeftMenu.LeftMenuView')
 go
 insert into menu_panels values ( 2, 106, 'Pizza', 'EclipsePos.Apps.Views.LeftMenu.LeftMenuView')
 go
 insert into menu_panels values ( 2, 107, 'Desserts', 'EclipsePos.Apps.Views.LeftMenu.LeftMenuView')
 go
 insert into menu_panels values ( 2, 108, 'Beverages', 'EclipsePos.Apps.Views.LeftMenu.LeftMenuView')
 go
 








 insert into menu_panels values ( 2, 991, 'Panel navigator', 'EclipsePos.Apps.Views.BottomMenu.BottomMenuView')
 go
 
 


 
 
--Navigator
insert into pos_key values (2, 991,	'Common Tasks',		1,   90,   112,	3,	20,		8,	48,		118,		90,		192,	90,	'',1, 'EclipsePos.Apps.PosEvents.LeftMenuNavigator',' ', 'F1');
go														  				
insert into pos_key values (2, 991,	'Discounts',		1,   91,   113,	3,	140,	8,  48,		118,		91,		192,	91,	'',1, 'EclipsePos.Apps.PosEvents.LeftMenuNavigator',' ', 'F2');
go
insert into pos_key values (2, 991,	'Promotions',		1,   92,   114,	3,	260,	8,  48,		118,		93,		192,	92,	'',1, 'EclipsePos.Apps.PosEvents.LeftMenuNavigator',' ', 'F3');
go
insert into pos_key values (2, 991,	'Tender',			1,   93,   115,	3,	380,	8,  48,		118,		94,		192,	93,	'',1, 'EclipsePos.Apps.PosEvents.LeftMenuNavigator',' ', 'F4');
go
insert into pos_key values (2, 991,	'Manager',			1,   94,   116,	3,	500,	8,  48,		118,		95,		192,	94,	'',1, 'EclipsePos.Apps.PosEvents.LeftMenuNavigator',' ', 'F5');
go
insert into pos_key values (2, 991,	'Menus',		1,   95,   117,	3,	620,	8,  48,		118,		96,		192,	95,	'',1, 'EclipsePos.Apps.PosEvents.LeftMenuNavigator',' ', 'F7');
go
insert into pos_key values (2, 991,	'Alt Currency',		1,   96,   118,	3,	740,	8,  48,		118,		97,		192,	96,	'',1, 'EclipsePos.Apps.PosEvents.LeftMenuNavigator',' ', 'F8');
go														  				
insert into pos_key values (2, 991,	'Exit',				1,   97,   119,	3,	860,	8,  48,		118,		98,		192,	97,	'',1, 'EclipsePos.Apps.PosEvents.LeftMenuNavigator',' ', 'F9');
go
														  				
														  				
														  				
														  				
														  				
														  				



--Common Tasks
insert into pos_key values (2, 90,	'Ctrl',		1,   3, 1001,		3,	170,		40,			48, 56,	90,	192,	131184,	'',1, 'EclipsePos.Apps.PosEvents.Quantity','Quantity','F1');
go
insert into pos_key values (2, 90,	'Ctrl',		1,   0, 1002,		3,  170,		89,			48, 56,	91,	192,	131185,	'',1,'EclipsePos.Apps.PosEvents.Plu','PLU', 'F2');
go
insert into pos_key values (2, 90,	'Ctrl',		1,   0, 1003,		3,	170,		138,		48, 56,	92,	192,	131186,	'',1, 'EclipsePos.Apps.PosEvents.Subtotal','Subtotal','F3');
go
insert into pos_key values (2, 90,	'Ctrl',		1,   1, 1004,		3,	170,		187,		48, 56,	93,	192,	131187,	'',1, 'EclipsePos.Apps.PosEvents.Total','Total','F4');
go
insert into pos_key values (2, 90,	'Ctrl',		1,   0, 1005,		3,	170,		236,		48, 56, 94,	192,	131189,	'',1, 'EclipsePos.Apps.PosEvents.ItemVoid','Void','F5');
go
insert into pos_key values (2, 90,	'Ctrl',		1,   0, 1006,		3, 170,			285,		48, 56, 95,	192,	131190,	'',1, 'EclipsePos.Apps.PosEvents.VoidSale','Void Sale','F6');
go
insert into pos_key values (2, 90,	'Ctrl',		1,   2, 1007,		3,  170,		334,		48, 56, 96,	0,		131191,	'',1, 'EclipsePos.Apps.PosEvents.SaveEj', 'Store','F7');
go
insert into pos_key values (2, 90,	'Ctrl',		1,   0, 1008,		3,  170,		383,		48, 56, 97,	0,		131192,	'',1,'EclipsePos.Apps.PosEvents.RecallEj', 'Recall','F8');
go
insert into pos_key values (2, 90,	'Ctrl',		1,   0, 1009,		3, 170,			432,		48, 56, 98,	192,	131193,	'',1, 'EclipsePos.Apps.PosEvents.ReturnSale','Return Sale','F9');
go   													  		  


--Discounts 
insert into pos_key values (2, 91,		'Ctrl',		1,   1,	1010,		3,  170,	40,			48, 56,	90,	192,	131184,	'',1, 'EclipsePos.Apps.PosEvents.ItemMarkdown','Item Disc. 10%','F1');
go
insert into pos_key values (2, 91,		'Ctrl',		1,   2,	1011,		3,  170,	89,			48, 56,	91,	192,	131185,	'',1, 'EclipsePos.Apps.PosEvents.ItemMarkdown','Item Disc. 20%','F1');
go
insert into pos_key values (2, 91,		'Ctrl',		1,   3,	1012,		3,  170,	138,		48, 56,	92,	192,	131186,	'',1, 'EclipsePos.Apps.PosEvents.ItemMarkdown','Item Disc. 30%','F1');
go
insert into pos_key values (2, 91,		'Ctrl',		1,   4,	1013,		3,  170,	187,		48, 56,	93,	192,	131187,	'',1, 'EclipsePos.Apps.PosEvents.ItemMarkdown','Item Disc. 40%','F1');
go
insert into pos_key values (2, 91,		'Ctrl',		1,   5,	1014,		3,  170,	236,		48, 56,	94,	192,	131188,	'',1, 'EclipsePos.Apps.PosEvents.ItemMarkdown','Item Disc. 50%','F1');
go


--Promotions
insert into pos_key values (2, 92,		'Ctrl',		1,   101,	1015,		3,	170,	40,			48, 56, 90,	192,	131184,	'',1, 'EclipsePos.Apps.PosEvents.Discount', 'Buy 2,20% Off 3rd','F2');
go
insert into pos_key values (2, 92,		'Ctrl',		1,   201,	1016,		3,	170,	89,			48, 56, 91,	192,	131185,	'',1, 'EclipsePos.Apps.PosEvents.Discount', 'Three For $10','F2');
go



--Tender
insert into pos_key values (2, 93,		'Ctrl' ,	1,  -1,  1017,		3, 170,			40,		48, 56,	90,	192,	131184,	'',1, 'EclipsePos.Apps.PosEvents.CashTender','Cash ','F1');
go
insert into pos_key values (2, 93,		'Ctrl',		1,   0,  1018,		3, 170,			89,		48, 56, 91,	192,	131185,	'',1, 'EclipsePos.Apps.PosEvents.CheckTender','Check ','F2');
go
insert into pos_key values (2, 93,		'Ctrl',		1,   0,  1019,		3, 170,			138,	48, 56,	92,	192,	131186,	'',1, 'EclipsePos.Apps.PosEvents.CreditTender','Credit Card ','F3');
go
				 							 		  			


--Manager
insert into pos_key values (2, 94,	'Ctrl',		1,   0,  1020,		3,  170,		40,		48, 56,		90,	100,	131184,		'',1,'EclipsePos.Apps.PosEvents.PaidIn', 'Paid In','F1');
go
insert into pos_key values (2, 94,	'Ctrl',		1,   0,  1021,		3,  170,		89,		48, 56,		91,	100,	131185,		'',1,'EclipsePos.Apps.PosEvents.PaidOut', 'Paid Out','F2');
go
insert into pos_key values (2, 94,	'Ctrl',		1,   0,	 1022,		3, 170,			138,	48, 56,		92,	50,		131186,		'',1, 'EclipsePos.Apps.PosEvents.TrainingMode', 'Training Mode','F3');
go     				  		  		
insert into pos_key values (2, 94,	'Ctrl',		1,   1,	 1023,		3,	170,		187,	48,  56,	93,	25,		131187,		'',	1,	'EclipsePos.Apps.PosEvents.TerminalReport', 'X-Report','F4');
go
insert into pos_key values (2, 94,	'Ctrl',		1,   2,	 1024,		3,	170,		236,	48,  56,    94,	0,		131188,		'',	1,	'EclipsePos.Apps.PosEvents.TerminalReport', 'Z-Report','F5');
go
insert into pos_key values (2, 94,	'Ctrl',		1,   0,	 1025,		3,	170,		285,	48,  56,    95,	0,		131189,		'',	1,	'EclipsePos.Apps.PosEvents.PriceOverride', 'Change Price','F6');
go
insert into pos_key values (2, 94,	'Ctrl',		1,   0,	 1026,		3,	170,		334,	48,  56,    96,	0,		131190,		'',	1,	'EclipsePos.Apps.PosEvents.SystemManager', 'System Manager','F7');
go

--insert into pos_key values (0, 106,	'Ctrl',		1,   4, 4,		3,  170,		236,	48, 56, 0,	25,		-1,		'NNNNNNNN',1,'EclipsePos.Apps.PosEvents.PickUp', 'Pickup','F5');
--go



--Exit
insert into pos_key values (2, 97,		'Ctrl',		1,   0,	27,		3, 170,			89,			48, 56,0,	192,	131184,	'',1, 'EclipsePos.Apps.PosEvents.Lock','Lock','F1');
go
insert into pos_key values (2, 97,		'Ctrl',		1,   2,	 1027,		3,  170,		40,		48, 56,90,0, 131185,'',1, 'EclipsePos.Apps.PosEvents.LogOff', 'Log Off','F2');
go
insert into pos_key values (2, 97,		'Ctrl',		1,  -1,	 1028,		3,  170,		89,		48, 56,91,50, 131186,'',0, 'EclipsePos.Apps.PosEvents.Exit', 'Shutdown','F3');
go




--Menus
insert into pos_key values (2, 95,	'Ctrl',		1,   98,		1050,		3, 170,			40,		48, 56,90,	192,	131184,	'',1, 'EclipsePos.Apps.PosEvents.LeftMenuNavigator','Appertizers','F1');
go
insert into pos_key values (2, 95,	'Ctrl',		1,   99,		1051,		3, 170,			89,		48, 56,91,	192,	131185,	'',1, 'EclipsePos.Apps.PosEvents.LeftMenuNavigator','Sides','F2');
go
insert into pos_key values (2, 95,	'Ctrl',		1,   100,		1052,		3, 170,			138,	48, 56,92,	192,	131186,	'',1, 'EclipsePos.Apps.PosEvents.LeftMenuNavigator','Soup and salads','F3');
go 
insert into pos_key values (2, 95,	'Ctrl',		1,   1,		1053,		3, 170,			40,		48, 56,90,	192,	131187,	'',1, 'EclipsePos.Apps.PosEvents.LeftMenuNavigator','Kids menu','F4');
go
insert into pos_key values (2, 95,	'Ctrl',		1,   2,		1054,		3, 170,			89,		48, 56,91,	192,	131188,	'',1, 'EclipsePos.Apps.PosEvents.LeftMenuNavigator','Sandwiches','F5');
go
insert into pos_key values (2, 95,	'Ctrl',		1,   3,		1055,		3, 170,			138,	48, 56,92,	192,	131189,	'',1, 'EclipsePos.Apps.PosEvents.LeftMenuNavigator','Pstas','F6');
go   													  		  
insert into pos_key values (2, 95,	'Ctrl',		1,   2,		1056,		3, 170,			89,		48, 56,91,	192,	131190,	'',1, 'EclipsePos.Apps.PosEvents.LeftMenuNavigator','Pizza','F7');
go
insert into pos_key values (2, 95,	'Ctrl',		1,   3,		1057,		3, 170,			138,	48, 56,92,	192,	131191,	'',1, 'EclipsePos.Apps.PosEvents.LeftMenuNavigator','Desserts','F8');
go   													  		  
insert into pos_key values (2, 95,	'Ctrl',		1,   3,		1058,		3, 170,			138,	48, 56,92,	192,	131192,	'',1, 'EclipsePos.Apps.PosEvents.LeftMenuNavigator','Beberages','F9');
go   													  		  
   													  		  


--Help
		  			
--Alternate currency entry
insert into pos_key values (2, 96,	'Ctrl' ,		1,   1,		1032,	3,	 170,	40,   48,  56, 90,	0, 131184,'',1,'EclipsePos.Apps.PosEvents.AltCurrTender', 'US Dollar','F1');
go
insert into pos_key values (2, 96,	'Ctrl',			1,   2,		1033,	3,	170,	89,   48,  56, 91,	0, 131185,'',1,'EclipsePos.Apps.PosEvents.AltCurrTender', 'Euro','F2');
go
insert into pos_key values (2, 96,	'Ctrl',			1,   3,		1034,	3,	170,	138,  48,  56, 92,	0, 131186,'',1,'EclipsePos.Apps.PosEvents.AltCurrTender', 'Sterling Pound','F3');
go
insert into pos_key values (2, 96,	'Ctrl',			1,   4,		1035,	3,	170,	187,  48,  56, 93,	0, 131187,'',1,'EclipsePos.Apps.PosEvents.AltCurrTender', 'Aust. Dollar','F4');
go
insert into pos_key values (2, 96,	'Ctrl',			1,   5,		1036,	3,	170,	236,  48,  56, 94,	25, 131188,'',1,'EclipsePos.Apps.PosEvents.AltCurrTender', 'HK Dollar','F5');
go
insert into pos_key values (2, 96,	'Ctrl',			1,   6,		1037,	3,	170,	285,  48,  56, 95,	25, 131189,'',1,'EclipsePos.Apps.PosEvents.AltCurrTender', 'Yen','F6');
go   													  				



/* Appertizers */

insert into pos_key values (2, 98,	'Ctrl',		1,   11000001,		1070,		3, 170,			40,		48, 56,90,	192,	131184,	'/Pictures/Food/BuffaloWings3.bmp',1, 'EclipsePos.Apps.PosEvents.Plu','Buffalo wings','F1');
go
insert into pos_key values (2, 98,	'Ctrl',		1,   11000002,		1071,		3, 170,			89,		48, 56,91,	192,	131185,	'',1, 'EclipsePos.Apps.PosEvents.Plu','Oninon Rings','F2');
go
insert into pos_key values (2, 98,	'Ctrl',		1,   11000003,		1072,		3, 170,			138,	48, 56,92,	192,	131186,	'',1, 'EclipsePos.Apps.PosEvents.Plu','Nachos','F3');
go 
insert into pos_key values (2, 98,	'Ctrl',		1,   11000004,		1073,		3, 170,			40,		48, 56,90,	192,	131187,	'',1, 'EclipsePos.Apps.PosEvents.Plu','Potato skins','F4');
go
insert into pos_key values (2, 98,	'Ctrl',		1,   11000005,		1074,		3, 170,			89,		48, 56,91,	192,	131188,	'',1, 'EclipsePos.Apps.PosEvents.Plu','Shrimp cocktail','F5');
go
insert into pos_key values (2, 98,	'Ctrl',		1,   11000006,		1075,		3, 170,			138,	48, 56,92,	192,	131189,	'',1, 'EclipsePos.Apps.PosEvents.Plu','Quesadilla','F6');
go   													  		  
insert into pos_key values (2, 98,	'Ctrl',		1,   11000007,		1076,		3, 170,			89,		48, 56,91,	192,	131190,	'',1, 'EclipsePos.Apps.PosEvents.Plu','Chicken Tenders','F7');
go
insert into pos_key values (2, 98,	'Ctrl',		1,   11000008,		1077,		3, 170,			138,	48, 56,92,	192,	131191,	'',1, 'EclipsePos.Apps.PosEvents.Plu','Lemon pep Shrimp','F8');
go   													  		  
insert into pos_key values (2, 98,	'Ctrl',		1,   11000009,		1078,		3, 170,			138,	48, 56,92,	192,	131192,	'',1, 'EclipsePos.Apps.PosEvents.Plu','Stuff Jalapeno','F9');
go   													  		  


/* Sides */

insert into pos_key values (2, 99,	'Ctrl',		1,   11000010,		1079,		3, 170,			40,		48, 56,90,	192,	131184,	'',1, 'EclipsePos.Apps.PosEvents.Plu','Baked Potato','F1');
go
insert into pos_key values (2, 99,	'Ctrl',		1,   11000011,		1080,		3, 170,			89,		48, 56,91,	192,	131185,	'',1, 'EclipsePos.Apps.PosEvents.Plu','Cole Staw','F2');
go
insert into pos_key values (2, 99,	'Ctrl',		1,   11000012,		1081,		3, 170,			138,	48, 56,92,	192,	131186,	'',1, 'EclipsePos.Apps.PosEvents.Plu','Steamed Vegi.','F3');
go 
insert into pos_key values (2, 99,	'Ctrl',		1,   11000013,		1082,		3, 170,			40,		48, 56,90,	192,	131187,	'',1, 'EclipsePos.Apps.PosEvents.Plu','Side Salad','F4');
go
insert into pos_key values (2, 99,	'Ctrl',		1,   11000014,		1083,		3, 170,			89,		48, 56,91,	192,	131188,	'',1, 'EclipsePos.Apps.PosEvents.Plu','French Fries','F5');
go
insert into pos_key values (2, 99,	'Ctrl',		1,   11000015,		1084,		3, 170,			138,	48, 56,92,	192,	131189,	'',1, 'EclipsePos.Apps.PosEvents.Plu','Special Beans','F6');
go   													  		  
insert into pos_key values (2, 99,	'Ctrl',		1,   11000016,		1085,		3, 170,			89,		48, 56,91,	192,	131190,	'',1, 'EclipsePos.Apps.PosEvents.Plu','Marshed Potato','F7');
go
insert into pos_key values (2, 99,	'Ctrl',		1,   11000017,		1086,		3, 170,			138,	48, 56,92,	192,	131191,	'',1, 'EclipsePos.Apps.PosEvents.Plu','Gourment Muffins','F8');
go   													  		  


/* Soups and Salads */

insert into pos_key values (2, 100,	'Ctrl',		1,   11000018,		1087,		3, 170,			40,		48, 56,90,	192,	131184,	'',1, 'EclipsePos.Apps.PosEvents.Plu','Frech Onion clam chowder','F1');
go
insert into pos_key values (2, 100,	'Ctrl',		1,   11000019,		1088,		3, 170,			89,		48, 56,91,	192,	131185,	'',1, 'EclipsePos.Apps.PosEvents.Plu','Vegitarian Deluxe','F2');
go
insert into pos_key values (2, 100,	'Ctrl',		1,   11000020,		1089,		3, 170,			138,	48, 56,92,	192,	131186,	'',1, 'EclipsePos.Apps.PosEvents.Plu','Garden Salad','F3');
go 
insert into pos_key values (2, 100,	'Ctrl',		1,   11000021,		1090,		3, 170,			40,		48, 56,90,	192,	131187,	'',1, 'EclipsePos.Apps.PosEvents.Plu','Chx Suppreme Salad','F4');
go
insert into pos_key values (2, 100,	'Ctrl',		1,   11000022,		1091,		3, 170,			89,		48, 56,91,	192,	131188,	'',1, 'EclipsePos.Apps.PosEvents.Plu','Todays Soup','F5');
go
insert into pos_key values (2, 100,	'Ctrl',		1,   11000023,		1092,		3, 170,			138,	48, 56,92,	192,	131189,	'',1, 'EclipsePos.Apps.PosEvents.Plu','Potato Salads','F6');
go   													  		  



/* Kids Menu */

insert into pos_key values (2, 101,	'Ctrl',		1,   11000024,		1093,		3, 170,			40,		48, 56,90,	192,	131184,	'',1, 'EclipsePos.Apps.PosEvents.Plu','Kids Burger','F1');
go
insert into pos_key values (2, 101,	'Ctrl',		1,   11000025,		1094,		3, 170,			89,		48, 56,91,	192,	131185,	'',1, 'EclipsePos.Apps.PosEvents.Plu','Grilled Chees','F2');
go
insert into pos_key values (2, 101,	'Ctrl',		1,   11000026,		1095,		3, 170,			138,	48, 56,92,	192,	131186,	'',1, 'EclipsePos.Apps.PosEvents.Plu','Hot Dog','F3');
go 
insert into pos_key values (2, 101,	'Ctrl',		1,   11000027,		1096,		3, 170,			40,		48, 56,90,	192,	131187,	'',1, 'EclipsePos.Apps.PosEvents.Plu','Cheken finger','F4');
go


/* Sandwiches */


insert into pos_key values (2, 102,	'Ctrl',		1,   11000028,		1097,		3, 170,			40,		48, 56,90,	192,	131184,	'/Pictures/Food/BuffaloWings3.bmp',1, 'EclipsePos.Apps.PosEvents.Plu','Sandwiches1','F1');
go
insert into pos_key values (2, 102,	'Ctrl',		1,   11000029,		1098,		3, 170,			89,		48, 56,91,	192,	131185,	'',1, 'EclipsePos.Apps.PosEvents.Plu','Sandwiches12','F2');
go
insert into pos_key values (2, 102,	'Ctrl',		1,   11000030,		1099,		3, 170,			138,	48, 56,92,	192,	131186,	'',1, 'EclipsePos.Apps.PosEvents.Plu','Sandwiches13','F3');
go 
insert into pos_key values (2, 102,	'Ctrl',		1,   11000031,		1100,		3, 170,			40,		48, 56,90,	192,	131187,	'',1, 'EclipsePos.Apps.PosEvents.Plu','Sandwiches14','F4');
go

insert into pos_key values (2, 102,	'Ctrl',		1,   11000032,		1101,		3, 170,			89,		48, 56,91,	192,	131188,	'',1, 'EclipsePos.Apps.PosEvents.Plu','Sandwiches15','F5');
go
insert into pos_key values (2, 102,	'Ctrl',		1,   11000033,		1102,		3, 170,			138,	48, 56,92,	192,	131189,	'',1, 'EclipsePos.Apps.PosEvents.Plu','Sandwiches16','F6');
go   													  		  
insert into pos_key values (2, 102,	'Ctrl',		1,   11000034,		1103,		3, 170,			89,		48, 56,91,	192,	131190,	'',1, 'EclipsePos.Apps.PosEvents.Plu','Sandwiches17','F7');
go
 													  		  





--Pos profile

--insert into pos_profile values (0, 0, 'Manager') 
--go
--insert into pos_profile values (0, 0, 'Cashier') 
--go
--insert into pos_profile values (0, 0, 'System Administrator') 
--go



--insert into tax_group values (1, 10) 
--go
-- insert into tax values (0, 1, 1, 'GST', 0.05, 0.05) 
--go
--insert into tax values (0, 2, 1, 'GST', 0.050, 0.050) 
--go


insert into pos_param values (  2, 3, 0, 0, 'CustWelcome', 'Welcome') 
go
insert into pos_param values (   2, 3, 0, 0, 'ReceiptLine1', 'Thank you for shopping') 
go
insert into pos_param values (  2, 3, 0, 0, 'OperTitle', 'Operator Display') 
go
insert into pos_param values (  2, 3, 0, 0, 'Total', 'TOTAL') 
go
insert into pos_param values ( 2, 3, 0, 0, 'TotalTax', 'Total Tax') 
go
insert into pos_param values ( 2, 3, 0, 0, 'SubTotal', 'SUBTOTAL') 
go
insert into pos_param values ( 2, 3, 0, 0, 'CashTender', 'Cash Tender') 
go
insert into pos_param values ( 2, 3, 0, 0, 'CheckTender', 'Check Tender') 
go
insert into pos_param values ( 2, 3, 0, 0, 'CreditCard', 'Credit Card Tender') 
go
insert into pos_param values ( 2, 3, 0, 0, 'Discount', 'Discount') 
go
insert into pos_param values ( 2, 3, 0, 0, 'Markout', 'Markout') 
go
insert into pos_param values ( 2, 3, 0, 0, 'Change', 'Change Due') 
go
insert into pos_param values ( 2, 3, 0, 0, 'CashBack', 'Cash Back') 
go
insert into pos_param values ( 2, 3, 0, 0, 'CloseDrawer', 'Close Cash Drawer') 
go
insert into pos_param values ( 2, 3, 0, 0, 'InsertCheck', 'Insert check') 
go
insert into pos_param values ( 2, 3, 0, 0, 'InsertValidation', 'Insert Validation') 
go
insert into pos_param values ( 2, 3, 0, 0, 'InsertCCValidation', 'Insert credit card receipt') 
go
insert into pos_param values ( 2, 3, 0, 0, 'BadName', 'Bad user ID, press clear') 
go
insert into pos_param values ( 2, 3, 0, 0, 'BadPass', 'Invalid password, press clear') 
go
insert into pos_param values ( 2, 3, 0, 0, 'InvalidCustomer', 'Invalid customer number, press clear') 
go
insert into pos_param values ( 2, 3, 0, 0, 'TooMany', 'Too many logon attempts, press clear-') 
go
insert into pos_param values ( 2, 3, 0, 0, 'GoodLogin', 'Logon successful') 
go
insert into pos_param values ( 2, 3, 0, 0, 'OkText', 'OK') 
go
insert into pos_param values ( 2, 3, 0, 0, 'CancelText', 'Cancel') 
go
insert into pos_param values ( 2, 3, 0, 0, 'ClearText', 'Clear') 
go
insert into pos_param values ( 2, 3, 0, 0, 'InvalidInput', 'Invalid Input, press clear') 
go
insert into pos_param values ( 2, 3, 0, 0, 'PromptOpenAmount', 'Enter open amount: ') 
go
insert into pos_param values ( 2, 3, 0, 0, 'PromptAmount', 'Enter amount: ') 
go
insert into pos_param values ( 2, 3, 0, 0, 'PromptCashBack', 'Cash back amount:') 
go
insert into pos_param values ( 2, 3, 0, 0, 'ConfirmOpenAmount', 'Confirm (enter/clear)') 
go
insert into pos_param values ( 2, 3, 0, 0, 'RegOpen', 'Register Open') 
go
insert into pos_param values ( 2, 3, 0, 0, 'ReturnSale', 'Return Sale') 
go
insert into pos_param values ( 2, 3, 0, 0, 'TotalRequired', 'Total Required, press clear') 
go
insert into pos_param values ( 2, 3, 0, 0, 'InsufficientFunds', 'Insufficient Funds, press clear') 
go
insert into pos_param values ( 2, 3, 0, 0, 'BalanceDue', 'Balance Due') 
go
insert into pos_param values ( 2, 3, 0, 0, 'MgrIntervention', 'Manager intervention required') 
go
insert into pos_param values ( 2, 3, 0, 0, 'EnterUser', 'Enter User ID: ') 
go
insert into pos_param values ( 2, 3, 0, 0, 'EnterPass', 'Enter Password: ') 
go
insert into pos_param values ( 2, 3, 0, 0, 'LoginTab', 'Login') 
go
insert into pos_param values ( 2, 3, 0, 0, 'PromptDrawerNo', 'Enter drawer number: ') 
go
insert into pos_param values ( 2, 3, 0, 0, 'ConfirmDrawerNo', 'Confirm (enter/clear)') 
go
insert into pos_param values ( 2, 3, 0, 0, 'BadDrawerNo', 'Invalid drawer number') 
go
insert into pos_param values ( 2, 3, 0, 0, 'BadCheckNo', 'Invalid check number') 
go
insert into pos_param values ( 2, 3, 0, 0, 'BadCCNo', 'Invalid credit card') 
go
insert into pos_param values ( 2, 3, 0, 0, 'BadExpr', 'Bad expiration date') 
go
insert into pos_param values ( 2, 3, 0, 0, 'PromptCustomer', 'Enter Customer Number: ') 
go
insert into pos_param values ( 2, 3, 0, 0, 'VoidSale', 'Sale Voided, press enter') 
go
insert into pos_param values ( 2, 3, 0, 0, 'ConvertedAltCurrency', 'Converted total') 
go
insert into pos_param values ( 2, 3, 0, 0, 'AltCurrTenderPrompt', 'Enter alternate currency amount: ') 
go
insert into pos_param values ( 2, 3, 0, 0, 'AltCurrencyDescription', 'Alternate Currency Tender') 
go
insert into pos_param values ( 2, 3, 0, 0, 'TenderTotal', 'Amount Tendered') 
go
insert into pos_param values ( 2, 3, 0, 0, 'TerminalLocked', 'Terminal locked, press enter') 
go
insert into pos_param values ( 2, 3, 0, 0, 'EnterItem', 'Enter item') 
go
insert into pos_param values ( 2, 3, 0, 0, 'EnterWeight', 'Enter weight') 
go
insert into pos_param values ( 2, 3, 0, 0, 'Pause', 'Press enter to continue...') 
go
insert into pos_param values ( 2, 3, 0, 0, 'CloseCash', 'Close cash drawer.') 
go
insert into pos_param values ( 2, 3, 0, 0, 'RecallFailed', 'Transaction not found') 
go
insert into pos_param values ( 2, 3, 0, 0, 'CashLimitExceeded', 'Cash in drawer limit exceeded') 
go
insert into pos_param values ( 2, 3, 0, 0, 'EnterNewPrice', 'Enter new price:') 
go
insert into pos_param values ( 2, 3, 0, 0, 'PosPrinterFailed', 'PRINTER FAILURE') 
go
--insert into pos_param values ( 0, 3, 0, 0, 'PosPrinterError', 'PRINTER ERROR') 
--go
insert into pos_param values ( 2, 3, 0, 0, 'ReceiptTopMOD1', 'Biz Reg. No. 2567892555 W') 
go
insert into pos_param values ( 2, 3, 0, 0, 'ReceiptTopMOD2', 'GST Reg. No. ME-845234-7') 
go
insert into pos_param values ( 2, 3, 0, 0, 'ReceiptTopMOD3', '*** Enjoy 5% cash rebates ***') 
go
insert into pos_param values ( 2, 3, 0, 0, 'ReceiptTopMOD4', 'When you use POSB Everyday credit card') 
go
insert into pos_param values ( 2, 3, 0, 0, 'ReceiptBottomMOD', 'Thank you for shopping') 
go
insert into pos_param values ( 2, 3, 0, 0, 'ReceiptTrxTag', 'TAX') 
go
insert into pos_param values ( 2, 3, 0, 0, 'ReceiptPosTag', 'REG') 
go
insert into pos_param values ( 2, 3, 0, 0, 'ReceiptEmpTag', 'EMP') 
go
insert into pos_param values ( 2, 3, 0, 0, 'SavedReceipt', 'Sale Saved') 
go
insert into pos_param values ( 2, 3, 0, 0, 'TrxNo', 'TRX: ') 
go
insert into pos_param values ( 2, 3, 0, 0, 'PosNo', 'POS: ') 
go
insert into pos_param values ( 2, 3, 0, 0, 'PosPrinterError', 'Printer Error') 
go
insert into pos_param values ( 2, 3, 0, 0, 'CashDrawerError', 'Cash Drawer Error') 
go
insert into pos_param values ( 2, 3, 0, 0, 'PosLineDisplayError', 'Line Display Error') 
go
insert into pos_param values ( 2, 3, 0, 0, 'ShutdownKeyNotAllowed', 'Shutdown Key Not Allowed') 
go
insert into pos_param values ( 2, 4, 0, 0, 'SpeedDrawer', 'false') 
go
insert into pos_param values ( 2, 3, 0, 0, 'ReceiptClass', 'com.globalretailtech.pos.devices.Receipt') 
go
insert into pos_param values ( 2, 3, 0, 0, 'OperPromptClass', 'com.globalretailtech.pos.devices.OperPrompt') 
go
insert into pos_param values ( 2, 3, 0, 0, 'InitDialog', 'Open') 
go
insert into pos_param values ( 2, 4, 0, 0, 'PromptForReceipt', 'false') 
go
insert into pos_param values ( 2, 3, 0, 0, 'MathClass', 'com.globalretailtech.pos.operators.SimpleMath') 
go
insert into pos_param values ( 2, 3, 0, 0, 'FieldsClass', 'com.globalretailtech.pos.operators.SimpleFields') 
go
insert into pos_param values ( 2, 4, 0, 0, 'ReceiptPrintAddr1', 'true') 
go
insert into pos_param values ( 2, 4, 0, 0, 'ReceiptPrintAddr2', 'true') 
go
insert into pos_param values ( 2, 4, 0, 0, 'ReceiptPrintAddr3', 'true') 
go
insert into pos_param values ( 2, 4, 0, 0, 'ReceiptPrintAddr4', 'true') 
go
insert into pos_param values ( 2, 4, 0, 0, 'ReceiptPrintAddr5', 'true') 
go
insert into pos_param values ( 2, 4, 0, 0, 'ReceiptPrintTel', 'true') 
go

insert into pos_param values ( 2, 4, 0, 0, 'NavigateButtons', 'true') 
go
insert into pos_param values ( 2, 3, 0, 0, 'OperReceiptFont', 'Lucida Sans Typewriter Regular') 
go
insert into pos_param values ( 2, 3, 0, 0, 'HeaderFont', 'Courier') 
go
insert into pos_param values ( 2, 3, 0, 0, 'HeaderTitleFont', 'Helvetica') 
go
insert into pos_param values ( 2, 1, 0, 0, 'OperReceiptFontSize', '15') 
go
insert into pos_param values ( 2, 1, 0, 0, 'HeaderFontSize', '12') 
go
insert into pos_param values ( 2, 1, 0, 0, 'HeaderTitleFontSize', '14') 
go
insert into pos_param values ( 2, 1, 0, 0, 'RowHeight', '30') 
go
insert into pos_param values ( 2, 1, 0, 0, 'ItemWidth', '168') 
go
insert into pos_param values ( 2, 1, 0, 0, 'QtyWidth', '73') 
go
insert into pos_param values ( 2, 1, 0, 0, 'DescWidth', '280') 
go
insert into pos_param values ( 2, 1, 0, 0, 'ValueWidth', '120')
go
insert into pos_param values ( 2, 1, 0, 0, 'PriceWidth', '95') 
go
insert into pos_param values ( 2, 1, 0, 0, 'TableRows', '200') 
go
insert into pos_param values ( 2, 1, 0, 0, 'TrxWidth', '10') 
go
insert into pos_param values ( 2, 1, 0, 0, 'PosWidth', '4') 
go
insert into pos_param values ( 2, 1, 0, 0, 'EmpWidth', '4') 
go
insert into pos_param values ( 2, 1, 0, 0, 'DateWidth', '14') 
go



insert into pos_param values ( 2, 3, 0, 0, 'MarkdownLiteral1', 'Take ') 
go
insert into pos_param values ( 2, 3, 0, 0, 'MarkdownLiteral2', '% Off') 
go


insert into pos_param values ( 2, 3, 0, 0, 'NonTaxCount', 'Non-Tax transactions') 
go
insert into pos_param values ( 2, 3, 0, 0, 'NonTaxAmount', 'Non-Tax amount') 
go
insert into pos_param values ( 2, 3, 0, 0, 'TaxCount', 'Tax transactions ') 
go
insert into pos_param values ( 2, 3, 0, 0, 'TaxAmount', 'Tax amount ') 
go
insert into pos_param values ( 2, 3, 0, 0, 'VoidCount', 'Void transactions') 
go
insert into pos_param values ( 2, 3, 0, 0, 'VoidAmount', 'Void amount') 
go
insert into pos_param values ( 2, 3, 0, 0, 'ReturnCount', 'Return transactions') 
go
insert into pos_param values ( 2, 3, 0, 0, 'ReturnAmount', 'Return amount') 
go
insert into pos_param values ( 2, 3, 0, 0, 'CouponCount', 'Coupon transactions') 
go
insert into pos_param values ( 2, 3, 0, 0, 'CouponAmount', 'Coupon amount') 
go
insert into pos_param values ( 2, 3, 0, 0, 'CreditCount', 'Credit transactions') 
go
insert into pos_param values ( 2, 3, 0, 0, 'CreditAmount', 'Credit amount') 
go
insert into pos_param values ( 2, 3, 0, 0, 'CheckCount', 'Check transactions') 
go
insert into pos_param values ( 2, 3, 0, 0, 'CheckAmount', 'Check amount') 
go
insert into pos_param values ( 2, 3, 0, 0, 'RecdOnAcctCount', 'Received on account transactions') 
go
insert into pos_param values ( 2, 3, 0, 0, 'RecdOnAcctAmount', 'Received on account amount') 
go
insert into pos_param values ( 2, 3, 0, 0, 'PaidInCount', 'Paid in transactions') 
go
insert into pos_param values ( 2, 3, 0, 0, 'PaidInAmount', 'Paid in Amount') 
go
insert into pos_param values ( 2, 3, 0, 0, 'PaidOutCount', 'Paid out transactions') 
go
insert into pos_param values ( 2, 3, 0, 0, 'PaidOutAmount', 'Paid out Amount') 
go
insert into pos_param values ( 2, 3, 0, 0, 'CashInDrCount', 'Cash transactions') 
go
insert into pos_param values ( 2, 3, 0, 0, 'CashInDrAmount', 'Cash in Drawer Amount') 
go
insert into pos_param values ( 2, 3, 0, 0, 'LoanCount', 'Loan transactions') 
go
insert into pos_param values ( 2, 3, 0, 0, 'LoanAmount', 'Loans amount') 
go
insert into pos_param values ( 2, 3, 0, 0, 'PickupCount', 'Pickup transactions') 
go
insert into pos_param values ( 2, 3, 0, 0, 'PickupAmount', 'Pickup amount') 
go
--insert into pos_param values ( 0, 3, 0, 0, '', ' transactions') 
--go
--insert into pos_param values ( 0, 3, 0, 0, '', ' amount') 
go
insert into pos_param values ( 2, 2, 0, 0, 'CashPickup', '10000.0') 
go
insert into pos_param values ( 2, 1, 0, 0, 'NumCashDrawers', '2') 
go
insert into pos_param values ( 2, 3, 0, 0, 'DailyXHeader', 'X-Daily Report') 
go
insert into pos_param values ( 2, 3, 0, 0, 'DailyZHeader', 'Z-Daily Report') 
go
insert into pos_param values ( 2, 3, 0, 0, 'WeeklyXHeader', 'X-Weekly Report') 
go 
insert into pos_param values ( 2, 3, 0, 0, 'WeeklyZHeader', 'Z-Weekly Report') 
go
insert into pos_param values ( 2, 3, 0, 0, 'MonthlyXHeader', 'X-Monthly Report') 
go
insert into pos_param values ( 2, 3, 0, 0, 'MonthlyZHeader', 'Z-Monthly Report') 
go


insert into pos_param values ( 2, 3, 0, 0, 'PromptPosNo', 'Enter POS Number: ') 
go
insert into pos_param values ( 2, 3, 0, 0, 'PromptTransNo', 'Enter Transaction Number:') 
go
insert into pos_param values ( 2, 3, 0, 0, 'NoSaleCount', 'No sale transactions') 
go
insert into pos_param values ( 2, 3, 0, 0, 'TransNo', 'TRANS#') 
go
insert into pos_param values ( 2, 3, 0, 0, 'TransType', 'TRANS TYPE') 
go
insert into pos_param values ( 2, 3, 0, 0, 'OperLogon', 'Operator logon') 
go
insert into pos_param values ( 2, 3, 0, 0, 'OperLogoff', 'Operator logoff') 
go
insert into pos_param values ( 2, 3, 0, 0, 'BankTrans', 'Bank transaction') 
go
insert into pos_param values ( 2, 3, 0, 0, 'PromptCheckNo', 'Enter check number:') 
go
insert into pos_param values ( 2, 3, 0, 0, 'PromptCCNo', 'Enter credit card number:') 
go
insert into pos_param values ( 2, 3, 0, 0, 'PromptCCExpr', 'Enter expiration data:') 
go
insert into pos_param values ( 2, 3, 0, 0, 'Confirm', 'Press enter') 
go
insert into pos_param values ( 2, 3, 0, 0, 'GroupDiscount', '10% off third item') 
go

insert into pos_param values ( 2, 3, 0, 0, 'SiteName', 'Eclipse Retailers, Inc.') 
go
insert into pos_param values ( 2, 3, 0, 0, 'SiteAddr1', '9602 Provost Road') 
go
insert into pos_param values ( 2, 3, 0, 0, 'SiteAddr2', 'Silverdale') 
go
insert into pos_param values ( 2, 3, 0, 0, 'SiteAddr3', 'Singapore') 
go
insert into pos_param values ( 2, 3, 0, 0, 'SiteAddr4', '111113') 
go
insert into pos_param values ( 2, 3, 0, 0, 'SiteAddr5', '') 
go
insert into pos_param values ( 2, 3, 0, 0, 'SiteAddr6', '') 
go
insert into pos_param values ( 2, 3, 0, 0, 'SitePhone', '(555) 555-1234') 
go
insert into pos_param values ( 2, 3, 0, 0, 'SiteFax', '(555) 555-4321') 
go
insert into pos_param values ( 2, 3, 0, 0, 'TrxTag', 'Transaction') 
go
insert into pos_param values ( 2, 3, 0, 0, 'PosTag', 'Register') 
go
insert into pos_param values ( 2, 3, 0, 0, 'EmpTag', 'Employee') 
go
insert into pos_param values ( 2, 3, 0, 0, 'DateTag', 'Time/Date') 
go
insert into pos_param values ( 2, 3, 0, 0, 'TimeTag', 'Time ') 
go
insert into pos_param values ( 2, 3, 0, 0, 'QtyHeader', 'Qty') 
go
insert into pos_param values ( 2, 3, 0, 0, 'ItemHeader', 'Item') 
go
insert into pos_param values ( 2, 3, 0, 0, 'DescHeader', 'Description') 
go
insert into pos_param values ( 2, 3, 0, 0, 'PriceHeader', 'Price') 
go
insert into pos_param values ( 2, 3, 0, 0, 'PLUHeader', 'PLU') 
go
insert into pos_param values ( 2, 3, 0, 0, 'ValueHeader', 'Value') 
go
insert into pos_param values ( 2, 3, 0, 0, 'CustNoTag', 'Number') 
go
insert into pos_param values ( 2, 3, 0, 0, 'CustNameTag', 'Name') 
go
insert into pos_param values ( 2, 3, 0, 0, 'CustAddrTag', 'Address') 
go
insert into pos_param values ( 2, 3, 0, 0, 'CustCityTag', 'City') 
go
insert into pos_param values ( 2, 3, 0, 0, 'CustStateTag', 'State') 
go
insert into pos_param values ( 2, 3, 0, 0, 'CustZipTag', 'Zip') 
go
insert into pos_param values (  2, 3, 0, 0, 'CustPhoneTag', 'Phone') 
go
insert into pos_param values ( 2, 3, 0, 0, 'CustFaxTag', 'Fax') 
go
insert into pos_param values (  2, 3, 0, 0, 'CustEmailTag', 'E-Mail') 
go
insert into pos_param values (  2, 3, 0, 0, 'OverMeiaLimit', 'Over Media Limit') 
go
insert into pos_param values (  2, 3, 0, 0, 'UnderMediaLimit', 'Under Media Limit') 
go
insert into pos_param values (  2, 3, 0, 0, 'ConvertedTotal', 'Converted Total') 
go
insert into pos_param values (  2, 3, 0, 0, 'AltCurrTotal', 'Alternate Currency Total') 
go



insert into pos_param values (  2, 3, 0, 0, 'LocaleLanguage', 'en') 
go
insert into pos_param values (  2, 3, 0, 0, 'LocaleCountry', 'US') 
go
insert into pos_param values (  2, 3, 0, 0, 'LocaleVariant', '') 
go

insert into pos_param values (2, 2, 0, 0, 'DecimalPlaces', '2') 
go
insert into pos_param values ( 2, 4, 0, 0, 'PromptForCashBack', 'TRUE') 
go
insert into pos_param values ( 2, 2, 0, 0, 'DefaultDrawerNo', '1') 
go
insert into pos_param values ( 2, 3, 0, 0, 'Idle1', ' Welcome to         ') 
go
insert into pos_param values (2, 3, 0, 0, 'Idle2', '       my shop......') 
go
insert into pos_param values ( 2, 3, 0, 0, 'MaximumPluLength', '13') 
go

insert into pos_param values ( 2, 3, 0, 0, 'ReturnSalePrompt', 'Return Sale') 
go
insert into pos_param values ( 2, 3, 0, 0, 'SalePrompt', 'Sales Transaction') 
go


insert into pos_param values ( 2, 3, 0, 0, 'CurrencyPanel', 'Currency') 
go
insert into pos_param values ( 2, 3, 0, 0, 'DiscountsPanel', 'Discounts') 
go
insert into pos_param values ( 2, 3, 0, 0, 'PromotionsPanel', 'Promotions') 
go
insert into pos_param values ( 2, 3, 0, 0, 'TenderPanel', 'Tender') 
go
insert into pos_param values ( 2, 3, 0, 0, 'ExitPanel', 'Exit') 
go
insert into pos_param values ( 2, 3, 0, 0, 'HelpPanel', 'Help') 
go
insert into pos_param values ( 2, 3, 0, 0, 'ItemPanel', 'Item Search') 
go
insert into pos_param values ( 2, 3, 0, 0, 'ItemLookupPanel', 'Item Search') 
go
insert into pos_param values ( 2, 3, 0, 0, 'CommonTasksPanel', 'Common Tasks') 
go
insert into pos_param values ( 2, 3, 0, 0, 'ManagerPanel', 'Manager Functions') 
go
insert into pos_param values ( 2, 3, 0, 0, 'SKUDetailsPanel', 'Product Details') 
go
insert into pos_param values ( 2, 3, 0, 0, 'ReceiptLogo', 'sample2.bmp') 
go
insert into pos_param values ( 2, 3, 0, 0, 'TaxIncludedText', 'GST    5%') 
go
insert into pos_param values ( 2, 3, 0, 0, 'TotalItemCountText', 'Item count') 
go
insert into pos_param values ( 2, 3, 0, 0, 'InsufficientUserAuthority', 'Insufficient User Authority') 
go



insert into dialog values (1600, 2, 0, 1, 'Open') 
go
insert into dialog_event values (2,  1600, 1, 0, 'Register Open', 0,  1, 1, 'EclipsePos.Apps.PosEvents.RegisterOpen') 
go
insert into dialog_event values (2, 1600, 3, 0, null, 0,  1, 1, 'EclipsePos.Apps.PosEvents.NewLogon') 
go
insert into dialog_event values (2, 1600, 4, 0, 'Complete logon', 8,  1, 1, 'EclipsePos.Apps.PosEvents.Logon') 
go
insert into dialog_event values (2, 1600, 5, 0, 'Get Open Amount', 3,  0, 0, null) 
go
insert into dialog_event values (2, 1600, 6, 0, 'Get Drawer', 2,  0, 0, null) 
go




insert into dialog values (1601, 2, 0, 1, 'Logon') 
go

insert into dialog_event values (2,  1601, 1, 0, null, 0,  1, 1, 'EclipsePos.Apps.PosEvents.RegisterOpen') 
go
insert into dialog_event values (2,  1601, 3, 0, null, 0,  1, 1, 'EclipsePos.Apps.PosEvents.NewLogon') 
go
insert into dialog_event values (2,  1601, 4, 0, null, 0,  1, 1, 'EclipsePos.Apps.PosEvents.LogOn') 
go



insert into dialog values (1602, 2, 0, 1, 'ManagerRequired') 
go


insert into dialog_event values (2,  1602, 1,  0, null, 1005, 1, 1, 'EclipsePos.Apps.PosEvents.Error') 
go
insert into dialog_event values (2,  1602, 2,  0, null, 29,   1, 1, 'EclipsePos.Apps.PosEvents.UserValidation') 
go
insert into dialog_event values (2,  1602, 4,  0, null, 30,   1, 1, null) 
go
insert into dialog_event values (2,  1602, 4,  0, null, 70,   1, 1, null) 
go



insert into dialog values (1603, 2, 0, 1, 'CashTender') 
go



insert into dialog_event values (2,  1603, 1, 0, null, 0,  1, 1, 'EclipsePos.Apps.PosEvents.RegisterOpen') 
go
insert into dialog_event values (2,  1603, 3, 0, null, 0, 1, 1, 'EclipsePos.Apps.PosEvents.FinishTransaction') 
go
insert into dialog_event values (2,  1603, 4, 0, null, 0, 1, 1, 'EclipsePos.Apps.PosEvents.CloseCashDrawer') 
go
insert into dialog_event values (2,  1603, 5, 0, null, 0, 1, 1, 'EclipsePos.Apps.PosEvents.PromptPrintReceipt') 
go
insert into dialog_event values (2,  1603, 6, 0, null, 0, 1, 1, 'EclipsePos.Apps.EJournal.EjTender') 
go
insert into dialog_event values (2,  1603, 7, 0, null, 0, 1, 1, 'EclipsePos.Apps.PosEvents.CheckHardware') 
go



insert into dialog values (1604, 2, 0, 1, 'CheckTender') 
go



insert into dialog_event values (2,  1604, 1, 0, null, 0,  1, 1, 'EclipsePos.Apps.PosEvents.RegisterOpen') 
go
insert into dialog_event values (2,  1604, 3, 0, null, 0, 1, 1, 'EclipsePos.Apps.PosEvents.FinishTransaction') 
go
insert into dialog_event values (2,  1604, 4, 0, null, 0, 1, 1, 'EclipsePos.Apps.PosEvents.CloseCashDrawer') 
go
insert into dialog_event values (2,  1604, 5, 0, null, 0, 1, 1, 'EclipsePos.Apps.PosEvents.PromptPrintReceipt') 
go
insert into dialog_event values (2,  1604, 6, 0, null, 5, 1, 1, 'EclipsePos.Apps.EJournal.EjCheckTender')  
go
insert into dialog_event values (2,  1604, 7, 0, null, 2, 1, 1, null) 
go
insert into dialog_event values (2,  1604, 8, 0, null, 1, 1, 1, null) 
go
insert into dialog_event values (2,  1604, 9, 0, null, 0, 1, 1, 'EclipsePos.Apps.PosEvents.CheckHardware') 
go


insert into dialog values (1605, 2, 0, 1, 'CreditTender') 
go



insert into dialog_event values (2,  1605, 1, 0, null, 0,  1, 1, 'EclipsePos.Apps.PosEvents.RegisterOpen') 
go
insert into dialog_event values (2,  1605, 3, 0, null, 0, 1, 1, 'EclipsePos.Apps.PosEvents.FinishTransaction') 
go
insert into dialog_event values (2,  1605, 4, 0, null, 0, 1, 1, 'EclipsePos.Apps.PosEvents.CloseCashDrawer') 
go
insert into dialog_event values (2,  1605, 5, 0, null, 0, 1, 1, 'EclipsePos.Apps.PosEvents.PromptPrintReceipt') 
go
insert into dialog_event values (2,  1605, 6, 0, null, 8, 1, 1, 'EclipsePos.Apps.EJournal.EjCCTender') 
go
insert into dialog_event values (2,  1605, 7, 0, null, 7, 1, 1, null) 
go
insert into dialog_event values (2,  1605, 8, 0, null, 3, 1, 1, null) 
go
insert into dialog_event values (2,  1605, 9, 0, null, 2, 1, 1, null) 
go
insert into dialog_event values (2,  1605, 10 , 0, null, 1, 1, 1, null) 
go
insert into dialog_event values (2,  1605, 11, 0, null, 0, 1, 1, 'EclipsePos.Apps.PosEvents.CheckHardware') 
go




insert into dialog values (1606, 2, 0, 1, 'AltCurrTender') 
go



insert into dialog_event values (2,  1606, 1, 0, null, 0, 1, 1, 'EclipsePos.Apps.PosEvents.RegisterOpen') 
go
insert into dialog_event values (2,  1606, 2, 0, null, 0, 1, 1, 'EclipsePos.Apps.PosEvents.FinishTransaction') 
go
insert into dialog_event values (2,  1606, 3, 0, null, 0, 1, 1, 'EclipsePos.Apps.PosEvents.CloseCashDrawer') 
go
insert into dialog_event values (2,  1606, 4, 0, null, 0, 1, 1, 'EclipsePos.Apps.PosEvents.PromptPrintReceipt') 
go
insert into dialog_event values (2,  1606, 5, 0, null, 1, 1, 1, 'EclipsePos.Apps.EJournal.EjAltCurrTender') 
go



insert into dialog values (1607, 2, 0, 1, 'RecallEj') 
go


insert into dialog_event values (2,  1607, 1, 0, null, 5, 1, 1, 'EclipsePos.Apps.PosEvents.RecallEj') 
go
insert into dialog_event values (2,  1607, 2, 0, null, 2, 1, 1, null) 
go
insert into dialog_event values (2,  1607, 3, 0, null, 1, 1, 1, null) 
go



insert into dialog values (1608, 2, 0, 1, 'PaidIn') 
go


insert into dialog_event values (2,  1608, 1, 0, null, 0, 1, 1, 'EclipsePos.Apps.PosEvents.RegisterOpen') 
go
insert into dialog_event values (2,  1608, 3, 0, null, 0, 1, 1, 'EclipsePos.Apps.PosEvents.FinishTransaction') 
go
insert into dialog_event values (2,  1608, 4, 0, null, 0, 1, 1, 'EclipsePos.Apps.PosEvents.CloseCashDrawer') 
go
insert into dialog_event values (2,  1608, 5, 0, null, 1, 1, 1, 'EclipsePos.Apps.EJournal.EjBank') 
go


insert into dialog values (1609, 2,  0, 1, 'PaidOut') 
go


insert into dialog_event values (2,  1609, 1, 0, null, 0, 1, 1, 'EclipsePos.Apps.PosEvents.RegisterOpen') 
go
insert into dialog_event values (2,  1609, 3, 0, null, 0, 1, 1, 'EclipsePos.Apps.PosEvents.FinishTransaction') 
go
insert into dialog_event values (2,  1609, 4, 0, null, 0, 1, 1, 'EclipsePos.Apps.PosEvents.CloseCashDrawer') 
go
insert into dialog_event values (2,  1609, 5, 0, null, 2, 1, 1, 'EclipsePos.Apps.EJournal.EjBank') 
go



insert into dialog values (1611, 2, 0, 1, 'PettyCash') 
go


insert into dialog_event values (2,  1611, 1, 0, null, 0, 1, 1, 'EclipsePos.Apps.PosEvents.RegisterOpen') 
go
insert into dialog_event values (2,  1611, 3, 0, null, 0, 1, 1, 'EclipsePos.Apps.PosEvents.FinishTransaction') 
go
insert into dialog_event values (2,  1611, 4, 0, null, 0, 1, 1, 'EclipsePos.Apps.PosEvents.CloseCashDrawer') 
go
insert into dialog_event values (2,  1611, 5, 0, null, 1, 1, 1, 'EclipsePos.Apps.EJournal.EjBank') 
go


insert into dialog values (1611, 2, 0, 1, 'UnLock') 
go



insert into dialog_event values (2,  1611, 1, 0, null, 2, 1, 1, 'EclipsePos.Apps.PosEvents.UnLock') 
go
insert into dialog_event values (2,  1611, 2, 0, null, 0, 1, 1, null) 
go






insert into media values ( 2, 1, 20000, 0, 'Cash', null) 
go
insert into media values ( 2, 2, 100, 0, 'Check', null) 
go
insert into media values ( 2, 3, 100000, 0, 'Visa', null) 
go
insert into media values ( 2, 4, 100000, 0, 'Master Card', null) 
go
insert into media values ( 2, 5, 100000, 0, 'American Express', null) 
go
insert into media values ( 2, 6, 100000, 0, 'Debit Card', null) 
go
insert into media values ( 2, 7, 100000, 0, 'Euro', null) 
go
insert into media values ( 2, 8, 100000, 0, 'DEM', null) 
go
insert into media values ( 2, 9, 100000, 0, 'DKK', null) 
go




insert into promotion values ( 2, 101, 1,   3, 0, 0, 0, 0,    20,  0, 0, 0, 0,   0,	 ' ', ' ', 'Group Discount',	'EclipsePos.Apps.Operators.GroupDiscount' )
go 
insert into promotion values ( 2, 201, 1,   3, 0, 0, 0, 0,   10.00,  0, 0, 0, 0,   0,	 ' ', ' ', '3 for $10',	'EclipsePos.Apps.Operators.NForX' )
go



insert into promotion values ( 2, 1, 1,   1, 0, 0, 0, 0,    10,  0, 0, 0, 0,   0,	 ' ', ' ', 'Item markdown ',	'EclipsePos.Apps.Operators.ItemDiscount' )
go  
insert into promotion values ( 2, 2, 1,   1, 0, 0, 0, 0,    20,  0, 0, 0, 0,   0,	 ' ', ' ', 'Item markdown ',	'EclipsePos.Apps.Operators.ItemDiscount' )
go
insert into promotion values ( 2, 3, 1,   1, 0, 0, 0, 0,    30,  0, 0, 0, 0,   0,	 ' ', ' ', 'Item markdown ',	'EclipsePos.Apps.Operators.ItemDiscount' )
go 
insert into promotion values ( 2, 4, 1,   1, 0, 0, 0, 0,    40,  0, 0, 0, 0,   0,	 ' ', ' ', 'Item markdown ',	'EclipsePos.Apps.Operators.ItemDiscount' )
go
insert into promotion values ( 2, 5, 1,   1, 0, 0, 0, 0,    50,  0, 0, 0, 0,   0,	 ' ', ' ', 'Item markdown ',	'EclipsePos.Apps.Operators.ItemDiscount' )
go


INSERT into pos VALUES( 110, 1, 2, 0, 'Corner store', '8-12-08', '8-12-08' )

go