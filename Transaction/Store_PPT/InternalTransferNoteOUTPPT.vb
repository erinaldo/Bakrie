Public Class InternalTransferNoteOUTPPT

#Region "Private Member Declarations"

    Private _STInternalTransferOutID As String = String.Empty
    Private _OperatorName As String = String.Empty
    Private _TransportDate As DateTime = DateTime.Now
    Private _VehicleNo As String = String.Empty
    Private _MRCNo As String = String.Empty
    Private _ItnOutNo As String = String.Empty
    Private _ITNDate As Date = Date.Today
    Private _Remarks As String = String.Empty
    Private _Status As String = String.Empty
    Private _RejectedReason As String = String.Empty
    Private _STInternalTransferOutDetailsID As String = String.Empty
    Private _StockID As String = String.Empty
    Private _StockCode As String = String.Empty
    Private _StockDesc As String = String.Empty
    Private _PartNo As String = String.Empty
    Private _AvailQty As Double = 0.0
    Private _UnitPrice As Double = 0.0
    Private _COAID As String = String.Empty
    Private _COACode As String = String.Empty
    Private _TransferOutQty As Double = 0.0
    Private _TransferOutValue As Double = 0.0
    Private _ReceivedLocation As String = String.Empty
    Private _ReceivedLocationSearch As String = String.Empty
    Private _DC As String = String.Empty
    Private _LedgerID As String = String.Empty
    Private _DivID As String = String.Empty
    Private _YopID As String = String.Empty
    Private _BlockID As String = String.Empty
    Private _VHID As String = String.Empty
    Private _VHDetailCostCodeID As String = String.Empty
    Private _T0 As String = String.Empty
    Private _T1 As String = String.Empty
    Private _T2 As String = String.Empty
    Private _T3 As String = String.Empty
    Private _T4 As String = String.Empty
    Private _JournalDetDescp As String = String.Empty
    Private _Flag As String = String.Empty
    Private _Value As Double = 0.0
    Private _StationID As String = String.Empty

#End Region

