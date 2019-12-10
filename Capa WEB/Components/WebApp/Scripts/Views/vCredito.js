function vCredito() {

    this.tblCreditoId = 'tbl_Credito';
    this.service = 'credito';
    this.ctrlActions = new ControlActions();
    this.columns = "idCredito,monto,taza,nombre,cuota,fechaInicio,estado,saldo";
        


    this.RetrieveAll = function () {
        // referencia en ControlActions , línea 15
        this.ctrlActions.FillTable(this.service, this.tblCreditoId, false);
    }

    this.ReloadTable = function () {
        this.ctrlActions.FillTable(this.service, this.tblCreditoId, true);
    }

    this.Create = function () {
        var CreditoData = {};
        // referencia en ControlActions , línea 57
        CreditoData = this.ctrlActions.GetDataForm('frmEdition');
        // referencia en ControlActions , línea 82, realiza el post al create
        this.ctrlActions.PostToAPI(this.service, CreditoData);
        this.ReloadTable();
    }

    this.Update = function () {
        var CreditoData = {};
        // referencia en ControlActions , línea 57
        CreditoData = this.ctrlActions.GetDataForm('frmEdition');
        // referencia en ControlActions , línea 95
        this.ctrlActions.PutToAPI(this.service, CreditoData);
        this.ReloadTable();
    }

    this.Delete = function () {
        var CreditoData = {};
        // referencia en ControlActions , línea 57
        CreditoData = this.ctrlActions.GetDataForm('frmEdition');
        // referencia en ControlActions , línea 108
        this.ctrlActions.DeleteToAPI(this.service, CreditoData);
        this.ReloadTable();
    }

    this.BindFields = function (data) {
        // referencia en ControlActions , línea 49
        this.ctrlActions.BindFields('frmEdition', data);
    }

}

$(document).ready(function () {

    var vcredito = new vCredito();
    vcredito.RetrieveAll();

});
