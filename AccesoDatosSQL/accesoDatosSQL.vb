Imports System.Data.SqlClient

Public Class accesodatosSQL

    Private Shared conexion As New SqlConnection

    Private Shared comando As New SqlCommand

    Public Shared Function conectar() As String

        Try

            conexion.ConnectionString = "Server=tcp:hads15iu.database.windows.net,1433;Initial Catalog=HADS-15-Tareas;Persist Security Info=False;User ID=opalomo001;Password=Freetanga69;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;"

            conexion.Open()

        Catch ex As Exception

            Return "ERROR DE CONEXIÓN: " + ex.Message

        End Try

        Return "CONEXION OK"

    End Function

    Public Shared Function myrandomize() As Integer

        Dim NumConf As Integer = CLng(Rnd() * 9000000) + 1000000

        Return NumConf

    End Function

    Public Shared Function insertar(ByVal email As String, ByVal nombre As String, ByVal apellido1 As String,
                                    ByVal apellido2 As String, ByVal numconfir As Integer,
                                    ByVal tipo As String, ByVal pass As String) As String


        Dim st = "insert into Usuarios (email,nombre,apellido1,apellido2,numconfir,confirmado,tipo,pass) values (
        
        '" & email & "',
        '" & nombre & "',
        '" & apellido1 & "',
        '" & apellido2 & "',
        '" & numconfir & "',
        '0',
        '" & tipo & "',
        '" & pass & "'
        )"

        Dim numregs As Integer

        comando = New SqlCommand(st, conexion)

        Try

            numregs = comando.ExecuteNonQuery()

        Catch ex As Exception

            Return ex.Message

        End Try

        Return (numregs & "registro(s) insertado(s) en la BD")

    End Function

    Public Shared Function existeUsuario(ByVal email As String) As String

        cerrarconexion()

        conectar()

        Dim st = "select * from Usuarios where email='" & email & "' AND confirmado='" & True & "' "

        comando = New SqlCommand(st, conexion)

        If comando.ExecuteNonQuery() = 0 Then

            Return "-1"

        End If

        Return "1"

    End Function


    Public Shared Function comprobarUsuario(ByVal email As String, ByVal password As String) As String

        cerrarconexion()

        conectar()

        Dim st As String

        st = existeUsuario(email)

        If st = "-1" Then

            Return "-1"

        End If

        st = "select count(*) from Usuarios where email='" & email & "' AND pass='" & password & "' "

        comando = New SqlCommand(st, conexion)

        If comando.ExecuteScalar > 0 Then

            Return "1"

        Else

            Return "0"

        End If

    End Function

    Public Shared Function confirmarUsuario(ByVal email As String, ByVal numconf As String) As String

        Try
            Dim st As String

            Dim numregs As Integer

            cerrarconexion()

            If (conectar() IsNot "CONEXION OK") Then

                Return "Error"

            End If

            st = "UPDATE Usuarios SET confirmado=1 WHERE email='" & email & "' AND numconfir='" & numconf & "' AND confirmado=0 "

            comando = New SqlCommand(st, conexion)

            numregs = comando.ExecuteNonQuery()

            cerrarconexion()

            If numregs = 0 Then

                Return "0"

            Else

                Return "OK"

            End If

        Catch ex As Exception

            Return ex.Message

        End Try

    End Function

    Public Shared Function solicitudCambioPass(ByVal email) As String

        cerrarconexion()

        conectar()

        Dim st As String

        st = existeUsuario(email)

        If st = "-1" Then

            Return "-1"

        End If

        'TO DO :

        'EN CASO DE QUE EXISTA EL MAIL:'
        'GENERAR NUEVO CODIGO'
        'ACTUALIZAR EL CODIGO DEL USUARIO EN LA BD'
        'ENVIAR EMAIL CON EL NUEVO CODIGO'

        cerrarconexion()

        Return "1"

    End Function

    Public Shared Function cambiarPass(ByVal numconfir As String, ByVal email As String, ByVal newpass As String) As String

        Try
            Dim st As String

            cerrarconexion()

            conectar()

            st = "SELECT * FROM USUARIOS WHERE email='" & email & "' and numconfir='" & numconfir & "'"

            comando = New SqlCommand(st, conexion)

            If comando.ExecuteNonQuery = 0 Then

                cerrarconexion()

                Return "-1"

            End If

            st = "UPDATE Usuarios SET pass='" & newpass & "' WHERE email='" & email & "' AND numconfir='" & numconfir & "'"

            comando = New SqlCommand(st, conexion)

            cerrarconexion()

            If comando.ExecuteNonQuery() = 0 Then

                cerrarconexion()

                Return "0"

            Else

                cerrarconexion()

                Return "1"

            End If

        Catch ex As Exception

            Return False

        End Try

    End Function

    Public Shared Sub cerrarconexion()

        conexion.Close()

    End Sub

End Class
