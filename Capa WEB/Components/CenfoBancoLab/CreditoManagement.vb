Imports DataAcces.Crud
Class CreditoManagement
    Private CrudCredito As CreditoCrudFactory


    Public Sub CreditoManagement()
        CrudCredito = New CreditoCrudFactory()

    End Sub

    Public Sub Create(credito As Entities_POJO.Credito)

        CrudCredito.Create(credito)

    End Sub


    Public Function RetrieveAll() As List(Of Entities_POJO.Credito)
        Dim lista As List(Of Entities_POJO.Credito) = CrudCredito.RetrieveAll(Of Entities_POJO.Credito)
        Return lista
    End Function

    Public Function RetrieveById(credito As Entities_POJO.Credito) As Entities_POJO.Credito
        Dim creditoEnc As Entities_POJO.Credito = CrudCredito.Retrieve(Of Entities_POJO.Credito)(credito)
        Return creditoEnc
    End Function


    Friend Sub Update(credito As Entities_POJO.Credito)
        CrudCredito.Update(credito)
    End Sub

    Friend Sub Delete(credito As Entities_POJO.Credito)
        CrudCredito.Delete(credito)
    End Sub

End Class
