Public Class CropStatement_PPT

#Region "Private Members Declarations"

    Private CropStatementID As String
    Private CropYieldCode As String
    Private CropYieldID As String
    Private DivID As String
    Private YOPID As String
    Private BlockID As String
    Private MilWeight As Double
    Private Bunches As Double
    Private DDate As Date

#End Region


#Region "Public Member Declarations"
    Public Property _CropStatementID() As String
        Get
            Return CropStatementID
        End Get
        Set(ByVal value As String)
            CropStatementID = value
        End Set
    End Property
    Public Property _CropYieldID() As String
        Get
            Return CropYieldID
        End Get
        Set(ByVal value As String)
            CropYieldID = value
        End Set
    End Property
    Public Property _CropYieldCode() As String
        Get
            Return CropYieldCode
        End Get
        Set(ByVal value As String)
            CropYieldCode = value
        End Set
    End Property
    Public Property _DivID() As String
        Get
            Return DivID
        End Get
        Set(ByVal value As String)
            DivID = value
        End Set
    End Property
    Public Property _YOPID() As String
        Get
            Return YOPID
        End Get
        Set(ByVal value As String)
            YOPID = value
        End Set
    End Property
    Public Property _BlockID() As String
        Get
            Return BlockID
        End Get
        Set(ByVal value As String)
            BlockID = value
        End Set
    End Property
    Public Property _MilWeight() As Double
        Get
            Return MilWeight
        End Get
        Set(ByVal value As Double)
            MilWeight = value
        End Set
    End Property
    Public Property _Bunches() As Double
        Get
            Return Bunches
        End Get
        Set(ByVal value As Double)
            Bunches = value
        End Set
    End Property

    Public Property _DDate() As Date
        Get
            Return DDate
        End Get
        Set(ByVal value As Date)
            DDate = value
        End Set
    End Property


#End Region

End Class
