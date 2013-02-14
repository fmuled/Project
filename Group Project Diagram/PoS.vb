' **********************************************************************************************************
' Engineers: 
'   Jamie Leviner -
'   Miguel Espinoza - 
'   Tyler Donaldson - 
'
' Project Begin Date: 1/28/13
' Project End Date:
'
' For information/documentation about the code, or how a function works, please view documentation within
' the READMEs. If there is documentation about a function, a README notice will be in a comment above the 
' function that has the documentation.
' **********************************************************************************************************
' Import Statements:
' 
' **********************************************************************************************************

Public Class PoS
    Dim dataCon As New VehiclesDataContext

    ' Clears dealershipDGV and displays all the vehicles.
    Private Sub clearFilter()
        Dim query = From vehicle In dataCon.Vehicles
                   Select vehicle

        dealershipDGV.DataSource = query.ToList
    End Sub

    Private Sub Form1_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Label138.Text = " "
    End Sub

    Private Sub RadioButton1_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles RadioButton1.CheckedChanged
        If (GroupBox15.Enabled = False) Then
            GroupBox15.Enabled = True
            Label124.Text = "Type of Card"
            Label125.Text = "Credit Card"
            Label126.Text = "Expiration Date"
            Label127.Text = "CVN Number"
            Label128.Text = "Name on Account"
            Label137.Text = "Credit Card"
            Label138.Text = " "
        Else
            GroupBox15.Enabled = False
            Label137.Text = " "
        End If
    End Sub

    Private Sub RadioButton2_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles RadioButton2.CheckedChanged
        If (GroupBox16.Enabled = False) Then
            GroupBox16.Enabled = True
            MaskedTextBox15.Focus()
            Label124.Text = "Account Number"
            Label125.Text = "Routing Number"
            Label126.Text = "Check Number"
            Label127.Text = "Name on Account"
            Label128.Text = " "
            Label137.Text = "Checking Account"
        Else
            GroupBox16.Enabled = False
            Label137.Text = " "
        End If
    End Sub

    Private Sub MaskedTextBox15_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MaskedTextBox15.TextChanged, MaskedTextBox15.Enter
        Label138.Text = MaskedTextBox15.Text
    End Sub

    Private Sub Button3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnLogout.Click
        Login.txtName.Clear()
        Login.txtPass.Clear()
        Login.Show()
        Me.Close()
        Login.Close()
    End Sub

    Private Sub LoadVehiclesToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles LoadVehiclesToolStripMenuItem.Click
        clearFilter()
    End Sub

    Private Sub ToolStripMenuItem1_Click(sender As Object, e As EventArgs) Handles ToolStripMenuItem1.Click
        Dim price As Decimal = 6500.0
        dataCon.spInsertVehicle("Honda", "Accord", "2005", "2-Door", "Red", "KGFJN89853KSGNJNS", "Used", price)

    End Sub


    Private Sub btnFilter_Click(sender As Object, e As EventArgs) Handles btnFilter.Click
        Dim blagh = dealershipDGV.CurrentRow
        If (rbMake.Checked) Then
            dealershipDGV.DataSource = dataCon.spSearchVehicleMake(txtSMake.Text)
        ElseIf (rbModel.Checked) Then
            dealershipDGV.DataSource = dataCon.spSearchVehicleModel(txtSModel.Text)
        ElseIf (rbYear.Checked) Then
            dealershipDGV.DataSource = dataCon.spSearchVehicleYear(txtSYear.Text)
        Else
            clearFilter()
        End If
    End Sub

    Private Sub btnClearFilter_Click(sender As Object, e As EventArgs) Handles btnClearFilter.Click
        clearFilter()
        txtSMake.Clear()
        txtSModel.Clear()
        txtSYear.Clear()
    End Sub

    Private Sub RemoveVehicleToolStripMenuItem1_Click(sender As Object, e As EventArgs) Handles RemoveVehicleToolStripMenuItem1.Click
        Dim ID = dealershipDGV.CurrentCell.Value
        dataCon.spDeleteVehicle(ID.ToString)
        clearFilter()
    End Sub
End Class
