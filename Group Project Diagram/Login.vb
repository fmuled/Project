Public Class Login

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnLogin.Click
        If (txtName.Text = "tdonaldson") And (txtPass.Text = "p@ssw0rd!") Then
            Me.Hide()
            PoS.Show()
            PoS.txtSalesperson.Text = "Tyler Donaldson"
        ElseIf (txtName.Text = "jleviner") And (txtPass.Text = "p@ssw0rd!") Then
            Me.Hide()
            PoS.Show()
            PoS.txtSalesperson.Text = "Jamie Leviner"
            PoS.tabSales.Hide()
            PoS.menuSales.Enabled = False
            PoS.menuEmployee.Enabled = False
            PoS.txtSearchEmployee.Enabled = False
        ElseIf (txtName.Text = "mespinoza") And (txtPass.Text = "p@ssw0rd!") Then
            Me.Hide()
            PoS.Show()
            PoS.txtSalesperson.Text = "Miguel Espinoza"
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