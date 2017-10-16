
Imports AssyPart
Imports magod.fab
Imports MySql.Data.MySqlClient

#Region "Assembly Items"
Public Interface IPartAssy

    Property Id As Integer
    Property BaseId As Integer
    Property Level As Integer
    Property ParentId As Integer
    Property Name As String
    Property IsAssy As Boolean
    Property ComponentList As AssemblyItemsList


    ReadOnly Property BOM As List(Of IpartBOM)
    ReadOnly Property SubAssyList As List(Of ISubAssy)
    ReadOnly Property SubAssyList(ByVal Name As String) As List(Of IPartAssy)
    ' Property BOMTable As FabDS.BOMDataTable

    ' Property SubAssyTable As FabDS.SubAssyDataTable
    Property Parent As IPartAssy

    '**** This Item is to be purchased from others
    Property Source As ComponentSource
    Property UnitMaterialCost As Double
    Property LabourCost As Double
    Function CheckIfContainsSubAssy(ByVal name As String) As Int32

    Function CheckIfContiansPart(ByVal name As String) As Int32

    Event ValueChanged()


End Interface

Public Interface IpartBOM
    Property Id As Integer
    Property AssyId As Integer
    Property PartName As String
    Property Quantity As Double
    Property UnitMaterialCost As Decimal
    ReadOnly Property TotalCost As Decimal

End Interface

Public Interface ISubAssy
    Property Id As Integer
    Property AssyId As Integer
    Property SubAssyName As String
    Property Quantity As Double
    Property UnitLabourCost As Decimal
    ReadOnly Property TotalCost As Decimal
End Interface
MustInherit Class PartAssy
    Implements IPartAssy, IEquatable(Of IPartAssy)

    Private _name As String
    Private _Id As Integer
    Private _baseId As Integer
    Private _level As Integer
    Private _parentId As Integer
    Private _isAssy As Boolean
    Private _componentsList As AssemblyItemsList
    Private _parent As IPartAssy
    Private _source As ComponentSource = ComponentSource.InHouse
    Private _materialCost As Double
    Private _labourCost As Double
    Private cmd As MySql.Data.MySqlClient.MySqlCommand
    Public Event ValueChanged() Implements IPartAssy.ValueChanged
    Private Shared counter As Int32 = -1
    Private _BomTable As FabDS.BOMDataTable
    Private _subAssyTable As FabDS.SubAssyDataTable
    Private _children As IList(Of IPartAssy)

    Protected Sub New()
        _Id = counter
        counter -= 1
    End Sub
    Public Sub New(ByVal Name As String, Optional ByRef parent As IPartAssy = Nothing)
        _name = Name
        _BomTable = New FabDS.BOMDataTable
        If Not parent Is Nothing Then
            _baseId = parent.BaseId
            _level = parent.Level + 1
            _parentId = parent.ParentId
        End If
    End Sub

#Region "Static Method"
    Public Shared Function convertToPartAssy(ByRef dr As FabDS.FabricationAssyPartsRow) As IPartAssy
        Dim partassy = New MagodPartAssyFactory().getPartAssy(dr.Name, dr.Isassy)
        With partassy
            .Id = dr.Id
            .BaseId = dr.BaseId
            .ParentId = dr.ParentId
            .Name = dr.Name
            .Level = dr.Level
            .Source = dr.Source
        End With
        Return partassy

    End Function

    Public Shared Function convertToDataRow(ByRef dr As FabDS.FabricationAssyPartsRow, ByVal partAssy As IPartAssy) As Boolean

        With dr
            .Id = partAssy.Id
            .BaseId = partAssy.BaseId
            .ParentId = partAssy.ParentId
            .Name = partAssy.Name
            .Level = partAssy.Level
            .Source = partAssy.Source
            .Isassy = partAssy.IsAssy
        End With
        Return True

    End Function

    Public Shared Function convertToAlphaNumericOnly(ByVal value As String) As String
        Dim rgx As System.Text.RegularExpressions.Regex
        rgx = New System.Text.RegularExpressions.Regex("[^a-zA-Z0-9]")
        Return rgx.Replace(value, "")
    End Function
    '    Public Static Class RegexConvert
    '{
    '    Public Static String ToAlphaNumericOnly(this String input)
    '    {
    '        Regex rgx = New Regex("[^a-zA-Z0-9]");
    '        Return rgx.Replace(input, "");
    '    }

    '    Public Static String ToAlphaOnly(this String input)
    '    {
    '        Regex rgx = New Regex("[^a-zA-Z]");
    '        Return rgx.Replace(input, "");
    '    }

    '    Public Static String ToNumericOnly(this String input)
    '    {
    '        Regex rgx = New Regex("[^0-9]");
    '        Return rgx.Replace(input, "");
    '    }
    '}

#End Region
#Region "Functions"

    Public Overrides Function Equals(obj As Object) As Boolean
        '**** This ensures only IpartAssy is compared
        If obj Is Nothing Then
            Return False
        End If
        Dim objAsPart As IPartAssy = TryCast(obj, IPartAssy)
        If objAsPart Is Nothing Then
            Return False
        Else
            Return Equals(objAsPart)
        End If
    End Function

    Public Overrides Function GetHashCode() As Integer
        Return _Id
    End Function
    Public Overloads Function Equals(other As IPartAssy) As Boolean Implements IEquatable(Of IPartAssy).Equals
        If other Is Nothing Then
            Return False
        End If
        Return (Me.Id.Equals(other.Id))
    End Function

    Private Function CheckIfContainsSubAssy(name As String) As Integer Implements IPartAssy.CheckIfContainsSubAssy
        '**** Return the Number of SubAssy
        Dim result = Aggregate item In SubAssyList()
                         Where PartAssy.convertToAlphaNumericOnly(item.SubAssyName) _
                             = PartAssy.convertToAlphaNumericOnly(name) Into gp = Sum(item.Quantity)
        Return result
    End Function

    Public Function CheckIfContiansPart(name As String) As Integer Implements IPartAssy.CheckIfContiansPart
        '**** Return the Number of Parts with This name
        Dim result = Aggregate item In BOM
                         Where PartAssy.convertToAlphaNumericOnly(item.PartName) _
                             = PartAssy.convertToAlphaNumericOnly(name) Into gp = Sum(item.Quantity)
        Return result
    End Function

#End Region

