Public Class ConsignmentReceivedPPT

#Region "Private Member Declarations"
    Private _StConsignmentID As String = String.Empty
    Private _blReceivedDate As Boolean = False
    Private _ReceivedDate As Date = Date.Today
    Private _ReferenceNo As String = String.Empty
    Private _STConsignmentMasterID As String = String.Empty
    Private _STCode As String = String.Empty
    Private _STDesc As String = String.Empty
    Private _ReceivedQty As Double = 0.0
    Private _Remarks As String = String.Empty
    Private _Status As String = String.Empty
    Private _RejectedReason As String = String.Empty

    ''Private _IsDirect As String = String.Empty


#End Region



#Region "Public Member Declarations"
    Public Property StConsignmentID() As String
        Get
            Return _StConsignmentID
        End Get
        Set(ByVal value As String)
            _StConsignmentID = value
        End Set
    End Property
    Public Property ReceivedDate() As Date
        Get
            Return _ReceivedDate
        End Get
        Set(ByVal value As Date)
            _ReceivedDate = value
        End Set
    End Property
    Public Property ReferenceNo() As String
        Get
            Return _ReferenceNo
        End Get
        Set(ByVal value As String)
            _ReferenceNo = value
        End Set
    End Property
    Public Property STConsignmentMasterID() As String
        Get
            Return _STConsignmentMasterID
        End Get
        Set(ByVal value As String)
            _STConsignmentMasterID = value
        End Set
    End Property
    Public Property STCode() As String
        Get
            Return _STCode
        End Get
        Set(ByVal value As String)
            _STCode = value
        End Set
    End Property
    Public Property STDesc() As String
        Get
            Return _STDesc
        End Get
        Set(ByVal value As String)
            _STDesc = value
        End Set
    End Property

    Public Property ReceivedQty() As Double
        Get
            Return _ReceivedQty
        End Get
        Set(ByVal value As Double)
            _ReceivedQty = value
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

    ''Public Property IsDirect() As String
    ''    Get
    ''        Return _IsDirect
    ''    End Get
    ''    Set(ByVal value As String)
    ''        _IsDirect = value
    ''    End Set
    ''End Property

    Public Property blReceivedDate() As Boolean
        Get
            Return _blReceivedDate
        End Get
        Set(ByVal value As Boolean)
            _blReceivedDate = value
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



#End Region
End Class
