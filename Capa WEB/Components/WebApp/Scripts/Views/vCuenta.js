function vCuenta() {

    this.tblCuentaId = 'tbl_Cuenta';
    this.service = 'cuenta';
    this.ctrlActions = new ControlActions();
    this.columns ="id_cuenta,nombre,moneda,saldo";


    this.RetrieveAll = function () {
        // referencia en ControlActions , línea 15
        this.ctrlActions.FillTable(this.service, this.tblCuentaId, false);
    }

    this.ReloadTable = function () {
        this.ctrlActions.FillTable(this.service, this.tblCuentaId, true);
    }

    this.Create = function () {
        var CuentaData = {};
        // referencia en ControlActions , línea 57
        CuentaData = this.ctrlActions.GetDataForm('frmEdition');
        // referencia en ControlActions , línea 82, realiza el post al create
        this.ctrlActions.PostToAPI(this.service, CuentaData);
        this.ReloadTable();
    }

    this.Update = function () {
        var CuentaData = {};
        // referencia en ControlActions , línea 57
        CuentaData = this.ctrlActions.GetDataForm('frmEdition');
        // referencia en ControlActions , línea 95
        this.ctrlActions.PutToAPI(this.service, CuentaData);
        this.ReloadTable();
    }

    this.Delete = function () {
        var CuentaData = {};
        // referencia en ControlActions , línea 57
        CuentaData = this.ctrlActions.GetDataForm('frmEdition');
        // referencia en ControlActions , línea 108
        this.ctrlActions.DeleteToAPI(this.service, CuentaData);
        this.ReloadTable();
    }

    this.BindFields = function (data) {
        // referencia en ControlActions , línea 49
        this.ctrlActions.BindFields('frmEdition', data);
    }

}

$(document).ready(function () {

    var vcuenta = new vCuenta();
    vcuenta.RetrieveAll();

});