#Region "Public Member Declarations"

    Public Property STInternalTransferOutID() As String
        Get
            Return _STInternalTransferOutID
        End Get
        Set(ByVal value As String)
            _STInternalTransferOutID = value
        End Set
    End Property
    Public Property OperatorName() As String
        Get
            Return _OperatorName
        End Get
        Set(ByVal value As String)
            _OperatorName = value
        End Set
    End Property
    Public Property TransportDate() As DateTime
        Get
            Return _TransportDate
        End Get
        Set(ByVal value As DateTime)
            _TransportDate = value
        End Set
    End Property
    Public Property VehicleNo() As String
        Get
            Return _VehicleNo
        End Get
        Set(ByVal value As String)
            _VehicleNo = value
        End Set
    End Property
    Public Property MRCNo() As String
        Get
            Return _MRCNo
        End Get
        Set(ByVal value As String)
            _MRCNo = value
        End Set
    End Property
    Public Property ItnOutNo() As String
        Get
            Return _ItnOutNo
        End Get
        Set(ByVal value As String)
            _ItnOutNo = value
        End Set
    End Property
    Public Property ITNDate() As Date
        Get
            Return _ITNDate
        End Get
        Set(ByVal value As Date)
            _ITNDate = value
        End Set
    End Property
    Public Property Remarks() As String
        Get
            Return _Remarks
        End Get
        Set(ByVal value As String)
            _Remarks = value
        End Set
    End Property
    Public Property Status() As String
        Get
            Return _Status
        End Get
        Set(ByVal value As String)
            _Status = value
        End Set
    End Property
    Public Property RejectedReason() As String
        Get
            Return _RejectedReason
        End Get
        Set(ByVal value As String)
            _RejectedReason = value
        End Set
    End Property
    Public Property STInternalTransferOutDetailsID() As String
        Get
            Return _STInternalTransferOutDetailsID
        End Get
        Set(ByVal value As String)
            _STInternalTransferOutDetailsID = value
        End Set
    End Property
    Public Property StockID() As String
        Get
            Return _StockID
        End Get
        Set(ByVal value As String)
            _StockID = value
        End Set
    End Property
    Public Property StockCode() As String
        Get
            Return _StockCode
        End Get
        Set(ByVal value As String)
            _StockCode = value
        End Set
    End Property
    Public Property StockDesc() As String
        Get
            Return _StockDesc
        End Get
        Set(ByVal value As String)
            _StockDesc = value
        End Set
    End Property
    Public Property PartNo() As String
        Get
            Return _PartNo
        End Get
        Set(ByVal value As String)
            _PartNo = value
        End Set
    End Property
    Public Property AvailQty() As Double
        Get
            Return _AvailQty
        End Get
        Set(ByVal value As Double)
            _AvailQty = value
        End Set
    End Property
    Public Property UnitPrice() As Double
        Get
            Return _UnitPrice
        End Get
        Set(ByVal value As Double)
            _UnitPrice = value
        End Set
    End Property
    Public Property COAID() As String
        Get
            Return _COAID
        End Get
        Set(ByVal value As String)
            _COAID = value
        End Set
    End Property
    Public Property COACode() As String
        Get
            Return _COACode
        End Get
        Set(ByVal value As String)
            _COACode = value
        End Set
    End Property
    Public Property TransferOutQty() As Double
        Get
            Return _TransferOutQty
        End Get
        Set(ByVal value As Double)
            _TransferOutQty = value
        End Set
    End Property
    Public Property TransferOutValue() As Double
        Get
            Return _TransferOutValue
        End Get
        Set(ByVal value As Double)
            _TransferOutValue = value
        End Set
    End Property
    Public Property ReceivedLocation() As String
        Get
            Return _ReceivedLocation
        End Get
        Set(ByVal value As String)
            _ReceivedLocation = value
        End Set
    End Property

    Public Property ReceivedLocationSearch() As String
        Get
            Return _ReceivedLocationSearch
        End Get
        Set(ByVal value As String)
            _ReceivedLocationSearch = value
        End Set
    End Property

    Public Property DC() As String
        Get
            Return _DC
        End Get
        Set(ByVal value As String)
            _DC = value
        End Set
    End Property

    Public Property LedgerID() As String
        Get
            Return _LedgerID
        End Get
        Set(ByVal value As String)
            _LedgerID = value
        End Set
    End Property

    Public Property DivID() As String
        Get
            Return _DivID
        End Get
        Set(ByVal value As String)
            _DivID = value
        End Set
    End Property

    Public Property YopID() As String
        Get
            Return _YopID
        End Get
        Set(ByVal value As String)
            _YopID = value
        End Set
    End Property

    Public Property BlockID() As String
        Get
            Return _BlockID
        End Get
        Set(ByVal value As String)
            _BlockID = value
        End Set
    End Property

    Public Property VHID() As String
        Get
            Return _VHID
        End Get
        Set(ByVal value As String)
            _VHID = value
        End Set
    End Property

    Public Property VHDetailCostCodeID() As String
        Get
            Return _VHDetailCostCodeID
        End Get
        Set(ByVal value As String)
            _VHDetailCostCodeID = value
        End Set
    End Property

    Public Property T0() As String
        Get
            Return _T0
        End Get
        Set(ByVal value As String)
            _T0 = value
        End Set
    End Property

    Public Property T1() As String
        Get
            Return _T1
        End Get
        Set(ByVal value As String)
            _T1 = value
        End Set
    End Property

    Public Property T2() As String
        Get
            Return _T2
        End Get
        Set(ByVal value As String)
            _T2 = value
        End Set
    End Property

    Public Property T3() As String
        Get
            Return _T3
        End Get
        Set(ByVal value As String)
            _T3 = value
        End Set
    End Property

    Public Property T4() As String
        Get
            Return _T4
        End Get
        Set(ByVal value As String)
            _T4 = value
        End Set
    End Property

    Public Property JournalDetDescp() As String
        Get
            Return _JournalDetDescp
        End Get
        Set(ByVal value As String)
            _JournalDetDescp = value
        End Set
    End Property

    Public Property Flag() As String
        Get
            Return _Flag
        End Get
        Set(ByVal value As String)
            _Flag = value
        End Set
    End Property

    Public Property value() As Double
        Get
            Return _Value
        End Get
        Set(ByVal value As Double)
            _Value = value
        End Set
    End Property



    Public Property StationID() As String
        Get
            Return _StationID
        End Get
        Set(ByVal value As String)
            _StationID = value
        End Set
    End Property

#End Region

End Class
