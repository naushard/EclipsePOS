use possite1
go


delete from menu_panels where config_no = 5
go
delete from pos_key where config_no = 5
go
delete from pos_param where config_no = 5
go
delete from menu_config where config_no = 5
go

delete from ItemGroup where organization_no = '40'

go
 


delete from trans_stock where organization_no = '40'
go

delete from stock_balance where organization_no = '40'
go

delete from item where organization_no='40'
go


delete from promotion where organization_no = '40'
go

delete from customer where organization_no ='40'
go


delete from tax where organization_no ='40'
go

delete from tax_group  where organization_no ='40'
go

delete from employee_role_event where organization_no ='40'
go
delete from employee_roles where organization_no ='40'
go


delete from employee where organization_no ='40'
go




delete from pos where organization_no ='40'
go

delete from retail_store where organization_no ='40'
go



delete from organization where organization_no ='40'
go

delete from pos_config where config_no =5
go


print 'Delete complete'

go

INSERT INTO pos_config
           ([config_no]
			,[name]
           )
  VALUES (5
			,'Queens Emporium'
           )
go




 -- Panel Classes
insert into menu_panels values ( 5, 71, 'Other Menus', 'EclipsePos.Apps.Views.LeftMenu.LeftMenuView')
go
insert into menu_panels values ( 5, 91, 'Discounts', 'EclipsePos.Apps.Views.LeftMenu.LeftMenuView')
go
insert into menu_panels values ( 5, 93, 'Common Ops', 'EclipsePos.Apps.Views.LeftMenu.LeftMenuView')
go
insert into menu_panels values ( 5, 94, 'Tender', 'EclipsePos.Apps.Views.LeftMenu.LeftMenuView')
go
insert into menu_panels values ( 5, 95, 'Item Lookup', 'EclipsePos.Apps.Views.LeftMenu.LeftMenuView')
go
insert into menu_panels values ( 5, 96, 'Day End', 'EclipsePos.Apps.Views.LeftMenu.LeftMenuView')
go
insert into menu_panels values ( 5, 97, 'Payments', 'EclipsePos.Apps.Views.LeftMenu.LeftMenuView')
go
insert into menu_panels values ( 5, 98, 'Tools', 'EclipsePos.Apps.Views.LeftMenu.LeftMenuView')
go
insert into menu_panels values ( 5, 99, 'Exit', 'EclipsePos.Apps.Views.LeftMenu.LeftMenuView')
go
insert into menu_panels values ( 5, 991, 'Panel navigator', 'EclipsePos.Apps.Views.BottomMenu.BottomMenuView')
go
insert into menu_panels values ( 5, 992, 'Cash Bills and Coins', 'EclipsePos.Apps.Views.LeftMenu.LeftMenuView')
go
insert into menu_panels values ( 5, 993, 'Card Types', 'EclipsePos.Apps.Views.LeftMenu.LeftMenuView')
go
insert into menu_panels values ( 5, 994, 'Item Groups', 'EclipsePos.Apps.Views.ItemGroup.ItemGroupView')
go



-- Menus
insert into menu_config values ( 5, 1, 'Item Group', 994, 0, 991)
go
insert into menu_config values ( 5, 2, 'Tender', 94, 0, 991)
go
insert into menu_config values ( 5, 3, 'Tools', 93, 99, 991)
go
insert into menu_config values ( 5, 4, 'Manager', 96, 97, 991)
go
insert into menu_config values ( 5, 5, 'Others', 93, 71, 991)
go
insert into menu_config values ( 5, 6, 'Discounts', 91, 0, 991)
go
insert into menu_config values ( 5, 7, 'Exit', 99, 0, 991)
go


insert into menu_config values ( 5, 41, 'Coins', 992, 0, 991)
go
insert into menu_config values ( 5, 42, 'Cards', 993, 0, 991)
go













 
 
-- Navigator

insert into pos_key values (5, 991,	'-Disc%',		1,   6,   112,		3,	20,		8,	48,		118,		90,		192,	90,	null,1, 'EclipsePos.Apps.PosEvents.MenuNavigator', 'Discounts', 'F1')
go
	  				
insert into pos_key values (5, 991,	'Qty',			1,   91,   113,		3,	140,	8,  48,		118,		91,		192,	91,	null,1, 'EclipsePos.Apps.PosEvents.Quantity', 'Qty', 'F2')
go

insert into pos_key values (5, 991,	'X-Item',		1,   92,   114,		3,	260,	8,  48,		118,		93,		192,	92,	null,1, 'EclipsePos.Apps.PosEvents.ItemVoid', 'X-Item', 'F3')
go

insert into pos_key values (5, 991,	'X-Sale',		1,   93,   115,		3,	380,	8,  48,		118,		94,		192,	93,	null,1, 'EclipsePos.Apps.PosEvents.VoidSale', 'X-Sale', 'F4')
go

insert into pos_key values (5, 991,	'Tender',		1,   2,   116,		3,	500,	8,  48,		118,		95,		192,	94,	null,1, 'EclipsePos.Apps.PosEvents.MenuNavigator', 'Tender', 'F5')
go
														  				
insert into pos_key values (5, 991,	'More...',		1,   5,   117,		3,	860,	8,  48,		118,		96,		192,	95,	null,1, 'EclipsePos.Apps.PosEvents.MenuNavigator', 'Menu', 'F8')
go

														  				
														  				
										  				
														  				
												  				
														  				







-- Save/Recall/Return
insert into pos_key values (5, 93,	'Ctrl',		1,   0,  1005,		3,  170,		285,		48, 56, 95,	192,	131184,	null,1, 'EclipsePos.Apps.PosEvents.SaveEj', 'Save Order','F2')
go
insert into pos_key values (5, 93,	'Ctrl',		1,   0,  1006,		3,  170,		334,		48, 56, 96,	192,	131185,	null,1,'EclipsePos.Apps.PosEvents.RecallEj', 'Recall Order','F3')
go
insert into pos_key values (5, 93,	'Ctrl',		1,   0,  1007,		3, 170,			432,		48, 56, 97,	192,	131186,	null,1, 'EclipsePos.Apps.PosEvents.ReturnSale','Return Sale','F4')
go
insert into pos_key values (5, 93,	'Ctrl',		1,   0,  1008,		3, 170,			432,		48, 56, 97,	192,	131187,	null,1, 'EclipsePos.Apps.PosEvents.FreeText','Free Text','F5')
go




--insert into pos_key values (5, 93,	'Ctrl',		1,   0,  1005,		3, 170,			236,		48, 56, 94,	192,	131184,	null,1, 'EclipsePos.Apps.PosEvents.VoidSale','Void Order','F1')
--go
--insert into pos_key values (5, 93,	'Ctrl' ,	1,   96,  1009,		3, 170,			40,			48, 56,	90,	192,	131188,	null,1, 'EclipsePos.Apps.PosEvents.MenuNavigator','Manager Tasks','F5')
--go
--insert into pos_key values (5, 93,	'Ctrl',		1,   99,  1010,		3, 170,			138,		48, 56,	93,	192,	131189,	null,1, 'EclipsePos.Apps.PosEvents.MenuNavigator','Exit/Tools','F6')
--go



-- Others menus

