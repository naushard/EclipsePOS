
delete from menu_root where config_no = 7
go
delete from sub_menu where menu_id =  701
go
delete from sub_menu where menu_id =  702
go
delete from sub_menu where menu_id =  703
go
delete from pos_key where sub_menu_id =  7001
go
delete from pos_key where sub_menu_id =  7002
go
delete from pos_key where sub_menu_id =  7003
go
delete from pos_key where sub_menu_id =  7004
go
delete from pos_key where sub_menu_id =  7005
go
delete from pos_key where sub_menu_id =  7006
go
delete from employee where employee_id =7
go
delete from employee where employee_id =8
go


delete from pos_profile where config_no = 7
go
delete from tax_group where config_no =7
go
delete from tax where tax_group_id =7
go
delete from pos_param where config_no= 7
go
delete from dialog where config_no=7
go
delete from dialog_event where dialog_id=7500 
go
delete from dialog_event where dialog_id=7501
go
delete from dialog_event where dialog_id=7502 
go
delete from dialog_event where dialog_id=7503
go
delete from dialog_event where dialog_id=7504 
go
delete from dialog_event where dialog_id=7505 
go
delete from dialog_event where dialog_id=7506 
go
delete from dialog_event where dialog_id=7507 
go
delete from dialog_event where dialog_id=7508
go
delete from dialog_event where dialog_id=7509 
go
delete from dialog_event where dialog_id=7510 
go
delete from currency where config_no=7
go
delete from media where config_no=7
go
delete from pos_config where config_no=7
go



insert into menu_root values (701,    7,     0,    0,   44, 1024,    0,    0, "Prompt")
go
insert into menu_root values (702,    7,     0,   49,  374, 1024,    0,    0, "Invoice")
go
insert into menu_root values (703,    7,     0,   444, 320, 1024,    0,    0, "Main")
go



insert into sub_menu values (7001, 701, "Prompt")
go
insert into sub_menu values (7002, 702, "Invoice")
go
insert into sub_menu values (7003, 703, "Main")
go
insert into sub_menu values (7004, 703, "Functions") 
go
insert into sub_menu values (7005, 703, "Alternate Currency Entry") 
go
insert into sub_menu values (7006, 703, "PLU Menu") 
go


											

-
insert into employee values (7, 501, 1, 1, "Manager", "", "", "", 0) 
go
insert into employee values (8,  502, 1, 2, "Cashier", "", "", "", 0) 
go

insert into pos_profile values (null, 7, 0, "Manager") 
go
insert into pos_profile values (2, 7, 0, "Cashier") 
go


insert into tax_group values (7, 7) 
go
insert into tax values (0, 7, 1, "GST", 0.05, 0.05) 
go
insert into tax values (0, 7, 2, "GST", 0.050, 0.050) 
go


