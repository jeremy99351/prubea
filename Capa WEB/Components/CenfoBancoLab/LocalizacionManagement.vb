

Imports DataAcces.Crud

Public Class LocalizacionManagement
    Private crudLocalizacion As LocalizacionCrudFactory

    Public Sub LocalizacionManagement()
        crudLocalizacion = New LocalizacionCrudFactory()
    End Sub

    Public Sub Create(l As Entities_POJO.Localizacion
                      )
        crudLocalizacion.Create(l)
    End Sub

    Public Function RetrieveAll() As List(Of Entities_POJO.Localizacion)
        Dim lista As List(Of Entities_POJO.Localizacion) = crudLocalizacion.RetrieveAll(Of Entities_POJO.Localizacion)
        Return lista
    End Function

    Public Function RetrieveById(l As Entities_POJO.Localizacion) As Entities_POJO.Localizacion
        Dim clienteEnc As Entities_POJO.Localizacion = crudLocalizacion.Retrieve(Of Entities_POJO.Localizacion)(l)
        Return clienteEnc
    End Function
    Friend Sub Update(l As Entities_POJO.Localizacion)
        crudLocalizacion.Update(l)
    End Sub
    Friend Sub Delete(l As Entities_POJO.Localizacion)
        crudLocalizacion.Delete(l)
    End Sub

End Class