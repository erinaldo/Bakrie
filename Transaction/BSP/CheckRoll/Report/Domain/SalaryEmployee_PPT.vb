Namespace CheckRoll.Report.Domain
    Public Class SalaryEmployee_PPT

        Public Property TargetLatex() As String
        Public Property TargetLump() As String
        Public Property LatexPrograsive() As String
        Public Property LumpPrograsive() As String
        Public Property LatexBonus() As String
        Public Property LumpBonus() As String
        Public Property TL() As String

        Public Property ID() As String
        Public Property Dept() As String
        Public Property STTPTKP() As String
        Public Property Golongan() As String
        Public Property HkTdkDiByr() As Integer

        Public Property Nama() As String
        Public Property LokasiClass() As String
        Public Property GTTBeras() As String

        Public Property JenisKaryawan() As String
        Public Property JmlHariKerja() As String
        Public Property JmlHkTdkDibayar() As String
        Public Property STTJamsostek() As String

        'Public Property Detail() As IEnumerable(Of SalaryEmployeeDetail_PPT)

        Public Property IdPendapatan() As String
        Public Property Pendapatan() As String
        Public Property JmlPendapatan() As Integer

        Public Property IdPotongan() As String
        Public Property Potongan() As String
        Public Property Jmlpotongan() As Integer

        Public Property TotalPendapatan() As Integer
        Public Property TotalPotongan() As Integer
        Public Property GajiBersih() As Integer
        Public Property Pembulatan() As Integer
        Public Property GajiDibayar() As Integer
        Public Property BankId() As String
        Public Property BerasNatura() As Integer
        Public Property DagingNatura() As Integer
        Public Property DedSPSI() As Integer
        Public Property DedSPSB() As Integer
        Public Property GangID() As String
        Public Property MandorBesar() As String
    End Class
End Namespace