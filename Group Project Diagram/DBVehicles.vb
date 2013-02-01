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
' ****************************************************************

Public Class DBVehicles
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
    Public Sub addVehicles()

    End Sub

    ' This function allows the user to remove a vehicle from
    ' the database when it has been sold.
    Public Sub deleteVehicles()

    End Sub

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
