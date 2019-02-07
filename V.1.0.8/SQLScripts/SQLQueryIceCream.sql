use possite1
go


delete from menu_panels where config_no = 3
go
delete from pos_key where config_no = 3
go
delete from pos_param where config_no = 3
go
delete from menu_config where config_no = 3
go

delete from ItemGroup where organization_no = '30'

go
 


delete from trans_stock where organization_no = '30'
go

delete from stock_balance where organization_no = '30'
go

delete from item where organization_no='30'
go


delete from promotion where organization_no = '30'
go

delete from customer where organization_no ='30'
go


delete from tax where organization_no ='30'
go

delete from tax_group  where organization_no ='30'
go

delete from employee_role_event where organization_no ='30'
go
delete from employee_roles where organization_no ='30'
go


delete from employee where organization_no ='30'
go




delete from pos where organization_no ='30'
go

delete from retail_store where organization_no ='30'
go



delete from organization where organization_no ='30'
go

delete from pos_config where config_no =3
go


print 'Delete complete'

go


INSERT INTO pos_config
           ([config_no]
			,[name]
           )
  VALUES
           (3
			,'Fast Food Express'
           )

go




 -- Panel Classes
 
 
insert into menu_panels values ( 3, 93, 'Menu', 'EclipsePos.Apps.Views.LeftMenu.LeftMenuView')
 go
 
 insert into menu_panels values ( 3, 94, 'Tender', 'EclipsePos.Apps.Views.LeftMenu.LeftMenuView')
 go
 
 
 insert into menu_panels values ( 3, 95, 'Item Lookup', 'EclipsePos.Apps.Views.LeftMenu.LeftMenuView')
 go
  
 insert into menu_panels values ( 3, 96, 'Manager Tasks', 'EclipsePos.Apps.Views.LeftMenu.LeftMenuView')
 go

insert into menu_panels values ( 3, 97, 'Promotions', 'EclipsePos.Apps.Views.BottomMenu.BottomMenuView')
go

insert into menu_panels values ( 3, 98, 'Discounts', 'EclipsePos.Apps.Views.BottomMenu.BottomMenuView')
go

insert into menu_panels values ( 3, 99, 'Exit/Tools', 'EclipsePos.Apps.Views.LeftMenu.LeftMenuView')
 go

insert into menu_panels values ( 3, 991, 'Panel navigator', 'EclipsePos.Apps.Views.BottomMenu.BottomMenuView')
go

insert into menu_panels values ( 3, 992, 'Cash Bills and Coins', 'EclipsePos.Apps.Views.LeftMenu.LeftMenuView')
 go

insert into menu_panels values ( 3, 993, 'Card Types', 'EclipsePos.Apps.Views.LeftMenu.LeftMenuView')
 go

insert into menu_panels values ( 3, 994, 'Item Groups', 'EclipsePos.Apps.Views.ItemGroup.ItemGroupView')
 go



-- Menus
insert into menu_config values ( 3, 1, 'Item Group', 994, 0, 991)
go
insert into menu_config values ( 3, 2, 'Tender', 992, 0, 991)
go
insert into menu_config values ( 3, 3, 'Menu', 93, 99, 991)
go
insert into menu_config values ( 3, 4, 'Manager', 96, 0, 991)
go
insert into menu_config values ( 3, 5, 'Others', 99, 97, 991)
go








 
 
-- Navigator

insert into pos_key values (3, 991,	'Item Groups',		1,   1,   112,		3,	20,		8,	48,		118,		90,		192,	90,	null,1, 'EclipsePos.Apps.PosEvents.MenuNavigator', 'Item Groups', 'F1')
go
	  				
insert into pos_key values (3, 991,	'Quantity',			1,   91,   113,		3,	140,	8,  48,		118,		91,		192,	91,	null,1, 'EclipsePos.Apps.PosEvents.Quantity', 'Quantity', 'F2')
go

insert into pos_key values (3, 991,	'Viod Item',		1,   92,   114,		3,	260,	8,  48,		118,		93,		192,	92,	null,1, 'EclipsePos.Apps.PosEvents.VoidItem', 'Void Item', 'F3')
go

insert into pos_key values (3, 991,	'Void Sale',		1,   93,   115,		3,	380,	8,  48,		118,		94,		192,	93,	null,1, 'EclipsePos.Apps.PosEvents.VoidSale', 'Void Sale', 'F4')
go

insert into pos_key values (3, 991,	'Cash',				1,   94,   116,		3,	500,	8,  48,		118,		95,		192,	94,	null,1, 'EclipsePos.Apps.PosEvents.CashTender', 'Cash', 'F5')
go
														  				
insert into pos_key values (3, 991,	'Menu',				1,   5,   117,		3,	860,	8,  48,		118,		96,		192,	95,	null,1, 'EclipsePos.Apps.PosEvents.MenuNavigator', 'Menu', 'F8')
go

														  				
														  				
										  				
														  				
												  				
														  				







