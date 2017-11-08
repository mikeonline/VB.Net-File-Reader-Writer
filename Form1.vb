Imports System
Imports System.IO
Imports System.Net
Imports Newtonsoft.Json
Imports Newtonsoft.Json.Linq

Public Class Form1
    Const url as string = "https://api.fixer.io/latest"

    Private Function HttpGet(ByVal url As String) As string
        Dim request As WebRequest = WebRequest.Create(url)

        ' Get the response.  
        Dim response As WebResponse = request.GetResponse() 
        ' Get the stream containing content returned by the server. 
        Dim dataStream As Stream = response.GetResponseStream()  
        ' Open the stream using a StreamReader for easy access.  
        Dim reader As New StreamReader(dataStream)  
        ' Read the content.  
        Dim responseFromServer As String = reader.ReadToEnd()  

        Return responseFromServer
    End Function
    Public Class RatePair
        Public countryCode As String
        Public curRate As Decimal
    End Class
    Public Class FixerResponse
        Public baseCur As String
        Public requestDate As Date
        public rateObject As String
    End Class

    Private Function ParseString() As string
        Dim json As FixerResponse = JsonConvert.DeserializeObject(Of Object)(HttpGet(url))
        
        return json.Rates.Where(Function(x) x.countryCode Is "AUD").Select(Function(y) y.curRate).ToString()
    End Function

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
        TextBox2.Text = ParseString()
    End Sub

    Private Sub Form1_FormClosing(sender as Object, e as FormClosingEventArgs) _ 
        Handles MyBase.FormClosing

        File.WriteAllText(("C:\vbtest\TestFile.txt"), TextBox1.text)

    End Sub


End Class
