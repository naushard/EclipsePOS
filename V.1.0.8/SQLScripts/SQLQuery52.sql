use possite

go


print('ok1')
go

delete from menu_panels where config_no =  3
go

delete from pos_param  where config_no = 3
go

delete from pos_key where config_no = 3 
go






INSERT INTO pos_config
           ([config_no]
			,[name]
           )
  VALUES
           (3
			,'Iliciliano Restaurant'
           )

go




Print('Creating pos_param')
go

-- Line display
insert into pos_param values (3, 3, 1, 1, 'CustWelcome', 'Welcome to Il Siciliano', null) 
go



-- Customer receipt print
insert into pos_param values ( 3, 3, 2, 1, 'ReceiptTopMOD1', '', null) 
go
insert into pos_param values ( 3, 3, 2, 2, 'ReceiptTopMOD2', '', null) 
go
insert into pos_param values ( 3, 3, 2, 3, 'ReceiptTopMOD3', '', null) 
go
insert into pos_param values ( 3, 3, 2, 4, 'ReceiptTopMOD4', '', null) 
go
insert into pos_param values ( 3, 3, 2, 5, 'ReceiptBottomMOD', 'Thank you for dining at IL SICILIANO', null) 
go
insert into pos_param values ( 3, 3, 2, 6, 'TrxNo', 'TRX: ', null) 
go
insert into pos_param values ( 3, 3, 2, 7, 'PosNo', 'POS: ', null) 
go
insert into pos_param values ( 3, 3, 2, 12, 'ReceiptLogo', 'Siciliano.bmp', null) 
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









Print (' OK ----------------' )
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
insert into pos_param values ( 3, 3, 4, 47, 'PosPrinterError', 'Printer Error', null) 
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
insert into pos_param values ( 3, 1, 4, 56, 'HeaderFontSize', '20', null) 
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
insert into pos_param values ( 3, 3, 4, 90, 'InsufficientUserAuthority', 'Insufficient User Authority', null) 
go
insert into pos_param values ( 3, 3, 4, 91, 'TableNumberPrompt', 'Enter Table no', null) 
go
insert into pos_param values ( 3, 3, 4, 92, 'PromptItemPrice', 'Enter Item Price', null) 
go
insert into pos_param values ( 3, 3, 4, 93, 'PriceChangeNotAllowed', 'Price change not allowed', null) 
go
insert into pos_param values ( 3, 3, 4, 94, 'SelectCustomer', 'Select customer and try again', null) 
go
insert into pos_param values ( 3, 3, 4, 95, 'InsufficientCreditLimit', 'Insufficient credit limit', null) 
go
insert into pos_param values ( 3, 3, 4, 96, 'DebtTender', 'Debt Tender', null) 
go
insert into pos_param values ( 3, 3, 4, 97, 'InvalidFunction', 'Invalid operation', null) 
go
insert into pos_param values ( 3, 3, 4, 98, 'PromptCardName', 'Enter card name and Press Enter', null) 
go








-- Terminal reports
insert into pos_param values ( 3, 3, 5, 1, 'NonTaxCount', 'Non-tax transactions', null) 
go
insert into pos_param values ( 3, 3, 5, 2, 'NonTaxAmount', 'Non-tax amount', null) 
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
insert into pos_param values ( 3, 3, 5, 18, 'PaidInAmount', 'Paid in amount', null) 
go
insert into pos_param values ( 3, 3, 5, 19, 'PaidOutCount', 'Paid out transactions', null) 
go
insert into pos_param values ( 3, 3, 5, 20, 'PaidOutAmount', 'Paid out amount', null) 
go
insert into pos_param values ( 3, 3, 5, 21, 'CashSalesCount', 'Cash sales transactions', null) 
go
insert into pos_param values ( 3, 3, 5, 22, 'CashSalesAmount', 'Cash sales amount', null) 
go
insert into pos_param values ( 3, 3, 5, 23, 'CashInDrCount', 'Cash transactions', null) 
go
insert into pos_param values ( 3, 3, 5, 24, 'CashInDrAmount', 'Cash in drawer amount', null) 
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
insert into pos_param values ( 3, 3, 5, 30, 'CashBackAmount', 'Cash back amount', null) 
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
insert into pos_param values ( 3, 4, 6, 4, 'PromptForTableNo', 'TRUE', null) 
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



