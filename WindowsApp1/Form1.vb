Public Class Form1

    Dim bd As JosephTutos_PedidosEntities
    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        bd = New JosephTutos_PedidosEntities
        Dim clientes = bd.cliente.ToList
        For Each item In clientes
            ListBox1.Items.Add(item.clie_nombre + " " + item.clie_apellidos)
        Next

    End Sub

    Private Sub ListBox1_DoubleClick(sender As Object, e As EventArgs) Handles ListBox1.DoubleClick
        If ListBox1.SelectedIndex > -1 Then
            Dim nombre As String
            nombre = ListBox1.SelectedItem
            ListBox2.Items.Add(nombre)
            ListBox2.Visible = True
            ListBox1.ClearSelected()
        End If
    End Sub

    Private Sub ListBox2_MouseDoubleClick(sender As Object, e As MouseEventArgs) Handles ListBox2.MouseDoubleClick
        If ListBox2.SelectedIndex > -1 Then
            ListBox2.Items.RemoveAt(ListBox2.SelectedIndex)
        End If

        If ListBox2.Items.Count <= 0 Then
            ListBox2.Visible = False
        End If
        ListBox2.ClearSelected()
    End Sub
    Dim clientes As New List(Of cliente)
    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        clientes = New List(Of cliente)
        Dim cli As New cliente
        If ListBox2.Items.Count > 0 Then
            For index = 0 To ListBox2.Items.Count - 1
                cli = New cliente
                cli.clie_nombre = ListBox2.Items(index)
                cli.clie_id = index + 1
                clientes.Add(cli)
            Next
        Else
            For index = 0 To ListBox1.Items.Count - 1
                cli = New cliente
                cli.clie_nombre = ListBox1.Items(index)
                cli.clie_id = index + 1
                clientes.Add(cli)
            Next
        End If


        Dim cry = New CrystalReport1
        Me.CrystalReportViewer1.ReportSource = cry
        cry.SetDataSource(clientes)
        Me.CrystalReportViewer1.RefreshReport()
        clientes = Nothing
    End Sub
End Class
