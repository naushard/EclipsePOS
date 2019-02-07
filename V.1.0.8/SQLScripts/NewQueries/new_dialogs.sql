use possite

go


delete from dialog_event;

go

delete from dialog;

go

insert into dialog values (1601,  1, 'Logon') 
go

insert into dialog_event values ( 1601, 1,  null, 0,  1, 1, 'EclipsePos.Apps.PosEvents.RegisterOpen') 
go
insert into dialog_event values ( 1601, 3,  null, 0,  1, 1, 'EclipsePos.Apps.PosEvents.NewLogon') 
go
insert into dialog_event values ( 1601, 4,  null, 0,  1, 1, 'EclipsePos.Apps.PosEvents.LogOn') 
go



insert into dialog values (1602,  1, 'ManagerRequired') 
go


insert into dialog_event values ( 1602, 1,  null, 1005, 1, 1, 'EclipsePos.Apps.PosEvents.Error') 
go
insert into dialog_event values ( 1602, 2,  null, 29,   1, 1, 'EclipsePos.Apps.PosEvents.UserValidation') 
go
insert into dialog_event values ( 1602, 4,  null, 30,   1, 1, null) 
go
insert into dialog_event values ( 1602, 4,  null, 70,   1, 1, null) 
go



insert into dialog values (1603,   1, 'CashTender') 
go


insert into dialog_event values ( 1603, 1,  null, 0, 1, 1, 'EclipsePos.Apps.PosEvents.RegisterOpen') 
go
insert into dialog_event values ( 1603, 2,  null, 0, 1, 1, 'EclipsePos.Apps.PosEvents.FinishTransaction') 
go
insert into dialog_event values ( 1603, 3,  null, 0, 1, 1, 'EclipsePos.Apps.PosEvents.CloseCashDrawer') 
go
insert into dialog_event values ( 1603, 4,  null, 0, 1, 1, 'EclipsePos.Apps.PosEvents.PromptPrintReceipt') 
go
insert into dialog_event values ( 1603, 5,  null, 0, 1, 1, 'EclipsePos.Apps.EJournal.EjTender')
go
insert into dialog_event values ( 1603, 6,  null, 0, 1, 1, 'EclipsePos.Apps.PosEvents.AutoRoundingAdjustment')
go
insert into dialog_event values ( 1603, 7,  null, 0, 1, 1, 'EclipsePos.Apps.EJournal.EjSalesPerson') 
go
insert into dialog_event values ( 1603, 8,  null, 0, 1, 1, 'EclipsePos.Apps.PosEvents.CheckHardware') 
go


insert into dialog values (1604,  1, 'CheckTender') 
go



insert into dialog_event values ( 1604, 1,  null, 0,  1, 1, 'EclipsePos.Apps.PosEvents.RegisterOpen') 
go
insert into dialog_event values ( 1604, 3,  null, 0, 1, 1, 'EclipsePos.Apps.PosEvents.FinishTransaction') 
go
insert into dialog_event values ( 1604, 4,  null, 0, 1, 1, 'EclipsePos.Apps.PosEvents.CloseCashDrawer') 
go
insert into dialog_event values ( 1604, 5,  null, 0, 1, 1, 'EclipsePos.Apps.PosEvents.PromptPrintReceipt') 
go
insert into dialog_event values ( 1604, 6, null, 5, 1, 1, 'EclipsePos.Apps.EJournal.EjCheckTender')  
go
insert into dialog_event values ( 1604, 7,  null, 2, 1, 1, null) 
go
insert into dialog_event values ( 1604, 8,  null, 1, 1, 1, null) 
go
insert into dialog_event values ( 1604, 9,  null, 0, 1, 1, 'EclipsePos.Apps.EJournal.EjSalesPerson') 
go
insert into dialog_event values ( 1604, 10,  null, 0, 1, 1, 'EclipsePos.Apps.PosEvents.CheckHardware') 
go


insert into dialog values (1605,  1, 'CreditTender') 
go



insert into dialog_event values (  1605, 1,  null, 0,  1, 1, 'EclipsePos.Apps.PosEvents.RegisterOpen') 
go
insert into dialog_event values (  1605, 3,  null, 0, 1, 1, 'EclipsePos.Apps.PosEvents.FinishTransaction') 
go
insert into dialog_event values (  1605, 4,  null, 0, 1, 1, 'EclipsePos.Apps.PosEvents.CloseCashDrawer') 
go
insert into dialog_event values (  1605, 5,  null, 0, 1, 1, 'EclipsePos.Apps.PosEvents.PromptPrintReceipt') 
go
insert into dialog_event values (  1605, 6,  null, 0, 1, 1, 'EclipsePos.Apps.EJournal.EjCCTender') 
go
insert into dialog_event values (  1605, 7,  null, 0, 1, 1, 'EclipsePos.Apps.EJournal.EjSalesPerson') 
go
insert into dialog_event values (  1605, 8,  null, 0, 1, 1, 'EclipsePos.Apps.PosEvents.CheckHardware') 
go