-- Panels 
 
 insert into menu_panels values ( 3, 90, 'Common tasks', 'EclipsePos.Apps.Views.LeftMenu.LeftMenuView')
 go
 insert into menu_panels values ( 3, 91, 'Discounts', 'EclipsePos.Apps.Views.LeftMenu.LeftMenuView')
 go
 insert into menu_panels values ( 3, 92, 'Miscellaneous', 'EclipsePos.Apps.Views.LeftMenu.LeftMenuView')
 go
 insert into menu_panels values ( 3, 93, 'Tender', 'EclipsePos.Apps.Views.LeftMenu.LeftMenuView')
 go
 insert into menu_panels values ( 3, 94, 'Manager tasks', 'EclipsePos.Apps.Views.LeftMenu.LeftMenuView')
 go
 insert into menu_panels values ( 3, 95, 'Main Course', 'EclipsePos.Apps.Views.LeftMenu.LeftMenuView')
 go
 insert into menu_panels values ( 3, 96, 'Alt Currency', 'EclipsePos.Apps.Views.LeftMenu.LeftMenuView')
 go
 insert into menu_panels values ( 3, 97,  'Exit', 'EclipsePos.Apps.Views.LeftMenu.LeftMenuView')
 go
 
 insert into menu_panels values ( 3, 201, 'Kinds Menu', 'EclipsePos.Apps.Views.LeftMenu.LeftMenuView')
 go
 insert into menu_panels values ( 3, 202, 'Sandwiches', 'EclipsePos.Apps.Views.LeftMenu.LeftMenuView')
 go
 insert into menu_panels values ( 3, 203, 'Burgers', 'EclipsePos.Apps.Views.LeftMenu.LeftMenuView')
 go
 insert into menu_panels values ( 3, 204, 'Pizza', 'EclipsePos.Apps.Views.LeftMenu.LeftMenuView')
 go
 insert into menu_panels values ( 3, 205, 'Pasta', 'EclipsePos.Apps.Views.LeftMenu.LeftMenuView')
 go
 insert into menu_panels values ( 3, 206, 'Deserts', 'EclipsePos.Apps.Views.LeftMenu.LeftMenuView')
 go
 insert into menu_panels values ( 3, 207, 'Beverages', 'EclipsePos.Apps.Views.LeftMenu.LeftMenuView')
 go

 insert into menu_panels values ( 3, 991, 'Panel navigator', 'EclipsePos.Apps.Views.BottomMenu.BottomMenuView')
 go
insert into menu_panels values ( 3, 992, 'Cash Bills and Coins', 'EclipsePos.Apps.Views.LeftMenu.LeftMenuView')
 go

insert into menu_panels values ( 3, 993, 'Card Types', 'EclipsePos.Apps.Views.LeftMenu.LeftMenuView')
 go

 


 
 
-- Navigator

insert into pos_key values (3, 991,	'Common Tasks',		1,   90 ,   112,	3,	20,		8,	48,		118,		90,		192,	90,	null,1, 'EclipsePos.Apps.PosEvents.LeftMenuNavigator', 'Common Tasks', 'F1')
go
	
						  				
insert into pos_key values (3, 991,	'Discounts',		1,   91,   113,	3,	140,	8,  48,		118,		91,		192,	91,	null,1, 'EclipsePos.Apps.PosEvents.LeftMenuNavigator', 'Discounts', 'F2')
go

insert into pos_key values (3, 991,	'Micellaneous',		1,   92,   114,	3,	260,	8,  48,		118,		93,		192,	92,	null,1, 'EclipsePos.Apps.PosEvents.LeftMenuNavigator', 'Miscellaneous', 'F3')
go

insert into pos_key values (3, 991,	'Tender',			1,   93,   115,	3,	380,	8,  48,		118,		94,		192,	93,	null,1, 'EclipsePos.Apps.PosEvents.LeftMenuNavigator', 'Tender', 'F4')
go

insert into pos_key values (3, 991,	'Manager',			1,   94,   116,	3,	500,	8,  48,		118,		95,		192,	94,	null,1, 'EclipsePos.Apps.PosEvents.LeftMenuNavigator', 'Manager', 'F5')
go

insert into pos_key values (3, 991,	'Main course',		1,   95,   117,	3,	620,	8,  48,		118,		96,		192,	95,	null,1, 'EclipsePos.Apps.PosEvents.LeftMenuNavigator', 'Main Course', 'F6')
go

insert into pos_key values (3, 991,	'Alt Currency',		1,   96,   118,	3,	740,	8,  48,		118,		97,		192,	96,	null,1, 'EclipsePos.Apps.PosEvents.LeftMenuNavigator', 'Alt Currency', 'F7')
go
														  				
insert into pos_key values (3, 991,	'Exit',				1,   97,   119,	3,	860,	8,  48,		118,		98,		192,	97,	null,1, 'EclipsePos.Apps.PosEvents.LeftMenuNavigator', 'Exit', 'F8')
go

														  				
														  				


-- Common Tasks
insert into pos_key values (3, 90,	'Ctrl',		1,   0, 1001,		3,	170,		40,			48, 56,	90,	192,	131184,	null,1, 'EclipsePos.Apps.PosEvents.Quantity','Quantity','F1')
go
insert into pos_key values (3, 90,	'Ctrl',		1,   0, 1002,		3,  170,		89,			48, 56,	91,	192,	131185,	null,1,'EclipsePos.Apps.PosEvents.SelectTable','Select Table', 'F2')
go
insert into pos_key values (3, 90,	'Ctrl',		1,   0, 1003,		3,	170,		138,		48, 56,	92,	192,	131186,	null,1, 'EclipsePos.Apps.PosEvents.Subtotal','Subtotal','F3')
go
insert into pos_key values (3, 90,	'Ctrl',		1,   0, 1004,		3,	170,		187,		48, 56,	93,	192,	131187,	null,1, 'EclipsePos.Apps.PosEvents.Total','Total','F4')
go
insert into pos_key values (3, 90,	'Ctrl',		1,   0, 1005,		3,	170,		236,		48, 56, 94,	192,	131188,	null,1, 'EclipsePos.Apps.PosEvents.ItemVoid','Void Item','F5')
go
insert into pos_key values (3, 90,	'Ctrl',		1,   0, 1006,		3, 170,			285,		48, 56, 95,	192,	131189,	null,1, 'EclipsePos.Apps.PosEvents.VoidSale','Void Sale','F6')
go
insert into pos_key values (3, 90,	'Ctrl',		1,   0, 1007,		3,  170,		334,		48, 56, 96,	192,	131190,	null,1, 'EclipsePos.Apps.PosEvents.SaveEj', 'Save Invoice','F7')
go
insert into pos_key values (3, 90,	'Ctrl',		1,   0, 1008,		3, 170,			432,		48, 56, 97,	192,	131191,	null,1, 'EclipsePos.Apps.PosEvents.ReturnSale','Return Sale','F8')
go
insert into pos_key values (3, 90,	'Ctrl',		1,   0, 1009,		3, 170,			481,		48, 56, 98,	192,	131192,	null,1, 'EclipsePos.Apps.PosEvents.Customer','Customer','F9')
go