#Region "Properties"


    Public Property Id As Integer Implements IPartAssy.Id
        Get
            Return _Id
        End Get
        Set(value As Integer)
            _Id = value
        End Set
    End Property

    Public Property BaseId As Integer Implements IPartAssy.BaseId
        Get
            Return _baseId
        End Get
        Set(value As Integer)
            _baseId = value
        End Set
    End Property

    Public Property Level As Integer Implements IPartAssy.Level
        Get
            Return _level
        End Get
        Set(value As Integer)
            _level = value
        End Set
    End Property

    Public Property ParentId As Integer Implements IPartAssy.ParentId
        Get
            Return _parentId
        End Get
        Set(value As Integer)
            _parentId = value
        End Set
    End Property

    Public Property Name As String Implements IPartAssy.Name
        Get
            Return _name
        End Get
        Set(value As String)
            _name = value
        End Set
    End Property

    Public Property IsAssy As Boolean Implements IPartAssy.IsAssy
        Get
            Return _isAssy
        End Get
        Set(value As Boolean)
            _isAssy = value
        End Set
    End Property

    Public Property ComponentList As AssemblyItemsList Implements IPartAssy.ComponentList
        Get
            Return _componentsList
        End Get
        Set(value As AssemblyItemsList)
            _componentsList = value
        End Set
    End Property


    Public Property Parent As IPartAssy Implements IPartAssy.Parent
        Get
            Return _parent
        End Get
        Set(value As IPartAssy)
            _parent = value
        End Set
    End Property

    Public Overridable Property Source As ComponentSource Implements IPartAssy.Source
        Get
            Return _source
        End Get
        Set(value As ComponentSource)
            _source = value
        End Set
    End Property

    Public Property UnitMaterialCost As Double Implements IPartAssy.UnitMaterialCost
        Get
            Return _materialCost
        End Get
        Set(value As Double)
            _materialCost = value
        End Set
    End Property

    Public Property LabourCost As Double Implements IPartAssy.LabourCost
        Get
            Return _labourCost
        End Get
        Set(value As Double)
            _labourCost = value
        End Set
    End Property

    Public ReadOnly Property BOM As List(Of IpartBOM) Implements IPartAssy.BOM
        Get
            '***** Returns BOM for This Assemby
            Dim AssyBOM As New List(Of IpartBOM)
            AssyBOM.AddRange(ComponentList.getBOM)
            For Each subAssy In ComponentList
                If subAssy.IsAssy Then
                    For Each part In subAssy.BOM
                        If AssyBOM.Contains(part) Then
                            AssyBOM(AssyBOM.IndexOf(part)).Quantity += part.Quantity
                        Else
                            AssyBOM.Add(part)
                        End If
                    Next
                End If
            Next
            Return AssyBOM
        End Get
    End Property

    Public ReadOnly Property SubAssyList As List(Of ISubAssy) Implements IPartAssy.SubAssyList
        Get
            Dim SubAssyBOM As New List(Of ISubAssy)
            '*** This adds SubAssys in in Current Component List
            For Each subAssy In ComponentList.getSubAssemblies

                If SubAssyBOM.Contains(subAssy) Then
                    SubAssyBOM(SubAssyBOM.IndexOf(subAssy)).Quantity += subAssy.Quantity
                Else
                    SubAssyBOM.Add(subAssy)
                End If


            Next
            Return SubAssyBOM
        End Get
    End Property

    Public ReadOnly Property SubAssyList(ByVal Name As String) As List(Of IPartAssy) Implements IPartAssy.SubAssyList
        Get

            Return ComponentList.getSubAssemblies(Name)
        End Get
    End Property


#End Region

End Class

Class Part
    Inherits PartAssy
    Public Sub New(ByVal Name As String, Optional ByRef parent As IPartAssy = Nothing)
        Me.Name = Name
        Me.IsAssy = False
        If Not parent Is Nothing Then
            Me.BaseId = parent.BaseId
            Me.Level = parent.Level + 1
            Me.ParentId = parent.Id
        End If
    End Sub



    Public Overloads ReadOnly Property AssemblyPartList As List(Of IPartAssy)
        Get
            Return Nothing
        End Get
    End Property

End Class

Class SubAssembly
    Inherits PartAssy
    Private _operationsList As OperationsList
    ' Private _assyPartsList As List(Of IPartAssy)
    ' Private _assyChildren As IList(Of IPartAssy)
    Public Sub New(ByVal Name As String, Optional ByRef parent As IPartAssy = Nothing)
        Me.Name = Name
        Me.IsAssy = True

        Me.ComponentList = New AssemblyItemsList

        If Not parent Is Nothing Then
            Me.BaseId = parent.BaseId
            Me.Level = parent.Level + 1
            Me.ParentId = parent.Id

        End If

    End Sub

    Public Overrides Property Source As ComponentSource
        Get
            Return MyBase.Source
        End Get
        Set(value As ComponentSource)
            '****An Assembly must be fabricated InHouse or Out Sourced
            If Not (value = ComponentSource.InHouse Or value = ComponentSource.OutSourced) Then
                Throw New ArgumentException("Assemby must either be fabricated InHouse or Oursourced. If yoou are only using it add it as part")
            End If
            MyBase.Source = value
        End Set
    End Property
    Public ReadOnly Property OperationsList As OperationsList
        Get
            Return _operationsList
        End Get
    End Property


End Class



MustInherit Class FabItemsFactory
    '***** Factory for Producing Parts and Assy instances
    Protected Sub New()

    End Sub
    MustOverride Function getPartAssy(ByVal Name As String, ByVal IsAssemby As Boolean, Optional ByRef Parent As IPartAssy = Nothing) As IPartAssy
    MustOverride Function getAssemblyOperation(ByVal Name As String, ByVal ParentId As Integer) As IOperation

End Class
Class MagodPartAssyFactory
    Inherits FabItemsFactory

    Public Overrides Function getAssemblyOperation(Name As String, ParentId As Integer) As IOperation
        Return New QuotationOperation(Name, ParentId)

    End Function

    Public Overrides Function getPartAssy(Name As String, IsAssemby As Boolean, ByRef Optional Parent As IPartAssy = Nothing) As IPartAssy
        If IsAssemby Then
            Return New magod.fab.SubAssembly(Name, Parent)
        Else
            Return New magod.fab.Part(Name, Parent)
        End If

    End Function
End Class

