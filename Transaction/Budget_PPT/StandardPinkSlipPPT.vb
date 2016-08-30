
Public Class StandardPinkSlipPPT

#Region "Private Member Declarations"
    Private _PinkSlipId As String
    Private _PinkSlipDetailId As String
    Private _EstateID As String
    Private _EstateCode As String
    Private _RefNo As String
    Private _DateRequest As Date
    Private _COAID As String
    Private _COACode As String
    Private _COADescp As String
    Private _RequestedAmt As Double
    Private _RejectedReason As String
    Private _Reason As String
    Private _ApprovedAmt As Double
    Private _BDGyear As String
    Private _BudgetAmount As Integer
    Private _ActualToDate As Integer
    Private _Status As String
    Private _DateRequestIsChecked As Boolean = False
    'Private _StatusSearch As String
    'Private _RGNDate As Date = Date.Today
#End Region
#Region "Public Member Declar+ations"
    Public Property BDGYear() As String
        Get
            Return _BDGyear
        End Get
        Set(ByVal value As String)
            _BDGyear = value
        End Set
    End Property

    Public Property COADescp() As String
        Get
            Return _COADescp
        End Get
        Set(ByVal value As String)
            _COADescp = value
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

    Public Property COACode() As String
        Get
            Return _COACode
        End Get
        Set(ByVal value As String)
            _COACode = value
        End Set
    End Property
    Public Property EstateCode() As String
        Get
            Return _EstateCode
        End Get
        Set(ByVal value As String)
            _EstateCode = value
        End Set
    End Property

    Public Property PinkSlipId() As String
        Get
            Return _PinkSlipId
        End Get
        Set(ByVal value As String)
            _PinkSlipId = value
        End Set
    End Property
    Public Property PinkSlipDetailId() As String
        Get
            Return _PinkSlipDetailId
        End Get
        Set(ByVal value As String)
            _PinkSlipDetailId = value
        End Set
    End Property

    Public Property EstateID() As String
        Get
            Return _EstateID
        End Get
        Set(ByVal value As String)
            _EstateID = value
        End Set
    End Property
    Public Property RefNo() As String
        Get
            Return _RefNo
        End Get
        Set(ByVal value As String)
            _RefNo = value
        End Set
    End Property
    Public Property DateRequestIsChecked() As Boolean
        Get
            Return _DateRequestIsChecked
        End Get
        Set(ByVal value As Boolean)
            _DateRequestIsChecked = value
        End Set
    End Property

    Public Property DateRequest() As Date

        Get
            Return _DateRequest

        End Get
        Set(ByVal value As Date)
            _DateRequest = value
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
    Public Property RequestedAmt() As Double
        Get
            Return _RequestedAmt
        End Get
        Set(ByVal value As Double)
            _RequestedAmt = value
        End Set
    End Property
    Public Property Reason() As String
        Get
            Return _Reason
        End Get
        Set(ByVal value As String)
            _Reason = value
        End Set
    End Property
    Public Property ApprovedAmt() As Double
        Get
            Return _ApprovedAmt
        End Get
        Set(ByVal value As Double)
            _ApprovedAmt = value
        End Set
    End Property
    Public Property BudgetAmount() As Integer
        Get
            Return _BudgetAmount
        End Get
        Set(ByVal value As Integer)
            _BudgetAmount = value
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
    Public Property ActualToDate() As Integer
        Get
            Return _ActualToDate
        End Get
        Set(ByVal value As Integer)
            _ActualToDate = value
        End Set
    End Property

#End Region
End Class