insert into pos_key values (5, 71,	'Ctrl',		1,   7,  1010,		3, 170,			138,		48, 56,	93,	192,	131189,	null,1, 'EclipsePos.Apps.PosEvents.MenuNavigator','Exit','F1')
go
insert into pos_key values (5, 71,	'Ctrl' ,	1,   3,  1009,		3, 170,			40,			48, 56,	90,	192,	131188,	null,1, 'EclipsePos.Apps.PosEvents.MenuNavigator','Tools','F2')
go
insert into pos_key values (5, 71,	'Ctrl' ,	1,   4,  1009,		3, 170,			40,			48, 56,	90,	192,	131188,	null,1, 'EclipsePos.Apps.PosEvents.MenuNavigator','Manager','F3')
go




				 							 		  			


-- Payments
insert into pos_key values (5, 97,	'Ctrl',		1,   0,  1041,		3,  170,		40,		48, 56,		90,	100,	131184,		null,1,'EclipsePos.Apps.PosEvents.PaidIn', 'Paid In','F1')
go

insert into pos_key values (5, 97,	'Ctrl',		1,   0,  1042,		3,  170,		89,		48, 56,		91,	100,	131185,		null,1,'EclipsePos.Apps.PosEvents.PaidOut', 'Paid Out','F2')
go

insert into pos_key values (5, 97,	'Ctrl',		1,   0,	 1043,		3, 170,			138,	48, 56,		92,	50,		131186,		null,1, 'EclipsePos.Apps.PosEvents.TrainingMode', 'Training Mode','F3')
go
     				  		  		

-- Day End
insert into pos_key values (5, 96,	'Ctrl',		1,   1,	 8831,		3,	170,		187,	48,  56,	93,	25,		131184,		null,	1,	'EclipsePos.Apps.PosEvents.TerminalReport', 'X-Report','F4')
go

insert into pos_key values (5, 96,	'Ctrl',		1,   2,	 8832,		3,	170,		236,	48,  56,    94,	0,		131185,		null,	1,	'EclipsePos.Apps.PosEvents.TerminalReport', 'Z-Report','F5')
go







-- Exit
insert into pos_key values (5, 99,		'Ctrl',		1,   0,	1051,		3, 170,			89,			48, 56,0,	0,	131184,	null,1, 'EclipsePos.Apps.PosEvents.Lock','Lock','F1')
go

insert into pos_key values (5, 99,		'Ctrl',		1,   2,	 1052,		3,  170,		40,			48, 56,90,0, 131185,null,1, 'EclipsePos.Apps.PosEvents.LogOff', 'Log Off','F2')
go

insert into pos_key values (5, 99,		'Ctrl',		1,  -1,	 1053,		3,  170,		89,			48, 56,91,50, 131186,null,1, 'EclipsePos.Apps.PosEvents.Exit', 'Shutdown','F3')
go

insert into pos_key values (5, 99,		'Ctrl',		1,   1,	 1054,		3,  170,		89,			48, 56,91,50, 131187,null,1, 'EclipsePos.Apps.PosEvents.SystemManager', 'System Manager','F4')
go









-- Cash tender Notes/Coins
insert into pos_key values (5, 992,	'Ctrl' ,		1,   10000,		1091,	3,	 170,	40,   48,  56, 90,	0, 131184,null,1,'EclipsePos.Apps.PosEvents.MediaValue', '100.00','F1')
go

insert into pos_key values (5, 992,	'Ctrl',			1,   5000,		1092,	3,	170,	89,   48,  56, 91,	0, 131185,null,1,'EclipsePos.Apps.PosEvents.MediaValue', '50.00','F2')
go

insert into pos_key values (5, 992,	'Ctrl',			1,   1000,		1093,	3,	170,	138,  48,  56, 92,	0, 131186,null,1,'EclipsePos.Apps.PosEvents.MediaValue', '10.00','F3')
go

insert into pos_key values (5, 992,	'Ctrl',			1,   500,		1094,	3,	170,	187,  48,  56, 93,	0, 131187,null,1,'EclipsePos.Apps.PosEvents.MediaValue', '5.00','F4')
go

insert into pos_key values (5, 992,	'Ctrl',			1,   200,		1095,	3,	170,	236,  48,  56, 94,	0, 131188,null,1,'EclipsePos.Apps.PosEvents.MediaValue', '2.00','F5')
go

insert into pos_key values (5, 992,	'Ctrl',			1,   100,		1096,	3,	170,	285,  48,  56, 95,	0, 131189,null,1,'EclipsePos.Apps.PosEvents.MediaValue', '1.00','F6')
go

insert into pos_key values (5, 992,	'Ctrl',			1,   50,		1097,	3,	170,	334,  48,  56, 96,	0, 131190,null,1,'EclipsePos.Apps.PosEvents.MediaValue', '.50','F7')
go

insert into pos_key values (5, 992,	'Ctrl',			1,   20,		1098,	3,	170,	383,  48,  56, 97,	0, 131191,null,1,'EclipsePos.Apps.PosEvents.MediaValue', '.20','F8')
go

insert into pos_key values (5, 992,	'Ctrl',			1,   10,		1099,	3,	170,	432,  48,  56, 98,	0, 131192,null,1,'EclipsePos.Apps.PosEvents.MediaValue', '.10','F9')
go



-- Credit card types
insert into pos_key values (5, 993,	'Ctrl' ,		1,   0,		1101,	3,	 170,	40,   48,  56, 90,	0, 131184, 'Visa.gif',	1,	'EclipsePos.Apps.PosEvents.MediaText', 'VISA','F1')
go

insert into pos_key values (5, 993,	'Ctrl',			1,   0,		1102,	3,	170,	89,   48,  56, 91,	0, 131185, 'MasterCard.gif',	1,	'EclipsePos.Apps.PosEvents.MediaText', 'MASTER','F2')
go

insert into pos_key values (5, 993,	'Ctrl',			1,   0,		1103,	3,	170,	138,  48,  56, 92,	0, 131186, 'Amex.gif',	 1,	'EclipsePos.Apps.PosEvents.MediaText', 'AMEX','F3')
go

insert into pos_key values (5, 993,	'Ctrl',			1,   0,		1104,	3,	170,	187,  48,  56, 93,	0, 131187, 'Discover.gif',	1,	'EclipsePos.Apps.PosEvents.MediaText', 'DISCOVER','F4')
go

insert into pos_key values (5, 993,	'Ctrl',			1,   0,		1105,	3,	170,	236,  48,  56, 94,	0, 131188,	null,	1,	'EclipsePos.Apps.PosEvents.MediaText', 'NETS','F5')
go


-- Tender
insert into pos_key values (5, 94,		'Ctrl' ,	1,  -1,  1031,		3, 170,			40,		48, 56,	90,	192,	131184,	null,1, 'EclipsePos.Apps.PosEvents.CashTender','Cash ','F1')
go

insert into pos_key values (5, 94,		'Ctrl',		1,   0,  1032,		3, 170,			89,		48, 56, 91,	192,	131185,	null,1, 'EclipsePos.Apps.PosEvents.CheckTender','Check ','F2')
go

insert into pos_key values (5, 94,		'Ctrl',		1,   0,  1033,		3, 170,			138,	48, 56,	92,	192,	131186,	null,1, 'EclipsePos.Apps.PosEvents.CreditTender','Credit Card ','F3')
go

insert into pos_key values (5, 94,		'Ctrl',		1,   0,  1034,		3, 170,			138,	48, 56,	93,	192,	131187,	null,1, 'EclipsePos.Apps.PosEvents.DebtTender','Debt','F4')
go


-- Discounts 

insert into pos_key values (5, 91,		'-20% All',		1,   101,	1011,		3,  170,	40,			48, 56,	90,	192,	131184,	null,1, 'EclipsePos.Apps.PosEvents.ItemMarkdown','Whole. 20%','F1')
go

