Public Class JournalPPT


#Region "Private Member Declarations"

    Private _AccJournalID As String = String.Empty
    Private _EstateID As String = String.Empty
    Private _ActiveMonthYearID As String = String.Empty
    Private _AccBatchID As String = String.Empty
    Private _LedgerNo As String = String.Empty
    Private _LedgerSetupID As String = String.Empty
    Private _LedgerType As String = String.Empty
    Private _JournalDate As Date
    Private _lJournalDate As String
    Private _RecurringJournal As Char
    Private _Status As Char
    Private _ContractID As String = String.Empty
    Private _ContractNo As String = String.Empty
    Private _ContractName As String = String.Empty
    Private _JournalDescp As String = String.Empty
    Private _COAID As String = String.Empty
    Private _COACode As String = String.Empty
    Private _COADescp As String = String.Empty
    Private _DivID As String = String.Empty
    Private _Div As String = String.Empty
    Private _DivName As String = String.Empty
    Private _YOPID As String = String.Empty
    Private _YOP As String = String.Empty
    Private _YOPName As String = String.Empty
    Private _BlockID As String = String.Empty
    Private _SubBlock As String = String.Empty
    Private _BlockStatus As String = String.Empty
    Private _VHID As String = String.Empty
    Private _VHWSCode As String = String.Empty
    Private _VHDesc As String = String.Empty
    Private _VHDetailCostCodeID As String = String.Empty
    Private _VHDetailCostCode As String = String.Empty
    Private _VHDetailCostDesc As String = String.Empty
    Private _VHCategoryID As String = String.Empty
    Private _Type As String = String.Empty
    Private _StationID As String = String.Empty
    Private _StationCode As String = String.Empty
    Private _StationDesc As String = String.Empty
    Private _T0 As String = String.Empty
    Private _T1 As String = String.Empty
    Private _T2 As String = String.Empty
    Private _T3 As String = String.Empty
    Private _T4 As String = String.Empty
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
    Private _Debit As Decimal
    Private _Credit As Decimal
    Private _BatchTotal As Decimal
    Private _Description As String = String.Empty

    ''' for Approval

    Private _AYear As String = String.Empty
    Private _Amonth As String = String.Empty
    Private _LedgerDate As String = String.Empty
    Private _LedgerID As String = String.Empty
    Private _DC As String = String.Empty
    Private _Value As Decimal
    Private _Flag As String = String.Empty
    Private _EstateCodeL As String = String.Empty

    'Private _GLLedgerID As String = String.Empty
    'Private _GLSubID As String = String.Empty
    Private _MonthCalculation As Decimal
    Private _UpdateDebitCalc As Decimal
    Private _UpdateCreditCalc As Decimal
    Private _RejectedReason As String = String.Empty

    Private _UOMID As String = String.Empty
    Private _Qty As Double = 0
    Private _RefNo As String = String.Empty

#End Region

#Region "Public Properties"
    Public Property AccJournalID() As String
        Get
            Return _AccJournalID
        End Get
        Set(ByVal value As String)
            _AccJournalID = value
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
    Public Property AccBatchID() As String
        Get
            Return _AccBatchID
        End Get
        Set(ByVal value As String)
            _AccBatchID = value
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
    Public Property LedgerSetupID() As String
        Get
            Return _LedgerSetupID
        End Get
        Set(ByVal value As String)
            _LedgerSetupID = value
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
    Public Property JournalDate() As Date
        Get
            Return _JournalDate
        End Get
        Set(ByVal value As Date)
            _JournalDate = value
        End Set
    End Property

    Public Property lJournalDate() As String
        Get
            Return _lJournalDate
        End Get
        Set(ByVal value As String)
            _lJournalDate = value
        End Set
    End Property
    Public Property RecurringJournal() As Char
        Get
            Return _RecurringJournal
        End Get
        Set(ByVal value As Char)
            _RecurringJournal = value
        End Set
    End Property
    Public Property Status() As Char
        Get
            Return _Status
        End Get
        Set(ByVal value As Char)
            _Status = value
        End Set
    End Property
    Public Property ContractID() As String
        Get
            Return _ContractID
        End Get
        Set(ByVal value As String)
            _ContractID = value
        End Set
    End Property
    Public Property ContractNo() As String
        Get
            Return _ContractNo
        End Get
        Set(ByVal value As String)
            _ContractNo = value
        End Set
    End Property
    Public Property ContractName() As String
        Get
            Return _ContractName
        End Get
        Set(ByVal value As String)
            _ContractName = value
        End Set
    End Property
    Public Property JournalDescp() As String
        Get
            Return _JournalDescp
        End Get
        Set(ByVal value As String)
            _JournalDescp = value
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
    Public Property DivID() As String
        Get
            Return _DivID
        End Get
        Set(ByVal value As String)
            _DivID = value
        End Set
    End Property
    Public Property Div() As String
        Get
            Return _Div
        End Get
        Set(ByVal value As String)
            _Div = value
        End Set
    End Property
    Public Property DivName() As String
        Get
            Return _DivName
        End Get
        Set(ByVal value As String)
            _DivName = value
        End Set
    End Property
    Public Property YOPID() As String
        Get
            Return _YOPID
        End Get
        Set(ByVal value As String)
            _YOPID = value
        End Set
    End Property
    Public Property YOP() As String
        Get
            Return _YOP
        End Get
        Set(ByVal value As String)
            _YOP = value
        End Set
    End Property
    Public Property YOPName() As String
        Get
            Return _YOPName
        End Get
        Set(ByVal value As String)
            _YOPName = value
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
    Public Property SubBlock() As String
        Get
            Return _SubBlock
        End Get
        Set(ByVal value As String)
            _SubBlock = value
        End Set
    End Property
    Public Property BlockStatus() As String
        Get
            Return _BlockStatus
        End Get
        Set(ByVal value As String)
            _BlockStatus = value
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
    Public Property VHWScode() As String
        Get
            Return _VHWSCode
        End Get
        Set(ByVal value As String)
            _VHWSCode = value
        End Set
    End Property
    Public Property VHDesc() As String
        Get
            Return _VHDesc
        End Get
        Set(ByVal value As String)
            _VHDesc = value
        End Set
    End Property
    Public Property VHDetailcostCodeID() As String
        Get
            Return _VHDetailCostCodeID
        End Get
        Set(ByVal value As String)
            _VHDetailCostCodeID = value
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
    Public Property VHDetailCostDescp() As String
        Get
            Return _VHDetailCostDesc
        End Get
        Set(ByVal value As String)
            _VHDetailCostDesc = value
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
    Public Property StationCode() As String
        Get
            Return _StationCode
        End Get
        Set(ByVal value As String)
            _StationCode = value
        End Set
    End Property
    Public Property StationDesc() As String
        Get
            Return _StationDesc
        End Get
        Set(ByVal value As String)
            _StationDesc = value
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
    Public Property Description() As String
        Get
            Return _Description
        End Get
        Set(ByVal value As String)
            _Description = value
        End Set
    End Property

    Public Property Credit() As Decimal
        Get
            Return _Credit
        End Get
        Set(ByVal value As Decimal)
            _Credit = value
        End Set
    End Property

    Public Property Debit() As Decimal
        Get
            Return _Debit
        End Get
        Set(ByVal value As Decimal)
            _Debit = value
        End Set
    End Property
    Public Property BatchTotal() As Decimal
        Get
            Return _BatchTotal
        End Get
        Set(ByVal value As Decimal)
            _BatchTotal = value
        End Set
    End Property

    Public Property VHCategoryID() As String
        Get
            Return _VHCategoryID
        End Get
        Set(ByVal value As String)
            _VHCategoryID = value
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

    '''For Approval
    Public Property AYear() As String
        Get
            Return _AYear
        End Get
        Set(ByVal value As String)
            _AYear = value
        End Set
    End Property
    Public Property Amonth() As String
        Get
            Return _Amonth
        End Get
        Set(ByVal value As String)
            _Amonth = value
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
    Public Property LedgerID() As String
        Get
            Return _LedgerID
        End Get
        Set(ByVal value As String)
            _LedgerID = value
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

    Public Property Value() As Decimal
        Get
            Return _Value
        End Get
        Set(ByVal value As Decimal)
            _Value = value
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
    Public Property EstateCodeL() As String
        Get
            Return _EstateCodeL
        End Get
        Set(ByVal value As String)
            _EstateCodeL = value
        End Set
    End Property
    'Public Property GLLedgerID() As String
    '    Get
    '        Return _GLLedgerID
    '    End Get
    '    Set(ByVal value As String)
    '        _GLLedgerID = value
    '    End Set
    'End Property
    'Public Property GLSubID() As String
    '    Get
    '        Return _GLSubID
    '    End Get
    '    Set(ByVal value As String)
    '        _GLSubID = value
    '    End Set
    'End Property

    Public Property MonthCalculation() As Decimal
        Get
            Return _MonthCalculation
        End Get
        Set(ByVal value As Decimal)
            _MonthCalculation = value
        End Set
    End Property

    Public Property UpdateDebitCalc() As Decimal
        Get
            Return _UpdateDebitCalc
        End Get
        Set(ByVal value As Decimal)
            _UpdateDebitCalc = value
        End Set
    End Property
    Public Property UpdateCreditCalc() As Decimal
        Get
            Return _UpdateCreditCalc
        End Get
        Set(ByVal value As Decimal)
            _UpdateCreditCalc = value
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
