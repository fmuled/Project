' **********************************************************************************************************
' Engineers: 
'   Jamie Leviner
'   Miguel Espinoza 
'   Tyler Donaldson
'
' Handles the Login System and verification
' 2/15/2012
' **********************************************************************************************************
Public Class Login
    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnLogin.Click
        If (txtName.Text = "manager" And txtPass.Text = "manager") Or (txtName.Text = "owner" And txtPass.Text = "owner") Then
            Me.Hide()
            PoS.Show()
            PoS.txtSalesperson.Text = "Manager/Owner"
        ElseIf (txtName.Text = "employee") And (txtPass.Text = "employee") Then
            Me.Hide()
            PoS.Show()
            PoS.txtSalesperson.Text = "Employee"
            PoS.tabSales.Hide()
            PoS.menuSales.Enabled = False
            PoS.menuEmployee.Enabled = False
            PoS.txtSearchEmployee.Enabled = False
        ElseIf (txtName.Text = "") And (txtPass.Text = "") Then
            Me.Hide()
            PoS.Show()
            PoS.txtSalesperson.Text = ""
        Else
            MessageBox.Show("Username/Password is incorrect. Please try again!")
        End If
    End Sub

    Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnExit.Click
        Me.Close()
    End Sub
End Class