insert into pos_key values (5, 91,		'-10% SKU',		1,   1,		1012,		3,  170,	89,			48, 56,	91,	192,	131185,	null,1, 'EclipsePos.Apps.PosEvents.ItemMarkdown','Item Disc 20%','F2')
go

insert into pos_key values (5, 91,		'-15% SKU',		1,   2,		1013,		3,  170,	138,		48, 56,	92,	192,	131186,	null,1, 'EclipsePos.Apps.PosEvents.ItemMarkdown','Item Disc 30%','F3')
go

insert into pos_key values (5, 91,		'-20% SKU',		1,   3,		1014,		3,  170,	187,		48, 56,	93,	192,	131187,	null,1, 'EclipsePos.Apps.PosEvents.ItemMarkdown','Item Disc 40%','F4')
go

insert into pos_key values (5, 91,		'-25% SKU',		1,   4,		1015,		3,  170,	236,		48, 56,	94,	192,	131188,	null,1, 'EclipsePos.Apps.PosEvents.ItemMarkdown','Item Disc 50%','F5')
go
insert into pos_key values (5, 91,		'-Input',		1,   201,	1016,		3,  170,	285,		48, 56,	94,	192,	131189,	null,1, 'EclipsePos.Apps.PosEvents.ItemMarkdown','Disc. input','F6')
go





Print('Creating pos_param')
go

-- Line display
insert into pos_param values (5, 5, 1, 1, 'CustWelcome', 'Welcome', null) 
go



-- Customer receipt print
insert into pos_param values ( 5, 5, 2, 1, 'ReceiptTopMOD1', 'Biz Reg. No. 2567891555 W', null) 
go
insert into pos_param values ( 5, 5, 2, 2, 'ReceiptTopMOD2', 'GST Reg. No. ME-845234-7', null) 
go
insert into pos_param values ( 5, 5, 2, 3, 'ReceiptTopMOD3', '*** Enjoy 5% cash rebates ***', null) 
go
insert into pos_param values ( 5, 5, 2, 4, 'ReceiptTopMOD4', 'When you use POSB Everyday credit card', null) 
go
insert into pos_param values ( 5, 5, 2, 5, 'ReceiptBottomMOD', 'Thank you for shopping', null) 
go
insert into pos_param values ( 5, 5, 2, 6, 'TrxNo', 'TRX: ', null) 
go
insert into pos_param values ( 5, 5, 2, 7, 'PosNo', 'POS: ', null) 
go
insert into pos_param values ( 5, 5, 2, 12, 'ReceiptLogo', 'sample2.bmp', null) 
go
insert into pos_param values ( 5, 5, 2, 13, 'TaxIncludedText', 'GST    7%', null) 
go
insert into pos_param values ( 5, 5, 2, 14, 'TotalItemCountText', 'Item count', null) 
go
insert into pos_param values ( 5, 5, 2, 15, 'ConvertedAltCurrency', 'Converted total', null) 
go
insert into pos_param values ( 5, 5, 2, 16, 'AltCurrencyDescription', 'Alternate Currency Tender', null) 
go
insert into pos_param values ( 5, 5, 2, 17, 'Total', 'TOTAL', null) 
go
insert into pos_param values ( 5, 5, 2, 18, 'BalanceDue', 'Balance Due', null) 
go
insert into pos_param values ( 5, 5, 2, 19, 'CashTender', 'Cash Tender', null) 
go
insert into pos_param values ( 5, 5, 2, 20, 'CheckTender', 'Check Tender', null) 
go
insert into pos_param values ( 5, 5, 2, 21, 'CreditTender', 'Credit Card Tender', null)
go
insert into pos_param values ( 5, 5, 2, 22, 'Change', 'Change Due', null) 
go
insert into pos_param values ( 5, 5, 2, 23, 'TableText', 'Table No.', null) 
go
insert into pos_param values ( 5, 5, 2, 24, 'DebitCardTender', 'Debit Card Tender', null)
go
insert into pos_param values ( 5, 5, 2, 25, 'VoidSaleText', 'Void Sales', null)
go
insert into pos_param values ( 5, 5, 2, 26, 'LogoBitmapWidth', '200', null)
go


-- POS Workbench settings

insert into pos_param values ( 5, 5, 3, 1, 'TotalTax', 'Total Tax', null) 
go
insert into pos_param values ( 5, 5, 3, 2, 'SubTotal', 'SUBTOTAL', null) 
go
insert into pos_param values ( 5, 5, 3, 3, 'Discount', 'Discount', null) 
go
insert into pos_param values ( 5, 5, 3, 4, 'Markout', 'Markout', null) 
go
insert into pos_param values ( 5, 5, 3, 5, 'CashBack', 'Cash Back', null) 
go
insert into pos_param values ( 5, 5, 3, 6, 'PosTag', 'Register', null) 
go
insert into pos_param values ( 5, 5, 3, 7, 'EmpTag', 'Employee', null) 
go
insert into pos_param values ( 5, 5, 3, 8, 'DateTag', 'Time/Date', null) 
go
insert into pos_param values ( 5, 5, 3, 9, 'TrxTag', 'Transaction', null) 
go
insert into pos_param values ( 5, 5, 3, 10, 'QtyHeader', 'Qty', null) 
go
insert into pos_param values ( 5, 5, 3, 11, 'ItemHeader', 'Item', null) 
go
insert into pos_param values ( 5, 5, 3, 12, 'DescHeader', 'Description', null) 
go
insert into pos_param values ( 5, 5, 3, 13, 'PriceHeader', 'Price', null) 
go
insert into pos_param values ( 5, 5, 3, 14, 'ValueHeader', 'Value', null) 
go
insert into pos_param values ( 5, 5, 3, 15, 'SubtotalTag', 'Subtotal', null) 
go
insert into pos_param values ( 5, 5, 3, 16, 'TotalTaxTag', 'Tax', null) 
go
insert into pos_param values ( 5, 5, 3, 17, 'GrandTotal', 'Total', null) 
go
insert into pos_param values ( 5, 5, 3, 18, 'TenderedTag', 'Tendered', null) 
go
insert into pos_param values ( 5, 5, 3, 19, 'LineNumberHeader', 'Ln', null) 
go




