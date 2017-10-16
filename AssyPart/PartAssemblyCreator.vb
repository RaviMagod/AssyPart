Imports PerpetuumSoft.Reporting.Components

Public Class PartAssemblyCreator
    Private QtnId As Integer
    Private assyId As Integer
    Private assembly As QuotationAssembly
    Private component As IPartAssy
    Private selctedNode As TreeNode
    Private NodeSelectedToCopyDeletePaste As TreeNode
    Private selectedComponent As IPartAssy
    Private treeNodeLevel As Integer
    Private qtn As magod.Qtn



    Public Sub New()

        ' This call is required by the designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.
        Me.Text = "Magod Laser : Fabrication Assembly DisAggregator Form"
        AssyPartModule.setUp(New Util.magodData(Application.StartupPath, "Sales", "sales"))
        '   AssyPartModule.setUp()
        assyId = 854
        loadAssembly(assyId)
        BS_Assembly.DataSource = assembly
        Label_AssemblyName.Text = assembly.getAssembly.Name



    End Sub

    Public Sub New(ByVal _qtnId As Integer, ByRef MD As magod.Util.magodData)

        ' This call is required by the designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.
        Me.Text = "Magod Laser : Fabrication Assembly DisAggregator Form"

        QtnId = _qtnId
        AssyPartModule.setUp(MD)
        '***** Get the Assy ID Created for this QtnList

        With getCommand()
            .Parameters.Clear()
            .Parameters.AddWithValue("@QtnId", QtnId)
            .CommandText = "SELECT Id FROM magodqtn.fabrication_assyparts WHERE QtnId=@QtnId"
            .Connection.Open()
            Dim X As Int32 = .ExecuteScalar

            If X = 0 Then
                .CommandText = "SELECT q.`Name` FROM magodqtn.qtn_itemslist q WHERE q.`ID`=@QtnId"
                Dim assyName = .ExecuteScalar
                assembly = New QuotationAssembly(QtnId, assyName)
                assyId = assembly.getAssembly.Id
            Else
                assyId = X
            End If
            .Connection.Close()
        End With
        '  assyId = 440
        loadAssembly(assyId)
        BS_Assembly.DataSource = assembly
        Label_AssemblyName.Text = assembly.getAssembly.Name


    End Sub

    Public Sub New(ByVal _qtnId As Integer, ByRef MD As magod.Util.magodData, ByVal _qtn As magod.Qtn)

        ' This call is required by the designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.
        Me.Text = "Magod Laser : Fabrication Assembly DisAggregator Form"
        qtn = _qtn
        Label_QtnNo.Text = String.Format("Quotation No : {0}", qtn.QtnNo)
        QtnId = _qtnId
        AssyPartModule.setUp(MD)
        '***** Get the Assy ID Created for this QtnList

        With getCommand()
            .Parameters.Clear()
            .Parameters.AddWithValue("@QtnId", QtnId)
            .CommandText = "SELECT Id FROM magodqtn.fabrication_assyparts WHERE QtnId=@QtnId"
            .Connection.Open()
            Dim X As Int32 = .ExecuteScalar

            If X = 0 Then
                .CommandText = "SELECT q.`Name` FROM magodqtn.qtn_itemslist q WHERE q.`ID`=@QtnId"
                Dim assyName = .ExecuteScalar
                assembly = New QuotationAssembly(QtnId, assyName)
                assyId = assembly.getAssembly.Id
            Else
                assyId = X
            End If
            .Connection.Close()
        End With
        '  assyId = 440
        loadAssembly(assyId)
        BS_Assembly.DataSource = assembly
        Label_AssemblyName.Text = assembly.getAssembly.Name


    End Sub
#Region "Setting Up"


    Private Sub loadAssembly(ByVal Id As Integer)
        assembly = New QuotationAssembly(Id)
        assembly.getAssembly = assembly.getAssembly
        component = assembly.getAssembly
        Label_AssemblyName.Text = assembly.getAssembly.Name
        setStatus()

        Bs_part.DataSource = component
        Bs_part.ResetBindings(True)
        setComponentTree()

        Bs_BOM.DataSource = component.BOM
        BS_SubAssy.DataSource = component.SubAssyList

        BS_BomMaterial.DataSource = assembly.BOM
        BS_AssyLabour.DataSource = assembly.AssemblyList

        BS_Qtn.DataSource = qtn

    End Sub

#End Region