insert into pos_param values (  0, 7, 3, 0, 0, "CustWelcome", "Welcome") 
go
insert into pos_param values (  0, 7, 3, 0, 0, "ReceiptLine1", "Thank you for shopping") 
go
insert into pos_param values (  0, 7, 3, 0, 0, "OperTitle", "Operator Display") 
go
insert into pos_param values (  0, 7, 3, 0, 0, "Total", "Total") 
go
insert into pos_param values ( 0, 7, 3, 0, 0, "TotalTax", "Total Tax") 
go
insert into pos_param values ( 0, 7, 3, 0, 0, "SubTotal", "SubTotal") 
go
insert into pos_param values ( 0, 7, 3, 0, 0, "CashTender", "Cash Tender") 
go
insert into pos_param values ( 0, 7, 3, 0, 0, "CheckTender", "Check Tender") 
go
insert into pos_param values ( 0, 7, 3, 0, 0, "CreditCard", "Credit Card Tender") 
go
insert into pos_param values ( 0, 7, 3, 0, 0, "Discount", "Discount") 
go
insert into pos_param values ( 0, 7, 3, 0, 0, "Markout", "Markout") 
go
insert into pos_param values ( 0, 7, 3, 0, 0, "Change", "Change Due") 
go
insert into pos_param values ( 0, 7, 3, 0, 0, "CashBack", "Cash Back") 
go
insert into pos_param values ( 0, 7, 3, 0, 0, "CloseDrawer", "Close Cash Drawer") 
go
insert into pos_param values ( 0, 7, 3, 0, 0, "InsertCheck", "Insert check") 
go
insert into pos_param values ( 0, 7, 3, 0, 0, "InsertValidation", "Insert Validation") 
go
insert into pos_param values ( 0, 7, 3, 0, 0, "InsertCCValidation", "Insert credit card receipt") 
go
insert into pos_param values ( 0, 7, 3, 0, 0, "BadName", "Bad user ID, press clear") 
go
insert into pos_param values ( 0, 7, 3, 0, 0, "BadPass", "Invalid password, press clear") 
go
insert into pos_param values ( 0, 7, 3, 0, 0, "InvalidCustomer", "Invalid customer number, press clear") 
go
insert into pos_param values ( 0, 7, 3, 0, 0, "TooMany", "Too many logon attempts, press clear-") 
go
insert into pos_param values ( 0, 7, 3, 0, 0, "GoodLogin", "Logon successful") 
go
insert into pos_param values ( 0, 7, 3, 0, 0, "OkText", "OK") 
go
insert into pos_param values ( 0, 7, 3, 0, 0, "CancelText", "Cancel") 
go
insert into pos_param values ( 0, 7, 3, 0, 0, "ClearText", "Clear") 
go
insert into pos_param values ( 0, 7, 3, 0, 0, "InvalidInput", "Invalid Input, press clear") 
go
insert into pos_param values ( 0, 7, 3, 0, 0, "PromptOpenAmount", "Enter open amount: ") 
go
insert into pos_param values ( 0, 7, 3, 0, 0, "PromptAmount", "Enter amount: ") 
go
insert into pos_param values ( 0, 7, 3, 0, 0, "PromptCashBack", "Cash back amount:") 
go
insert into pos_param values ( 0, 7, 3, 0, 0, "ConfirmOpenAmount", "Confirm (enter/clear)") 
go
insert into pos_param values ( 0, 7, 3, 0, 0, "RegOpen", "Register Open") 
go
insert into pos_param values ( 0, 7, 3, 0, 0, "ReturnSale", "Return Sale") 
go
insert into pos_param values ( 0, 7, 3, 0, 0, "TotalRequired", "Total Required, press clear") 
go
insert into pos_param values ( 0, 7, 3, 0, 0, "InsufficientFunds", "Insufficient Funds, press clear") 
go
insert into pos_param values ( 0, 7, 3, 0, 0, "BalanceDue", "Balance Due:") 
go
insert into pos_param values ( 0, 7, 3, 0, 0, "MgrIntervention", "Manager intervention required") 
go
insert into pos_param values ( 0, 7, 3, 0, 0, "EnterUser", "Enter User ID: ") 
go
insert into pos_param values ( 0, 7, 3, 0, 0, "EnterPass", "Enter Password: ") 
go
insert into pos_param values ( 0, 7, 3, 0, 0, "LoginTab", "Login") 
go
insert into pos_param values ( 0, 7, 3, 0, 0, "PromptDrawerNo", "Enter drawer number: ") 
go
insert into pos_param values ( 0, 7, 3, 0, 0, "ConfirmDrawerNo", "Confirm (enter/clear)") 
go
insert into pos_param values ( 0, 7, 3, 0, 0, "BadDrawerNo", "Invalid drawer number") 
go
insert into pos_param values ( 0, 7, 3, 0, 0, "BadCheckNo", "Invalid check number") 
go
insert into pos_param values ( 0, 7, 3, 0, 0, "BadCCNo", "Invalid credit card") 
go
insert into pos_param values ( 0, 7, 3, 0, 0, "BadExpr", "Bad expiration date") 
go
insert into pos_param values ( 0, 7, 3, 0, 0, "PromptCustomer", "Enter Customer Number: ") 
go
insert into pos_param values ( 0, 7, 3, 0, 0, "VoidSale", "Sale Voided, press enter") 
go
insert into pos_param values ( 0, 7, 3, 0, 0, "ConvertedAltCurrency", "Converted total") 
go
insert into pos_param values ( 0, 7, 3, 0, 0, "AltCurrTenderPrompt", "Enter alternate currency amount: ") 
go
insert into pos_param values ( 0, 7, 3, 0, 0, "AltCurrencyDescription", "Alternate Currency Tender") 
go
insert into pos_param values ( 0, 7, 3, 0, 0, "TenderTotal", "Amount Tendered") 
go
insert into pos_param values ( 0, 7, 3, 0, 0, "TerminalLocked", "Terminal locked, press enter") 
go
insert into pos_param values ( 0, 7, 3, 0, 0, "EnterItem", "Enter item") 
go
insert into pos_param values ( 0, 7, 3, 0, 0, "EnterWeight", "Enter weight") 
go
insert into pos_param values ( 0, 7, 3, 0, 0, "Pause", "Press enter to continue...") 
go
insert into pos_param values ( 0, 7, 3, 0, 0, "CloaeCash", "Close cash drawer.") 
go
insert into pos_param values ( 0, 7, 3, 0, 0, "RecallFailed", "Transaction not found") 
go
insert into pos_param values ( 0, 7, 3, 0, 0, "CashLimitExceeded", "Cash in drawer limit exceeded") 
go
insert into pos_param values ( 0, 7, 3, 0, 0, "EnterNewPrice", "Enter new price:") 
go
insert into pos_param values ( 0, 7, 3, 0, 0, "PosPrinterFailed", "PRINTER FAILURE") 
go
insert into pos_param values ( 0, 7, 3, 0, 0, "PosPrinterError", "PRINTER ERROR") 
go
insert into pos_param values ( 0, 7, 3, 0, 0, "ReceiptTopMOD", "Welcome to Mercator") 
go
insert into pos_param values ( 0, 7, 3, 0, 0, "ReceiptBottomMOD", "Thank you for shopping") 
go
insert into pos_param values ( 0, 7, 3, 0, 0, "ReceiptTrxTag", "TAX") 
go
insert into pos_param values ( 0, 7, 3, 0, 0, "ReceiptPosTag", "REG") 
go
insert into pos_param values ( 0, 7, 3, 0, 0, "ReceiptEmpTag", "EMP") 
go
insert into pos_param values ( 0, 7, 3, 0, 0, "SavedReceipt", "Sale Saved") 
go
insert into pos_param values ( 0, 7, 3, 0, 0, "TrxNo", "TRX: ") 
go
insert into pos_param values ( 0, 7, 3, 0, 0, "PosNo", "POS: ") 
go
insert into pos_param values ( 0, 7, 3, 0, 0, "PosPrinterError", "Printer Error") 
go
insert into pos_param values ( 0, 7, 3, 0, 0, "CashDrawerError", "Cash Drawer Error") 
go
insert into pos_param values ( 0, 7, 3, 0, 0, "PosLineDisplayError", "Line Display Error") 
go
insert into pos_param values ( 0, 7, 4, 0, 0, "SpeedDrawer", "false") 
go
insert into pos_param values ( 0, 7, 3, 0, 0, "ReceiptClass", "com.globalretailtech.pos.devices.Receipt") 
go
insert into pos_param values ( 0, 7, 3, 0, 0, "OperPromptClass", "com.globalretailtech.pos.devices.OperPrompt") 
go
insert into pos_param values ( 0, 7, 3, 0, 0, "InitDialog", "Open") 
go
insert into pos_param values ( 0, 7, 4, 0, 0, "PromptForReceipt", "false") 
go
insert into pos_param values ( 0, 7, 3, 0, 0, "MathClass", "com.globalretailtech.pos.operators.SimpleMath") 
go
insert into pos_param values ( 0, 7, 3, 0, 0, "FieldsClass", "com.globalretailtech.pos.operators.SimpleFields") 
go
insert into pos_param values ( 0, 7, 4, 0, 0, "ReceiptPrintAddr1", "true") 
go
insert into pos_param values ( 0, 7, 4, 0, 0, "ReceiptPrintAddr2", "true") 
go
insert into pos_param values ( 0, 7, 4, 0, 0, "ReceiptPrintAddr3", "true") 
go
insert into pos_param values ( 0, 7, 4, 0, 0, "ReceiptPrintAddr4", "true") 
go
insert into pos_param values ( 0, 7, 4, 0, 0, "ReceiptPrintAddr5", "true") 
go
insert into pos_param values ( 0, 7, 4, 0, 0, "ReceiptPrintTel", "true") 
go

insert into pos_param values ( 0, 7, 4, 0, 0, "NavigateButtons", "true") 
go
insert into pos_param values ( 0, 7, 3, 0, 0, "OperReceiptFont", "Lucida Sans Typewriter Regular") 
go
insert into pos_param values ( 0, 7, 3, 0, 0, "HeaderFont", "Courier") 
go
insert into pos_param values ( 0, 7, 3, 0, 0, "HeaderTitleFont", "Helvetica") 
go
insert into pos_param values ( 0, 7, 1, 0, 0, "OperReceiptFontSize", "15") 
go
insert into pos_param values ( 0, 7, 1, 0, 0, "HeaderFontSize", "12") 
go
insert into pos_param values ( 0, 7, 1, 0, 0, "HeaderTitleFontSize", "14") 
go
insert into pos_param values ( 0, 7, 1, 0, 0, "RowHeight", "30") 
go
insert into pos_param values ( 0, 7, 1, 0, 0, "QtyWidth", "55") 
go
insert into pos_param values ( 0, 7, 1, 0, 0, "DescWidth", "250") 
go
insert into pos_param values ( 0, 7, 1, 0, 0, "ValueWidth", "112") 
go
insert into pos_param values ( 0, 7, 1, 0, 0, "TableRows", "200") 
go
insert into pos_param values ( 0, 7, 1, 0, 0, "TrxWidth", "10") 
go
insert into pos_param values ( 0, 7, 1, 0, 0, "PosWidth", "4") 
go
insert into pos_param values ( 0, 7, 1, 0, 0, "EmpWidth", "4") 
go
insert into pos_param values ( 0, 7, 1, 0, 0, "DateWidth", "14") 
go



insert into pos_param values ( 0, 7, 3, 0, 0, "MarkdownLiteral1", "Take ") 
go
insert into pos_param values ( 0, 7, 3, 0, 0, "MarkdownLiteral2", "% Off") 
go


