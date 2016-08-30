Public Class PettyCashReceiptPPT
#Region "Private Member Declarations"
    Private _AccReceiptID As String = String.Empty
    Private _ReceiptDate As Date
    Private _ReceiptNo As String = String.Empty
    Private _ReconcilationDate As Date
    Private _Amount As Decimal
    Private _ReceiptDesc As String = String.Empty
    Private _ModifiedOn As Date
    Private _Approved As String = String.Empty
    Private _RejectedReason As String = String.Empty
    Private _ReceivedFrom As String = String.Empty


#End Region
#Region "Public Properties"
    Public Property ReceiptNo() As String
        Get
            Return _ReceiptNo
        End Get
        Set(ByVal value As String)
            _ReceiptNo = value
        End Set
    End Property
    Public Property ReceivedFrom() As String
        Get
            Return _ReceivedFrom
        End Get
        Set(ByVal value As String)
            _ReceivedFrom = value
        End Set
    End Property
    Public Property AccReceiptID() As String
        Get
            Return _AccReceiptID
        End Get
        Set(ByVal value As String)
            _AccReceiptID = value
        End Set
    End Property
    Public Property ReceiptDesc() As String
        Get
            Return _ReceiptDesc
        End Get
        Set(ByVal value As String)
            _ReceiptDesc = value
        End Set
    End Property
    Public Property Approved() As String
        Get
            Return _Approved
        End Get
        Set(ByVal value As String)
            _Approved = value
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
    Public Property ModifiedOn() As Date
        Get
            Return _ModifiedOn
        End Get
        Set(ByVal value As Date)
            _ModifiedOn = value
        End Set
    End Property
    Public Property ReceiptDate() As Date
        Get
            Return _ReceiptDate
        End Get
        Set(ByVal value As Date)
            _ReceiptDate = value
        End Set
    End Property
    Public Property ReconcilationDate() As Date
        Get
            Return _ReconcilationDate
        End Get
        Set(ByVal value As Date)
            _ReconcilationDate = value
        End Set
    End Property
  
    Public Property Amount() As Decimal
        Get
            Return _Amount
        End Get
        Set(ByVal value As Decimal)
            _Amount = value
        End Set
    End Property
#End Region
End Class
