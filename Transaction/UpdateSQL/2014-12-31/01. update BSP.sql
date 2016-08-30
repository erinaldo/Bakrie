insert into KeyValuePairs values('RateSetupLevel',0,null)

go

ALTER TABLE Checkroll.CREmployee ADD
	Grade nvarchar(100) NULL,
	[Level] nvarchar(100) NULL

go