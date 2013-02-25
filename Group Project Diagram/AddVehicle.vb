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
    'Data Members
    Private datacon As New VehiclesDataContext
    Private priceAdded As Boolean = False
    Private added As Boolean = False

    'Defines the vehicle class
    Public Class Vehicle
        Public make As String
        Public model As String
        Public year As String
        Public style As String
        Public color As String
        Public vin As String
        Public type As String
        Public price As Double
    End Class

    ' Add a vehicle to the database.
    Private Sub btnAddVehicle_Click(sender As Object, e As EventArgs) Handles btnAddVehicle.Click
        Dim add As New Vehicle

        add.make = txtMake.Text
        add.model = txtModel.Text
        add.year = txtYear.Text
        add.style = txtStyle.Text
        add.color = txtColor.Text
        add.vin = txtVIN.Text
        add.type = cbType.SelectedItem

        ' Check to see if the price box has correct type of values.
        If (txtPrice.Text = "" Or Not (IsNumeric(txtPrice.Text))) Then
            MessageBox.Show("Please enter a valid price")
        Else
            add.price = CDbl(txtPrice.Text)
            priceAdded = True
        End If

        ' Tell the user there is some error in input
        If (add.make = Nothing Or add.model = Nothing Or
            add.year = Nothing Or add.year = Nothing Or
            add.style = Nothing Or add.color = Nothing Or
            add.vin = Nothing Or add.year = Nothing) Then
            MessageBox.Show("Please fill the empty textboxes with values.")
        ElseIf (priceAdded) Then ' Add the vehicle to the database unless there is an incorrect price
            datacon.spInsertVehicle(add.make, add.model, add.year, add.style, _
                                    add.color, add.vin, add.type, add.price)
            added = True
        End If

        If added Then ' Update the dgvs and close the add vehicle form.
            PoS.clearNetworkFilter(PoS.networkDGV)
            PoS.clearDealershipFilter(PoS.dealershipDGV)
            Me.Close()
        End If
    End Sub
End Class