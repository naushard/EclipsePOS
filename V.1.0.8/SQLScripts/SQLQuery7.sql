


use possite

go

alter table trans_item

add column  pos_no int not null references pos(pos_no)