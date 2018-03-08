
Imports AccesoDatosSQL.accesodatosSQL

Public Class Login
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

    End Sub

    Protected Sub submit_Click(sender As Object, e As EventArgs) Handles submit.Click

        Dim log As String

        log = comprobarUsuario(txtMail.Text, txtPass.Text)

        If log = "-1" Then

            lblAns.Text = "Ese email no se encuentra registrado"

        End If

        If log = "1" Then

            Session("user") = txtMail.Text

            Response.Redirect("Inicio.aspx")

        End If

        If log = "0" Then

            lblAns.Text = "Contraseña errónea"

        End If

    End Sub

End Class