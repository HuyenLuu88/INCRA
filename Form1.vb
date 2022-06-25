
Imports RestSharp
Imports System.Net
Imports System.Net.Security
Imports System.Security.Cryptography.X509Certificates
Imports HtmlAgilityPack
Imports System.Text
Imports System.IO
Imports System.Text.Json.Serialization

Public Class PostData
    Public j_idt5 As String
    Public j_idt5_numcert As String
    Public j_idt5_j_idt12 As String
    Public j_idt5_j_idt9_collapsed As String
    Public j_idt5_j_idt20 As String
    Public j_idt5_j_idt22 As String
    Public j_idt5_j_idt24 As String
    Public j_idt5_j_idt26 As String
    Public j_idt5_j_idt28 As String
    Public j_idt5_j_idt30 As String
    Public j_idt5_j_idt32 As String
    Public j_idt5_pdados_collapsed As String
    Public javax_faces_ViewState As String
    Public j_idt5_tabela1_j_idt44 As String
End Class
Public Class Form1

    Public Function AcceptAllCertifications(sender As Object, certification As X509Certificate,
                    chain As X509Chain, sslPolicyErrors As SslPolicyErrors) As Boolean
        Return True
    End Function

    Dim checked As Boolean = False

    Dim searchData As String
    Dim postCSVData As PostData
    Dim client As RestClient = New RestClient("https://acervofundiario.incra.gov.br/")

    'Get ViewState
    Private Function GetSearchPostData(html As String) As PostData
        Dim data As PostData = New PostData()
        Dim htmlDoc = New HtmlDocument()
        htmlDoc.LoadHtml(html)
        Dim element = htmlDoc.GetElementbyId("j_id1:javax.faces.ViewState:0")

        data.j_idt5 = "j_idt5"
        data.j_idt5_numcert = txtCertNum.Text
        data.j_idt5_j_idt12 = ""
        data.j_idt5_j_idt9_collapsed = "false"
        data.j_idt5_j_idt20 = ""
        data.j_idt5_j_idt22 = ""
        data.j_idt5_j_idt24 = ""
        data.j_idt5_j_idt26 = ""
        data.j_idt5_j_idt28 = ""
        data.j_idt5_j_idt30 = ""
        data.j_idt5_j_idt32 = ""
        data.j_idt5_pdados_collapsed = "false"
        data.javax_faces_ViewState = element.GetAttributeValue("value", "")
        data.j_idt5_tabela1_j_idt44 = ""

        Return data
    End Function

    Private Function GetExtractPostData(html As String) As PostData
        Dim data As PostData = New PostData()
        Dim htmlDoc = New HtmlDocument()
        htmlDoc.LoadHtml(html)

        data.j_idt5 = "j_idt5"
        data.j_idt5_numcert = txtCertNum.Text

        data.j_idt5_j_idt9_collapsed = "false"

        Dim element = htmlDoc.GetElementbyId("j_idt5:j_idt20")
        data.j_idt5_j_idt20 = element.GetAttributeValue("value", "")

        element = htmlDoc.GetElementbyId("j_idt5:j_idt22")
        data.j_idt5_j_idt22 = element.GetAttributeValue("value", "")

        element = htmlDoc.GetElementbyId("j_idt5:j_idt24")
        data.j_idt5_j_idt24 = element.GetAttributeValue("value", "")

        element = htmlDoc.GetElementbyId("j_idt5:j_idt26")
        data.j_idt5_j_idt26 = element.GetAttributeValue("value", "")

        element = htmlDoc.GetElementbyId("j_idt5:j_idt28")
        data.j_idt5_j_idt28 = element.GetAttributeValue("value", "")

        element = htmlDoc.GetElementbyId("j_idt5:j_idt30")
        data.j_idt5_j_idt30 = element.GetAttributeValue("value", "")

        element = htmlDoc.GetElementbyId("j_idt5:j_idt32")
        data.j_idt5_j_idt32 = element.GetAttributeValue("value", "")

        data.j_idt5_pdados_collapsed = "false"

        element = htmlDoc.GetElementbyId("j_id1:javax.faces.ViewState:0")
        data.javax_faces_ViewState = element.GetAttributeValue("value", "")

        data.j_idt5_tabela1_j_idt44 = "j_idt5:tabela1:j_idt44"

        Return data
    End Function
    Private Function CreateRequest() As RestRequest
        Dim request = New RestRequest("/Conversao01/faces/index.xhtml", Method.Post)
        request.AddHeader("Content-Type", "application/x-www-form-urlencoded")
        Return request
    End Function
    Private Function PostFormDataSearch(data As PostData) As String
        Dim request = CreateRequest()
        request.AddParameter("j_idt5", data.j_idt5)
        request.AddParameter("j_idt5:numcert", data.j_idt5_numcert)
        request.AddParameter("j_idt5:j_idt9_collapsed", data.j_idt5_j_idt9_collapsed)
        request.AddParameter("j_idt5:pdados_collapsed", data.j_idt5_pdados_collapsed)
        request.AddParameter("javax.faces.ViewState", data.javax_faces_ViewState)
        request.AddParameter("j_idt5:j_idt12", "")
        request.AddParameter("j_idt5:j_idt20", "")
        request.AddParameter("j_idt5:j_idt22", "")
        request.AddParameter("j_idt5:j_idt24", "")
        request.AddParameter("j_idt5:j_idt26", "")
        request.AddParameter("j_idt5:j_idt28", "")
        request.AddParameter("j_idt5:j_idt30", "")
        request.AddParameter("j_idt5:j_idt32", "")

        Dim res = client.Execute(request)

        Return res.Content
    End Function

    Private Function PostFormDataCSV(data As PostData) As String

        Dim request = CreateRequest()

        request.AddParameter("j_idt5", data.j_idt5)
        request.AddParameter("j_idt5:numcert", data.j_idt5_numcert)
        request.AddParameter("j_idt5:j_idt9_collapsed", data.j_idt5_j_idt9_collapsed)
        request.AddParameter("j_idt5:j_idt20", data.j_idt5_j_idt20)
        request.AddParameter("j_idt5:j_idt22", data.j_idt5_j_idt22)
        request.AddParameter("j_idt5:j_idt24", data.j_idt5_j_idt24)
        request.AddParameter("j_idt5:j_idt26", data.j_idt5_j_idt26)
        request.AddParameter("j_idt5:j_idt28", data.j_idt5_j_idt28)
        request.AddParameter("j_idt5:j_idt30", data.j_idt5_j_idt30)
        request.AddParameter("j_idt5:j_idt32", data.j_idt5_j_idt32)
        request.AddParameter("j_idt5:pdados_collapsed", data.j_idt5_pdados_collapsed)
        request.AddParameter("javax.faces.ViewState", data.javax_faces_ViewState)
        request.AddParameter("j_idt5:tabela1:j_idt44", data.j_idt5_tabela1_j_idt44)

        Dim res = client.Execute(request)

        Return res.Content
    End Function
    Private Function DoSaveItems(fileName As String, csvData As String())
        Dim outFile As IO.StreamWriter = My.Computer.FileSystem.OpenTextFileWriter(fileName, False)
        outFile.WriteLine("Coordenada X, Coordenada Y")
        For i As Integer = 2 To csvData.Length / 2 - 1
            Dim str = "" + csvData(2 * i) + ", " + csvData(2 * i + 1) + ""
            outFile.WriteLine(str)
        Next
        outFile.Close()
        Return ""
    End Function
    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Try
            ServicePointManager.ServerCertificateValidationCallback =
                New RemoteCertificateValidationCallback(AddressOf AcceptAllCertifications)

            Dim client As WebClient = New WebClient()
            Dim text As String = client.DownloadString("https://acervofundiario.incra.gov.br/Conversao01/faces/index.xhtml")

            Dim postData = GetSearchPostData(Text)

            searchData = PostFormDataSearch(PostData)
            'searchData = My.Computer.FileSystem.ReadAllText("C:\temp\second.html")
            postCSVData = GetExtractPostData(searchData)

            MsgBox(postCSVData.j_idt5_j_idt20 & ControlChars.CrLf & postCSVData.j_idt5_j_idt22 & ControlChars.CrLf & postCSVData.j_idt5_j_idt30 & ControlChars.CrLf)

            checked = True

        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Exclamation, Me.Text)
        End Try
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        Try

            Dim data = PostFormDataCSV(postCSVData)

            data = data.Replace("""", String.Empty)

            Dim csvData = data.Split(","c, ControlChars.CrLf, ControlChars.Lf)
            Dim strList As List(Of String) = csvData.ToList()

            For Each arr As String In csvData
                strList.Remove("")
            Next

            csvData = strList.ToArray()

            Dim SFD As New SaveFileDialog()
            Try
                With SFD
                    .AddExtension = True
                    .CheckPathExists = True
                    .CreatePrompt = False
                    .OverwritePrompt = True
                    .ValidateNames = True
                    .ShowHelp = True
                    .DefaultExt = "txt"
                    .Filter =
                        "CSV Files (*.csv)|*.csv|" &
                        "All files|*.*"
                    .FilterIndex = 1

                    If .ShowDialog() = System.Windows.Forms.DialogResult.OK Then
                        DoSaveItems(.FileName, csvData)
                        MsgBox("Saved the CSV file!")
                    End If

                End With
            Catch ex As Exception
                MsgBox(ex.Message, MsgBoxStyle.Exclamation, Me.Text)
            End Try
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Exclamation, Me.Text)
        End Try
    End Sub

End Class
