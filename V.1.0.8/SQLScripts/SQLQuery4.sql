use possite
go
declare  @organizationFrom int 
declare  @organizationTo int  
declare @storeFrom int 
declare @storeTo int  

set @organizationFrom = 1
set  @organizationTo = 12
set   @storeFrom = 1
set  @storeTo = 12

select store_name, trans_tender.trans_no, amount, tender_desc, 
                               [possite].[dbo].[ufn_GetDateOnly](start_time) as trans_date 
                                from trans_tender join trans 
                                on  (trans_tender.trans_no = trans.trans_no and trans_tender.organization_no = trans.organization_no) 
                                join retail_store on 
                                (trans.store_no=retail_store.store_no) 
                                where trans.state = 2 
                                and trans.organization_no >= @organizationFrom and trans.organization_no <= @organizationTo 
                                and trans.store_no >= @storeFrom and trans.store_no <= @storeTo 
                                order by store_name, trans_date, trans_tender.trans_no 
    