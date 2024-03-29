﻿Public Class EstMillDeliveryDetPPT
#Region "Privete Member Declarations"
    Private _STEstMillDeliveryID As String = String.Empty
    Private _LPOorIPR As Char
    Private _IDNNO As String = String.Empty
    Private _IDNDate As Date = Date.Now
    Private _GRNNo As String = String.Empty
    Private _PONo As String = String.Empty
    Private _STLPOID As String = String.Empty
    Private _STIPRID As String = String.Empty
    Private _DeliverySource As String = String.Empty
    Private _Remarks As String = String.Empty
    Private _SupplierID As String = String.Empty
    Private _Status As String = String.Empty
    Private _RejectedReason As String = String.Empty
    Private _OperatorName As String = String.Empty
    Private _TransportDate As Date = Date.Now
    Private _VehicleNo As String = String.Empty
    Private _STEstMillDeliveryDetID As String = String.Empty
    Private _STLPODetID As String = String.Empty
    Private _STIPRDetID As String = String.Empty
    Private _StockID As String = String.Empty
    Private _PartNo As String = String.Empty
    Private _COAID As String = String.Empty
    Private _AvailQty As Integer
    Private _UnitPrice As Integer
    Private _T0 As String = String.Empty
    Private _RequestedQty As Integer
    Private _ReceivedQty As Integer
    Private _ReceivedPrice As Integer
    Private _TotalPrice As Integer

#End Region
#Region "public Member Declarations"
    Public Property STEstMillDeliveryID() As String
        Get
            Return _STEstMillDeliveryID
        End Get
        Set(ByVal value As String)
            _STEstMillDeliveryID = value

        End Set
    End Property
    Public Property LPOorIPR() As String
        Get
            Return _LPOorIPR
        End Get
        Set(ByVal value As String)
            _LPOorIPR = value
        End Set
    End Property
    Public Property IDNNO() As Char
        Get
            Return _IDNNO
        End Get
        Set(ByVal value As Char)
            _IDNNO = value

        End Set
    End Property
    Public Property IDNDate() As Date
        Get
            Return _IDNDate
        End Get
        Set(ByVal value As Date)
            _IDNDate = value
        End Set
    End Property
    Public Property GRNNo() As String
        Get
            Return _GRNNo
        End Get
        Set(ByVal value As String)
            _GRNNo = value

        End Set
    End Property
    Public Property PONo() As String
        Get
            Return _PONo
        End Get
        Set(ByVal value As String)
            _PONo = value

        End Set
    End Property
    Public Property STLPOID() As String
        Get
            Return _STLPOID
        End Get
        Set(ByVal value As String)
            _STLPOID = value

        End Set
    End Property
    Public Property STIPRID() As String
        Get
            Return _STIPRID
        End Get
        Set(ByVal value As String)
            _STIPRID = value

        End Set
    End Property
    Public Property DeliverySource() As String
        Get
            Return _DeliverySource
        End Get
        Set(ByVal value As String)
            _DeliverySource = value

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
    Public Property SupplierID() As String
        Get
            Return _SupplierID
        End Get
        Set(ByVal value As String)
            _SupplierID = value

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
    Public Property RejectedReason() As String
        Get
            Return _RejectedReason
        End Get
        Set(ByVal value As String)
            _RejectedReason = value

        End Set
    End Property
    Public Property OperatorName() As String
        Get
            Return _OperatorName
        End Get
        Set(ByVal value As String)
            _OperatorName = value

        End Set
    End Property
    Public Property TransportDate() As String
        Get
            Return _TransportDate
        End Get
        Set(ByVal value As String)
            _TransportDate = value

        End Set
    End Property
    Public Property VehicleNo() As String
        Get
            Return _VehicleNo
        End Get
        Set(ByVal value As String)
            _VehicleNo = value
        End Set
    End Property
    Public Property STEstMillDeliveryDetID() As String
        Get
            Return _STEstMillDeliveryDetID
        End Get
        Set(ByVal value As String)
            _STEstMillDeliveryDetID = value
        End Set
    End Property

    Public Property STLPODetID() As String
        Get
            Return _STLPODetID
        End Get
        Set(ByVal value As String)
            _STLPODetID = value
        End Set
    End Property

    Public Property STIPRDetID() As String
        Get
            Return _STIPRDetID
        End Get
        Set(ByVal value As String)
            _STIPRDetID = value
        End Set
    End Property

    Public Property StockID() As String
        Get
            Return _StockID
        End Get
        Set(ByVal value As String)
            _StockID = value
        End Set
    End Property

    Public Property PartNo() As String
        Get
            Return _PartNo
        End Get
        Set(ByVal value As String)
            _PartNo = value
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

    Public Property AvailQty() As Integer
        Get
            Return _AvailQty
        End Get
        Set(ByVal value As Integer)
            _AvailQty = value
        End Set
    End Property

    Public Property UnitPrice() As Integer
        Get
            Return _UnitPrice
        End Get
        Set(ByVal value As Integer)
            _UnitPrice = value
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

    Public Property RequestedQty() As Integer
        Get
            Return _RequestedQty
        End Get
        Set(ByVal value As Integer)
            _RequestedQty = value
        End Set
    End Property

    Public Property ReceivedQty() As Integer
        Get
            Return _ReceivedQty
        End Get
        Set(ByVal value As Integer)
            _ReceivedQty = value
        End Set
    End Property

    Public Property ReceivedPrice() As Integer
        Get
            Return _ReceivedPrice
        End Get
        Set(ByVal value As Integer)
            _ReceivedPrice = value
        End Set
    End Property

    Public Property TotalPrice() As Integer
        Get
            Return _TotalPrice
        End Get
        Set(ByVal value As Integer)
            _TotalPrice = value
        End Set
    End Property


#End Region
End Class
