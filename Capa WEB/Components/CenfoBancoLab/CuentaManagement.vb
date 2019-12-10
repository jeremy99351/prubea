Imports DataAcces.Crud


Class CuentaManagement

    Private CrudCuenta As CuentaCrudFactory


    Public Sub CuentaManagement()
        CrudCuenta = New CuentaCrudFactory()

    End Sub

    Public Sub Create(cuenta As Entities_POJO.Cuenta)

        CrudCuenta.Create(cuenta)

    End Sub


    Public Function RetrieveAll() As List(Of Entities_POJO.Cuenta)
        Dim lista As List(Of Entities_POJO.Cuenta) = CrudCuenta.RetrieveAll(Of Entities_POJO.Cuenta)
        Return lista
    End Function

    Public Function RetrieveById(cuenta As Entities_POJO.Cuenta) As Entities_POJO.Cuenta
        Dim cuentaEnc As Entities_POJO.Cuenta = CrudCuenta.Retrieve(Of Entities_POJO.Cuenta)(cuenta)
        Return cuentaEnc
    End Function


    Friend Sub Update(cuenta As Entities_POJO.Cuenta)
        CrudCuenta.Update(cuenta)
    End Sub

    Friend Sub Delete(cuenta As Entities_POJO.Cuenta)
        CrudCuenta.Delete(cuenta)
    End Sub

End Class
