Public Class InternalTransferNoteOUTApprovalPPT
#Region "Private Member Declarations"
    Private _STInternalTransferOutID As String = String.Empty
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
    Private _ReceiverLocation As String = String.Empty
    Private _AvailQty As Integer
    Private _UnitPrice As Integer
    Private _COAID As String = String.Empty
    Private _TransferOutQty As Integer
    Private _TransferOutValue As Integer

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
    Public Property ReceiverLocation() As String
        Get
            Return _ReceiverLocation
        End Get
        Set(ByVal value As String)
            _ReceiverLocation = value
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
    Public Property AvailQty() As Integer
        Get
            Return _AvailQty
        End Get
        Set(ByVal value As Integer)
            _AvailQty = value
        End Set
    End Property
    Public Property UnitPrice() As Integer
        Get
            Return _UnitPrice
        End Get
        Set(ByVal value As Integer)
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
    Public Property TransferOutQty() As Integer
        Get
            Return _TransferOutQty
        End Get
        Set(ByVal value As Integer)
            _TransferOutQty = value
        End Set
    End Property
    Public Property TransferOutValue() As Integer
        Get
            Return _TransferOutValue
        End Get
        Set(ByVal value As Integer)
            _TransferOutValue = value
        End Set
    End Property

#End Region
End Class
