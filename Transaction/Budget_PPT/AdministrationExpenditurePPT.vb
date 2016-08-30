Public Class AdministrationExpenditurePPT
#Region "Private Member Declarations"


    

    Private _BudgetID As String = String.Empty
    Private _BudgetType As String = String.Empty

    Private _BudgetYear As Integer
    Private _COAId As String = String.Empty
    Private _COACode As String = String.Empty
    Private _COADescp As String = String.Empty

    Private _SubDesc As String = String.Empty
    Private _Qty As Decimal
    Private _Cost As Decimal
    Private _Price As Decimal
    Private _Day As Integer
    Private _Month As Integer
    Private _Percentage As Decimal


    'Private _Amount As Decimal
    Private _Remarks As String = String.Empty
    Private _BudgetJan As Decimal
    Private _BudgetFeb As Decimal
    Private _BudgetMar As Decimal
    Private _BudgetApr As Decimal
    Private _BudgetMay As Decimal
    Private _BudgetJun As Decimal
    Private _BudgetJul As Decimal
    Private _BudgetAug As Decimal
    Private _BudgetSep As Decimal
    Private _BudgetOct As Decimal
    Private _BudgetNov As Decimal
    Private _BudgetDec As Decimal
    Private _RevJan As Decimal
    Private _RevFeb As Decimal
    Private _RevMar As Decimal
    Private _RevApr As Decimal
    Private _RevMay As Decimal
    Private _RevJun As Decimal
    Private _RevJul As Decimal
    Private _RevAug As Decimal
    Private _RevSep As Decimal
    Private _RevOct As Decimal
    Private _RevNov As Decimal
    Private _RevDec As Decimal
    Private _PinkJan As Decimal
    Private _PinkFeb As Decimal
    Private _PinkMar As Decimal
    Private _PinkApr As Decimal
    Private _PinkMay As Decimal
    Private _PinkJun As Decimal
    Private _PinkJul As Decimal
    Private _PinkAug As Decimal
    Private _PinkSep As Decimal
    Private _PinkOct As Decimal
    Private _PinkNov As Decimal
    Private _PinkDec As Decimal
    Private _BudgetTotal As Decimal
    Private _Status As String
    Private _VersionNo As Decimal


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
    Public Property Remarks() As String
        Get
            Return _Remarks
        End Get
        Set(ByVal value As String)
            _Remarks = value
        End Set
    End Property
    Public Property RevJan() As Decimal
        Get
            Return _RevJan
        End Get
        Set(ByVal value As Decimal)
            _RevJan = value
        End Set
    End Property
    Public Property RevFeb() As Decimal
        Get
            Return _RevFeb
        End Get
        Set(ByVal value As Decimal)
            _RevFeb = value
        End Set
    End Property
    Public Property RevMar() As Decimal
        Get
            Return _RevMar
        End Get
        Set(ByVal value As Decimal)
            _RevMar = value
        End Set
    End Property
    Public Property RevApr() As Decimal
        Get
            Return _RevApr
        End Get
        Set(ByVal value As Decimal)
            _RevApr = value
        End Set
    End Property


    Public Property RevMay() As Decimal
        Get
            Return _RevMay
        End Get
        Set(ByVal value As Decimal)
            _RevMay = value
        End Set
    End Property
    Public Property RevJun() As Decimal
        Get
            Return _RevJun
        End Get
        Set(ByVal value As Decimal)
            _RevJun = value
        End Set
    End Property
    Public Property RevJul() As Decimal
        Get
            Return _RevJul
        End Get
        Set(ByVal value As Decimal)
            _RevJul = value
        End Set
    End Property
    Public Property RevAug() As Decimal
        Get
            Return _RevAug
        End Get
        Set(ByVal value As Decimal)
            _RevAug = value
        End Set
    End Property

    Public Property RevSep() As Decimal
        Get
            Return _RevSep
        End Get
        Set(ByVal value As Decimal)
            _RevSep = value
        End Set
    End Property
    Public Property RevOct() As Decimal
        Get
            Return _RevOct
        End Get
        Set(ByVal value As Decimal)
            _RevOct = value
        End Set
    End Property
    Public Property RevNov() As Decimal
        Get
            Return _RevNov
        End Get
        Set(ByVal value As Decimal)
            _RevNov = value
        End Set
    End Property
    Public Property RevDec() As Decimal
        Get
            Return _RevDec
        End Get
        Set(ByVal value As Decimal)
            _RevDec = value
        End Set
    End Property


    Public Property BudgetJan() As Decimal
        Get
            Return _BudgetJan
        End Get
        Set(ByVal value As Decimal)
            _BudgetJan = value
        End Set
    End Property
    Public Property BudgetFeb() As Decimal
        Get
            Return _BudgetFeb
        End Get
        Set(ByVal value As Decimal)
            _BudgetFeb = value
        End Set
    End Property
    Public Property BudgetMar() As Decimal
        Get
            Return _BudgetMar
        End Get
        Set(ByVal value As Decimal)
            _BudgetMar = value
        End Set
    End Property
    Public Property BudgetApr() As Decimal
        Get
            Return _BudgetApr
        End Get
        Set(ByVal value As Decimal)
            _BudgetApr = value
        End Set
    End Property


    Public Property BudgetMay() As Decimal
        Get
            Return _BudgetMay
        End Get
        Set(ByVal value As Decimal)
            _BudgetMay = value
        End Set
    End Property
    Public Property BudgetJun() As Decimal
        Get
            Return _BudgetJun
        End Get
        Set(ByVal value As Decimal)
            _BudgetJun = value
        End Set
    End Property
    Public Property BudgetJul() As Decimal
        Get
            Return _BudgetJul
        End Get
        Set(ByVal value As Decimal)
            _BudgetJul = value
        End Set
    End Property
    Public Property BudgetAug() As Decimal
        Get
            Return _BudgetAug
        End Get
        Set(ByVal value As Decimal)
            _BudgetAug = value
        End Set
    End Property

    Public Property BudgetSep() As Decimal
        Get
            Return _BudgetSep
        End Get
        Set(ByVal value As Decimal)
            _BudgetSep = value
        End Set
    End Property
    Public Property BudgetOct() As Decimal
        Get
            Return _BudgetOct
        End Get
        Set(ByVal value As Decimal)
            _BudgetOct = value
        End Set
    End Property
    Public Property BudgetNov() As Decimal
        Get
            Return _BudgetNov
        End Get
        Set(ByVal value As Decimal)
            _BudgetNov = value
        End Set
    End Property
    Public Property BudgetDec() As Decimal
        Get
            Return _BudgetDec
        End Get
        Set(ByVal value As Decimal)
            _BudgetDec = value
        End Set
    End Property

    Public Property BudgetTotal() As Decimal
        Get
            Return _BudgetTotal
        End Get
        Set(ByVal value As Decimal)
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


    Public Property PinkJan() As Decimal
        Get
            Return _PinkJan
        End Get
        Set(ByVal value As Decimal)
            _PinkJan = value
        End Set
    End Property
    Public Property PinkFeb() As Decimal
        Get
            Return _PinkFeb
        End Get
        Set(ByVal value As Decimal)
            _PinkFeb = value
        End Set
    End Property
    Public Property PinkMar() As Decimal
        Get
            Return _PinkMar
        End Get
        Set(ByVal value As Decimal)
            _PinkMar = value
        End Set
    End Property
    Public Property PinkApr() As Decimal
        Get
            Return _PinkApr
        End Get
        Set(ByVal value As Decimal)
            _PinkApr = value
        End Set
    End Property


    Public Property PinkMay() As Decimal
        Get
            Return _PinkMay
        End Get
        Set(ByVal value As Decimal)
            _PinkMay = value
        End Set
    End Property
    Public Property PinkJun() As Decimal
        Get
            Return _PinkJun
        End Get
        Set(ByVal value As Decimal)
            _PinkJun = value
        End Set
    End Property
    Public Property PinkJul() As Decimal
        Get
            Return _PinkJul
        End Get
        Set(ByVal value As Decimal)
            _PinkJul = value
        End Set
    End Property
    Public Property PinkAug() As Decimal
        Get
            Return _PinkAug
        End Get
        Set(ByVal value As Decimal)
            _PinkAug = value
        End Set
    End Property

    Public Property PinkSep() As Decimal
        Get
            Return _PinkSep
        End Get
        Set(ByVal value As Decimal)
            _PinkSep = value
        End Set
    End Property
    Public Property PinkOct() As Decimal
        Get
            Return _PinkOct
        End Get
        Set(ByVal value As Decimal)
            _PinkOct = value
        End Set
    End Property
    Public Property PinkNov() As Decimal
        Get
            Return _PinkNov
        End Get
        Set(ByVal value As Decimal)
            _PinkNov = value
        End Set
    End Property
    Public Property PinkDec() As Decimal
        Get
            Return _PinkDec
        End Get
        Set(ByVal value As Decimal)
            _PinkDec = value
        End Set
    End Property

    Public Property VersionNo() As Decimal
        Get
            Return _VersionNo
        End Get
        Set(ByVal value As Decimal)
            _VersionNo = value
        End Set
    End Property
#End Region
End Class

