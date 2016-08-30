Public Class ProductionTransferPPT
    Private _Id As Decimal
    Public Property Id() As Decimal
        Get
            Return _Id
        End Get
        Set(ByVal value As Decimal)
            _Id = value
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

    Private _ProductFrom As String
    Public Property ProductFrom() As String
        Get
            Return _ProductFrom
        End Get
        Set(ByVal value As String)
            _ProductFrom = value
        End Set
    End Property

    Private _StorageFrom As String
    Public Property StorageFrom() As String
        Get
            Return _StorageFrom
        End Get
        Set(ByVal value As String)
            _StorageFrom = value
        End Set
    End Property

    Private _ProductTo As String
    Public Property ProductTo() As String
        Get
            Return _ProductTo
        End Get
        Set(ByVal value As String)
            _ProductTo = value
        End Set
    End Property

    Private _StorageTo As String
    Public Property StorageTo() As String
        Get
            Return _StorageTo
        End Get
        Set(ByVal value As String)
            _StorageTo = value
        End Set
    End Property

    Private _Remarks As String
    Public Property Remarks() As String
        Get
            Return _Remarks
        End Get
        Set(ByVal value As String)
            _Remarks = value
        End Set
    End Property

    Private _QtyFromWet As Decimal
    Public Property QtyFromWet() As Decimal
        Get
            Return _QtyFromWet
        End Get
        Set(ByVal value As Decimal)
            _QtyFromWet = value
        End Set
    End Property

    Private _QtyFromDry As Decimal
    Public Property QtyFromDry() As Decimal
        Get
            Return _QtyFromDry
        End Get
        Set(ByVal value As Decimal)
            _QtyFromDry = value
        End Set
    End Property

    Private _QtyToWet As Decimal
    Public Property QtyToWet() As Decimal
        Get
            Return _QtyToWet
        End Get
        Set(ByVal value As Decimal)
            _QtyToWet = value
        End Set
    End Property

    Private _QtyToDry As Decimal
    Public Property QtyToDry() As Decimal
        Get
            Return _QtyToDry
        End Get
        Set(ByVal value As Decimal)
            _QtyToDry = value
        End Set
    End Property

    Private _tstamp As Byte()
    Public Property Tstamp() As Byte()
        Get
            Return _tstamp
        End Get
        Set(ByVal value As Byte())
            _tstamp = value
        End Set
    End Property
End Class