insert into pos_param values ( 0, 7, 3, 0, 0, "NonTaxCount", "Non-Tax transactions") 
go
insert into pos_param values ( 0, 7, 3, 0, 0, "NonTaxAmount", "Non-Tax amount") 
go
insert into pos_param values ( 0, 7, 3, 0, 0, "TaxCount", "Tax transactions ") 
go
insert into pos_param values ( 0, 7, 3, 0, 0, "TaxAmount", "Tax amount ") 
go
insert into pos_param values ( 0, 7, 3, 0, 0, "VoidCount", "Void transactions") 
go
insert into pos_param values ( 0, 7, 3, 0, 0, "VoidAmount", "Void amount") 
go
insert into pos_param values ( 0, 7, 3, 0, 0, "ReturnCount", "Return transactions") 
go
insert into pos_param values ( 0, 7, 3, 0, 0, "ReturnAmount", "Return amount") 
go
insert into pos_param values ( 0, 7, 3, 0, 0, "CouponCount", "Coupon transactions") 
go
insert into pos_param values ( 0, 7, 3, 0, 0, "CouponAmount", "Coupon amount") 
go
insert into pos_param values ( 0, 7, 3, 0, 0, "CreditCount", "Credit transactions") 
go
insert into pos_param values ( 0, 7, 3, 0, 0, "CreditAmount", "Credit amount") 
go
insert into pos_param values ( 0, 7, 3, 0, 0, "CheckCount", "Check transactions") 
go
insert into pos_param values ( 0, 7, 3, 0, 0, "CheckAmount", "Check amount") 
go
insert into pos_param values ( 0, 7, 3, 0, 0, "RecdOnAcctCount", "Received on account transactions") 
go
insert into pos_param values ( 0, 7, 3, 0, 0, "RecdOnAcctAmount", "Received on account amount") 
go
insert into pos_param values ( 0, 7, 3, 0, 0, "PaidInCount", "Paid in transactions") 
go
insert into pos_param values ( 0, 7, 3, 0, 0, "PaidInAmount", "Paid in Amount") 
go
insert into pos_param values ( 0, 7, 3, 0, 0, "PaidOutCount", "Paid out transactions") 
go
insert into pos_param values ( 0, 7, 3, 0, 0, "PaidOutAmount", "Paid out Amount") 
go
insert into pos_param values ( 0, 7, 3, 0, 0, "CashInDrCount", "Cash transactions") 
go
insert into pos_param values ( 0, 7, 3, 0, 0, "CashInDrAmount", "Cash in Drawer Amount") 
go
insert into pos_param values ( 0, 7, 3, 0, 0, "LoanCount", "Loan transactions") 
go
insert into pos_param values ( 0, 7, 3, 0, 0, "LoanAmount", "Loans amount") 
go
insert into pos_param values ( 0, 7, 3, 0, 0, "PickupCount", "Pickup transactions") 
go
insert into pos_param values ( 0, 7, 3, 0, 0, "PickupAmount", "Pickup amount") 
go
insert into pos_param values ( 0, 7, 3, 0, 0, "", " transactions") 
go
insert into pos_param values ( 0, 7, 3, 0, 0, "", " amount") 
go
insert into pos_param values ( 0, 7, 2, 0, 0, "CashPickup", "10000.0") 
go
insert into pos_param values ( 0, 7, 1, 0, 0, "NumCashDrawers", "2") 
go
insert into pos_param values ( 0, 7, 3, 0, 0, "DailyXHeader", "X-Daily Report") 
go
insert into pos_param values ( 0, 7, 3, 0, 0, "DailyZHeader", "Z-Daily Report") 
go
insert into pos_param values ( 0, 7, 3, 0, 0, "WeeklyXHeader", "X-Weekly Report") 
go
insert into pos_param values ( 0, 7, 3, 0, 0, "WeeklyZHeader", "Z-Weekly Report") 
go
insert into pos_param values ( 0, 7, 3, 0, 0, "MonthlyXHeader", "X-Monthly Report") 
go
insert into pos_param values ( 0, 7, 3, 0, 0, "MonthlyZHeader", "Z-Monthly Report") 
go


insert into pos_param values ( 0, 7, 3, 0, 0, "PromptPosNo", "Enter POS Number: ") 
go
insert into pos_param values ( 0, 7, 3, 0, 0, "PromptTransNo", "Enter Transaction Number:") 
go
insert into pos_param values ( 0, 7, 3, 0, 0, "NoSaleCount", "No sale transactions") 
go
insert into pos_param values ( 0, 7, 3, 0, 0, "TransNo", "TRANS#") 
go
insert into pos_param values ( 0, 7, 3, 0, 0, "TransType", "TRANS TYPE") 
go
insert into pos_param values ( 0, 7, 3, 0, 0, "OperLogon", "Operator logon") 
go
insert into pos_param values ( 0, 7, 3, 0, 0, "OperLogoff", "Operator logoff") 
go
insert into pos_param values ( 0, 7, 3, 0, 0, "BankTrans", "Bank transaction") 
go
insert into pos_param values ( 0, 7, 3, 0, 0, "PromptCheckNo", "Enter check number:") 
go
insert into pos_param values ( 0, 7, 3, 0, 0, "PromptCCNo", "Enter credit card number:") 
go
insert into pos_param values ( 0, 7, 3, 0, 0, "PromptCCExpr", "Enter expiration data:") 
go
insert into pos_param values ( 0, 7, 3, 0, 0, "Confirm", "Press enter") 
go
insert into pos_param values ( 0, 7, 3, 0, 0, "GroupDiscount", "10% off third item") 
go

insert into pos_param values ( 0, 7, 3, 0, 0, "SiteName", "Eclipse Retailers, Inc.") 
go
insert into pos_param values ( 0, 7, 3, 0, 0, "SiteAddr1", "9601 Provost Road") 
go
insert into pos_param values ( 0, 7, 3, 0, 0, "SiteAddr2", "Silverdale") 
go
insert into pos_param values ( 0, 7, 3, 0, 0, "SiteAddr3", "Singapore") 
go
insert into pos_param values ( 0, 7, 3, 0, 0, "SiteAddr4", "111113") 
go
insert into pos_param values ( 0, 7, 3, 0, 0, "SiteAddr5", "") 
go
insert into pos_param values ( 0, 7, 3, 0, 0, "SiteAddr6", "") 
go
insert into pos_param values ( 0, 7, 3, 0, 0, "SitePhone", "(555) 555-1234") 
go
insert into pos_param values ( 0, 7, 3, 0, 0, "SiteFax", "(555) 555-4321") 
go
insert into pos_param values ( 0, 7, 3, 0, 0, "TrxTag", "Transaction") 
go
insert into pos_param values ( 0, 7, 3, 0, 0, "PosTag", "Register") 
go
insert into pos_param values ( 0, 7, 3, 0, 0, "EmpTag", "Employee") 
go
insert into pos_param values ( 0, 7, 3, 0, 0, "DateTag", "Time/Date") 
go
insert into pos_param values ( 0, 7, 3, 0, 0, "TimeTag", "Time ") 
go
insert into pos_param values ( 0, 7, 3, 0, 0, "QtyHeader", "Qty") 
go
insert into pos_param values ( 0, 7, 3, 0, 0, "ItemHeader", "Item") 
go
insert into pos_param values ( 0, 7, 3, 0, 0, "DescHeader", "Description") 
go
insert into pos_param values ( 0, 7, 3, 0, 0, "PriceHeader", "Price") 
go
insert into pos_param values ( 0, 7, 3, 0, 0, "PLUHeader", "PLU") 
go
insert into pos_param values ( 0, 7, 3, 0, 0, "ValueHeader", "Value") 
go
insert into pos_param values ( 0, 7, 3, 0, 0, "CustNoTag", "Number") 
go
insert into pos_param values ( 0, 7, 3, 0, 0, "CustNameTag", "Name") 
go
insert into pos_param values ( 0, 7, 3, 0, 0, "CustAddrTag", "Address") 
go
insert into pos_param values ( 0, 7, 3, 0, 0, "CustCityTag", "City") 
go
insert into pos_param values ( 0, 7, 3, 0, 0, "CustStateTag", "State") 
go
insert into pos_param values ( 0, 7, 3, 0, 0, "CustZipTag", "Zip") 
go
insert into pos_param values ( 0, 7, 3, 0, 0, "CustPhoneTag", "Phone") 
go
insert into pos_param values ( 0, 7, 3, 0, 0, "CustFaxTag", "Fax") 
go
insert into pos_param values ( 0, 7, 3, 0, 0, "CustEmailTag", "E-Mail") 
go
insert into pos_param values ( 0, 7, 3, 0, 0, "OverMeiaLimit", "Over Media Limit") 
go
insert into pos_param values ( 0, 7, 3, 0, 0, "UnderMediaLimit", "Under Media Limit") 
go
insert into pos_param values ( 0, 7, 3, 0, 0, "ConvertedTotal", "Converted Total") 
go
insert into pos_param values ( 0, 7, 3, 0, 0, "AltCurrTotal", "Alternate Currency Total") 
go



