Public Class ProductionLogBSRPPT
    Private _ID As Decimal?
    Public Property ID() As Decimal?
        Get
            Return _ID
        End Get
        Set(ByVal value As Decimal?)
            _ID = value
        End Set
    End Property

    Private _TransId As Decimal?
    Public Property TransId() As Decimal?
        Get
            Return _TransId
        End Get
        Set(ByVal value As Decimal?)
            _TransId = value
        End Set
    End Property

    Private _DocDate As DateTime?
    Public Property DocDate() As DateTime?
        Get
            Return _DocDate
        End Get
        Set(ByVal value As DateTime?)
            _DocDate = value
        End Set
    End Property

    Private _BSRAssistant As String
    Public Property BSRAssistant() As String
        Get
            Return _BSRAssistant
        End Get
        Set(ByVal value As String)
            _BSRAssistant = value
        End Set
    End Property


    Private _BSRStartTime As String
    Public Property BSRStartTime() As String
        Get
            Return _BSRStartTime
        End Get
        Set(ByVal value As String)
            _BSRStartTime = value
        End Set
    End Property

    Private _BSRStopTime As String
    Public Property BSRStopTime() As String
        Get
            Return _BSRStopTime
        End Get
        Set(ByVal value As String)
            _BSRStopTime = value
        End Set
    End Property

    Private _BSRBdTime As String
    Public Property BSRBdTime() As String
        Get
            Return _BSRBdTime
        End Get
        Set(ByVal value As String)
            _BSRBdTime = value
        End Set
    End Property

    Private _BSRSHrs As String
    Public Property BSRSHrs() As String
        Get
            Return _BSRSHrs
        End Get
        Set(ByVal value As String)
            _BSRSHrs = value
        End Set
    End Property

    Private _BSRProduct As String
    Public Property BSRProduct() As String
        Get
            Return _BSRProduct
        End Get
        Set(ByVal value As String)
            _BSRProduct = value
        End Set
    End Property

    Private _BSRStorage As String
    Public Property BSRStorage() As String
        Get
            Return _BSRStorage
        End Get
        Set(ByVal value As String)
            _BSRStorage = value
        End Set
    End Property

    Private _BSRTL As Decimal
    Public Property BSRTL() As Decimal
        Get
            Return _BSRTL
        End Get
        Set(ByVal value As Decimal)
            _BSRTL = value
        End Set
    End Property

    Private _BSRWS As Decimal
    Public Property BSRWS() As Decimal
        Get
            Return _BSRWS
        End Get
        Set(ByVal value As Decimal)
            _BSRWS = value
        End Set
    End Property

    Private _BSRSLDry As Decimal
    Public Property BSRSLDry() As Decimal
        Get
            Return _BSRSLDry
        End Get
        Set(ByVal value As Decimal)
            _BSRSLDry = value
        End Set
    End Property

    Private _BSRSL As Decimal
    Public Property BSRSL() As Decimal
        Get
            Return _BSRSL
        End Get
        Set(ByVal value As Decimal)
            _BSRSL = value
        End Set
    End Property

    Private _BSRBT As Decimal
    Public Property BSRBT() As Decimal
        Get
            Return _BSRBT
        End Get
        Set(ByVal value As Decimal)
            _BSRBT = value
        End Set
    End Property

    Private _BSRCP As Decimal
    Public Property BSRCP() As Decimal
        Get
            Return _BSRCP
        End Get
        Set(ByVal value As Decimal)
            _BSRCP = value
        End Set
    End Property

End Class
