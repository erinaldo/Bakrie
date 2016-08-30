Public Class OperatingBudgetHourPPT
#Region "Private Member Declaration"
    Private _OperatingBudgetByHoursID As String = String.Empty
    Private _EstateID As String = String.Empty
    Private _BudgetYear As String = String.Empty
    Private _COAID As String = String.Empty
    Private _COACode As String = String.Empty
    Private _COADescp As String = String.Empty
    Private _VHID As String = String.Empty
    Private _VHNO As String = String.Empty
    Private _NoOfHours As Double
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
    Private _VersionNo As String = String.Empty
    Private _Status As String = String.Empty
    Private _BudgetTotal As Double
#End Region

#Region "Public Member Declaration"
    Public Property OperatingBudgetByHoursID() As String
        Get
            Return _OperatingBudgetByHoursID
        End Get
        Set(ByVal value As String)
            _OperatingBudgetByHoursID = value
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
    Public Property BudgetYear() As String
        Get
            Return _BudgetYear
        End Get
        Set(ByVal value As String)
            _BudgetYear = value
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
    Public Property VHNO() As String
        Get
            Return _VHNO
        End Get
        Set(ByVal value As String)
            _VHNO = value
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
    Public Property NoOfHours() As Double
        Get
            Return _NoOfHours
        End Get
        Set(ByVal value As Double)
            _NoOfHours = value
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

    Public Property VersionNo() As Double
        Get
            Return _VersionNo
        End Get
        Set(ByVal value As Double)
            _VersionNo = value
        End Set
    End Property
#End Region
End Class