insert into pos_param values ( 0, 7, 3, 0, 0, "LocaleLanguage", "en") 
go
insert into pos_param values ( 0, 7, 3, 0, 0, "LocaleCountry", "US") 
go
insert into pos_param values ( 0, 7, 3, 0, 0, "LocaleVariant", "") 
go

insert into pos_param values ( 0, 7, 2, 0, 0, "DecimalPlaces", "2") 
go
insert into pos_param values ( 0, 7, 4, 0, 0, "PromptForCashBack", "TRUE") 
go
insert into pos_param values ( 0, 7, 1, 0, 0, "DefaultDrawerNo", "1") 
go
insert into pos_param values ( 0, 7, 3, 0, 0, "Idle1", " Welcome to         ") 
go
insert into pos_param values ( 0, 7, 3, 0, 0, "Idle2", "       my shop......") 
go



insert into dialog values (7500, 7, 0, 1, "Open") 
go
insert into dialog_event values (1,  7500, 1, 0, "Register Open", 0,  1, 1, "EclipsePos.Apps.PosEvents.RegisterOpen") 
go
insert into dialog_event values (7, 7500, 2, 0, null, 0,  1, 1, "EclipsePos.Apps.PosEvents.StartTransaction") 
go
insert into dialog_event values (7, 7500, 3, 0, null, 0,  1, 1, "EclipsePos.Apps.PosEvents.NewLogon") 
go
insert into dialog_event values (7, 7500, 4, 0, "Complete logon", 8,  1, 1, "EclipsePos.Apps.PosEvents.Logon") 
go
insert into dialog_event values (7, 7500, 5, 0, "Get Open Amount", 3,  0, 0, null) 
go
insert into dialog_event values (7, 7500, 6, 0, "Get Drawer", 2,  0, 0, null) 
go
insert into dialog_event values (7, 7500, 7, 0, null, 0,  1, 1, "EclipsePos.Apps.PosEvents.StartTransaction") 
go




insert into dialog values (7,7501, 7, 0, 1, "Logon") 
go


insert into dialog_event values (7,  7501, 1, 0, null, 0,  1, 1, "EclipsePos.Apps.PosEvents.RegisterOpen") 
go
insert into dialog_event values (7,  7501, 2, 0, null, 0,  1, 1, "EclipsePos.Apps.PosEvents.StartTransaction") 
go
insert into dialog_event values (7,  7501, 3, 0, null, 0,  1, 1, "EclipsePos.Apps.PosEvents.NewLogon") 
go
insert into dialog_event values (7,  7501, 4, 0, null, 8,  1, 1, "EclipsePos.Apps.PosEvents.Logon") 
go
insert into dialog_event values (7,  7501, 5, 0, null, 3,  1, 1, null) 
go
insert into dialog_event values (7,  7501, 6, 0, null, 2,  1, 1, null) 
go
insert into dialog_event values (7,  7501, 7, 0, null, 1,  1, 1, null) 
go
insert into dialog_event values (7,  7501, 8, 0, null, 0,  1, 1, null) 
go
insert into dialog_event values (7,  7501, 9, 0, null, 0,  1, 1, "EclipsePos.Apps.PosEvents.StartTransaction") 
go



insert into dialog values (7502, 7, 0, 1, "ManagerRequired") 
go




insert into dialog_event values (7,  7502, 1,  0, null, 1005, 1, 1, "EclipsePos.Apps.PosEvents.Error") 
go
insert into dialog_event values (7,  7502, 2,  0, null, 29,   1, 1, "EclipsePos.Apps.PosEvents.UserValidation") 
go
insert into dialog_event values (7,  7502, 4,  0, null, 30,   1, 1, null) 
go
insert into dialog_event values (7,  7502, 4,  0, null, 70,   1, 1, null) 
go



insert into dialog values (7503, 7, 0, 1, "CashTender") 
go



insert into dialog_event values (7,  7503, 1, 0, null, 0,  1, 1, "EclipsePos.Apps.PosEvents.RegisterOpen") 
go
insert into dialog_event values (7,  7503, 2, 0, null, 0,  1, 1, "EclipsePos.Apps.PosEvents.StartTransaction") 
go
insert into dialog_event values (7,  7503, 3, 0, null, 0, 1, 1, "EclipsePos.Apps.PosEvents.FinishTransaction") 
go
insert into dialog_event values (7,  7503, 4, 0, null, 0, 1, 1, "EclipsePosApps.Apps.PosEvents.CloseCashDrawer") 
go
insert into dialog_event values (7,  7503, 5, 0, null, 0, 1, 1, "EclipsePos.Apps.PosEvents.PromptPrintReceipt") 
go
insert into dialog_event values (7,  7503, 6, 0, null, 0, 1, 1, "EclipsePos.Apps.EJournal.EjTender") 
go
insert into dialog_event values (7,  7503, 7, 0, null, 0, 1, 1, "EclipsePos.Apps.PosEvents.CheckHardware") 
go



insert into dialog values (7504, 7, 0, 1, "CheckTender") 
go



insert into dialog_event values (7,  7504, 1, 0, null, 0,  1, 1, "EclipsePos.Apps.PosEvents.RegisterOpen") 
go
insert into dialog_event values (7,  7504, 2, 0, null, 0,  1, 1, "EclipsePos.Apps.PosEvents.StartTransaction") 
go
insert into dialog_event values (7,  7504, 3, 0, null, 0, 1, 1, "EclipsePos.Apps.PosEvents.FinishTransaction") 
go
insert into dialog_event values (7,  7504, 4, 0, null, 0, 1, 1, "EclipsePos.Apps.PosEvents.CloseCashDrawer") 
go
insert into dialog_event values (7,  7504, 5, 0, null, 0, 1, 1, "EclipsePos.Apps.PosEvents.PromptPrintReceipt") 
go
insert into dialog_event values (7,  7504, 6, 0, null, 5, 1, 1, "EclipsePos.Apps.EJournal.EjCheckTender")  
go
insert into dialog_event values (7,  7504, 7, 0, null, 2, 1, 1, null) 
go
insert into dialog_event values (7,  7504, 8, 0, null, 1, 1, 1, null) 
go
insert into dialog_event values (7,  7504, 9, 0, null, 0, 1, 1, "EclipsePos.Apps.PosEvents.CheckHardware") 
go


