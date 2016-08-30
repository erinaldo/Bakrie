Public Class VehicleDistributionPostingPPT

    'We are telling the procedure to post all as posted for the text "PostAll"
    'If the text is single we are posting by using the Id
    Private lsPostingType As String
    Public Property psPostingType() As String
        Get
            Return lsPostingType
        End Get
        Set(ByVal value As String)
            lsPostingType = value
        End Set
    End Property


    Private lbIsPostAll As Boolean
    Public Property pbIsPostAll() As Boolean
        Get
            Return lbIsPostAll
        End Get
        Set(ByVal value As Boolean)
            lbIsPostAll = value
        End Set
    End Property

    Private liId As Integer
    Public Property piId() As Integer
        Get
            Return liId
        End Get
        Set(ByVal value As Integer)
            liId = value
        End Set
    End Property

    Dim lsEstateID As String
    'Related to db table column name: EstateID
    Public Property psEstateID() As String
        Get
            Return lsEstateID
        End Get
        Set(ByVal value As String)
            lsEstateID = value
        End Set
    End Property

    'Related to db table column name: ActiveMonthYearID
    Dim lsActiveMonthYearID As String

    Public Property psActiveMonthYearID() As String
        Get
            Return lsActiveMonthYearID
        End Get
        Set(ByVal value As String)
            lsActiveMonthYearID = value
        End Set
    End Property

    'Related to db table column name: DistributionDT
    Private ldDistributionDT As DateTime
    Public Property pdDistributionDT() As DateTime
        Get
            Return ldDistributionDT
        End Get
        Set(ByVal value As DateTime)
            ldDistributionDT = value
        End Set
    End Property

    'Related to db table column name: VHID
    Private lsVehicleId As String
    Public Property psVHID() As String
        Get
            Return lsVehicleId
        End Get
        Set(ByVal value As String)
            lsVehicleId = value
        End Set
    End Property

    'Related to db table column name: TotalRunningKmHours
    Private ldTotalRunningKmHours As Decimal
    Public Property pdTotalRunningKmHours() As Decimal
        Get
            Return ldTotalRunningKmHours
        End Get
        Set(ByVal value As Decimal)
            ldTotalRunningKmHours = value
        End Set
    End Property

    'Related to db table column name: TotalKmHoursDistributed
    Private ldTotalKmHoursDistributed As Decimal
    Public Property pdTotalKmHoursDistributed() As Decimal
        Get
            Return ldTotalKmHoursDistributed
        End Get
        Set(ByVal value As Decimal)
            ldTotalKmHoursDistributed = value
        End Set
    End Property

    Dim lsCreatedModifiedBy As String
    'Related to db table column name: CreatedBy/ModifiedBy
    Public Property psCreatedModifiedBy() As String
        Get
            Return lsCreatedModifiedBy
        End Get
        Set(ByVal value As String)
            lsCreatedModifiedBy = value
        End Set
    End Property
End Class