-- Menu
insert into pos_key values (3, 93,	'Ctrl',		1,   0,  1005,		3, 170,			236,		48, 56, 94,	192,	131184,	null,1, 'EclipsePos.Apps.PosEvents.VoidSale','Void Order','F1')
go
insert into pos_key values (3, 93,	'Ctrl',		1,   0,  1006,		3,  170,		285,		48, 56, 95,	192,	131185,	null,1, 'EclipsePos.Apps.PosEvents.SaveEj', 'Save Order','F2')
go
insert into pos_key values (3, 93,	'Ctrl',		1,   0,  1007,		3,  170,		334,		48, 56, 96,	192,	131186,	null,1,'EclipsePos.Apps.PosEvents.RecallEj', 'Recall Order','F3')
go
insert into pos_key values (3, 93,	'Ctrl',		1,   0,  1008,		3, 170,			432,		48, 56, 97,	192,	131187,	null,1, 'EclipsePos.Apps.PosEvents.ReturnSale','Return Sale','F4')
go
insert into pos_key values (3, 93,	'Ctrl' ,	1,   96,  1009,		3, 170,			40,			48, 56,	90,	192,	131188,	null,1, 'EclipsePos.Apps.PosEvents.MenuNavigator','Manager Tasks','F5')
go
insert into pos_key values (3, 93,	'Ctrl',		1,   99,  1010,		3, 170,			138,		48, 56,	93,	192,	131189,	null,1, 'EclipsePos.Apps.PosEvents.MenuNavigator','Exit/Tools','F6')
go



				 							 		  			


-- Manager
insert into pos_key values (3, 96,	'Ctrl',		1,   0,  1041,		3,  170,		40,		48, 56,		90,	100,	131184,		null,1,'EclipsePos.Apps.PosEvents.PaidIn', 'Paid In','F1')
go

insert into pos_key values (3, 96,	'Ctrl',		1,   0,  1042,		3,  170,		89,		48, 56,		91,	100,	131185,		null,1,'EclipsePos.Apps.PosEvents.PaidOut', 'Paid Out','F2')
go

insert into pos_key values (3, 96,	'Ctrl',		1,   0,	 1043,		3, 170,			138,	48, 56,		92,	50,		131186,		null,1, 'EclipsePos.Apps.PosEvents.TrainingMode', 'Training Mode','F3')
go
     				  		  		
insert into pos_key values (3, 96,	'Ctrl',		1,   1,	 1044,		3,	170,		187,	48,  56,	93,	25,		131187,		null,	1,	'EclipsePos.Apps.PosEvents.TerminalReport', 'X-Report','F4')
go

insert into pos_key values (3, 96,	'Ctrl',		1,   2,	 1045,		3,	170,		236,	48,  56,    94,	0,		131188,		null,	1,	'EclipsePos.Apps.PosEvents.TerminalReport', 'Z-Report','F5')
go







-- Exit
insert into pos_key values (3, 99,		'Ctrl',		1,   0,	1051,		3, 170,			89,			48, 56,0,	0,	131184,	null,1, 'EclipsePos.Apps.PosEvents.Lock','Lock','F1')
go

insert into pos_key values (3, 99,		'Ctrl',		1,   2,	 1052,		3,  170,		40,			48, 56,90,0, 131185,null,1, 'EclipsePos.Apps.PosEvents.LogOff', 'Log Off','F2')
go

insert into pos_key values (3, 99,		'Ctrl',		1,  -1,	 1053,		3,  170,		89,			48, 56,91,50, 131186,null,1, 'EclipsePos.Apps.PosEvents.Exit', 'Shutdown','F3')
go

insert into pos_key values (3, 99,		'Ctrl',		1,   1,	 1054,		3,  170,		89,			48, 56,91,50, 131187,null,1, 'EclipsePos.Apps.PosEvents.SystemManager', 'System Manager','F4')
go








-- Cash tender Notes/Coins
insert into pos_key values (3, 992,	'Ctrl' ,		1,   10000,		1091,	3,	 170,	40,   48,  56, 90,	0, 131184,null,1,'EclipsePos.Apps.PosEvents.MediaValue', '100.00','F1')
go

insert into pos_key values (3, 992,	'Ctrl',			1,   5000,		1092,	3,	170,	89,   48,  56, 91,	0, 131185,null,1,'EclipsePos.Apps.PosEvents.MediaValue', '50.00','F2')
go

insert into pos_key values (3, 992,	'Ctrl',			1,   1000,		1093,	3,	170,	138,  48,  56, 92,	0, 131186,null,1,'EclipsePos.Apps.PosEvents.MediaValue', '10.00','F3')
go

insert into pos_key values (3, 992,	'Ctrl',			1,   500,		1094,	3,	170,	187,  48,  56, 93,	0, 131187,null,1,'EclipsePos.Apps.PosEvents.MediaValue', '5.00','F4')
go

insert into pos_key values (3, 992,	'Ctrl',			1,   200,		1095,	3,	170,	236,  48,  56, 94,	0, 131188,null,1,'EclipsePos.Apps.PosEvents.MediaValue', '2.00','F5')
go

insert into pos_key values (3, 992,	'Ctrl',			1,   100,		1096,	3,	170,	285,  48,  56, 95,	0, 131189,null,1,'EclipsePos.Apps.PosEvents.MediaValue', '1.00','F6')
go