insert into dialog values (7505, 7, 0, 1, "CreditTender") 
go



insert into dialog_event values (7,  7505, 1, 0, null, 0,  1, 1, "EclipsePos.Apps.PosEvents.RegisterOpen") 
go
insert into dialog_event values (7,  7505, 2, 0, null, 0, 1, 1, "EclipsePos.Apps.PosEvents.StartTransaction") 
go
insert into dialog_event values (7,  7505, 3, 0, null, 0, 1, 1, "EclipsePos.Apps.PosEvents.FinishTransaction") 
go
insert into dialog_event values (7,  7505, 4, 0, null, 0, 1, 1, "EclipsePos.Apps.PosEvents.CloseCashDrawer") 
go
insert into dialog_event values (7,  7505, 5, 0, null, 0, 1, 1, "EclipsePos.Apps.PosEvents.PromptPrintReceipt") 
go
insert into dialog_event values (7,  7505, 6, 0, null, 8, 1, 1, "EclipsePos.Apps.EJournal.EjCCTender") 
go
insert into dialog_event values (7,  7505, 7, 0, null, 7, 1, 1, null) 
go
insert into dialog_event values (7,  7505, 8, 0, null, 3, 1, 1, null) 
go
insert into dialog_event values (7,  7505, 9, 0, null, 2, 1, 1, null) 
go
insert into dialog_event values (7,  7505, 10 , 0, null, 1, 1, 1, null) 
go
insert into dialog_event values (7,  7505, 11, 0, null, 0, 1, 1, "EclipsePos.Apps.PosEvents.CheckHardware") 
go




insert into dialog values (7506, 7, 0, 1, "AltCurrTender") 
go



insert into dialog_event values (7,  7506, 1, 0, null, 0, 1, 1, "EclipsePos.Apps.PosEvents.RegisterOpen") 
go
insert into dialog_event values (7,  7506, 2, 0, null, 0, 1, 1, "EclipsePos.Apps.PosEvents.StartTransaction") 
go
insert into dialog_event values (7,  7506, 3, 0, null, 0, 1, 1, "EclipsePos.Apps.PosEvents.FinishTransaction") 
go
insert into dialog_event values (7,  7506, 4, 0, null, 0, 1, 1, "EclipsePos.Apps.PosEvents.CloseCashDrawer") 
go
insert into dialog_event values (7,  7506, 5, 0, null, 0, 1, 1, "EclipsePos.Apps.PosEvents.PromptPrintReceipt") 
go
insert into dialog_event values (7,  7506, 5, 0, null, 1, 1, 1, "EclipsePos.Apps.EJournal.EjAltCurrTender") 
go



insert into dialog values (7507, 7, 0, 1, "RecallEj") 
go


insert into dialog_event values (7,  7507, 1, 0, null, 5, 1, 1, "EclipsePos.Apps.EJournal.RecallEj") 
go
insert into dialog_event values (7,  7507, 2, 0, null, 2, 1, 1, null) 
go
insert into dialog_event values (7,  7507, 3, 0, null, 1, 1, 1, null) 
go


insert into dialog values (7508, 7, 0, 1, "PaidIn") 
go


insert into dialog_event values (7,  7508, 1, 0, null, 0, 1, 1, "EclipsePos.Apps.PosEvents.RegisterOpen") 
go
insert into dialog_event values (7,  7508, 2, 0, null, 0, 1, 1, "EclipsePos.Apps.PosEvents.StartTransaction") 
go
insert into dialog_event values (7,  7508, 3, 0, null, 0, 1, 1, "EclipsePos.Apps.PosEvents.FinishTransaction") 
go
insert into dialog_event values (7,  7508, 4, 0, null, 0, 1, 1, "EclipsePos.Apps.PosEvents.CloseCashDrawer") 
go
insert into dialog_event values (7,  7508, 5, 0, null, 1, 1, 1, "EclipsePos.Apps.EJournal.EjBank") 
go


insert into dialog values (7509, 7, 0, 1, "PaidOut") 
go


insert into dialog_event values (7,  7509, 1, 0, null, 0, 1, 1, "EclipsePos.Apps.PosEvents.RegisterOpen") 
go
insert into dialog_event values (7,  7509, 2, 0, null, 0, 1, 1, "EclipsePos.Apps.PosEvents.StartTransaction") 
go
insert into dialog_event values (7,  7509, 3, 0, null, 0, 1, 1, "EclipsePos.Apps.PosEvents.FinishTransaction") 
go
insert into dialog_event values (7,  7509, 4, 0, null, 0, 1, 1, "EclipsePos.Apps.PosEvents.CloseCashDrawer") 
go
insert into dialog_event values (7,  7509, 5, 0, null, 2, 1, 1, "EclipsePos.Apps.EJournal.EjBank") 
go


insert into dialog values (7510, 7, 0, 1, "UnLock") 
go



insert into dialog_event values (7,  7510, 1, 0, null, 2, 1, 1, "EclipsePos.Apps.PosEvents.UnLock") 
go
insert into dialog_event values (7,  7510, 2, 0, null, 0, 1, 1, null) 
go



insert into currency values ( 7, 1,   1.0,      1, 2, "US", 1, 1, null, null) 
go
insert into currency values ( 7, 28,  2.12868,  1, 2, "DE", 0, 0, null, null) 
go
insert into currency values ( 7, 30,  1.67400,  1, 2, "CH", 0, 0, null, null) 
go
insert into currency values ( 7, 69,  7.13928,  1, 2, "FR", 0, 0, null, null) 
go
insert into currency values ( 7, 36,  43.9050,  1, 2, "BE", 0, 0, null, null) 
go
insert into currency values ( 7, 37,  1.58014,  1, 2, "CA", 0, 0, null, null) 
go
insert into currency values ( 7, 89,  1.13236,  1, 2, "EU", 0, 0, null, null) 
go


insert into media values ( 7, 1, 20000, 0, "Cash", null) 
go
insert into media values ( 7, 2, 100, 0, "Check", null) 
go
insert into media values ( 7, 3, 100000, 0, "Visa", null) 
go
insert into media values ( 7, 4, 100000, 0, "Master Card", null) 
go
insert into media values ( 7, 5, 100000, 0, "American Express", null) 
go
insert into media values ( 7, 6, 100000, 0, "Debit Card", null) 
go
insert into media values ( 7, 7, 100000, 0, "Euro", null) 
go
insert into media values ( 7, 8, 100000, 0, "DEM", null) 
go
insert into media values ( 7, 9, 100000, 0, "DKK", null) 
go

insert into pos_config values (7,  7, "Pos Configuration" ) 



insert into pos_key values (1 , 1," "                       ,5,   2,   0,1,   0,   0,  32,1024,0,0,-1,"NNNNNNNN",1,"com.globalretailtech.pos.gui.OneLine"," "," ");
go
insert into pos_key values (1 , 2," "                       ,5,   2,   0,1,   5,   0, 650, 420,0,0,-1,"NNNNNNNN",1,"com.globalretailtech.pos.gui.OperDisplay"," "," ");
go


