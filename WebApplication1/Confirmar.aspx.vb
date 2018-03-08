
Imports AccesoDatosSQL.accesodatosSQL

Public Class ConfirmAccount
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load


    End Sub

    Protected Sub submit_Click(sender As Object, e As EventArgs) Handles submit.Click

        Dim res As String

        res = confirmarUsuario(txtMail.Text, txtCod.Text)

        If res = "OK" Then

            Label1.Text = "CUenta confirmada con exito"

            Response.Redirect("Login.aspx")

        End If

        If res = "Error" Then

            Label1.Text = "Ha saltado una error"

        End If

        If res = "0" Then

            Label1.Text = "No hay coincidencias"

        Else

            Label1.Text = res

        End If


    End Sub

End Class