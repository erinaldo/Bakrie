Public Class PettyCashPaymentPPT

#Region "Private Member Declarations"
    Private _PaymentID As String = String.Empty
    Private _EstateID As String = String.Empty
    Private _ActiveMonthYearID As String = String.Empty
    Private _VoucherDate As Date
    Private _ApprovalDate As Date
    Private _lVoucherDate As String
    Private _VoucherNo As String = String.Empty
    Private _PayToID As String = String.Empty
    Private _PayDescp As String = String.Empty
    Private _DiscrepancyTransaction As Char
    Private _COAID As String = String.Empty
    Private _T0 As String = String.Empty
    Private _T1 As String = String.Empty
    Private _T2 As String = String.Empty
    Private _T3 As String = String.Empty
    Private _T4 As String = String.Empty
    Private _Amount As Decimal
    Private _Remarks As String = String.Empty
    Private _Approved As Char
    Private _COACode As String = String.Empty
    Private _COADescp As String = String.Empty
    Private _TDecide As String = String.Empty
    Private _T0Value As String = String.Empty
    Private _T0Desc As String = String.Empty
    Private _T1Value As String = String.Empty
    Private _T1Desc As String = String.Empty
    Private _T2Value As String = String.Empty
    Private _T2Desc As String = String.Empty
    Private _T3Value As String = String.Empty
    Private _T3Desc As String = String.Empty
    Private _T4Value As String = String.Empty
    Private _T4Desc As String = String.Empty
    Private _Qty As Integer
    Private _LedgerID As String = String.Empty
    Private _AYear As Integer
    Private _AMonth As Integer
    Private _ModID As Integer
    Private _LedgerDate As Date = Date.Today
    Private _LedgerType As String = String.Empty
    Private _LedgerNo As String = String.Empty
    Private _Descp As String = String.Empty
    Private _BatchAmount As Integer
    Private _JournalDetID As String = String.Empty
    Private _DC As String = String.Empty
    Private _Value As Integer
    Private _JournalDetDescp As String = String.Empty
    Private _Flag As String = String.Empty
    Private _EstateCodeL As String = String.Empty
    Private _Type As String = String.Empty
    Private _RejectedReason As String = String.Empty
    Private _UOMID As String = String.Empty
    Private _UOM As String = String.Empty
    Private _PaidTo As String = String.Empty
    Private _TransactionType As String = String.Empty
    Private _VHID As String = String.Empty
    Private _VHDetailCostCodeID As String = String.Empty


#End Region
#Region "Public Properties"
    Public Property PaymentID() As String
        Get
            Return _PaymentID
        End Get
        Set(ByVal value As String)
            _PaymentID = value
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
    Public Property ActiveMonthYearID() As String
        Get
            Return _ActiveMonthYearID
        End Get
        Set(ByVal value As String)
            _ActiveMonthYearID = value
        End Set
    End Property
  
    Public Property VoucherDate() As Date
        Get
            Return _VoucherDate
        End Get
        Set(ByVal value As Date)
            _VoucherDate = value
        End Set
    End Property
    Public Property ApprovalDate() As Date
        Get
            Return _ApprovalDate
        End Get
        Set(ByVal value As Date)
            _ApprovalDate = value
        End Set
    End Property


    Public Property lVoucherDate() As String
        Get
            Return _lVoucherDate
        End Get
        Set(ByVal value As String)
            _lVoucherDate = value
        End Set
    End Property

    Public Property VoucherNo() As String
        Get
            Return _VoucherNo
        End Get
        Set(ByVal value As String)
            _VoucherNo = value
        End Set
    End Property
    Public Property PayToID() As String
        Get
            Return _PayToID
        End Get
        Set(ByVal value As String)
            _PayToID = value
        End Set
    End Property
    Public Property PayDescp() As String
        Get
            Return _PayDescp
        End Get
        Set(ByVal value As String)
            _PayDescp = value
        End Set
    End Property

    Public Property DiscrepancyTransaction() As Char
        Get
            Return _DiscrepancyTransaction
        End Get
        Set(ByVal value As Char)
            _DiscrepancyTransaction = value
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

    Public Property Amount() As Decimal
        Get
            Return _Amount
        End Get
        Set(ByVal value As Decimal)
            _Amount = value
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

    Public Property Approved() As Char
        Get
            Return _Approved
        End Get
        Set(ByVal value As Char)
            _Approved = value
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

    Public Property COADescp() As String
        Get
            Return _COADescp
        End Get
        Set(ByVal value As String)
            _COADescp = value
        End Set
    End Property

    Public Property TDecide() As String
        Get
            Return _TDecide
        End Get
        Set(ByVal value As String)
            _TDecide = value
        End Set
    End Property

    Public Property T0Value() As String
        Get
            Return _T0Value
        End Get
        Set(ByVal value As String)
            _T0Value = value
        End Set
    End Property

    Public Property T0Desc() As String
        Get
            Return _T0Desc
        End Get
        Set(ByVal value As String)
            _T0Desc = value
        End Set
    End Property

    Public Property T1Value() As String
        Get
            Return _T1Value
        End Get
        Set(ByVal value As String)
            _T1Value = value
        End Set
    End Property

    Public Property T1Desc() As String
        Get
            Return _T1Desc
        End Get
        Set(ByVal value As String)
            _T1Desc = value
        End Set
    End Property

    Public Property T2Value() As String
        Get
            Return _T2Value
        End Get
        Set(ByVal value As String)
            _T2Value = value
        End Set
    End Property

    Public Property T2Desc() As String
        Get
            Return _T2Desc
        End Get
        Set(ByVal value As String)
            _T2Desc = value
        End Set
    End Property

    Public Property T3Value() As String
        Get
            Return _T3Value
        End Get
        Set(ByVal value As String)
            _T3Value = value
        End Set
    End Property

    Public Property T3Desc() As String
        Get
            Return _T3Desc
        End Get
        Set(ByVal value As String)
            _T3Desc = value
        End Set
    End Property

    Public Property T4Value() As String
        Get
            Return _T4Value
        End Get
        Set(ByVal value As String)
            _T4Value = value
        End Set
    End Property

    Public Property T4Desc() As String
        Get
            Return _T4Desc
        End Get
        Set(ByVal value As String)
            _T4Desc = value
        End Set
    End Property

    Public Property Qty() As Decimal
        Get
            Return _Qty
        End Get
        Set(ByVal value As Decimal)
            _Qty = value
        End Set
    End Property

    Public Property TransactionType() As String
        Get
            Return _TransactionType
        End Get
        Set(ByVal value As String)
            _TransactionType = value
        End Set
    End Property


    '' For approval
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
    Public Property BatchAmount() As Integer
        Get
            Return _BatchAmount
        End Get
        Set(ByVal value As Integer)
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
    Public Property Value() As Integer
        Get
            Return _Value
        End Get
        Set(ByVal value As Integer)
            _Value = value
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
    Public Property EstateCodeL() As String
        Get
            Return _EstateCodeL
        End Get
        Set(ByVal value As String)
            _EstateCodeL = value
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

    Public Property Type() As String
        Get
            Return _Type
        End Get
        Set(ByVal value As String)
            _Type = value
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

    Public Property UOMID() As String
        Get
            Return _UOMID
        End Get
        Set(ByVal value As String)
            _UOMID = value
        End Set
    End Property

    Public Property UOM() As String
        Get
            Return _UOM
        End Get
        Set(ByVal value As String)
            _UOM = value
        End Set
    End Property


    Public Property PaidTo() As String
        Get
            Return _PaidTo
        End Get
        Set(ByVal value As String)
            _PaidTo = value
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

#End Region

End Class
