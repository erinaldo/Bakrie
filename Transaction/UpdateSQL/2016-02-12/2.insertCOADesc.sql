DECLARE @COAID nvarchar(50)
DECLARE @MaxID as int	
DECLARE cData CURSOR FOR   
  select a.COAID from Accounts.COA a 
left join Accounts.COADescription b on a.COAID = b.COAID
where len(a.COAID) = 20 and b.COAID is null
Open cData  
FETCH NEXT FROM cData  
INTO  @COAID
     
WHILE @@FETCH_STATUS = 0 
BEGIN
	--Print 
	insert into Accounts.COADescription(COAID,ActivityDescription) values (@COAID,Checkroll.ConcatenateActivityCOA2(@Coaid))
   FETCH NEXT FROM cData  
     INTO @COAID
         
 END  
  CLOSE cData  
 DEALLOCATE cData 
