' **********************************************************************************************************
' Engineers: 
'   Jamie Leviner
'   Miguel Espinoza 
'   Tyler Donaldson
'
' Handles the Addition of New Employees to the Database
' 2/26/2012
' **********************************************************************************************************
Public Class frmAddSalesperson
    Private datacon As New VehiclesDataContext

    Private Sub btnAddSalesperson_Click(sender As Object, e As EventArgs) Handles btnAddSalesperson.Click
        Dim person As New Employee
        Dim added As Boolean = False

        ' Check to make sure all the information is input into the text boxes
        If (txtASPfName.Text = vbNullString Or txtASPlName.Text = vbNullString Or _
            txtASPStreet.Text = vbNullString Or txtASPCity.Text = vbNullString Or _
            cbASPState.SelectedItem = vbNullString Or mtbASPZipCode.Text = vbNullString Or _
            mtbASPHPhone.Text = vbNullString Or mtbASPCPhone.Text = vbNullString Or _
            txtASPNumSold.Text = vbNullString) Then

            MessageBox.Show("Please fill in all boxes.")
        Else
            person.fName = txtASPfName.Text
            person.lName = txtASPlName.Text
            person.street = txtASPStreet.Text
            person.city = txtASPCity.Text
            person.state = cbASPState.SelectedItem
            person.zipCode = mtbASPZipCode.Text
            person.hPhone = mtbASPHPhone.Text
            person.cPhone = mtbASPCPhone.Text
            person.vehiclesSold = txtASPNumSold.Text
            If cbManager.Checked Then
                person.isManager = "Y"
            Else
                person.isManager = "N"
            End If

            datacon.spInsertEmployee(person.fName, person.lName, person.street, person.city, _
                                     person.state, person.zipCode, person.hPhone, person.cPhone, _
                                     CInt(person.vehiclesSold), person.isManager)

            added = True
        End If

        If added Then
            PoS.employeeDGV.DataSource = datacon.spGetEmployeeInfo()
            Me.Close()
        End If
    End Sub
End Class