insert into dialog values (1606,  1, 'AltCurrTender') 
go



insert into dialog_event values (  1606, 1,  null, 0, 1, 1, 'EclipsePos.Apps.PosEvents.RegisterOpen') 
go
insert into dialog_event values (  1606, 2,  null, 0, 1, 1, 'EclipsePos.Apps.PosEvents.FinishTransaction') 
go
insert into dialog_event values (  1606, 3,  null, 0, 1, 1, 'EclipsePos.Apps.PosEvents.CloseCashDrawer') 
go
insert into dialog_event values (  1606, 4,  null, 0, 1, 1, 'EclipsePos.Apps.PosEvents.PromptPrintReceipt') 
go
insert into dialog_event values ( 1606,  5,  null, 0, 1, 1, 'EclipsePos.Apps.EJournal.EjSalesPerson') 
go
insert into dialog_event values (  1606, 6,  null, 1, 1, 1, 'EclipsePos.Apps.EJournal.EjAltCurrTender') 
go



insert into dialog values (1607,  1, 'RecallEj') 
go


insert into dialog_event values (  1607, 1,  null, 5, 1, 1, 'EclipsePos.Apps.PosEvents.RecallEj') 
go
insert into dialog_event values (  1607, 2,  null, 2, 1, 1, null) 
go
insert into dialog_event values (  1607, 3,  null, 1, 1, 1, null) 
go



insert into dialog values (1608, 1, 'PaidIn') 
go
insert into dialog_event values ( 1608, 1,  null, 0, 1, 1, 'EclipsePos.Apps.PosEvents.RegisterOpen') 
go
insert into dialog_event values ( 1608, 2,  null, 0, 1, 1, 'EclipsePos.Apps.PosEvents.FinishTransaction') 
go
insert into dialog_event values ( 1608, 3,  null, 0, 1, 1, 'EclipsePos.Apps.PosEvents.CloseCashDrawer') 
go
insert into dialog_event values ( 1608, 4,  null, 0, 1, 1, 'EclipsePos.Apps.PosEvents.PromptPrintReceipt') 
go
insert into dialog_event values ( 1608,  5, null, 1, 1, 1, 'EclipsePos.Apps.EJournal.EjFreeText') 
go
insert into dialog_event values ( 1608, 6,  null, 1, 1, 1, 'EclipsePos.Apps.EJournal.EjBank') 
go
insert into dialog_event values ( 1608, 7,  null, 0, 1, 1, 'EclipsePos.Apps.PosEvents.StartTransaction') 
go



insert into dialog values (1609,  1, 'PaidOut') 
go
insert into dialog_event values (  1609, 1, null, 0, 1, 1, 'EclipsePos.Apps.PosEvents.RegisterOpen') 
go
insert into dialog_event values (  1609, 2,  null, 0, 1, 1, 'EclipsePos.Apps.PosEvents.FinishTransaction') 
go
insert into dialog_event values (  1609, 3,  null, 0, 1, 1, 'EclipsePos.Apps.PosEvents.CloseCashDrawer') 
go
insert into dialog_event values (  1609, 4,  null, 0, 1, 1, 'EclipsePos.Apps.PosEvents.PromptPrintReceipt') 
go
insert into dialog_event values (  1609, 5,  null, 1, 1, 1, 'EclipsePos.Apps.EJournal.EjFreeText') 
go
insert into dialog_event values (  1609, 6,  null, 2, 1, 1, 'EclipsePos.Apps.EJournal.EjBank') 
go
insert into dialog_event values (  1609, 7, null, 0, 1, 1, 'EclipsePos.Apps.PosEvents.StartTransaction') 
go




insert into dialog values (1611, 1, 'PettyCash') 
go


insert into dialog_event values (  1611, 1,  null, 0, 1, 1, 'EclipsePos.Apps.PosEvents.RegisterOpen') 
go
insert into dialog_event values (  1611, 3,  null, 0, 1, 1, 'EclipsePos.Apps.PosEvents.FinishTransaction') 
go
insert into dialog_event values (  1611, 4,  null, 0, 1, 1, 'EclipsePos.Apps.PosEvents.CloseCashDrawer') 
go
insert into dialog_event values (  1611, 5,  null, 1, 1, 1, 'EclipsePos.Apps.EJournal.EjBank') 
go


insert into dialog values (1612, 1, 'UnLock') 
go



insert into dialog_event values (  1612, 1,  null, 2, 1, 1, 'EclipsePos.Apps.PosEvents.UnLock') 
go
insert into dialog_event values (  1612, 2,  null, 0, 1, 1, null) 
go



insert into dialog values (1613, 1, 'Customer') 
go



insert into dialog_event values (  1613, 1,  null, 2, 1, 1, 'EclipsePos.Apps.EJournal.EjCustomer') 
go
insert into dialog_event values (  1613, 2,  null, 1, 1, 1, null) 
go



