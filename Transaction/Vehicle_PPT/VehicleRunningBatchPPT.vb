Imports System
Imports System.ComponentModel
Imports System.Diagnostics
Imports System.Collections
Imports System.Collections.ObjectModel
Imports System.Collections.Generic

Public Class VehicleRunningBatchPPT

    'type prop + TAB + TAB for property initialization

    Private liID As Integer
    Public Property piID() As Integer
        Get
            Return liID
        End Get
        Set(ByVal value As Integer)
            liID = value
        End Set
    End Property

    Private ldVHBatchDT As Date
    Public Property pdVHBatchDT() As Date
        Get
            Return ldVHBatchDT
        End Get
        Set(ByVal value As Date)
            ldVHBatchDT = value
        End Set
    End Property

    Private lsVHID As String
    Public Property psVHID() As String
        Get
            Return lsVHID
        End Get
        Set(ByVal value As String)
            lsVHID = value
        End Set
    End Property


    Private lsVHWSCode As String
    Public Property psVHWSCode() As String
        Get
            Return lsVHWSCode
        End Get
        Set(ByVal value As String)
            lsVHWSCode = value
        End Set
    End Property

    Private lsEstateID As String
    Public Property psEstateID() As String
        Get
            Return lsEstateID
        End Get
        Set(ByVal value As String)
            lsEstateID = value
        End Set
    End Property

    Private lsActiveMonthYearID As String
    Public Property psActiveMonthYearID() As String
        Get
            Return lsActiveMonthYearID
        End Get
        Set(ByVal value As String)
            lsActiveMonthYearID = value
        End Set
    End Property

    Private lsVHBatchOperatorName As String
    Public Property psVHBatchOperatorName() As String
        Get
            Return lsVHBatchOperatorName
        End Get
        Set(ByVal value As String)
            lsVHBatchOperatorName = value
        End Set
    End Property

    Private lcUOM As Char
    Public Property pcUOM() As Char
        Get
            Return lcUOM
        End Get
        Set(ByVal value As Char)
            lcUOM = value
        End Set
    End Property

    Private liVHBatchValue As Decimal
    Public Property piVHBatchValue() As Decimal
        Get
            Return liVHBatchValue
        End Get
        Set(ByVal value As Decimal)
            liVHBatchValue = value
        End Set
    End Property

    Private lsCreateBy As String
    Public Property psCreateBy() As String
        Get
            Return lsCreateBy
        End Get
        Set(ByVal value As String)
            lsCreateBy = value
        End Set
    End Property

    Private lsModifiedBy As String
    Public Property psModifiedBy() As String
        Get
            Return lsModifiedBy
        End Get
        Set(ByVal value As String)
            lsModifiedBy = value
        End Set
    End Property

    Private lsSearchBy As String
    Public Property psSearchBy() As String
        Get
            Return lsSearchBy
        End Get
        Set(ByVal value As String)
            lsSearchBy = value
        End Set
    End Property

    Private lsConcurrencyID As Byte()
    Public Property piConcurrencyId() As Byte()
        Get
            Return lsConcurrencyID
        End Get
        Set(ByVal value As Byte())
            lsConcurrencyID = value
        End Set
    End Property

End Class