insert into pos_key values (3, 992,	'Ctrl',			1,   50,		1097,	3,	170,	334,  48,  56, 96,	0, 131190,null,1,'EclipsePos.Apps.PosEvents.MediaValue', '.50','F7')
go

insert into pos_key values (3, 992,	'Ctrl',			1,   20,		1098,	3,	170,	383,  48,  56, 97,	0, 131191,null,1,'EclipsePos.Apps.PosEvents.MediaValue', '.20','F8')
go

insert into pos_key values (3, 992,	'Ctrl',			1,   10,		1099,	3,	170,	432,  48,  56, 98,	0, 131192,null,1,'EclipsePos.Apps.PosEvents.MediaValue', '.10','F9')
go



-- Credit card types
insert into pos_key values (3, 993,	'Ctrl' ,		1,   0,		1101,	3,	 170,	40,   48,  56, 90,	0, 131184, 'Visa.gif',	1,	'EclipsePos.Apps.PosEvents.MediaText', 'VISA','F1')
go

insert into pos_key values (3, 993,	'Ctrl',			1,   0,		1102,	3,	170,	89,   48,  56, 91,	0, 131185, 'MasterCard.gif',	1,	'EclipsePos.Apps.PosEvents.MediaText', 'MASTER','F2')
go

insert into pos_key values (3, 993,	'Ctrl',			1,   0,		1103,	3,	170,	138,  48,  56, 92,	0, 131186, 'Amex.gif',	 1,	'EclipsePos.Apps.PosEvents.MediaText', 'AMEX','F3')
go

insert into pos_key values (3, 993,	'Ctrl',			1,   0,		1104,	3,	170,	187,  48,  56, 93,	0, 131187, 'Discover.gif',	1,	'EclipsePos.Apps.PosEvents.MediaText', 'DISCOVER','F4')
go

insert into pos_key values (3, 993,	'Ctrl',			1,   0,		1105,	3,	170,	236,  48,  56, 94,	0, 131188,	null,	1,	'EclipsePos.Apps.PosEvents.MediaText', 'NETS','F5')
go




Print('Creating pos_param')
go

-- Line display
insert into pos_param values (3, 3, 1, 1, 'CustWelcome', 'Welcome', null) 
go



-- Customer receipt print
insert into pos_param values ( 3, 3, 2, 1, 'ReceiptTopMOD1', 'Biz Reg. No. 2567891555 W', null) 
go
insert into pos_param values ( 3, 3, 2, 2, 'ReceiptTopMOD2', 'GST Reg. No. ME-845234-7', null) 
go
insert into pos_param values ( 3, 3, 2, 3, 'ReceiptTopMOD3', '*** Enjoy 5% cash rebates ***', null) 
go
insert into pos_param values ( 3, 3, 2, 4, 'ReceiptTopMOD4', 'When you use POSB Everyday credit card', null) 
go
insert into pos_param values ( 3, 3, 2, 5, 'ReceiptBottomMOD', 'Thank you for shopping', null) 
go
insert into pos_param values ( 3, 3, 2, 6, 'TrxNo', 'TRX: ', null) 
go
insert into pos_param values ( 3, 3, 2, 7, 'PosNo', 'POS: ', null) 
go
insert into pos_param values ( 3, 3, 2, 12, 'ReceiptLogo', 'sample2.bmp', null) 
go
insert into pos_param values ( 3, 3, 2, 13, 'TaxIncludedText', 'GST    7%', null) 
go
insert into pos_param values ( 3, 3, 2, 14, 'TotalItemCountText', 'Item count', null) 
go
insert into pos_param values ( 3, 3, 2, 15, 'ConvertedAltCurrency', 'Converted total', null) 
go
insert into pos_param values ( 3, 3, 2, 16, 'AltCurrencyDescription', 'Alternate Currency Tender', null) 
go
insert into pos_param values ( 3, 3, 2, 17, 'Total', 'TOTAL', null) 
go
insert into pos_param values ( 3, 3, 2, 18, 'BalanceDue', 'Balance Due', null) 
go
insert into pos_param values ( 3, 3, 2, 19, 'CashTender', 'Cash Tender', null) 
go
insert into pos_param values ( 3, 3, 2, 20, 'CheckTender', 'Check Tender', null) 
go
insert into pos_param values ( 3, 3, 2, 21, 'CreditTender', 'Credit Card Tender', null)
go
insert into pos_param values ( 3, 3, 2, 22, 'Change', 'Change Due', null) 
go
insert into pos_param values ( 3, 3, 2, 23, 'TableText', 'Table No.', null) 
go
insert into pos_param values ( 3, 3, 2, 24, 'DebitCardTender', 'Debit Card Tender', null)
go
insert into pos_param values ( 3, 3, 2, 25, 'VoidSaleText', 'Void Sales', null)
go
insert into pos_param values ( 3, 1, 2, 26, 'LogoBitmapWidth', '200', null)
go


-- POS Workbench settings

