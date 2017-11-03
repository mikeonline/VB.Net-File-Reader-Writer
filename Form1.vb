Imports System
Imports System.IO

Public Class Form1

    Private Sub Form1_Load(ByVal sender As Object, _
                           ByVal e As System.EventArgs) Handles MyBase.Load
        Try
            Using sr As StreamReader = New StreamReader("C:\vbtest\TestFile.txt")
                Dim line = sr.ReadToEnd()
                TextBox1.Text = line
            End Using
        Catch
            TextBox1.Text = "Could not read the file"
        End Try
    End Sub

    Private Sub Form1_FormClosing(sender as Object, e as FormClosingEventArgs) _ 
        Handles MyBase.FormClosing

        File.WriteAllText(("C:\vbtest\TestFile.txt"), TextBox1.text)

    End Sub
End Class