insert into pos_key values (1 , 3,"PLU"                     ,5,   0, 300,0,   3,   3,  78, 107,0,	192,	192,	"NNNNNNNN",1,"EclipsePos.Apps.PosEvents.LookupItem"," ", " ");
go
insert into pos_key values (1 , 3,"Quantity"                ,5,   3, 301,0, 147,   3,  78, 107,0,	192,	192,	"NNNNNNNN",1, "EclipsePos.Apps.PosEvents.Quantity"," "," ");
go
insert into pos_key values (1 , 3,"Subtotal"                ,5,   0, 302,0, 291,   3,  78, 107,0,	192,	192,	"NNNNNNNN",1, "EclipsePos.Apps.PosEvents.Function"," "," ");
go
insert into pos_key values (1 , 3,"Total"                   ,5,   1, 303,0, 435,   3,  78, 107,0,	192,	192,	"NNNNNNNN",1, "EclipsePos.Apps.PosEvents.Function"," "," ");
go   													  			
insert into pos_key values (1 , 3,"Cash"                    ,5,  -1, 400,0,   3,  84,  78, 107,0,	192,	192,	"NNNNNNNN",1, "EclipsePos.Apps.PosEvents.CashTender"," "," ");
go
insert into pos_key values (1 , 3,"Check"                   ,5,   0, 401,0, 147,  84,  78, 107,0,	192,	192,	"NNNNNNNN",1, "EclipsePos.Apps.PosEvents.CheckTender"," "," ");
go
insert into pos_key values (1 , 3,"Credit Card"             ,5,   0, 402,0, 291,  84,  78, 107,0,	192,	192,	"NNNNNNNN",1, "EclipsePos.Apps.PosEvents.CreditTender"," "," ");
go
insert into pos_key values (1 , 3,"Alternate Currency Entry",4,   0,   0,0, 435,  84,  78, 107,0,	192,	192,	"NNNNNNNN",1, "EclipsePos.Apps.PosEvents.Null","Alternate Currency Entry","");
go   				 							 		  			
insert into pos_key values (1 , 3,"Markdown"                ,5,   2, 500,0,   3, 165,  78, 107,0,	192,	192,	"NNNNNNNN",1, "EclipsePos.Apps.PosEvents.ItemMarkdown"," "," ");
go
insert into pos_key values (1 , 3,"Void"                    ,5,   0, 501,0, 147, 165,  78, 107,0,	192,	192,	"NNNNNNNN",1, "EclipsePos.Apps.PosEvents.ItemVoid"," "," ");
go
insert into pos_key values (1 , 3,"Void Sale"               ,5,   0, 502,0, 291, 165,  78, 107,0,	192,	192,	"NNNNNNNN",1, "EclipsePos.Apps.PosEvents.VoidSale"," "," ");
go
insert into pos_key values (1 , 3,"Return Sale"             ,5,   0, 503,0, 435, 165,  78, 107,0,	192,	192,	"NNNNNNNN",1, "EclipsePos.Apps.PosEvents.ReturnSale"," "," ");
go   													  		  
insert into pos_key values (1 , 3,"Lock"                    ,5,   0,   0,0,   3, 246,  78, 107,0,	192,	192,	"NNNNNNNN",1, "EclipsePos.Apps.PosEvents.Lock"," "," ");
go
insert into pos_key values (1 , 3,"Discount Sale"           ,2,   2,   0,0, 147, 246,  78, 107,0,	192,	192,	"NNNNNNNN",1, "EclipsePos.Apps.PosEvents.Discount", " "," ");
go
insert into pos_key values (1 , 3,"PLU Menu"                ,4,   4,   0,0, 291, 246,  78, 107,0,	192,	192,	"NNNNNNNN",1, "EclipsePos.Apps.PosEvents.Null", "PLU Menu"," ");
go
insert into pos_key values (1 , 3,"Functions"               ,4,   4,   0,0, 435, 246,  78, 107,0,	192,	192,	"NNNNNNNN",1, "EclipsePos.Apps.PosEvents.Null","Functions", " ");
go														  				
insert into pos_key values (1 , 3,"7"                       ,5,   7, 103,0,   3, 327,  78, 107,	255,	192,	128,	"NNNNNNNN",0, "EclipsePos.Apps.PosEvents.NumKey"," "," ");
go
insert into pos_key values (1 , 3,"8"                       ,5,   8, 104,0, 147, 327,  78, 107,	255,	192,	128,	"NNNNNNNN",0, "EclipsePos.Apps.PosEvents.NumKey", " "," ");
go 
insert into pos_key values (1 , 3,"9"                       ,5,   9, 105,0, 291, 327,  78, 107,	255,	192,	128,	"NNNNNNNN",0, "EclipsePos.Apps.PosEvents.NumKey", " "," ");
go
insert into pos_key values (1 , 3,"Enter"                   ,5,   0,  10,0, 435, 327, 321, 107,	255,	192,	128,	"NNNNNNNN",0, "EclipsePos.Apps.PosEvents.EnterKey"," "," ");
go	  										  		  		   
insert into pos_key values (1 , 3,"4"                       ,5,   4, 100,0,   3, 408,  78, 107	255,	192,	128,	"NNNNNNNN",0, "EclipsePos.Apps.PosEvents.NumKey", " "," ");
go
insert into pos_key values (1 , 3,"5"                       ,5,   5, 101,0, 147, 408,  78, 107,	255,	192,	128,	"NNNNNNNN",0, "EclipsePos.Apps.PosEvents.NumKey", " "," ");
go
insert into pos_key values (1 , 3,"6"                       ,5,   6, 102,0, 291, 408,  78, 107,	255,	192,	128,	"NNNNNNNN",0, "EclipsePos.Apps.PosEvents.NumKey", " "," ");
go	  										  		  				
insert into pos_key values (1 , 3,"1"                       ,5,   1,  97,0,   3, 489,  78, 107,	255,	192,	128,	"NNNNNNNN",0, "EclipsePos.Apps.PosEvents.NumKey", " "," ");
go
insert into pos_key values (1 , 3,"2"                       ,5,   2,  98,0, 147, 489,  78, 107,	255,	192,	128,	"NNNNNNNN",0, "EclipsePos.Apps.PosEvents.NumKey", " "," ");
go
insert into pos_key values (1 , 3,"3"                       ,5,   3,  99,0, 291, 489,  78, 107,	255,	192,	128,	"NNNNNNNN",0, "EclipsePos.Apps.PosEvents.NumKey", " "," ");
go	  												  		  
insert into pos_key values (1 , 3,"Clear"                   ,5,   0,  27,0,   3, 570,  78, 107,	255,	192,	128,	"NNNNNNNN",0, "EclipsePos.Apps.PosEvents.ClearKey", " "," ");
go
insert into pos_key values (1 , 3,"0"                       ,5,   0,  96,0, 147, 570,  78, 107,	255,	192,	128,	"NNNNNNNN",0, "EclipsePos.Apps.PosEvents.NumKey", " "," ");
go
insert into pos_key values (1 , 3,"00"                      ,5, 100,   0,0, 291, 570,  78, 107,	255,	192,	128,	"NNNNNNNN",0, "EclipsePos.Apps.PosEvents.MultKey", " "," ");
go

-- functions		 								  				
					 									  				
