use possite

go

delete from dialog_event
where dialog_id = 1604

go

delete from dialog 
where dialog_id = 1604

go




insert into dialog values (1604,  1, 'ChequeTender') 
go



insert into dialog_event values ( 1604, 1,  null, 0,  1, 1, 'EclipsePos.Apps.PosEvents.RegisterOpen') 
go
insert into dialog_event values ( 1604, 3,  null, 0, 1, 1, 'EclipsePos.Apps.PosEvents.FinishTransaction') 
go
insert into dialog_event values ( 1604, 4,  null, 0, 1, 1, 'EclipsePos.Apps.PosEvents.CloseCashDrawer') 
go
insert into dialog_event values ( 1604, 5,  null, 0, 1, 1, 'EclipsePos.Apps.PosEvents.PromptPrintReceipt') 
go
insert into dialog_event values ( 1604, 6, null, 5, 1, 1, 'EclipsePos.Apps.EJournal.EjChequeTender')  
go
insert into dialog_event values ( 1604, 7,  null, 2, 1, 1, null) 
go
insert into dialog_event values ( 1604, 8,  null, 1, 1, 1, null) 
go
insert into dialog_event values ( 1604, 9,  null, 0, 1, 1, 'EclipsePos.Apps.EJournal.EjSalesPerson') 
go
insert into dialog_event values ( 1604, 10,  null, 0, 1, 1, 'EclipsePos.Apps.PosEvents.CheckHardware') 
go