'funciones/usuarios.vb
Imports System.Data.SqlClient
Module usuarios

    ' ************************************ FUNCIONES DE USUARIOS **********************
    Public Function info_usuario(ByVal id_usuario As Integer) As usuario
        Dim tmp As New usuario
        Dim sqlstr As String = "SELECT id_usuario, usuario, password, nombre, activo FROM usuarios WHERE id_usuario = '" & id_usuario.ToString & "'"
        Dim dt As DataTable = GetDataTable(sqlstr)
        If dt.Rows.Count > 0 Then
            With dt.Rows(0)
                tmp.id_usuario = .Item(0).ToString
                tmp.usuario = .Item(1).ToString
                tmp.password = .Item(2).ToString
                tmp.nombre = .Item(3).ToString
                tmp.activo = .Item(4).ToString
            End With
        End If
        Return tmp
    End Function

    Public Function info_usuario(ByVal usuario As String, ByVal exacto As Boolean) As usuario
        Dim tmp As New usuario
        Dim sqlstr As String
        If exacto Then
            sqlstr = "SELECT id_usuario, usuario, password, nombre, activo FROM usuarios WHERE usuario = '" & usuario & "'"
        Else
            sqlstr = "SELECT id_usuario, usuario, password, nombre, activo FROM usuarios WHERE usuario LIKE '%" & usuario & "%'"
        End If
        Dim dt As DataTable = GetDataTable(sqlstr)
        If dt.Rows.Count > 0 Then
            With dt.Rows(0)
                tmp.id_usuario = .Item(0).ToString
                tmp.usuario = .Item(1).ToString
                tmp.password = .Item(2).ToString
                tmp.nombre = .Item(3).ToString
                tmp.activo = .Item(4).ToString
            End With
        End If
        Return tmp
    End Function

    Public Function addUsuario(ByVal u As usuario) As Boolean
        Dim sqlstr As String = "INSERT INTO usuarios (usuario, password, nombre, activo) VALUES ('" & u.usuario & "', '" & u.password & "', '" & u.nombre.ToString & "', '" & u.activo.ToString & "')"
        Return ExecuteNonQuery(sqlstr)
    End Function

    Public Function updateUsuario(ByVal u As usuario, Optional ByVal borra As Boolean = False) As Boolean
        Dim sqlstr As String
        If borra = True Then
            sqlstr = "UPDATE usuarios SET activo = '0' WHERE id_usuario = '" & u.id_usuario.ToString & "'"
        Else
            sqlstr = "UPDATE usuarios SET usuario = '" & u.usuario & "', password = '" & u.password.ToString & "', nombre = '" & u.nombre & "', activo = '" & u.activo.ToString & "' WHERE id_usuario = '" & u.id_usuario.ToString & "'"
        End If
        Return ExecuteNonQuery(sqlstr)
    End Function

    Public Function borrarUsuario(ByVal u As usuario) As Boolean
        Dim sqlstr As String = "DELETE FROM usuarios WHERE id_usuario = '" & u.id_usuario.ToString & "'"
        Return ExecuteNonQuery(sqlstr)
    End Function

    Public Function add_usuario_perfil(ByVal up As usuario_perfil) As Boolean
        Dim sqlstr As String = "INSERT INTO usuarios_perfiles (id_usuario, id_perfil) VALUES ('" & up.id_usuario.ToString & "', '" & up.id_perfil.ToString & "')"
        Return ExecuteNonQuery(sqlstr)
    End Function

    Public Function add_permiso_perfil(ByVal pp As perfil_permiso) As Boolean
        Dim sqlstr As String = "INSERT INTO permisos_perfiles (id_permiso, id_perfil) VALUES ('" & pp.id_permiso.ToString & "', '" & pp.id_perfil.ToString & "')"
        Return ExecuteNonQuery(sqlstr)
    End Function

    Public Function info_login(ByVal usuario As String, ByVal password As String) As usuario
        Dim tmp As New usuario
        Dim sqlstr As String = "SELECT id_usuario, usuario, password, nombre, activo FROM usuarios WHERE usuario = '" & usuario & "' AND password = '" & password & "'"
        Dim dt As DataTable = GetDataTable(sqlstr)
        If dt.Rows.Count > 0 Then
            With dt.Rows(0)
                tmp.id_usuario = .Item(0).ToString
                tmp.usuario = .Item(1).ToString
                tmp.password = .Item(2).ToString
                tmp.nombre = .Item(3).ToString
                tmp.activo = .Item(4).ToString
            End With
        End If
        Return tmp
    End Function
    ' ************************************ FUNCIONES DE USUARIOS **********************
End Module

