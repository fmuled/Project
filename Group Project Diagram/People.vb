' **********************************************************************************************************
' Engineers: 
'   Jamie Leviner
'   Miguel Espinoza 
'   Tyler Donaldson
'
' Project Begin Date: 1/28/13
' Project End Date:
' **********************************************************************************************************
' This file contains the declaration of all the classes that need to be used to help store information
' in the database
' **********************************************************************************************************
Public Class People
    Public fName As String
    Public lName As String
    Public street As String
    Public city As String
    Public state As String
    Public zipCode As String
    Public hPhone As String
    Public cPhone As String
End Class

' Employee class, inherits Person
Public Class Employee
    Inherits People

    Public vehiclesSold As Integer
    Public isManager As Char
End Class

' Customer Class, inherits Person
Public Class Customer
    Inherits People

    Public paymentType As String
    Public licenseNum As String
    Public licenseExp As String
End Class
