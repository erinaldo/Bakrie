Public Class WorkshopLogPPT

    'Database used: BSP
    'Table used: Vehicle.WorkshopLog
    'Naming conventions used for keywords: l-local;p-public;s-string;d-double;i-integer;date-prefix:d,sufix:DT;
    'Naming conventions used for variables: Pascal Case;Example: GetWindow
    'Naming conventions used for methods/functions: Prefix with access modifier and return type:l-local;p-public;s-string;d-double;i-integer;date-prefix:d,sufix:DT;
    'Followed by function/method name: Pascal Case;Example: psGetWindow()

#Region "Properties"

    'Related to db table column name: VHWorkshopLogID
    Private lsLogId As String
    Public Property psVHWorkshopLogID() As String
        Get
            Return lsLogId
        End Get
        Set(ByVal value As String)
            lsLogId = value
        End Set
    End Property

    'Related to db table column name: EstateID
    Private lsEstateId As String
    Public Property psEstateID() As String
        Get
            Return lsEstateId
        End Get
        Set(ByVal value As String)
            lsEstateId = value
        End Set
    End Property

    'Related to db table column name: ActiveMonthYearID
    'Private lsAciveMonthYearId As String
    'Public Property psActiveMonthYearID() As String
    '    Get
    '        Return lsAciveMonthYearId
    '    End Get
    '    Set(ByVal value As String)
    '        lsAciveMonthYearId = value
    '    End Set
    'End Property

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

    'Related to db table column name: StartTime
    Private ldStartTimeDT As TimeSpan
    Public Property pdStartTimeDT() As TimeSpan
        Get
            Return ldStartTimeDT
        End Get
        Set(ByVal value As TimeSpan)
            ldStartTimeDT = value
        End Set
    End Property

    'Related to db table column name: EndTime
    Private ldEndTimeDT As TimeSpan
    Public Property pdEndTimeDT() As TimeSpan
        Get
            Return ldEndTimeDT
        End Get
        Set(ByVal value As TimeSpan)
            ldEndTimeDT = value
        End Set
    End Property

    'Related to db table column name: TotalHrs
    Private ldTotalHrsDT As String
    Public Property pdTotalHrsDT() As String
        Get
            Return ldTotalHrsDT
        End Get
        Set(ByVal value As String)
            ldTotalHrsDT = value
        End Set
    End Property

    'Related to db table column name: StartTime
    Private lsStartTime As String
    Public Property psStartTime() As String
        Get
            Return lsStartTime
        End Get
        Set(ByVal value As String)
            lsStartTime = value
        End Set
    End Property

    'Related to db table column name: EndTime
    Private lsEndTime As String
    Public Property psEndTime() As String
        Get
            Return lsEndTime
        End Get
        Set(ByVal value As String)
            lsEndTime = value
        End Set
    End Property

    'Related to db table column name: TotalHrs
    Private lsTotalHrs As String
    Public Property psTotalHrs() As String
        Get
            Return lsTotalHrs
        End Get
        Set(ByVal value As String)
            lsTotalHrs = value
        End Set
    End Property

    'Related to db table column name: Activity
    Private lsActivity As String
    Public Property psActivity() As String
        Get
            Return lsActivity
        End Get
        Set(ByVal value As String)
            lsActivity = value
        End Set
    End Property

    'Related to db table column name: EmpID
    Private lsOperatorCode As String
    Public Property psEmpCode() As String
        Get
            Return lsOperatorCode
        End Get
        Set(ByVal value As String)
            lsOperatorCode = value
        End Set
    End Property

    Private lsOperatorId As String
    Public Property psEmpID() As String
        Get
            Return lsOperatorId
        End Get
        Set(ByVal value As String)
            lsOperatorId = value
        End Set
    End Property

    Private lsOperatorName As String
    Public Property psEmpName() As String
        Get
            Return lsOperatorName
        End Get
        Set(ByVal value As String)
            lsOperatorName = value
        End Set
    End Property

    'Related to db table column name: COAID
    Private lsAccountCode As String
    Public Property psCOAID() As String
        Get
            Return lsAccountCode
        End Get
        Set(ByVal value As String)
            lsAccountCode = value
        End Set
    End Property

    'Related to db table column name: DivID
    Private lsDivisionCode As String
    Public Property psDivID() As String
        Get
            Return lsDivisionCode
        End Get
        Set(ByVal value As String)
            lsDivisionCode = value
        End Set
    End Property

    'Related to db table column name: YOPID
    Private lsYOPCode As String
    Public Property psYOPID() As String
        Get
            Return lsYOPCode
        End Get
        Set(ByVal value As String)
            lsYOPCode = value
        End Set
    End Property

    'Related to db table column name: BlockID
    Private lsBlockCode As String
    Public Property psBlockID() As String
        Get
            Return lsBlockCode
        End Get
        Set(ByVal value As String)
            lsBlockCode = value
        End Set
    End Property

    'Related to db table column name: T0
    Private lsTAnalysis0 As String
    Public Property psT0() As String
        Get
            Return lsTAnalysis0
        End Get
        Set(ByVal value As String)
            lsTAnalysis0 = value
        End Set
    End Property

    'Related to db table column name: T1
    Private lsTAnalysis1 As String
    Public Property psT1() As String
        Get
            Return lsTAnalysis1
        End Get
        Set(ByVal value As String)
            lsTAnalysis1 = value
        End Set
    End Property

    'Related to db table column name: T2
    Private lsTAnalysis2 As String

    Public Property psT2() As String
        Get
            Return lsTAnalysis2
        End Get
        Set(ByVal value As String)
            lsTAnalysis2 = value
        End Set
    End Property

    'Related to db table column name: T3
    Private lsTAnalysis3 As String
    Public Property psT3() As String
        Get
            Return lsTAnalysis3
        End Get
        Set(ByVal value As String)
            lsTAnalysis3 = value
        End Set
    End Property

    'Related to db table column name: T4
    Private lsTAnalysis4 As String
    Public Property psT4() As String
        Get
            Return lsTAnalysis4
        End Get
        Set(ByVal value As String)
            lsTAnalysis4 = value
        End Set
    End Property

    Private lsTDescp0 As String
    Public Property psTDescp0() As String
        Get
            Return lsTDescp0
        End Get
        Set(ByVal value As String)
            lsTDescp0 = value
        End Set
    End Property

    Private lsTDescp1 As String
    Public Property psTDescp1() As String
        Get
            Return lsTDescp1
        End Get
        Set(ByVal value As String)
            lsTDescp1 = value
        End Set
    End Property

    Private lsTDescp2 As String
    Public Property psTDescp2() As String
        Get
            Return lsTDescp2
        End Get
        Set(ByVal value As String)
            lsTDescp2 = value
        End Set
    End Property

    Private lsTDescp3 As String
    Public Property psTDescp3() As String
        Get
            Return lsTDescp3
        End Get
        Set(ByVal value As String)
            lsTDescp3 = value
        End Set
    End Property

    Private lsTDescp4 As String
    Public Property psTDescp4() As String
        Get
            Return lsTDescp4
        End Get
        Set(ByVal value As String)
            lsTDescp4 = value
        End Set
    End Property

    'Related to db table column name: CreatedBy
    'Private lsCreatedBy As String
    'Public Property psCreatedBy() As String
    '    Get
    '        Return lsCreatedBy
    '    End Get
    '    Set(ByVal value As String)
    '        lsCreatedBy = value
    '    End Set
    'End Property

    'Related to db table column name: ModifiedBy
    'Private lsModifiedBy As String
    'Public Property psModifiedBy() As String
    '    Get
    '        Return lsModifiedBy
    '    End Get
    '    Set(ByVal value As String)
    '        lsModifiedBy = value
    '    End Set
    'End Property

    'Related to db procedure parameter : @SearchBy
    Private lsSearchBy As String
    Public Property psSearchBy() As String
        Get
            Return lsSearchBy
        End Get
        Set(ByVal value As String)
            lsSearchBy = value
        End Set
    End Property

    'Related to db procedure parameter : @SearchTerm
    Private lsSearchTerm As String
    Public Property psSearchTerm() As String
        Get
            Return lsSearchTerm
        End Get
        Set(ByVal value As String)
            lsSearchTerm = value
        End Set
    End Property

    'Related to db procedure parameter : @Id
    Private liId As Integer
    Public Property piId() As Integer
        Get
            Return liId
        End Get
        Set(ByVal value As Integer)
            liId = value
        End Set
    End Property

    'Related to db procedure parameter : @FieldName
    Private lsFieldName As String
    Public Property psFieldName() As String
        Get
            Return lsFieldName
        End Get
        Set(ByVal value As String)
            lsFieldName = value
        End Set
    End Property

    'Related to db procedure parameter : @FieldValue
    Private lsFieldValue As String
    Public Property psFieldValue() As String
        Get
            Return lsFieldValue
        End Get
        Set(ByVal value As String)
            lsFieldValue = value
        End Set
    End Property

    Private lcPosted As Char
    Public Property pcPosted() As Char
        Get
            Return lcPosted
        End Get
        Set(ByVal value As Char)
            lcPosted = value
        End Set
    End Property

    Private lsCOADesc As String
    Public Property psCOADesc() As String
        Get
            Return lsCOADesc
        End Get
        Set(ByVal value As String)
            lsCOADesc = value
        End Set
    End Property

    Private lsOperatorDesc As String
    Public Property psOperatorDesc() As String
        Get
            Return lsOperatorDesc
        End Get
        Set(ByVal value As String)
            lsOperatorDesc = value
        End Set
    End Property

    Private liAMonth As Integer
    Public Property piAMonth() As Integer
        Get
            Return liAMonth
        End Get
        Set(ByVal value As Integer)
            liAMonth = value
        End Set
    End Property

    Private ldAYear As Decimal
    Public Property pdAYear() As Decimal
        Get
            Return ldAYear
        End Get
        Set(ByVal value As Decimal)
            ldAYear = value
        End Set
    End Property

    Dim lbConcurrencyID As Byte() = New Byte(7) {}
    Public Property pbConcurrencyId() As Byte() 'Related to db procedure parameter : @ConcurrencyId
        Get
            Return lbConcurrencyID
        End Get
        Set(ByVal value As Byte())
            lbConcurrencyID = value
        End Set
    End Property

#End Region

End Class