-- Discounts 
insert into pos_key values (3, 91,		'Ctrl',		1,   1,	1011,		3,  170,	40,			48, 56,	90,	192,	131184,	null,1, 'EclipsePos.Apps.PosEvents.ItemMarkdown','Item Disc 10%','F1')
go
insert into pos_key values (3, 91,		'Ctrl',		1,   2,	1012,		3,  170,	89,			48, 56,	91,	192,	131185,	null,1, 'EclipsePos.Apps.PosEvents.ItemMarkdown','Item Disc 20%','F2')
go
insert into pos_key values (3, 91,		'Ctrl',		1,   3,	1013,		3,  170,	138,		48, 56,	92,	192,	131186,	null,1, 'EclipsePos.Apps.PosEvents.ItemMarkdown','Item Disc 30%','F3')
go
insert into pos_key values (3, 91,		'Ctrl',		1,   4,	1014,		3,  170,	187,		48, 56,	93,	192,	131187,	null,1, 'EclipsePos.Apps.PosEvents.ItemMarkdown','Item Disc 40%','F4')
go
insert into pos_key values (3, 91,		'Ctrl',		1,   5,	1015,		3,  170,	236,		48, 56,	94,	192,	131188,	null,1, 'EclipsePos.Apps.PosEvents.ItemMarkdown','Item Disc 50%','F5')
go


-- Miscellaneous

insert into pos_key values (3, 92,		'Ctrl',		1,   0,		1021,		3,	170,	40,			48,		56,     90,		0,		131184,		null,	1,	'EclipsePos.Apps.PosEvents.PriceOverride', 'Change Price','F1')
go
insert into pos_key values (3, 92,		'Ctrl',		1,	 1,		1022,		3,  170,	89,			48,		56,		91,		50,		131185,		null,	1,	'EclipsePos.Apps.PosEvents.ExecScript', 'Calculator','F2')
go
insert into pos_key values (3, 92,		'Ctrl',		1,	 2,		1023,		3,  170,	138,		48,		56,		92,		50,		131186,		null,	1,	'EclipsePos.Apps.PosEvents.ExecScript', 'Notepad','F3')
go
insert into pos_key values (3, 92,		'Ctrl',		1,   0,		1024,		3, 170,		187,		48,		56,		93,		192,	131187,		null,	1, 'EclipsePos.Apps.PosEvents.ReceiveOnAccount', 'Receive on Acc', 'F5')
go
insert into pos_key values (3, 92,		'Ctrl',		1,   0,		1025,		3, 170,		236,		48,		56,		94,		192,	131188,		null,	1, 'EclipsePos.Apps.PosEvents.FreeText', 'Free text', 'F6')
go






-- Tender
insert into pos_key values (3, 93,		'Ctrl' ,	1,   0,  1031,		3, 170,			40,		48, 56,	90,	192,	131184,	null,1, 'EclipsePos.Apps.PosEvents.CashTender','Cash ','F1')
go
insert into pos_key values (3, 93,		'Ctrl',		1,   0,  1032,		3, 170,			89,		48, 56, 91,	192,	131185,	null,1, 'EclipsePos.Apps.PosEvents.CheckTender','Check ','F2')
go
insert into pos_key values (3, 93,		'Ctrl',		1,   0,  1033,		3, 170,			138,	48, 56,	92,	192,	131186,	null,1, 'EclipsePos.Apps.PosEvents.CreditTender','Credit Card ','F3')
go
insert into pos_key values (3, 93,		'Ctrl',		1,   0,  1034,		3, 170,			187,	48, 56,	92,	192,	131187,	null,1, 'EclipsePos.Apps.PosEvents.DebtTender','Debt','F4')
go


				 							 		  			


-- Manager
insert into pos_key values (3, 94,	'Ctrl',		1,   0,  1041,		3,  170,		40,		48, 56,		90,	100,	131184,		null,1,'EclipsePos.Apps.PosEvents.PaidIn', 'Paid In','F1')
go
insert into pos_key values (3, 94,	'Ctrl',		1,   0,  1042,		3,  170,		89,		48, 56,		91,	100,	131185,		null,1,'EclipsePos.Apps.PosEvents.PaidOut', 'Paid Out','F2')
go
insert into pos_key values (3, 94,	'Ctrl',		1,   0,	 1043,		3, 170,			138,	48, 56,		92,	50,		131186,		null,1, 'EclipsePos.Apps.PosEvents.TrainingMode', 'Training Mode','F3')
go
insert into pos_key values (3, 94,	'Ctrl',		1,   1,	 1044,		3,	170,		187,	48,  56,	93,	25,		131187,		null,	1,	'EclipsePos.Apps.PosEvents.TerminalReport', 'X-Report','F4')
go
insert into pos_key values (3, 94,	'Ctrl',		1,   2,	 1045,		3,	170,		236,	48,  56,    94,	0,		131188,		null,	1,	'EclipsePos.Apps.PosEvents.TerminalReport', 'Z-Report','F5')
go





