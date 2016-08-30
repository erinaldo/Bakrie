'created: Jum'at, 28 Aug 2009, 11:57
'update:  Jum'at, 28 Aug 2009: 22:19

Imports System

Public Class DailyActivityDistribution_PPT

#Region "Private Members Declarations"

    Private _DailyActivityDistribution As String = String.Empty
    Private _EstateID As String = String.Empty
    Private _ActiveMonthYearID As String = String.Empty

    Private _ContractID As String = String.Empty
    Private _ActivityID As String = String.Empty
    Private _StationID As String = String.Empty
    Private _DivID As String = String.Empty
    Private _YOPID As String = String.Empty

    Private _BlockID As String = String.Empty
    Private _T0 As String = String.Empty
    Private _T1 As String = String.Empty
    Private _T2 As String = String.Empty
    Private _T3 As String = String.Empty
    Private _T4 As String = String.Empty
    Private _VHID As String = String.Empty

    Private _rowcount As Integer ' Sunday, 30 Aug 2009, 22:15

#End Region


#Region "Public Member Declarations"
    Public Property DailyActivityDistribution() As String
        Get
            Return _DailyActivityDistribution
        End Get
        Set(ByVal value As String)
            _DailyActivityDistribution = value
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

    Public Property ActiveMonthYearID() As String
        Get
            Return _ActiveMonthYearID
        End Get
        Set(ByVal value As String)
            _ActiveMonthYearID = value
        End Set
    End Property

    Public Property ContractID() As String
        Get
            Return _ContractID
        End Get
        Set(ByVal value As String)
            _ContractID = value
        End Set
    End Property

    Public Property ActivityID() As String
        Get
            Return _ActivityID
        End Get
        Set(ByVal value As String)
            _ActivityID = value
        End Set
    End Property

    Public Property StationID() As String
        Get
            Return _StationID
        End Get
        Set(ByVal value As String)
            _StationID = value
        End Set
    End Property

    Public Property DivID() As String
        Get
            Return _DivID
        End Get
        Set(ByVal value As String)
            _DivID = value
        End Set
    End Property

    Public Property YOPID() As String
        Get
            Return _YOPID
        End Get
        Set(ByVal value As String)
            _YOPID = value
        End Set
    End Property

    Public Property BlockID() As String
        Get
            Return _BlockID
        End Get
        Set(ByVal value As String)

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

    Public Property T1() As String
        Get
            Return _T1
        End Get
        Set(ByVal value As String)
            _T1 = value
        End Set
    End Property

    Public Property T2() As String
        Get
            Return _T2
        End Get
        Set(ByVal value As String)
            _T2 = value
        End Set
    End Property

    Public Property T3() As String
        Get
            Return _T3
        End Get
        Set(ByVal value As String)
            _T3 = value
        End Set
    End Property

    Public Property T4() As String
        Get
            Return _T4
        End Get
        Set(ByVal value As String)
            _T4 = value
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

#End Region

End Class