-- POS Workbench operator prompt text
insert into pos_param values ( 5, 5, 4, 1, 'CloseDrawer', 'Close Cash Drawer', null) 
go
insert into pos_param values ( 5, 5, 4, 2, 'InsertCheck', 'Insert check', null) 
go
insert into pos_param values ( 5, 5, 4, 3, 'InsertValidation', 'Insert Validation', null) 
go
insert into pos_param values ( 5, 5, 4, 4, 'InsertCCValidation', 'Insert credit card receipt', null) 
go
insert into pos_param values ( 5, 5, 4, 5, 'BadName', 'Bad user ID, press clear', null) 
go
insert into pos_param values ( 5, 5, 4, 6, 'BadPass', 'Invalid password, press clear', null) 
go
insert into pos_param values ( 5, 5, 4, 7, 'InvalidCustomer', 'Invalid customer number, press clear', null) 
go
insert into pos_param values ( 5, 5, 4, 8, 'TooMany', 'Too many logon attempts, press clear', null) 
go
insert into pos_param values ( 5, 5, 4, 9, 'GoodLogin', 'Logon successful', null) 
go
insert into pos_param values ( 5, 5, 4, 10, 'OkText', 'OK', null) 
go
insert into pos_param values ( 5, 5, 4, 11, 'CancelText', 'Cancel', null) 
go
insert into pos_param values ( 5, 5, 4, 12, 'ClearText', 'Clear', null) 
go
insert into pos_param values ( 5, 5, 4, 13, 'InvalidInput', 'Invalid Input, press clear', null) 
go
insert into pos_param values ( 5, 5, 4, 14, 'PromptOpenAmount', 'Enter open amount: ', null) 
go
insert into pos_param values ( 5, 5, 4, 15, 'PromptAmount', 'Enter amount: ', null) 
go
insert into pos_param values ( 5, 5, 4, 16, 'PromptCashBack', 'Cash back amount:', null) 
go
insert into pos_param values ( 5, 5, 4, 17, 'ConfirmOpenAmount', 'Confirm (enter/clear)', null) 
go
insert into pos_param values ( 5, 5, 4, 18, 'RegOpen', 'Register Open', null) 
go
insert into pos_param values ( 5, 5, 4, 19, 'ReturnSale', 'Return Sale', null) 
go
insert into pos_param values ( 5, 5, 4, 20, 'TotalRequired', 'Total Required, press clear', null) 
go
insert into pos_param values ( 5, 5, 4, 21, 'InsufficientFunds', 'Insufficient Funds, press clear', null) 
go
insert into pos_param values ( 5, 5, 4, 23, 'MgrIntervention', 'Manager intervention required', null) 
go
insert into pos_param values ( 5, 5, 4, 24, 'EnterUser', 'Enter User ID: ', null) 
go
insert into pos_param values ( 5, 5, 4, 25, 'EnterPass', 'Enter Password: ', null) 
go
insert into pos_param values ( 5, 5, 4, 26, 'PromptDrawerNo', 'Enter drawer number: ', null) 
go
insert into pos_param values ( 5, 5, 4, 27, 'ConfirmDrawerNo', 'Confirm (enter/clear)', null) 
go
insert into pos_param values ( 5, 5, 4, 28, 'BadDrawerNo', 'Invalid drawer number', null) 
go
insert into pos_param values ( 5, 5, 4, 29, 'BadCheckNo', 'Invalid check number', null) 
go
insert into pos_param values ( 5, 5, 4, 30, 'BadCCNo', 'Invalid credit card', null) 
go
insert into pos_param values ( 5, 5, 4, 31, 'BadExpr', 'Bad expiration date', null) 
go
insert into pos_param values ( 5, 5, 4, 32, 'PromptCustomer', 'Enter Customer Number: ', null) 
go
insert into pos_param values ( 5, 5, 4, 33, 'VoidSale', 'Sale Voided, press enter', null) 
go
insert into pos_param values ( 5, 5, 4, 35, 'AltCurrTenderPrompt', 'Enter alternate currency amount: ', null) 
go
insert into pos_param values ( 5, 5, 4, 37, 'TenderTotal', 'Amount Tendered', null) 
go
insert into pos_param values ( 5, 5, 4, 38, 'TerminalLocked', 'Terminal locked, press enter', null) 
go
insert into pos_param values ( 5, 5, 4, 39, 'EnterItem', 'Enter item', null) 
go
insert into pos_param values ( 5, 5, 4, 40, 'EnterWeight', 'Enter weight', null) 
go
insert into pos_param values ( 5, 5, 4, 41, 'Pause', 'Press enter to continue...', null) 
go
insert into pos_param values ( 5, 5, 4, 42, 'CloseCash', 'Close cash drawer.', null) 
go
insert into pos_param values ( 5, 5, 4, 43, 'RecallFailed', 'Transaction not found', null) 
go
insert into pos_param values ( 5, 5, 4, 44, 'CashLimitExceeded', 'Cash in drawer limit exceeded', null) 
go
insert into pos_param values ( 5, 5, 4, 45, 'EnterNewPrice', 'Enter new price:', null) 
go
insert into pos_param values ( 5, 5, 4, 46, 'PosPrinterFailed', 'PRINTER FAILURE', null) 
go
insert into pos_param values ( 5, 5, 4, 47, 'PosPrinterError', 'Printer Error' , null) 
go
insert into pos_param values ( 5, 5, 4, 48, 'CashDrawerError', 'Cash Drawer Error', null) 
go
insert into pos_param values ( 5, 5, 4, 49, 'PosLineDisplayError', 'Line Display Error', null) 
go
insert into pos_param values ( 5, 5, 4, 50, 'ShutdownKeyNotAllowed', 'Shutdown Key Not Allowed', null) 
go
insert into pos_param values ( 5, 5, 4, 51, 'NavigateButtons', 'true', null) 
go
insert into pos_param values ( 5, 5, 4, 52, 'OperReceiptFont', 'Lucida Sans Typewriter Regular', null) 
go
insert into pos_param values ( 5, 5, 4, 53, 'HeaderFont', 'Courier', null) 
go
insert into pos_param values ( 5, 5, 4, 54, 'HeaderTitleFont', 'Helvetica', null) 
go
insert into pos_param values ( 5, 5, 4, 55, 'OperReceiptFontSize', '15', null) 
go
insert into pos_param values ( 5, 5, 4, 56, 'HeaderFontSize', '12', null) 
go
insert into pos_param values ( 5, 5, 4, 57, 'HeaderTitleFontSize', '14', null) 
go
insert into pos_param values ( 5, 5, 4, 58, 'PromptPosNo', 'Enter POS Number: ', null) 
go
insert into pos_param values ( 5, 5, 4, 59, 'PromptTransNo', 'Enter Transaction Number:', null) 
go
insert into pos_param values ( 5, 5, 4, 60, 'NoSaleCount', 'No sale transactions', null) 
go
insert into pos_param values ( 5, 5, 4, 61, 'TransNo', 'TRANS#', null) 
go
insert into pos_param values ( 5, 5, 4, 62, 'TransType', 'TRANS TYPE', null) 
go
insert into pos_param values ( 5, 5, 4, 63, 'OperLogon', 'Operator logon', null) 
go
insert into pos_param values ( 5, 5, 4, 64, 'OperLogoff', 'Operator logoff', null) 
go
insert into pos_param values ( 5, 5, 4, 65, 'BankTrans', 'Bank transaction', null) 
go
insert into pos_param values ( 5, 5, 4, 66, 'PromptCheckNo', 'Enter check number:', null) 
go
insert into pos_param values ( 5, 5, 4, 67, 'PromptCCNo', 'Enter credit card number:', null) 
go
insert into pos_param values ( 5, 5, 4, 68, 'PromptCCExpr', 'Enter expiration data:', null) 
go
insert into pos_param values ( 5, 5, 4, 69, 'Confirm', 'Press enter', null) 
go
insert into pos_param values ( 5, 5, 4, 85, 'OverMeiaLimit', 'Over Media Limit', null) 
go
insert into pos_param values ( 5, 5, 4, 86, 'UnderMediaLimit', 'Under Media Limit', null) 
go
insert into pos_param values ( 5, 5, 4, 87, 'ReturnSalePrompt', 'Return Sale', null) 
go
insert into pos_param values ( 5, 5, 4, 89, 'SalePrompt', 'Sales Transaction', null) 
go
insert into pos_param values ( 5, 5, 4, 90, 'DineInPrompt', 'Dine In', null) 
go
insert into pos_param values ( 5, 5, 4, 91, 'CarryOutPrompt', 'Take Away', null) 
go
insert into pos_param values ( 5, 5, 4, 92, 'InsufficientUserAuthority', 'Insufficient User Authority', null) 
go
insert into pos_param values ( 5, 5, 4, 93, 'TableNumberPrompt', 'Enter Table no', null) 
go
insert into pos_param values ( 5, 5, 4, 94, 'PromptItemPrice', 'Enter Item Price', null) 
go
insert into pos_param values ( 5, 5, 4, 95, 'PriceChangeNotAllowed', 'Price change not allowed', null) 
go
insert into pos_param values ( 5, 5, 4, 96, 'SelectCustomer', 'Select customer and try again', null) 
go
insert into pos_param values ( 5, 5, 4, 97, 'InsufficientCreditLimit', 'Insufficient credit limit', null) 
go
insert into pos_param values ( 5, 5, 4, 98, 'DebtTender', 'Debt Tender', null) 
go
insert into pos_param values ( 5, 5, 4, 99, 'InvalidFunction', 'Invalid operation', null) 
go
insert into pos_param values ( 5, 5, 4, 100, 'PromptCardName', 'Enter card name and Press Enter', null) 
go
insert into pos_param values ( 5, 5, 4, 101, 'PromptEnterLineNumber', 'Enter Line no.', null) 
go
insert into pos_param values ( 5, 5, 4, 102, 'EnterQuantity', 'Enter Qty/Length', null) 
go
insert into pos_param values ( 5, 5, 4, 102, 'InvalidEmployeeNumber', 'Invalid Employee No.', null) 
go






