Public Class CPOProductionPPT
#Region "Private Member Declarations"
    Private _Capacity As Decimal = 0
    Private _TankNo As String = String.Empty
    Private _PrevDayReading As Decimal = 0
    Private _StockTankID As String = String.Empty
    Private _TankID As String = String.Empty
    Private _LoadTankID As String = String.Empty
    Private _TransTankID As String = String.Empty
    Private _CropYieldID As String = String.Empty

    Private _ProductionToday As Decimal = 0
    Private _ProductionMonth As Decimal = 0
    Private _ProductionYear As Decimal = 0
    Private _balance As Decimal = 0
    Private _CurrentReading As Decimal = 0
    Private _Writeoff As Decimal = 0
    Private _Reason As String = String.Empty
    Private _BeritaAcara As String = String.Empty
    Private _Measurement As Decimal = 0
    Private _Temparature As Decimal = 0
    Private _FFA As Decimal = 0
    Private _Moisture As Decimal = 0
    Private _Dirt As Decimal = 0

    Private _LoadQty As Decimal
    Private _LoadMonthToDate As Decimal = 0
    Private _TransQty As Decimal = 0
    Private _TransMonthToDate As Decimal = 0
    Private _LoadingLocationID As String = String.Empty
    Private _CPODate As Date
    Private _CPOProductionDate As Date
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

    Private _LoadCurrentReading As Decimal = 0
    Private _LoadPrevDayReading As Decimal = 0


#End Region
#Region "Public Member Declarations"
    Public Property LoadQty() As Decimal
        Get
            Return _LoadQty
        End Get
        Set(ByVal value As Decimal)
            _LoadQty = value
        End Set
    End Property
    Public Property BeritaAcara() As String
        Get
            Return _BeritaAcara
        End Get
        Set(ByVal value As String)
            _BeritaAcara = value
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
    Public Property CPODate() As Date
        Get
            Return _CPODate
        End Get
        Set(ByVal value As Date)
            _CPODate = value
        End Set
    End Property
    Public Property CPOProductionDate() As Date
        Get
            Return _CPOProductionDate
        End Get
        Set(ByVal value As Date)
            _CPOProductionDate = value
        End Set
    End Property
    Public Property LoadCurrentReading() As Decimal
        Get
            Return _LoadCurrentReading
        End Get
        Set(ByVal value As Decimal)
            _LoadCurrentReading = value
        End Set
    End Property
    Public Property LoadPrevDayReading() As Decimal
        Get
            Return _LoadPrevDayReading
        End Get
        Set(ByVal value As Decimal)
            _LoadPrevDayReading = value
        End Set
    End Property

    Public Property LoadMonthToDate() As Decimal
        Get
            Return _LoadMonthToDate
        End Get
        Set(ByVal value As Decimal)
            _LoadMonthToDate = value
        End Set
    End Property
    Public Property TransQty() As Decimal
        Get
            Return _TransQty
        End Get
        Set(ByVal value As Decimal)
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
    Public Property TransMonthToDate() As Decimal
        Get
            Return _TransMonthToDate
        End Get
        Set(ByVal value As Decimal)
            _TransMonthToDate = value
        End Set
    End Property

    Public Property ProductionToday() As Decimal
        Get
            Return _ProductionToday
        End Get
        Set(ByVal value As Decimal)
            _ProductionToday = value
        End Set
    End Property
    Public Property ProductionYear() As Decimal
        Get
            Return _ProductionYear
        End Get
        Set(ByVal value As Decimal)
            _ProductionYear = value
        End Set
    End Property
    Public Property ProductionMonth() As Decimal
        Get
            Return _ProductionMonth
        End Get
        Set(ByVal value As Decimal)
            _ProductionMonth = value
        End Set
    End Property

    Public Property balance() As Decimal
        Get
            Return _balance
        End Get
        Set(ByVal value As Decimal)
            _balance = value
        End Set
    End Property
    Public Property CurrentReading() As Decimal
        Get
            Return _CurrentReading
        End Get
        Set(ByVal value As Decimal)
            _CurrentReading = value
        End Set
    End Property
    Public Property Writeoff() As Decimal
        Get
            Return _Writeoff
        End Get
        Set(ByVal value As Decimal)
            _Writeoff = value
        End Set
    End Property
    Public Property Reason() As String
        Get
            Return _Reason
        End Get
        Set(ByVal value As String)
            _Reason = value
        End Set
    End Property
    Public Property Measurement() As Decimal
        Get
            Return _Measurement
        End Get
        Set(ByVal value As Decimal)
            _Measurement = value
        End Set
    End Property
    Public Property Temparature() As Decimal
        Get
            Return _Temparature
        End Get
        Set(ByVal value As Decimal)
            _Temparature = value
        End Set
    End Property
    Public Property FFA() As Decimal
        Get
            Return _FFA
        End Get
        Set(ByVal value As Decimal)
            _FFA = value
        End Set
    End Property

    Public Property Moisture() As Decimal
        Get
            Return _Moisture
        End Get
        Set(ByVal value As Decimal)
            _Moisture = value
        End Set
    End Property
    Public Property Dirt() As Decimal
        Get
            Return _Dirt
        End Get
        Set(ByVal value As Decimal)
            _Dirt = value
        End Set
    End Property
    Public Property Capacity() As Decimal
        Get
            Return _Capacity
        End Get
        Set(ByVal value As Decimal)
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
    Public Property PrevDayReading() As Decimal
        Get
            Return _PrevDayReading
        End Get
        Set(ByVal value As Decimal)
            _PrevDayReading = value
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
