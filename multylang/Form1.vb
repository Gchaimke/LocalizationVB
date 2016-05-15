
Imports System.Globalization
Imports System.ComponentModel
Public Class Form1
    Private Property CultureInfo As CultureInfo

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click

        My.Settings.language = ComboBox1.Text

        My.Settings.Save()

        If ComboBox1.SelectedIndex = 0 Then

            ChangeLanguage("en")

        Else

            ChangeLanguage("he-IL")

        End If


    End Sub


    Private Sub ChangeLanguage(ByVal Language As String)

        For Each c As Control In Me.Controls

            Dim crmLang As ComponentResourceManager = New ComponentResourceManager(GetType(Form1))

            crmLang.ApplyResources(c, c.Name, New CultureInfo(Language)) 'Set desired language

        Next c

    End Sub

    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        ChangeLanguage(My.Settings.language)
    End Sub
End Class
