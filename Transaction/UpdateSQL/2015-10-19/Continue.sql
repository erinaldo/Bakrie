


insert into Accounts.COADescription(COAID,ActivityDescription)
Select COAID,Checkroll.ConcatenateActivityCOA(Coaid) from Accounts.COA where LEN(COAid) = 20 and left(COAID,2) = 72