Public Class AssemblyItemsList
    Inherits List(Of IPartAssy)
    Private IdTofind As Integer
    ' Private _listBOM As List(Of IpartBOM)
    Public Sub New()


    End Sub

    Public ReadOnly Property getBOM As List(Of IpartBOM)
        Get
            '**** This contains all Parts in this Assembly
            '**** to this we need to add Parts of all subAssy
            Dim _listBOM = New List(Of IpartBOM)
            For Each part In MyBase.ToList
                If Not part.IsAssy Then
                    '*** If Part Check and Add to BOM for this Assemby
                    Dim X As New BOM
                    X.PartName = part.Name
                    X.AssyId = part.BaseId
                    '   Console.WriteLine(X.PartName)
                    '**** Check If part Exists in the list
                    If _listBOM.Contains(X) Then
                        _listBOM(_listBOM.IndexOf(X)).Quantity += 1
                    Else
                        X.Quantity = 1
                        _listBOM.Add(X)
                    End If
                End If
            Next


            Return _listBOM
        End Get
    End Property

    Public ReadOnly Property getSubAssemblies As List(Of ISubAssy)

        Get
            '**** This contains all SubAssemblies in this Assembly
            '**** to this we need to add SubAssemblies of all subAssy
            Dim _listSubAssy = New List(Of ISubAssy)
            For Each part In MyBase.ToList
                If part.IsAssy Then
                    _listSubAssy.AddRange(part.ComponentList.getSubAssemblies)
                    '*** If Part Check and Add to BOM for this Assemby
                    Dim X As New SubAssy
                    X.SubAssyName = part.Name
                    X.AssyId = part.BaseId
                    '**** Check If part Exists in the list
                    If _listSubAssy.Contains(X) Then
                        _listSubAssy(_listSubAssy.IndexOf(X)).Quantity += 1
                    Else
                        X.Quantity = 1
                        _listSubAssy.Add(X)
                    End If

                End If
            Next


            Return _listSubAssy
        End Get
    End Property
    Public ReadOnly Property getSubAssemblies(ByVal Name As String) As List(Of IPartAssy)
        Get
            '**** This all SubAssemblies with the given name in the assembly
            '**** to this we need to add Parts of all subAssy
            Dim _listSubAssy = New List(Of IPartAssy)
            For Each part In MyBase.ToList
                If part.IsAssy And part.Name = Name Then
                    '*** If component is assemby and of same name add to list
                    _listSubAssy.Add(part)
                ElseIf part.IsAssy Then 'Other Assemblies Search for part
                    _listSubAssy.AddRange(part.ComponentList.getSubAssemblies(Name))
                End If
            Next


            Return _listSubAssy
        End Get
    End Property

    Public ReadOnly Property getComponent(ByVal Id As Integer) As IPartAssy
        Get
            '*** Search in Current List
            IdTofind = Id

            Dim partassy As IPartAssy = Me.Find(AddressOf FindID)
            '**** if Component in this list return componet
            If partassy IsNot Nothing Then
                Return partassy
            Else
                '*** Serch on Component list for the part
                Dim componetList As List(Of IPartAssy) = Me.FindAll(AddressOf findSubAssemblies)
                If componetList Is Nothing Then
                    Return Nothing
                Else
                    '*** Recursively search the componet list
                    For Each Item As IPartAssy In componetList

                        partassy = Item.ComponentList.getComponent(Id)
                        If partassy IsNot Nothing Then
                            Return partassy
                        End If
                    Next
                End If
            End If
            '**** Item with this Id is not found in any list
            Return Nothing
        End Get
    End Property
    Private Function FindID(ByVal item As IPartAssy) As Boolean
        If item.Id = IdTofind Then
            Return True
        Else
            Return False
        End If
    End Function
    Private Function findSubAssemblies(ByVal item As IPartAssy) As Boolean
        If item.IsAssy AndAlso item.ComponentList.Count > 0 Then
            Return True
        Else
            Return False
        End If
    End Function
    Private Function findAssemby(ByVal item As IPartAssy) As Boolean
        If item.IsAssy Then
            Return True
        Else
            Return False
        End If
    End Function
    Private Function findPart(ByVal item As IPartAssy) As Boolean
        If Not item.IsAssy Then
            Return True
        Else
            Return False
        End If
    End Function

    Public Class BOM
        Implements IpartBOM, IEquatable(Of IpartBOM)
        Private Shared counter As Int32 = -1
        Private _Id As Int32
        Private _BaseId As Int32
        Private _partName As String
        Private _qty As Double
        Private _materialCost As Decimal

        Public Sub New()
            _Id = counter
            counter -= 1
        End Sub

        Public Property AssyId As Integer Implements IpartBOM.AssyId
            Get

                Return _BaseId
            End Get
            Set(value As Integer)
                _BaseId = value

            End Set
        End Property

        Public Property Id As Integer Implements IpartBOM.Id
            Get
                Return _Id
            End Get
            Set(value As Integer)
                _Id = value
            End Set
        End Property

        Public Property PartName As String Implements IpartBOM.PartName
            Get
                Return _partName
            End Get
            Set(value As String)
                _partName = value

            End Set
        End Property

        Public Property Quantity As Double Implements IpartBOM.Quantity
            Get
                Return _qty
            End Get
            Set(value As Double)
                _qty = value
            End Set
        End Property

        Public Property UnitMaterialCost As Decimal Implements IpartBOM.UnitMaterialCost
            Get
                Return _materialCost
            End Get
            Set(value As Decimal)
                _materialCost = value
            End Set
        End Property

        Public ReadOnly Property TotalCost As Decimal Implements IpartBOM.TotalCost
            Get
                Return _materialCost * _qty
            End Get
        End Property

        Public Overrides Function Equals(obj As Object) As Boolean
            '**** This ensures only IpartAssy is compared
            If obj Is Nothing Then
                Return False
            End If
            Dim objAsPart As IpartBOM = TryCast(obj, IpartBOM)
            If objAsPart Is Nothing Then
                Return False
            Else
                Return Equals(objAsPart)
            End If
        End Function
        Public Overrides Function GetHashCode() As Integer
            Return _partName.GetHashCode
        End Function


        Public Overloads Function Equals(other As IpartBOM) As Boolean Implements IEquatable(Of IpartBOM).Equals
            If other Is Nothing Then
                Return False
            End If
            '**** Both Parts are considered Equal if AlfaNumeric Signature in Uppercase Matches
            Dim X = PartAssy.convertToAlphaNumericOnly(Me.PartName)
            Dim Y = PartAssy.convertToAlphaNumericOnly(other.PartName)

            Dim result As Boolean = X.ToUpper.Equals(Y.ToUpper)
            Return (result)
        End Function
    End Class

    Public Class SubAssy
        Implements ISubAssy, IEquatable(Of ISubAssy)
        Private Shared counter As Int32 = -1
        Private _Id As Int32
        Private _BaseId As Int32
        Private _partName As String
        Private _qty As Double
        Private _labourCost As Decimal

        Public Sub New()
            _Id = counter
            counter -= 1
        End Sub

        Public Property AssyId As Integer Implements ISubAssy.AssyId
            Get

                Return _BaseId
            End Get
            Set(value As Integer)
                _BaseId = value

            End Set
        End Property

        Public Property Id As Integer Implements ISubAssy.Id
            Get
                Return _Id
            End Get
            Set(value As Integer)
                _Id = value
            End Set
        End Property

        Public Property SubAssyName As String Implements ISubAssy.SubAssyName
            Get
                Return _partName
            End Get
            Set(value As String)
                _partName = value

            End Set
        End Property

        Public Property Quantity As Double Implements ISubAssy.Quantity
            Get
                Return _qty
            End Get
            Set(value As Double)
                _qty = value
            End Set
        End Property

        Public Property UnitLabourCost As Decimal Implements ISubAssy.UnitLabourCost
            Get
                Return _labourCost
            End Get
            Set(value As Decimal)
                _labourCost = value
            End Set
        End Property

        Public ReadOnly Property TotalCost As Decimal Implements ISubAssy.TotalCost
            Get
                Return _labourCost * _qty
            End Get
        End Property

        Public Overrides Function Equals(obj As Object) As Boolean
            '**** This ensures only IpartAssy is compared
            If obj Is Nothing Then
                Return False
            End If
            Dim objAsPart As ISubAssy = TryCast(obj, ISubAssy)
            If objAsPart Is Nothing Then
                Return False
            Else
                Return Equals(objAsPart)
            End If
        End Function
        Public Overrides Function GetHashCode() As Integer
            Return _partName.GetHashCode
        End Function


        Public Overloads Function Equals(other As ISubAssy) As Boolean Implements IEquatable(Of ISubAssy).Equals
            If other Is Nothing Then
                Return False
            End If
            Dim X = PartAssy.convertToAlphaNumericOnly(Me.SubAssyName)
            Dim Y = PartAssy.convertToAlphaNumericOnly(other.SubAssyName)

            Dim result As Boolean = X.ToUpper.Equals(Y.ToUpper)
            Return (result)

        End Function


    End Class

End Class

Public Enum ComponentSource
    InHouse = 0
    OutSourced = 1
    FromTrade = 2
    CustomerSupplied = 3
End Enum



#End Region

#Region "Assembly"



