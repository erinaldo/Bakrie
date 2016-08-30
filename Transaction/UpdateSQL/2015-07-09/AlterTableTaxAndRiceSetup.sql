ALTER TABLE Checkroll.TaxAndRiceSetup ADD
	RANaturaPrice numeric(18, 2) NULL
GO
UPDATE Checkroll.TaxAndRiceSetup SET RANaturaPrice = 0
GO