insert into pos_param values ( 3, 3, 3, 1, 'TotalTax', 'Total Tax', null) 
go
insert into pos_param values ( 3, 3, 3, 2, 'SubTotal', 'SUBTOTAL', null) 
go
insert into pos_param values ( 3, 3, 3, 3, 'Discount', 'Discount', null) 
go
insert into pos_param values ( 3, 3, 3, 4, 'Markout', 'Markout', null) 
go
insert into pos_param values ( 3, 3, 3, 5, 'CashBack', 'Cash Back', null) 
go
insert into pos_param values ( 3, 3, 3, 6, 'PosTag', 'Register', null) 
go
insert into pos_param values ( 3, 3, 3, 7, 'EmpTag', 'Employee', null) 
go
insert into pos_param values ( 3, 3, 3, 8, 'DateTag', 'Time/Date', null) 
go
insert into pos_param values ( 3, 3, 3, 9, 'TrxTag', 'Transaction', null) 
go
insert into pos_param values ( 3, 3, 3, 10, 'QtyHeader', 'Qty', null) 
go
insert into pos_param values ( 3, 3, 3, 11, 'ItemHeader', 'Item', null) 
go
insert into pos_param values ( 3, 3, 3, 12, 'DescHeader', 'Description', null) 
go
insert into pos_param values ( 3, 3, 3, 13, 'PriceHeader', 'Price', null) 
go
insert into pos_param values ( 3, 3, 3, 14, 'ValueHeader', 'Value', null) 
go
insert into pos_param values ( 3, 3, 3, 15, 'SubtotalTag', 'Subtotal', null) 
go
insert into pos_param values ( 3, 3, 3, 16, 'TotalTaxTag', 'Tax', null) 
go
insert into pos_param values ( 3, 3, 3, 17, 'GrandTotal', 'Total', null) 
go
insert into pos_param values ( 3, 3, 3, 18, 'TenderedTag', 'Tendered', null) 
go
insert into pos_param values ( 3, 3, 3, 19, 'LineNumberHeader', 'Ln', null) 
go




