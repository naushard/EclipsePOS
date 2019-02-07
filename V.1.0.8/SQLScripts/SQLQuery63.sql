
use possite
go


select store_name, trans_item.trans_no, trans_item.line_no as sales_line, trans_item.seq_no, 
sku, item_desc, cast (quantity as decimal(5,0)) as qty, amount, ext_amount, promo.amt as promo_amt, [possite].[dbo].[ufn_Addition](ext_amount, promo.amt) as net_sales,  cast( [possite].[dbo].[ufn_GetDateOnly](start_time) as varchar(12 ) ) as sales_date, trans.store_no  
from trans_item join trans 
on (trans_item.trans_no = trans.trans_no and 
trans_item.organization_no = trans.organization_no and 
trans_item.store_no = trans.store_no ) 
left outer join 
(SELECT trans_promotion.organization_no, trans_promotion.store_no,  trans_promotion.trans_no, trans_promotion.line_no, sum(trans_promotion.promotion_amount) amt 
FROM trans_promotion 
group by trans_promotion.organization_no, trans_promotion.store_no, trans_promotion.trans_no, trans_promotion.line_no) 
AS promo   
on (trans_item.organization_no = promo.organization_no and trans_item.store_no = promo.store_no and trans_item.trans_no = promo.trans_no and trans_item.line_no = promo.line_no )
left outer join retail_store on
(trans.store_no=retail_store.store_no and trans.organization_no = retail_store.organization_no ) 
where trans.state = 2 
and trans_item.state = 2 
and trans.organization_no >= '40' and trans.organization_no <= '40' 
and trans.store_no >= '3' and trans.store_no <= '3' 
order by store_name, sales_date, trans_item.trans_no, trans_item.line_no

go 