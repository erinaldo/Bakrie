Imports System.Configuration
Imports Core.Framework.Helper.Configuration
Imports Core.Framework.Helper.Contracts
Public Class BaseForm
    Inherits System.Windows.Forms.Form
    Public Sub New()
        AddHandler Load, AddressOf LoadForm
    End Sub

    Private Sub LoadForm(ByVal sender As Object, ByVal e As EventArgs)
        GenerateLanguage(Me)
    End Sub

    Private Sub GenerateLanguage(control As Control)

        Dim settingRepository As ISetting

        settingRepository = New SettingXml()
        For Each o As Control In GetAll(control, GetType(Control))
            If (o.GetType() Is GetType(Label)) Then
                If (ConfigurationManager.AppSettings.Get("GenerateLanguange").Equals("1")) Then
                    settingRepository.Save(CType(o, Label).Text.Trim(), CType(o, Label).Text.Trim())
                Else
                    CType(o, Label).Text = settingRepository.GetValue(CType(o, Label).Text.Trim())
                End If
            ElseIf (o.GetType() Is GetType(Button)) Then
                If (ConfigurationManager.AppSettings.Get("GenerateLanguange").Equals("1")) Then
                    settingRepository.Save(CType(o, Button).Text.Trim(), CType(o, Button).Text.Trim())
                Else
                    CType(o, Button).Text = settingRepository.GetValue(CType(o, Button).Text.Trim())
                End If

            ElseIf (o.GetType() Is GetType(RadioButton)) Then
                If (ConfigurationManager.AppSettings.Get("GenerateLanguange").Equals("1")) Then
                    settingRepository.Save(CType(o, RadioButton).Text.Trim(), CType(o, RadioButton).Text.Trim())
                Else
                    CType(o, RadioButton).Text = settingRepository.GetValue(CType(o, RadioButton).Text.Trim())
                End If
            ElseIf (o.GetType() Is GetType(CheckBox)) Then
                If (ConfigurationManager.AppSettings.Get("GenerateLanguange").Equals("1")) Then
                    settingRepository.Save(CType(o, CheckBox).Text.Trim(), CType(o, CheckBox).Text.Trim())
                Else
                    CType(o, CheckBox).Text = settingRepository.GetValue(CType(o, CheckBox).Text.Trim())
                End If
            ElseIf (o.GetType() Is GetType(TabControl)) Then
                For Each tabPage As Object In CType(o,TabControl).TabPages
                    GenerateLanguage(tabPage)
                Next
            End If
        Next
    End Sub

    Public Function GetAll(control As Control, type As Type) As IEnumerable(Of Control)
        Dim controls = control.Controls.Cast(Of Control)().ToList()
        Dim listTemp As List(Of Control) = New List(Of Control)()
        For Each control1 As Control In controls
            Dim items As IEnumerable(Of Control) = GetAll(control1, GetType(Control))
            listTemp.AddRange(items)
        Next
        controls.AddRange(listTemp)
        Return controls
    End Function
End Class
