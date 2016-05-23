
Imports System.Globalization
Imports System.ComponentModel
Imports System.Resources
Imports System.Reflection
Imports System.Threading
Public Class Form1
    Private Property CultureInfo As CultureInfo
    Dim resFile As String = "multylang.MsgRes"
    Dim resources As New ResourceManager(resFile, [Assembly].GetExecutingAssembly())

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click

        My.Settings.language = ComboBox1.Text

        My.Settings.Save()

        If ComboBox1.SelectedIndex = 0 Then

            ChangeLanguage("en")
            MessageBox.Show(resources.GetString("MyStr"))
        Else

            ChangeLanguage("he-IL")
            MessageBox.Show(resources.GetString("MyStr"))
        End If


    End Sub


    Private Sub ChangeLanguage(ByVal Language As String)

        For Each c As Control In Me.Controls

            Dim crmLang As ComponentResourceManager = New ComponentResourceManager(GetType(Form1))

            crmLang.ApplyResources(c, c.Name, New CultureInfo(Language)) 'Set desired language

        Next c
        Thread.CurrentThread.CurrentUICulture = New CultureInfo(My.Settings.language)
        Thread.CurrentThread.CurrentCulture = New CultureInfo(My.Settings.language)
    End Sub

    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        ChangeLanguage(My.Settings.language)

    End Sub
End Class