-- POS Workbench operator prompt text
insert into pos_param values ( 3, 3, 4, 1, 'CloseDrawer', 'Close Cash Drawer', null) 
go
insert into pos_param values ( 3, 3, 4, 2, 'InsertCheck', 'Insert check', null) 
go
insert into pos_param values ( 3, 3, 4, 3, 'InsertValidation', 'Insert Validation', null) 
go
insert into pos_param values ( 3, 3, 4, 4, 'InsertCCValidation', 'Insert credit card receipt', null) 
go
insert into pos_param values ( 3, 3, 4, 5, 'BadName', 'Bad user ID, press clear', null) 
go
insert into pos_param values ( 3, 3, 4, 6, 'BadPass', 'Invalid password, press clear', null) 
go
insert into pos_param values ( 3, 3, 4, 7, 'InvalidCustomer', 'Invalid customer number, press clear', null) 
go
insert into pos_param values ( 3, 3, 4, 8, 'TooMany', 'Too many logon attempts, press clear', null) 
go
insert into pos_param values ( 3, 3, 4, 9, 'GoodLogin', 'Logon successful', null) 
go
insert into pos_param values ( 3, 3, 4, 10, 'OkText', 'OK', null) 
go
insert into pos_param values ( 3, 3, 4, 11, 'CancelText', 'Cancel', null) 
go
insert into pos_param values ( 3, 3, 4, 12, 'ClearText', 'Clear', null) 
go
insert into pos_param values ( 3, 3, 4, 13, 'InvalidInput', 'Invalid Input, press clear', null) 
go
insert into pos_param values ( 3, 3, 4, 14, 'PromptOpenAmount', 'Enter open amount: ', null) 
go
insert into pos_param values ( 3, 3, 4, 15, 'PromptAmount', 'Enter amount: ', null) 
go
insert into pos_param values ( 3, 3, 4, 16, 'PromptCashBack', 'Cash back amount:', null) 
go
insert into pos_param values ( 3, 3, 4, 17, 'ConfirmOpenAmount', 'Confirm (enter/clear)', null) 
go
insert into pos_param values ( 3, 3, 4, 18, 'RegOpen', 'Register Open', null) 
go
insert into pos_param values ( 3, 3, 4, 19, 'ReturnSale', 'Return Sale', null) 
go
insert into pos_param values ( 3, 3, 4, 20, 'TotalRequired', 'Total Required, press clear', null) 
go
insert into pos_param values ( 3, 3, 4, 21, 'InsufficientFunds', 'Insufficient Funds, press clear', null) 
go
insert into pos_param values ( 3, 3, 4, 23, 'MgrIntervention', 'Manager intervention required', null) 
go
insert into pos_param values ( 3, 3, 4, 24, 'EnterUser', 'Enter User ID: ', null) 
go
insert into pos_param values ( 3, 3, 4, 25, 'EnterPass', 'Enter Password: ', null) 
go
insert into pos_param values ( 3, 3, 4, 26, 'PromptDrawerNo', 'Enter drawer number: ', null) 
go
insert into pos_param values ( 3, 3, 4, 27, 'ConfirmDrawerNo', 'Confirm (enter/clear)', null) 
go
insert into pos_param values ( 3, 3, 4, 28, 'BadDrawerNo', 'Invalid drawer number', null) 
go
insert into pos_param values ( 3, 3, 4, 29, 'BadCheckNo', 'Invalid check number', null) 
go
insert into pos_param values ( 3, 3, 4, 30, 'BadCCNo', 'Invalid credit card', null) 
go
insert into pos_param values ( 3, 3, 4, 31, 'BadExpr', 'Bad expiration date', null) 
go
insert into pos_param values ( 3, 3, 4, 32, 'PromptCustomer', 'Enter Customer Number: ', null) 
go
insert into pos_param values ( 3, 3, 4, 33, 'VoidSale', 'Sale Voided, press enter', null) 
go
insert into pos_param values ( 3, 3, 4, 35, 'AltCurrTenderPrompt', 'Enter alternate currency amount: ', null) 
go
insert into pos_param values ( 3, 3, 4, 37, 'TenderTotal', 'Amount Tendered', null) 
go
insert into pos_param values ( 3, 3, 4, 38, 'TerminalLocked', 'Terminal locked, press enter', null) 
go
insert into pos_param values ( 3, 3, 4, 39, 'EnterItem', 'Enter item', null) 
go
insert into pos_param values ( 3, 3, 4, 40, 'EnterWeight', 'Enter weight', null) 
go
insert into pos_param values ( 3, 3, 4, 41, 'Pause', 'Press enter to continue...', null) 
go
insert into pos_param values ( 3, 3, 4, 42, 'CloseCash', 'Close cash drawer.', null) 
go
insert into pos_param values ( 3, 3, 4, 43, 'RecallFailed', 'Transaction not found', null) 
go
insert into pos_param values ( 3, 3, 4, 44, 'CashLimitExceeded', 'Cash in drawer limit exceeded', null) 
go
insert into pos_param values ( 3, 3, 4, 45, 'EnterNewPrice', 'Enter new price:', null) 
go
insert into pos_param values ( 3, 3, 4, 46, 'PosPrinterFailed', 'PRINTER FAILURE', null) 
go
insert into pos_param values ( 3, 3, 4, 47, 'PosPrinterError', 'Printer Error' , null) 
go
insert into pos_param values ( 3, 3, 4, 48, 'CashDrawerError', 'Cash Drawer Error', null) 
go
insert into pos_param values ( 3, 3, 4, 49, 'PosLineDisplayError', 'Line Display Error', null) 
go
insert into pos_param values ( 3, 3, 4, 50, 'ShutdownKeyNotAllowed', 'Shutdown Key Not Allowed', null) 
go
insert into pos_param values ( 3, 4, 4, 51, 'NavigateButtons', 'true', null) 
go
insert into pos_param values ( 3, 3, 4, 52, 'OperReceiptFont', 'Lucida Sans Typewriter Regular', null) 
go
insert into pos_param values ( 3, 3, 4, 53, 'HeaderFont', 'Courier', null) 
go
insert into pos_param values ( 3, 3, 4, 54, 'HeaderTitleFont', 'Helvetica', null) 
go
insert into pos_param values ( 3, 1, 4, 55, 'OperReceiptFontSize', '15', null) 
go
insert into pos_param values ( 3, 1, 4, 56, 'HeaderFontSize', '12', null) 
go
insert into pos_param values ( 3, 1, 4, 57, 'HeaderTitleFontSize', '14', null) 
go
insert into pos_param values ( 3, 3, 4, 58, 'PromptPosNo', 'Enter POS Number: ', null) 
go
insert into pos_param values ( 3, 3, 4, 59, 'PromptTransNo', 'Enter Transaction Number:', null) 
go
insert into pos_param values ( 3, 3, 4, 60, 'NoSaleCount', 'No sale transactions', null) 
go
insert into pos_param values ( 3, 3, 4, 61, 'TransNo', 'TRANS#', null) 
go
insert into pos_param values ( 3, 3, 4, 62, 'TransType', 'TRANS TYPE', null) 
go
insert into pos_param values ( 3, 3, 4, 63, 'OperLogon', 'Operator logon', null) 
go
insert into pos_param values ( 3, 3, 4, 64, 'OperLogoff', 'Operator logoff', null) 
go
insert into pos_param values ( 3, 3, 4, 65, 'BankTrans', 'Bank transaction', null) 
go
insert into pos_param values ( 3, 3, 4, 66, 'PromptCheckNo', 'Enter check number:', null) 
go
insert into pos_param values ( 3, 3, 4, 67, 'PromptCCNo', 'Enter credit card number:', null) 
go
insert into pos_param values ( 3, 3, 4, 68, 'PromptCCExpr', 'Enter expiration data:', null) 
go
insert into pos_param values ( 3, 3, 4, 69, 'Confirm', 'Press enter', null) 
go
insert into pos_param values ( 3, 3, 4, 85, 'OverMeiaLimit', 'Over Media Limit', null) 
go
insert into pos_param values ( 3, 3, 4, 86, 'UnderMediaLimit', 'Under Media Limit', null) 
go
insert into pos_param values ( 3, 3, 4, 87, 'ReturnSalePrompt', 'Return Sale', null) 
go
insert into pos_param values ( 3, 3, 4, 89, 'SalePrompt', 'Sales Transaction', null) 
go
insert into pos_param values ( 3, 3, 4, 90, 'DineInPrompt', 'Dine In', null) 
go
insert into pos_param values ( 3, 3, 4, 91, 'CarryOutPrompt', 'Take Away', null) 
go
insert into pos_param values ( 3, 3, 4, 92, 'InsufficientUserAuthority', 'Insufficient User Authority', null) 
go
insert into pos_param values ( 3, 3, 4, 93, 'TableNumberPrompt', 'Enter Table no', null) 
go
insert into pos_param values ( 3, 3, 4, 94, 'PromptItemPrice', 'Enter Item Price', null) 
go
insert into pos_param values ( 3, 3, 4, 95, 'PriceChangeNotAllowed', 'Price change not allowed', null) 
go
insert into pos_param values ( 3, 3, 4, 96, 'SelectCustomer', 'Select customer and try again', null) 
go
insert into pos_param values ( 3, 3, 4, 97, 'InsufficientCreditLimit', 'Insufficient credit limit', null) 
go
insert into pos_param values ( 3, 3, 4, 98, 'DebtTender', 'Debt Tender', null) 
go
insert into pos_param values ( 3, 3, 4, 99, 'InvalidFunction', 'Invalid operation', null) 
go
insert into pos_param values ( 3, 3, 4, 100, 'PromptCardName', 'Enter card name and Press Enter', null) 
go
insert into pos_param values ( 3, 3, 4, 101, 'PromptEnterLineNumber', 'Enter Line no.', null) 
go






