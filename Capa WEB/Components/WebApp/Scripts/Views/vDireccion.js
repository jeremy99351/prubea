function vDireccion() {

    this.tblDireccionId = 'tbl_Direccion';
    this.service = 'direccion';
    this.ctrlActions = new ControlActions();
    this.columns = "PROVINCIA,CANTON,DISTRITO,NOMBRE";


    this.RetrieveAll = function () {
        // referencia en ControlActions , línea 15
        this.ctrlActions.FillTable(this.service, this.tblDireccionId, false);
    }

    this.ReloadTable = function () {
        this.ctrlActions.FillTable(this.service, this.tblDireccionId, true);
    }

    this.Create = function () {
        var DireccionData = {};
        // referencia en ControlActions , línea 57
        DireccionData = this.ctrlActions.GetDataForm('frmEdition');
        // referencia en ControlActions , línea 82, realiza el post al create
        this.ctrlActions.PostToAPI(this.service, DireccionData);
        this.ReloadTable();
    }

    this.Update = function () {
        var DireccionData = {};
        // referencia en ControlActions , línea 57
        DireccionData = this.ctrlActions.GetDataForm('frmEdition');
        // referencia en ControlActions , línea 95
        this.ctrlActions.PutToAPI(this.service, DireccionData);
        this.ReloadTable();
    }

    this.Delete = function () {
        var DireccionData = {};
        // referencia en ControlActions , línea 57
        DireccionData = this.ctrlActions.GetDataForm('frmEdition');
        // referencia en ControlActions , línea 108
        this.ctrlActions.DeleteToAPI(this.service, DireccionData);
        this.ReloadTable();
    }

    this.BindFields = function (data) {
        // referencia en ControlActions , línea 49
        this.ctrlActions.BindFields('frmEdition', data);
    }

}

$(document).ready(function () {

    var vdireccion = new vDireccion();
    vdireccion.RetrieveAll();

});