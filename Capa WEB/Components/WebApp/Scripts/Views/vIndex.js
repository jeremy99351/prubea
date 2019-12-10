function vIndex() {

    this.chartId = 'myChart';
    this.service = 'cliente';
    this.ctrlActions = new ControlActions();

    this.GetDataToChart = function (initializeChartFunction) {
        //linea 122 = GetToAPI
        this.ctrlActions.GetToApi(this.service + '?type=millenials', initializeChartFunction);
    };


}
