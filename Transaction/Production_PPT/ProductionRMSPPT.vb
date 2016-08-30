Public Class ProductionRMSPPT
    Private _ID As Decimal?
    Public Property ID() As Decimal?
        Get
            Return _ID
        End Get
        Set(ByVal value As Decimal?)
            _ID = value
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

    Private _RMSLoc As String
    Public Property RMSLoc() As String
        Get
            Return _RMSLoc
        End Get
        Set(ByVal value As String)
            _RMSLoc = value
        End Set
    End Property


    Private _RMSLocDesc As String
    Public Property RMSLocDesc() As String
        Get
            Return _RMSLocDesc
        End Get
        Set(ByVal value As String)
            _RMSLocDesc = value
        End Set
    End Property

    Private _RMSProduct As String
    Public Property RMSProduct() As String
        Get
            Return _RMSProduct
        End Get
        Set(ByVal value As String)
            _RMSProduct = value
        End Set
    End Property

    Private _RMSStorage As String
    Public Property RMSStorage() As String
        Get
            Return _RMSStorage
        End Get
        Set(ByVal value As String)
            _RMSStorage = value
        End Set
    End Property

    Private _RMSTodayWet As Decimal
    Public Property RMSTodayWet() As Decimal
        Get
            Return _RMSTodayWet
        End Get
        Set(ByVal value As Decimal)
            _RMSTodayWet = value
        End Set
    End Property

    Private _RMSTodayDry As Decimal
    Public Property RMSTodayDry() As Decimal
        Get
            Return _RMSTodayDry
        End Get
        Set(ByVal value As Decimal)
            _RMSTodayDry = value
        End Set
    End Property

    Private _RMSTodateWet As Decimal
    Public Property RMSTodateWet() As Decimal
        Get
            Return _RMSTodateWet
        End Get
        Set(ByVal value As Decimal)
            _RMSTodateWet = value
        End Set
    End Property

    Private _RMSTodateDry As Decimal
    Public Property RMSTodateDry() As Decimal
        Get
            Return _RMSTodateDry
        End Get
        Set(ByVal value As Decimal)
            _RMSTodateDry = value
        End Set
    End Property

    Private _RMSEstateId As String
    Public Property RMSEstateId() As String
        Get
            Return _RMSEstateId
        End Get
        Set(ByVal value As String)
            _RMSEstateId = value
        End Set
    End Property

End Class