insert into dialog values (1614, 1, 'DebtTender') 
go


insert into dialog_event values (  1614, 1,  null, 0,  1, 1, 'EclipsePos.Apps.PosEvents.RegisterOpen') 
go
insert into dialog_event values (  1614, 3,  null, 0, 1, 1, 'EclipsePos.Apps.PosEvents.FinishTransaction') 
go
insert into dialog_event values (  1614, 4,  null, 0, 1, 1, 'EclipsePos.Apps.PosEvents.CloseCashDrawer') 
go
insert into dialog_event values (  1614, 5,  null, 0, 1, 1, 'EclipsePos.Apps.PosEvents.PromptPrintReceipt') 
go
insert into dialog_event values (  1614, 6,  null, 1, 1, 1, 'EclipsePos.Apps.EJournal.EjDebtTender') 
go
insert into dialog_event values (  1614, 7,  null, 0, 1, 1, 'EclipsePos.Apps.EJournal.EjSalesPerson') 
go
insert into dialog_event values (  1614, 8,  null, 0, 1, 1, 'EclipsePos.Apps.PosEvents.CheckHardware') 
go



insert into dialog values (1615, 1, 'ReceiveOnAccount') 
go


insert into dialog_event values (  1615, 1,  null, 1, 1, 1, 'EclipsePos.Apps.EJournal.EjReceiveOnAccount') 
go
insert into dialog_event values (  1615, 2, null, 0, 1, 1, 'EclipsePos.Apps.PosEvents.StartTransaction') 
go
insert into dialog_event values (  1615, 3,  null, 0, 1, 1, 'EclipsePos.Apps.EJournal.EjSalesPerson') 
go
insert into dialog_event values (  1615, 4,  null, 0, 1, 1, 'EclipsePos.Apps.PosEvents.CheckHardware') 
go



insert into dialog values (1616,  1, 'DebitCardTender') 
go


insert into dialog_event values (  1616, 1,  null, 0,  1, 1, 'EclipsePos.Apps.PosEvents.RegisterOpen') 
go
insert into dialog_event values ( 1616, 3,  null, 0, 1, 1, 'EclipsePos.Apps.PosEvents.FinishTransaction') 
go
insert into dialog_event values ( 1616, 4,  null, 0, 1, 1, 'EclipsePos.Apps.PosEvents.CloseCashDrawer') 
go
insert into dialog_event values ( 1616, 5,  null, 0, 1, 1, 'EclipsePos.Apps.PosEvents.PromptPrintReceipt') 
go
insert into dialog_event values (  1616, 6, null, 5, 1, 1, 'EclipsePos.Apps.EJournal.EjDebitCardTender')  
go
insert into dialog_event values (  1616, 7,  null, 2, 1, 1, null) 
go
insert into dialog_event values (  1616, 8,  null, 1, 1, 1, null) 
go
insert into dialog_event values (  1616, 9,  null, 0, 1, 1, 'EclipsePos.Apps.EJournal.EjSalesPerson') 
go
insert into dialog_event values (  1616, 10,  null, 0, 1, 1, 'EclipsePos.Apps.PosEvents.CheckHardware') 
go



insert into dialog values (1617, 1, 'AddSalesPerson') 
go


insert into dialog_event values (  1617, 1,  null, 0, 1, 1, 'EclipsePos.Apps.PosEvents.RegisterOpen') 
go
insert into dialog_event values (  1617, 2,  null, 0, 1, 1, 'EclipsePos.Apps.EJournal.EjSalesPerson') 
go



insert into dialog values (1618, 1, 'FastSale') 
go


insert into dialog_event values ( 1618, 1,  null, 0, 1, 1, 'EclipsePos.Apps.PosEvents.RegisterOpen') 
go
insert into dialog_event values ( 1618, 2,  null, 0, 1, 1, 'EclipsePos.Apps.PosEvents.FinishTransaction') 
go
insert into dialog_event values ( 1618, 3,  null, 0, 1, 1, 'EclipsePos.Apps.PosEvents.CloseCashDrawer') 
go
insert into dialog_event values ( 1618, 4,  null, 0, 1, 1, 'EclipsePos.Apps.PosEvents.PromptPrintReceipt') 
go
insert into dialog_event values ( 1618, 5,  null, 0, 1, 1, 'EclipsePos.Apps.EJournal.EjTender')
go
insert into dialog_event values ( 1618, 6,  null, 0, 1, 1, 'EclipsePos.Apps.PosEvents.AutoRoundingAdjustment')
go
insert into dialog_event values ( 1618, 7,  null, 0, 1, 1, 'EclipsePos.Apps.EJournal.EjSalesPerson') 
go
insert into dialog_event values ( 1618, 8,  null, 0, 1, 1, 'EclipsePos.Apps.PosEvents.CheckHardware') 
go
insert into dialog_event values (  1618, 9,  null, 0, 1, 1, 'EclipsePos.Apps.PosEvents.QuickSaleItem') 
go


