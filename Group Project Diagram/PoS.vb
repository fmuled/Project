' **********************************************************************************************************
' Engineers: 
'   Jamie Leviner
'   Miguel Espinoza 
'   Tyler Donaldson
'
' Project Begin Date: 1/28/13
' Project End Date:
' **********************************************************************************************************s
' Things Left To Do
'   Implement Accounting Queries (Add/Remove/Edit)
'   Selling of a vehicle - Only have to save the sales information to the database left for this.
'   Trade-in - Insert into the sales database that a certain amount was given to a customer
' **********************************************************************************************************

Public Class PoS
    Private dataCon As New VehiclesDataContext
    Public tradeInValue As Integer = 0 ' This value is used to get the value of a vehicle if the customer is trading in a car
    Public vehicleType As String = "New" ' Variable used for validation purposes
    Private cust As Customer
    Private tradeIn As Boolean = False
    Private carWashSpecial As String = " "

    ' **************************************************************************************************************************************
    ' UNIVERSAL FUNCTIONS GO IN HERE!
    ' **************************************************************************************************************************************
    ' Clears dealershipDGV and displays all the vehicles.
    Public Sub clearDealershipFilter(ByRef dgv As DataGridView)
        Dim query = From vehicle In dataCon.Vehicles
                   Select vehicle

        dgv.DataSource = query.ToList
    End Sub

    ' Clears the filter on the networkDGV and displays the new vehicles
    Public Sub clearNetworkFilter(ByRef dgv As DataGridView)
        Dim query = From vehicle In dataCon.Vehicles
                    Select vehicle
                    Where vehicle.condition = "New"

        dgv.DataSource = query.ToList
    End Sub

    ' Clear all the boxes in the Customer Information tab
    Public Sub clearCustomerInfo()
        txtCIfName.Clear()
        txtCIlName.Clear()
        txtCIMName.Clear()
        txtCIStreet.Clear()
        txtCICity.Clear()
        mtbZipCode.Clear()
        mtbHPhone.Clear()
        mtbCPhone.Clear()
        mtbWPhone.Clear()
        mtbDriversLicNum.Clear()
        txtCIDLExp.Clear()
        mtbCreditCardNum.Clear()
        mtbCCExpDate.Clear()
        mtbCVN.Clear()
        txtCICardName.Clear()
        txtCIAccName.Clear()
        txtCICheckNum.Clear()
        mtbRoutingNumber.Clear()
        mtbAccountNumber.Clear()
        rbCheckAcc.Checked = False
        rbCredit.Checked = False
        cbState.SelectedText = " "
    End Sub

    ' Inserts information into the Credit Card database
    Sub insertCreditCard()
        If (mtbCreditCardNum.Text = vbNullString Or cbCICCType.Text = vbNullString Or _
            mtbCCExpDate.Text = vbNullString Or mtbCVN.Text = vbNullString Or _
            txtCICardName.Text = vbNullString) Then
        Else
            dataCon.spInsertCreditCardInfo(mtbCreditCardNum.Text, mtbCCExpDate.Text, _
                                           mtbCVN.Text, txtCICardName.Text, cbCICCType.Text)
        End If
    End Sub

    ' Inserts information into the Checking Account database
    Sub insertCheckingAccount()
        If (mtbAccountNumber.Text = vbNullString Or mtbRoutingNumber.Text = vbNullString Or _
            txtCIAccName.Text = vbNullString Or txtCICheckNum.Text = vbNullString) Then
        Else
            dataCon.spInsertCheckingAccountInfo(txtCIAccName.Text, mtbAccountNumber.Text, _
                                                mtbRoutingNumber.Text, txtCICheckNum.Text)
        End If
    End Sub

    ' Actually conducts the sale of the vehicle
    Private Sub sellVehicle(ByRef dgv As DataGridView)
        Dim amount As Double = -1.0

        ' Special prompt if the customer received a the car wash special
        Do While carWashSpecial = " "
            carWashSpecial = CStr(InputBox("Please enter Y or N of whether the customer receives a car wash special:", _
                                   "Car Wash Special?", "N")).ToUpper
        Loop

        ' Prompt the salesperson for how much the vehicle is being sold for.
        Do While (amount <= -1.0 And IsNumeric(amount))
            amount = CInt(InputBox("Please enter the amount the vehicle is being sold:", _
                                       "Vehicle Price", "0"))
        Loop

        ' Remove the vehicle from the vehicle database.
        removeVehicle(dgv)

        ' Enter the information about the customer who is purchasing the vehicle
        TabControl1.SelectTab(0)

        ' Salesperson clicks enter, saves that information to the sales database
        ' THIS IS THE ONLY THING LEFT

        loadSales()
        ' Go home.
    End Sub

    ' Removes a vehicle from the Vehicle database. 
    Private Sub removeVehicle(ByRef dgv As DataGridView)
        Dim ID = dgv.CurrentCell.Value
        dataCon.spDeleteVehicle(ID.ToString)
        clearNetworkFilter(networkDGV)
        clearDealershipFilter(dealershipDGV)
    End Sub

    ' Load all the sales information for the dealership
    Private Sub loadSales()
        ' Individual Sales Tab
        dgvIndSales.DataSource = dataCon.spSelectPersonalSales

        ' Daily Sales Tab
        dgvDailySales.DataSource = dataCon.spSelectDailySales

        ' Monthly Sales Tab
        dgvMonthlySales.DataSource = dataCon.spSelectMonthlySales

        ' All Sales Tab
        dgvAllSales.DataSource = dataCon.spGetAllSalesInfo
    End Sub
    ' **************************************************************************************************************************************
    ' UNIVERSAL FUNCTIONS GO ABOVE HERE!
    ' **************************************************************************************************************************************





    ' **************************************************************************************************************************************
    ' MISC FORM MANIPULATION FUNCTIONS GO IN HERE!
    ' **************************************************************************************************************************************

    ' Allows only the Credit Card info to be available Customer Information Tab
    Private Sub RadioButton1_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles rbCredit.CheckedChanged
        If (GroupBox15.Enabled = False) Then
            GroupBox15.Enabled = True
        Else
            GroupBox15.Enabled = False
        End If
    End Sub

    ' Allowsonly the Checking Account info to be available, Customer Information Tab
    Private Sub RadioButton2_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles rbCheckAcc.CheckedChanged
        If (GroupBox16.Enabled = False) Then
            GroupBox16.Enabled = True
            mtbAccountNumber.Focus()
        Else
            GroupBox16.Enabled = False
        End If
    End Sub

    ' Log in manipulation
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
        clearDealershipFilter(dealershipDGV)
        clearNetworkFilter(networkDGV)
    End Sub

    ' Add a vehicle from the Dealership Vehicles Tab
    Private Sub ToolStripMenuItem1_Click(sender As Object, e As EventArgs) Handles ToolStripMenuItem1.Click
        AddVehicle.Show()
        clearDealershipFilter(dealershipDGV)
        clearNetworkFilter(networkDGV)
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
            clearDealershipFilter(dealershipDGV)
        End If
    End Sub

    ' Clear the filters from the DGV in the Dealership VEhicles Tab
    Private Sub btnClearFilter_Click(sender As Object, e As EventArgs) Handles btnClearFilter.Click
        clearDealershipFilter(dealershipDGV)
        txtSMake.Clear()
        txtSModel.Clear()
        txtSYear.Clear()
    End Sub

    ' Remove a vehicle from the DGV in the Dealership Vehicles Tab
    Private Sub RemoveVehicleToolStripMenuItem2_Click(sender As Object, e As EventArgs) Handles RemoveVehicleToolStripMenuItem2.Click
        removeVehicle(dealershipDGV)
        txtSMake.Clear()
        txtSModel.Clear()
        txtSYear.Clear()
    End Sub

    ' This function allows the salesperson to actually conduct a sale, whether it be selling a new or used vehicle.
    Private Sub SellVehicleToolStripMenuItem1_Click(sender As Object, e As EventArgs) Handles SellVehicleToolStripMenuItem1.Click
        sellVehicle(dealershipDGV)
    End Sub
    ' **************************************************************************************************************************************
    ' DEALERSHIP VEHICLES TAB FUNCTIONS GO ABOVE HERE!
    ' **************************************************************************************************************************************





    ' **************************************************************************************************************************************
    ' NETWORK VEHICLES TAB FUNCTIONS GO IN HERE!
    ' **************************************************************************************************************************************

    ' Remove a Vehicle from the DGV in the Network Vehicle Tab
    Private Sub RemovingFromLotToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles RemovingFromLotToolStripMenuItem.Click
        removeVehicle(networkDGV)
        txtNMake.Clear()
        txtNModel.Clear()
        txtNYear.Clear()
    End Sub

    ' Load the vehicles into the DGV on the Network Tab
    Private Sub LoadVehiclesToolStripMenuItem1_Click(sender As Object, e As EventArgs) Handles LoadVehiclesToolStripMenuItem1.Click
        clearNetworkFilter(networkDGV)
        clearDealershipFilter(dealershipDGV)
    End Sub

    ' Add a vehicle into the Network Vehicle Tab
    Private Sub AddVehicleToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles AddVehicleToolStripMenuItem.Click
        AddVehicle.Show()

        ' Check to see if the vehicle was a tradein. 
        'If it was given control to the customer information tab.
        If vehicleType = "Used/Trade-in" Then
            tradeIn = True
            TabControl1.SelectTab(0)
        End If

        clearNetworkFilter(networkDGV)
        clearDealershipFilter(dealershipDGV)
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
            clearNetworkFilter(networkDGV)
        End If
    End Sub

    ' Clear the filters from the DGV
    Private Sub txtNClear_Click(sender As Object, e As EventArgs) Handles txtNClear.Click
        clearNetworkFilter(networkDGV)
        txtNMake.Clear()
        txtNModel.Clear()
        txtNYear.Clear()
    End Sub


    ' Conducts the sale of a vehicle.
    Private Sub RemoveVehicleToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles RemoveVehicleToolStripMenuItem.Click
        sellVehicle(networkDGV)
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

    ' Remove a customer from the database
    Private Sub RemoveCustomerToolStripMethod_Click(sender As Object, e As EventArgs) Handles RemoveCustomerToolStripMethod.Click
        Dim ID = customerDGV.CurrentCell.Value
        dataCon.spRemoveCustomer(ID.ToString)
        customerDGV.DataSource = dataCon.spGetCustomerInfo()
    End Sub

    ' Search for a customer
    Private Sub btnCustSearch_Click(sender As Object, e As EventArgs) Handles btnCustSearch.Click
        If TextBox24.Text = "" Then
            'Do Nothing
        Else
            Dim query = From cust In dataCon.CustomerInfos
                    Let ID = cust.customerID
                    Let FirstName = cust.fName
                    Let LastName = cust.lName
                    Let Address = cust.street + " " + cust.city + ", " + cust.state + " " + cust.zipcode
                    Let HomePhone = cust.hPhone
                    Let CellPhone = cust.cPhone
                    Let PaymentType = cust.paymentType
                    Select ID, FirstName, LastName, Address, HomePhone, CellPhone, PaymentType
                    Where FirstName.ToLower = TextBox24.Text.ToLower

            customerDGV.DataSource = query.ToList
        End If
    End Sub

    ' Clear the filter of the search
    Private Sub ClearSeachToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ClearSeachToolStripMenuItem.Click
        customerDGV.DataSource = dataCon.spGetCustomerInfo
        TextBox24.Clear()
    End Sub

    ' Gives focus to the Customer Information tab to enter a new customer.
    ' This occurs when the toolbox strip button for adding customer is clicked
    Private Sub AddCustomerToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles AddCustomerToolStripMenuItem.Click
        TabControl1.SelectTab(0)
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

    ' Insert a customer into the database
    Private Sub SaveCustomerInformationToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles SaveCustomerInformationToolStripMenuItem.Click
        cust = New Customer
        Dim added As Boolean = False
        Dim credit As Boolean = False
        Dim checking As Boolean = False

        ' Check to make sure all the information is input into the text boxes
        If (txtCIfName.Text = vbNullString Or txtCIlName.Text = vbNullString Or _
            txtCIStreet.Text = vbNullString Or txtCICity.Text = vbNullString Or _
            cbState.SelectedItem = vbNullString Or mtbZipCode.Text = vbNullString Or _
            mtbHPhone.Text = vbNullString Or mtbCPhone.Text = vbNullString Or _
            mtbDriversLicNum.Text = vbNullString Or txtCIDLExp.Text = vbNullString) Then

            MessageBox.Show("Please fill in all boxes.")
        Else ' Put all the customer information into a class object
            cust.fName = txtCIfName.Text
            cust.lName = txtCIlName.Text
            cust.street = txtCIStreet.Text
            cust.city = txtCICity.Text
            cust.state = cbState.SelectedItem
            cust.zipCode = mtbZipCode.Text
            cust.hPhone = mtbHPhone.Text
            cust.cPhone = mtbCPhone.Text
            cust.licenseNum = mtbDriversLicNum.Text
            cust.licenseExp = txtCIDLExp.Text

            ' Get the payment type
            If (rbCredit.Checked) Then
                cust.paymentType = "Credit"
                added = True
                credit = True
            ElseIf (rbCheckAcc.Checked) Then
                cust.paymentType = "Checking"
                added = True
                checking = True
            Else
                MessageBox.Show("Please check a payment option.")
            End If

            ' Insert into the database
            If (added) Then
                If carWashSpecial = " " Then
                    carWashSpecial = "N"
                End If

                dataCon.spInsertCustomer(cust.fName, cust.lName, cust.street, _
                                         cust.city, cust.state, cust.zipCode, _
                                         cust.hPhone, cust.cPhone, cust.paymentType, _
                                         cust.licenseNum, cust.licenseExp, _
                                         carWashSpecial, tradeInValue)

                customerDGV.DataSource = dataCon.spGetCustomerInfo()
                clearCustomerInfo()
            End If

            ' Insert the payment form
            If (credit) Then
                insertCreditCard()
                credit = False
            ElseIf (checking) Then
                insertCheckingAccount()
                checking = False
            Else
                MessageBox.Show("Please fill in the necessary boxes.")
            End If
        End If
    End Sub

    ' Clear the textboxes
    Private Sub ClearFieldsToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ClearFieldsToolStripMenuItem.Click
        clearCustomerInfo()
    End Sub

    ' **************************************************************************************************************************************
    ' CUSTOMER INFORMATION TAB FUNCTIONS GO ABOVE HERE!
    ' **************************************************************************************************************************************





    ' **************************************************************************************************************************************
    ' EMPLOYEE HISTORY TAB FUNCTIONS GO BELOW HERE!
    ' **************************************************************************************************************************************

    ' Load the employees into the DGV
    Private Sub LoadEmployeesToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles LoadEmployeesToolStripMenuItem.Click
        employeeDGV.DataSource = dataCon.spGetEmployeeInfo()
    End Sub

    ' Search for certain employees
    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles btnSearchEmp.Click
        If txtSearchEmp.Text = "" Then
            ' Do Nothing
        Else
            Dim query = From emp In dataCon.EmployeeInfos
                    Let ID = emp.employeeID
                    Let FirstName = emp.fName
                    Let LastName = emp.lName
                    Let Address = emp.street + " " + emp.city + ", " + emp.state + " " + emp.zipcode
                    Let HomePhone = emp.hPhone
                    Let CellPhone = emp.cPhone
                    Let CarsSold = emp.vehiclesSold
                    Select ID, FirstName, LastName, Address, HomePhone, CellPhone, CarsSold
                    Where FirstName.ToLower = txtSearchEmp.Text.ToLower

            employeeDGV.DataSource = query.ToList
        End If

    End Sub

    ' Clear the search filter
    Private Sub ClearSearchToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ClearSearchToolStripMenuItem.Click
        employeeDGV.DataSource = dataCon.spGetEmployeeInfo()
        txtSearchEmp.Clear()
    End Sub

    ' Remove an employee from the database
    Private Sub ToolStripMenuItem4_Click(sender As Object, e As EventArgs) Handles ToolStripMenuItem4.Click
        Dim ID = employeeDGV.CurrentCell.Value
        dataCon.spRemoveEmployee(ID.ToString)
        employeeDGV.DataSource = dataCon.spGetEmployeeInfo()
    End Sub

    ' Insert a new employee into the database
    Private Sub ToolStripMenuItem3_Click(sender As Object, e As EventArgs) Handles ToolStripMenuItem3.Click
        frmAddSalesperson.Show()
    End Sub
    ' **************************************************************************************************************************************
    ' EMPLOYEE HISTORY TAB FUNCTIONS GO ABOVE HERE!
    ' **************************************************************************************************************************************    





    ' **************************************************************************************************************************************
    ' SALES INFORMATION TAB FUNCTIONS GO BELOW HERE!
    ' ************************************************************************************************************************************** 
    ' This function searches for a particular person's sales.
    Private Sub btnSaleSearch_Click(sender As Object, e As EventArgs) Handles btnSaleSearch.Click
        Dim Name As String = txtSalesPersonsales.Text

        dgvIndSales.DataSource = dataCon.spSearchSalesForPerson(Name)
    End Sub

    ' This function loads all the sales for the dealership
    Private Sub LoadSalesToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles LoadSalesToolStripMenuItem.Click
        loadSales()
    End Sub

    ' Delete the sale on a double click of the mouse
    Private Sub dgvAllSales_CellMouseDoubleClick(sender As Object, e As DataGridViewCellMouseEventArgs) Handles dgvAllSales.CellMouseDoubleClick
        If IsNumeric(dgvAllSales.CurrentCell.Value) Then
            Dim transID As Integer = dgvAllSales.CurrentCell.Value
            dataCon.spDeleteSales(transID)
            loadSales()
        Else
            MessageBox.Show("Please click on the Transaction ID field.")
        End If
    End Sub

    ' Display a message explaining what to do if the delete sale button is pressed.
    Private Sub DeleteSaleToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles DeleteSaleToolStripMenuItem.Click
        MessageBox.Show("To delete a sale, go to the 'All Sales' tab and double click the " & _
                        "'Transaction ID' cell that you wish to remove.")
    End Sub
    ' **************************************************************************************************************************************
    ' SALES INFORMATION TAB FUNCTIONS GO ABOVE HERE!
    ' **************************************************************************************************************************************    
End Class