-- Terminal reports
insert into pos_param values ( 3, 3, 5, 1, 'NonTaxCount', 'Non-Tax transactions', null) 
go
insert into pos_param values ( 3, 3, 5, 2, 'NonTaxAmount', 'Non-Tax amount', null) 
go
insert into pos_param values ( 3, 3, 5, 3, 'TaxCount', 'Tax transactions ', null) 
go
insert into pos_param values ( 3, 3, 5, 4, 'TaxAmount', 'Tax amount ', null) 
go
insert into pos_param values ( 3, 3, 5, 5, 'VoidCount', 'Void transactions', null) 
go
insert into pos_param values ( 3, 3, 5, 6, 'VoidAmount', 'Void amount', null) 
go
insert into pos_param values ( 3, 3, 5, 7, 'ReturnCount', 'Return transactions', null) 
go
insert into pos_param values ( 3, 3, 5, 8, 'ReturnAmount', 'Return amount', null) 
go
insert into pos_param values ( 3, 3, 5, 9, 'CouponCount', 'Coupon transactions', null) 
go
insert into pos_param values ( 3, 3, 5, 10, 'CouponAmount', 'Coupon amount', null) 
go
insert into pos_param values ( 3, 3, 5, 11, 'CreditCount', 'Credit transactions', null) 
go
insert into pos_param values ( 3, 3, 5, 12, 'CreditAmount', 'Credit amount', null) 
go
insert into pos_param values ( 3, 3, 5, 13, 'CheckCount', 'Check transactions', null) 
go
insert into pos_param values ( 3, 3, 5, 14, 'CheckAmount', 'Check amount', null) 
go
insert into pos_param values ( 3, 3, 5, 15, 'RecdOnAcctCount', 'Received on account transactions', null) 
go
insert into pos_param values ( 3, 3, 5, 16, 'RecdOnAcctAmount', 'Received on account amount', null) 
go
insert into pos_param values ( 3, 3, 5, 17, 'PaidInCount', 'Paid in transactions', null) 
go
insert into pos_param values ( 3, 3, 5, 18, 'PaidInAmount', 'Paid in Amount', null) 
go
insert into pos_param values ( 3, 3, 5, 19, 'PaidOutCount', 'Paid out transactions', null) 
go
insert into pos_param values ( 3, 3, 5, 20, 'PaidOutAmount', 'Paid out Amount', null) 
go
insert into pos_param values ( 3, 3, 5, 21, 'CashSalesCount', 'Cash sales transactions', null) 
go
insert into pos_param values ( 3, 3, 5, 22, 'CashSalesAmount', 'Cash sales Amount', null) 
go
insert into pos_param values ( 3, 3, 5, 23, 'CashInDrCount', 'Cash transactions', null) 
go
insert into pos_param values ( 3, 3, 5, 24, 'CashInDrAmount', 'Cash in drawer Amount', null) 
go
insert into pos_param values ( 3, 3, 5, 25, 'LoanCount', 'Loan transactions', null) 
go
insert into pos_param values ( 3, 3, 5, 26, 'LoanAmount', 'Loans amount', null) 
go
insert into pos_param values ( 3, 3, 5, 27, 'PickupCount', 'Pickup transactions', null) 
go
insert into pos_param values ( 3, 3, 5, 28, 'PickupAmount', 'Pickup amount', null) 
go
insert into pos_param values ( 3, 3, 5, 29, 'CashBackCount', 'Cash back transactions', null) 
go
insert into pos_param values ( 3, 3, 5, 30, 'CashBackAmount', 'Cash back Amount', null) 
go
insert into pos_param values ( 3, 3, 5, 31, 'DailyXHeader', 'X-Daily Report', null) 
go
insert into pos_param values ( 3, 3, 5, 32, 'DailyZHeader', 'Z-Daily Report', null)
go
insert into pos_param values ( 3, 3, 5, 33, 'WeeklyXHeader', 'X-Weekly Report', null)
go
insert into pos_param values ( 3, 3, 5, 34, 'WeeklyZHeader', 'Z-Weekly Report', null) 
go
insert into pos_param values ( 3, 3, 5, 35, 'MonthlyXHeader', 'X-Monthly Report', null) 
go
insert into pos_param values ( 3, 3, 5, 36, 'MonthlyZHeader', 'Z-Monthly Report', null) 
go
insert into pos_param values ( 3, 3, 5, 37, 'YearlyXHeader', 'X-Yearly Report', null) 
go
insert into pos_param values ( 3, 3, 5, 38, 'YearlyZHeader', 'Z-Yearly Report', null) 
go
insert into pos_param values ( 3, 3, 5, 39, 'SequenceNo', 'Sequence no', null) 
go
insert into pos_param values ( 3, 3, 5, 40, 'StartDate', 'Start date :', null) 
go
insert into pos_param values ( 3, 3, 5, 41, 'DebtCount', 'Debt transactions', null) 
go
insert into pos_param values ( 3, 3, 5, 42, 'DebtAmount', 'Debt Amount', null) 
go
insert into pos_param values ( 3, 3, 5, 43, 'DebitCardCount', 'Debit card transactions', null) 
go
insert into pos_param values ( 3, 3, 5, 44, 'DebitCardAmount', 'Debit card Amount', null) 
go





