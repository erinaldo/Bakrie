Public Class StockAdjustmentApprovalPPT

#Region "Private Member Declarations"

    Private _DivID As String = String.Empty
    Private _YopID As String = String.Empty
    Private _T0analysisID As String = String.Empty
    Private _T1analysisID As String = String.Empty
    Private _T2analysisID As String = String.Empty
    Private _T3analysisID As String = String.Empty
    Private _T4analysisID As String = String.Empty
    Private _AdjustmentNo As String = String.Empty
    Private _Status As String = String.Empty
    Private _AdjustmentDate As Date = Date.Today
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



    Private _LedgerID As String = String.Empty
    Private _AYear As Integer
    Private _AMonth As Integer
    Private _ModID As Integer
    Private _LedgerDate As Date = Date.Today
    Private _LedgerType As String = String.Empty
    Private _LedgerNo As String = String.Empty
    Private _Descp As String = String.Empty
    Private _BatchAmount As Double
    Private _JournalDetID As String = String.Empty
    Private _DC As String = String.Empty
    Private _VHID As String = String.Empty
    Private _VHDetailCostCodeID As String = String.Empty
    Private _JournalDetDescp As String = String.Empty
    Private _Flag As String = String.Empty
    Private _Value As Double
    Private _StationID As String = String.Empty

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

    Public Property LedgerID() As String
        Get
            Return _LedgerID
        End Get
        Set(ByVal value As String)
            _LedgerID = value
        End Set
    End Property

    Public Property AYear() As String
        Get
            Return _AYear
        End Get
        Set(ByVal value As String)
            _AYear = value
        End Set
    End Property

    Public Property AMonth() As String
        Get
            Return _AMonth
        End Get
        Set(ByVal value As String)
            _AMonth = value
        End Set
    End Property

    Public Property ModID() As String
        Get
            Return _ModID
        End Get
        Set(ByVal value As String)
            _ModID = value
        End Set
    End Property

    Public Property LedgerDate() As Date
        Get
            Return _LedgerDate
        End Get
        Set(ByVal value As Date)
            _LedgerDate = value
        End Set
    End Property

    Public Property LedgerType() As String
        Get
            Return _LedgerType
        End Get
        Set(ByVal value As String)
            _LedgerType = value
        End Set
    End Property

    Public Property LedgerNo() As Date
        Get
            Return _LedgerNo
        End Get
        Set(ByVal value As Date)
            _LedgerNo = value
        End Set
    End Property

    Public Property Descp() As String
        Get
            Return _Descp
        End Get
        Set(ByVal value As String)
            _Descp = value
        End Set
    End Property

    Public Property BatchAmount() As Double
        Get
            Return _BatchAmount
        End Get
        Set(ByVal value As Double)
            _BatchAmount = value
        End Set
    End Property
    Public Property JournalDetID() As String
        Get
            Return _JournalDetID
        End Get
        Set(ByVal value As String)
            _JournalDetID = value
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

    Public Property Value() As Double
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
