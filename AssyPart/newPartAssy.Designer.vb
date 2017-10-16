<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class newPartAssy
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()> _
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.lbl_Parent = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.TextBox_Name = New System.Windows.Forms.TextBox()
        Me.CB_IsAssy = New System.Windows.Forms.CheckBox()
        Me.btn_add = New System.Windows.Forms.Button()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.cmb_Source = New System.Windows.Forms.ComboBox()
        Me.Panel1.SuspendLayout()
        Me.SuspendLayout()
        '
        'Panel1
        '
        Me.Panel1.BackColor = System.Drawing.Color.FromArgb(CType(CType(128, Byte), Integer), CType(CType(128, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.Panel1.Controls.Add(Me.lbl_Parent)
        Me.Panel1.Controls.Add(Me.Label1)
        Me.Panel1.Dock = System.Windows.Forms.DockStyle.Top
        Me.Panel1.Location = New System.Drawing.Point(0, 0)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(509, 72)
        Me.Panel1.TabIndex = 0
        '
        'lbl_Parent
        '
        Me.lbl_Parent.AutoSize = True
        Me.lbl_Parent.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbl_Parent.ForeColor = System.Drawing.Color.White
        Me.lbl_Parent.Location = New System.Drawing.Point(12, 35)
        Me.lbl_Parent.Name = "lbl_Parent"
        Me.lbl_Parent.Size = New System.Drawing.Size(129, 17)
        Me.lbl_Parent.TabIndex = 2
        Me.lbl_Parent.Text = "Parent Assembly"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(12, 9)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(129, 17)
        Me.Label1.TabIndex = 1
        Me.Label1.Text = "Parent Assembly"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(12, 86)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(35, 13)
        Me.Label2.TabIndex = 1
        Me.Label2.Text = "Name"
        '
        'TextBox_Name
        '
        Me.TextBox_Name.Location = New System.Drawing.Point(53, 83)
        Me.TextBox_Name.Name = "TextBox_Name"
        Me.TextBox_Name.Size = New System.Drawing.Size(280, 20)
        Me.TextBox_Name.TabIndex = 2
        '
        'CB_IsAssy
        '
        Me.CB_IsAssy.AutoSize = True
        Me.CB_IsAssy.Location = New System.Drawing.Point(252, 113)
        Me.CB_IsAssy.Name = "CB_IsAssy"
        Me.CB_IsAssy.Size = New System.Drawing.Size(81, 17)
        Me.CB_IsAssy.TabIndex = 3
        Me.CB_IsAssy.Text = "Is Assembly"
        Me.CB_IsAssy.UseVisualStyleBackColor = True
        '
        'btn_add
        '
        Me.btn_add.Location = New System.Drawing.Point(258, 148)
        Me.btn_add.Name = "btn_add"
        Me.btn_add.Size = New System.Drawing.Size(75, 23)
        Me.btn_add.TabIndex = 4
        Me.btn_add.Text = "Add"
        Me.btn_add.UseVisualStyleBackColor = True
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(12, 114)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(41, 13)
        Me.Label3.TabIndex = 5
        Me.Label3.Text = "Source"
        '
        'cmb_Source
        '
        Me.cmb_Source.FormattingEnabled = True
        Me.cmb_Source.Location = New System.Drawing.Point(53, 111)
        Me.cmb_Source.Name = "cmb_Source"
        Me.cmb_Source.Size = New System.Drawing.Size(173, 21)
        Me.cmb_Source.TabIndex = 6
        '
        'newPartAssy
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(509, 183)
        Me.Controls.Add(Me.cmb_Source)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.btn_add)
        Me.Controls.Add(Me.CB_IsAssy)
        Me.Controls.Add(Me.TextBox_Name)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.Panel1)
        Me.Name = "newPartAssy"
        Me.Text = "Magod Laser: Party/ Assembly"
        Me.Panel1.ResumeLayout(False)
        Me.Panel1.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents Panel1 As Panel
    Friend WithEvents lbl_Parent As Label
    Friend WithEvents Label1 As Label
    Friend WithEvents Label2 As Label
    Friend WithEvents TextBox_Name As TextBox
    Friend WithEvents CB_IsAssy As CheckBox
    Friend WithEvents btn_add As Button
    Friend WithEvents Label3 As Label
    Friend WithEvents cmb_Source As ComboBox
End Class
