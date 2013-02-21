' **********************************************************************************************************
' Engineers: 
'   Jamie Leviner
'   Miguel Espinoza 
'   Tyler Donaldson
'
' Handles the Addition of New Vehicles to the Database
' 2/15/2012
' **********************************************************************************************************
Public Class AddVehicle
    Dim datacon As New VehiclesDataContext

    ' Structure to make the adding of the vehicle information into the SQL procedure
    ' neater and more understandable.
    Public Structure Vehicle
        Dim make As String
        Dim model As String
        Dim year As String
        Dim style As String
        Dim color As String
        Dim vin As String
        Dim type As String
        Dim price As Double
    End Structure

    ' Add a vehicle to the database.
    Private Sub btnAddVehicle_Click(sender As Object, e As EventArgs) Handles btnAddVehicle.Click
        Dim add As New Vehicle
        Dim added As Boolean = False
        add.make = txtMake.Text
        add.model = txtModel.Text
        add.year = txtYear.Text
        add.style = txtStyle.Text
        add.color = txtColor.Text
        add.vin = txtVIN.Text
        add.type = cbType.SelectedItem
        If txtPrice.Text = "" Then
            MessageBox.Show("Price field is empty. Please enter a monetary value.")
        Else
            add.price = CDbl(txtPrice.Text)
        End If

        If (add.make = Nothing Or add.model = Nothing Or
            add.year = Nothing Or add.year = Nothing Or
            add.style = Nothing Or add.color = Nothing Or
            add.vin = Nothing Or add.year = Nothing) Then
            MessageBox.Show("Please fill the empty textboxes with values.")
        Else
            datacon.spInsertVehicle(add.make, add.model, add.year, add.style, _
                                    add.color, add.vin, add.type, add.price)
            added = True
        End If

        If added Then
            PoS.clearFilter(PoS.networkDGV)
            PoS.clearFilter(PoS.dealershipDGV)
            Me.Close()
        End If
    End Sub
End Class