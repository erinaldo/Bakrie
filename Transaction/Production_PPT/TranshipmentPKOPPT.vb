Public Class TranshipmentPKOPPT

#Region "Private Member Declarations"
    Private _Capacity As Double = 0
    Private _TankNo As String = String.Empty
    Private _BFQty As Double = 0
    Private _StockTankID As String = String.Empty
    Private _TankID As String = String.Empty
    Private _LoadTankID As String = String.Empty
    Private _TransTankID As String = String.Empty
    Private _CropYieldID As String = String.Empty

    Private _ProductionToday As Double = 0
    Private _ProductionMonth As Double = 0
    Private _ProductionYear As Double = 0
    Private _balance As Double = 0
    Private _CurrentReading As Double = 0
    Private _Measurement As Double = 0
    Private _Temparature As Double = 0
    Private _FFA As Double = 0
    Private _Moisture As Double = 0
    Private _Dirt As Double = 0

    Private _LoadQty As Double
    Private _LoadMonthToDate As Double = 0
    Private _TransQty As Double = 0
    Private _TransMonthToDate As Double = 0
    Private _LoadingLocationID As String = String.Empty
    Private _PKODate As Date
    Private _ProdStockID As String = String.Empty
    Private _Descp As String = String.Empty
    Private _TransLocationID As String = String.Empty
    Private _ProductionID As String = String.Empty
    Private _ProdTranshipID As String = String.Empty
    Private _ProdLoadingID As String = String.Empty
    Private _CropYieldCode As String = String.Empty
    Private _KernalID As String = String.Empty
    Private _LoadRemarks As String = String.Empty
    Private _TransRemarks As String = String.Empty
#End Region
#Region "Public Member Declarations"
    Public Property LoadQty() As Double
        Get
            Return _LoadQty
        End Get
        Set(ByVal value As Double)
            _LoadQty = value
        End Set
    End Property
    Public Property CropYieldCode() As String
        Get
            Return _CropYieldCode
        End Get
        Set(ByVal value As String)
            _CropYieldCode = value
        End Set
    End Property
    Public Property ProductionID() As String
        Get
            Return _ProductionID
        End Get
        Set(ByVal value As String)
            _ProductionID = value
        End Set
    End Property
    Public Property Descp() As String
        Get
            Return _Descp
        End Get
        Set(ByVal value As String)
            _Descp = value
        End Set
    End Property

    Public Property TransLocationID() As String
        Get
            Return _TransLocationID
        End Get
        Set(ByVal value As String)
            _TransLocationID = value
        End Set
    End Property
    Public Property ProdStockID() As String
        Get
            Return _ProdStockID
        End Get
        Set(ByVal value As String)
            _ProdStockID = value
        End Set
    End Property
    Public Property ProdTranshipID() As String
        Get
            Return _ProdTranshipID
        End Get
        Set(ByVal value As String)
            _ProdTranshipID = value
        End Set
    End Property
    Public Property ProdLoadingID() As String
        Get
            Return _ProdLoadingID
        End Get
        Set(ByVal value As String)
            _ProdLoadingID = value
        End Set
    End Property
    Public Property PKODate() As Date
        Get
            Return _PKODate
        End Get
        Set(ByVal value As Date)
            _PKODate = value
        End Set
    End Property
    Public Property LoadMonthToDate() As Double
        Get
            Return _LoadMonthToDate
        End Get
        Set(ByVal value As Double)
            _LoadMonthToDate = value
        End Set
    End Property
    Public Property TransQty() As Double
        Get
            Return _TransQty
        End Get
        Set(ByVal value As Double)
            _TransQty = value
        End Set
    End Property
    Public Property LoadingLocationID() As String
        Get
            Return _LoadingLocationID
        End Get
        Set(ByVal value As String)
            _LoadingLocationID = value
        End Set
    End Property
    Public Property TransMonthToDate() As Double
        Get
            Return _TransMonthToDate
        End Get
        Set(ByVal value As Double)
            _TransMonthToDate = value
        End Set
    End Property

    Public Property ProductionToday() As Double
        Get
            Return _ProductionToday
        End Get
        Set(ByVal value As Double)
            _ProductionToday = value
        End Set
    End Property
    Public Property ProductionYear() As Double
        Get
            Return _ProductionYear
        End Get
        Set(ByVal value As Double)
            _ProductionYear = value
        End Set
    End Property
    Public Property ProductionMonth() As Double
        Get
            Return _ProductionMonth
        End Get
        Set(ByVal value As Double)
            _ProductionMonth = value
        End Set
    End Property

    Public Property balance() As Double
        Get
            Return _balance
        End Get
        Set(ByVal value As Double)
            _balance = value
        End Set
    End Property
    Public Property CurrentReading() As Double
        Get
            Return _CurrentReading
        End Get
        Set(ByVal value As Double)
            _CurrentReading = value
        End Set
    End Property
    Public Property Measurement() As Double
        Get
            Return _Measurement
        End Get
        Set(ByVal value As Double)
            _Measurement = value
        End Set
    End Property
    Public Property Temparature() As Double
        Get
            Return _Temparature
        End Get
        Set(ByVal value As Double)
            _Temparature = value
        End Set
    End Property
    Public Property FFA() As Double
        Get
            Return _FFA
        End Get
        Set(ByVal value As Double)
            _FFA = value
        End Set
    End Property

    Public Property Moisture() As Double
        Get
            Return _Moisture
        End Get
        Set(ByVal value As Double)
            _Moisture = value
        End Set
    End Property
    Public Property Dirt() As Double
        Get
            Return _Dirt
        End Get
        Set(ByVal value As Double)
            _Dirt = value
        End Set
    End Property
    Public Property Capacity() As Double
        Get
            Return _Capacity
        End Get
        Set(ByVal value As Double)
            _Capacity = value
        End Set
    End Property
    Public Property TankNo() As String
        Get
            Return _TankNo
        End Get
        Set(ByVal value As String)
            _TankNo = value
        End Set
    End Property
    Public Property BFQty() As Double
        Get
            Return _BFQty
        End Get
        Set(ByVal value As Double)
            _BFQty = value
        End Set
    End Property
    Public Property StockTankID() As String
        Get
            Return _StockTankID
        End Get
        Set(ByVal value As String)
            _StockTankID = value
        End Set
    End Property
    Public Property CropYieldID() As String
        Get
            Return _CropYieldID
        End Get
        Set(ByVal value As String)
            _CropYieldID = value
        End Set
    End Property
    Public Property LoadTankID() As String
        Get
            Return _LoadTankID
        End Get
        Set(ByVal value As String)
            _LoadTankID = value
        End Set
    End Property
    Public Property TankID() As String
        Get
            Return _TankID
        End Get
        Set(ByVal value As String)
            _TankID = value
        End Set
    End Property
    Public Property KernalID() As String
        Get
            Return _KernalID
        End Get
        Set(ByVal value As String)
            _KernalID = value
        End Set
    End Property
    Public Property TransTankID() As String
        Get
            Return _TransTankID
        End Get
        Set(ByVal value As String)
            _TransTankID = value
        End Set
    End Property
    Public Property LoadRemarks() As String
        Get
            Return _LoadRemarks
        End Get
        Set(ByVal value As String)
            _LoadRemarks = value
        End Set
    End Property
    Public Property TransRemarks() As String
        Get
            Return _TransRemarks
        End Get
        Set(ByVal value As String)
            _TransRemarks = value
        End Set
    End Property
#End Region

End Class