-- Terminal reports
insert into pos_param values ( 5, 5, 5, 1, 'NonTaxCount', 'Non-Tax transactions', null) 
go
insert into pos_param values ( 5, 5, 5, 2, 'NonTaxAmount', 'Non-Tax amount', null) 
go
insert into pos_param values ( 5, 5, 5, 3, 'TaxCount', 'Tax transactions ', null) 
go
insert into pos_param values ( 5, 5, 5, 4, 'TaxAmount', 'Tax amount ', null) 
go
insert into pos_param values ( 5, 5, 5, 5, 'VoidCount', 'Void transactions', null) 
go
insert into pos_param values ( 5, 5, 5, 6, 'VoidAmount', 'Void amount', null) 
go
insert into pos_param values ( 5, 5, 5, 7, 'ReturnCount', 'Return transactions', null) 
go
insert into pos_param values ( 5, 5, 5, 8, 'ReturnAmount', 'Return amount', null) 
go
insert into pos_param values ( 5, 5, 5, 9, 'CouponCount', 'Coupon transactions', null) 
go
insert into pos_param values ( 5, 5, 5, 10, 'CouponAmount', 'Coupon amount', null) 
go
insert into pos_param values ( 5, 5, 5, 11, 'CreditCount', 'Credit transactions', null) 
go
insert into pos_param values ( 5, 5, 5, 12, 'CreditAmount', 'Credit amount', null) 
go
insert into pos_param values ( 5, 5, 5, 13, 'CheckCount', 'Check transactions', null) 
go
insert into pos_param values ( 5, 5, 5, 14, 'CheckAmount', 'Check amount', null) 
go
insert into pos_param values ( 5, 5, 5, 15, 'RecdOnAcctCount', 'Received on account transactions', null) 
go
insert into pos_param values ( 5, 5, 5, 16, 'RecdOnAcctAmount', 'Received on account amount', null) 
go
insert into pos_param values ( 5, 5, 5, 17, 'PaidInCount', 'Paid in transactions', null) 
go
insert into pos_param values ( 5, 5, 5, 18, 'PaidInAmount', 'Paid in Amount', null) 
go
insert into pos_param values ( 5, 5, 5, 19, 'PaidOutCount', 'Paid out transactions', null) 
go
insert into pos_param values ( 5, 5, 5, 20, 'PaidOutAmount', 'Paid out Amount', null) 
go
insert into pos_param values ( 5, 5, 5, 21, 'CashSalesCount', 'Cash sales transactions', null) 
go
insert into pos_param values ( 5, 5, 5, 22, 'CashSalesAmount', 'Cash sales Amount', null) 
go
insert into pos_param values ( 5, 5, 5, 23, 'CashInDrCount', 'Cash transactions', null) 
go
insert into pos_param values ( 5, 5, 5, 24, 'CashInDrAmount', 'Cash in drawer Amount', null) 
go
insert into pos_param values ( 5, 5, 5, 25, 'LoanCount', 'Loan transactions', null) 
go
insert into pos_param values ( 5, 5, 5, 26, 'LoanAmount', 'Loans amount', null) 
go
insert into pos_param values ( 5, 5, 5, 27, 'PickupCount', 'Pickup transactions', null) 
go
insert into pos_param values ( 5, 5, 5, 28, 'PickupAmount', 'Pickup amount', null) 
go
insert into pos_param values ( 5, 5, 5, 29, 'CashBackCount', 'Cash back transactions', null) 
go
insert into pos_param values ( 5, 5, 5, 30, 'CashBackAmount', 'Cash back Amount', null) 
go
insert into pos_param values ( 5, 5, 5, 31, 'DailyXHeader', 'X-Daily Report', null) 
go
insert into pos_param values ( 5, 5, 5, 32, 'DailyZHeader', 'Z-Daily Report', null)
go
insert into pos_param values ( 5, 5, 5, 33, 'WeeklyXHeader', 'X-Weekly Report', null)
go
insert into pos_param values ( 5, 5, 5, 34, 'WeeklyZHeader', 'Z-Weekly Report', null) 
go
insert into pos_param values ( 5, 5, 5, 35, 'MonthlyXHeader', 'X-Monthly Report', null) 
go
insert into pos_param values ( 5, 5, 5, 36, 'MonthlyZHeader', 'Z-Monthly Report', null) 
go
insert into pos_param values ( 5, 5, 5, 37, 'YearlyXHeader', 'X-Yearly Report', null) 
go
insert into pos_param values ( 5, 5, 5, 38, 'YearlyZHeader', 'Z-Yearly Report', null) 
go
insert into pos_param values ( 5, 5, 5, 39, 'SequenceNo', 'Sequence no', null) 
go
insert into pos_param values ( 5, 5, 5, 40, 'StartDate', 'Start date :', null) 
go
insert into pos_param values ( 5, 5, 5, 41, 'DebtCount', 'Debt transactions', null) 
go
insert into pos_param values ( 5, 5, 5, 42, 'DebtAmount', 'Debt Amount', null) 
go
insert into pos_param values ( 5, 5, 5, 43, 'DebitCardCount', 'Debit card transactions', null) 
go
insert into pos_param values ( 5, 5, 5, 44, 'DebitCardAmount', 'Debit card Amount', null) 
go





-- Micellanious 

insert into pos_param values ( 5, 5, 6, 1, 'CashPickup', '10000.0', null) 
go
insert into pos_param values ( 5, 5, 6, 2, 'MaximumPluLength', '13', null) 
go
insert into pos_param values ( 5, 5, 6, 3, 'PromptForCashBack', 'TRUE', null) 
go
insert into pos_param values ( 5, 5, 6, 4, 'PromptForTableNo', 'FALSE', null) 
go
insert into pos_param values ( 5, 5, 6, 5, 'HomeLeftPanelNo', '90', null) 
go
insert into pos_param values ( 5, 5, 6, 6, 'CashMediaMenuNo', '41', null) 
go
insert into pos_param values ( 5, 5, 6, 7, 'CreditMediaMenuNo', '42', null) 
go
insert into pos_param values ( 5, 5, 6, 8, 'ItemWidth%', '10', null) 
go
insert into pos_param values ( 5, 5, 6, 9, 'DescriptionWidth%', '40', null) 
go
insert into pos_param values ( 5, 5, 6, 10, 'QuantityWidth%', '10', null) 
go
insert into pos_param values ( 5, 5, 6, 11, 'PriceWidth%', '15', null) 
go
insert into pos_param values ( 5, 5, 6, 12, 'AmountWidth%', '15', null) 
go
insert into pos_param values ( 5, 5, 6, 13, 'DefaultTransactionType', '1', null) 
go
insert into pos_param values ( 5, 5, 6, 14, 'ApplyRoundingToCashTender', 'TRUE', null) 
go
insert into pos_param values ( 5, 5, 6, 15, 'AutoRoundDownPromotionNo', '999', null) 
go
insert into pos_param values ( 5, 5, 6, 16, 'LineNumberWidth%', '5', null) 
go
insert into pos_param values ( 5, 5, 6, 17, 'HomeMenuID', '1', null) 
go
insert into pos_param values ( 5, 3, 6, 18, 'FontFamily', 'Calibri', null) 
go












