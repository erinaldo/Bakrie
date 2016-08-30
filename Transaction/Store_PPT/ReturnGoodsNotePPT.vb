Public Class ReturnGoodsNotePPT

#Region "Private Member Declarations"
    Private _STReturnGoodsNoteID As String = String.Empty
    Private _RGNDate As Date = Date.Today
    Private _RGNDateIsChecked As Boolean = False
    Private _RGNNo As String = String.Empty
    Private _SIVNO As String = String.Empty
    Private _SIVDate As String = String.Empty
    Private _STIssueID As String = String.Empty
    Private _STIssueDetailsID As String = String.Empty
    Private _Status As String = String.Empty
    Private _RejectedStatus As String = String.Empty
    Private _Remarks As String = String.Empty
    Private _STReturnGoodsDetailsID As String = String.Empty
    Private _StockID As String = String.Empty
    Private _StockCode As String = String.Empty
    Private _StockDesc As String = String.Empty
    Private _Unit As String = String.Empty
    Private _IssueQty As Double = 0.0
    Private _IssueValue As Double = 0.0
    Private _ReturnQty As Double = 0.0
    Private _ReturnedValue As Double = 0.0
    Private _RejectedReason As String = String.Empty
    Private _PartNo As String = String.Empty
#End Region

#Region "Public Member Declarations"
    Public Property STReturnGoodsNoteID() As String
        Get
            Return _STReturnGoodsNoteID
        End Get
        Set(ByVal value As String)
            _STReturnGoodsNoteID = value
        End Set
    End Property
    Public Property RGNDate() As Date
        Get
            Return _RGNDate
        End Get
        Set(ByVal value As Date)
            _RGNDate = value
        End Set
    End Property
    Public Property RGNDateIsChecked() As Boolean
        Get
            Return _RGNDateIsChecked
        End Get
        Set(ByVal value As Boolean)
            _RGNDateIsChecked = value
        End Set
    End Property

    Public Property RGNNo() As String
        Get
            Return _RGNNo
        End Get
        Set(ByVal value As String)
            _RGNNo = value
        End Set
    End Property
    Public Property SIVNO() As String
        Get
            Return _SIVNO
        End Get
        Set(ByVal value As String)
            _SIVNO = value
        End Set
    End Property
    Public Property SIVDate() As String
        Get
            Return _SIVDate
        End Get
        Set(ByVal value As String)
            _SIVDate = value
        End Set
    End Property
    Public Property STIssueDetailsID() As String
        Get
            Return _STIssueDetailsID
        End Get
        Set(ByVal value As String)
            _STIssueDetailsID = value
        End Set
    End Property
    Public Property STIssueID() As String
        Get
            Return _STIssueID
        End Get
        Set(ByVal value As String)
            _STIssueID = value
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

    Public Property RejectedStatus() As String
        Get
            Return _RejectedStatus
        End Get
        Set(ByVal value As String)
            _RejectedStatus = value
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

    Public Property STReturnGoodsDetailsID() As String
        Get
            Return _STReturnGoodsDetailsID
        End Get
        Set(ByVal value As String)
            _STReturnGoodsDetailsID = value
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

    Public Property Unit() As String
        Get
            Return _Unit
        End Get
        Set(ByVal value As String)
            _Unit = value
        End Set
    End Property

    Public Property IssueQty() As Double
        Get
            Return _IssueQty
        End Get
        Set(ByVal value As Double)
            _IssueQty = value
        End Set
    End Property

    Public Property IssueValue() As Double
        Get
            Return _IssueValue
        End Get
        Set(ByVal value As Double)
            _IssueValue = value
        End Set
    End Property

    Public Property ReturnQty() As Double
        Get
            Return _ReturnQty
        End Get
        Set(ByVal value As Double)
            _ReturnQty = value
        End Set
    End Property

    Public Property ReturnedValue() As Double
        Get
            Return _ReturnedValue
        End Get
        Set(ByVal value As Double)
            _ReturnedValue = value
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

    Public Property PartNo() As String
        Get
            Return _PartNo
        End Get
        Set(ByVal value As String)
            _PartNo = value
        End Set
    End Property

#End Region


End Class
