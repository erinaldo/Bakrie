Public Class StockAdjustmentPPT
#Region "Private Member Declarations"
    Private _DivID As String = String.Empty
    Private _YopID As String = String.Empty
    Private _BeritaAcaraAudit As String = String.Empty
    Private _T0analysisID As String = String.Empty
    Private _T1analysisID As String = String.Empty
    Private _T2analysisID As String = String.Empty
    Private _T3analysisID As String = String.Empty
    Private _T4analysisID As String = String.Empty
    Private _AdjustmentNo As String = String.Empty
    Private _Status As String = String.Empty
    Private _AdjustmentDate As Date = Date.Today
    Private _AccountCode As String = String.Empty

    Private _STAdjustmentID As String = String.Empty
    Private _stockID As String = String.Empty
    Private _stockCode As String = String.Empty

    Private _stockDescription As String = String.Empty
    Private _RejectedReason As String = String.Empty
    Private _AdjQty As Double
    Private _AdjValue As Double
    Private _Unit As String

    Private _COAID As String = String.Empty
    Private _BlockID As String = String.Empty
    Private _Remarks As String = String.Empty
    ' Private _ConcurrencyId As Date = Date.Today

    Private _CreatedBy As String = String.Empty
    Private _CreatedOn As String = String.Empty
    Private _ModifiedBy As String = String.Empty
    Private _ModifiedOn As Date = Date.Today
    Private _TransType As String = "STA"
    Private _STAdjustmentNo As String = String.Empty
    Private _ID As Double
    Private _StdValue As Double
    Private _VarianceId As String
#End Region
#Region "Public Member Declarations"
    Public Property DivID() As String
        Get
            Return _DivID
        End Get
        Set(ByVal value As String)
            _DivID = value
        End Set
    End Property
    Public Property BeritaAcaraAudit() As String
        Get
            Return _BeritaAcaraAudit
        End Get
        Set(ByVal value As String)
            _BeritaAcaraAudit = value
        End Set
    End Property
    Public Property STAdjustmentNo() As String
        Get
            Return _STAdjustmentNo
        End Get
        Set(ByVal value As String)
            _STAdjustmentNo = value
        End Set
    End Property


    Public Property VarianceId() As String
        Get
            Return _VarianceId
        End Get
        Set(ByVal value As String)
            _VarianceId = value
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

    Public Property T0analysisID() As String
        Get
            Return _T0analysisID
        End Get
        Set(ByVal value As String)
            _T0analysisID = value
        End Set
    End Property

    Public Property stockCode() As String
        Get
            Return _stockCode
        End Get
        Set(ByVal value As String)
            _stockCode = value
        End Set
    End Property
    Public Property stockDescription() As String
        Get
            Return _stockDescription
        End Get
        Set(ByVal value As String)
            _stockDescription = value
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


    Public Property T1analysisID() As String
        Get
            Return _T1analysisID
        End Get
        Set(ByVal value As String)
            _T1analysisID = value
        End Set
    End Property

    Public Property T2analysisID() As String
        Get
            Return _T2analysisID
        End Get
        Set(ByVal value As String)
            _T2analysisID = value
        End Set
    End Property

    Public Property T3analysisID() As String
        Get
            Return _T3analysisID
        End Get
        Set(ByVal value As String)
            _T3analysisID = value
        End Set
    End Property
    Public Property T4analysisID() As String
        Get
            Return _T4analysisID
        End Get
        Set(ByVal value As String)
            _T4analysisID = value
        End Set
    End Property

    Public Property AdjustmentDate() As Date
        Get
            Return _AdjustmentDate
        End Get
        Set(ByVal value As Date)
            _AdjustmentDate = value
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
    Public Property Status() As String
        Get
            Return _Status
        End Get
        Set(ByVal value As String)
            _Status = value
        End Set
    End Property


    Public Property STAdjustmentID() As String
        Get
            Return _STAdjustmentID
        End Get
        Set(ByVal value As String)
            _STAdjustmentID = value
        End Set
    End Property

    Public Property stockID() As String
        Get
            Return _stockID
        End Get
        Set(ByVal value As String)
            _stockID = value
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

    Public Property AdjQty() As Double
        Get
            Return _AdjQty
        End Get
        Set(ByVal value As Double)
            _AdjQty = value
        End Set
    End Property


    Public Property AdjValue() As Double
        Get
            Return _AdjValue
        End Get
        Set(ByVal value As Double)
            _AdjValue = value
        End Set
    End Property

    Public Property StdValue() As Double
        Get
            Return _StdValue
        End Get
        Set(ByVal value As Double)
            _StdValue = value
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


    Public Property BlockID() As String
        Get
            Return _BlockID
        End Get
        Set(ByVal value As String)
            _BlockID = value
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

    'Public Property ConcurrencyId() As String
    '    Get
    '        Return _ConcurrencyId
    '    End Get
    '    Set(ByVal value As String)
    '        _ConcurrencyId = value
    '    End Set
    'End Property


    Public Property CreatedBy() As String
        Get
            Return _CreatedBy
        End Get
        Set(ByVal value As String)
            _CreatedBy = value
        End Set
    End Property
    Public Property ID() As Integer
        Get
            Return _ID
        End Get
        Set(ByVal value As Integer)
            _ID = value
        End Set
    End Property
    Public Property CreatedOn() As String
        Get
            Return _CreatedOn
        End Get
        Set(ByVal value As String)
            _CreatedOn = value
        End Set
    End Property
    Public Property ModifiedBy() As String
        Get
            Return _ModifiedBy
        End Get
        Set(ByVal value As String)
            _ModifiedBy = value
        End Set
    End Property
    Public Property ModifiedOn() As String
        Get
            Return _ModifiedOn
        End Get
        Set(ByVal value As String)
            _ModifiedOn = value
        End Set
    End Property
    Public Property TransType() As String
        Get
            Return _TransType
        End Get
        Set(ByVal value As String)
            _TransType = value
        End Set
    End Property
    Public Property AccountCode() As String
        Get
            Return _AccountCode
        End Get
        Set(ByVal value As String)
            _AccountCode = value
        End Set
    End Property

#End Region
End Class
