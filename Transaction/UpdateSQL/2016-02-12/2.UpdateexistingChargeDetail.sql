DECLARE @VHID nvarchar(50)
DECLARE @Value numeric(18,3)
DECLARE @Amonth int
DECLARE @Ayear int



Declare @ID int	
DECLARE cData CURSOR FOR   
  select b.VHID,a.Value,a.AMonth,a.AYear,a.Id from Vehicle.VHChargeDetail a
inner join Vehicle.VHMaster b on a.VHWSCode = b.VHWSCode 
where a.LedgerType = 'STORE-SIV'
Open cData  
FETCH NEXT FROM cData  
INTO  @VHID,@Value,@Amonth,@Ayear,@ID
WHILE @@FETCH_STATUS = 0 
BEGIN

	WHILE @@FETCH_STATUS = 0 
BEGIN
	DECLARE @Qty numeric(18,3)
	DECLARE @UOMID nvarchar(50)
	DECLARE @SIVID nvarchar(50)

	select top 1  @qty = std.IssuedQty - ISNULL(std.ReturnQty,0),@SIVID = SIVNO,@UOMID = General.uom.UOM from store.STIssueDetails std
	inner join store.STIssue st on std.STIssueID = st.STIssueID
	inner join store.STMaster stm on std.StockID = stm.StockID
	left join General.UOM on stm.UOMID = General.uom.UOMID
	where vhid = @Vhid and stm.StdPrice = @Value and MOnth(SivDate) = @Amonth and Year(SivDate) = @Ayear

	UPDATE Vehicle.VHChargeDetail set uomid = @UOMID, QTyUsed = @Qty, RefNo = @SIVID where id = @ID

   FETCH NEXT FROM cData  
     INTO  @VHID,@Value,@Amonth,@Ayear,@ID
         
 END  
  CLOSE cData  
 DEALLOCATE cData 
 	Update Vehicle.VHChargeDetail set UOMID = 'HK' where LedgerType = 'Checkroll'
 END