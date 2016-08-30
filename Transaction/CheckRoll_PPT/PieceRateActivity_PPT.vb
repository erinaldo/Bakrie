Public Class PieceRateActivity_PPT
    Public Property Id As Integer
    Public Property EstateID As String
    Public Property ActivityBy As String
    Public Property Description As String
    Public Property BlockID As String
    Public Property BlockName As String
    Public Property ReferenceNo As String
    Public Property JobRate As Double
    Public Property MandoreRate As Double
    Public Property KeraniRate As Double
    Public Property Unit As String
    Public Property TotalUnit As Double
    Public Property StartDate As DateTime
    Public Property EndDate As DateTime
    Public Property StationDesc As String
End Class

Public Class PieceRateTransaction_PPT
    Public Property Id As Integer
    Public Property PieceRateActivityId As Integer
    Public Property ActivityDate As Date
    Public Property VHID As String
    Public Property SubStationID As String
    Public Property UnitCompleted As Double
    Public Property Remarks As String
    Public Property EmpID As String
    Public Property ContractID As String
    Public Property CreatedBy As String
    Public Property ModifiedBy As String
    Public Property Production() As Integer
End Class
