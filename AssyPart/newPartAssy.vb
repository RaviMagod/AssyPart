Public Class newPartAssy
    Private parentAssy As IPartAssy
    Public Event componentAdded(ByVal added As IPartAssy)

    Public Sub New(ByRef parent As IPartAssy)

        ' This call is required by the designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.
        Me.lbl_Parent.Text = parent.Name
        parentAssy = parent
        cmb_Source.DataSource = AssyPartModule.getComponentSource
    End Sub

    Private Sub btn_add_Click(sender As Object, e As EventArgs) Handles btn_add.Click
        Try


            '*** Check name length
            If Me.TextBox_Name.TextLength = 0 Then
                MsgBox("Enter Name of Part/ Assembly")
            Else
                Dim newX As IPartAssy = New MagodPartAssyFactory().getPartAssy(Trim(Me.TextBox_Name.Text), Me.CB_IsAssy.Checked, parentAssy)

                If Me.CB_IsAssy.Checked Then
                    If Not (cmb_Source.SelectedValue = ComponentSource.InHouse _
                       Or cmb_Source.SelectedValue = ComponentSource.OutSourced) Then

                        MsgBox("An assembly can be fabricated InHouse or OutSourced. Otherwise consider it a  Part of an Assemby BOM")
                        newX = Nothing
                        Exit Sub
                    End If

                End If
                newX.Source = cmb_Source.SelectedValue
                parentAssy.ComponentList.Add(newX)
                RaiseEvent componentAdded(newX)
                MsgBox(String.Format("{0} added to {1}, Close to exit or continue to add", newX.Name, parentAssy.Name))
            End If
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub
End Class