insert into pos_key values (1 , 4,"Log Off"                 ,0,   2,   0,0,   3,   3,  78, 107,0,0,-1,"NNNNNNNN",1, "EclipsePos.Apps.PosEvents.LogOff", " "," ");
go
insert into pos_key values (1 , 4,"Toggle Alternate Tax"    ,0,   3,   0,0, 147,   3,  78, 107,0,0,-1,"NNNNNNNN",1, "EclipsePos.Apps.PosEvents.ToggleAltTax", " "," ");
go     				  				
insert into pos_key values (1 , 4,"Shutdown"                ,0,  -1,   0,0,   3,  84,  78, 107,0,50,-1,"NNNNNNNN",1, "EclipsePos.Apps.PosEvents.Exit", " "," ");
go
insert into pos_key values (1 , 4,"Lock"                    ,0,   0,   0,0, 147,  84,  78, 107,0,50,-1,"NNNNNNNN",1, "EclipsePos.Apps.PosEvents.Exit", " "," ");
go
insert into pos_key values (1 , 4,"Training Mode"           ,0,   0,   0,0, 291,  84,  78, 107,0,50,-1,"NNNNNNNN",1, "EclipsePos.Apps.PosEvents.TrainingMode", " "," ");
go     		 		  						  
insert into pos_key values (1 , 4,"Store"                   ,0,   2,   0,0,   3, 165,  78, 107,0,0,-1,"NNNNNNNN",1, "EclipsePos.Apps.PosEvents.SaveEj", " "," ");
go
insert into pos_key values (1 , 4,"Recall"                  ,0,   0,   0,0, 147, 165,  78, 107,0,0,-1,"NNNNNNNN",1,"EclipsePos.Apps.PosEvents.RecallEj", " "," ");
go
insert into pos_key values (1 , 4,"Paid In"                 ,0,   1,   0,0, 291, 165,  78, 107,0,100,-1,"NNNNNNNN",1,"EclipsePos.Apps.PosEvents.Bank", " "," ");
go
insert into pos_key values (1 , 4,"Paid Out"                ,0,   2,   0,0, 435, 165,  78, 107,0,100,-1,"NNNNNNNN",1,"EclipsePos.Apps.PosEvents.Bank", " "," ");
go     				  		  		
insert into pos_key values (1 , 4,"X-Report"                ,0,   1,   0,0,   3, 246,  78, 107,0,25,-1,"NNNNNNNN",1,"EclipsePos.Apps.PosEvents.TerminalReport", " "," ");
go
insert into pos_key values (1 , 4,"Z-Report"                ,0,   2,   0,0, 147, 246,  78, 107,0,100,-1,"NNNNNNNN",1,"EclipsePos.Apps.PosEvents.TerminalReport", " "," ");
go
insert into pos_key values (1 , 4,"Pickup"                  ,0,   4,   0,0, 291, 246,  78, 107,0,25,-1,"NNNNNNNN",1,"EclipsePos.Apps.PosEvents.Bank", " "," ");
go
insert into pos_key values (1 , 4,"Home"                    ,8,   4,   0,0, 435, 246,  78, 107,0,25,-1,"NNNNNNNN",1,"EclipsePos.Apps.PosEvents.Null", " "," ");
go										  			  									 									  				
														  				
insert into pos_key values (1 , 4,"7"                       ,5,   7, 107,0,   3, 327,  78, 107,0,0,-1,"NNNNNNNN",0,"EclipsePos.Apps.PosEvents.NumKey", " "," ");
go
insert into pos_key values (1 , 4,"8"                       ,5,   8, 108,0, 147, 327,  78, 107,0,0,-1,"NNNNNNNN",0,"EclipsePos.Apps.PosEvents.NumKey", " "," ");
go
insert into pos_key values (1 , 4,"9"                       ,5,   9, 109,0, 291, 327,  78, 107,0,0,-1,"NNNNNNNN",0,"EclipsePos.Apps.PosEvents.NumKey", " "," ");
go
insert into pos_key values (1 , 4,"Enter"                   ,5,   0,  50,0, 435, 327, 321, 107,0,25,-1,"NNNNNNNN",0,"EclipsePos.Apps.PosEvents.EnterKey", " "," ");
go	 										  		  		   
insert into pos_key values (1 , 4,"4"                       ,5,   4, 104,0,   3, 408,  78, 107,0,0,-1,"NNNNNNNN",0,"EclipsePos.Apps.PosEvents.NumKey", " "," ");
go
insert into pos_key values (1 , 4,"5"                       ,5,   5, 105,0, 147, 408,  78, 107,0,0,-1,"NNNNNNNN",0,"EclipsePos.Apps.PosEvents.NumKey", " "," ");
go
insert into pos_key values (1 , 4,"6"                       ,5,   6, 106,0, 291, 408,  78, 107,0,0,-1,"NNNNNNNN",0,"EclipsePos.Apps.PosEvents.NumKey", " "," ");
go
insert into pos_key values (1 , 4,"1"                       ,5,   1, 101,0,   3, 489,  78, 107,0,0,-1,"NNNNNNNN",0,"EclipsePos.Apps.PosEvents.NumKey"," "," ");
go
insert into pos_key values (1 , 4,"2"                       ,5,   2, 102,0, 147, 489,  78, 107,0,0,-1,"NNNNNNNN",0,"EclipsePos.Apps.PosEvents.NumKey", " "," ");
go
insert into pos_key values (1 , 4,"3"                       ,5,   3, 103,0, 291, 489,  78, 107,0,0,-1,"NNNNNNNN",0,"EclipsePos.Apps.PosEvents.NumKey", " "," ");
go
insert into pos_key values (1 , 4,"Clear"                   ,5,   0,  51,0,   3, 570,  78, 107,0,25,-1,"NNNNNNNN",0,"EclipsePos.Apps.PosEvents.ClearKey", " "," ");
go
insert into pos_key values (1 , 4,"0"                       ,5,   0, 100,0, 147, 570,  78, 107,0,0,-1,"NNNNNNNN",0,"EclipsePos.Apps.PosEvents.NumKey", " "," ");
go
insert into pos_key values (1 , 4,"00"                      ,5, 100, 110,0, 291, 570,  78, 107,0,0,-1,"NNNNNNNN",0,"EclipsePos.Apps.PosEvents.MultKey", " "," ");
go


-- alt currency menu							  				
					 									  				
insert into pos_key values (1 , 5,"Canadian"                ,0,   6,   0,0, 003,   3,  78, 141,0,0,-1,"NNNNNNNN",1,"EclipsePos.Apps.PosEvents.AltCurrTender", " "," ");
go
insert into pos_key values (1 , 5,"Euro"                    ,0,   7,   0,0, 147,   3,  78, 141,0,0,-1,"NNNNNNNN",1,"EclipsePos.Apps.PosEvents.AltCurrTender", " "," ");
go
insert into pos_key values (1 , 5,"Deutch Marks"            ,0,   2,   0,0, 003,  84,  78, 141,0,0,-1,"NNNNNNNN",1,"EclipsePos.Apps.PosEvents.AltCurrTender", " "," ");
go
insert into pos_key values (1 , 5,"French Francs"           ,0,   4,   0,0, 147,  84,  78, 141,0,0,-1,"NNNNNNNN",1,"EclipsePos.Apps.PosEvents.AltCurrTender", " "," ");
go
insert into pos_key values (1 , 5,"Swiss Francs"            ,0,   3,   0,0, 291,  84,  78, 141,0,25,-1,"NNNNNNNN",1,"EclipsePos.Apps.PosEvents.AltCurrTender", " "," ");
go
insert into pos_key values (1 , 5,"Belgian Francs"          ,0,   5,   0,0, 435,  84,  78, 141,0,25,-1,"NNNNNNNN",1,"EclipsePos.Apps.PosEvents.AltCurrTender", " "," ");
go   													  				
insert into pos_key values (1 , 5,"Home"                    ,8,   4,   0,0, 435, 246,  78, 141,0,25,-1,"NNNNNNNN",1,"EclipsePos.Apps.PosEvents.Null", " "," ");
go					 									  				
														  				