-- Organization

insert into organization values ( '40', 'Queens Emporium', 'Arabe Street', 
 'Blk 827', 'Unit #01-130', 'xx', 'Singapore', 'Singapore', '520 827', 'Singapore',
 '96323845', '91250053', 'Mr. XYZ', 'SGD', '200333737838G',  22, null, 0 )   

go









-- employee roles



INSERT INTO employee_roles
           ([role_id]
			,[role_name]
           ,[organization_no])
     VALUES
           (
			'1001'
			,'Manager'
			,'40'
			)

go




insert into employee_role_event values (1,   'VoidSale', '1001', '40')
go
insert into employee_role_event values (2,   'PaidIn', '1001', '40' )
go
insert into employee_role_event values (3,   'PaidOut', '1001', '40' )
go
insert into employee_role_event values (4,   'TrainingMode', '1001', '40' )
go
insert into employee_role_event values (5,   'TerminalReports', '1001', '40')
go
insert into employee_role_event values (6,   'VoidItemLine', '1001', '40')
go
insert into employee_role_event values (7,   'Store', '1001', '40')
go
insert into employee_role_event values (8,   'Recall', '1001', '40')
go
insert into employee_role_event values (9,   'Shutdown', '1001', '40' )
go
insert into employee_role_event values (10,   'LogOff', '1001', '40')
go
insert into employee_role_event values (11,  'ReturnSale', '1001', '40')
go
insert into employee_role_event values (12,   'Discount', '1001', '40')
go
insert into employee_role_event values (13,   'Promotion', '1001', '40')
go
insert into employee_role_event values (14,   'Customer', '1001', '40')
go
insert into employee_role_event values (15,   'SystemManager', '1001', '40')
go
insert into employee_role_event values (16,   'ChangePrice', '1001', '40')
go
insert into employee_role_event values (17,   'ShutDown', '1001', '40')
go
insert into employee_role_event values (18,   'CreditTender', '1001','40' )
go
insert into employee_role_event values (19,  'AltCurrencyTender', '1001', '40' )
go
insert into employee_role_event values (20,  'CheckTender',  '1001', '40')
go
insert into employee_role_event values (21,  'DebtTender',  '1001', '40')
go




 



-- employee

INSERT INTO employee
           ([organization_no]
           ,[employee_no]
           ,[logon_no]
           ,[logon_pass]
           ,[role_id]
           ,[fname]
           ,[lname]
           ,[mi]
           ,[ssn]
           ,[sal_grade])
     VALUES
           ('40'
           ,'Eclipse100'
           ,'100'
           ,'F899139DF5E1059396431415E770C6DD'
           ,'1001'
           ,'Eclipse'
           ,'ES'
           ,null
           ,null
           ,0)
 
go




INSERT INTO Retail_Store
           
     VALUES
  
			('2'
			,'40'
		   ,'Queen Emporium'
           ,'Blk 827'
           ,'Arab Street '
           ,'Singapore'
           ,''
           ,''
           ,''
           ,''
           ,''
           ,''
			,''
			,''
			,''
           ,0
			,null 
			)


GO




INSERT INTO tax_group VALUES('7','40','Zero' )
go





insert into tax values ( 1, '7', '40', 0, 'GST 0%', 0.0, 0.0) 
go











INSERT into pos VALUES( 105, '40', 2, 0, 'Station A', '8-12-08', '8-12-08' )

go



insert into ItemGroup values ('40', '1', 'LINEN' )
go
insert into ItemGroup values ('40', '2', 'LACE' )
go
insert into ItemGroup values ('40', '3', 'CHIFFON' )
go
insert into ItemGroup values ('40', '4', 'SILK' )
go
insert into ItemGroup values ('40', '5', 'SONGKET HANDLOOM' )
go
insert into ItemGroup values ('40', '6', 'SONGKET POWERLOOM' )
go
insert into ItemGroup values ('40', '7', 'SAMPING' )
go
insert into ItemGroup values ('40', '8', 'COTTON' )
go
insert into ItemGroup values ('40', '9', 'MENS' )
go
insert into ItemGroup values ('40', '10', 'POLYESTE' )
go
insert into ItemGroup values ('40', '11', 'ASSORTED' )
go
insert into ItemGroup values ('40', '12', 'REMNANT' )
go
insert into ItemGroup values ('40', '13', 'LINING' )
go
insert into ItemGroup values ('40', '14', 'PACKAGES' )
go


-- Cotton

INSERT INTO ITEM VALUES('40', '801' ,'RUBIA SWISS' , 1.00,  null, '8', 7, '3', null, null, 1, 0, null, 'MR', null, 0.0 )
go
INSERT INTO ITEM VALUES('40', '802' ,'RUBIA JAPAN' ,  1.00,  null, '8', 7, '3', null, null, 1, 0, null, 'MR', null, 0.0  )
go
INSERT INTO ITEM VALUES('40', '803' ,'PRINTED COTTON' , 1.00,  null, '8', 7, '3', null, null, 1, 0, null, 'MR', null, 0.0  )
go
INSERT INTO ITEM VALUES('40', '804' ,'VISCOSE' ,  1.00,  null, '8', 7, '3', null, null, 1, 0, null, 'MR', null, 0.0  )
go
INSERT INTO ITEM VALUES('40', '805' ,'EMBROIDERY SUIT (SMALL/B)' , 1.00,  null, '8', 7, '3', null, null, 1, 0, null, 'MR', null, 0.0  )
go
INSERT INTO ITEM VALUES('40', '806' ,'EMBROIDERY SUIT (BIG/FULL)' ,  1.00,  null, '8', 7, '3', null, null, 1, 0, null, 'MR', null, 0.0  )
go
INSERT INTO ITEM VALUES('40', '807' ,'MEN’S  SUIT' ,  1.00,  null, '8', 7, '3', null, null, 1, 0, null, 'MR', null, 0.0  )
go



-- Chiffon

INSERT INTO ITEM VALUES('40', '301' ,'CHIFFON PRINTED' , 1.00,  null, '3', 7, '3', null, null, 1, 0, null, 'MR', null, 0.0  )
go
INSERT INTO ITEM VALUES('40', '302' ,'CHIFFON SUIT (SEQUINED)' ,  1.00,  null, '3', 7, '3', null, null, 1, 0, null, 'MR', null, 0.0  )
go
INSERT INTO ITEM VALUES('40', '303' ,'CHIFFON SUIT STONE( SMALL/B)' , 1.00,  null, '3', 7, '3', null, null, 1, 0, null, 'MR', null, 0.0  )
go
INSERT INTO ITEM VALUES('40', '304' ,'CHIFFON SUIT STONE( BIG/FULL)' ,  1.00,  null, '3', 7, '3', null, null, 1, 0, null, 'MR', null, 0.0  )
go