-- Exit
insert into pos_key values (3, 97,		'Ctrl',		1,   0,	1051,		3, 170,			89,			48, 56,0,	0,	131184,	null,1, 'EclipsePos.Apps.PosEvents.Lock','Lock','F1')
go
insert into pos_key values (3, 97,		'Ctrl',		1,   2,	 1052,		3,  170,		40,		48, 56,90,0, 131185,null,1, 'EclipsePos.Apps.PosEvents.LogOff', 'Log Off','F2')
go
insert into pos_key values (3, 97,		'Ctrl',		1,  -1,	 1053,		3,  170,		89,		48, 56,91,50, 131186,null,0, 'EclipsePos.Apps.PosEvents.Exit', 'Shutdown','F3')
go
insert into pos_key values (3, 97,		'Ctrl',		1,  -1,	 1054,		3,  170,		89,		48, 56,91,50, 131187,null,1, 'EclipsePos.Apps.PosEvents.SystemManager', 'System Manager','F4')
go



-- Main course
insert into pos_key values (3, 95,	'Ctrl',		1,   201,		1061,		3, 170,			40,		48, 56,90,	192,	131184,	null,1, 'EclipsePos.Apps.PosEvents.LeftMenuNavigator','Kids menu','F1')
go
insert into pos_key values (3, 95,	'Ctrl',		1,   202,		1062,		3, 170,			89,		48, 56,91,	192,	131185,	null,1, 'EclipsePos.Apps.PosEvents.LeftMenuNavigator','Sandwiches','F2')
go
insert into pos_key values (3, 95,	'Ctrl',		1,   203,		1063,		3, 170,			138,	48, 56,92,	192,	131186,	null,1, 'EclipsePos.Apps.PosEvents.LeftMenuNavigator','Burgers','F3')
go
insert into pos_key values (3, 95,	'Ctrl',		1,   204,		1064,		3, 170,			138,	48, 56,92,	192,	131187,	null,1, 'EclipsePos.Apps.PosEvents.LeftMenuNavigator', 'Pizza', 'F4')
go
insert into pos_key values (3, 95,	'Ctrl',		1,   205,		1065,		3, 170,			138,	48, 56,92,	192,	131188,	null,1, 'EclipsePos.Apps.PosEvents.LeftMenuNavigator','Pasta','F5')
go
insert into pos_key values (3, 95,	'Ctrl',		1,   206,		1066,		3, 170,			138,	48, 56,92,	192,	131189,	null,1, 'EclipsePos.Apps.PosEvents.LeftMenuNavigator', 'Deserts', 'F6')
go
insert into pos_key values (3, 95,	'Ctrl',		1,   207,		1067,		3, 170,			138,	48, 56,92,	192,	131190,	null,1, 'EclipsePos.Apps.PosEvents.LeftMenuNavigator', 'Beverages', 'F7')
go
													  		  


-- Help
		  			
-- Alternate currency entry
insert into pos_key values (3, 96,	'Ctrl' ,		1,   1,		1071,	3,	 170,	40,   48,  56, 90,	0, 131184,null,1,'EclipsePos.Apps.PosEvents.AltCurrTender', 'US Dollar','F1')
go
insert into pos_key values (3, 96,	'Ctrl',			1,   2,		1072,	3,	170,	89,   48,  56, 91,	0, 131185,null,1,'EclipsePos.Apps.PosEvents.AltCurrTender', 'Euro','F2')
go
insert into pos_key values (3, 96,	'Ctrl',			1,   3,		1073,	3,	170,	138,  48,  56, 92,	0, 131186,null,1,'EclipsePos.Apps.PosEvents.AltCurrTender', 'Sterling Pound','F3')
go
insert into pos_key values (3, 96,	'Ctrl',			1,   4,		1074,	3,	170,	187,  48,  56, 93,	0, 131187,null,1,'EclipsePos.Apps.PosEvents.AltCurrTender', 'Aust. Dollar','F4')
go
insert into pos_key values (3, 96,	'Ctrl',			1,   5,		1075,	3,	170,	236,  48,  56, 94,	25, 131188,null,1,'EclipsePos.Apps.PosEvents.AltCurrTender', 'HK Dollar','F5')
go
insert into pos_key values (3, 96,	'Ctrl',			1,   6,		1076,	3,	170,	285,  48,  56, 95,	25, 131189,null,1,'EclipsePos.Apps.PosEvents.AltCurrTender', 'Yen','F6')
go




-- Cash tender Notes/Coins
insert into pos_key values (3, 992,	'Ctrl' ,		1,   10000,		2071,	3,	 170,	40,   48,  56, 90,	0, 131184,null,1,'EclipsePos.Apps.PosEvents.MediaValue', '100.00','F1')
go

insert into pos_key values (3, 992,	'Ctrl',			1,   5000,		2172,	3,	170,	89,   48,  56, 91,	0, 131185,null,1,'EclipsePos.Apps.PosEvents.MediaValue', '50.00','F2')
go

insert into pos_key values (3, 992,	'Ctrl',			1,   1000,		2073,	3,	170,	138,  48,  56, 92,	0, 131186,null,1,'EclipsePos.Apps.PosEvents.MediaValue', '10.00','F3')
go

insert into pos_key values (3, 992,	'Ctrl',			1,   500,		2074,	3,	170,	187,  48,  56, 93,	0, 131187,null,1,'EclipsePos.Apps.PosEvents.MediaValue', '5.00','F4')
go

insert into pos_key values (3, 992,	'Ctrl',			1,   200,		2075,	3,	170,	236,  48,  56, 94,	0, 131188,null,1,'EclipsePos.Apps.PosEvents.MediaValue', '2.00','F5')
go

