use possite

go
delete from dialog_event where dialog_id = 1603

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
insert into dialog_event values ( 1603, 7,  null, 0, 1, 1, 'EclipsePos.Apps.PosEvents.CheckHardware') 
go


