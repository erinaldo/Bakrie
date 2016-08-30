Public Class CapitalExpenditurePPT
#Region "Private Member Declarations"
    Private _CapitalExpendID As String = String.Empty
    Private _BudgetYear As Integer
    Private _COAId As String = String.Empty
    Private _COACode As String = String.Empty
    Private _COADescp As String = String.Empty


    Private _BudgetID As String = String.Empty
    Private _BudgetType As String = String.Empty

    Private _SubDesc As String = String.Empty
    Private _Qty As Decimal
    Private _Cost As Decimal
    Private _Price As Decimal
    Private _Day As Integer
    Private _Month As Integer
    Private _Percentage As Decimal




    'Private _Amount As Double
    Private _Remarks As String = String.Empty
    Private _BudgetJan As Double
    Private _BudgetFeb As Double
    Private _BudgetMar As Double
    Private _BudgetApr As Double
    Private _BudgetMay As Double
    Private _BudgetJun As Double
    Private _BudgetJul As Double
    Private _BudgetAug As Double
    Private _BudgetSep As Double
    Private _BudgetOct As Double
    Private _BudgetNov As Double
    Private _BudgetDec As Double
    Private _RevJan As Double
    Private _RevFeb As Double
    Private _RevMar As Double
    Private _RevApr As Double
    Private _RevMay As Double
    Private _RevJun As Double
    Private _RevJul As Double
    Private _RevAug As Double
    Private _RevSep As Double
    Private _RevOct As Double
    Private _RevNov As Double
    Private _RevDec As Double
    Private _PinkSlipJan As Double
    Private _PinkSlipFeb As Double
    Private _PinkSlipMar As Double
    Private _PinkSlipApr As Double
    Private _PinkSlipMay As Double
    Private _PinkSlipJun As Double
    Private _PinkSlipJul As Double
    Private _PinkSlipAug As Double
    Private _PinkSlipSep As Double
    Private _PinkSlipOct As Double
    Private _PinkSlipNov As Double
    Private _PinkSlipDec As Double
    Private _BudgetTotal As Double
    Private _Status As String
    Private _VersionNo As Double


