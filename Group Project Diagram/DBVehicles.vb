' ****************************************************************
' Created by Tyler Donaldson
' January 28, 2013
'
' This class is the management class for the Vehicles
' Database. It will be capable of adding, loading, 
' and deleting contents of the database.
' ****************************************************************
' Updates To The Application:
'   1/29/2013 - Created the class and loadVehicles function
'   1/30/2013 - Created the filter functions.
'   1/31/2013 - Able to add vehicles to the database.
' ****************************************************************

Public Class DBVehicles

    Private adapter As New  _
        VehiclesDataSetTableAdapters.VehicleTableAdapter
    Public Shared Property LastError As String

    ' Finished 1/29/2013
    ' This function allows the user to update 
    ' the view of the vehicles in the system
    ' whenever they want to.
    Public Sub loadVehicles()
        Dim query = From vehicle In PoS.VehiclesDataSet.Vehicle
            Let id = vehicle.ID
            Let make = vehicle.make
            Let model = vehicle.model
            Let vehicleYear = vehicle.vehicleYear
            Let bodyStyle = vehicle.bodyStyle
            Let color = vehicle.color
            Let vinNumber = vehicle.vinNumber
            Let condition = vehicle.condition
            Where vehicle.For_Sale = "Yes"
            Select id, make, model, vehicleYear, bodyStyle, _
                   color, vinNumber, condition

        PoS.dealershipDGV.DataSource = query.ToList
    End Sub

    ' This function allows the user to add new vehicles to
    ' the database when a new inventory comes in.
    Public Sub addVehicles(ByVal make As String, ByVal model As String, _
                           ByVal vehicleYear As String, ByVal bodyStyle As String, _
                           ByVal color As String, ByVal vinNumber As String, _
                           ByVal condition As String, ByVal Equipment As String, _
                           ByVal For_Sale As String)

        Try
            LastError = String.Empty
            adapter.Insert(make, model, vehicleYear, bodyStyle, color, _
                           vinNumber, condition, Equipment, For_Sale)
        Catch ex As Exception
            LastError = ex.Message
        End Try

    End Sub

    '
    Function GetByVIN(ByVal vin As String) As DataTable
        Dim table As VehiclesDataSet.VehicleDataTable
        table = adapter.GetData()
        Return table
    End Function

    ' This function allows the user to remove a vehicle from
    ' the database when it has been sold.
    'Public Sub deleteVehicles(ByVal vin As String)
    'Dim table As VehiclesDataSet.VehicleDataTable = adapter.GetData()
    'Dim row As VehiclesDataSet.VehicleRow = table.SearchVIN_NUM(vin) ' Not going to work yet because of SQL query
    'Dim rowAffected As Integer = adapter.Delete(row.ID, row.make, row.model, row.vehicleYear, row.bodyStyle, row.color, row.vinNumber, _
    '                            row.condition, row.Equipment, row.For_Sale)
    'End Sub

    ' This function allows the user to filter the vehicles by
    ' the make of the vehicle
    ' Finished 1/30/2013
    Public Sub filterVehicle_make(ByVal filter As String)
        Dim query = From vehicle In PoS.VehiclesDataSet.Vehicle
            Let id = vehicle.ID
            Let make = vehicle.make
            Let model = vehicle.model
            Let vehicleYear = vehicle.vehicleYear
            Let bodyStyle = vehicle.bodyStyle
            Let color = vehicle.color
            Let vinNumber = vehicle.vinNumber
            Let condition = vehicle.condition
            Where vehicle.For_Sale = "Yes" And make = filter
            Select id, make, model, vehicleYear, bodyStyle, _
                   color, vinNumber, condition

        PoS.dealershipDGV.DataSource = query.ToList
    End Sub

    ' This function allows the user to filter the vehicles by
    ' the model of the vehicle
    ' Finished 1/30/2013
    Public Sub filterVehicle_model(ByVal filter As String)
        Dim query = From vehicle In PoS.VehiclesDataSet.Vehicle
            Let id = vehicle.ID
            Let make = vehicle.make
            Let model = vehicle.model
            Let vehicleYear = vehicle.vehicleYear
            Let bodyStyle = vehicle.bodyStyle
            Let color = vehicle.color
            Let vinNumber = vehicle.vinNumber
            Let condition = vehicle.condition
            Where vehicle.For_Sale = "Yes" And model = filter
            Select id, make, model, vehicleYear, bodyStyle, _
                   color, vinNumber, condition

        PoS.dealershipDGV.DataSource = query.ToList
    End Sub

    ' This function allows the user to filter the vehicles by
    ' the year of the vehicle
    ' Finished 1/30/2013
    Public Sub filterVehicle_year(ByVal filter As Int32)
        Dim query = From vehicle In PoS.VehiclesDataSet.Vehicle
            Let id = vehicle.ID
            Let make = vehicle.make
            Let model = vehicle.model
            Let vehicleYear = vehicle.vehicleYear
            Let bodyStyle = vehicle.bodyStyle
            Let color = vehicle.color
            Let vinNumber = vehicle.vinNumber
            Let condition = vehicle.condition
            Where vehicle.For_Sale = "Yes" And vehicleYear = filter
            Select id, make, model, vehicleYear, bodyStyle, _
                   color, vinNumber, condition

        PoS.dealershipDGV.DataSource = query.ToList
    End Sub
End Class