insert into pos_key values (3, 992,	'Ctrl',			1,   100,		2076,	3,	170,	285,  48,  56, 95,	0, 131189,null,1,'EclipsePos.Apps.PosEvents.MediaValue', '1.00','F6')
go

insert into pos_key values (3, 992,	'Ctrl',			1,   50,		2077,	3,	170,	334,  48,  56, 96,	0, 131190,null,1,'EclipsePos.Apps.PosEvents.MediaValue', '.50','F7')
go

insert into pos_key values (3, 992,	'Ctrl',			1,   20,		2078,	3,	170,	383,  48,  56, 97,	0, 131191,null,1,'EclipsePos.Apps.PosEvents.MediaValue', '.20','F8')
go

insert into pos_key values (3, 992,	'Ctrl',			1,   10,		2079,	3,	170,	432,  48,  56, 98,	0, 131192,null,1,'EclipsePos.Apps.PosEvents.MediaValue', '.10','F9')
go



-- Credit card types
insert into pos_key values (3, 993,	'Ctrl' ,		1,   0,		2081,	3,	 170,	40,   48,  56, 90,	0, 131184,	'Visa.gif',	1,	'EclipsePos.Apps.PosEvents.MediaText', 'VISA','F1')
go

insert into pos_key values (3, 993,	'Ctrl',			1,   0,		2082,	3,	170,	89,   48,  56, 91,	0, 131185,	'MasterCard.gif',	1,	'EclipsePos.Apps.PosEvents.MediaText', 'MASTER','F2')
go

insert into pos_key values (3, 993,	'Ctrl',			1,   0,		2083,	3,	170,	138,  48,  56, 92,	0, 131186,	'Amex.gif',	1,	'EclipsePos.Apps.PosEvents.MediaText', 'AMEX','F3')
go

insert into pos_key values (3, 993,	'Ctrl',			1,   0,		2084,	3,	170,	187,  48,  56, 93,	0, 131187,	'Discover.gif',	1,	'EclipsePos.Apps.PosEvents.MediaText', 'DISCOVER','F4')
go

insert into pos_key values (3, 993,	'Ctrl',			1,   0,		2085,	3,	170,	236,  48,  56, 94,	0, 131188,	null,	1,	'EclipsePos.Apps.PosEvents.MediaText', 'NETS','F5')
go

		



print 'delete stage 2 OK'
go


insert into organization values ( '20', 'IL SICILIANO', '104 Faber Drive', 
 'Faber Hills', 'Singapore 129412', ' ', '', ' ', '', '',
 '89988888', '09881111', 'Mr. XYZ', 'SGD', '200333737838G',   22, null, 0)   

go



-- employee roles



INSERT INTO employee_roles
           ([role_id]
			,[role_name]
           ,[organization_no])
     VALUES
           (
			'1'
			,'Returant Manager'
			,'20'
			)

go



insert into employee_role_event values (1,   'VoidSale', '1', '20')
go
insert into employee_role_event values (2,   'PaidIn', '1', '20' )
go
insert into employee_role_event values (3,   'PaidOut', '1', '20' )
go
insert into employee_role_event values (4,   'TrainingMode', '1', '20' )
go
insert into employee_role_event values (5,   'TerminalReports', '1', '20')
go
insert into employee_role_event values (6,   'VoidItemLine', '1', '20')
go
insert into employee_role_event values (7,   'Store', '1', '20')
go
insert into employee_role_event values (8,   'Recall', '1', '20')
go
insert into employee_role_event values (9,   'Shutdown', '1', '20' )
go
insert into employee_role_event values (10,   'LogOff', '1', '20')
go
insert into employee_role_event values (11,  'ReturnSale', '1', '20')
go
insert into employee_role_event values (12,   'Discount', '1', '20')
go
insert into employee_role_event values (13,   'Promotion', '1', '20')
go
insert into employee_role_event values (14,   'Customer', '1', '20')
go
insert into employee_role_event values (15,   'SystemManager', '1', '20')
go
insert into employee_role_event values (16,   'ChangePrice', '1', '20')
go
insert into employee_role_event values (17,   'ShutDown', '1', '20')
go
insert into employee_role_event values (18,   'CreditTender', '1','20' )
go
insert into employee_role_event values (19,  'AltCurrencyTender', '1', '20' )
go
insert into employee_role_event values (20,  'CheckTender',  '1', '20')
go
insert into employee_role_event values (21,  'DebtTender',  '1', '20')
go






-- employee
--insert into employee values (100, 101, 1, 'Eclipse', 'ES', null, null, 0 )
--go 
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
           ('20'
           ,'Test '
           ,'200'
           ,'3644A684F98EA8FE223C713B77189A77'
           ,'1'
           ,'Eclipse'
           ,'ES'
           ,null
           ,null
           ,0)
 
go




