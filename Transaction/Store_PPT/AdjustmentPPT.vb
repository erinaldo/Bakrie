Public Class AdjustmentPPT
#Region "Private Member Declarations"
    Private _STAdjustmentID As String = String.Empty
    Private _AdjustmentNo As String = String.Empty
    Private _AdjustmentDate As Date = Date.Today
    Private _StockID As String = String.Empty
    Private _Status As String = String.Empty
    Private _RejectedReason As String = String.Empty
    Private _AdjQty As Integer
    Private _AdjValue As Integer
    Private _COAID As String = String.Empty
    Private _DivID As String = String.Empty
    Private _YopID As String = String.Empty
    Private _BlockID As String = String.Empty
    Private _T0 As String = String.Empty
    Private _T1 As String = String.Empty
    Private _T2 As String = String.Empty
    Private _T3 As String = String.Empty
    Private _T4 As String = String.Empty
    Private _Remarks As String = String.Empty

#End Region

#Region "Public Properties"
    Public Property STAdjustmentID() As String
        Get
            Return _STAdjustmentID
        End Get
        Set(ByVal value As String)
            _STAdjustmentID = value
        End Set
    End Property
    Public Property AdjustmentNo() As String
        Get
            Return _AdjustmentNo
        End Get
        Set(ByVal value As String)
            _AdjustmentNo = value
        End Set
    End Property
    Public Property AdjustmentDate() As Date
        Get
            Return _AdjustmentDate
        End Get
        Set(ByVal value As Date)
            _AdjustmentDate = Date.Today
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
    Public Property AdjQty() As Integer
        Get
            Return _AdjQty
        End Get
        Set(ByVal value As Integer)
            _AdjQty = value
        End Set
    End Property
    Public Property AdjValue() As Integer
        Get
            Return _AdjValue
        End Get
        Set(ByVal value As Integer)
            _AdjValue = value
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
    Public Property Remarks() As String
        Get
            Return _Remarks
        End Get
        Set(ByVal value As String)
            _Remarks = value
        End Set
    End Property
#End Region
End Class
