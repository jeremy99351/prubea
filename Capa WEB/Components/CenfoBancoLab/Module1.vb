Imports System

Module Module1
    Sub Main()
        Menu()
        'MenuLocalizacion()

    End Sub

    Sub Menu()
        Try
            Dim mng As New ClienteManagement
            mng.ClienteManagement()
            Dim cliente = New Entities_POJO.Cliente()

            Dim mngCuenta As New CuentaManagement
            mngCuenta.CuentaManagement()
            Dim cuenta = New Entities_POJO.Cuenta()

            Dim mngCredito As New CreditoManagement
            mngCredito.CreditoManagement()
            Dim credito = New Entities_POJO.Credito()

            Dim mngDireccion As New DireccionesManagement
            mngDireccion.DireccionesManagement()
            Dim direccion = New Entities_POJO.Direcciones()

            Console.WriteLine("Cliente")
            Console.WriteLine("1.Registrar Cliente")
            Console.WriteLine("2.Listar Cliente")
            Console.WriteLine("3.Buscar Cliente")
            Console.WriteLine("4.Actualizar Cliente")
            Console.WriteLine("5.Eliminar Cliente")
            Console.WriteLine("Cuenta")
            Console.WriteLine("6.Registrar Cuenta")
            Console.WriteLine("7.Listar Cuenta")
            Console.WriteLine("8.Buscar Cuenta")
            Console.WriteLine("9.Actualizar Cuenta")
            Console.WriteLine("10.Eliminar Cuenta")
            Console.WriteLine("Credito")
            Console.WriteLine("11.Registrar Credito")
            Console.WriteLine("12.Listar Credito")
            Console.WriteLine("13.Buscar Credito")
            Console.WriteLine("14.Actualizar Credito")
            Console.WriteLine("15.Eliminar Credito")
            Console.WriteLine("Dirección")
            Console.WriteLine("16.Registrar Dirección")
            Console.WriteLine("17.Listar Dirección")
            Console.WriteLine("18.Buscar Dirección")
            Console.WriteLine("19.Actualizar Dirección")
            Console.WriteLine("20.Eliminar Dirección")

            Dim opcion As Integer = Console.ReadLine()

            Select Case opcion
                Case 1
                    Console.WriteLine("*********")
                    Console.WriteLine("**REGISTRAR CLIENTE**")
                    Console.WriteLine("*********")
                    Console.WriteLine("Digite Cedula, Nombre, Apellido, Fecha de Nacimiento, Edad,Estado civil y genero")
                    Console.WriteLine("Todo separado por una coma")
                    Dim info = Console.ReadLine()
                    Dim infoArray() As String = Split(info, ",")

                    cliente = New Entities_POJO.Cliente(infoArray)
                    mng.Create(cliente)
                    Console.WriteLine("Se ha creado el cliente")
                Case 2
                    Console.WriteLine("*********")
                    Console.WriteLine("***LISTAR CLIENTES***")
                    Console.WriteLine("*********")
                    Dim lstCliente = mng.RetrieveAll()
                    Dim count = 0
                    For Each c In lstCliente
                        count += 1
                        Console.WriteLine(count & " ==> " & c.GetEntityInformation())

                    Next
                Case 3
                    Console.WriteLine("*********")
                    Console.WriteLine("*Buscar por cedula***")
                    Console.WriteLine("*********")
                    Console.WriteLine("Digite la cedula que desea buscar:")
                    cliente.cedula = Console.ReadLine()
                    cliente = mng.RetrieveById(cliente)
                    If cliente IsNot Nothing Then
                        Console.WriteLine(" ==> " & cliente.GetEntityInformation())

                    End If
                Case 4
                    Console.WriteLine("*********")
                    Console.WriteLine("**  UPDATE  ***")
                    Console.WriteLine("*********")
                    Console.WriteLine("Digite la cedula que desea modificar:")
                    cliente.cedula = Console.ReadLine()
                    cliente = mng.RetrieveById(cliente)
                    If cliente IsNot Nothing Then
                        Console.WriteLine(" ==> " & cliente.GetEntityInformation())
                        Console.WriteLine("Digite el nombre, el nombre actual es: " & cliente.nombre)
                        cliente.Nombre = Console.ReadLine()
                        Console.WriteLine("Digite el apellido, el apellido actual es: " & cliente.Apellido)
                        cliente.Apellido = Console.ReadLine()
                        Console.WriteLine("Digite la edad,la edad actual es: " & cliente.edad)
                        cliente.edad = Console.ReadLine()
                        Console.WriteLine("Digite el estado civil, el estado civil actual es: " & cliente.EstadoCivil)
                        cliente.estadoCivil = Console.ReadLine()

                        mng.Update(cliente)
                        Console.WriteLine("El cliente fue modificado")
                    Else
                        Throw New Exception("El cliente no esta registrado")
                    End If

                Case 5
                    Console.WriteLine("*********")
                    Console.WriteLine("**  DELETE  ***")
                    Console.WriteLine("*********")
                    Console.WriteLine("Digite la cedula que desea eliminar:")
                    cliente.cedula = Console.ReadLine()
                    cliente = mng.RetrieveById(cliente)
                    If cliente IsNot Nothing Then
                        Console.WriteLine(" ==> " & cliente.GetEntityInformation())
                        Console.WriteLine("Eliminar? Y/N")
                        Dim delete = Console.ReadLine()
                        If delete.Equals("Y", StringComparison.CurrentCultureIgnoreCase) Then
                            mng.Delete(cliente)
                            Console.WriteLine("Cliente eliminado correctamente")

                        End If

                    Else
                        Throw New Exception("El cliente no esta registrado")

                    End If

                Case 6
                    Console.WriteLine("*********")
                    Console.WriteLine("**INSERTAR CUENTA**")
                    Console.WriteLine("*********")
                    Console.WriteLine("Digite el numero de cuenta, la cedula del cliente, moneda, saldo")
                    Console.WriteLine("Todo separado por una coma")
                    Dim info = Console.ReadLine()
                    Dim infoArray() As String = Split(info, ",")

                    cuenta = New Entities_POJO.Cuenta(infoArray)
                    mngCuenta.Create(cuenta)
                    Console.WriteLine("Se ha creado la cuenta")
                Case 7
                    Console.WriteLine("*********")
                    Console.WriteLine("***LISTAR CUENTAS***")
                    Console.WriteLine("*********")
                    Dim lstCuenta = mngCuenta.RetrieveAll()
                    Dim count = 0
                    For Each c In lstCuenta
                        count += 1
                        Console.WriteLine(count & " ==> " & c.GetEntityInformation())

                    Next
                Case 8
                    Console.WriteLine("*********")
                    Console.WriteLine("*Buscar Cuenta***")
                    Console.WriteLine("*********")
                    Console.WriteLine("Digite la cuenta que desea buscar:")
                    cuenta.idCuenta = Console.ReadLine()
                    cuenta = mngCuenta.RetrieveById(cuenta)
                    If cuenta IsNot Nothing Then
                        Console.WriteLine(" ==> " & cuenta.GetEntityInformation())

                    End If
                Case 9
                    'Funciona a medias , revisar
                    Console.WriteLine("*********")
                    Console.WriteLine("**  UPDATE CUENTA  ***")
                    Console.WriteLine("*********")
                    Console.WriteLine("Digite la cuenta que desea modificar:")
                    cuenta.idCuenta = Console.ReadLine()
                    cuenta = mngCuenta.RetrieveById(cuenta)
                    If cuenta IsNot Nothing Then
                        Console.WriteLine(" ==> " & cuenta.GetEntityInformation())
                        Console.WriteLine("Digite el número de cuenta, el número de cuenta actual es: " & cuenta.idCuenta)
                        cuenta.idCuenta = Console.ReadLine()
                        Console.WriteLine("Digite el número de cedula del cliente, el número de cedula del cliente actual es: " & cuenta.nombre)
                        cuenta.nombre = Console.ReadLine()
                        Console.WriteLine("Digite la moneda,la moneda actual es: " & cuenta.moneda)
                        cuenta.moneda = Console.ReadLine()
                        Console.WriteLine("Digite el saldo, el saldo actual es: " & cuenta.saldo)
                        cuenta.saldo = Console.ReadLine()
                        mngCuenta.Update(cuenta)
                        Console.WriteLine("La cuenta fue modificada")
                    Else
                        Throw New Exception("La cuenta no esta registrada")
                    End If


                Case 10
                    Console.WriteLine("*********")
                    Console.WriteLine("***DELETE CUENTA**")
                    Console.WriteLine("*********")
                    Console.WriteLine("Digite el id que desea eliminar:")
                    cuenta.idCuenta = Console.ReadLine()
                    cuenta = mngCuenta.RetrieveById(cuenta)
                    If cuenta IsNot Nothing Then
                        Console.WriteLine(" ==> " & cliente.GetEntityInformation())
                        Console.WriteLine("Eliminar? Y/N")
                        Dim delete = Console.ReadLine()
                        If delete.Equals("Y", StringComparison.CurrentCultureIgnoreCase) Then
                            mngCuenta.Delete(cuenta)
                            Console.WriteLine("Cuenta eliminada correctamente")

                        End If

                    Else
                        Throw New Exception("La cuenta no esta registrada")

                    End If
                Case 11
                    Console.WriteLine("*********")
                    Console.WriteLine("**INSERTAR CREDITO**")
                    Console.WriteLine("*********")
                    Console.WriteLine("Digite el id del credito,monto, tasa, nombre(cedula), cuota, fecha inicio, estado, saldo ")
                    Console.WriteLine("Todo separado por una coma")
                    Dim info = Console.ReadLine()
                    Dim infoArray() As String = Split(info, ",")

                    credito = New Entities_POJO.Credito(infoArray)
                    mngCredito.Create(credito)
                    Console.WriteLine("Se ha creado el credito")
                Case 12
                    Console.WriteLine("*********")
                    Console.WriteLine("***LISTAR CREDITOS***")
                    Console.WriteLine("*********")
                    Dim lstCreditos = mngCredito.RetrieveAll()
                    Dim count = 0
                    For Each c In lstCreditos
                        count += 1
                        Console.WriteLine(count & " ==> " & c.GetEntityInformation())

                    Next
                Case 13
                    Console.WriteLine("*********")
                    Console.WriteLine("*Buscar Credito***")
                    Console.WriteLine("*********")
                    Console.WriteLine("Digite el id que desea buscar:")
                    credito.idCredito = Console.ReadLine()
                    credito = mngCredito.RetrieveById(credito)
                    If credito IsNot Nothing Then
                        Console.WriteLine(" ==> " & credito.GetEntityInformation())

                    End If
                Case 14
                    Console.WriteLine("*********")
                    Console.WriteLine("**  UPDATE CREDITO  ***")
                    Console.WriteLine("*********")
                    Console.WriteLine("Digite el id que desea modificar:")
                    credito.idCredito = Console.ReadLine()
                    credito = mngCredito.RetrieveById(credito)
                    If credito IsNot Nothing Then
                        Console.WriteLine(" ==> " & credito.GetEntityInformation())
                        Console.WriteLine("Digite el monto, el monto actual es: " & credito.monto)
                        credito.monto = Console.ReadLine()
                        Console.WriteLine("Digite la taza,la taza actual es: " & credito.taza)
                        credito.taza = Console.ReadLine()

                        Console.WriteLine("Digite la cuota, la cuota actual es: " & credito.cuota)
                        credito.cuota = Console.ReadLine()
                        Console.WriteLine("Digite la fecha de inicio, la fecha de inicio actual es: " & credito.fechaInicio)
                        credito.fechaInicio = Console.ReadLine()
                        Console.WriteLine("Digite el estado, el estado actual es: " & credito.estado)
                        credito.estado = Console.ReadLine()
                        Console.WriteLine("Digite el saldo, el saldo actual es: " & credito.saldo)
                        credito.saldo = Console.ReadLine()
                        mngCredito.Update(credito)
                        Console.WriteLine("El credito fue modificado")
                    Else
                        Throw New Exception("El credito no esta registrado")
                    End If

                Case 15
                    Console.WriteLine("*********")
                    Console.WriteLine("***DELETE CREDITO**")
                    Console.WriteLine("*********")
                    Console.WriteLine("Digite el id que desea eliminar:")
                    credito.idCredito = Console.ReadLine()
                    credito = mngCredito.RetrieveById(credito)
                    If credito IsNot Nothing Then
                        Console.WriteLine(" ==> " & credito.GetEntityInformation())
                        Console.WriteLine("Eliminar? Y/N")
                        Dim delete = Console.ReadLine()
                        If delete.Equals("Y", StringComparison.CurrentCultureIgnoreCase) Then
                            mngCredito.Delete(credito)
                            Console.WriteLine("Credito eliminado correctamente")

                        End If

                    Else
                        Throw New Exception("El credito no esta registrado")

                    End If
                Case 16
                    Console.WriteLine("*********")
                    Console.WriteLine("**INSERTAR DIRECCION**")
                    Console.WriteLine("*********")
                    Console.WriteLine("Digite la provincia, canton, distrito y la cedula del cliente")
                    Console.WriteLine("Todo separado por una coma")
                    Dim info = Console.ReadLine()
                    Dim infoArray() As String = Split(info, ",")

                    direccion = New Entities_POJO.Direcciones(infoArray)
                    mngDireccion.Create(direccion)
                    Console.WriteLine("Se ha creado la direccion")
                Case 17
                    Console.WriteLine("*********")
                    Console.WriteLine("***LISTAR DIRECCION***")
                    Console.WriteLine("*********")
                    Dim lstDireccion = mngDireccion.RetrieveAll()
                    Dim count = 0
                    For Each c In lstDireccion
                        count += 1
                        Console.WriteLine(count & " ==> " & c.GetEntityInformation())

                    Next
                Case 18
                    Console.WriteLine("*********")
                    Console.WriteLine("*Buscar por provincia***")
                    Console.WriteLine("*********")
                    Console.WriteLine("Digite la provincia que desea buscar:")
                    direccion.Provincia = Console.ReadLine()
                    direccion = mngDireccion.RetrieveById(direccion)
                    If direccion IsNot Nothing Then
                        Console.WriteLine(" ==> " & direccion.GetEntityInformation())

                    End If
                Case 19
                    Console.WriteLine("*********")
                    Console.WriteLine("**  UPDATE DIRECCION  ***")
                    Console.WriteLine("*********")
                    Console.WriteLine("Digite la provincia que desea modificar:")
                    direccion.Provincia = Console.ReadLine()
                    direccion = mngDireccion.RetrieveById(direccion)
                    If direccion IsNot Nothing Then
                        Console.WriteLine(" ==> " & direccion.GetEntityInformation())
                        Console.WriteLine("Digite el canton, el canton actual es: " & direccion.Canton)
                        direccion.Canton = Console.ReadLine()
                        Console.WriteLine("Digite el distrito, el distrio actual es: " & direccion.Distrito)
                        direccion.Distrito = Console.ReadLine()
                        mngDireccion.Update(direccion)
                        Console.WriteLine("La direccion fue modificado")
                    Else
                        Throw New Exception("La direccion no esta registrado")
                    End If

                Case 20
                    Console.WriteLine("*********")
                    Console.WriteLine("***DELETE DIRECCION**")
                    Console.WriteLine("*********")
                    Console.WriteLine("Digite la provincia que desea eliminar:")
                    direccion.Provincia = Console.ReadLine()
                    direccion = mngDireccion.RetrieveById(direccion)
                    If direccion IsNot Nothing Then
                        Console.WriteLine(" ==> " & direccion.GetEntityInformation())
                        Console.WriteLine("Eliminar? Y/N")
                        Dim delete = Console.ReadLine()
                        If delete.Equals("Y", StringComparison.CurrentCultureIgnoreCase) Then
                            mngDireccion.Delete(direccion)
                            Console.WriteLine("Direccion eliminada correctamente")

                        End If

                    Else
                        Throw New Exception("La direccion no esta registrada")

                    End If
            End Select

        Catch ex As Exception
            Console.WriteLine("*********")
            Console.WriteLine("ERROR: " & ex.Message)
            Console.WriteLine(ex.StackTrace)
            Console.WriteLine("*********")
        Finally
            Console.WriteLine("Continue? Y/N")
            Dim moreActions As String = Console.ReadLine()
            If moreActions.Equals("Y", StringComparison.CurrentCultureIgnoreCase) Then Menu()
        End Try
    End Sub


    Sub MenuLocalizacion()
        Try
            Dim mng As New LocalizacionManagement
            mng.LocalizacionManagement()
            Dim localizacion = New Entities_POJO.Localizacion()

            Console.WriteLine("-----------------------------")
            Console.WriteLine("Opciones CRUD de Localización")
            Console.WriteLine("1.Registrar")
            Console.WriteLine("2.Listar")
            Console.WriteLine("3.Buscar")
            Console.WriteLine("4.Eliminar")
            Console.WriteLine("5.Modificar")
            Console.WriteLine("¿Que desea hacer?")
            Dim opcion As Integer = Console.ReadLine()

            Select Case opcion
                Case 1
                    Console.WriteLine("---------------------------")
                    Console.WriteLine("--INSERTAR LOCALIZACION----")
                    Console.WriteLine("---------------------------")
                    Console.WriteLine("Digite el id,cedula,tipo,valor")
                    Console.WriteLine("Todo separado por una coma")
                    Dim info = Console.ReadLine()
                    Dim infoArray() As String = Split(info, ",")

                    localizacion = New Entities_POJO.Localizacion(infoArray)
                    mng.Create(localizacion)
                    Console.WriteLine("Se ha creado la localizacion")
                Case 2
                    Console.WriteLine("---------------------------")
                    Console.WriteLine("----LISTAR LOCALIZACION----")
                    Console.WriteLine("---------------------------")
                    Dim lstLocalizacion = mng.RetrieveAll()
                    Dim count = 0
                    For Each c In lstLocalizacion
                        count += 1
                        Console.WriteLine(count & " ==> " & c.GetEntityInformation())

                    Next
                Case 3
                    Console.WriteLine("---------------------------")
                    Console.WriteLine("-------BUSCAR POR ID-------")
                    Console.WriteLine("---------------------------")
                    localizacion.cedula = Console.ReadLine()
                    localizacion = mng.RetrieveById(localizacion)
                    If localizacion IsNot Nothing Then
                        Console.WriteLine(" ==> " & localizacion.GetEntityInformation())

                    End If
                Case 4
                    Console.WriteLine("---------------------------")
                    Console.WriteLine("---ELIMINAR LONCALIZACIO---")
                    Console.WriteLine("---------------------------")
                    Console.WriteLine("Digite el id que desea eliminar:")
                    localizacion.cedula = Console.ReadLine()
                    localizacion = mng.RetrieveById(localizacion)
                    If localizacion IsNot Nothing Then
                        Console.WriteLine(" ==> " & localizacion.GetEntityInformation())
                        Console.WriteLine("Eliminar? Y/N")
                        Dim delete = Console.ReadLine()
                        If delete.Equals("Y", StringComparison.CurrentCultureIgnoreCase) Then
                            mng.Delete(localizacion)
                            Console.WriteLine("localizacion eliminada correctamente")

                        End If

                    Else
                        Throw New Exception("El credito no esta registrado")

                    End If

                Case 5
                    Console.WriteLine("*********")
                    Console.WriteLine("**  UPDATE localización  ***")
                    Console.WriteLine("*********")
                    Console.WriteLine("Digite la cedula que desea modificar:")
                    localizacion.cedula = Console.ReadLine()
                    localizacion = mng.RetrieveById(localizacion)
                    If localizacion IsNot Nothing Then
                        Console.WriteLine(" ==> " & localizacion.GetEntityInformation())
                        Console.WriteLine("Digite el tipo de localización, el tipo de localización actual es: " & localizacion.tipoLocalizacion)
                        localizacion.tipoLocalizacion = Console.ReadLine()
                        Console.WriteLine("Digite la localizacion, la localizacion actual es: " & localizacion.valor)
                        localizacion.valor = Console.ReadLine()
                        mng.Update(localizacion)
                        Console.WriteLine("La localización fue modificado")
                    Else
                        Throw New Exception("La localización no esta registrado")
                    End If
            End Select

        Catch ex As Exception
            Console.WriteLine("---------------------------")
            Console.WriteLine("ERROR: " & ex.Message)
            Console.WriteLine(ex.StackTrace)
            Console.WriteLine("---------------------------")
        Finally
            Console.WriteLine("Desea continuar? Y/N")
            Dim moreActions As String = Console.ReadLine()
            If moreActions.Equals("Y", StringComparison.CurrentCultureIgnoreCase) Then MenuLocalizacion()
        End Try
    End Sub
End Module