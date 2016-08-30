Public Class WipPPT
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

    Private _WIPStation As String
    Public Property WIPStation() As String
        Get
            Return _WIPStation
        End Get
        Set(ByVal value As String)
            _WIPStation = value
        End Set
    End Property


    Private _WIPProduct As String
    Public Property WIPProduct() As String
        Get
            Return _WIPProduct
        End Get
        Set(ByVal value As String)
            _WIPProduct = value
        End Set
    End Property

    Private _WIPStorage As String
    Public Property WIPStorage() As String
        Get
            Return _WIPStorage
        End Get
        Set(ByVal value As String)
            _WIPStorage = value
        End Set
    End Property

    Private _WIPClass As String
    Public Property WIPClass() As String
        Get
            Return _WIPClass
        End Get
        Set(ByVal value As String)
            _WIPClass = value
        End Set
    End Property

    Private _WIPCenexWet As Decimal
    Public Property WIPCenexWet() As Decimal
        Get
            Return _WIPCenexWet
        End Get
        Set(ByVal value As Decimal)
            _WIPCenexWet = value
        End Set
    End Property

    Private _WIPCenexDry As Decimal
    Public Property WIPCenexDry() As Decimal
        Get
            Return _WIPCenexDry
        End Get
        Set(ByVal value As Decimal)
            _WIPCenexDry = value
        End Set
    End Property

    Private _WIPQtyDry As Decimal
    Public Property WIPQtyDry() As Decimal
        Get
            Return _WIPQtyDry
        End Get
        Set(ByVal value As Decimal)
            _WIPQtyDry = value
        End Set
    End Property

    Private _WIPDrc As Decimal
    Public Property WIPDrc() As Decimal
        Get
            Return _WIPDrc
        End Get
        Set(ByVal value As Decimal)
            _WIPDrc = value
        End Set
    End Property

    Private _WIPEstateId As String
    Public Property WIPEstateId() As String
        Get
            Return _WIPEstateId
        End Get
        Set(ByVal value As String)
            _WIPEstateId = value
        End Set
    End Property
End Class
