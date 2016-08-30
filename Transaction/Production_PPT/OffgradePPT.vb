Public Class OffgradePPT
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

    Private _OGContract As String
    Public Property OGContract() As String
        Get
            Return _OGContract
        End Get
        Set(ByVal value As String)
            _OGContract = value
        End Set
    End Property


    Private _OGCust As String
    Public Property OGCust() As String
        Get
            Return _OGCust
        End Get
        Set(ByVal value As String)
            _OGCust = value
        End Set
    End Property

    Private _OGDo As String
    Public Property OGDo() As String
        Get
            Return _OGDo
        End Get
        Set(ByVal value As String)
            _OGDo = value
        End Set
    End Property

    Private _OGTruckId As String
    Public Property OGTruckId() As String
        Get
            Return _OGTruckId
        End Get
        Set(ByVal value As String)
            _OGTruckId = value
        End Set
    End Property

    Private _OGStorage As String
    Public Property OGStorage() As String
        Get
            Return _OGStorage
        End Get
        Set(ByVal value As String)
            _OGStorage = value
        End Set
    End Property

    Private _OGProduct As String
    Public Property OGProduct() As String
        Get
            Return _OGProduct
        End Get
        Set(ByVal value As String)
            _OGProduct = value
        End Set
    End Property

    Private _OGWet As Decimal
    Public Property OGWet() As Decimal
        Get
            Return _OGWet
        End Get
        Set(ByVal value As Decimal)
            _OGWet = value
        End Set
    End Property

    Private _OGDry As Decimal
    Public Property OGDry() As Decimal
        Get
            Return _OGDry
        End Get
        Set(ByVal value As Decimal)
            _OGDry = value
        End Set
    End Property

    Private _OGDrc As Decimal
    Public Property OGDrc() As Decimal
        Get
            Return _OGDrc
        End Get
        Set(ByVal value As Decimal)
            _OGDrc = value
        End Set
    End Property
End Class
