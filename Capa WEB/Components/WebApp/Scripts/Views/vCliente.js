function vCliente() {

    this.tblClienteId = 'tbl_Cliente';
    this.service = 'cliente';
    this.ctrlActions = new ControlActions();
    this.columns = "cedula,nombre,apellido,fechaNacimiento,edad,estadoCivil,genero";


    this.RetrieveAll = function () {
        // referencia en ControlActions , línea 15
        this.ctrlActions.FillTable(this.service, this.tblClienteId, false);
    }

    this.ReloadTable = function () {
        this.ctrlActions.FillTable(this.service, this.tblClienteId, true);
    }

    this.Create = function () {
        var ClienteData = {};
        // referencia en ControlActions , línea 57
        ClienteData = this.ctrlActions.GetDataForm('frmEdition');
        // referencia en ControlActions , línea 82, realiza el post al create
        this.ctrlActions.PostToAPI(this.service, ClienteData);
        this.ReloadTable();
    }

    this.Update = function () {
        var ClienteData = {};
        // referencia en ControlActions , línea 57
        ClienteData = this.ctrlActions.GetDataForm('frmEdition');
        // referencia en ControlActions , línea 95
        this.ctrlActions.PutToAPI(this.service, ClienteData);
        this.ReloadTable();
    }

    this.Delete = function () {
        var ClienteData = {};
        // referencia en ControlActions , línea 57
        ClienteData = this.ctrlActions.GetDataForm('frmEdition');
        // referencia en ControlActions , línea 108
        this.ctrlActions.DeleteToAPI(this.service, ClienteData);
        this.ReloadTable();
    }

    this.BindFields = function (data) {
        // referencia en ControlActions , línea 49
        this.ctrlActions.BindFields('frmEdition', data);
    }

}

$(document).ready(function () {

    var vcliente = new vCliente();
    vcliente.RetrieveAll();

});