#Region "UserInteraction"
    Private Sub TreeView_Assy_NodeMouseDoubleClick(sender As Object, e As TreeNodeMouseClickEventArgs) Handles TreeView_Assy.NodeMouseDoubleClick
        Dim goToComponent As IPartAssy
        treeNodeLevel = e.Node.Level
        If assembly.getAssembly.BaseId = CInt(e.Node.Name) Then
            goToComponent = assembly.getAssembly
        Else
            goToComponent = assembly.getAssembly.ComponentList.getComponent(e.Node.Name)
        End If

        If goToComponent Is Nothing Then
            '  MsgBox("Such part does not exist")
        Else
            '   MsgBox("Part Found")
            component = goToComponent
            setStatus()
            Bs_part.DataSource = component
            Bs_part.ResetBindings(True)
            selctedNode = e.Node

            refreshBOM()
        End If
    End Sub

    Private Sub btn_add_Click(sender As Object, e As EventArgs) Handles btn_add.Click


        Try

            '*** Check name length
            If Me.TextBox_Name.TextLength = 0 Then
                MsgBox("Enter Name of Part/ Assembly")
            ElseIf CB_IsAssy.Checked AndAlso assembly.getAssembly.CheckIfContiansPart(Me.TextBox_Name.Text) > 0 Then
                '**** A Part of This name already exists
                MsgBox(String.Format("Part with name {0} already Exists, Choose another Unique Name", Me.TextBox_Name.Text))

            ElseIf Not CB_IsAssy.Checked AndAlso assembly.getAssembly.CheckIfContainsSubAssy(Me.TextBox_Name.Text) > 0 Then
                '**** A Sub Assembly of This name already exists
                MsgBox(String.Format("Sub Assembly with name {0} already Exists, Choose another Unique Name", Me.TextBox_Name.Text))

            ElseIf (CB_IsAssy.Checked AndAlso assembly.getAssembly.CheckIfContainsSubAssy(Me.TextBox_Name.Text) > 0) Then
                '****** Condition for adding new Assembly is that there should not be similar subAssembly in the Base Assembly
                MsgBox(String.Format("Sub Assembly {0} already exists. {1}If you want to add this sub assemby Right Click on the tree, Copy and Paste", PartAssy.convertToAlphaNumericOnly(Me.TextBox_Name.Text), Environment.NewLine))

            ElseIf (assembly.getAssembly.CheckIfContainsSubAssy(component.Name) > 1) Then
                '****** Condition for adding Part is that if the Base assembly contains this Sub Assembly
                '**** all Components will be added with this part
                'If (MsgBox(String.Format("Do you wish to add {0} to all '{1}' SubAssemblies? ", Me.TextBox_Name.Text, component.Name), vbYesNo)) = MsgBoxResult.Yes Then
                Dim newX As IPartAssy = New MagodPartAssyFactory().getPartAssy(Trim(Me.TextBox_Name.Text), Me.CB_IsAssy.Checked, component)

                '**** for each subAssy of same name add partAssy
                assembly.addComponentsToAllSubSys(component.Name, newX)
                setComponentTree()
                ' End If
            Else
                Dim newX As IPartAssy = New MagodPartAssyFactory().getPartAssy(Trim(Me.TextBox_Name.Text), Me.CB_IsAssy.Checked, component)

                newX.Source = ComponentSource.InHouse
                component.ComponentList.Add(newX)
                assembly.Save(newX)
                refreshBOM()
                addassyNode(newX)

            End If
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
        RefreshAssyCost()
    End Sub

    Private Sub btn_save_Click(sender As Object, e As EventArgs) Handles btn_save.Click
        '***** Save The Assembly , BOM and SubAssy

        assembly.Save()
        setComponentTree()
        MsgBox("Assembly details saved")
    End Sub

    Private Sub btn_Delete_Click(sender As Object, e As EventArgs) Handles btn_Delete.Click
        If assembly.getAssembly.Id = component.Id Then
            MsgBox("Cannot Delete Main Assembly Here")
            Exit Sub
        End If
        Dim name As String = component.Name
        If MsgBox(String.Format("Do you wish to delete {0} and all Parts/ Sub Assemblies under it", name), vbYesNo) = MsgBoxResult.Yes Then
            '*** Shift Selected Component to Parent
            '**** Delete Component and its children
            DeleteComponent(component)
            MsgBox(String.Format("{0} Deleted", name))

        End If
        RefreshAssyCost()
    End Sub



    Private Sub SaveDeletePartAssy_ItemClicked(sender As Object, e As ToolStripItemClickedEventArgs) Handles SaveDeletePartAssy.ItemClicked
        If TreeView_Assy.SelectedNode Is Nothing Then
            MsgBox("Selected the Part/ Assy")
            Exit Sub
        End If
        Select Case e.ClickedItem.Text
            Case "Copy"
                NodeSelectedToCopyDeletePaste = TreeView_Assy.SelectedNode
                If MsgBox(String.Format(" Copy {0} ?", NodeSelectedToCopyDeletePaste.Text), MsgBoxStyle.YesNo) = MsgBoxResult.Yes Then
                    selectedComponent = assembly.getAssembly.ComponentList.getComponent(CInt(NodeSelectedToCopyDeletePaste.Name))
                End If
            Case "Paste"
                If selectedComponent Is Nothing Then
                    MsgBox("Select SubAssy or Part to Paste")
                    Exit Sub
                End If
                NodeSelectedToCopyDeletePaste = TreeView_Assy.SelectedNode
                If MsgBox(String.Format(" Paste {0}  Into {1}?", selectedComponent.Name, NodeSelectedToCopyDeletePaste.Text), MsgBoxStyle.YesNo) = MsgBoxResult.Yes Then
                    Dim PasteTo As IPartAssy
                    If assembly.getAssembly.Id = CInt(NodeSelectedToCopyDeletePaste.Name) Then
                        PasteTo = assembly.getAssembly
                    Else
                        PasteTo = assembly.getAssembly.ComponentList.getComponent(CInt(NodeSelectedToCopyDeletePaste.Name))
                    End If
                    If PasteTo.IsAssy Then
                        '**** Check for Cyclical Refrence
                        If selectedComponent.IsAssy Then
                            If assembly.IsParentOf(PasteTo, selectedComponent) Then
                                MsgBox("Cyclical refrence error, cannot add parent to child assembly")
                                Exit Sub
                            Else
                                assembly.addComponentsToAllSubSys(PasteTo.Name, selectedComponent)
                            End If
                        Else

                            '***** If the count of SubAssy is more than one this part has to be added to all subAssemblies with this name
                            assembly.addComponentsToAllSubSys(PasteTo.Name, selectedComponent)

                        End If

                        '  Dim cmd = AssyPartModule.getCommand
                        assembly.Save()
                        setComponentTree()
                    Else
                        MsgBox("Cannot Add Part/ Sub Assembly to a Part")
                    End If


                End If
            Case "Delete"
                NodeSelectedToCopyDeletePaste = TreeView_Assy.SelectedNode
                If MsgBox(String.Format(" Delete {0} ?", NodeSelectedToCopyDeletePaste.Text), MsgBoxStyle.YesNo) = MsgBoxResult.Yes Then

                    DeleteComponent(assembly.getAssembly.ComponentList.getComponent(CInt(NodeSelectedToCopyDeletePaste.Name)))

                End If
        End Select
        refreshBOM()
        RefreshAssyCost()
    End Sub

    Private Sub TreeView_Assy_AfterSelect(sender As Object, e As TreeViewEventArgs) Handles TreeView_Assy.AfterSelect
        Dim goToComponent As IPartAssy
        treeNodeLevel = e.Node.Level
        If assembly.getAssembly.BaseId = CInt(e.Node.Name) Then
            goToComponent = assembly.getAssembly

        Else
            goToComponent = assembly.getAssembly.ComponentList.getComponent(e.Node.Name)
        End If


        If Not goToComponent Is Nothing Then
            component = goToComponent
            setStatus()
            Bs_part.DataSource = component
            Bs_part.ResetBindings(True)
            selctedNode = e.Node

            refreshBOM()
        End If
    End Sub

    Private Sub btn_saveCosting_Click(sender As Object, e As EventArgs) Handles btn_saveCosting.Click
        '****** Save Assy Parts before updating BOM

        assembly.UpDateAssyBOM_SubAssy()
        MsgBox("Costing Information Saved")
    End Sub


