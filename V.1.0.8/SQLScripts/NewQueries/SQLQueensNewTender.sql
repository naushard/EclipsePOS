

use possite

go

delete from pos_key where  config_no = 5 and panel_id = 993

go

delete from pos_key where  config_no = 5 and panel_id = 94

go







-- Credit card types

delete from card_media where organization_no = '40'

go



insert into card_media values ('40', 1, 'NETS', 1, 'Network for electroic transfers (S) Pte Ltd', Null,  401)
go
insert into card_media values ('40', 2, 'Ez-Link', 1, 'Ez-Link', Null,  402)
go
insert into card_media values ('40', 3, 'VISA', 2, 'Visa International', Null,  421)
go
insert into card_media values ('40', 4, 'MASTER', 2, 'Master International', null, 422)
go
insert into card_media values ('40', 5, 'DINNERS', 2, 'Dinners International', Null,  423);
go
insert into card_media values ('40', 6, 'AMEX', 2, 'American Express', Null,  424);
go
insert into card_media values ('40', 7, 'DISCOVER', 2, 'Discover', Null,  425);
go
insert into card_media values ('40', 8, 'DINERS', 2, 'Diners club', Null,  426);
go



-- Tender
insert into pos_key values (5, 94,		'Ctrl' ,		1,   0,		1031,		3, 170,			40,		48, 56,	90,	192,	131184,	null,	1, 'EclipsePos.Apps.PosEvents.CashTender','Cash ','F1')
go

insert into pos_key values (5, 94,		'Ctrl',			1,   0,		1032,		3, 170,			89,		48, 56, 91,	192,	131185,	null,	1, 'EclipsePos.Apps.PosEvents.CheckTender','Check ','F2')
go

insert into pos_key values (5, 94,		'Ctrl' ,		1,   3,		1101,		3,	 170,		40,		48,  56, 90,	0, 131188, null, 	1,	'EclipsePos.Apps.PosEvents.CreditTender', 'VISA', 'Visa.gif')
go

insert into pos_key values (5, 94,		'Ctrl',			1,   4,		1102,		3,	170,		89,		48,  56, 91,	0, 131189, null, 	1,	'EclipsePos.Apps.PosEvents.CreditTender', 'MASTER','MasterCard.gif')
go

insert into pos_key values (5, 94,		'Ctrl',			1,   6,		1103,		3,	170,		138,	48,  56, 92,	0, 131190, null, 	1,	'EclipsePos.Apps.PosEvents.CreditTender', 'AMEX','Amex.gif')
go

insert into pos_key values (5, 94,		'Ctrl',			1,   8,		1106,		3,	170,		187,	48,  56, 93,	0, 131191,  null, 	1,	'EclipsePos.Apps.PosEvents.CreditTender', 'DINERS CLUB','DinersClub.png')
go

insert into pos_key values (5, 94,		'Ctrl',			1,   7,		1104,		3,	170,		187,	48,  56, 93,	0, 131191,  null, 	1,	'EclipsePos.Apps.PosEvents.CreditTender', 'DISCOVER','Discover.gif')
go

insert into pos_key values (5, 94,		'Ctrl',			1,   1,		1105,		3,	170,		236,	48,  56, 94,	0, 131192,	null,	1,	'EclipsePos.Apps.PosEvents.CreditTender', 'NETS','Nets.jpg')
go
