
Imports AccesoDatosSQL.accesodatosSQL

Public Class PassChange2
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

    End Sub

    Protected Sub submit_Click(sender As Object, e As EventArgs) Handles submit.Click

        Dim res As String

        res = cambiarPass(txtCod.Text, Session("passRequestMail"), txtPass.Text)

        If res IsNot "1" Then

            ans.Text = "Revisa el código introducido"

        End If

        Session("passRequestMail") = " " 'Se vacia para evitar posibles errores'

        Response.Redirect("Inicio.aspx")

    End Sub

End Class