-- SONGKET HANDLOOM
INSERT INTO ITEM VALUES('40', '501' ,'SONGKET HANDLOOM' , 1.00,  null, '5', 7, '3', null, null, 1, 0, null, 'MR', null, 0.0  )
go
INSERT INTO ITEM VALUES('40', '502' ,'SONGKET KAIN (H/L)' , 1.00,  null, '5', 7, '3', null, null, 1, 0, null, 'MR',  null, 0.0 )
go
INSERT INTO ITEM VALUES('40', '503' ,'SONGKET STRIPE(H/L)' , 1.00,  null, '5', 7, '3', null, null, 1, 0, null, 'MR', null, 0.0  )
go
INSERT INTO ITEM VALUES('40', '504' ,'SONGKET BUNGA TABUR (H/L)' , 1.00,  null, '5', 7, '3', null, null, 1, 0, null, 'MR',  null, 0.0 )
go
INSERT INTO ITEM VALUES('40', '505' ,'SONGKET STONE (H/L)' , 1.00,  null, '5', 7, '3', null, null, 1, 0, null, 'MR', null, 0.0  )
go
INSERT INTO ITEM VALUES('40', '506' ,'SONGKET COLOUR (H/L)' , 1.00,  null, '5', 7, '3', null, null, 1, 0, null, 'MR',  null, 0.0 )
go
INSERT INTO ITEM VALUES('40', '507' ,'SONGKET BIG BORDER (H/L)' , 1.00,  null, '5', 7, '3', null, null, 1, 0, null, 'MR', null, 0.0  )
go
INSERT INTO ITEM VALUES('40', '508' ,'SONGKET SAMARINDA (H/L)' , 1.00,  null, '5', 7, '3', null, null, 1, 0, null, 'MR', null, 0.0  )
go
INSERT INTO ITEM VALUES('40', '509' ,'SONGKET EXCLUSIVE (H/L)' , 1.00,  null, '5', 7, '3', null, null, 1, 0, null, 'MR',  null, 0.0 )
go


-- SONGKET POWERLOOM
INSERT INTO ITEM VALUES('40', '601' ,'SONGKET KAIN COLOUR (P/L)' , 1.00,  null, '6', 7, '3', null, null, 1, 0, null, 'MR', null, 0.0  )
go
INSERT INTO ITEM VALUES('40', '602' ,'SONGKET BUNGA TABUR (P/L)' , 1.00,  null, '6', 7, '3', null, null, 1, 0, null, 'MR',  null, 0.0 )
go
INSERT INTO ITEM VALUES('40', '603' ,'SONGKET STONE (P/L) ' , 1.00,  null, '6', 7, '3', null, null, 1, 0, null, 'MR', null, 0.0  )
go
INSERT INTO ITEM VALUES('40', '604' ,'SONGKET POWERLOOM' , 1.00,  null, '6', 7, '3', null, null, 1, 0, null, 'MR',  null, 0.0 )
go
INSERT INTO ITEM VALUES('40', '605' ,'SUIT LAPAN' , 1.00,  null, '6', 7, '3', null, null, 1, 0, null, 'MR', null, 0.0  )
go


-- SAMPING
INSERT INTO ITEM VALUES('40', '701' ,'SAMPING EXCLUSIVE  (H/L)' , 1.00,  null, '7', 7, '3', null, null, 1, 0, null, 'MR', null, 0.0  )
go
INSERT INTO ITEM VALUES('40', '702' ,'SAMPING COLOUR  (H/L)' , 1.00,  null, '7', 7, '3', null, null, 1, 0, null, 'MR',  null, 0.0 )
go
INSERT INTO ITEM VALUES('40', '703' ,'SAMPING (P/L)' , 1.00,  null, '7', 7, '3', null, null, 1, 0, null, 'MR', null, 0.0  )
go



-- Lace
INSERT INTO ITEM VALUES('40', '201' ,'FRENCH LACE ' , 1.00,  null, '2', 7, '3', null, null, 1, 0, null, 'MR', null, 0.0  )
go
INSERT INTO ITEM VALUES('40', '202' ,'BEADED LACE' , 1.00,  null, '2', 7, '3', null, null, 1, 0, null, 'MR',  null, 0.0 )
go
INSERT INTO ITEM VALUES('40', '203' ,'COADED LACE' , 1.00,  null, '2', 7, '3', null, null, 1, 0, null, 'MR',  null, 0.0 )
go
INSERT INTO ITEM VALUES('40', '204' ,'SEQUINED LACE' , 1.00,  null, '2', 7, '3', null, null, 1, 0, null, 'MR',  null, 0.0 )
go
INSERT INTO ITEM VALUES('40', '205' ,'STONE LACE' , 1.00,  null, '2', 7, '3', null, null, 1, 0, null, 'MR',  null, 0.0 )
go
INSERT INTO ITEM VALUES('40', '206' ,'EMBROIDERY LACE' , 1.00,  null, '2', 7, '3', null, null, 1, 0, null, 'MR',  null, 0.0 )
go
INSERT INTO ITEM VALUES('40', '207' ,'EXCLUSIVE LACE' , 1.00,  null, '2', 7, '3', null, null, 1, 0, null, 'MR',  null, 0.0 )
go
INSERT INTO ITEM VALUES('40', '208' ,'LACE' , 1.00,  null, '2', 7, '3', null, null, 1, 0, null, 'MR',  null, 0.0 )
go






-- Silk
INSERT INTO ITEM VALUES('40', '21' ,'THAI SILK' , 1.00,  null, '4', 7, '3', null, null, 1, 0, null, 'MR', null, 0.0  )
go
INSERT INTO ITEM VALUES('40', '22' ,'THAI SILK  PATTEN' , 1.00,  null, '4', 7, '3', null, null, 1, 0, null, 'MR', null, 0.0  )
go
INSERT INTO ITEM VALUES('40', '23' ,'DUPION SILK EMBROIDERY' , 1.00,  null, '4', 7, '3', null, null, 1, 0, null, 'MR', null, 0.0  )
go
INSERT INTO ITEM VALUES('40', '24' ,'SILK PRINTED  (G/1)' , 1.00,  null, '4', 7, '3', null, null, 1, 0, null, 'MR', null, 0.0  )
go
INSERT INTO ITEM VALUES('40', '25' ,'SILK PRINTED' , 1.00,  null, '4', 7, '3', null, null, 1, 0, null, 'MR', null, 0.0  )
go
INSERT INTO ITEM VALUES('40', '26' ,'SILK JACQUARD' , 1.00,  null, '4', 7, '3', null, null, 1, 0, null, 'MR', null, 0.0  )
go
INSERT INTO ITEM VALUES('40', '27' ,'SILK SATIN PLAIN' , 1.00,  null, '4', 7, '3', null, null, 1, 0, null, 'MR', null, 0.0  )
go
INSERT INTO ITEM VALUES('40', '28' ,'SILK CHIFFON PLAIN' , 1.00,  null, '4', 7, '3', null, null, 1, 0, null, 'MR', null, 0.0  )
go
INSERT INTO ITEM VALUES('40', '29' ,'SILK CHIFFON PRINTED/STONE ' , 1.00,  null, '4', 7, '3', null, null, 1, 0, null, 'MR', null, 0.0  )
go
INSERT INTO ITEM VALUES('40', '30' ,'SILK CHIFFON PRINTED ' , 1.00,  null, '4', 7, '3', null, null, 1, 0, null, 'MR', null, 0.0  )
go
INSERT INTO ITEM VALUES('40', '31' ,'SILK CHIFFON EMBROIDERY ' , 1.00,  null, '4', 7, '3', null, null, 1, 0, null, 'MR', null, 0.0  )
go
INSERT INTO ITEM VALUES('40', '32' ,'SILK BEADED' , 1.00,  null, '4', 7, '3', null, null, 1, 0, null, 'MR', null, 0.0 )
go
INSERT INTO ITEM VALUES('40', '33' ,'CHIFFON BURN OUT' , 1.00,  null, '4', 7, '3', null, null, 1, 0, null, 'MR', null, 0.0  )
go
INSERT INTO ITEM VALUES('40', '34' ,'ORGANZA SILK' , 1.00,  null, '4', 7, '3', null, null, 1, 0, null, 'MR', null, 0.0  )
go
INSERT INTO ITEM VALUES('40', '35' ,'ORGANZA SILK EMBROIDERY' , 1.00,  null, '4', 7, '3', null, null, 1, 0, null, 'MR', null , 0.0 )
go







