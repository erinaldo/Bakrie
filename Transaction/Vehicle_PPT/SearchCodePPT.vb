Imports System

Public Class SearchCodePPT

    Dim lsSearchFor As String
    Dim lsSearchBy As String
    Dim lsSearchTerm As String
    Dim lsEstateID As String
    Dim lsActiveMonthYearID As String
    Dim ldLoggedInYear As Integer
    Dim lsDivCodeOrName As String
    Dim lsSubBlockCodeOrName As String
    Dim lsDIVCode As String
    Dim lsDIVName As String
    Dim lsYOPCode As String
    Dim lsSubBlockCode As String
    Dim lsYOPName As String
    Dim lcType As Char

    'Dim objclsSearchCodeFunc As clsSearchCodeFunc
    'Dim obbjclsVehicleRunningBatchFunc As clsVehicleRunningBatchFunc

    'Related to db procedure parameter : @SearchFor
    Public Property psSearchFor() As String
        Get
            Return lsSearchFor
        End Get
        Set(ByVal value As String)
            lsSearchFor = value
        End Set
    End Property

    'Related to db procedure parameter : @SearchBy
    Public Property psSearchBy() As String
        Get
            Return lsSearchBy
        End Get
        Set(ByVal value As String)
            lsSearchBy = value
        End Set
    End Property

    'Related to db procedure parameter : @Code
    Public Property psSearchTerm() As String
        Get
            Return lsSearchTerm
        End Get
        Set(ByVal value As String)
            lsSearchTerm = value
        End Set
    End Property

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
    Public Property psActiveMonthYearID() As String
        Get
            Return lsActiveMonthYearID
        End Get
        Set(ByVal value As String)
            lsActiveMonthYearID = value
        End Set
    End Property

    'Related to db procedure parameter : @SearchFor
    Public Property pcType() As Char
        Get
            Return lcType
        End Get
        Set(ByVal value As Char)
            lcType = value
        End Set
    End Property

    Public Property pdLoggedInYear() As Integer
        Get
            Return ldLoggedInYear
        End Get
        Set(ByVal value As Integer)
            ldLoggedInYear = value
        End Set
    End Property

    Public Property psDivCodeOrName() As String
        Get
            Return lsDivCodeOrName
        End Get
        Set(ByVal value As String)
            lsDivCodeOrName = value
        End Set
    End Property

    Public Property psSubBlockCodeOrName() As String
        Get
            Return lsSubBlockCodeOrName
        End Get
        Set(ByVal value As String)
            lsSubBlockCodeOrName = value
        End Set
    End Property

    Public Property psDIVCode() As String
        Get
            Return lsDIVCode
        End Get
        Set(ByVal value As String)
            lsDIVCode = value
        End Set
    End Property

    Public Property psDIVName() As String
        Get
            Return lsDIVName
        End Get
        Set(ByVal value As String)
            lsDIVName = value
        End Set
    End Property

    Public Property psSubBlockCode() As String
        Get
            Return lsSubBlockCode
        End Get
        Set(ByVal value As String)
            lsSubBlockCode = value
        End Set
    End Property

    Public Property psYOPCode() As String
        Get
            Return lsYOPCode
        End Get
        Set(ByVal value As String)
            lsYOPCode = value
        End Set
    End Property

    Public Property psYOPName() As String
        Get
            Return lsYOPName
        End Get
        Set(ByVal value As String)
            lsYOPName = value
        End Set
    End Property

    'Related to db table column name: WorkshopVHID
    Private lsContractNo As String
    Public Property psContractNo() As String
        Get
            Return lsContractNo
        End Get
        Set(ByVal value As String)
            lsContractNo = value
        End Set
    End Property

    'Related to db table column name: WorkshopVHID
    Private lsContractName As String
    Public Property psContractName() As String
        Get
            Return lsContractName
        End Get
        Set(ByVal value As String)
            lsContractName = value
        End Set
    End Property

    'Related to db table column name: WorkshopVHID
    Private lsWorkshopID As String
    Public Property psWorkshopID() As String
        Get
            Return lsWorkshopID
        End Get
        Set(ByVal value As String)
            lsWorkshopID = value
        End Set
    End Property

    'Related to db table column name: WorkshopVHID
    Private lsLogNo As String
    Public Property psWorkVHID() As String
        Get
            Return lsLogNo
        End Get
        Set(ByVal value As String)
            lsLogNo = value
        End Set
    End Property

    'Related to db table column name: VHID
    Private lsVHID As String
    Public Property psVHID() As String
        Get
            Return lsVHID
        End Get
        Set(ByVal value As String)
            lsVHID = value
        End Set
    End Property

    'Related to db table column name: Category
    Private lsWorkshopCategory As String
    Public Property psCategory() As String
        Get
            Return lsWorkshopCategory
        End Get
        Set(ByVal value As String)
            lsWorkshopCategory = value
        End Set
    End Property

    'Related to db table column name: VHModel
    Private lsWorkshopModel As String
    Public Property psModel() As String
        Get
            Return lsWorkshopModel
        End Get
        Set(ByVal value As String)
            lsWorkshopModel = value
        End Set
    End Property

    'Related to db table column name: TAnalysisID
    Private lsTAnalysisID As String
    Public Property psTAnalysisID() As String
        Get
            Return lsTAnalysisID
        End Get
        Set(ByVal value As String)
            lsTAnalysisID = value
        End Set
    End Property

    'Related to db table column name: TAnalysisCode
    Private lsTAnalysisCode As String
    Public Property psTAnalysisCode() As String
        Get
            Return lsTAnalysisCode
        End Get
        Set(ByVal value As String)
            lsTAnalysisCode = value
        End Set
    End Property

    ''Related to db table column name: TAnalysisCode
    'Private lsTAnalysis1 As String
    'Public Property psTAnalysis1() As String
    '    Get
    '        Return lsTAnalysis1
    '    End Get
    '    Set(ByVal value As String)
    '        lsTAnalysis1 = value
    '    End Set
    'End Property

    ''Related to db table column name: TAnalysisCode
    'Private lsTAnalysis2 As String
    'Public Property psTAnalysis2() As String
    '    Get
    '        Return lsTAnalysis2
    '    End Get
    '    Set(ByVal value As String)
    '        lsTAnalysis2 = value
    '    End Set
    'End Property

    ''Related to db table column name: TAnalysisCode
    'Private lsTAnalysis3 As String
    'Public Property psTAnalysis3() As String
    '    Get
    '        Return lsTAnalysis3
    '    End Get
    '    Set(ByVal value As String)
    '        lsTAnalysis3 = value
    '    End Set
    'End Property

    ''Related to db table column name: TAnalysisCode
    'Private lsTAnalysis4 As String
    'Public Property psTAnalysis4() As String
    '    Get
    '        Return lsTAnalysis4
    '    End Get
    '    Set(ByVal value As String)
    '        lsTAnalysis4 = value
    '    End Set
    'End Property

    'Related to db table column name: TValue
    Private lsTAnalysisValue As String
    Public Property psTAnalysisValue() As String
        Get
            Return lsTAnalysisValue
        End Get
        Set(ByVal value As String)
            lsTAnalysisValue = value
        End Set
    End Property

    ''Related to db table column name: TAnalysisCode
    'Private lsTAnalysisValue1 As String
    'Public Property psTAnalysisValue1() As String
    '    Get
    '        Return lsTAnalysisValue1
    '    End Get
    '    Set(ByVal value As String)
    '        lsTAnalysisValue1 = value
    '    End Set
    'End Property

    ''Related to db table column name: TAnalysisCode
    'Private lsTAnalysisValue2 As String
    'Public Property psTAnalysisValue2() As String
    '    Get
    '        Return lsTAnalysisValue2
    '    End Get
    '    Set(ByVal value As String)
    '        lsTAnalysisValue2 = value
    '    End Set
    'End Property

    ''Related to db table column name: TAnalysisCode
    'Private lsTAnalysisValue3 As String
    'Public Property psTAnalysisValue3() As String
    '    Get
    '        Return lsTAnalysisValue3
    '    End Get
    '    Set(ByVal value As String)
    '        lsTAnalysisValue3 = value
    '    End Set
    'End Property

    ''Related to db table column name: TAnalysisCode
    'Private lsTAnalysisValue4 As String
    'Public Property psTAnalysisValue4() As String
    '    Get
    '        Return lsTAnalysisValue4
    '    End Get
    '    Set(ByVal value As String)
    '        lsTAnalysisValue4 = value
    '    End Set
    'End Property

    'Related to db table column name: TAnalysisDescp
    Private lsTAnalysisDesc As String
    Public Property psTAnalysisDesc() As String
        Get
            Return lsTAnalysisDesc
        End Get
        Set(ByVal value As String)
            lsTAnalysisDesc = value
        End Set
    End Property

    'Related to db table column name: COAID
    Private lsCOAID As String
    Public Property psCOAID() As String
        Get
            Return lsCOAID
        End Get
        Set(ByVal value As String)
            lsCOAID = value
        End Set
    End Property

    'Related to db table column name: COACode
    Private lsCOACode As String
    Public Property psCOACode() As String
        Get
            Return lsCOACode
        End Get
        Set(ByVal value As String)
            lsCOACode = value
        End Set
    End Property

    'Related to db table column name: COADescp
    Private lsCOADescp As String
    Public Property psCOADescp() As String
        Get
            Return lsCOADescp
        End Get
        Set(ByVal value As String)
            lsCOADescp = value
        End Set
    End Property

    'Related to db table column name: COA
    Private lsCOA As String
    Public Property psCOA() As String
        Get
            Return lsCOA
        End Get
        Set(ByVal value As String)
            lsCOA = value
        End Set
    End Property

    'Related to db table column name: EmpID
    Private lsEmpId As String
    Public Property psEmpId() As String
        Get
            Return lsEmpId
        End Get
        Set(ByVal value As String)
            lsEmpId = value
        End Set
    End Property


    'Related to db table column name: EmpCode
    Private lsEmpCode As String
    Public Property psEmpCode() As String
        Get
            Return lsEmpCode
        End Get
        Set(ByVal value As String)
            lsEmpCode = value
        End Set
    End Property

    'Related to db table column name: EmpName
    Private lsEmpName As String
    Public Property psEmpName() As String
        Get
            Return lsEmpName
        End Get
        Set(ByVal value As String)
            lsEmpName = value
        End Set
    End Property

    Dim lsContactNoOrName As String

    Public Property psContactNoOrName() As String
        Get
            Return lsContactNoOrName
        End Get
        Set(ByVal value As String)
            lsContactNoOrName = value
        End Set
    End Property

End Class
