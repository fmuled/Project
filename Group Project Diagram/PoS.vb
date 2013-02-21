' **********************************************************************************************************
' Engineers: 
'   Jamie Leviner
'   Miguel Espinoza 
'   Tyler Donaldson
'
' Project Begin Date: 1/28/13
' Project End Date:
' **********************************************************************************************************
' Import Statements:
' 
' **********************************************************************************************************

Public Class PoS
    Dim dataCon As New VehiclesDataContext

    ' **************************************************************************************************************************************
    ' UNIVERSAL FUNCTIONS GO IN HERE!
    ' **************************************************************************************************************************************
    ' Clears dealershipDGV and displays all the vehicles.
    Public Sub clearFilter(ByRef dgv As DataGridView)
        Dim query = From vehicle In dataCon.Vehicles
                   Select vehicle

        dgv.DataSource = query.ToList
    End Sub
    ' **************************************************************************************************************************************
    ' UNIVERSAL FUNCTIONS GO ABOVE HERE!
    ' **************************************************************************************************************************************





    ' **************************************************************************************************************************************
    ' MISC FORM MANIPULATION FUNCTIONS GO IN HERE!
    ' **************************************************************************************************************************************
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
    ' **************************************************************************************************************************************
    ' MISC FORM MANIPULATION FUNCTIONS GO ABOVE HERE!
    ' **************************************************************************************************************************************





    ' **************************************************************************************************************************************
    ' DEALERSHIP VEHICLES TAB FUNCTIONS GO IN HERE!
    ' **************************************************************************************************************************************
    ' Load the vehicles into the dealershipDGV 
    Private Sub LoadVehiclesToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles LoadVehiclesToolStripMenuItem.Click
        clearFilter(dealershipDGV)
        clearFilter(networkDGV)
    End Sub

    ' Add a vehicle from the Dealership Vehicles Tab
    Private Sub ToolStripMenuItem1_Click(sender As Object, e As EventArgs) Handles ToolStripMenuItem1.Click
        AddVehicle.Show()
        clearFilter(dealershipDGV)
        clearFilter(networkDGV)
    End Sub

    ' Filter the vehicles in the DGV in the Dealership Vehicles Tab
    Private Sub btnFilter_Click(sender As Object, e As EventArgs) Handles btnFilter.Click
        If (rbMake.Checked) Then
            dealershipDGV.DataSource = dataCon.spSearchVehicleMake(txtSMake.Text)
        ElseIf (rbModel.Checked) Then
            dealershipDGV.DataSource = dataCon.spSearchVehicleModel(txtSModel.Text)
        ElseIf (rbYear.Checked) Then
            dealershipDGV.DataSource = dataCon.spSearchVehicleYear(txtSYear.Text)
        Else
            clearFilter(dealershipDGV)
        End If
    End Sub

    ' Clear the filters from the DGV in the Dealership VEhicles Tab
    Private Sub btnClearFilter_Click(sender As Object, e As EventArgs) Handles btnClearFilter.Click
        clearFilter(dealershipDGV)
        txtSMake.Clear()
        txtSModel.Clear()
        txtSYear.Clear()
    End Sub

    ' Remove a vehicle from the DGV in the Dealership Vehicles Tab
    Private Sub RemoveVehicleToolStripMenuItem2_Click(sender As Object, e As EventArgs) Handles RemoveVehicleToolStripMenuItem2.Click
        Dim ID = dealershipDGV.CurrentCell.Value
        dataCon.spDeleteVehicle(ID.ToString)
        clearFilter(dealershipDGV)
        clearFilter(networkDGV)
        txtSMake.Text = ""
        txtSModel.Text = ""
        txtSYear.Text = ""
    End Sub
    ' **************************************************************************************************************************************
    ' DEALERSHIP VEHICLES TAB FUNCTIONS GO ABOVE HERE!
    ' **************************************************************************************************************************************





    ' **************************************************************************************************************************************
    ' NETWORK VEHICLES TAB FUNCTIONS GO IN HERE!
    ' **************************************************************************************************************************************
    ' Remove a Vehicle from the DGV in the Network Vehicle Tab
    Private Sub RemovingFromLotToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles RemovingFromLotToolStripMenuItem.Click
        Dim ID = networkDGV.CurrentCell.Value
        dataCon.spDeleteVehicle(ID.ToString)
        clearFilter(networkDGV)
        clearFilter(dealershipDGV)
    End Sub

    ' Load the vehicles into the DGV on the Network Tab
    Private Sub LoadVehiclesToolStripMenuItem1_Click(sender As Object, e As EventArgs) Handles LoadVehiclesToolStripMenuItem1.Click
        clearFilter(networkDGV)
        clearFilter(dealershipDGV)
    End Sub

    ' Add a vehicle into the Network Vehicle Tab
    Private Sub AddVehicleToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles AddVehicleToolStripMenuItem.Click
        AddVehicle.Show()
        clearFilter(networkDGV)
        clearFilter(dealershipDGV)
    End Sub

    ' Filter the vehicles on the tab
    Private Sub txtNFilter_Click(sender As Object, e As EventArgs) Handles txtNFilter.Click
        If (rbNMake.Checked) Then
            networkDGV.DataSource = dataCon.spSearchVehicleMake(txtNMake.Text)
        ElseIf (rbNModel.Checked) Then
            networkDGV.DataSource = dataCon.spSearchVehicleModel(txtNModel.Text)
        ElseIf (rbNYear.Checked) Then
            networkDGV.DataSource = dataCon.spSearchVehicleYear(txtNYear.Text)
        Else
            clearFilter(networkDGV)
        End If
    End Sub

    ' Clear the filters from the DGV
    Private Sub txtNClear_Click(sender As Object, e As EventArgs) Handles txtNClear.Click
        clearFilter(networkDGV)
        txtNMake.Text = ""
        txtNModel.Text = ""
        txtNYear.Text = ""
    End Sub
    ' **************************************************************************************************************************************
    ' NETWORK VEHICLES TAB FUNCTIONS GO ABOVE HERE!
    ' **************************************************************************************************************************************






    ' **************************************************************************************************************************************
    ' CUSTOMER HISTORY TAB FUNCTIONS GO IN HERE!
    ' **************************************************************************************************************************************
    ' Load Customer info into the DGV on the Customer History Tab
    Private Sub LoadCustomersToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles LoadCustomersToolStripMenuItem.Click
        customerDGV.DataSource = dataCon.spGetCustomerInfo()
    End Sub
    ' **************************************************************************************************************************************
    ' CUSTOMER HISTORY TAB FUNCTIONS GO ABOVE HERE!
    ' **************************************************************************************************************************************






    ' **************************************************************************************************************************************
    ' CUSTOMER INFORMATION TAB FUNCTIONS GO IN HERE!
    ' **************************************************************************************************************************************
    ' Link from the Customer Information Tab to the Customer History Tab
    Private Sub SearchForCustomerToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles SearchForCustomerToolStripMenuItem.Click
        TabControl1.SelectTab(3)
    End Sub
    ' **************************************************************************************************************************************
    ' CUSTOMER INFORMATION TAB FUNCTIONS GO ABOVE HERE!
    ' **************************************************************************************************************************************
End Class
