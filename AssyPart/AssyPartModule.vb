Module AssyPartModule

    Public _MD As magod.Util.magodData
    Private cmd As MySql.Data.MySqlClient.MySqlCommand

    Dim CurDate As Date

    Private strQtnPath As String

    Public Sub setUp(ByRef MD As magod.Util.magodData)
        _MD = MD
        cmd = MD.getCommand
        strQtnPath = _MD.getPath("QuotationDrawings")
        With cmd
            .CommandText = "SELECT CURDATE();"
            .Connection.Open()
            CurDate = .ExecuteScalar
            .Connection.Close()
        End With
    End Sub
    Public Function getCommand() As MySql.Data.MySqlClient.MySqlCommand
        Return cmd
    End Function

    Public Function getComponentSource() As BindingSource
        Dim x As New BindingSource
        x.DataSource = System.Enum.GetValues(GetType(ComponentSource))
        Return x
    End Function
    Public Function getDataAdopter() As MySql.Data.MySqlClient.MySqlDataAdapter
        Return _MD.getMySqlDataAdopter

    End Function
    Public ReadOnly Property UnitName() As String
        Get
            Return _MD.getUnitInfo.UnitName
        End Get
    End Property
End Module
