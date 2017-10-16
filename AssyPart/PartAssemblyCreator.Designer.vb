<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class PartAssemblyCreator
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()>
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
    <System.Diagnostics.DebuggerStepThrough()>
    Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container()
        Dim DataGridViewCellStyle1 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle2 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle6 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(PartAssemblyCreator))
        Dim DataGridViewCellStyle3 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle4 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle5 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Me.BS_Source = New System.Windows.Forms.BindingSource(Me.components)
        Me.ToolTip1 = New System.Windows.Forms.ToolTip(Me.components)
        Me.TreeView_Assy = New System.Windows.Forms.TreeView()
        Me.SaveDeletePartAssy = New System.Windows.Forms.ContextMenuStrip(Me.components)
        Me.CopyToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.PasteToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.DeleteToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.btn_Delete = New System.Windows.Forms.Button()
        Me.btn_save = New System.Windows.Forms.Button()
        Me.TextBox1 = New System.Windows.Forms.TextBox()
        Me.Bs_part = New System.Windows.Forms.BindingSource(Me.components)
        Me.Panel2 = New System.Windows.Forms.Panel()
        Me.TabControl1 = New System.Windows.Forms.TabControl()
        Me.TabPage1 = New System.Windows.Forms.TabPage()
        Me.SplitContainer1 = New System.Windows.Forms.SplitContainer()
        Me.DGV_Ass2 = New System.Windows.Forms.DataGridView()
        Me.NameDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.IsAssyDataGridViewCheckBoxColumn = New System.Windows.Forms.DataGridViewCheckBoxColumn()
        Me.BS_ItemsList = New System.Windows.Forms.BindingSource(Me.components)
        Me.SplitContainer2 = New System.Windows.Forms.SplitContainer()
        Me.DGV_BOM = New System.Windows.Forms.DataGridView()
        Me.PartNameDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.QuantityDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Bs_BOM = New System.Windows.Forms.BindingSource(Me.components)
        Me.FabDS = New magod.fab.FabDS()
        Me.DGV_Assy = New System.Windows.Forms.DataGridView()
        Me.DataGridViewTextBoxColumn3 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.AssemblyName = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.BS_SubAssy = New System.Windows.Forms.BindingSource(Me.components)
        Me.PanelNewComponent = New System.Windows.Forms.Panel()
        Me.btn_add = New System.Windows.Forms.Button()
        Me.CB_IsAssy = New System.Windows.Forms.CheckBox()
        Me.TextBox_Name = New System.Windows.Forms.TextBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.TabPage2 = New System.Windows.Forms.TabPage()
        Me.SplitContainer3 = New System.Windows.Forms.SplitContainer()
        Me.DGV_MaterialCost = New System.Windows.Forms.DataGridView()
        Me.DataGridViewTextBoxColumn2 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DataGridViewTextBoxColumn4 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.UnitMaterialCost = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.TotalCost = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.BS_BomMaterial = New System.Windows.Forms.BindingSource(Me.components)
        Me.SplitContainer4 = New System.Windows.Forms.SplitContainer()
        Me.DGV_AssemblyCost = New System.Windows.Forms.DataGridView()
        Me.BS_AssyLabour = New System.Windows.Forms.BindingSource(Me.components)
        Me.DataGridView1 = New System.Windows.Forms.DataGridView()
        Me.OperationDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.CostDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.BS_SubAssyOperations = New System.Windows.Forms.BindingSource(Me.components)
        Me.Panel4 = New System.Windows.Forms.Panel()
        Me.btn_saveCosting = New System.Windows.Forms.Button()
        Me.Panel3 = New System.Windows.Forms.Panel()
        Me.Label_QtnNo = New System.Windows.Forms.Label()
        Me.btn_Print = New System.Windows.Forms.Button()
        Me.TextBox_AssyCost = New System.Windows.Forms.TextBox()
        Me.BS_Assembly = New System.Windows.Forms.BindingSource(Me.components)
        Me.Label4 = New System.Windows.Forms.Label()
        Me.TextBox_LabourCost = New System.Windows.Forms.TextBox()
        Me.TextBox_MaterialCost = New System.Windows.Forms.TextBox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Label_AssemblyName = New System.Windows.Forms.Label()
        Me.DataGridViewComboBoxColumn1 = New System.Windows.Forms.DataGridViewComboBoxColumn()
        Me.DataGridViewComboBoxColumn2 = New System.Windows.Forms.DataGridViewComboBoxColumn()
        Me.ReportManager1 = New PerpetuumSoft.Reporting.Components.ReportManager(Me.components)
        Me.BS_Qtn = New System.Windows.Forms.BindingSource(Me.components)
        Me.InlineReportSlot1 = New PerpetuumSoft.Reporting.Components.InlineReportSlot(Me.components)
        Me.DataGridViewTextBoxColumn5 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DataGridViewTextBoxColumn6 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.CalculatedCost = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.UnitLabourCost = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DataGridViewTextBoxColumn7 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        CType(Me.BS_Source, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SaveDeletePartAssy.SuspendLayout()
        Me.Panel1.SuspendLayout()
        CType(Me.Bs_part, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.Panel2.SuspendLayout()
        Me.TabControl1.SuspendLayout()
        Me.TabPage1.SuspendLayout()
        CType(Me.SplitContainer1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SplitContainer1.Panel1.SuspendLayout()
        Me.SplitContainer1.Panel2.SuspendLayout()
        Me.SplitContainer1.SuspendLayout()
        CType(Me.DGV_Ass2, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.BS_ItemsList, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.SplitContainer2, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SplitContainer2.Panel1.SuspendLayout()
        Me.SplitContainer2.Panel2.SuspendLayout()
        Me.SplitContainer2.SuspendLayout()
        CType(Me.DGV_BOM, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Bs_BOM, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.FabDS, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.DGV_Assy, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.BS_SubAssy, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.PanelNewComponent.SuspendLayout()
        Me.TabPage2.SuspendLayout()
        CType(Me.SplitContainer3, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SplitContainer3.Panel1.SuspendLayout()
        Me.SplitContainer3.Panel2.SuspendLayout()
        Me.SplitContainer3.SuspendLayout()
        CType(Me.DGV_MaterialCost, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.BS_BomMaterial, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.SplitContainer4, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SplitContainer4.Panel1.SuspendLayout()
        Me.SplitContainer4.Panel2.SuspendLayout()
        Me.SplitContainer4.SuspendLayout()
        CType(Me.DGV_AssemblyCost, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.BS_AssyLabour, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.DataGridView1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.BS_SubAssyOperations, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.Panel4.SuspendLayout()
        Me.Panel3.SuspendLayout()
        CType(Me.BS_Assembly, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.BS_Qtn, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'TreeView_Assy
        '
        Me.TreeView_Assy.ContextMenuStrip = Me.SaveDeletePartAssy
        Me.TreeView_Assy.Dock = System.Windows.Forms.DockStyle.Right
        Me.TreeView_Assy.Location = New System.Drawing.Point(649, 0)
        Me.TreeView_Assy.Name = "TreeView_Assy"
        Me.TreeView_Assy.Size = New System.Drawing.Size(289, 379)
        Me.TreeView_Assy.TabIndex = 1
        Me.ToolTip1.SetToolTip(Me.TreeView_Assy, "Double Click to Load Part/  Assembly")
        '
        'SaveDeletePartAssy
        '
        Me.SaveDeletePartAssy.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.CopyToolStripMenuItem, Me.PasteToolStripMenuItem, Me.DeleteToolStripMenuItem})
        Me.SaveDeletePartAssy.Name = "SaveDeletePartAssy"
        Me.SaveDeletePartAssy.Size = New System.Drawing.Size(108, 70)
        '
        'CopyToolStripMenuItem
        '
        Me.CopyToolStripMenuItem.Name = "CopyToolStripMenuItem"
        Me.CopyToolStripMenuItem.Size = New System.Drawing.Size(107, 22)
        Me.CopyToolStripMenuItem.Text = "Copy"
        '
        'PasteToolStripMenuItem
        '
        Me.PasteToolStripMenuItem.Name = "PasteToolStripMenuItem"
        Me.PasteToolStripMenuItem.Size = New System.Drawing.Size(107, 22)
        Me.PasteToolStripMenuItem.Text = "Paste"
        '
        'DeleteToolStripMenuItem
        '
        Me.DeleteToolStripMenuItem.Name = "DeleteToolStripMenuItem"
        Me.DeleteToolStripMenuItem.Size = New System.Drawing.Size(107, 22)
        Me.DeleteToolStripMenuItem.Text = "Delete"
        '
        'Panel1
        '
        Me.Panel1.BackColor = System.Drawing.Color.Gray
        Me.Panel1.Controls.Add(Me.btn_Delete)
        Me.Panel1.Controls.Add(Me.btn_save)
        Me.Panel1.Controls.Add(Me.TextBox1)
        Me.Panel1.Dock = System.Windows.Forms.DockStyle.Top
        Me.Panel1.Location = New System.Drawing.Point(3, 3)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(635, 44)
        Me.Panel1.TabIndex = 2
        '
        'btn_Delete
        '
        Me.btn_Delete.Location = New System.Drawing.Point(517, 10)
        Me.btn_Delete.Name = "btn_Delete"
        Me.btn_Delete.Size = New System.Drawing.Size(75, 23)
        Me.btn_Delete.TabIndex = 6
        Me.btn_Delete.Text = "Delete"
        Me.btn_Delete.UseVisualStyleBackColor = True
        '
        'btn_save
        '
        Me.btn_save.Location = New System.Drawing.Point(438, 10)
        Me.btn_save.Name = "btn_save"
        Me.btn_save.Size = New System.Drawing.Size(75, 23)
        Me.btn_save.TabIndex = 5
        Me.btn_save.Text = "Save"
        Me.btn_save.UseVisualStyleBackColor = True
        '
        'TextBox1
        '
        Me.TextBox1.DataBindings.Add(New System.Windows.Forms.Binding("Text", Me.Bs_part, "Name", True))
        Me.TextBox1.Location = New System.Drawing.Point(15, 12)
        Me.TextBox1.Name = "TextBox1"
        Me.TextBox1.Size = New System.Drawing.Size(422, 20)
        Me.TextBox1.TabIndex = 1
        '
        'Bs_part
        '
        Me.Bs_part.DataSource = GetType(magod.fab.SubAssembly)
        '
        'Panel2
        '
        Me.Panel2.Controls.Add(Me.TabControl1)
        Me.Panel2.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Panel2.Location = New System.Drawing.Point(0, 164)
        Me.Panel2.Name = "Panel2"
        Me.Panel2.Size = New System.Drawing.Size(649, 215)
        Me.Panel2.TabIndex = 3
        '
        'TabControl1
        '
        Me.TabControl1.Controls.Add(Me.TabPage1)
        Me.TabControl1.Controls.Add(Me.TabPage2)
        Me.TabControl1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.TabControl1.Location = New System.Drawing.Point(0, 0)
        Me.TabControl1.Name = "TabControl1"
        Me.TabControl1.SelectedIndex = 0
        Me.TabControl1.Size = New System.Drawing.Size(649, 215)
        Me.TabControl1.TabIndex = 3
        '
        'TabPage1
        '
        Me.TabPage1.Controls.Add(Me.SplitContainer1)
        Me.TabPage1.Controls.Add(Me.PanelNewComponent)
        Me.TabPage1.Controls.Add(Me.Panel1)
        Me.TabPage1.Location = New System.Drawing.Point(4, 22)
        Me.TabPage1.Name = "TabPage1"
        Me.TabPage1.Padding = New System.Windows.Forms.Padding(3)
        Me.TabPage1.Size = New System.Drawing.Size(641, 189)
        Me.TabPage1.TabIndex = 0
        Me.TabPage1.Text = "Assemby Components"
        Me.TabPage1.UseVisualStyleBackColor = True
        '
        'SplitContainer1
        '
        Me.SplitContainer1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.SplitContainer1.Location = New System.Drawing.Point(3, 47)
        Me.SplitContainer1.Name = "SplitContainer1"
        '
        'SplitContainer1.Panel1
        '
        Me.SplitContainer1.Panel1.Controls.Add(Me.DGV_Ass2)
        '
        'SplitContainer1.Panel2
        '
        Me.SplitContainer1.Panel2.Controls.Add(Me.SplitContainer2)
        Me.SplitContainer1.Size = New System.Drawing.Size(635, 97)
        Me.SplitContainer1.SplitterDistance = 210
        Me.SplitContainer1.TabIndex = 6
        '
        'DGV_Ass2
        '
        Me.DGV_Ass2.AllowUserToAddRows = False
        Me.DGV_Ass2.AllowUserToDeleteRows = False
        Me.DGV_Ass2.AutoGenerateColumns = False
        Me.DGV_Ass2.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.DGV_Ass2.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.NameDataGridViewTextBoxColumn, Me.IsAssyDataGridViewCheckBoxColumn})
        Me.DGV_Ass2.DataSource = Me.BS_ItemsList
        Me.DGV_Ass2.Dock = System.Windows.Forms.DockStyle.Fill
        Me.DGV_Ass2.Location = New System.Drawing.Point(0, 0)
        Me.DGV_Ass2.Name = "DGV_Ass2"
        Me.DGV_Ass2.ReadOnly = True
        Me.DGV_Ass2.Size = New System.Drawing.Size(210, 97)
        Me.DGV_Ass2.TabIndex = 4
        '
        'NameDataGridViewTextBoxColumn
        '
        Me.NameDataGridViewTextBoxColumn.DataPropertyName = "Name"
        Me.NameDataGridViewTextBoxColumn.HeaderText = "Name"
        Me.NameDataGridViewTextBoxColumn.Name = "NameDataGridViewTextBoxColumn"
        Me.NameDataGridViewTextBoxColumn.ReadOnly = True
        Me.NameDataGridViewTextBoxColumn.Width = 150
        '
        'IsAssyDataGridViewCheckBoxColumn
        '
        Me.IsAssyDataGridViewCheckBoxColumn.DataPropertyName = "IsAssy"
        Me.IsAssyDataGridViewCheckBoxColumn.HeaderText = "Is Assy"
        Me.IsAssyDataGridViewCheckBoxColumn.Name = "IsAssyDataGridViewCheckBoxColumn"
        Me.IsAssyDataGridViewCheckBoxColumn.ReadOnly = True
        Me.IsAssyDataGridViewCheckBoxColumn.Width = 50
        '
        'BS_ItemsList
        '
        Me.BS_ItemsList.DataMember = "ComponentList"
        Me.BS_ItemsList.DataSource = Me.Bs_part
        '
        'SplitContainer2
        '
        Me.SplitContainer2.Dock = System.Windows.Forms.DockStyle.Fill
        Me.SplitContainer2.Location = New System.Drawing.Point(0, 0)
        Me.SplitContainer2.Name = "SplitContainer2"
        '
        'SplitContainer2.Panel1
        '
        Me.SplitContainer2.Panel1.Controls.Add(Me.DGV_BOM)
        '
        'SplitContainer2.Panel2
        '
        Me.SplitContainer2.Panel2.Controls.Add(Me.DGV_Assy)
        Me.SplitContainer2.Size = New System.Drawing.Size(421, 97)
        Me.SplitContainer2.SplitterDistance = 205
        Me.SplitContainer2.TabIndex = 1
        '
        'DGV_BOM
        '
        Me.DGV_BOM.AllowUserToAddRows = False
        Me.DGV_BOM.AllowUserToDeleteRows = False
        Me.DGV_BOM.AutoGenerateColumns = False
        Me.DGV_BOM.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.DGV_BOM.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.PartNameDataGridViewTextBoxColumn, Me.QuantityDataGridViewTextBoxColumn})
        Me.DGV_BOM.DataSource = Me.Bs_BOM
        Me.DGV_BOM.Dock = System.Windows.Forms.DockStyle.Fill
        Me.DGV_BOM.Location = New System.Drawing.Point(0, 0)
        Me.DGV_BOM.Name = "DGV_BOM"
        Me.DGV_BOM.ReadOnly = True
        Me.DGV_BOM.Size = New System.Drawing.Size(205, 97)
        Me.DGV_BOM.TabIndex = 0
        '
        'PartNameDataGridViewTextBoxColumn
        '
        Me.PartNameDataGridViewTextBoxColumn.DataPropertyName = "PartName"
        Me.PartNameDataGridViewTextBoxColumn.HeaderText = "Part Name"
        Me.PartNameDataGridViewTextBoxColumn.Name = "PartNameDataGridViewTextBoxColumn"
        Me.PartNameDataGridViewTextBoxColumn.ReadOnly = True
        Me.PartNameDataGridViewTextBoxColumn.Width = 200
        '
        'QuantityDataGridViewTextBoxColumn
        '
        Me.QuantityDataGridViewTextBoxColumn.DataPropertyName = "Quantity"
        Me.QuantityDataGridViewTextBoxColumn.HeaderText = "Quantity"
        Me.QuantityDataGridViewTextBoxColumn.Name = "QuantityDataGridViewTextBoxColumn"
        Me.QuantityDataGridViewTextBoxColumn.ReadOnly = True
        Me.QuantityDataGridViewTextBoxColumn.Width = 50
        '
        'Bs_BOM
        '
        Me.Bs_BOM.DataMember = "BOM"
        Me.Bs_BOM.DataSource = Me.FabDS
        '
        'FabDS
        '
        Me.FabDS.DataSetName = "FabDS"
        Me.FabDS.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema
        '
        'DGV_Assy
        '
        Me.DGV_Assy.AllowUserToAddRows = False
        Me.DGV_Assy.AllowUserToDeleteRows = False
        Me.DGV_Assy.AutoGenerateColumns = False
        Me.DGV_Assy.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.DGV_Assy.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.DataGridViewTextBoxColumn3, Me.AssemblyName})
        Me.DGV_Assy.DataSource = Me.BS_SubAssy
        Me.DGV_Assy.Dock = System.Windows.Forms.DockStyle.Fill
        Me.DGV_Assy.Location = New System.Drawing.Point(0, 0)
        Me.DGV_Assy.Name = "DGV_Assy"
        Me.DGV_Assy.ReadOnly = True
        Me.DGV_Assy.Size = New System.Drawing.Size(212, 97)
        Me.DGV_Assy.TabIndex = 1
        '
        'DataGridViewTextBoxColumn3
        '
        Me.DataGridViewTextBoxColumn3.DataPropertyName = "Quantity"
        Me.DataGridViewTextBoxColumn3.HeaderText = "Quantity"
        Me.DataGridViewTextBoxColumn3.Name = "DataGridViewTextBoxColumn3"
        Me.DataGridViewTextBoxColumn3.ReadOnly = True
        Me.DataGridViewTextBoxColumn3.Width = 50
        '
        'AssemblyName
        '
        Me.AssemblyName.DataPropertyName = "SubAssyName"
        Me.AssemblyName.HeaderText = "Assembly Name"
        Me.AssemblyName.Name = "AssemblyName"
        Me.AssemblyName.ReadOnly = True
        Me.AssemblyName.Width = 200
        '
        'BS_SubAssy
        '
        Me.BS_SubAssy.DataMember = "SubAssy"
        Me.BS_SubAssy.DataSource = Me.FabDS
        '
        'PanelNewComponent
        '
        Me.PanelNewComponent.BackColor = System.Drawing.Color.Gray
        Me.PanelNewComponent.Controls.Add(Me.btn_add)
        Me.PanelNewComponent.Controls.Add(Me.CB_IsAssy)
        Me.PanelNewComponent.Controls.Add(Me.TextBox_Name)
        Me.PanelNewComponent.Controls.Add(Me.Label2)
        Me.PanelNewComponent.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.PanelNewComponent.Location = New System.Drawing.Point(3, 144)
        Me.PanelNewComponent.Name = "PanelNewComponent"
        Me.PanelNewComponent.Size = New System.Drawing.Size(635, 42)
        Me.PanelNewComponent.TabIndex = 5
        '
        'btn_add
        '
        Me.btn_add.Location = New System.Drawing.Point(380, 5)
        Me.btn_add.Name = "btn_add"
        Me.btn_add.Size = New System.Drawing.Size(75, 23)
        Me.btn_add.TabIndex = 12
        Me.btn_add.Text = "Add"
        Me.btn_add.UseVisualStyleBackColor = True
        '
        'CB_IsAssy
        '
        Me.CB_IsAssy.AutoSize = True
        Me.CB_IsAssy.ForeColor = System.Drawing.Color.White
        Me.CB_IsAssy.Location = New System.Drawing.Point(295, 9)
        Me.CB_IsAssy.Name = "CB_IsAssy"
        Me.CB_IsAssy.Size = New System.Drawing.Size(81, 17)
        Me.CB_IsAssy.TabIndex = 9
        Me.CB_IsAssy.Text = "Is Assembly"
        Me.CB_IsAssy.UseVisualStyleBackColor = True
        '
        'TextBox_Name
        '
        Me.TextBox_Name.Location = New System.Drawing.Point(52, 6)
        Me.TextBox_Name.Name = "TextBox_Name"
        Me.TextBox_Name.Size = New System.Drawing.Size(233, 20)
        Me.TextBox_Name.TabIndex = 8
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.ForeColor = System.Drawing.Color.White
        Me.Label2.Location = New System.Drawing.Point(11, 9)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(35, 13)
        Me.Label2.TabIndex = 7
        Me.Label2.Text = "Name"
        '
        'TabPage2
        '
        Me.TabPage2.Controls.Add(Me.SplitContainer3)
        Me.TabPage2.Controls.Add(Me.Panel4)
        Me.TabPage2.Location = New System.Drawing.Point(4, 22)
        Me.TabPage2.Name = "TabPage2"
        Me.TabPage2.Padding = New System.Windows.Forms.Padding(3)
        Me.TabPage2.Size = New System.Drawing.Size(641, 189)
        Me.TabPage2.TabIndex = 1
        Me.TabPage2.Text = "Costing"
        Me.TabPage2.UseVisualStyleBackColor = True
        '
        'SplitContainer3
        '
        Me.SplitContainer3.Dock = System.Windows.Forms.DockStyle.Fill
        Me.SplitContainer3.Location = New System.Drawing.Point(3, 69)
        Me.SplitContainer3.Name = "SplitContainer3"
        '
        'SplitContainer3.Panel1
        '
        Me.SplitContainer3.Panel1.Controls.Add(Me.DGV_MaterialCost)
        '
        'SplitContainer3.Panel2
        '
        Me.SplitContainer3.Panel2.Controls.Add(Me.SplitContainer4)
        Me.SplitContainer3.Size = New System.Drawing.Size(635, 117)
        Me.SplitContainer3.SplitterDistance = 326
        Me.SplitContainer3.TabIndex = 2
        '
        'DGV_MaterialCost
        '
        Me.DGV_MaterialCost.AllowUserToAddRows = False
        Me.DGV_MaterialCost.AllowUserToDeleteRows = False
        Me.DGV_MaterialCost.AutoGenerateColumns = False
        Me.DGV_MaterialCost.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.DGV_MaterialCost.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.DataGridViewTextBoxColumn2, Me.DataGridViewTextBoxColumn4, Me.UnitMaterialCost, Me.TotalCost})
        Me.DGV_MaterialCost.DataSource = Me.BS_BomMaterial
        Me.DGV_MaterialCost.Dock = System.Windows.Forms.DockStyle.Fill
        Me.DGV_MaterialCost.Location = New System.Drawing.Point(0, 0)
        Me.DGV_MaterialCost.Name = "DGV_MaterialCost"
        Me.DGV_MaterialCost.Size = New System.Drawing.Size(326, 117)
        Me.DGV_MaterialCost.TabIndex = 0
        '
        'DataGridViewTextBoxColumn2
        '
        Me.DataGridViewTextBoxColumn2.DataPropertyName = "PartName"
        Me.DataGridViewTextBoxColumn2.HeaderText = "Part Name"
        Me.DataGridViewTextBoxColumn2.Name = "DataGridViewTextBoxColumn2"
        Me.DataGridViewTextBoxColumn2.Width = 200
        '
        'DataGridViewTextBoxColumn4
        '
        Me.DataGridViewTextBoxColumn4.DataPropertyName = "Quantity"
        Me.DataGridViewTextBoxColumn4.HeaderText = "Quantity"
        Me.DataGridViewTextBoxColumn4.Name = "DataGridViewTextBoxColumn4"
        Me.DataGridViewTextBoxColumn4.Width = 50
        '
        'UnitMaterialCost
        '
        Me.UnitMaterialCost.DataPropertyName = "UnitMaterialCost"
        DataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
        DataGridViewCellStyle1.BackColor = System.Drawing.Color.LemonChiffon
        DataGridViewCellStyle1.Format = "N2"
        DataGridViewCellStyle1.Padding = New System.Windows.Forms.Padding(0, 0, 3, 0)
        Me.UnitMaterialCost.DefaultCellStyle = DataGridViewCellStyle1
        Me.UnitMaterialCost.HeaderText = "Material Cost/Unit"
        Me.UnitMaterialCost.Name = "UnitMaterialCost"
        Me.UnitMaterialCost.Width = 70
        '
        'TotalCost
        '
        Me.TotalCost.DataPropertyName = "TotalCost"
        DataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
        DataGridViewCellStyle2.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle2.Format = "n2"
        DataGridViewCellStyle2.Padding = New System.Windows.Forms.Padding(0, 0, 3, 0)
        Me.TotalCost.DefaultCellStyle = DataGridViewCellStyle2
        Me.TotalCost.HeaderText = "TotalCost"
        Me.TotalCost.Name = "TotalCost"
        Me.TotalCost.ReadOnly = True
        Me.TotalCost.Width = 70
        '
        'BS_BomMaterial
        '
        Me.BS_BomMaterial.DataMember = "BOM"
        Me.BS_BomMaterial.DataSource = Me.FabDS
        '
        'SplitContainer4
        '
        Me.SplitContainer4.Dock = System.Windows.Forms.DockStyle.Fill
        Me.SplitContainer4.Location = New System.Drawing.Point(0, 0)
        Me.SplitContainer4.Name = "SplitContainer4"
        Me.SplitContainer4.Orientation = System.Windows.Forms.Orientation.Horizontal
        '
        'SplitContainer4.Panel1
        '
        Me.SplitContainer4.Panel1.Controls.Add(Me.DGV_AssemblyCost)
        '
        'SplitContainer4.Panel2
        '
        Me.SplitContainer4.Panel2.Controls.Add(Me.DataGridView1)
        Me.SplitContainer4.Size = New System.Drawing.Size(305, 117)
        Me.SplitContainer4.SplitterDistance = 68
        Me.SplitContainer4.TabIndex = 2
        '
        'DGV_AssemblyCost
        '
        Me.DGV_AssemblyCost.AllowUserToAddRows = False
        Me.DGV_AssemblyCost.AllowUserToDeleteRows = False
        Me.DGV_AssemblyCost.AutoGenerateColumns = False
        Me.DGV_AssemblyCost.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.DGV_AssemblyCost.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.DataGridViewTextBoxColumn5, Me.DataGridViewTextBoxColumn6, Me.CalculatedCost, Me.UnitLabourCost, Me.DataGridViewTextBoxColumn7})
        Me.DGV_AssemblyCost.DataSource = Me.BS_AssyLabour
        Me.DGV_AssemblyCost.Dock = System.Windows.Forms.DockStyle.Fill
        Me.DGV_AssemblyCost.Location = New System.Drawing.Point(0, 0)
        Me.DGV_AssemblyCost.Name = "DGV_AssemblyCost"
        Me.DGV_AssemblyCost.Size = New System.Drawing.Size(305, 68)
        Me.DGV_AssemblyCost.TabIndex = 1
        '
        'BS_AssyLabour
        '
        Me.BS_AssyLabour.DataMember = "SubAssy"
        Me.BS_AssyLabour.DataSource = Me.FabDS
        '
        'DataGridView1
        '
        Me.DataGridView1.AutoGenerateColumns = False
        Me.DataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.DataGridView1.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.OperationDataGridViewTextBoxColumn, Me.CostDataGridViewTextBoxColumn})
        Me.DataGridView1.DataSource = Me.BS_SubAssyOperations
        Me.DataGridView1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.DataGridView1.Location = New System.Drawing.Point(0, 0)
        Me.DataGridView1.Name = "DataGridView1"
        Me.DataGridView1.Size = New System.Drawing.Size(305, 45)
        Me.DataGridView1.TabIndex = 0
        '
        'OperationDataGridViewTextBoxColumn
        '
        Me.OperationDataGridViewTextBoxColumn.DataPropertyName = "Operation"
        Me.OperationDataGridViewTextBoxColumn.HeaderText = "Operation"
        Me.OperationDataGridViewTextBoxColumn.Name = "OperationDataGridViewTextBoxColumn"
        Me.OperationDataGridViewTextBoxColumn.Width = 150
        '
        'CostDataGridViewTextBoxColumn
        '
        Me.CostDataGridViewTextBoxColumn.DataPropertyName = "Cost"
        DataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
        DataGridViewCellStyle6.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(192, Byte), Integer), CType(CType(192, Byte), Integer))
        DataGridViewCellStyle6.Format = "N2"
        DataGridViewCellStyle6.Padding = New System.Windows.Forms.Padding(0, 0, 3, 0)
        Me.CostDataGridViewTextBoxColumn.DefaultCellStyle = DataGridViewCellStyle6
        Me.CostDataGridViewTextBoxColumn.HeaderText = "Cost"
        Me.CostDataGridViewTextBoxColumn.Name = "CostDataGridViewTextBoxColumn"
        Me.CostDataGridViewTextBoxColumn.Width = 50
        '
        'BS_SubAssyOperations
        '
        Me.BS_SubAssyOperations.DataMember = "FK_SubAssy_AssyOperations"
        Me.BS_SubAssyOperations.DataSource = Me.BS_AssyLabour
        '
        'Panel4
        '
        Me.Panel4.BackColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.Panel4.Controls.Add(Me.btn_saveCosting)
        Me.Panel4.Dock = System.Windows.Forms.DockStyle.Top
        Me.Panel4.Location = New System.Drawing.Point(3, 3)
        Me.Panel4.Name = "Panel4"
        Me.Panel4.Size = New System.Drawing.Size(635, 66)
        Me.Panel4.TabIndex = 0
        '
        'btn_saveCosting
        '
        Me.btn_saveCosting.Location = New System.Drawing.Point(18, 22)
        Me.btn_saveCosting.Name = "btn_saveCosting"
        Me.btn_saveCosting.Size = New System.Drawing.Size(75, 23)
        Me.btn_saveCosting.TabIndex = 0
        Me.btn_saveCosting.Text = "Save"
        Me.btn_saveCosting.UseVisualStyleBackColor = True
        '
        'Panel3
        '
        Me.Panel3.Controls.Add(Me.Label_QtnNo)
        Me.Panel3.Controls.Add(Me.btn_Print)
        Me.Panel3.Controls.Add(Me.TextBox_AssyCost)
        Me.Panel3.Controls.Add(Me.Label4)
        Me.Panel3.Controls.Add(Me.TextBox_LabourCost)
        Me.Panel3.Controls.Add(Me.TextBox_MaterialCost)
        Me.Panel3.Controls.Add(Me.Label3)
        Me.Panel3.Controls.Add(Me.Label1)
        Me.Panel3.Controls.Add(Me.Label_AssemblyName)
        Me.Panel3.Dock = System.Windows.Forms.DockStyle.Top
        Me.Panel3.Location = New System.Drawing.Point(0, 0)
        Me.Panel3.Name = "Panel3"
        Me.Panel3.Size = New System.Drawing.Size(649, 164)
        Me.Panel3.TabIndex = 11
        '
        'Label_QtnNo
        '
        Me.Label_QtnNo.AutoSize = True
        Me.Label_QtnNo.BackColor = System.Drawing.Color.White
        Me.Label_QtnNo.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label_QtnNo.Location = New System.Drawing.Point(22, 9)
        Me.Label_QtnNo.Name = "Label_QtnNo"
        Me.Label_QtnNo.Size = New System.Drawing.Size(57, 17)
        Me.Label_QtnNo.TabIndex = 13
        Me.Label_QtnNo.Text = "Label1"
        '
        'btn_Print
        '
        Me.btn_Print.Location = New System.Drawing.Point(245, 121)
        Me.btn_Print.Name = "btn_Print"
        Me.btn_Print.Size = New System.Drawing.Size(75, 23)
        Me.btn_Print.TabIndex = 12
        Me.btn_Print.Text = "Print"
        Me.btn_Print.UseVisualStyleBackColor = True
        '
        'TextBox_AssyCost
        '
        Me.TextBox_AssyCost.DataBindings.Add(New System.Windows.Forms.Binding("Text", Me.BS_Assembly, "TotalUnitCost", True))
        Me.TextBox_AssyCost.Enabled = False
        Me.TextBox_AssyCost.Location = New System.Drawing.Point(99, 123)
        Me.TextBox_AssyCost.Name = "TextBox_AssyCost"
        Me.TextBox_AssyCost.ReadOnly = True
        Me.TextBox_AssyCost.Size = New System.Drawing.Size(128, 20)
        Me.TextBox_AssyCost.TabIndex = 7
        '
        'BS_Assembly
        '
        Me.BS_Assembly.DataSource = GetType(magod.fab.QuotationAssembly)
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.Location = New System.Drawing.Point(29, 126)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(65, 13)
        Me.Label4.TabIndex = 6
        Me.Label4.Text = "Total Cost"
        '
        'TextBox_LabourCost
        '
        Me.TextBox_LabourCost.DataBindings.Add(New System.Windows.Forms.Binding("Text", Me.BS_Assembly, "LabourCost", True))
        Me.TextBox_LabourCost.Enabled = False
        Me.TextBox_LabourCost.Location = New System.Drawing.Point(99, 97)
        Me.TextBox_LabourCost.Name = "TextBox_LabourCost"
        Me.TextBox_LabourCost.ReadOnly = True
        Me.TextBox_LabourCost.Size = New System.Drawing.Size(128, 20)
        Me.TextBox_LabourCost.TabIndex = 5
        '
        'TextBox_MaterialCost
        '
        Me.TextBox_MaterialCost.DataBindings.Add(New System.Windows.Forms.Binding("Text", Me.BS_Assembly, "MaterialCost", True))
        Me.TextBox_MaterialCost.Location = New System.Drawing.Point(99, 73)
        Me.TextBox_MaterialCost.Name = "TextBox_MaterialCost"
        Me.TextBox_MaterialCost.ReadOnly = True
        Me.TextBox_MaterialCost.Size = New System.Drawing.Size(128, 20)
        Me.TextBox_MaterialCost.TabIndex = 4
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.Location = New System.Drawing.Point(22, 100)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(75, 13)
        Me.Label3.TabIndex = 3
        Me.Label3.Text = "Labour Cost"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(16, 76)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(81, 13)
        Me.Label1.TabIndex = 2
        Me.Label1.Text = "Material Cost"
        '
        'Label_AssemblyName
        '
        Me.Label_AssemblyName.AutoSize = True
        Me.Label_AssemblyName.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label_AssemblyName.Location = New System.Drawing.Point(22, 37)
        Me.Label_AssemblyName.Name = "Label_AssemblyName"
        Me.Label_AssemblyName.Size = New System.Drawing.Size(57, 17)
        Me.Label_AssemblyName.TabIndex = 1
        Me.Label_AssemblyName.Text = "Label1"
        '
        'DataGridViewComboBoxColumn1
        '
        Me.DataGridViewComboBoxColumn1.DataPropertyName = "Source"
        Me.DataGridViewComboBoxColumn1.DataSource = Me.BS_Source
        Me.DataGridViewComboBoxColumn1.HeaderText = "Source"
        Me.DataGridViewComboBoxColumn1.Name = "DataGridViewComboBoxColumn1"
        Me.DataGridViewComboBoxColumn1.Resizable = System.Windows.Forms.DataGridViewTriState.[True]
        Me.DataGridViewComboBoxColumn1.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic
        Me.DataGridViewComboBoxColumn1.Width = 150
        '
        'DataGridViewComboBoxColumn2
        '
        Me.DataGridViewComboBoxColumn2.DataPropertyName = "Source"
        Me.DataGridViewComboBoxColumn2.DataSource = Me.BS_Source
        Me.DataGridViewComboBoxColumn2.HeaderText = "Source"
        Me.DataGridViewComboBoxColumn2.Name = "DataGridViewComboBoxColumn2"
        Me.DataGridViewComboBoxColumn2.Resizable = System.Windows.Forms.DataGridViewTriState.[True]
        Me.DataGridViewComboBoxColumn2.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic
        Me.DataGridViewComboBoxColumn2.Width = 150
        '
        'ReportManager1
        '
        Me.ReportManager1.DataSources = New PerpetuumSoft.Reporting.Components.ObjectPointerCollection(New String() {"Assembly", "AssyTree", "Qtn"}, New Object() {CType(Me.BS_Assembly, Object), CType(Me.TreeView_Assy, Object), CType(Me.BS_Qtn, Object)})
        Me.ReportManager1.OwnerForm = Me
        Me.ReportManager1.Reports.AddRange(New PerpetuumSoft.Reporting.Components.ReportSlot() {Me.InlineReportSlot1})
        '
        'InlineReportSlot1
        '
        Me.InlineReportSlot1.DocumentStream = resources.GetString("InlineReportSlot1.DocumentStream")
        Me.InlineReportSlot1.ReportName = "rpt_FabricationEstimator"
        Me.InlineReportSlot1.ReportScriptType = GetType(PerpetuumSoft.Reporting.Rendering.ReportScriptBase)
        '
        'DataGridViewTextBoxColumn5
        '
        Me.DataGridViewTextBoxColumn5.DataPropertyName = "AssemblyName"
        Me.DataGridViewTextBoxColumn5.HeaderText = "Assembly Name"
        Me.DataGridViewTextBoxColumn5.Name = "DataGridViewTextBoxColumn5"
        Me.DataGridViewTextBoxColumn5.Width = 150
        '
        'DataGridViewTextBoxColumn6
        '
        Me.DataGridViewTextBoxColumn6.DataPropertyName = "Quantity"
        Me.DataGridViewTextBoxColumn6.HeaderText = "Quantity"
        Me.DataGridViewTextBoxColumn6.Name = "DataGridViewTextBoxColumn6"
        Me.DataGridViewTextBoxColumn6.Width = 50
        '
        'CalculatedCost
        '
        Me.CalculatedCost.DataPropertyName = "CalculatedCost"
        DataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
        DataGridViewCellStyle3.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(192, Byte), Integer), CType(CType(192, Byte), Integer))
        DataGridViewCellStyle3.Format = "n2"
        DataGridViewCellStyle3.Padding = New System.Windows.Forms.Padding(0, 0, 3, 0)
        Me.CalculatedCost.DefaultCellStyle = DataGridViewCellStyle3
        Me.CalculatedCost.HeaderText = "Calculated Cost"
        Me.CalculatedCost.Name = "CalculatedCost"
        Me.CalculatedCost.ReadOnly = True
        Me.CalculatedCost.Width = 70
        '
        'UnitLabourCost
        '
        Me.UnitLabourCost.DataPropertyName = "UnitLabourCost"
        DataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
        DataGridViewCellStyle4.BackColor = System.Drawing.Color.LemonChiffon
        DataGridViewCellStyle4.Format = "n2"
        DataGridViewCellStyle4.Padding = New System.Windows.Forms.Padding(0, 0, 3, 0)
        Me.UnitLabourCost.DefaultCellStyle = DataGridViewCellStyle4
        Me.UnitLabourCost.HeaderText = "LabourCost/ Unit"
        Me.UnitLabourCost.Name = "UnitLabourCost"
        Me.UnitLabourCost.Width = 70
        '
        'DataGridViewTextBoxColumn7
        '
        Me.DataGridViewTextBoxColumn7.DataPropertyName = "TotalCost"
        DataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
        DataGridViewCellStyle5.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle5.Format = "n2"
        DataGridViewCellStyle5.Padding = New System.Windows.Forms.Padding(0, 0, 3, 0)
        Me.DataGridViewTextBoxColumn7.DefaultCellStyle = DataGridViewCellStyle5
        Me.DataGridViewTextBoxColumn7.HeaderText = "Total Cost"
        Me.DataGridViewTextBoxColumn7.Name = "DataGridViewTextBoxColumn7"
        Me.DataGridViewTextBoxColumn7.ReadOnly = True
        Me.DataGridViewTextBoxColumn7.Width = 70
        '
        'PartAssemblyCreator
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(938, 379)
        Me.Controls.Add(Me.Panel2)
        Me.Controls.Add(Me.Panel3)
        Me.Controls.Add(Me.TreeView_Assy)
        Me.Name = "PartAssemblyCreator"
        Me.Text = "PartAssemblyCreator"
        Me.WindowState = System.Windows.Forms.FormWindowState.Maximized
        CType(Me.BS_Source, System.ComponentModel.ISupportInitialize).EndInit()
        Me.SaveDeletePartAssy.ResumeLayout(False)
        Me.Panel1.ResumeLayout(False)
        Me.Panel1.PerformLayout()
        CType(Me.Bs_part, System.ComponentModel.ISupportInitialize).EndInit()
        Me.Panel2.ResumeLayout(False)
        Me.TabControl1.ResumeLayout(False)
        Me.TabPage1.ResumeLayout(False)
        Me.SplitContainer1.Panel1.ResumeLayout(False)
        Me.SplitContainer1.Panel2.ResumeLayout(False)
        CType(Me.SplitContainer1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.SplitContainer1.ResumeLayout(False)
        CType(Me.DGV_Ass2, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.BS_ItemsList, System.ComponentModel.ISupportInitialize).EndInit()
        Me.SplitContainer2.Panel1.ResumeLayout(False)
        Me.SplitContainer2.Panel2.ResumeLayout(False)
        CType(Me.SplitContainer2, System.ComponentModel.ISupportInitialize).EndInit()
        Me.SplitContainer2.ResumeLayout(False)
        CType(Me.DGV_BOM, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Bs_BOM, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.FabDS, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.DGV_Assy, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.BS_SubAssy, System.ComponentModel.ISupportInitialize).EndInit()
        Me.PanelNewComponent.ResumeLayout(False)
        Me.PanelNewComponent.PerformLayout()
        Me.TabPage2.ResumeLayout(False)
        Me.SplitContainer3.Panel1.ResumeLayout(False)
        Me.SplitContainer3.Panel2.ResumeLayout(False)
        CType(Me.SplitContainer3, System.ComponentModel.ISupportInitialize).EndInit()
        Me.SplitContainer3.ResumeLayout(False)
        CType(Me.DGV_MaterialCost, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.BS_BomMaterial, System.ComponentModel.ISupportInitialize).EndInit()
        Me.SplitContainer4.Panel1.ResumeLayout(False)
        Me.SplitContainer4.Panel2.ResumeLayout(False)
        CType(Me.SplitContainer4, System.ComponentModel.ISupportInitialize).EndInit()
        Me.SplitContainer4.ResumeLayout(False)
        CType(Me.DGV_AssemblyCost, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.BS_AssyLabour, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.DataGridView1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.BS_SubAssyOperations, System.ComponentModel.ISupportInitialize).EndInit()
        Me.Panel4.ResumeLayout(False)
        Me.Panel3.ResumeLayout(False)
        Me.Panel3.PerformLayout()
        CType(Me.BS_Assembly, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.BS_Qtn, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents Bs_part As BindingSource
    Friend WithEvents BS_Source As BindingSource
    Friend WithEvents ToolTip1 As ToolTip
    Friend WithEvents TreeView_Assy As TreeView
    Friend WithEvents Panel1 As Panel
    Friend WithEvents btn_Delete As Button
    Friend WithEvents btn_save As Button
    Friend WithEvents TextBox1 As TextBox
    Friend WithEvents Panel2 As Panel
    Friend WithEvents TabControl1 As TabControl
    Friend WithEvents TabPage1 As TabPage
    Friend WithEvents TabPage2 As TabPage
    Friend WithEvents Panel3 As Panel
    Friend WithEvents DGV_Ass2 As DataGridView
    Friend WithEvents DataGridViewComboBoxColumn1 As DataGridViewComboBoxColumn
    Friend WithEvents DataGridViewComboBoxColumn2 As DataGridViewComboBoxColumn
    Friend WithEvents PanelNewComponent As Panel
    Friend WithEvents CB_IsAssy As CheckBox
    Friend WithEvents TextBox_Name As TextBox
    Friend WithEvents Label2 As Label
    Friend WithEvents btn_add As Button
    Friend WithEvents SplitContainer1 As SplitContainer
    Friend WithEvents Bs_BOM As BindingSource
    Friend WithEvents DGV_BOM As DataGridView
    Friend WithEvents FabDS As FabDS
    Friend WithEvents SplitContainer2 As SplitContainer
    Friend WithEvents DGV_Assy As DataGridView
    Friend WithEvents BS_SubAssy As BindingSource
    Friend WithEvents SplitContainer3 As SplitContainer
    Friend WithEvents DGV_MaterialCost As DataGridView
    Friend WithEvents DGV_AssemblyCost As DataGridView
    Friend WithEvents Panel4 As Panel
    Friend WithEvents btn_saveCosting As Button
    Friend WithEvents BS_BomMaterial As BindingSource
    Friend WithEvents BS_AssyLabour As BindingSource
    Friend WithEvents TextBox_LabourCost As TextBox
    Friend WithEvents TextBox_MaterialCost As TextBox
    Friend WithEvents Label3 As Label
    Friend WithEvents Label1 As Label
    Friend WithEvents Label_AssemblyName As Label
    Friend WithEvents SaveDeletePartAssy As ContextMenuStrip
    Friend WithEvents CopyToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents PasteToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents DeleteToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents BS_Assembly As BindingSource
    Friend WithEvents TextBox_AssyCost As TextBox
    Friend WithEvents Label4 As Label
    Friend WithEvents BS_ItemsList As BindingSource
    Friend WithEvents NameDataGridViewTextBoxColumn As DataGridViewTextBoxColumn
    Friend WithEvents IsAssyDataGridViewCheckBoxColumn As DataGridViewCheckBoxColumn
    Friend WithEvents PartNameDataGridViewTextBoxColumn As DataGridViewTextBoxColumn
    Friend WithEvents QuantityDataGridViewTextBoxColumn As DataGridViewTextBoxColumn
    Friend WithEvents AssemblyName As DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn3 As DataGridViewTextBoxColumn
    Friend WithEvents SplitContainer4 As SplitContainer
    Friend WithEvents DataGridView1 As DataGridView
    Friend WithEvents BS_SubAssyOperations As BindingSource
    Friend WithEvents OperationDataGridViewTextBoxColumn As DataGridViewTextBoxColumn
    Friend WithEvents CostDataGridViewTextBoxColumn As DataGridViewTextBoxColumn
    Friend WithEvents ReportManager1 As PerpetuumSoft.Reporting.Components.ReportManager
    Friend WithEvents InlineReportSlot1 As PerpetuumSoft.Reporting.Components.InlineReportSlot
    Friend WithEvents btn_Print As Button
    Friend WithEvents BS_Qtn As BindingSource
    Friend WithEvents Label_QtnNo As Label
    Friend WithEvents DataGridViewTextBoxColumn2 As DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn4 As DataGridViewTextBoxColumn
    Friend WithEvents UnitMaterialCost As DataGridViewTextBoxColumn
    Friend WithEvents TotalCost As DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn5 As DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn6 As DataGridViewTextBoxColumn
    Friend WithEvents CalculatedCost As DataGridViewTextBoxColumn
    Friend WithEvents UnitLabourCost As DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn7 As DataGridViewTextBoxColumn
End Class
