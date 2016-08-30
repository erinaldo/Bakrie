Alter table weighbridge.WbWeighingINOut
	ADD  BarcodeEntry nvarchar(200),
	BarcodeExit nvarchar(200),
	WeighingDate2 datetime,
	WeighingTime2 datetime, 
	DO nvarchar(50),
	Username nvarchar(50),
	AfterDeductionWeight numeric(18,3)

	--select * from Weighbridge.WBWeighingInOut