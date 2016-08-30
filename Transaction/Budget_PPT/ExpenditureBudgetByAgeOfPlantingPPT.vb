Public Class ExpenditureBudgetByAgeOfPlantingPPT

#Region "Private Member Declarations"

    Private _COACode As String
    Private _COADescp As String
    Private _StockCode As String
    Private _Descp As String
    Private _IsDirect As String
    'EBBAOP 
    Private _EBBAOPID As String = String.Empty
    Private _EstateID As String = String.Empty
    Private _BudgetYear As Integer
    Private _AgeOfPlanting As String = String.Empty
    Private _Yearofplanting As Integer
    Private _COAID As String = String.Empty
    Private _MDaysRound As Decimal

    Private _Labour As Decimal
    Private _Material As Decimal
    Private _Other As Decimal
    Private _Total As Decimal
    Private _Rounds As Decimal
    Private _RpPerHect As Decimal


    'EBBAOPOther
    Private _EBBAOPOtherID As String = String.Empty
    Private _OtherActivity As String = String.Empty
    Private _OtherUOMID As String = String.Empty
    Private _OtherUOM As String = String.Empty
    Private _OtherQty As Decimal
    Private _OtherStandardPriceListID As String = String.Empty

    'EBBAOPmaterial
    Private _EBBAOPMaterialID As String = String.Empty
    Private _StandardPriceListID As String = String.Empty
    Private _StockDescp As String = String.Empty
    Private _Calc As Decimal
    Private _CalcUOM As String = String.Empty
    Private _CalcUOMID As String = String.Empty
    Private _Qty As Decimal
    Private _QtyUOM As String = String.Empty
    Private _QtyUOMID As String = String.Empty
    Private _UnitPrice As Decimal
    Private _Cost As Decimal

#End Region

#Region "Public Member Declarations"

    Public Property IsDirect() As String
        Get
            Return _IsDirect
        End Get
        Set(ByVal value As String)
            _IsDirect = value
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
    Public Property COADescp() As String
        Get
            Return _COADescp
        End Get
        Set(ByVal value As String)
            _COADescp = value
        End Set
    End Property

    Public Property COACode() As String
        Get
            Return _COACode
        End Get
        Set(ByVal value As String)
            _COACode = value
        End Set
    End Property
    Public Property StockCode() As String
        Get
            Return _StockCode
        End Get
        Set(ByVal value As String)
            _StockCode = value
        End Set
    End Property


    Public Property EBBAOPID() As String
        Get
            Return _EBBAOPID
        End Get
        Set(ByVal value As String)
            _EBBAOPID = value
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


    Public Property BudgetYear() As Integer
        Get
            Return _BudgetYear
        End Get
        Set(ByVal value As Integer)
            _BudgetYear = value
        End Set
    End Property

    Public Property AgeOfPlanting() As String
        Get
            Return _AgeOfPlanting
        End Get
        Set(ByVal value As String)
            _AgeOfPlanting = value

        End Set
    End Property


    Public Property Yearofplanting() As Integer
        Get
            Return _Yearofplanting
        End Get
        Set(ByVal value As Integer)
            _Yearofplanting = value
        End Set
    End Property

    Public Property COAID() As String
        Get
            Return _COAID
        End Get
        Set(ByVal value As String)
            _COAID = value
        End Set
    End Property

    Public Property MDaysRound() As Decimal
        Get
            Return _MDaysRound
        End Get
        Set(ByVal value As Decimal)
            _MDaysRound = value
        End Set
    End Property



    Public Property EBBAOPOtherID() As String
        Get
            Return _EBBAOPOtherID
        End Get
        Set(ByVal value As String)
            _EBBAOPOtherID = value
        End Set
    End Property
    Public Property OtherActivity() As String
        Get
            Return _OtherActivity
        End Get
        Set(ByVal value As String)
            _OtherActivity = value
        End Set
    End Property
    Public Property OtherUOMID() As String
        Get
            Return _OtherUOMID
        End Get
        Set(ByVal value As String)
            _OtherUOMID = value
        End Set
    End Property
    Public Property OtherUOM() As String
        Get
            Return _OtherUOM
        End Get
        Set(ByVal value As String)
            _OtherUOM = value
        End Set
    End Property

    Public Property OtherQty() As Decimal
        Get
            Return _OtherQty
        End Get
        Set(ByVal value As Decimal)
            _OtherQty = value
        End Set
    End Property
    Public Property Labour() As Decimal
        Get
            Return _Labour
        End Get
        Set(ByVal value As Decimal)
            _Labour = value
        End Set
    End Property
    Public Property Material() As Decimal
        Get
            Return _Material
        End Get
        Set(ByVal value As Decimal)
            _Material = value
        End Set
    End Property
    Public Property Other() As Decimal
        Get
            Return _Other
        End Get
        Set(ByVal value As Decimal)
            _Other = value
        End Set
    End Property
    Public Property Total() As Decimal
        Get
            Return _Total
        End Get
        Set(ByVal value As Decimal)
            _Total = value
        End Set
    End Property
    Public Property Rounds() As Decimal
        Get
            Return _Rounds
        End Get
        Set(ByVal value As Decimal)
            _Rounds = value
        End Set
    End Property
    Public Property RpPerHect() As Decimal
        Get
            Return _RpPerHect
        End Get
        Set(ByVal value As Decimal)
            _RpPerHect = value
        End Set
    End Property
    Public Property OtherStandardPriceListID() As String
        Get
            Return _OtherStandardPriceListID
        End Get
        Set(ByVal value As String)
            _OtherStandardPriceListID = value
        End Set
    End Property


    Public Property EBBAOPMaterialID() As String
        Get
            Return _EBBAOPMaterialID
        End Get
        Set(ByVal value As String)
            _EBBAOPMaterialID = value
        End Set
    End Property
    Public Property StandardPriceListID() As String
        Get
            Return _StandardPriceListID
        End Get
        Set(ByVal value As String)
            _StandardPriceListID = value
        End Set
    End Property
    Public Property StockDescp() As String
        Get
            Return _StockDescp
        End Get
        Set(ByVal value As String)
            _StockDescp = value
        End Set
    End Property
    Public Property CalcUOMID() As String
        Get
            Return _CalcUOMID
        End Get
        Set(ByVal value As String)
            _CalcUOMID = value
        End Set
    End Property
    Public Property CalcUOM() As String
        Get
            Return _CalcUOM
        End Get
        Set(ByVal value As String)
            _CalcUOM = value
        End Set
    End Property
    Public Property QtyUOMID() As String
        Get
            Return _QtyUOMID
        End Get
        Set(ByVal value As String)
            _QtyUOMID = value
        End Set
    End Property
    Public Property QtyUOM() As String
        Get
            Return _QtyUOM
        End Get
        Set(ByVal value As String)
            _QtyUOM = value
        End Set
    End Property
    Public Property Calc() As Decimal
        Get
            Return _Calc
        End Get
        Set(ByVal value As Decimal)
            _Calc = value
        End Set
    End Property
    Public Property Qty() As Decimal
        Get
            Return _Qty
        End Get
        Set(ByVal value As Decimal)
            _Qty = value
        End Set
    End Property
    Public Property UnitPrice() As Decimal
        Get
            Return _UnitPrice
        End Get
        Set(ByVal value As Decimal)
            _UnitPrice = value
        End Set
    End Property
    Public Property Cost() As Decimal
        Get
            Return _Cost
        End Get
        Set(ByVal value As Decimal)
            _Cost = value
        End Set
    End Property
#End Region

End Class
