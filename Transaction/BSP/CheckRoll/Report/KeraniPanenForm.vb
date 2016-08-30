Imports System.IO
Imports System.Configuration
Imports Microsoft.Office.Interop
Imports System.Reflection
Imports CheckRoll_DAL

Public Class KeraniPanenForm


    Private Sub KeraniPanenForm_Load(sender As System.Object, e As System.EventArgs) Handles MyBase.Load
        dpDate.Value = Today.Date
    End Sub

    Private Sub btnClose_Click(sender As System.Object, e As System.EventArgs) Handles btnClose.Click
        If (MessageBox.Show("Do you want to close this screen? If yes please click 'OK' or click 'Cancel'", "Confirmation", MessageBoxButtons.OKCancel) = Windows.Forms.DialogResult.OK) Then
            Me.Close()
        End If
    End Sub

    Private Sub btnReport_Click(sender As System.Object, e As System.EventArgs) Handles btnReport.Click
        PrepareReport()
        'TestExcel()
    End Sub

    Sub PrepareReport()

        Dim templateDirectory As String = GetReportFile()
        If templateDirectory = String.Empty Then
            MsgBox("Kerani Panen Form template missing. Please contact system administrator.")
        Else
            Dim reportDirectory As String = CreateReportDirectory()
            If reportDirectory = String.Empty Then
                MessageBox.Show("Report directory not found", "BSP")
            Else
                'get data
                Dim dt As DataTable = DailyReceiptionWithTeam_DAL.DailyReceiptionWithTeamReportByDate(dpDate.Value)
                ' get TOTAL unique employees and blocks to format the rows
                Dim uniqueEmployees As Integer = dt.DefaultView.ToTable(True, New String() {"BlockName", "EmpCode"}).Rows.Count

                Dim dr As DataTableReader = New DataTableReader(dt)

                If (dr.HasRows) Then

                    ' dataset to hold all the blocks in seperate datatables
                    Dim dsReceptions As New DataSet

                    ' get unique blocks
                    Dim dtBlocks As DataTable = dt.DefaultView.ToTable(True, "BlockName")
                    'convert each block to a table and ADD to dataset
                    For Each row As DataRow In dtBlocks.Rows
                        'filter datatable by block and split to tables
                        dt.DefaultView.RowFilter = "BlockName = '" + row("BlockName") + "'"
                        Dim dtBlock As DataTable = dt.DefaultView.ToTable(row("BlockName"))
                        dsReceptions.Tables.Add(dtBlock)
                    Next row


                    ' template dir and report dir exists
                    Dim xlApp As Excel.Application
                    Dim xlWorkBook As Excel.Workbook
                    Dim sheet As Excel.Worksheet = Nothing

                    'to fix an Excel bug need to change the culture info
                    Dim oldCI As System.Globalization.CultureInfo = System.Threading.Thread.CurrentThread.CurrentCulture
                    System.Threading.Thread.CurrentThread.CurrentCulture = New System.Globalization.CultureInfo("en-US")

                    xlApp = New Excel.Application()

                    xlWorkBook = xlApp.Workbooks.Open(templateDirectory)

                    sheet = xlWorkBook.Sheets("Sheet1")
                    sheet = DirectCast(xlWorkBook.Sheets(1), Excel.Worksheet)

                    Dim currentReportFile As String = "KeraniPanen-" + dpDate.Value.ToString("dd-MMM-yyyy")
                    currentReportFile = reportDirectory & "\" & currentReportFile & ".xls"


                    'If (File.Exists(currentReportFile)) Then
                    '    File.Delete(currentReportFile)
                    'Else
                    '    xlWorkBook.SaveAs(currentReportFile, Excel.XlFileFormat.xlWorkbookNormal, System.Type.Missing, System.Type.Missing, System.Type.Missing, System.Type.Missing, Excel.XlSaveAsAccessMode.xlShared, System.Type.Missing, System.Type.Missing, System.Type.Missing, System.Type.Missing, System.Type.Missing)
                    'End If

                    'xlApp.Visible = True
                    Cursor = Cursors.WaitCursor

                    'Fill report headers
                    'harvest date
                    sheet.Cells(2, 19) = dpDate.Value.ToString("dd-MMM-yyyy")
                    'report date
                    sheet.Cells(2, 24) = Date.Now.ToString("dd-MMM-yyyy")
                    'estate name
                    sheet.Cells(3, 4) = dt.Rows(0)("EstateName")
                    'team name
                    'sheet.Cells(5, 4) = dt.Rows(0)("DivName")
                    'sub-block
                    'sheet.Cells(6, 2) = "Sub-Block: " + dt.Rows(0)("BlockName")

                    '------------------- Start formatting records --------

                    FormatExcelSheet(uniqueEmployees, sheet)

                    Dim currentRow As Integer = 5
                    Dim rowCountInRecord As Integer = 18 ' 16 rows AND 2 empty rows in one record

                    For Each table As DataTable In dsReceptions.Tables
                        currentRow = TeamRecords(table, sheet, currentRow)
                    Next table


                    sheet.Protect("RANNBSP@2010", Contents:=True, UserInterfaceOnly:=False, AllowFormattingColumns:=True)

                    sheet.Visible = True
                    xlApp.Visible = True
                    xlApp.UserControl = True


                    'save the file
                    If (File.Exists(currentReportFile)) Then
                        File.Delete(currentReportFile)
                    End If

                    xlWorkBook.SaveAs(currentReportFile, Excel.XlFileFormat.xlWorkbookNormal, System.Type.Missing, System.Type.Missing, System.Type.Missing, System.Type.Missing, Excel.XlSaveAsAccessMode.xlShared, System.Type.Missing, System.Type.Missing, System.Type.Missing, System.Type.Missing, System.Type.Missing)

                    'Clean up
                    sheet = Nothing
                    xlWorkBook = Nothing
                    xlApp = Nothing

                    Cursor = Cursors.Default

                    ' put CultureInfo back to original
                    System.Threading.Thread.CurrentThread.CurrentCulture = oldCI


                Else
                    MessageBox.Show("Did not match any record", "Not Found", MessageBoxButtons.OK, MessageBoxIcon.Information)
                End If
            End If
        End If

    End Sub


    Function TeamRecords(ByVal dtTeam As DataTable, ByRef sheet As Excel.Worksheet, ByVal currentRow As Integer) As Integer
        Dim rowCountInRecord As Integer = 18 ' 18 rows in one record

        ' get unique employees and group multiple TPH data for each employee
        Dim dtEmployees As DataTable = dtTeam.DefaultView.ToTable(True, New String() {"BlockName", "EmpCode"})

        Dim teamFirstRecord = True

        For Each employee As DataRow In dtEmployees.Rows

            'filter datatable by employee
            dtTeam.DefaultView.RowFilter = "EmpCode = '" + employee("EmpCode") + "' AND BlockName = '" + employee("BlockName") + "'"
            Dim dv As DataView = dtTeam.DefaultView

            Dim dr As DataTableReader = New DataTableReader(dv.ToTable())

            Dim columnIndex As Integer = 4
            Dim empFirstRecord = True

            While dr.Read()
                If (empFirstRecord) Then
                    If teamFirstRecord Then
                        'If currentRow > 5 Then
                        '    sheet.HPageBreaks.Add(sheet.Range("A" + currentRow.ToString()))
                        'End If
                        sheet.Cells(currentRow, columnIndex) = dr("BlockName")
                        teamFirstRecord = False
                    Else
                        'remove team name row
                        sheet.Rows(currentRow).delete()
                        sheet.Rows(currentRow).delete()
                        currentRow = currentRow - 2
                    End If
                    sheet.Cells(currentRow + 2, columnIndex) = dr("EmpName")
                    sheet.Cells(currentRow + 2, 12) = dr("EmpCode")
                    sheet.Cells(currentRow + 2, 17) = dr("GangName")
                    sheet.Cells(currentRow + 2, 22) = dr("FKPSerialNo")

                    empFirstRecord = False
                End If
                'TphNormal
                'sheet.Cells(currentRow + 3, columnIndex) = dr("BlockName")

                If dr("TphNormal") <> "0" Then
                    sheet.Cells(currentRow + 3, columnIndex) = dr("TphNormal")
                    sheet.Cells(currentRow + 4, columnIndex) = dr("UnripeNormal")
                    sheet.Cells(currentRow + 5, columnIndex) = dr("UnderRipeNormal")
                    sheet.Cells(currentRow + 6, columnIndex) = dr("OverRipeNormal")
                    sheet.Cells(currentRow + 7, columnIndex) = dr("RipeNormal")
                    sheet.Cells(currentRow + 8, columnIndex) = dr("LooseFruitNormal")
                    sheet.Cells(currentRow + 9, columnIndex) = dr("DiscardedNormal")
                    sheet.Cells(currentRow + 10, columnIndex) = dr("HarvestedNormal")
                    sheet.Cells(currentRow + 11, columnIndex) = dr("DeductedNormal")
                    sheet.Cells(currentRow + 12, columnIndex) = dr("PaidNormal")
                Else
                    sheet.Cells(currentRow + 3, columnIndex) = dr("TphBorongan")
                    sheet.Cells(currentRow + 4, columnIndex) = dr("UnripeBorongan")
                    sheet.Cells(currentRow + 5, columnIndex) = dr("UnderRipeBorongan")
                    sheet.Cells(currentRow + 6, columnIndex) = dr("OverRipeBorongan")
                    sheet.Cells(currentRow + 7, columnIndex) = dr("RipeBorongan")
                    sheet.Cells(currentRow + 8, columnIndex) = dr("LooseFruitBorongan")
                    sheet.Cells(currentRow + 9, columnIndex) = dr("DiscardedBorongan")
                    sheet.Cells(currentRow + 10, columnIndex) = dr("HarvestedBorongan")
                    sheet.Cells(currentRow + 11, columnIndex) = dr("DeductedBorongan")
                    sheet.Cells(currentRow + 12, columnIndex) = dr("PaidBorongan")
                End If
                sheet.Cells(currentRow + 14, columnIndex) = dr("Ha")

                columnIndex = columnIndex + 2

            End While

            sheet.Range("E" + (currentRow + 3).ToString(), "E" + (currentRow + 15).ToString()).Locked = False
            sheet.Range("G" + (currentRow + 3).ToString(), "G" + (currentRow + 15).ToString()).Locked = False
            sheet.Range("I" + (currentRow + 3).ToString(), "I" + (currentRow + 15).ToString()).Locked = False
            sheet.Range("K" + (currentRow + 3).ToString(), "K" + (currentRow + 15).ToString()).Locked = False
            sheet.Range("M" + (currentRow + 3).ToString(), "M" + (currentRow + 15).ToString()).Locked = False
            sheet.Range("O" + (currentRow + 3).ToString(), "O" + (currentRow + 15).ToString()).Locked = False
            sheet.Range("Q" + (currentRow + 3).ToString(), "Q" + (currentRow + 15).ToString()).Locked = False
            sheet.Range("S" + (currentRow + 3).ToString(), "S" + (currentRow + 15).ToString()).Locked = False
            sheet.Range("U" + (currentRow + 3).ToString(), "U" + (currentRow + 15).ToString()).Locked = False
            sheet.Range("W" + (currentRow + 3).ToString(), "W" + (currentRow + 15).ToString()).Locked = False
            sheet.Range("Y" + (currentRow + 3).ToString(), "Y" + (currentRow + 15).ToString()).Locked = False
            sheet.Range("AA" + (currentRow + 3).ToString(), "AA" + (currentRow + 15).ToString()).Locked = False
            sheet.Range("AC" + (currentRow + 3).ToString(), "AC" + (currentRow + 15).ToString()).Locked = False
            sheet.Range("AE" + (currentRow + 3).ToString(), "AE" + (currentRow + 15).ToString()).Locked = False
            sheet.Range("AG" + (currentRow + 3).ToString(), "AG" + (currentRow + 15).ToString()).Locked = False
            sheet.Range("AI" + (currentRow + 3).ToString(), "AI" + (currentRow + 15).ToString()).Locked = False
            sheet.Range("AK" + (currentRow + 3).ToString(), "AK" + (currentRow + 15).ToString()).Locked = False

            currentRow = currentRow + rowCountInRecord

        Next employee

        Return currentRow

    End Function

    Sub FormatExcelSheet(ByVal NoOfRecords As Integer, ByRef sheet As Excel.Worksheet)
        '------------------- Start formating records --------
        Dim currentRow As Integer = 5
        Dim rowCountInRecord As Integer = 16 ' 16 rows in one record
        NoOfRecords = NoOfRecords - 1 ' first record is already in the template so no need to format that record

        For value As Integer = 1 To NoOfRecords
            'sheet.Cells(currentRow, 2) = "Employee: "
            Dim startRow As Integer = currentRow + rowCountInRecord + 2
            sheet.Range("B" + currentRow.ToString(), "AK" + (currentRow + rowCountInRecord).ToString()).Copy(sheet.Range("B" + startRow.ToString(), "AK" + (startRow + rowCountInRecord).ToString()))

            currentRow = startRow
        Next


    End Sub

    

    Function GetReportFile() As String
        Dim ReportDirectory As String = String.Empty
        Dim TemPath As String = Application.StartupPath & "\CheckRoll\Report\Excel\KeraniPanenForm_Report_Template.xls"

        Dim strFile = String.Empty

        If (File.Exists(TemPath)) Then
            strFile = TemPath
        End If

        Return strFile
    End Function

    Function CreateReportDirectory() As String
        Dim ReportDirectory As String = "" & ConfigurationManager.AppSettings.Item("oReportDirectory").ToString & ""

        Dim sDirName As String
        sDirName = ReportDirectory + ":"
        Dim dDir As New DirectoryInfo(sDirName)

        If Not dDir.Exists Then

            Return String.Empty
        End If

        sDirName = sDirName & "\BSP Checkroll Reports"
        Dim di As DirectoryInfo = New DirectoryInfo(sDirName)
        ' Determine whether the directory exists.
        If Not di.Exists Then
            di.Create()
        End If

        Return sDirName
    End Function

End Class