#End Region
#Region "Public Member Declarations"
    Public Property BudgetID() As String
        Get
            Return _BudgetID
        End Get
        Set(ByVal value As String)
            _BudgetID = value
        End Set
    End Property
    Public Property BudgetYear() As Integer
        Get
            Return _BudgetYear
        End Get
        Set(ByVal value As Integer)
            _BudgetYear = value
        End Set
    End Property

    Public Property COAId() As String
        Get
            Return _COAId
        End Get
        Set(ByVal value As String)
            _COAId = value
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
    'Public Property Amount() As Double
    '    Get
    '        Return _Amount
    '    End Get
    '    Set(ByVal value As Double)
    '        _Amount = value
    '    End Set
    'End Property
    Public Property Remarks() As String
        Get
            Return _Remarks
        End Get
        Set(ByVal value As String)
            _Remarks = value
        End Set
    End Property
    Public Property RevJan() As Double
        Get
            Return _RevJan
        End Get
        Set(ByVal value As Double)
            _RevJan = value
        End Set
    End Property
    Public Property RevFeb() As Double
        Get
            Return _RevFeb
        End Get
        Set(ByVal value As Double)
            _RevFeb = value
        End Set
    End Property
    Public Property RevMar() As Double
        Get
            Return _RevMar
        End Get
        Set(ByVal value As Double)
            _RevMar = value
        End Set
    End Property
    Public Property RevApr() As Double
        Get
            Return _RevApr
        End Get
        Set(ByVal value As Double)
            _RevApr = value
        End Set
    End Property


    Public Property RevMay() As Double
        Get
            Return _RevMay
        End Get
        Set(ByVal value As Double)
            _RevMay = value
        End Set
    End Property
    Public Property RevJun() As Double
        Get
            Return _RevJun
        End Get
        Set(ByVal value As Double)
            _RevJun = value
        End Set
    End Property
    Public Property RevJul() As Double
        Get
            Return _RevJul
        End Get
        Set(ByVal value As Double)
            _RevJul = value
        End Set
    End Property
    Public Property RevAug() As Double
        Get
            Return _RevAug
        End Get
        Set(ByVal value As Double)
            _RevAug = value
        End Set
    End Property

    Public Property RevSep() As Double
        Get
            Return _RevSep
        End Get
        Set(ByVal value As Double)
            _RevSep = value
        End Set
    End Property
    Public Property RevOct() As Double
        Get
            Return _RevOct
        End Get
        Set(ByVal value As Double)
            _RevOct = value
        End Set
    End Property
    Public Property RevNov() As Double
        Get
            Return _RevNov
        End Get
        Set(ByVal value As Double)
            _RevNov = value
        End Set
    End Property
    Public Property RevDec() As Double
        Get
            Return _RevDec
        End Get
        Set(ByVal value As Double)
            _RevDec = value
        End Set
    End Property


    Public Property BudgetJan() As Double
        Get
            Return _BudgetJan
        End Get
        Set(ByVal value As Double)
            _BudgetJan = value
        End Set
    End Property
    Public Property BudgetFeb() As Double
        Get
            Return _BudgetFeb
        End Get
        Set(ByVal value As Double)
            _BudgetFeb = value
        End Set
    End Property
    Public Property BudgetMar() As Double
        Get
            Return _BudgetMar
        End Get
        Set(ByVal value As Double)
            _BudgetMar = value
        End Set
    End Property
    Public Property BudgetApr() As Double
        Get
            Return _BudgetApr
        End Get
        Set(ByVal value As Double)
            _BudgetApr = value
        End Set
    End Property


    Public Property BudgetMay() As Double
        Get
            Return _BudgetMay
        End Get
        Set(ByVal value As Double)
            _BudgetMay = value
        End Set
    End Property
    Public Property BudgetJun() As Double
        Get
            Return _BudgetJun
        End Get
        Set(ByVal value As Double)
            _BudgetJun = value
        End Set
    End Property
    Public Property BudgetJul() As Double
        Get
            Return _BudgetJul
        End Get
        Set(ByVal value As Double)
            _BudgetJul = value
        End Set
    End Property
    Public Property BudgetAug() As Double
        Get
            Return _BudgetAug
        End Get
        Set(ByVal value As Double)
            _BudgetAug = value
        End Set
    End Property

    Public Property BudgetSep() As Double
        Get
            Return _BudgetSep
        End Get
        Set(ByVal value As Double)
            _BudgetSep = value
        End Set
    End Property
    Public Property BudgetOct() As Double
        Get
            Return _BudgetOct
        End Get
        Set(ByVal value As Double)
            _BudgetOct = value
        End Set
    End Property
    Public Property BudgetNov() As Double
        Get
            Return _BudgetNov
        End Get
        Set(ByVal value As Double)
            _BudgetNov = value
        End Set
    End Property
    Public Property BudgetDec() As Double
        Get
            Return _BudgetDec
        End Get
        Set(ByVal value As Double)
            _BudgetDec = value
        End Set
    End Property

    Public Property BudgetTotal() As Double
        Get
            Return _BudgetTotal
        End Get
        Set(ByVal value As Double)
            _BudgetTotal = value
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


    Public Property PinkSlipJan() As Double
        Get
            Return _PinkSlipJan
        End Get
        Set(ByVal value As Double)
            _PinkSlipJan = value
        End Set
    End Property
    Public Property PinkSlipFeb() As Double
        Get
            Return _PinkSlipFeb
        End Get
        Set(ByVal value As Double)
            _PinkSlipFeb = value
        End Set
    End Property
    Public Property PinkSlipMar() As Double
        Get
            Return _PinkSlipMar
        End Get
        Set(ByVal value As Double)
            _PinkSlipMar = value
        End Set
    End Property
    Public Property PinkSlipApr() As Double
        Get
            Return _PinkSlipApr
        End Get
        Set(ByVal value As Double)
            _PinkSlipApr = value
        End Set
    End Property


    Public Property PinkSlipMay() As Double
        Get
            Return _PinkSlipMay
        End Get
        Set(ByVal value As Double)
            _PinkSlipMay = value
        End Set
    End Property
    Public Property PinkSlipJun() As Double
        Get
            Return _PinkSlipJun
        End Get
        Set(ByVal value As Double)
            _PinkSlipJun = value
        End Set
    End Property
    Public Property PinkSlipJul() As Double
        Get
            Return _PinkSlipJul
        End Get
        Set(ByVal value As Double)
            _PinkSlipJul = value
        End Set
    End Property
    Public Property PinkSlipAug() As Double
        Get
            Return _PinkSlipAug
        End Get
        Set(ByVal value As Double)
            _PinkSlipAug = value
        End Set
    End Property

    Public Property PinkSlipSep() As Double
        Get
            Return _PinkSlipSep
        End Get
        Set(ByVal value As Double)
            _PinkSlipSep = value
        End Set
    End Property
    Public Property PinkSlipOct() As Double
        Get
            Return _PinkSlipOct
        End Get
        Set(ByVal value As Double)
            _PinkSlipOct = value
        End Set
    End Property
    Public Property PinkSlipNov() As Double
        Get
            Return _PinkSlipNov
        End Get
        Set(ByVal value As Double)
            _PinkSlipNov = value
        End Set
    End Property
    Public Property PinkSlipDec() As Double
        Get
            Return _PinkSlipDec
        End Get
        Set(ByVal value As Double)
            _PinkSlipDec = value
        End Set
    End Property

    Public Property VersionNo() As Double
        Get
            Return _VersionNo
        End Get
        Set(ByVal value As Double)
            _VersionNo = value
        End Set
    End Property

    Public Property BudgetType() As String
        Get
            Return _BudgetType
        End Get
        Set(ByVal value As String)
            _BudgetType = value
        End Set
    End Property
    Public Property SubDesc() As String
        Get
            Return _SubDesc
        End Get
        Set(ByVal value As String)
            _SubDesc = value
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
    Public Property Cost() As Decimal
        Get
            Return _Cost
        End Get
        Set(ByVal value As Decimal)
            _Cost = value
        End Set
    End Property
    Public Property Price() As Decimal
        Get
            Return _Price
        End Get
        Set(ByVal value As Decimal)
            _Price = value
        End Set
    End Property
    Public Property Day() As Integer
        Get
            Return _Day
        End Get
        Set(ByVal value As Integer)
            _Day = value
        End Set
    End Property
    Public Property Month() As Integer
        Get
            Return _Month
        End Get
        Set(ByVal value As Integer)
            _Month = value
        End Set
    End Property
    Public Property Percentage() As Decimal
        Get
            Return _Percentage
        End Get
        Set(ByVal value As Decimal)
            _Percentage = value
        End Set
    End Property
#End Region
End Class
