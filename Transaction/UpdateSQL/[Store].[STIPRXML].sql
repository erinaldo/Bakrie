
GO

/****** Object:  StoredProcedure [Store].[STIPRXML]    Script Date: 01/12/2014 16:19:15 ******/
DROP PROCEDURE [Store].[STIPRXML]
GO

/****** Object:  StoredProcedure [Store].[STIPRXML]    Script Date: 01/12/2014 16:19:15 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [Store].[STIPRXML]
	-- Add the parameters for the stored procedure here
	@ID as nvarchar(50)
AS
BEGIN
if @ID is null
begin
SELECT    Store.STIPR.CreatedBy AS creator, Store.STIPR.RequiredFor AS descr, 'Create' AS reqStatus, Store.STMaster.StockDesc AS LTName, 'approver' AS nextRoleId, 
                         Store.STIPR.IPRdate AS orderDate, Store.STIPRDetail.EstateID AS businessUnitCode, Store.STIPRDetail.RequestedQty AS quantity, 
                         Store.STIPRDetail.CreatedBy AS requisitioner, 'false' AS isRequisitionOnly, Store.STMaster.StockCode AS itemCode,Store.STMaster.StockDesc AS description, General.UOM.UOM AS unitOfMeasure, 
                         Store.STIPRDetail.UnitPrice AS unitPrice, Accounts.COA.COACode AS costCentreCode, 'IDR' AS currencyCode, Store.STIPRDetail.Id
FROM            Store.STIPRDetail LEFT OUTER JOIN
                         Store.STIPR ON Store.STIPRDetail.STIPRID = Store.STIPR.STIPRID LEFT OUTER JOIN
                         Accounts.COA ON Store.STIPR.UsageCOAID = Accounts.COA.COAID AND Store.STIPR.UsageCOAID = Accounts.COA.COAID LEFT OUTER JOIN
                         Store.STMaster ON Store.STIPRDetail.StockID = Store.STMaster.StockID LEFT OUTER JOIN
                         General.UOM ON Store.STMaster.UOMID = General.UOM.UOMID
end
else
SELECT    Store.STIPR.CreatedBy AS creator, Store.STIPR.RequiredFor AS descr, 'Create' AS reqStatus, Store.STMaster.StockDesc AS LTName, 'approver' AS nextRoleId, 
                         Store.STIPR.IPRdate AS orderDate, Store.STIPRDetail.EstateID AS businessUnitCode, Store.STIPRDetail.RequestedQty AS quantity, 
                         Store.STIPRDetail.CreatedBy AS requisitioner, 'false' AS isRequisitionOnly, Store.STMaster.StockCode AS itemCode, Store.STMaster.StockDesc AS description,General.UOM.UOM AS unitOfMeasure, 
                         Store.STIPRDetail.UnitPrice AS unitPrice, Accounts.COA.COACode AS costCentreCode, 'IDR' AS currencyCode, Store.STIPRDetail.Id
FROM            Store.STIPRDetail LEFT OUTER JOIN
                         Store.STIPR ON Store.STIPRDetail.STIPRID = Store.STIPR.STIPRID LEFT OUTER JOIN
                         Accounts.COA ON Store.STIPR.UsageCOAID = Accounts.COA.COAID AND Store.STIPR.UsageCOAID = Accounts.COA.COAID LEFT OUTER JOIN
                         Store.STMaster ON Store.STIPRDetail.StockID = Store.STMaster.StockID LEFT OUTER JOIN
                         General.UOM ON Store.STMaster.UOMID = General.UOM.UOMID
Where STIPRDetail.Id = @ID
END

GO


