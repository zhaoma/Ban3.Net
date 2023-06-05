$(document).ready(function () {

    //if ($(".singleStock").length > 0) {
    //    $(".singleStock").each(function () {

    //    });
    //}

});


function bindCharts(elementId, stockCode,cycle) {
    var chartDom = document.getElementById(elementId);
    var currentChart = echarts.init(chartDom);

    $.get("/home/Diagram/" + stockCode + "?cycle=" + cycle , function (rawData) {
        console.log(rawData);
        currentChart.setOption(
            (option = rawData),true
        );
    });
}