-- Polyester 

INSERT INTO ITEM VALUES('40', '1001' ,'CHIFFON STONE' , 1.00,  null, '10', 7, '3', null, null, 1, 0, null, 'MR', null, 0.0  )
go
INSERT INTO ITEM VALUES('40', '1002' ,'CHIFFON SEQUINED' ,  1.00,  null, '10', 7, '3', null, null, 1, 0, null, 'MR', null, 0.0  )
go
INSERT INTO ITEM VALUES('40', '1003' ,'CHIFFON EMBROIDERY' , 1.00,  null, '10', 7, '3', null, null, 1, 0, null, 'MR', null , 0.0 )
go
INSERT INTO ITEM VALUES('40', '1004' ,'GEORGETTE STONE' ,  1.00,  null, '10', 7, '3', null, null, 1, 0, null, 'MR', null, 0.0  )
go
INSERT INTO ITEM VALUES('40', '1005' ,'GEORGETTE SEQUINED' , 1.00,  null, '10', 7, '3', null, null, 1, 0, null, 'MR', null, 0.0  )
go
INSERT INTO ITEM VALUES('40', '1006' ,'CHIFFON  PRINTED' ,  1.00,  null, '10', 7, '3', null, null, 1, 0, null, 'MR', null, 0.0  )
go


-- Mens

INSERT INTO ITEM VALUES('40', '901' ,'SB LINE' , 1.00,  null, '9', 7, '3', null, null, 1, 0, null, 'MR', null, 0.0  )
go
INSERT INTO ITEM VALUES('40', '902' ,'SHANTUNG' ,  1.00,  null, '9', 7, '3', null, null, 1, 0, null, 'MR', null , 0.0 )
go
INSERT INTO ITEM VALUES('40', '903' ,'LINEN' , 1.00,  null, '9', 7, '3', null, null, 1, 0, null, 'MR', null , 0.0 )
go
INSERT INTO ITEM VALUES('40', '904' ,'BRIDAL SATIN' ,  1.00,  null, '9', 7, '3', null, null, 1, 0, null, 'MR', null, 0.0  )
go
INSERT INTO ITEM VALUES('40', '905' ,'MEN’S SUIT' , 1.00,  null, '9', 7, '3', null, null, 1, 0, null, 'MR', null, 0.0  )
go


-- Linning

INSERT INTO ITEM VALUES('40', '1301' ,'LINING' , 1.00,  null, '13', 7, '3', null, null, 1, 0, null, 'MR', null , 0.0 )
go
INSERT INTO ITEM VALUES('40', '1302' ,'SATIN/SILDOLL ' ,  1.00,  null, '13', 7, '3', null, null, 1, 0, null, 'MR', null, 0.0  )
go


-- Package

INSERT INTO ITEM VALUES('40', '1401' ,'(FABRIC 2M+LINING 2M)/SONGKITG' , 1.00,  null, '14', 7, '3', null, null, 1, 0, null, 'MR', null , 0.0 )
go
INSERT INTO ITEM VALUES('40', '1402' ,'(FABRIC 2.5M+LINING 2M)/SONGKET ' ,  1.00,  null, '14', 7, '3', null, null, 1, 0, null, 'MR', null , 0.0 )
go
INSERT INTO ITEM VALUES('40', '1403' ,'(FABRIC 2M + LINING 4M)' , 1.00,  null, '14', 7, '3', null, null, 1, 0, null, 'MR', null , 0.0 )
go
INSERT INTO ITEM VALUES('40', '1404' ,'(FABRIC 2.5M + LINING 4M)' ,  1.00,  null, '14', 7, '3', null, null, 1, 0, null, 'MR', null, 0.0  )
go
INSERT INTO ITEM VALUES('40', '1405' ,'(FABRIC 3M + LINING 4M)' , 1.00,  null, '14', 7, '3', null, null, 1, 0, null, 'MR', null, 0.0  )
go
INSERT INTO ITEM VALUES('40', '1406' ,'(FABRIC 3.5M + LINING 4.5M)' ,  1.00,  null, '14', 7, '3', null, null, 1, 0, null, 'MR', null , 0.0 )
go
INSERT INTO ITEM VALUES('40', '1407' ,'(FABRIC 4M + LINING 4M)' , 1.00,  null, '14', 7, '3', null, null, 1, 0, null, 'MR', null , 0.0 )
go
INSERT INTO ITEM VALUES('40', '1408' ,'(FABRIC 2.5M + LINING 2M)/SONGKET ' ,  1.00,  null, '14', 7, '3', null, null, 1, 0, null, 'MR', null , 0.0 )
go


-- Promotions
insert into promotion values ( '40',	101,	1,   3, 0, 0, 0, 0,    20.00,  0, 0, 0, 0,   0,	 '2001-01-01', '2099-01-01', 'Group Discount',	'EclipsePos.Apps.Operators.GroupDiscount' )
go
insert into promotion values ( '40',	1,		1,   1, 0, 0, 0, 0,    10.00,  0, 0, 0, 0,   0,	 '2001-01-01', '2099-01-01', 'Item markdown ',	'EclipsePos.Apps.Operators.PercentageDiscount' )
go
insert into promotion values ( '40',	2,		1,   1, 0, 0, 0, 0,    15.00,  0, 0, 0, 0,   0,	 '2001-01-01', '2099-01-01', 'Item markdown ',	'EclipsePos.Apps.Operators.PercentageDiscount' )
go
insert into promotion values ( '40',	3,		2,   1, 0, 0, 0, 0,    20.00,  0, 0, 0, 0,   0,	 '2001-01-01', '2099-01-01', 'Item markdown ',	'EclipsePos.Apps.Operators.PercentageDiscount' )
go
insert into promotion values ( '40',	4,		2,   1, 0, 0, 0, 0,    25.00,  0, 0, 0, 0,   0,	 '2001-01-01', '2099-01-01', 'Order discount',	'EclipsePos.Apps.Operators.PercentageDiscount' )
go
insert into promotion values ( '40',	201,	1,   1, 0, 0, 0, 0,    0.00,  0, 0, 0, 0,   0,	 '2001-01-01', '2099-01-01', 'Discount',	'EclipsePos.Apps.Operators.GetDiscountFromInput' )
go
insert into promotion values ( '40',	999,	1,   1, 0, 0, 0, 0,    0.05,  0, 0, 0, 0,   0,	 '2001-01-01', '2099-01-01', 'Rounding Adjustment',	'EclipsePos.Apps.Operators.RoundDownToFactorN' )
go





