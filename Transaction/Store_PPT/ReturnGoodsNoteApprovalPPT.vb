Public Class ReturnGoodsNoteApprovalPPT

#Region "Private Member Declarations"
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
    Private _COAID As String = String.Empty
    Private _DC As String = String.Empty
    Private _Value As Double
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
    Private _StationID As String = String.Empty
    Private _Status As String = String.Empty
    Private _RejectedReason As String = String.Empty
    Private _Flag As String = String.Empty
    Private _STIssueDetailsID As String = String.Empty
    Private _EstateCodeL As String = String.Empty
    Private _VHWSCode As String = String.Empty
    Private _EstateCode As String = String.Empty
    Private _VHDetailCostCode As String = String.Empty
    Private _Type As String = String.Empty
    Private _UOMID As String = String.Empty
    Private _Qty As Double = 0
    Private _RefNo As String = String.Empty
#End Region

#Region "Public Member Declarations"
    Public Property LedgerID() As String
        Get
            Return _LedgerID
        End Get
        Set(ByVal value As String)
            _LedgerID = value
        End Set
    End Property
    Public Property AYear() As Integer
        Get
            Return _AYear
        End Get
        Set(ByVal value As Integer)
            _AYear = value
        End Set
    End Property
    Public Property AMonth() As Integer
        Get
            Return _AMonth
        End Get
        Set(ByVal value As Integer)
            _AMonth = value
        End Set
    End Property
    Public Property ModID() As Integer
        Get
            Return _ModID
        End Get
        Set(ByVal value As Integer)
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
    Public Property LedgerNo() As String
        Get
            Return _LedgerNo
        End Get
        Set(ByVal value As String)
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
    Public Property COAID() As String
        Get
            Return _COAID
        End Get
        Set(ByVal value As String)
            _COAID = value
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
    Public Property Value() As Double
        Get
            Return _Value
        End Get
        Set(ByVal value As Double)
            _Value = value
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
    Public Property VHDetailCostCodeID() As String
        Get
            Return _VHDetailCostCodeID
        End Get
        Set(ByVal value As String)
            _VHDetailCostCodeID = value
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

    Public Property Flag() As String
        Get
            Return _Flag
        End Get
        Set(ByVal value As String)
            _Flag = value
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

    Public Property StationID() As String
        Get
            Return _StationID
        End Get
        Set(ByVal value As String)
            _StationID = value
        End Set
    End Property

    Public Property EstateCodeL() As String
        Get
            Return _EstateCodeL
        End Get
        Set(ByVal value As String)
            _EstateCodeL = value
        End Set
    End Property
    
    Public Property VHWSCode() As String
        Get
            Return _VHWSCode
        End Get
        Set(ByVal value As String)
            _VHWSCode = value
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
    Public Property VHDetailCostCode() As String
        Get
            Return _VHDetailCostCode
        End Get
        Set(ByVal value As String)
            _VHDetailCostCode = value
        End Set
    End Property
    Public Property Type() As String
        Get
            Return _Type
        End Get
        Set(ByVal value As String)
            _Type = value
        End Set
    End Property
    Public Property UOMID() As String
        Get
            Return _UOMID
        End Get
        Set(ByVal value As String)
            _UOMID = value
        End Set
    End Property

    Public Property Qty() As Double
        Get
            Return _Qty
        End Get
        Set(ByVal value As Double)
            _Qty = value
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

#End Region

End Class