''' <summary>
''' These Interfaces are to be implemented to persist data 
''' to database
''' </summary>
Interface ISaveAssembly

    Function Save() As Boolean
    Function Save(ByVal component As IPartAssy) As Boolean
    Function Delete(ByRef item As IPartAssy) As Boolean
    ''' <summary>
    ''' Implement sub to summarize as the parts and fbrication subassemblies
    ''' and save it to data base
    ''' </summary>
    Sub UpDateAssyBOM_SubAssy()
    ''' <summary>
    ''' Function to check if the child subAssy being inserted into parent has 
    ''' a parent- child relation with parent anywhere in the assembly
    ''' </summary>
    ''' <param name="parent">sub assy that is to receive the child</param>
    ''' <param name="child"> sub assy that is added to parent sub assy</param>
    ''' <returns></returns>
    Function IsParentOf(ByVal parent As IPartAssy, ByVal child As IPartAssy) As Boolean
End Interface
Public Interface IAssembly
    ReadOnly Property Name As String
    ReadOnly Property LabourCost As Decimal
    ReadOnly Property MaterialCost As Decimal
    ReadOnly Property TotalUnitCost As Decimal
    ReadOnly Property BOM As FabDS.BOMDataTable
    ReadOnly Property AssemblyList As FabDS.SubAssyDataTable
    Property getAssembly As IPartAssy
    Function Save() As Boolean
    Function Save(ByVal component As IPartAssy) As Boolean
    Function Delete(ByRef item As IPartAssy) As Boolean
    ''' <summary>
    ''' Implement sub to summarize as the parts and fbrication subassemblies
    ''' and save it to data base
    ''' </summary>
    Sub UpDateAssyBOM_SubAssy()
    ''' <summary>
    ''' Function to check if the child subAssy being inserted into parent has 
    ''' a parent- child relation with parent anywhere in the assembly
    ''' </summary>
    ''' <param name="parent">sub assy that is to receive the child</param>
    ''' <param name="child"> sub assy that is added to parent sub assy</param>
    ''' <returns></returns>
    Function IsParentOf(ByVal parent As IPartAssy, ByVal child As IPartAssy) As Boolean
    Sub AddComponentsToSubAssy(ByRef ToAssy As IPartAssy, ByVal add As IPartAssy)
