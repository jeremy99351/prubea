Imports DataAcess.Crud

Public Class DireccionesManagement
    Private CrudDireccion As DireccionesCrudFactory


    Public Sub DireccionesManagement()
        CrudDireccion = New DireccionesCrudFactory()

    End Sub

    Public Sub Create(direccion As Entities_POJO.Direcciones)

        CrudDireccion.Create(direccion)

    End Sub


    Public Function RetrieveAll() As List(Of Entities_POJO.Direcciones)
        Dim lista As List(Of Entities_POJO.Direcciones) = CrudDireccion.RetrieveAll(Of Entities_POJO.Direcciones)
        Return lista
    End Function

    Public Function RetrieveById(direccion As Entities_POJO.Direcciones) As Entities_POJO.Direcciones
        Dim DireccionEnc As Entities_POJO.Direcciones = CrudDireccion.Retrieve(Of Entities_POJO.Direcciones)(direccion)
        Return DireccionEnc
    End Function


    Friend Sub Update(direccion As Entities_POJO.Direcciones)
        CrudDireccion.Update(direccion)
    End Sub

    Friend Sub Delete(direccion As Entities_POJO.Direcciones)
        CrudDireccion.Delete(direccion)
    End Sub

End Class