insert into pos_key values (1 , 5,"7"                       ,5,   7, 107,0,   3, 327,  78, 141,0,0,-1,"NNNNNNNN",0,"EclipsePos.Apps.PosEvents.NumKey", " "," ");
go
insert into pos_key values (1 , 5,"8"                       ,5,   8, 108,0, 147, 327,  78, 141,0,0,-1,"NNNNNNNN",0,"EclipsePos.Apps.PosEvents.NumKey", " "," ");
go
insert into pos_key values (1 , 5,"9"                       ,5,   9, 109,0, 291, 327,  78, 141,0,0,-1,"NNNNNNNN",0,"EclipsePos.Apps.PosEvents.NumKey", " "," ");
go
insert into pos_key values (1 , 5,"Enter"                   ,5,   0,  50,0, 435, 327, 321, 141,0,25,-1,"NNNNNNNN",0,"EclipsePos.Apps.PosEvents.EnterKey", " "," ");
go	 										  		  		   
insert into pos_key values (1 , 5,"4"                       ,5,   4, 104,0,   3, 408,  78, 141,0,0,-1,"NNNNNNNN",0,"EclipsePos.Apps.PosEvents.NumKey", " "," ");
go
insert into pos_key values (1 , 5,"5"                       ,5,   5, 105,0, 147, 408,  78, 141,0,0,-1,"NNNNNNNN",0,"EclipsePos.Apps.PosEvents.NumKey", " "," ");
go
insert into pos_key values (1 , 5,"6"                       ,5,   6, 106,0, 291, 408,  78, 141,0,0,-1,"NNNNNNNN",0,"EclipsePos.Apps.PosEvents.NumKey", " "," ");
go 										  		  				
insert into pos_key values (1 , 5,"1"                       ,5,   1, 101,0,   3, 489,  78, 141,0,0,-1,"NNNNNNNN",0,"EclipsePos.Apps.PosEvents.NumKey", " "," ");
go
insert into pos_key values (1 , 5,"2"                       ,5,   2, 102,0, 147, 489,  78, 141,0,0,-1,"NNNNNNNN",0,"EclipsePos.Apps.PosEvents.NumKey", " "," ");
go
insert into pos_key values (1 , 5,"3"                       ,5,   3, 103,0, 291, 489,  78, 141,0,0,-1,"NNNNNNNN",0,"EclipsePos.Apps.PosEvents.NumKey", " "," ");
go	 												  		  
insert into pos_key values (1 , 5,"Clear"                   ,5,   0,  51,0,   3, 570,  78, 141,0,25,-1,"NNNNNNNN",0,"EclipsePos.Apps.PosEvents.ClearKey", " "," ");
go
insert into pos_key values (1 , 5,"0"                       ,5,   0, 100,0, 147, 570,  78, 141,0,0,-1,"NNNNNNNN",0,"EclipsePos.Apps.PosEvents.NumKey", " "," ");
go
insert into pos_key values (1 , 5,"00"                      ,5, 100, 110,0, 291, 570,  78, 141,0,0,-1,"NNNNNNNN",0,"EclipsePos.Apps.PosEvents.MultKey", " "," ");
go


insert into menu_root values (01,    1,     0,    0,   32, 1024,    0,    0, 'Prompt');
go
insert into menu_root values (02,    1,     0,   40,  650,  425,    0,    0, 'Invoice');
go
insert into menu_root values (03,    1,   426,   40,  650,  580,    0,    0, 'Main');
go

insert into sub_menu values (01,  1, 'Prompt');
go
insert into sub_menu values (02,  2, 'Invoice');
go
insert into sub_menu values (03,  3, 'Main');
go
insert into sub_menu values (04,  3, 'Functions');
go
insert into sub_menu values (05,  3, 'Alternate Currency Entry');
go
insert into sub_menu values (06,  3, 'PLU Menu');
go
 
 
 -- Panel Classes
 insert into menu_panels values ( 5, 701,  'EclipsePos.Apps.Gui.OneLine')
 go
 insert into menu_panels values ( 5, 702, 'EclipsePos.Apps.Gui.OperDisplay')
 go
 insert into menu_panels values ( 5, 703, 'EclipsePos.Apps.Gui.OperDisplayHeader')
 go
 insert into menu_panels values ( 5, 704, 'EclipsePos.Apps.Gui.OperDisplayTotals')
 go
 insert into menu_panels values ( 5, 705, 'EclipsePos.Apps.Gui.CurrencyKeyPanel')
 go	
 insert into menu_panels values ( 5, 706, 'EclipsePos.Apps.Gui.FunctionsKeyPanel')
 go
 insert into menu_panels values ( 5, 707, 'EclipsePos.Apps.Gui.MainKeyPanel')
 go
  
 
 -- Configurations
 -- Main
 insert into menu_config values ( 5, 0,  701,  10,		20,		600,	75, 0, 0, 0, 0, 0, 0, 12 )
 go
 insert into menu_config values ( 5, 0,  702,  5,		110,	1010,	335, 0, 0, 0, 0, 0, 0, 12 )
 go
 insert into menu_config values ( 5, 0,  703,  625,		10,		320,	95, 0, 0, 0, 0, 0, 0, 12 )
 go
 insert into menu_config values ( 5, 0,  704,  780,		450,	235,	320, 0, 0, 0, 0, 0, 0, 12 )
 go
 insert into menu_config values ( 5, 0,  707,  5,		450,	770,	310, 0, 0, 0, 0, 0, 0, 12 )
 go
 
 -- Functions
 insert into menu_config values ( 5, 1,  701,  10,		20,		600,	75, 0, 0, 0, 0, 0, 0, 12 )
 go
 insert into menu_config values ( 5, 1,  702,  5,		110,	1010,	335, 0, 0, 0, 0, 0, 0, 12 )
 go
 insert into menu_config values ( 5, 1,  703,  625,		10,		320,	95, 0, 0, 0, 0, 0, 0, 12 )
 go
 insert into menu_config values ( 5, 1,  704,  780,		450,	235,	320, 0, 0, 0, 0, 0, 0, 12 )
 go
 insert into menu_config values ( 5, 1,  706,  5,		450,	770,	310, 0, 0, 0, 0, 0, 0, 12 )
 go
 
 
  -- Currency
 insert into menu_config values ( 5, 2,  701,  10,		20,		600,	75, 0, 0, 0, 0, 0, 0, 12 )
 go
 insert into menu_config values ( 5, 2,  702,  5,		110,	1010,	335, 0, 0, 0, 0, 0, 0, 12 )
 go
 insert into menu_config values ( 5, 2,  703,  625,		10,		320,	95, 0, 0, 0, 0, 0, 0, 12 )
 go
 insert into menu_config values ( 5, 2,  704,  780,		450,	235,	320, 0, 0, 0, 0, 0, 0, 12 )
 go
 insert into menu_config values ( 5, 2,  705,  5,		450,	770,	310, 0, 0, 0, 0, 0, 0, 12 )
 go
 
 
 
 
 
  

 
 
 
 
 
   

 