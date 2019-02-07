use possite

go 

delete from pos_key 
where config_no = 5 and panel_id = 991

go

-- Navigator

insert into pos_key values (5, 991,	'Change Qty',	1,   6,   511112,		3,	20,		8,	48,		118,		90,		192,	90,	null,1, 'EclipsePos.Apps.PosEvents.ChangeQuantity', 'Qty', 'ChangeQty.png')
go
insert into pos_key values (5, 991,	'Change Price',	1,   91,   511113,		3,	140,	8,  48,		118,		91,		192,	91,	null,1, 'EclipsePos.Apps.PosEvents.PriceOverride', 'Change Price', 'ChangePrice.png')
go
insert into pos_key values (5, 991,	'Add Text',		1,   92,   511114,		3,	260,	8,  48,		118,		93,		192,	92,	null,1, 'EclipsePos.Apps.PosEvents.FreeText', 'Free Text', 'FreeText.png')
go
insert into pos_key values (5, 991,	'Void Item',	1,   93,   511115,		3,	380,	8,  48,		118,		94,		192,	93,	null,1, 'EclipsePos.Apps.PosEvents.ItemVoid', 'Void Item', 'VoidItem.png')
go
insert into pos_key values (5, 991,	'Void Sales',	1,   2,   511116,		3,	500,	8,  48,		118,		95,		192,	94,	null,1, 'EclipsePos.Apps.PosEvents.VoidSale', 'Void Sale', 'VoidSales.png')
go
insert into pos_key values (5, 991,	'Open Drawer',	1,   0,   511117,		3,  860,	8,  48,		56,			97,		192,	95,	null,1, 'EclipsePos.Apps.PosEvents.OpenDrawer', 'Open Drawer','OpenDrawer.png')


insert into pos_key values (5, 991,	'Discounts',	1,   6,   511118,		3,	20,		8,	48,		118,		97,		192,	90,	null,1, 'EclipsePos.Apps.PosEvents.MenuNavigator', 'Discounts', 'Discount.png')
go
insert into pos_key values (5, 991,	'Save Order',	1,   91,   511119,		3,	140,	8,  48,		118,		98,		192,	91,	null,1, 'EclipsePos.Apps.PosEvents.SaveEj', 'Save Order', 'SaveOrder.png')
go
insert into pos_key values (5, 991,	'Recall Order',	1,   92,   511120,		3,	260,	8,  48,		118,		99,		192,	92,	null,1, 'EclipsePos.Apps.PosEvents.RecallEj', 'Recall Order', 'RecallOrder.png')
go
insert into pos_key values (5, 991,	'Manager Menu',	1,   4,   511121,		3,	380,	8,  48,		118,		100,	192,	94,	null,1, 'EclipsePos.Apps.PosEvents.MenuNavigator', 'Cash Tender', 'Manager.png')
go
insert into pos_key values (5, 991,	'Tender',		1,   2,   511122,		3,	500,	8,  48,		118,		101,	192,	94,	null,1, 'EclipsePos.Apps.PosEvents.MenuNavigator', 'Tender', 'Tender.png')
go
insert into pos_key values (5, 991,	'More Options',	1,   3,   123,		3,	860,	8,  48,		118,		102,	192,	95,	null,1, 'EclipsePos.Apps.PosEvents.MenuNavigator', 'Menu', 'MoreOptions.png')
go

		




delete from pos_key 
where config_no = 5 and panel_id = 93
go

insert into pos_key values (5, 93,	'Return Sale',		1,   0,  19071,		3, 170,			432,		48, 56, 97,	192,	131186,	null,1, 'EclipsePos.Apps.PosEvents.ReturnSale','Return Sale','F4')
go

insert into pos_key values (5, 93,	'Add S/Staff',		1,   0,  19072,		3,	860,		8,			48,	118,96,	192,	131189,	null,1, 'EclipsePos.Apps.PosEvents.LDAddSalesPerson', 'Add S/Staff', 'F4')
go

insert into pos_key values (5, 93,	'Remove S/Staff',	1,   0,  19073,		3,	860,		8,			48,	118,96,	192,	131190,	null,1, 'EclipsePos.Apps.PosEvents.RemoveSalesPerson', 'Remove S/Staff', 'F4')
go