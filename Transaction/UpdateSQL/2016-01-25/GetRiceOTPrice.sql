
/****** Object:  StoredProcedure [Checkroll].[CRTAXSumOTPremi]    Script Date: 25/1/2016 12:22:49 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO











-- =============================================
-- Author:		<Agung Batricorsila,,Name>
-- Create date: <Sabtu, 17 Oct 2009,,>
-- Modifed date:<Sunday, 18 Oct 2009, 16:33>
-- Description:	<Description,,>
-- =============================================

CREATE PROCEDURE [Checkroll].[GETOTRicePrice]
@EstateID as nvarchar(50)

AS

SELECT  RAPRice from Checkroll.TaxAndRiceSetup
where  EstateID =@EstateID 








