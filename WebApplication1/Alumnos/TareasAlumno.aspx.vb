Imports System.Data.SqlClient

Public Class TareasAlumno
    Inherits System.Web.UI.Page

    Dim conexion As SqlConnection = New SqlConnection("") ' añadir el conection string de otras clases

    Dim adapAsg As New SqlDataAdapter()

    Dim dtsAsg As New DataSet

    Dim dtblAsg As New DataTable

    Dim drowAsg As DataRow

    '------------------------------------'

    Dim adapTareas As New SqlDataAdapter()

    Dim dtsTareas As New DataSet

    Dim dtblTareas As New DataTable

    Dim rowTareas As DataRow

    Dim dvTareas As DataView

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

    End Sub

    Protected Sub DropDownList1_SelectedIndexChanged(sender As Object, e As EventArgs) Handles DropDownList1.SelectedIndexChanged

        dtblTareas.Rows.Clear()

        adapTareas = New SqlDataAdapter("SELECT TareasGenericas.Codigo,TareasGenericas.Descripcion,TareasGenericas.HEstimadas,
                                         TareasGenericas.TipoTarea FROM TareasGenericas 
                                         WHERE TareasGenericas.CodAsig='" & DropDownList1.SelectedValue & "' 
                                         AND TareasGenericas.Explotacion='True' 
                                         AND TareasGenericas.Codigo NOT IN 
                                         (SELECT EstudiantesTareas.CodTarea FROM EstudiantesTareas INNER JOIN TareasGenericas 
                                         ON EstudiantesTareas.CodTarea = TareasGenericas.Codigo 
                                         WHERE EstudiantesTareas.Email='" & Session("UserID") & "' 
                                         AND TareasGenericas.CodAsig='" & DropDownList1.SelectedValue & "')", conexion)

        Dim bldTareas As New SqlCommandBuilder(adapTareas)

        dtsTareas.Clear()

        adapTareas.Fill(dtsTareas, "Tareas")

        dtblTareas = dtsTareas.Tables("Tareas")

        dvTareas = dtsTareas.Tables(0).DefaultView

        GridViewTareas.DataSource = dvTareas

        GridViewTareas.DataBind()

        Session("AdapterTareas") = adapTareas

    End Sub


End Class