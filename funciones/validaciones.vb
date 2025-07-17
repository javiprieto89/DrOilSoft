'funciones/Validaciones.vb

Imports System.Windows.Forms

Module Validaciones    
    'Verifica que un TextBox no esté vacío. Si lo está, muestra un mensaje y devuelve False.
    'Si no, devuelve True.
    Public Function CheckRequiredField(ByVal txt As TextBox, ByVal nombreCampo As String) As Boolean
        If txt.Text.Trim() = "" Then
            MsgBox("El campo '" & nombreCampo & "' es obligatorio y está vacio")
            Return False
        End If
        Return True
    End Function
End Module