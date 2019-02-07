use possite

go

select trans.trans_no, trans_type, trans.state, tendertype, amount, change_amt, amount-change_amt as sales_amt, tender_desc, start_time, complete_time, trans_sales_person.employee_no
from trans 
left outer join trans_tender
on ( trans.trans_no = trans_tender.trans_no and trans.organization_no = trans_tender.organization_no and trans.store_no = trans_tender.store_no and trans.pos_no = trans_tender.pos_no )  
left outer join trans_sales_person
on (trans.trans_no = trans_sales_person.trans_no and trans.organization_no = trans_sales_person.organization_no and trans.store_no = trans_sales_person.store_no and trans.pos_no = trans_sales_person.pos_no )
where trans.organization_no = '40' and trans.store_no = '3' and trans.pos_no = '85' and
trans.trans_no >=  ( select top 1 start_receipt_no from pos_total where total_name = 1 and end_date = 0 and pos_total.organization_no = '40' and pos_total.store_no = '3' and pos_total.pos_no = 85 )
order by trans.trans_no DESC