#End Region


#Region "DataHandling"


    Private Sub RefreshAssyCost()
        '***** 
        BS_BomMaterial.EndEdit()
        BS_AssyLabour.EndEdit()

        'assembly.getAssembly.UnitMaterialCost = assembly.getAssembly.BOMTable.Compute("Sum(TotalCost)", Nothing)
        'assembly.getAssembly.LabourCost = assembly.getAssembly.SubAssyTable.Compute("Sum(TotalCost)", Nothing)
        TextBox_LabourCost.DataBindings("Text").ReadValue()
        TextBox_MaterialCost.DataBindings("Text").ReadValue()
        TextBox_AssyCost.DataBindings("Text").ReadValue()
    End Sub
    Private Sub DeleteComponent(ByVal partAssytoDelete As IPartAssy)
        '**** Proceed  inly if not null
        If partAssytoDelete Is Nothing Then Exit Sub

        If partAssytoDelete.Id = partAssytoDelete.ParentId Then
            MsgBox("Main Assembly Cannot be deleted")
        End If
        '**** as soon as the Component is Deleted
        '*** Shift Focus to its parent

        Dim parentComponent As IPartAssy
        If partAssytoDelete.ParentId = assembly.getAssembly.Id Then
            parentComponent = assembly.getAssembly
            assembly.Delete(partAssytoDelete)
        Else
            parentComponent = assembly.getAssembly.ComponentList.getComponent(partAssytoDelete.ParentId)
            assembly.deleteComponentFromAllSubSys(parentComponent.Name, partAssytoDelete)
        End If


        '  If assembly.Delete(partAssytoDelete) Then
        assembly.getAssembly = assembly.getAssembly


        If parentComponent.Id = assembly.getAssembly.Id Then
            component = assembly.getAssembly
            treeNodeLevel = 0
        Else
            component = assembly.getAssembly.ComponentList.getComponent(parentComponent.Id)
            treeNodeLevel -= 1
        End If

        setComponentTree()
        setStatus()
        Bs_part.DataSource = component
        Bs_part.ResetBindings(True)

        refreshBOM()




    End Sub



    Private Sub setComponentTree()
        '****** Set the assy component tree afresh
        Me.TreeView_Assy.Nodes.Clear()

        If assembly.getAssembly IsNot Nothing Then
            With assembly.getAssembly
                Dim Base As New TreeNode(.Name)
                Base.BackColor = Color.Navy
                Base.ForeColor = Color.White
                Base.Name = .Id
                Me.TreeView_Assy.Nodes.Add(Base)
                selctedNode = Base
                For Each item As IPartAssy In .ComponentList.OrderBy(Function(x) x.IsAssy).ThenBy(Function(x) x.Name)
                    addassyNode(item)
                Next
                selctedNode = Base
            End With

            Me.TreeView_Assy.Refresh()
            Me.TreeView_Assy.ExpandAll()
            ' ExpandToLevel(TreeView_Assy.Nodes, treeNodeLevel + 1)
        End If
    End Sub

    Private Sub ExpandToLevel(ByRef Nodes As TreeNodeCollection, ByVal level As Integer)
        If level > 0 Then
            For Each node As TreeNode In Nodes
                node.Expand()
                ExpandToLevel(Nodes, level - 1)
            Next
        End If

    End Sub

    Private Sub addassyNode(ByVal item As IPartAssy)
        Dim newNode As New TreeNode(item.Name)
        newNode.Name = item.Id
        If item.IsAssy Then
            newNode.ForeColor = Color.Coral
        Else
            newNode.ForeColor = Color.Green
        End If
        selctedNode.Nodes.Add(newNode)
        If item.IsAssy Then
            Dim oldNode = selctedNode
            selctedNode = newNode
            For Each item1 As IPartAssy In item.ComponentList
                addassyNode(item1)
            Next
            selctedNode = oldNode
        End If
        Me.TreeView_Assy.Refresh()
    End Sub

    Private Sub setStatus()

        If component.IsAssy Then
            Me.PanelNewComponent.Enabled = True
        Else
            Me.PanelNewComponent.Enabled = False
        End If
    End Sub

    Private Sub refreshBOM()

        Bs_part.ResetBindings(True)

        If component.IsAssy Then
            Bs_BOM.DataSource = component.BOM
            BS_SubAssy.DataSource = component.SubAssyList
        Else
            Bs_BOM.DataSource = Nothing
            BS_SubAssy.DataSource = Nothing
        End If

    End Sub

    Private Function CheckForCircularRefrence(ByVal Name As String) As Boolean
        '**** Check if this  sub assembly has a parent at any level with same name


    End Function



    Private Sub DGV_AssemblyCost_CellValidated(sender As Object, e As DataGridViewCellEventArgs) Handles DGV_AssemblyCost.CellValidated
        If DGV_AssemblyCost.Columns(e.ColumnIndex).Name = "UnitLabourCost" Then
            BS_AssyLabour.EndEdit()
            RefreshAssyCost()
        End If
    End Sub

    Private Sub DGV_MaterialCost_CellValidated(sender As Object, e As DataGridViewCellEventArgs) Handles DGV_MaterialCost.CellValidated
        If DGV_MaterialCost.Columns(e.ColumnIndex).Name = "UnitMaterialCost" Then
            BS_BomMaterial.EndEdit()
            RefreshAssyCost()
        End If
    End Sub



    Private Sub InlineReportSlot1_GetReportParameter(sender As Object, e As GetReportParameterEventArgs) Handles InlineReportSlot1.GetReportParameter
        e.Parameters("unitName").Value = UnitName
        e.Parameters("qtnType").Value = qtn.QtnType
        e.Parameters("qtnNo").Value = qtn.QtnNo
    End Sub

    Private Sub btn_Print_Click(sender As Object, e As EventArgs) Handles btn_Print.Click
        assembly.UpDateAssyBOM_SubAssy()
        MsgBox("Costing Information Saved")
        ' Me.InlineReportSlot1.DesignTemplate()
        Me.InlineReportSlot1.Prepare()
        Using preViewForm As New PerpetuumSoft.Reporting.View.PreviewForm(InlineReportSlot1)
            preViewForm.WindowState = System.Windows.Forms.FormWindowState.Maximized
            preViewForm.ShowDialog()
        End Using
    End Sub

#End Region

End Class