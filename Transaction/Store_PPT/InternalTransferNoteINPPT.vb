Public Class InternalTransferNoteINPPT

#Region "Private Member Declarations"

    Private _STInternalTransferInID As String = String.Empty
    Private _OperatorName As String = String.Empty
    Private _TransportDate As DateTime = DateTime.Now
    Private _VehicleNo As String = String.Empty
    Private _MRCNo As String = String.Empty
    Private _ItnInNo As String = String.Empty
    Private _ITNDate As Date = Date.Today
    Private _Remarks As String = String.Empty
    Private _RejectedReason As String = String.Empty
    Private _Status As String = String.Empty
    Private _STInternalTransferInDetailsID As String = String.Empty
    Private _StockID As String = String.Empty
    Private _StockCode As String = String.Empty
    Private _StockDesc As String = String.Empty
    Private _PartNo As String = String.Empty
    Private _AvailQty As Double = 0.0
    Private _UnitPrice As Double = 0.0
    Private _COAID As String = String.Empty
    Private _COACode As String = String.Empty
    Private _TransferInQty As Double = 0.0
    Private _TransferInValue As Double = 0.0
    Private _SendersLocation As String = String.Empty
    Private _SendersLocationID As String = String.Empty
    Private _SendersLocationSearch As String = String.Empty
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
    Private _STCategoryID As String = String.Empty
    Private _StationID As String = String.Empty

#End Region

#Region "Public Member Declarations"

    Public Property STInternalTransferInID() As String
        Get
            Return _STInternalTransferInID
        End Get
        Set(ByVal value As String)
            _STInternalTransferInID = value
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

    Public Property ItnInNo() As String
        Get
            Return _ItnInNo
        End Get
        Set(ByVal value As String)
            _ItnInNo = value
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
    Public Property RejectedReason() As String
        Get
            Return _RejectedReason
        End Get
        Set(ByVal value As String)
            _RejectedReason = value
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
    Public Property STInternalTransferInDetailsID() As String
        Get
            Return _STInternalTransferInDetailsID
        End Get
        Set(ByVal value As String)
            _STInternalTransferInDetailsID = value
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

    Public Property TransferInQty() As Double
        Get
            Return _TransferInQty
        End Get
        Set(ByVal value As Double)
            _TransferInQty = value
        End Set
    End Property
    Public Property TransferInValue() As Double
        Get
            Return _TransferInValue
        End Get
        Set(ByVal value As Double)
            _TransferInValue = value
        End Set
    End Property

    Public Property SendersLocation() As String
        Get
            Return _SendersLocation
        End Get
        Set(ByVal value As String)
            _SendersLocation = value
        End Set
    End Property

    Public Property SendersLocationID() As String
        Get
            Return _SendersLocationID
        End Get
        Set(ByVal value As String)
            _SendersLocationID = value
        End Set
    End Property

    Public Property SendersLocationSearch() As String
        Get
            Return _SendersLocationSearch
        End Get
        Set(ByVal value As String)
            _SendersLocationSearch = value
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

    Public Property STCategoryID() As String
        Get
            Return _STCategoryID
        End Get
        Set(ByVal value As String)
            _STCategoryID = value
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
