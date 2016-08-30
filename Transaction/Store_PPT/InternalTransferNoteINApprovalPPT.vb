﻿Public Class InternalTransferNoteINApprovalPPT
#Region "Private Member Declarations"
    Private _STInternalTransferInID As String = String.Empty
    Private _ItnInNo As String = String.Empty
    Private _ITNDate As Date = Date.Today
    Private _Remarks As String = String.Empty
    Private _RejectedReason As String = String.Empty
    Private _Status As String = String.Empty
    Private _STInternalTransferInDetailsID As String = String.Empty
    Private _StockID As String = String.Empty
    Private _StockCode As String = String.Empty
    Private _StockDesc As String = String.Empty
    Private _PartNo As String = String.Empty
    Private _AvailQty As Double = 0.0
    Private _UnitPrice As Double = 0.0
    Private _COAID As String = String.Empty
    Private _TransferInQty As Double = 0.0
    Private _TransferInValue As Double = 0.0
    Private _SenderLocation As String = String.Empty

#End Region
#Region "Public Member Declarations"
    Public Property STInternalTransferInID() As String
        Get
            Return _STInternalTransferInID
        End Get
        Set(ByVal value As String)
            _STInternalTransferInID = value
        End Set
    End Property
    Public Property ItnInNo() As String
        Get
            Return _ItnInNo
        End Get
        Set(ByVal value As String)
            _ItnInNo = value
        End Set
    End Property
    Public Property ITNDate() As Date
        Get
            Return _ITNDate
        End Get
        Set(ByVal value As Date)
            _ITNDate = value
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
    Public Property RejectedReason() As String
        Get
            Return _RejectedReason
        End Get
        Set(ByVal value As String)
            _RejectedReason = value
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

    Public Property SenderLocation() As String
        Get
            Return _SenderLocation
        End Get
        Set(ByVal value As String)
            _SenderLocation = value
        End Set
    End Property


    Public Property STInternalTransferInDetailsID() As String
        Get
            Return _STInternalTransferInDetailsID
        End Get
        Set(ByVal value As String)
            _STInternalTransferInDetailsID = value
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
    Public Property StockCode() As String
        Get
            Return _StockCode
        End Get
        Set(ByVal value As String)
            _StockCode = value
        End Set
    End Property
    Public Property StockDesc() As String
        Get
            Return _StockDesc
        End Get
        Set(ByVal value As String)
            _StockDesc = value
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
    Public Property AvailQty() As Double
        Get
            Return _AvailQty
        End Get
        Set(ByVal value As Double)
            _AvailQty = value
        End Set
    End Property
    Public Property UnitPrice() As Double
        Get
            Return _UnitPrice
        End Get
        Set(ByVal value As Double)
            _UnitPrice = value
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
    Public Property TransferInQty() As Double
        Get
            Return _TransferInQty
        End Get
        Set(ByVal value As Double)
            _TransferInQty = value
        End Set
    End Property
    Public Property TransferInValue() As Double
        Get
            Return _TransferInValue
        End Get
        Set(ByVal value As Double)
            _TransferInValue = value
        End Set
    End Property

#End Region
End Class