INSERT INTO Retail_Store
           
     VALUES
           ('20'
			,'20'
		   ,'Il Siciliano Pte Ltd'
           ,'104 Faber Drive'
           ,'Faber Hills'
           ,'Singapore 129412'
           ,'Co. Reg. No.: 201109156W'
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



INSERT INTO tax_group  VALUES ('20' ,'20','Zero GST')
go



insert into tax values ( 1, '20', '20', 1, 'GST 0%', 0.0, 0.0) 





INSERT into pos VALUES( 125, '20', 20, 0, 'Counter 01', '8-12-08', '8-12-08' )

go

INSERT into pos VALUES( 130, '20', 20, 0, 'Counter 02', '8-12-08', '8-12-08' )

go


insert into table_group values( '20', 20, 1, 'Main Dining Room')
go



insert into table_details values( '20', 20, 1, '1', 0, 1, 4, '..\..\Images\A6.ico')
go
insert into table_details values( '20', 20, 1, '2', 0, 2, 4, '..\..\Images\A6.ico')
go
insert into table_details values( '20', 20, 1, '3', 0, 3, 4, '..\..\Images\A6.ico')
go
insert into table_details values( '20', 20, 1, '4', 0, 4, 4, '..\..\Images\A6.ico')
go
insert into table_details values( '20', 20, 1, '5', 0, 5, 4, '..\..\Images\A6.ico')
go
insert into table_details values( '20', 20, 1, '6', 0, 6, 4, '..\..\Images\A6.ico')
go
insert into table_details values( '20', 20, 1, '7', 0, 7, 4, '..\..\Images\A6.ico')
go
insert into table_details values( '20', 20, 1, '8', 0, 8, 4, '..\..\Images\A6.ico')
go

insert into table_details values( '20', 20, 1, '11', 1, 1, 4, '..\..\Images\A6.ico')
go
insert into table_details values( '20', 20, 1, '12', 2, 1, 4, '..\..\Images\A6.ico')
go
insert into table_details values( '20', 20, 1, '13', 3, 1, 4, '..\..\Images\A6.ico')
go
insert into table_details values( '20', 20, 1, '14', 4, 1, 4, '..\..\Images\A6.ico')
go
insert into table_details values( '20', 20, 1, '15', 5, 1, 4, '..\..\Images\A6.ico')
go
insert into table_details values( '20', 20, 1, '16', 6, 1, 4, '..\..\Images\A6.ico')
go
insert into table_details values( '20', 20, 1, '17', 7, 1, 4, '..\..\Images\A6.ico')
go


insert into table_details values( '20', 20, 1, '21', 2, 3, 7, '..\..\Images\A7.ico')
go
insert into table_details values( '20', 20, 1, '22', 2, 5, 7, '..\..\Images\A7.ico')
go
insert into table_details values( '20', 20, 1, '23', 2, 7, 7, '..\..\Images\A7.ico')
go
insert into table_details values( '20', 20, 1, '24', 4, 3, 7, '..\..\Images\A7.ico')
go
insert into table_details values( '20', 20, 1, '25', 4, 5, 7, '..\..\Images\A7.ico')
go
insert into table_details values( '20', 20, 1, '26', 4, 7, 7, '..\..\Images\A7.ico')
go
insert into table_details values( '20', 20, 1, '27', 6, 3, 7, '..\..\Images\A7.ico')
go
insert into table_details values( '20', 20, 1, '28', 6, 5, 7, '..\..\Images\A7.ico')
go
insert into table_details values( '20', 20, 1, '29', 6, 7, 7, '..\..\Images\A7.ico')
go








-- Kids Manu
insert into pos_key values (3, 201,	'Ctrl',		1,   8001,		2001,		3, 170,			40,		48, 56,90,	192,	131184,	null,1, 'EclipsePos.Apps.PosEvents.Plu','Kids Burger','F1')
go
insert into pos_key values (3, 201,	'Ctrl',		1,   8002,		2002,		3, 170,			89,		48, 56,91,	192,	131185,	null,1, 'EclipsePos.Apps.PosEvents.Plu','Grilled cheese','F2')
go
insert into pos_key values (3, 201,	'Ctrl',		1,   8003,		2003,		3, 170,			138,	48, 56,92,	192,	131186,	null,1, 'EclipsePos.Apps.PosEvents.Plu','Chicken fingers','F3')
go

-- Sandwiches  
insert into pos_key values (3, 202,	'Ctrl',		1,   2001,		2011,		3, 170,			138,	48, 56,92,	192,	131184,	null,1, 'EclipsePos.Apps.PosEvents.Plu', 'Chx Fillet sandwiches', 'F1')
go
insert into pos_key values (3, 202,	'Ctrl',		1,   2002,		2012,		3, 170,			138,	48, 56,92,	192,	131185,	null,1, 'EclipsePos.Apps.PosEvents.Plu','Tuna melt sandwiches','F2')
go
insert into pos_key values (3, 202,	'Ctrl',		1,   2003,		2013,		3, 170,			138,	48, 56,92,	192,	131186,	null,1, 'EclipsePos.Apps.PosEvents.Plu', 'Stk cheese sandwitches', 'F3')
go
														  				


-- Burgers
insert into pos_key values (3, 203,	'Ctrl',		1,   3001,		2021,		3, 170,			138,	48, 56,92,	192,	131184,	'\\Pictures\burger2', 1, 'EclipsePos.Apps.PosEvents.Plu', 'Supreme chx burger', 'F1')
go
  
insert into pos_key values (3, 203,	'Ctrl',		1,   3002,		2022,		3, 170,			138,	48, 56,92,	192,	131185,	'\\Pictures\\Food - Burger 1.bmp', 1, 'EclipsePos.Apps.PosEvents.Plu','Cheese burger','F2')
go
   
insert into pos_key values (3, 203,	'Ctrl',		1,   3003,		2023,		3, 170,			138,	48, 56,92,	192,	131186,	null, 1, 'EclipsePos.Apps.PosEvents.Plu', 'Vegi burger', 'F3')
go




-- Pizza  
insert into pos_key values (3, 204,	'Ctrl',		1,   4001,		2031,		3, 170,			138,	48, 56,92,	192,	131184,	null,1, 'EclipsePos.Apps.PosEvents.Plu', 'Slice of todays pizza', 'F1')
go
  
insert into pos_key values (3, 204,	'Ctrl',		1,   4002,		2032,		3, 170,			138,	48, 56,92,	192,	131185,	null,1, 'EclipsePos.Apps.PosEvents.Plu','Pepperoni lovers','F2')
go
   
insert into pos_key values (3, 204,	'Ctrl',		1,   4003,		2033,		3, 170,			138,	48, 56,92,	192,	131186,	null,1, 'EclipsePos.Apps.PosEvents.Plu', 'Hawaian deluxe', 'F3')
go




-- Pasta  
insert into pos_key values (3, 205,	'Ctrl',		1,   5001,		2041,		3, 170,			138,	48, 56,92,	192,	131184,	null,1, 'EclipsePos.Apps.PosEvents.Plu', 'Pasta Primavera', 'F1')
go
  
insert into pos_key values (3, 205,	'Ctrl',		1,   5002,		2042,		3, 170,			138,	48, 56,92,	192,	131185,	null,1, 'EclipsePos.Apps.PosEvents.Plu','Marinara Lasagna','F2')
go
   
		

-- Deserts  
insert into pos_key values (3, 206,	'Ctrl',		1,   6001,		2051,		3, 170,			138,	48, 56,92,	192,	131184,	null,1, 'EclipsePos.Apps.PosEvents.Plu', 'Chocolate cake', 'F1')
go
  
insert into pos_key values (3, 206,	'Ctrl',		1,   6002,		2052,		3, 170,			138,	48, 56,92,	192,	131185,	null,1, 'EclipsePos.Apps.PosEvents.Plu','Starwbery short cake','F2')
go
   
insert into pos_key values (3, 206,	'Ctrl',		1,   6003,		2053,		3, 170,			138,	48, 56,92,	192,	131186,	null,1, 'EclipsePos.Apps.PosEvents.Plu', 'Sandae', 'F3')
go


	

-- Beverages  
insert into pos_key values (3, 207,	'Ctrl',		1,   7001,		2061,		3, 170,			138,	48, 56,92,	192,	131184,	null,1, 'EclipsePos.Apps.PosEvents.Plu', 'Coca cola', 'F1')
go
  
insert into pos_key values (3, 207,	'Ctrl',		1,   7002,		2062,		3, 170,			138,	48, 56,92,	192,	131185,	null,1, 'EclipsePos.Apps.PosEvents.Plu','Srite','F2')
go
   
insert into pos_key values (3, 207,	'Ctrl',		1,   7003,		2063,		3, 170,			138,	48, 56,92,	192,	131186,	null,1, 'EclipsePos.Apps.PosEvents.Plu', 'Sunkist', 'F3')
go

insert into pos_key values (3, 207,	'Ctrl',		1,   7004,		2064,		3, 170,			138,	48, 56,92,	192,	131187,	null,1, 'EclipsePos.Apps.PosEvents.Plu', 'Bottle water', 'F4')
go

insert into pos_key values (3, 207,	'Ctrl',		1,   7005,		2065,		3, 170,			138,	48, 56,92,	192,	131188,	null,1, 'EclipsePos.Apps.PosEvents.Plu', 'Ice tea', 'F5')
go









-- Coffee Dock
INSERT INTO ITEM VALUES('20', '101' ,'Coffee' , 2.40,  null, null, 20, '1', null, null, 1, 0,  null, null, '101')
go

INSERT INTO ITEM VALUES('20', '102' ,'Expresso' ,2.70,  null, null, 20, '1', null, null, 1, 0,  null, null, '102')
go

INSERT INTO ITEM VALUES('20', '103' ,'Double Expresso' ,2.0,  null, null, 20, '1', null, null, 1, 0, null, null,  '103')
go

INSERT INTO ITEM VALUES('20', '104' ,'Decaf Expresso' , 2.40,  null, null, 20, '1', null, null, 1, 0,  null, null, '104')
go

INSERT INTO ITEM VALUES('20', '105' ,'Cappucino' ,2.70,  null, null, 20, '1', null, null, 1, 0,  null, null, '105')
go

INSERT INTO ITEM VALUES('20', '106' ,'Cappucino Double' ,2.0,  null, null, 20, '1', null, null, 1, 0, null, null,  '106')
go

INSERT INTO ITEM VALUES('20', '107' ,'Café Latte' ,2.0,  null, null, 20, '1', null, null, 1, 0, null, null,  '107')
go

INSERT INTO ITEM VALUES('20', '108' ,'Macchiato' ,2.0,  null, null, 20, '1', null, null, 1, 0, null, null,  '108')
go

INSERT INTO ITEM VALUES('20', '109' ,'Americano' ,2.0,  null, null, 20, '1', null, null, 1, 0, null, null,  '109')
go

INSERT INTO ITEM VALUES('20', '110' ,'Iced Coffee' ,2.0,  null, null, 20, '1', null, null, 1, 0, null, null,  '110')
go

INSERT INTO ITEM VALUES('20', '111' ,'Iced Latte' ,2.0,  null, null, 20, '1', null, null, 1, 0, null, null,  '111')
go





-- Tea Dock
INSERT INTO ITEM VALUES('20', '131' ,'English Breakfast' , 1.40,  null, null, 20, '1', null, null, 1, 0,  null, null, '131')
go

INSERT INTO ITEM VALUES('20', '132' ,'Chamomile' ,1.70,  null, null, 20, '1', null, null, 1, 0,  null, null, '132')
go

INSERT INTO ITEM VALUES('20', '133' ,'Earl Grey' ,1.0,  null, null, 20, '1', null, null, 1, 0, null, null,  '133')
go

INSERT INTO ITEM VALUES('20', '134' ,'Jasmine' , 1.40,  null, null, 20, '1', null, null, 1, 0,  null, null, '134')
go

INSERT INTO ITEM VALUES('20', '135' ,'Peppermint' ,1.70,  null, null, 20, '1', null, null, 1, 0,  null, null, '135')
go

INSERT INTO ITEM VALUES('20', '136' ,'Hot Chocolate' ,1.0,  null, null, 20, '1', null, null, 1, 0, null, null,  '136')
go



-- Mocktails
INSERT INTO ITEM VALUES('20', '161' ,'Supreme chx burger' , 2.40,  null, null, 20, '1', null, null, 1, 0,  null, null, '3001')
go

INSERT INTO ITEM VALUES('20', '3002' ,'Cheese burger' ,2.70,  null, null, 20, '1', null, null, 1, 0,  null, null, '3002')
go

INSERT INTO ITEM VALUES('20', '3003' ,'Vegi burger' ,2.0,  null, null, 20, '1', null, null, 1, 0, null, null,  '3003')
go


-- Pizza

INSERT INTO ITEM VALUES('20', '4001' ,'Slice of todays pizza' , 12.40,  null, null, 20, '1', null, null, 1, 0,  null, null, '4001')
go

INSERT INTO ITEM VALUES('20', '4002' ,'Pepperoni lovers' ,12.70,  null, null, 20, '1', null, null, 1, 0,  null, null, '4002')
go

INSERT INTO ITEM VALUES('20', '4003' ,'Hawaian deluxe' ,14.0,  null, null, 20, '1', null, null, 1, 0,  null, null, '4003')
go


-- Pasta
INSERT INTO ITEM VALUES('20', '5001' ,'Pasta primavera' , 4.50,  null, null,20, '1', null, null, 1, 0,  null, null, '5001')
go

INSERT INTO ITEM VALUES('20', '5002' ,'Marinara Lasagna' ,4.20,  null, null, 20, '1', null, null, 1, 0,  null, null, '5002')
go



-- Deserts
INSERT INTO ITEM VALUES('20', '6001' ,'Chocolate cake' , 1.90,  null, null, 20, '1', null, null, 1, 0,  null, null, '6001')
go

INSERT INTO ITEM VALUES('20', '6002' ,'Strawbery short cake' , 1.80,  null, null, 20, '1', null, null, 1, 0,  null, null, '6002')
go

INSERT INTO ITEM VALUES('20', '6003' ,'Sandae' , 1.40,  null, null, 20, '1', null, null, 1, 0,  null, null, '6003')
go



-- Beverages
INSERT INTO ITEM VALUES('20', '7001' ,'Coca cola' , 0.40,  null, null, 20, '1', null, null, 1, 0,  null, null, '7001')
go

INSERT INTO ITEM VALUES('20', '7002' ,'Sprite' ,0.40,  null, null, 20, '1', null, null, 1, 0,  null, null, '7002')
go

INSERT INTO ITEM VALUES('20', '7003' ,'Sunkist' , 0.30,  null, null, 20, '1', null, null, 1, 0,  null, null, '7003')
go

INSERT INTO ITEM VALUES('20', '7004' ,'Bottle water' , 0.30,  null, null, 20, '1', null, null, 1, 0,  null, null, '7004')
go

INSERT INTO ITEM VALUES('20', '7005' ,'Iced tea' , 0.40,  null, null, 20, '1', null, null, 1, 0,  null, null, '7005')
go




-- Promotions


insert into promotion values ( '20', 101, 1,   3, 0, 0, 0, 0,    20.00,  0, 0, 0, 0,   0,	 '2001-01-01', '2099-01-01', 'Group Discount',	'EclipsePos.Apps.Operators.GroupDiscount' )
go

insert into promotion values ( '20', 201, 1,   3, 0, 0, 0, 0,   10.00,  0, 0, 0, 0,   0,	 '2001-01-01', '2099-01-01', '3 for $10',	'EclipsePos.Apps.Operators.NForX' )
go

insert into promotion values ( '20', 1, 1,   1, 0, 0, 0, 0,    10.00,  0, 0, 0, 0,   0,	 '2001-01-01', '2099-01-01', 'Item markdown ',	'EclipsePos.Apps.Operators.ItemDiscount' )
go

insert into promotion values ( '20', 2, 1,   1, 0, 0, 0, 0,    20.00,  0, 0, 0, 0,   0,	 '2001-01-01', '2099-01-01', 'Item markdown ',	'EclipsePos.Apps.Operators.ItemDiscount' )
go

insert into promotion values ( '20', 3, 1,   1, 0, 0, 0, 0,    30.00,  0, 0, 0, 0,   0,	 '2001-01-01', '2099-01-01', 'Item markdown ',	'EclipsePos.Apps.Operators.ItemDiscount' )
go

insert into promotion values ( '20', 4, 1,   1, 0, 0, 0, 0,    40.00,  0, 0, 0, 0,   0,	 '2001-01-01', '2099-01-01', 'Item markdown ',	'EclipsePos.Apps.Operators.ItemDiscount' )
go

insert into promotion values ( '20', 5, 1,   1, 0, 0, 0, 0,    50.00,  0, 0, 0, 0,   0,	 '2001-01-01', '2099-01-01', 'Item markdown ',	'EclipsePos.Apps.Operators.ItemDiscount' )
go


























