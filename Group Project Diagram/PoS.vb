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
' Imports System.Windows.Forms.BindingContext 'This was used in an effort to use the database using SQL instead of LINQ.
' **********************************************************************************************************

Public Class PoS
    Private Sub Form1_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Label138.Text = " "
        Me.VehicleTA.Fill(Me.VehiclesDataSet.Vehicle)
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
        VehicleBindingSource.EndEdit()
        VehicleTA.Update(VehiclesDataSet.Vehicle)
        Me.Close()
        Login.Close()
    End Sub

    'Updates the DGV
    Private Sub LoadVehiclesToolStripMenuItem_Click(ByVal sender As Object, ByVal e As EventArgs) Handles LoadVehiclesToolStripMenuItem.Click
        Dim dbVehicles As New DBVehicles
        dbVehicles.loadVehicles()
    End Sub

    ' This function allows the user to filter through the database according to one of the three choices
    ' on the side of the dealership vehicles tab: make, model, or year. The user must have a radiobutton
    ' selected to be able to filter through the results.
    Private Sub btnFilter_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnFilter.Click
        Dim dbVehicles As New DBVehicles
        If Not (rbMake.Checked Or rbModel.Checked Or rbYear.Checked) Then
            MessageBox.Show("You must select a search criteria.")
        ElseIf rbMake.Checked Then
            dbVehicles.filterVehicle_make(cbMake.Text)
        ElseIf rbModel.Checked Then
            dbVehicles.filterVehicle_model(cbModel.Text)
        ElseIf rbYear.Checked Then
            dbVehicles.filterVehicle_year(Convert.ToInt32(cbYear.Text))
        End If
    End Sub

    ' This button clears the filter that has been attached to the Dealership Vehicles DGV
    Private Sub btnClearFilter_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnClearFilter.Click
        Dim dbVehicles As New DBVehicles
        dbVehicles.loadVehicles()
    End Sub
End Class
