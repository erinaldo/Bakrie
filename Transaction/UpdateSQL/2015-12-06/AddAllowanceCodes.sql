DECLARE @EstateID nvarchar(50)
select @EstateID = EstateID from General.Estate

Insert Into checkroll.AllowanceDeductionSetup(AllowDedID,EstateID,Type,AllowDedCode,Remarks,COAID,PPH,NoTransferToSalary,FixedAllowance)
VALUES
('BSP04R82',@EstateID,'A','A43','Premi Mandor Panen','11-01-01-01-01-001M1','Y',0,0),
('BSP04R83',@EstateID,'A','A44','Premi Mandor Deres','11-01-01-01-01-001M1','Y',0,0),
('BSP04R84',@EstateID,'A','A45','Premi Kerani Panen','11-01-01-01-01-001M1','Y',0,0),
('BSP04R85',@EstateID,'A','A46','Premi Kerani Deres','11-01-01-01-01-001M1','Y',0,0),
('BSP04R86',@EstateID,'A','A47','Premi Mandor Besar','11-01-01-01-01-001M1','Y',0,0);




