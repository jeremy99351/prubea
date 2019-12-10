Imports DataAcess.Crud

Class ClienteManagement
    Private crudCliente As ClienteCrudFactory

    Public Sub ClienteManagement()
        crudCliente = New ClienteCrudFactory()
    End Sub
    Public Sub Create(cliente As Entities_POJO.Cliente)
        crudCliente.Create(cliente)
    End Sub
    Public Function RetrieveAll() As List(Of Entities_POJO.Cliente)
        Dim lista As List(Of Entities_POJO.Cliente) = crudCliente.RetrieveAll(Of Entities_POJO.Cliente)
        Return lista
    End Function

    Public Function RetrieveById(cliente As Entities_POJO.Cliente) As Entities_POJO.Cliente
        Dim clienteEnc As Entities_POJO.Cliente = crudCliente.Retrieve(Of Entities_POJO.Cliente)(cliente)
        Return clienteEnc
    End Function

    Friend Sub Update(cliente As Entities_POJO.Cliente)
        crudCliente.Update(cliente)
    End Sub
    Friend Sub Delete(cliente As Entities_POJO.Cliente)
        crudCliente.Delete(cliente)
    End Sub
End Class