-- Micellanious 

insert into pos_param values ( 3, 1, 6, 1, 'CashPickup', '10000.0', null) 
go
insert into pos_param values ( 3, 1, 6, 2, 'MaximumPluLength', '13', null) 
go
insert into pos_param values ( 3, 4, 6, 3, 'PromptForCashBack', 'TRUE', null) 
go
insert into pos_param values ( 3, 4, 6, 4, 'PromptForTableNo', 'FALSE', null) 
go
insert into pos_param values ( 3, 1, 6, 5, 'HomeLeftPanelNo', '90', null) 
go
insert into pos_param values ( 3, 1, 6, 6, 'CashMediaPanelNo', '992', null) 
go
insert into pos_param values ( 3, 1, 6, 7, 'CreditMediaPanelNo', '993', null) 
go
insert into pos_param values ( 3, 1, 6, 8, 'ItemWidth%', '25', null) 
go
insert into pos_param values ( 3, 1, 6, 9, 'DescriptionWidth%', '40', null) 
go
insert into pos_param values ( 3, 1, 6, 10, 'QuantityWidth%', '10', null) 
go
insert into pos_param values ( 3, 1, 6, 11, 'PriceWidth%', '10', null) 
go
insert into pos_param values ( 3, 1, 6, 12, 'AmountWidth%', '15', null) 
go
insert into pos_param values ( 3, 1, 6, 13, 'DefaultTransactionType', '1', null) 
go
insert into pos_param values ( 3, 4, 6, 14, 'ApplyRoundingToCashTender', 'TRUE', null) 
go
insert into pos_param values ( 3, 1, 6, 15, 'AutoRoundDownPromotionNo', '999', null) 
go
insert into pos_param values ( 3, 1, 6, 16, 'LineNumberWidth%', '5', null) 
go
insert into pos_param values ( 3, 1, 6, 17, 'HomeMenuID', '1', null) 
go












-- Organization

insert into organization values ( '30', 'mischief >3 us', 'Jimmys Gelati Pte ltd', 
 'Blk 827', 'Unit #01-130', 'Tempanies Street 81', 'Singapore', 'Singapore', '520 827', 'Singapore',
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
			,'30'
			)

go




