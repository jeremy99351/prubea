﻿function vLocalizacion() {

    this.tblLocalizacionId = 'tbl_Localizacion';
    this.service = 'localizacion';
    this.ctrlActions = new ControlActions();
    this.columns = "idLocalizacion,cedula,tipoL,valor";


    this.RetrieveAll = function () {
        // referencia en ControlActions , línea 15
        this.ctrlActions.FillTable(this.service, this.tblLocalizacionId, false);
    }

    this.ReloadTable = function () {
        this.ctrlActions.FillTable(this.service, this.tblLocalizacionId, true);
    }

    this.Create = function () {
        var LocalizacionData = {};
        // referencia en ControlActions , línea 57
        LocalizacionData = this.ctrlActions.GetDataForm('frmEdition');
        // referencia en ControlActions , línea 82, realiza el post al create
        this.ctrlActions.PostToAPI(this.service, LocalizacionData);
        this.ReloadTable();
    }

    this.Update = function () {
        var LocalizacionData = {};
        // referencia en ControlActions , línea 57
        LocalizacionData = this.ctrlActions.GetDataForm('frmEdition');
        // referencia en ControlActions , línea 95
        this.ctrlActions.PutToAPI(this.service, LocalizacionData);
        this.ReloadTable();
    }

    this.Delete = function () {
        var LocalizacionData = {};
        // referencia en ControlActions , línea 57
        LocalizacionData = this.ctrlActions.GetDataForm('frmEdition');
        // referencia en ControlActions , línea 108
        this.ctrlActions.DeleteToAPI(this.service, LocalizacionData);
        this.ReloadTable();
    }

    this.BindFields = function (data) {
        // referencia en ControlActions , línea 49
        this.ctrlActions.BindFields('frmEdition', data);
    }

}

$(document).ready(function () {

    var vlocalizacion = new vLocalizacion();
    vlocalizacion.RetrieveAll();

});
