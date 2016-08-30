Imports Budget_PPT
Imports Budget_BOL
Imports Common_BOL
Imports Common_PPT
Imports System.Data.SqlClient

Public Class StandardPriceListStockLookUp

    Public StrStockID As String = String.Empty
    Public StrStockCode As String = String.Empty
    Public strDescp As String = String.Empty
    Public deciTotalCost As Decimal = 0.0
    Public aIsDirect As String = String.Empty


    Private Sub StandardPriceListStockLookUp_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        'SetUICulture(GlobalPPT.strLang)
        FillGrid()
    End Sub




    Public Sub FillGrid()

        Dim ExpendBudget As New ExpenditureBudgetByAgeOfPlantingFrm
        Dim oExpenditureBudgetByAgeOfPlantingPPT As New ExpenditureBudgetByAgeOfPlantingPPT
        Dim oExpenditureBudgetByAgeOfPlantingBOL As New ExpenditureBudgetByAgeOfPlantingBOL
        aIsDirect = ExpenditureBudgetByAgeOfPlantingFrm.IsDirect
       

        Dim ds As New DataSet
        oExpenditureBudgetByAgeOfPlantingPPT.IsDirect = aIsDirect
        oExpenditureBudgetByAgeOfPlantingPPT.Descp = txtDescpSearch.Text
        'objPPT.BudgetYear = txtBudgetYearSearch.Text.ToString
        ds = oExpenditureBudgetByAgeOfPlantingBOL.StandardPriceListStockLoopUPSelect(oExpenditureBudgetByAgeOfPlantingPPT)
        If (ds.Tables(0).Rows.Count > 0) Then
            'lblNoRecord.Visible = True
            dgStockLookUp.AutoGenerateColumns = False
            dgStockLookUp.DataSource = ds.Tables(0)
        Else
            'lblNoRecord.Visible = False
            dgStockLookUp.AutoGenerateColumns = False
            dgStockLookUp.DataSource = ds.Tables(0)
        End If
    End Sub

    Private Sub dgStockLookUp_DoubleClick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles dgStockLookUp.DoubleClick
        If dgStockLookUp.Rows.Count > 0 Then

            StrStockID = dgStockLookUp.CurrentRow.Cells("StandardPriceListID").Value.ToString()
            strDescp = dgStockLookUp.CurrentRow.Cells("Descp").Value.ToString()
            deciTotalCost = dgStockLookUp.CurrentRow.Cells("TotalCost").Value.ToString()
        
            StrStockCode = dgStockLookUp.CurrentRow.Cells("StockCode").Value.ToString()


            Me.DialogResult = DialogResult.OK
            Me.Close()
        Else
            MessageBox.Show("There is no record to select")
        End If
    End Sub

    
    Private Sub btnSTockCodeLookUpSearch_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSTockCodeLookUpSearch.Click

        'Dim objPPT As New StandardPriceListPPT
        Dim oExpenditureBudgetByAgeOfPlantingPPT As New ExpenditureBudgetByAgeOfPlantingPPT
        Dim oExpenditureBudgetByAgeOfPlantingBOL As New ExpenditureBudgetByAgeOfPlantingBOL

        Dim ds As New DataSet

        If txtDescpSearch.Text <> Nothing Then
            oExpenditureBudgetByAgeOfPlantingPPT.Descp = txtDescpSearch.Text
            oExpenditureBudgetByAgeOfPlantingPPT.BudgetYear = Val(txtBudgetYearSearch.Text)
            oExpenditureBudgetByAgeOfPlantingPPT.IsDirect = aIsDirect
            ds = oExpenditureBudgetByAgeOfPlantingBOL.StandardPriceListStockLoopUPSelect(oExpenditureBudgetByAgeOfPlantingPPT)
            If (ds.Tables(0).Rows.Count > 0) Then
                'lblNoRecord.Visible = True
                dgStockLookUp.AutoGenerateColumns = False
                dgStockLookUp.DataSource = ds.Tables(0)
            Else
                MsgBox("No record(s) found matching your search criteria.")
                dgStockLookUp.AutoGenerateColumns = False
                dgStockLookUp.DataSource = ds.Tables(0)
            End If

        Else
            MsgBox("Please enter criteria to search!")
            
            FillGrid()
        End If
    End Sub
End Class