insert into employee_role_event values (1,   'VoidSale', '1001', '30')
go
insert into employee_role_event values (2,   'PaidIn', '1001', '30' )
go
insert into employee_role_event values (3,   'PaidOut', '1001', '30' )
go
insert into employee_role_event values (4,   'TrainingMode', '1001', '30' )
go
insert into employee_role_event values (5,   'TerminalReports', '1001', '30')
go
insert into employee_role_event values (6,   'VoidItemLine', '1001', '30')
go
insert into employee_role_event values (7,   'Store', '1001', '30')
go
insert into employee_role_event values (8,   'Recall', '1001', '30')
go
insert into employee_role_event values (9,   'Shutdown', '1001', '30' )
go
insert into employee_role_event values (10,   'LogOff', '1001', '30')
go
insert into employee_role_event values (11,  'ReturnSale', '1001', '30')
go
insert into employee_role_event values (12,   'Discount', '1001', '30')
go
insert into employee_role_event values (13,   'Promotion', '1001', '30')
go
insert into employee_role_event values (14,   'Customer', '1001', '30')
go
insert into employee_role_event values (15,   'SystemManager', '1001', '30')
go
insert into employee_role_event values (16,   'ChangePrice', '1001', '30')
go
insert into employee_role_event values (17,   'ShutDown', '1001', '30')
go
insert into employee_role_event values (18,   'CreditTender', '1001','30' )
go
insert into employee_role_event values (19,  'AltCurrencyTender', '1001', '30' )
go
insert into employee_role_event values (20,  'CheckTender',  '1001', '30')
go
insert into employee_role_event values (21,  'DebtTender',  '1001', '30')
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
           ('30'
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
			,'30'
		   ,'mischief >3 us'
           ,'Blk 827'
           ,'Tampinies Street 81'
           ,'Singapore 520 827'
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




INSERT INTO tax_group VALUES('7','30','Zero' )
go





insert into tax values ( 1, '7', '30', 0, 'GST 0%', 0.0, 0.0) 
go











INSERT into pos VALUES( 105, '30', 2, 0, 'Station A', '8-12-08', '8-12-08' )

go



insert into ItemGroup values ('30', '1', 'Ice Cream' )
go
insert into ItemGroup values ('30', '2', 'Waffle' )
go
insert into ItemGroup values ('30', '3', 'Beverages' )
go




-- Beverages
INSERT INTO ITEM VALUES('30', '101' ,'Expresso' , 2.50,  null, '3', 7, '1', null, null, 1, 0, null, null, null )
go

INSERT INTO ITEM VALUES('30', '102' ,'Americano' , 2.50,  null, '3', 7, '1', null, null, 1, 0, null, null,  null)
go

INSERT INTO ITEM VALUES('30', '103' ,'Latte' , 4.70,  null, '3', 7, '1', null, null, 1, 0, null, null,  null)
go

INSERT INTO ITEM VALUES('30', '104' ,'Cappuccino' , 4.20,  null, '3', 7, '1', null, null, 1, 0, null, null,  null)
go

INSERT INTO ITEM VALUES('30', '105' ,'Affogoto' , 4.50,  null, '3', 7, '1', null, null, 1, 0, null, null,  null)
go

INSERT INTO ITEM VALUES('30', '106' ,'Float' , 4.80,  null, '3', 7, '1', null, null, 1, 0,  null, null, null)
go

INSERT INTO ITEM VALUES('30', '107' ,'Soft drik' , 1.00,  null, '3', 7, '1', null, null, 1, 0, null, null,  null)
go



-- Gelato Ice Cream
INSERT INTO ITEM VALUES('30', '201' ,'Standard Regular' , 3.40,  null, '2', 7, '1', null, null, 1, 0, null, null, null )
go
INSERT INTO ITEM VALUES('30', '202' ,'Standard Large' , 5.20,  null, '2', 7, '1', null, null, 1, 0, null, null, null )
go
INSERT INTO ITEM VALUES('30', '203' ,'Standard Pint' , 12.00,  null, '2', 7, '1', null, null, 1, 0, null, null, null )
go


INSERT INTO ITEM VALUES('30', '211' ,'Classic Regular' , 4.20,  null, '2', 7, '1', null, null, 1, 0, null, null, null )
go
INSERT INTO ITEM VALUES('30', '212' ,'Classic Large' , 6.20,  null, '2', 7, '1', null, null, 1, 0, null, null, null )
go
INSERT INTO ITEM VALUES('30', '213' ,'Classic Pint' , 15.00,  null, '2', 7, '1', null, null, 1, 0, null, null, null )
go


INSERT INTO ITEM VALUES('30', '221' ,'Premium Regular' , 5.40,  null, '2', 7, '1', null, null, 1, 0, null, null, null )
go
INSERT INTO ITEM VALUES('30', '222' ,'Premium Large' , 8.60,  null, '2', 7, '1', null, null, 1, 0, null, null, null )
go
INSERT INTO ITEM VALUES('30', '223' ,'Premium Pint' , 20.00,  null, '2', 7, '1', null, null, 1, 0, null, null, null )
go



-- Waffle

INSERT INTO ITEM VALUES('30', '301' ,'Waffle Standard Regular' , 5.00,  null, '1', 7, '1', null, null, 1, 0, null, null, null )
go
INSERT INTO ITEM VALUES('30', '302' ,'Waffle Standard Large' ,  6.80,  null, '1', 7, '1', null, null, 1, 0, null, null, null )
go

INSERT INTO ITEM VALUES('30', '303' ,'Waffle Classic Regular' , 5.80,  null, '1', 7, '1', null, null, 1, 0, null, null, null )
go
INSERT INTO ITEM VALUES('30', '304' ,'Waffle Classic Large' ,  7.80,  null, '1', 7, '1', null, null, 1, 0, null, null, null )
go

INSERT INTO ITEM VALUES('30', '305' ,'Waffle Premium Regular' , 7.00,  null, '1', 7, '1', null, null, 1, 0, null, null, null )
go
INSERT INTO ITEM VALUES('30', '306' ,'Waffle Premium Large' ,  10.20,  null, '1', 7, '1', null, null, 1, 0, null, null, null )
go


INSERT INTO ITEM VALUES('30', '307' ,'Waffle Standard + Classic' , 7.50,  null, '1', 7, '1', null, null, 1, 0, null, null, null )
go
INSERT INTO ITEM VALUES('30', '308' ,'Waffle Standard + Premium' ,  8.50,  null, '1', 7, '1', null, null, 1, 0, null, null, null )
go
INSERT INTO ITEM VALUES('30', '309' ,'Waffle Premium + Classic' ,  9.00,  null, '1', 7, '1', null, null, 1, 0, null, null, null )
go


-- Promotions




