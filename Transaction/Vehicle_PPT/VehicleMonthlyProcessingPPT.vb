Public Class VehicleMonthlyProcessingPPT
    'We are telling the procedure to post all as posted for the text "PostAll"
    'If the text is single we are posting by using the Id

#Region "WorkshopLog"



#End Region

#Region "VehicleDistribution"



#End Region

    Private lsPostingType As String
    Public Property psPostingType() As String
        Get
            Return lsPostingType
        End Get
        Set(ByVal value As String)
            lsPostingType = value
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

    Private lbIsPostAll As Boolean
    Public Property pbIsPostAll() As Boolean
        Get
            Return lbIsPostAll
        End Get
        Set(ByVal value As Boolean)
            lbIsPostAll = value
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

    'Related to db table column name: LogDate
    Private ldLogDateDT As DateTime
    Public Property pdLogDateDT() As DateTime
        Get
            Return ldLogDateDT
        End Get
        Set(ByVal value As DateTime)
            ldLogDateDT = value
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

    'Related to db table column name: WorkVHID
    Private lsLogNo As String
    Public Property psWorkVHID() As String
        Get
            Return lsLogNo
        End Get
        Set(ByVal value As String)
            lsLogNo = value
        End Set
    End Property

    Private lsVHDetailCostCode As String
    Public Property psVHDetailCostCode() As String
        Get
            Return lsVHDetailCostCode
        End Get
        Set(ByVal value As String)
            lsVHDetailCostCode = value
        End Set
    End Property

    Private ldTotalExpenditure As Decimal
    Public Property pdTotalExpenditure() As Decimal
        Get
            Return ldTotalExpenditure
        End Get
        Set(ByVal value As Decimal)
            ldTotalExpenditure = value
        End Set
    End Property

    Private lsTask As String
    Public Property psTask() As String
        Get
            Return lsTask
        End Get
        Set(ByVal value As String)
            lsTask = value
        End Set
    End Property

    Private lcComplete As Char
    Public Property pcComplete() As Char
        Get
            Return lcComplete
        End Get
        Set(ByVal value As Char)
            lcComplete = value
        End Set
    End Property

    Private liModId As Integer
    Public Property piModId() As Integer
        Get
            Return liModId
        End Get
        Set(ByVal value As Integer)
            liModId = value
        End Set
    End Property

    Private ldServiceCostPerHour As Decimal
    Public Property pdServiceCostPerHour() As Decimal
        Get
            Return ldServiceCostPerHour
        End Get
        Set(ByVal value As Decimal)
            ldServiceCostPerHour = value
        End Set
    End Property

    'Related to db table column name: TotalHrs
    Private ldTotalHrsDT As TimeSpan
    Public Property pdTotalHrsDT() As TimeSpan
        Get
            Return ldTotalHrsDT
        End Get
        Set(ByVal value As TimeSpan)
            ldTotalHrsDT = value
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
