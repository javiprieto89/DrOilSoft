Imports System.IO
Imports System
Imports System.Net
Imports Newtonsoft.Json.Linq
Imports Newtonsoft.Json

Module LeeCotizacionDolar
    Public Const DOLAR_OFICIAL As String = "Oficial"
    Public Const DOLAR_BLUE As String = "Blue"

    Public Function GetDolar() As Boolean
        Try
            Dim jsonResponse As String = New StreamReader((CType((CType(WebRequest.Create("https://dolarapi.com/v1/dolares"), HttpWebRequest)).GetResponse(), HttpWebResponse)).GetResponseStream()).ReadToEnd()
            Dim filePath As String = AppDomain.CurrentDomain.BaseDirectory & "\dolar.json"

            ' Escribir el contenido completo de la respuesta JSON en el archivo directamente
            System.IO.File.WriteAllText(filePath, jsonResponse)

            Return False
        Catch
            Return True
        End Try
    End Function

    Public Function LeeDolar(srch As String) As Cotizacion

        Dim f As String = AppDomain.CurrentDomain.BaseDirectory & "\dolar.json"
        Dim json As String = File.ReadAllText(f)
        Dim list As List(Of Cotizacion) = JsonConvert.DeserializeObject(Of List(Of Cotizacion))(json)

        Dim valDolar() As Cotizacion = New Cotizacion(list.Count - 1) {}
        Dim c As Integer = 0
        For Each cotizacion As Cotizacion In list
            valDolar(c) = cotizacion
            c += 1
        Next

        'Dim index As Integer '= Array.FindIndex(valDolar, Function(s) = "Dolar Oficial")
        ''Dim srch As String = "Dolar Blue"
        'Dim srch As String = "Dolar Oficial"
        'index = Array.Find(valDolar, srch)

        Dim index As Integer = Array.FindIndex(valDolar, Function(s) s.nombre = srch)
        'MsgBox(Index)
        Return valDolar(index)
    End Function
End Module