End Interface
''' <summary>
''' This is the Base Class for an Assembly to be fabricated
''' This is the Root and consists of Parts and SubAssemblies
''' </summary>
''' 
Public Class QuotationAssembly
    Implements IAssembly
    Private _qtnId As Integer
    Private _assyId As Integer
    Private _assyName As String
    Private assy As IPartAssy
    Public fabDs1 As New FabDS
    Private cmd As MySql.Data.MySqlClient.MySqlCommand

    Public Sub New(ByVal AssemblyName As String)
        _assyName = AssemblyName
    End Sub

    ''' <summary>
    ''' Loads the assembly from database if existing else creates new if Id =0, use Save to persist data to database
    ''' </summary>
    ''' <param name="AssyId">Unique Integer Id of the Assembly in the Data Base. If Zero create a new Assembly </param>
    Public Sub New(ByVal AssyId As Integer)
        cmd = AssyPartModule._MD.getCommand
        _assyId = AssyId
        setUpDA_Assy()
        setUpDA_Bom()
        setUpDA_SubAssy()
        loadAssembly()
    End Sub
    Public Sub New(ByVal QtnId As Integer, ByVal AssemblyName As String)
        cmd = AssyPartModule._MD.getCommand
        _qtnId = QtnId
        _assyName = AssemblyName
        setUpDA_Assy()
        setUpDA_Bom()
        setUpDA_SubAssy()
        assy = New MagodPartAssyFactory().getPartAssy(AssemblyName, True)
        Me.Save()
        '*** Add this Assembly to Assembly List for costing and production
        Dim mainAssy = fabDs1.SubAssy.NewSubAssyRow
        mainAssy.AssyID = assy.Id
        mainAssy.AssemblyName = AssemblyName
        mainAssy.Quantity = 1
        fabDs1.SubAssy.AddSubAssyRow(mainAssy)
        UpDateAssyBOM_SubAssy()
    End Sub


    Public ReadOnly Property LabourCost As Decimal Implements IAssembly.LabourCost
        Get
            If fabDs1.SubAssy.Count = 0 Then
                Return 0
            Else
                Return fabDs1.SubAssy.Compute("SUM(TotalCost)", Nothing)
            End If
        End Get
    End Property
    Public ReadOnly Property MaterialCost As Decimal Implements IAssembly.MaterialCost
        Get
            If fabDs1.BOM.Count = 0 Then
                Return 0
            Else
                Return fabDs1.BOM.Compute("SUM(TotalCost)", Nothing)
            End If
        End Get
    End Property
    Public ReadOnly Property TotalUnitCost As Decimal Implements IAssembly.TotalUnitCost
        Get
            Return LabourCost + MaterialCost
        End Get
    End Property
    Public ReadOnly Property Name As String Implements IAssembly.Name
        Get
            Return _assyName
        End Get
    End Property
#Region "Setting Up"
    Private DA_Assy As MySql.Data.MySqlClient.MySqlDataAdapter

    Private Sub setUpDA_Assy()

        DA_Assy = AssyPartModule.getDataAdopter
        With DA_Assy
            With .SelectCommand
                .CommandText = "SELECT * FROM  magodqtn.fabrication_assyparts f WHERE f.`BaseId`=@AssyId"
                .Parameters.AddWithValue("@AssyId", _assyId)
            End With
            With .DeleteCommand
                .CommandText = "DELETE FROM magodqtn.fabrication_assyparts  WHERE Id=@Id"
                .Parameters.Add("@Id", MySql.Data.MySqlClient.MySqlDbType.Int32, 20, "Id")
            End With
        End With
    End Sub

    Private DA_BOM As MySql.Data.MySqlClient.MySqlDataAdapter

    Private Sub setUpDA_Bom()
        DA_BOM = AssyPartModule.getDataAdopter
        With DA_BOM
            With .SelectCommand
                .CommandText = "SELECT * FROM magodqtn.fab_bom f WHERE  AssyID=@AssyID"
                .Parameters.AddWithValue("@AssyId", _assyId)
            End With
            With .InsertCommand
                .CommandText = "INSERT INTO magodqtn.fab_bom( AssyID, PartName, UnitMaterialCost, Quantity)
                                VALUES (@AssyID, @PartName, @UnitMaterialCost, @Quantity)"
                .Parameters.Add("@AssyID", MySql.Data.MySqlClient.MySqlDbType.Int32, 20, "AssyID")
                .Parameters.Add("@PartName", MySql.Data.MySqlClient.MySqlDbType.VarChar, 100, "PartName")
                .Parameters.Add("@UnitMaterialCost", MySql.Data.MySqlClient.MySqlDbType.Decimal, 20, "UnitMaterialCost")
                .Parameters.Add("@Quantity", MySql.Data.MySqlClient.MySqlDbType.Double, 20, "Quantity")


            End With
            With .UpdateCommand
                .CommandText = "UPDATE  magodqtn.fab_bom SET `UnitMaterialCost`=@UnitMaterialCost,
                                `Quantity` =@Quantity  WHERE Id=@Id"
                .Parameters.Add("@Id", MySql.Data.MySqlClient.MySqlDbType.Int32, 20, "Id")
                .Parameters.Add("@UnitMaterialCost", MySql.Data.MySqlClient.MySqlDbType.Decimal, 20, "UnitMaterialCost")
                .Parameters.Add("@Quantity", MySql.Data.MySqlClient.MySqlDbType.Double, 20, "Quantity")
            End With
            With .DeleteCommand
                .CommandText = "DELETE FROM magodqtn.fab_bom  WHERE Id=@Id"
                .Parameters.Add("@Id", MySql.Data.MySqlClient.MySqlDbType.Int32, 20, "Id")
            End With
        End With
    End Sub


    Private DA_SubAssy As MySql.Data.MySqlClient.MySqlDataAdapter
    Private DA_SubAssy_Operations As MySql.Data.MySqlClient.MySqlDataAdapter
    Private Sub setUpDA_SubAssy()

        '***** Sub Assemby and its Operations List
        DA_SubAssy = AssyPartModule.getDataAdopter
        With DA_SubAssy
            With .SelectCommand
                .CommandText = "SELECT * FROM magodqtn.fab_subassy f WHERE  AssyID=@AssyID"
                .Parameters.AddWithValue("@AssyId", _assyId)
            End With
            With .InsertCommand
                .CommandText = "INSERT INTO magodqtn.fab_subassy( AssyID, AssemblyName, UnitLabourCost, Quantity)
                                VALUES (@AssyID, @AssemblyName, @UnitLabourCost, @Quantity)"
                .Parameters.Add("@AssyID", MySql.Data.MySqlClient.MySqlDbType.Int32, 20, "AssyID")
                .Parameters.Add("@AssemblyName", MySql.Data.MySqlClient.MySqlDbType.VarChar, 100, "AssemblyName")
                .Parameters.Add("@UnitLabourCost", MySql.Data.MySqlClient.MySqlDbType.Decimal, 20, "UnitLabourCost")
                .Parameters.Add("@Quantity", MySql.Data.MySqlClient.MySqlDbType.Double, 20, "Quantity")
                'Id, AssyId, AssemblyName, UnitLabourCost, Quantity

            End With
            With .UpdateCommand
                .CommandText = "UPDATE  magodqtn.fab_subassy SET `UnitLabourCost`=@UnitLabourCost,
                                `Quantity` =@Quantity  WHERE Id=@Id"
                .Parameters.Add("@Id", MySql.Data.MySqlClient.MySqlDbType.Int32, 20, "Id")
                .Parameters.Add("@UnitLabourCost", MySql.Data.MySqlClient.MySqlDbType.Decimal, 20, "UnitLabourCost")
                .Parameters.Add("@Quantity", MySql.Data.MySqlClient.MySqlDbType.Double, 20, "Quantity")
            End With
            With .DeleteCommand
                .CommandText = "DELETE FROM magodqtn.fab_subassy  WHERE Id=@Id"
                .Parameters.Add("@Id", MySql.Data.MySqlClient.MySqlDbType.Int32, 20, "Id")
            End With
        End With

        '***** Sub Assembly Operations List
        'Id, SubAssyId, Operation, Cost, Duration, UOM, UOM_Quantity
        DA_SubAssy_Operations = AssyPartModule.getDataAdopter
        With DA_SubAssy_Operations
            With .SelectCommand
                .CommandText = "SELECT f1.* FROM magodqtn.fab_subassy f, magodqtn.fab_subassy_operations f1
                                WHERE  f.AssyID=@AssyID AND f1.SubAssyId=f.Id"
                .Parameters.AddWithValue("@AssyId", _assyId)
            End With
            With .InsertCommand
                .CommandText = "INSERT INTO magodqtn.fab_subassy_operations(SubAssyId, Operation, Cost, Duration, UOM, UOM_Quantity)
                                VALUES (@SubAssyId, @Operation, @Cost, @Duration, @UOM, @UOM_Quantity)"
                .Parameters.Add("@SubAssyId", MySql.Data.MySqlClient.MySqlDbType.Int32, 20, "SubAssyId")
                .Parameters.Add("@Operation", MySql.Data.MySqlClient.MySqlDbType.VarChar, 100, "Operation")
                .Parameters.Add("@Cost", MySql.Data.MySqlClient.MySqlDbType.Decimal, 20, "Cost")
                .Parameters.Add("@UOM_Quantity", MySql.Data.MySqlClient.MySqlDbType.Double, 20, "UOM_Quantity")
                .Parameters.Add("@Duration", MySql.Data.MySqlClient.MySqlDbType.VarChar, 100, "Duration")
                .Parameters.Add("@UOM", MySql.Data.MySqlClient.MySqlDbType.VarChar, 100, "UOM")

            End With
            With .UpdateCommand
                .CommandText = "UPDATE  magodqtn.fab_subassy_operations SET `Operation`=@Operation,
                                `Cost`=@Cost, `Duration`=@Duration, `UOM`=@UOM, `UOM_Quantity`=@UOM_Quantity
                                WHERE Id=@Id"
                .Parameters.Add("@SubAssyId", MySql.Data.MySqlClient.MySqlDbType.Int32, 20, "SubAssyId")
                .Parameters.Add("@Operation", MySql.Data.MySqlClient.MySqlDbType.VarChar, 100, "Operation")
                .Parameters.Add("@Cost", MySql.Data.MySqlClient.MySqlDbType.Decimal, 20, "Cost")
                .Parameters.Add("@UOM_Quantity", MySql.Data.MySqlClient.MySqlDbType.Double, 20, "UOM_Quantity")
                .Parameters.Add("@Duration", MySql.Data.MySqlClient.MySqlDbType.VarChar, 100, "Duration")
                .Parameters.Add("@UOM", MySql.Data.MySqlClient.MySqlDbType.VarChar, 100, "UOM")
                .Parameters.Add("@Id", MySql.Data.MySqlClient.MySqlDbType.Int32, 20, "Id")
            End With
            With .DeleteCommand
                .CommandText = "DELETE FROM magodqtn.fab_subassy_operations  WHERE Id=@Id"
                .Parameters.Add("@Id", MySql.Data.MySqlClient.MySqlDbType.Int32, 20, "Id")
            End With
        End With
    End Sub



    Private Sub loadAssembly()
        DA_Assy.Fill(fabDs1.FabricationAssyParts)
        DA_BOM.Fill(fabDs1.BOM)
        DA_SubAssy.Fill(fabDs1.SubAssy)
        DA_SubAssy_Operations.Fill(fabDs1.SubAssy_Operations)

        loadAssemblyModel()





    End Sub

    Private Sub loadAssemblyModel()
        '*** add The Main Assembly
        Dim base As FabDS.FabricationAssyPartsRow = fabDs1.FabricationAssyParts.FindById(_assyId)
        If base Is Nothing Then
            assy = New MagodPartAssyFactory().getPartAssy("AssemblyName", True)
            _assyId = assy.Id
        Else
            assy = New MagodPartAssyFactory().getPartAssy(base.Name, True)
            assy.Id = base.Id
            assy.BaseId = base.BaseId
            assy.Level = base.Level
            assy.ParentId = base.ParentId
            assy.Source = DirectCast([Enum].Parse(GetType(ComponentSource), base.Source), ComponentSource)
        End If

        '***** Clear all items in Component List
        assy.ComponentList.Clear()
        '**** Load Details into BaseAssembly Instance
        AddComponents(assy, CType(fabDs1.FabricationAssyParts.Copy, FabDS.FabricationAssyPartsDataTable))

        _assyName = assy.Name


    End Sub



#End Region
#Region "DataBase Handling"
    Public Function Save() As Boolean Implements IAssembly.Save
        '****** Save the partAssy, insert if not existingig
        '***** Requery the BOM and Assy List for the Assembly

        '***** Check Level
        Try

            Dim newComponent As FabDS.FabricationAssyPartsRow

            With cmd
                .Connection.Open()
                .Parameters.Clear()
                .Parameters.Add("@Id", MySql.Data.MySqlClient.MySqlDbType.Int32)
                .Parameters.Add("@ParentId", MySql.Data.MySqlClient.MySqlDbType.Int32)
                .Parameters.Add("@QtnId", MySql.Data.MySqlClient.MySqlDbType.Int32)
                .Parameters.Add("@BaseId", MySql.Data.MySqlClient.MySqlDbType.Int32)
                .Parameters.Add("@Name", MySql.Data.MySqlClient.MySqlDbType.VarChar)
                .Parameters.Add("@IsAssy", MySql.Data.MySqlClient.MySqlDbType.Int16)
                .Parameters.Add("@Level", MySql.Data.MySqlClient.MySqlDbType.Int16)
                .Parameters.Add("@Source", MySql.Data.MySqlClient.MySqlDbType.VarChar)

                '  If Me.Level = 0 Then
                '******* If Level is Zero this is  root assembly
                If assy.Id < 0 Then
                    '****** First add the root Assembly and get its ID and set it as BaseId 
                    '****** Set it as ParentId for all its children
                    .CommandText = "INSERT INTO magodqtn.fabrication_assyparts(QtnId,ParentId,Name,IsAssy,Source)
                            VALUES(@QtnId,@ParentId,@Name,@IsAssy,@Source)"
                    .Parameters("@QtnId").Value = _qtnId
                    .Parameters("@ParentId").Value = assy.ParentId
                    .Parameters("@Name").Value = assy.Name
                    .Parameters("@IsAssy").Value = assy.IsAssy
                    .Parameters("@Source").Value = assy.Source

                    .ExecuteNonQuery()
                    .CommandText = "SELECT LAST_INSERT_ID();"
                    Dim x As Int32 = .ExecuteScalar
                    assy.Id = x
                    _assyId = x
                    assy.BaseId = assy.Id
                    assy.ParentId = assy.BaseId
                    .CommandText = "UPDATE  magodqtn.fabrication_assyparts
                        SET ParentId=@ParentId,BaseId=@BaseId
                        WHERE Id=@Id"
                    .Parameters("@ParentId").Value = assy.ParentId
                    .Parameters("@BaseId").Value = assy.BaseId
                    .Parameters("@Id").Value = assy.Id

                    .ExecuteNonQuery()

                    newComponent = fabDs1.FabricationAssyParts.NewFabricationAssyPartsRow
                    PartAssy.convertToDataRow(newComponent, assy)
                    fabDs1.FabricationAssyParts.AddFabricationAssyPartsRow(newComponent)

                    '***** Update BaseId and Parent ID
                    For Each item As IPartAssy In assy.ComponentList
                        item.BaseId = assy.BaseId
                        item.ParentId = assy.Id
                        item.Level = assy.Level + 1
                        saveComponents(item)
                    Next
                Else
                    '*******Insert Parts without ID Else Save
                    .CommandText = "UPDATE  magodqtn.fabrication_assyparts
                                    SET ParentId=@ParentId,Name=@Name,IsAssy=@IsAssy, Level=@Level, BaseId=@BaseId,
                                        Source=@source
                                    WHERE @Id=Id;"

                    .Parameters("@ParentId").Value = assy.ParentId
                    .Parameters("@Name").Value = assy.Name
                    .Parameters("@IsAssy").Value = assy.IsAssy
                    .Parameters("@BaseId").Value = assy.BaseId
                    .Parameters("@Id").Value = assy.Id
                    .Parameters("@Level").Value = assy.Level
                    .Parameters("@Source").Value = assy.Level
                    .ExecuteNonQuery()
                    Dim dr = fabDs1.FabricationAssyParts.FindById(assy.Id)
                    dr.Name = assy.Name
                    dr.Isassy = assy.IsAssy
                    dr.Level = assy.Level
                    dr.BaseId = assy.BaseId
                    dr.ParentId = assy.ParentId
                    '***** Update BaseId and Parent ID
                    For Each item As IPartAssy In assy.ComponentList
                        item.BaseId = assy.BaseId
                        item.ParentId = assy.Id
                        item.Level = assy.Level + 1
                        saveComponents(item)
                    Next
                End If

                fabDs1.FabricationAssyParts.AcceptChanges()
                loadAssemblyModel()
                Me.UpDateAssyBOM_SubAssy()
            End With
        Catch ex As Exception
            MsgBox(ex.Message)
        Finally
            If Not cmd.Connection.State = ConnectionState.Closed Then
                cmd.Connection.Close()
            End If
        End Try
    End Function

    Public Function Save(ByVal component As IPartAssy) As Boolean Implements IAssembly.Save
        '****** Save the partAssy, insert if not existingig
        '***** Requery the BOM and Assy List for the Assembly

        '***** Check Level
        Try

            Dim newComponent As FabDS.FabricationAssyPartsRow

            With cmd
                .Connection.Open()
                .Parameters.Clear()
                .Parameters.Add("@Id", MySql.Data.MySqlClient.MySqlDbType.Int32)
                .Parameters.Add("@ParentId", MySql.Data.MySqlClient.MySqlDbType.Int32)
                .Parameters.Add("@BaseId", MySql.Data.MySqlClient.MySqlDbType.Int32)
                .Parameters.Add("@Name", MySql.Data.MySqlClient.MySqlDbType.VarChar)
                .Parameters.Add("@IsAssy", MySql.Data.MySqlClient.MySqlDbType.Int16)
                .Parameters.Add("@Level", MySql.Data.MySqlClient.MySqlDbType.Int16)
                .Parameters.Add("@Source", MySql.Data.MySqlClient.MySqlDbType.VarChar)

                '  If Me.Level = 0 Then
                '******* If Level is Zero this is  root assembly
                If component.Id < 0 Then
                    '****** First add the root Assembly and get its ID and set it as BaseId 
                    '****** Set it as ParentId for all its children
                    .CommandText = "INSERT INTO magodqtn.fabrication_assyparts(BaseId,ParentId,Name,IsAssy,Level,Source)
                            VALUES(@BaseId,@ParentId,@Name,@IsAssy,@Level,@Source)"
                    .Parameters("@BaseId").Value = component.BaseId
                    .Parameters("@ParentId").Value = component.ParentId
                    .Parameters("@Name").Value = component.Name
                    .Parameters("@IsAssy").Value = component.IsAssy
                    .Parameters("@Level").Value = component.Level
                    .Parameters("@Source").Value = component.Source
                    .ExecuteNonQuery()
                    .CommandText = "SELECT LAST_INSERT_ID();"
                    Dim x As Int32 = .ExecuteScalar
                    component.Id = x

                    newComponent = fabDs1.FabricationAssyParts.NewFabricationAssyPartsRow
                    PartAssy.convertToDataRow(newComponent, component)
                    fabDs1.FabricationAssyParts.AddFabricationAssyPartsRow(newComponent)

                End If

                fabDs1.FabricationAssyParts.AcceptChanges()
                loadAssemblyModel()
                Me.UpDateAssyBOM_SubAssy()
            End With
        Catch ex As Exception
            MsgBox(ex.Message)
        Finally
            If Not cmd.Connection.State = ConnectionState.Closed Then
                cmd.Connection.Close()
            End If
        End Try
    End Function

    Private Sub AddComponents(ByRef item As IPartAssy, ByVal tbl As FabDS.FabricationAssyPartsDataTable)
        If item.IsAssy Then
            Dim componentToAdd As IPartAssy
            For Each item1 As FabDS.FabricationAssyPartsRow In tbl.Select(String.Format("ParentId={0}", item.Id))
                '*** add only Items that are Not Root Assembly
                If item1.Level <> 0 Then

                    If item1.Isassy Then
                        componentToAdd = New MagodPartAssyFactory().getPartAssy(item1.Name, True, item)
                    Else
                        componentToAdd = New MagodPartAssyFactory().getPartAssy(item1.Name, False, assy)
                    End If
                    With componentToAdd
                        .Id = item1.Id
                        .IsAssy = item1.Isassy
                        .Level = item1.Level
                        .ParentId = item1.ParentId
                        .BaseId = item.BaseId
                        .Source = DirectCast([Enum].Parse(GetType(ComponentSource), item1.Source), ComponentSource)
                    End With
                    item.ComponentList.Add(componentToAdd)
                End If
            Next
            '**** Remove all items from tbl which have been added
            For Each part In item.ComponentList
                tbl.Rows.Remove(tbl.FindById(part.Id))
            Next
            '**** Accept Changes
            tbl.AcceptChanges()

            '**** add Componets to the Sub assemblies to this component list
            For Each part In item.ComponentList
                If part.IsAssy Then
                    AddComponents(part, tbl)
                End If
            Next
        End If

    End Sub

    Public Sub AddComponentsToSubAssy(ByRef ToAssy As IPartAssy, ByVal add As IPartAssy) Implements IAssembly.AddComponentsToSubAssy

        '**** add Child and its children to ToAssy
        Dim componentToAdd As IPartAssy

        If add.IsAssy Then
            componentToAdd = New MagodPartAssyFactory().getPartAssy(add.Name, True, ToAssy)
        Else
            componentToAdd = New MagodPartAssyFactory().getPartAssy(add.Name, False, ToAssy)
        End If
        ToAssy.ComponentList.Add(componentToAdd)
        Me.Save(componentToAdd)
        If add.IsAssy Then
            For Each item In add.ComponentList
                AddComponentsToSubAssy(componentToAdd, item)
            Next
        End If
    End Sub

    Public Sub addComponentsToAllSubSys(ByVal SubAssy As String, ByVal newComponent As IPartAssy)

        '***** Adds a given part to all sub assemblies with same name
        '**** for each subAssy of same name add partAssy
        '*** If the SubAssy is the Parent Then Add to it
        '*** add to the child sub assemblies
        If assy.Name.Equals(SubAssy) Then
            AddComponentsToSubAssy(assy, newComponent)
        Else
            For Each item In assy.SubAssyList(SubAssy)
                AddComponentsToSubAssy(item, newComponent)
            Next
        End If

    End Sub
    Public Function deleteComponentFromAllSubSys(ByVal SubAssy As String, ByVal toDelete As IPartAssy) As Boolean
        '**** Delete one instance of the component from all instances of SubAssy with this Name
        '*** If this is part of a SubAssy that has more than one instance
        '*** then all of them too need to be ammended accoridnigly

        '**** Get List of instances sub assemblies that have same name 
        '**** Delete First instance of toDelete

        Try
            For Each item In assy.SubAssyList(SubAssy)
                '**** Find first instance of n
                Dim delAssy = assy.ComponentList.getComponent(item.Id)
                '**** in the component list of this sub assembly find first toDelete Name
                Dim delPart = delAssy.ComponentList.First(Function(x) PartAssy.convertToAlphaNumericOnly(x.Name).Equals(PartAssy.convertToAlphaNumericOnly(toDelete.Name)))
                Delete(delPart)
            Next
            Return True
        Catch ex As Exception
            MsgBox(ex.Message)
            Return False
        End Try


    End Function
    Private Function saveComponents(ByRef item As IPartAssy)
        With cmd
            .Parameters("@ParentId").Value = item.ParentId
            .Parameters("@Name").Value = item.Name
            .Parameters("@IsAssy").Value = item.IsAssy
            .Parameters("@BaseId").Value = item.BaseId
            .Parameters("@Level").Value = item.Level
            .Parameters("@Source").Value = item.Source
            .Parameters("@Id").Value = item.Id
            If item.Id < 0 Then
                '**** Implies these are freshly added and not previously saved hence Insert this and its children
                .CommandText = "INSERT INTO magodqtn.fabrication_assyparts(ParentId,Name,Level,IsAssy,Source,BaseId)
                            VALUES(@ParentId,@Name,@Level,@IsAssy,@Source,@BaseId)"
                .ExecuteNonQuery()
                .CommandText = "SELECT LAST_INSERT_ID();"
                item.Id = .ExecuteScalar
                Dim newComponent = fabDs1.FabricationAssyParts.NewFabricationAssyPartsRow
                PartAssy.convertToDataRow(newComponent, item)
                fabDs1.FabricationAssyParts.AddFabricationAssyPartsRow(newComponent)


            Else
                .CommandText = "UPDATE  magodqtn.fabrication_assyparts
                                    SET ParentId=@ParentId,Name=@Name,IsAssy=@IsAssy, Level=@Level, BaseId=@BaseId,
                                        Source=@source
                                    WHERE @Id=Id;"

                .ExecuteNonQuery()
                Dim dr = fabDs1.FabricationAssyParts.FindById(item.Id)
                dr.Name = item.Name
                dr.Isassy = item.IsAssy
                dr.Level = item.Level
                dr.BaseId = item.BaseId
                dr.ParentId = item.ParentId
            End If
            If item.IsAssy Then
                For Each item1 As IPartAssy In item.ComponentList
                    item1.BaseId = assy.BaseId
                    item1.ParentId = item.Id
                    item1.Level = item.Level + 1
                    saveComponents(item1)
                Next
            End If


        End With
    End Function

    Public Function Delete(ByRef item As IPartAssy) As Boolean Implements IAssembly.Delete
        '*** Item can be Part or Assy
        '*** Deleting it Removes all its children from the data table

        '**** Delete This Item from assyTbl
        Try
            Dim dr = fabDs1.FabricationAssyParts.FindById(item.Id)
            If dr IsNot Nothing Then
                dr.Delete()
            End If
            '***** The Selected Part/ SubAssy have been deleted
            DA_Assy.Update(fabDs1.FabricationAssyParts)

            '***** Update Current Model to Reflect the Current Data
            loadAssemblyModel()
            Me.UpDateAssyBOM_SubAssy()
            Return True

        Catch ex As Exception
            MsgBox(ex.Message)
            Return False
        End Try
    End Function

    Private Function deleteComponents(ByRef _cmd As MySqlCommand, ByRef item As IPartAssy)
        '******* Check if Component is Not Root

        With _cmd
            If item.IsAssy Then
                For Each item1 As IPartAssy In item.ComponentList
                    deleteComponents(_cmd, item1)
                Next
                item.ComponentList.Clear()
            End If
            .Parameters("@Id").Value = item.Id
            .CommandText = "DELETE FROM  magodqtn.fabrication_assyparts WHERE @Id=Id;"
            .ExecuteNonQuery()

        End With
    End Function

    Public ReadOnly Property BOM As FabDS.BOMDataTable Implements IAssembly.BOM
        Get
            Return fabDs1.BOM
        End Get

    End Property
    Public ReadOnly Property AssemblyList As FabDS.SubAssyDataTable Implements IAssembly.AssemblyList
        Get
            Return fabDs1.SubAssy
        End Get
    End Property


    Public Sub UpDateAssyBOM_SubAssy() Implements IAssembly.UpDateAssyBOM_SubAssy
        '***** If Part Exists in Assembly Update Qty

#Region "BOM"


        For Each item In assy.BOM
            '  Console.WriteLine(String.Format("{0} , {1}, {2} ", item.PartName, item.AssyId, item.Quantity))
            Dim bomPart As FabDS.BOMRow() = fabDs1.BOM.Select(String.Format("PartName Like '{0}'", item.PartName))

            If bomPart.Length > 0 Then
                bomPart(0).Quantity = item.Quantity
            Else
                '*** add Part to List
                Dim newpart = fabDs1.BOM.NewBOMRow
                newpart.AssyID = item.AssyId
                newpart.PartName = item.PartName
                newpart.Quantity = item.Quantity
                fabDs1.BOM.AddBOMRow(newpart)
            End If

        Next

        DA_BOM.Update(fabDs1.BOM)
        fabDs1.BOM.Clear()
        DA_BOM.Fill(fabDs1.BOM)

        '***** Delete all items not in Assy but exist in BOM have to be deleted
        For Each item In fabDs1.BOM
            Dim X As New AssemblyItemsList.BOM
            X.PartName = item.PartName

            If Not assy.BOM.Contains(X) Then
                item.Delete()
            End If

        Next
        DA_BOM.Update(fabDs1.BOM)
        fabDs1.BOM.Clear()
        DA_BOM.Fill(fabDs1.BOM)
#End Region

#Region "Sub Assembly"
        For Each item In assy.SubAssyList
            '   Console.WriteLine(String.Format("{0} , {1}, {2} ", item.SubAssyName, item.AssyId, item.Quantity))
            Dim subAssy As FabDS.SubAssyRow() = fabDs1.SubAssy.Select(String.Format("AssemblyName Like '{0}'", item.SubAssyName))

            If subAssy.Length > 0 Then
                subAssy(0).Quantity = item.Quantity
            Else
                '*** add Part to List
                Dim newSubAssy = fabDs1.SubAssy.NewSubAssyRow
                newSubAssy.AssyID = item.AssyId
                newSubAssy.AssemblyName = item.SubAssyName
                newSubAssy.Quantity = item.Quantity
                fabDs1.SubAssy.AddSubAssyRow(newSubAssy)
            End If

        Next

        DA_SubAssy.Update(fabDs1.SubAssy)
        DA_SubAssy_Operations.Update(fabDs1.SubAssy_Operations)

        fabDs1.SubAssy_Operations.Clear()
        fabDs1.SubAssy.Clear()

        DA_SubAssy.Fill(fabDs1.SubAssy)
        DA_SubAssy_Operations.Fill(fabDs1.SubAssy_Operations)

        '***** Delete all items not in Assy but exist in SubAssyList have to be deleted
        For Each item In fabDs1.SubAssy
            Dim X As New AssemblyItemsList.SubAssy
            X.SubAssyName = item.AssemblyName

            If Not (assy.SubAssyList.Contains(X) Or Me.Name.Equals(item.AssemblyName)) Then
                item.Delete()
            End If

        Next
        DA_SubAssy.Update(fabDs1.SubAssy)
        DA_SubAssy_Operations.Update(fabDs1.SubAssy_Operations)

        fabDs1.SubAssy_Operations.Clear()
        fabDs1.SubAssy.Clear()

        DA_SubAssy.Fill(fabDs1.SubAssy)
        DA_SubAssy_Operations.Fill(fabDs1.SubAssy_Operations)
#End Region

        '****
    End Sub


    Public Function IsParentOf(ByVal parent As IPartAssy, ByVal child As IPartAssy) As Boolean Implements IAssembly.IsParentOf
        '*** This  Child need to be added to the parent
        '*** this Parent or its Parents cannot be smae as the child
        If PartAssy.convertToAlphaNumericOnly(parent.Name).Equals(PartAssy.convertToAlphaNumericOnly(child.Name)) Then
            Return True
        ElseIf parent.ParentId = assy.Id Then
            '*** Iterate till root is reached
            Return False
        Else
            Dim X = assy.ComponentList.getComponent(parent.ParentId)
            Return IsParentOf(X, child)

        End If
    End Function
#End Region
#Region "Properties"
    Public Property getAssembly As IPartAssy Implements IAssembly.getAssembly
        Get
            Return assy
        End Get
        Set(value As IPartAssy)
            assy = value
        End Set
    End Property


#End Region
End Class
#End Region

#Region "Operations and Processe"


Public Enum UOM
    TimeInMinutes = 0
    TimeInHours = 1
    LengthInMeters = 2
    LengthInMm = 3
    WightInKg = 4
    WeightInGram = 5

End Enum
Public Interface IOperation
    Property Id As Integer
    ''' <summary>
    ''' Every Operation Must belong to some Sub Assy
    ''' </summary>
    ''' <returns></returns>
    Property ParentId As Integer
    Property OpName As String
    Property CycleTime As TimeSpan
    Property OpCost As Decimal
    Property UOM As UOM
    Property QuantityInUOM As Double

End Interface

MustInherit Class Operation
    Implements IOperation

    Private _id As Integer
    Private _name As String
    Private _Cost As Decimal
    Private _duration As TimeSpan
    Private _uom As UOM
    Private _uomQty As Double
    Private Shared counter As Integer = -1

    Public Sub New()
        _id = counter
        counter -= 1
    End Sub

    Public Property OpCost As Decimal Implements IOperation.OpCost
        Get
            Return _Cost
        End Get
        Set(value As Decimal)
            _Cost = value
        End Set
    End Property

    Public Property OpName As String Implements IOperation.OpName
        Get
            Return _name
        End Get
        Set(value As String)
            _name = value
        End Set
    End Property

    Public Property CycleTime As TimeSpan Implements IOperation.CycleTime
        Get
            Return _duration
        End Get
        Set(value As TimeSpan)
            _duration = value
        End Set
    End Property

    Public Property Id As Integer Implements IOperation.Id
        Get
            Return _id
        End Get
        Set(value As Integer)
            _id = value
        End Set
    End Property

    Public Property ParentId As Integer Implements IOperation.ParentId
        Get
            Throw New NotImplementedException()
        End Get
        Set(value As Integer)
            Throw New NotImplementedException()
        End Set
    End Property

    Public Property UOM As UOM Implements IOperation.UOM
        Get
            Return _uom
        End Get
        Set(value As UOM)
            _uom = value
        End Set
    End Property

    Public Property QuantityInUOM As Double Implements IOperation.QuantityInUOM
        Get
            Return _uomQty
        End Get
        Set(value As Double)
            _uomQty = value
        End Set
    End Property
End Class
Class QuotationOperation
    Inherits Operation
    Private _Id As Integer
    Private _qtnSubAssyId As Integer

    Public Sub New(ByRef Name As String, ByVal ParentId As Integer)
        Me.OpName = Name
        Me.ParentId = ParentId
    End Sub
End Class

Public Class OperationsList
    Inherits List(Of IOperation)

End Class
#End Region