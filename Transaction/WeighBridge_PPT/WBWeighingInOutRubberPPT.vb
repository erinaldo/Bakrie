

Public Class WBWeighingInOutRubberPPT
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

    Private _WBTicketNo As String
    Public Property WBTicketNo() As String
        Get
            Return _WBTicketNo
        End Get
        Set(ByVal value As String)
            _WBTicketNo = value
        End Set
    End Property


    Private _VehicleID As String
    Public Property VehicleID() As String
        Get
            Return _VehicleID
        End Get
        Set(ByVal value As String)
            _VehicleID = value
        End Set
    End Property


    Private _EstateID As String
    Public Property EstateID() As String
        Get
            Return _EstateID
        End Get
        Set(ByVal value As String)
            _EstateID = value
        End Set
    End Property

    Private _DivID As String
    Public Property DivID() As String
        Get
            Return _DivID
        End Get
        Set(ByVal value As String)
            _DivID = value
        End Set
    End Property


    Private _Wet As Decimal
    Public Property Wet() As Decimal
        Get
            Return _Wet
        End Get
        Set(ByVal value As Decimal)
            _Wet = value
        End Set
    End Property

    Private _Dry As Decimal
    Public Property Dry() As Decimal
        Get
            Return _Dry
        End Get
        Set(ByVal value As Decimal)
            _Dry = value
        End Set
    End Property

    Private _DRCPct As String
    Public Property DRCPct() As String
        Get
            Return _DRCPct
        End Get
        Set(ByVal value As String)
            _DRCPct = value
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
