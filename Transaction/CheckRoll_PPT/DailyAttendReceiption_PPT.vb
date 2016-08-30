
' Jum'at, 28 Aug 2009, 10:06

'

Public Class DailyAttendReceiption_PPT

#Region "Private Member Declarations"

    Private _DailyReceiptionID As String = String.Empty
    Private _EstateID As String = String.Empty
    Private _ActiveMonthYearID As String = String.Empty
    Private _RDate As Date = Date.Now()
    Private _EmpID As String = String.Empty
    Private _OtherEstateEmpNo As String = String.Empty
    Private _OtherEstateName As String = String.Empty
    Private _AttendanceSetupID As String = String.Empty
    Private _DistributionSetupID As String = String.Empty
    Private _OTHours As Double = 0.0
    Private _DivID As String = String.Empty
    Private _YOPID As String = String.Empty
    Private _BlockID As String = String.Empty
    Private _IsDrivePremi As String = String.Empty
    Private _Tonnage As Double = 0.0
    Private _NActualBunches As Double = 0.0
    Private _NPayedBunches As Double = 0.0
    Private _NLooseFruits As Double = 0.0
    Private _NDiscarded As Double = 0.0
    Private _BActualBunches As Double = 0.0
    Private _BPayedBunches As Double = 0.0
    Private _BLooseFruits As Double = 0.0
    Private _BDiscarded As Double = 0.0
    Private _ConcurrencyId As Date = Date.Now()
    Private _CreatedBy As String = String.Empty
    Private _CreatedOn As Date = Date.Now()
    Private _ModifiedBy As String = String.Empty
    Private _ModifiedOn As Date = Date.Now()

#End Region

#Region "Public Member Declarations"

    Public Property DailyReceiptionID() As String
        Get
            Return _DailyReceiptionID
        End Get
        Set(ByVal value As String)
            _DailyReceiptionID = value
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

    Public Property RDate() As Date
        Get
            Return _RDate
        End Get
        Set(ByVal value As Date)
            _RDate = value
        End Set
    End Property

    Public Property EmpID() As String
        Get
            Return _EmpID
        End Get
        Set(ByVal value As String)
            _EmpID = value
        End Set
    End Property

    Public Property OtherEstateEmpNo() As String
        Get
            Return _OtherEstateEmpNo
        End Get
        Set(ByVal value As String)
            _OtherEstateEmpNo = value
        End Set
    End Property

    Public Property OtherEstateName() As String
        Get
            Return _OtherEstateName
        End Get
        Set(ByVal value As String)
            _OtherEstateName = value
        End Set
    End Property

    Public Property AttendanceSetupID() As String
        Get
            Return _AttendanceSetupID
        End Get
        Set(ByVal value As String)
            _AttendanceSetupID = value
        End Set
    End Property

    Public Property DistributionSetupID() As String
        Get
            Return _DistributionSetupID
        End Get
        Set(ByVal value As String)
            _DistributionSetupID = value
        End Set
    End Property

    Public Property OTHours() As Double
        Get
            Return _OTHours
        End Get
        Set(ByVal value As Double)
            _OTHours = value
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
            _BlockID = value
        End Set
    End Property

    Public Property IsDrivePremi() As String
        Get
            Return _IsDrivePremi
        End Get
        Set(ByVal value As String)
            _IsDrivePremi = value
        End Set
    End Property

    Public Property Tonnage() As Double
        Get
            Return _Tonnage
        End Get
        Set(ByVal value As Double)
            _Tonnage = value
        End Set
    End Property

    Public Property NActualBunches() As Double
        Get
            Return _NActualBunches
        End Get
        Set(ByVal value As Double)
            _NActualBunches = value
        End Set
    End Property

    Public Property NPayedBunches() As Double
        Get
            Return _NPayedBunches
        End Get
        Set(ByVal value As Double)
            _NPayedBunches = value
        End Set
    End Property

    Public Property NLooseFruits() As Double
        Get
            Return _NLooseFruits
        End Get
        Set(ByVal value As Double)
            _NLooseFruits = value
        End Set
    End Property

    Public Property BActualBunches() As Double
        Get
            Return _BActualBunches
        End Get
        Set(ByVal value As Double)
            _BActualBunches = value
        End Set
    End Property

    Public Property BPayedBunches() As Double
        Get
            Return _BPayedBunches
        End Get
        Set(ByVal value As Double)
            _BPayedBunches = value
        End Set
    End Property

    Public Property BLooseFruits() As Double
        Get
            Return _BLooseFruits
        End Get
        Set(ByVal value As Double)
            _BLooseFruits = value
        End Set
    End Property

    Public Property ConcurrencyId() As Date
        Get
            Return _ConcurrencyId
        End Get
        Set(ByVal value As Date)
            _ConcurrencyId = value
        End Set
    End Property

    Public Property CreatedBy() As String
        Get
            Return _CreatedBy
        End Get
        Set(ByVal value As String)
            _CreatedBy = value
        End Set
    End Property

    Public Property CreatedOn() As Date
        Get
            Return _CreatedOn
        End Get
        Set(ByVal value As Date)
            _CreatedOn = value
        End Set
    End Property

    Public Property ModifiedBy() As String
        Get
            Return _ModifiedBy
        End Get
        Set(ByVal value As String)
            _ModifiedBy = value
        End Set
    End Property

    Public Property ModifiedOn() As Date
        Get
            Return _ModifiedOn
        End Get
        Set(ByVal value As Date)
            _ModifiedOn = value
        End Set
    End Property

    Public Property NDiscarded() As Double
        Get
            Return _NDiscarded
        End Get
        Set(ByVal value As Double)
            _NDiscarded = value
        End Set
    End Property

    Public Property BDiscarded() As Double
        Get
            Return _BDiscarded
        End Get
        Set(ByVal value As Double)
            _BDiscarded = value
        End Set
    End Property
#End Region

End Class
