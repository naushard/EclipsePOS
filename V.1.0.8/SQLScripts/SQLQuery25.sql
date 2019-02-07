

use possite

go 

select * from retail_store 
left outer join  customer
on( retail_store.organization_no = customer.organization_no and
retail_store.customer_tax_id = customer.tax_id)

go 