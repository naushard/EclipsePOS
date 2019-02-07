use possite1;

go 


select trans.trans_no, trans_type, trans.state, tendertype, amount, change_amt, tender_desc, start_time, complete_time
from trans 
left outer join trans_tender
on ( trans.trans_no = trans_tender.trans_no and trans.organization_no = trans_tender.organization_no and trans.store_no = trans_tender.store_no and trans.pos_no = trans_tender.pos_no )  
where trans.organization_no = '40' and trans.store_no = '2' and trans.pos_no ='105' and
trans.trans_no >= ( select top 1 start_receipt_no from pos_total where total_name = 1 and end_date = 0 )

go
