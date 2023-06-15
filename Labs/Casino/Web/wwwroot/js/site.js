$(document).ready(function () {

    if ($(".renderCharts").length > 0) {
        $(".renderCharts").each(function () {
            var renderElement = $(this).attr("renderElement");
            var dataUrl = $(this).attr("dataUrl");
            alert(renderElement + "-" + dataUrl);
            bindCharts(renderElement, dataUrl);
        });
    }

    if ($(".renderChartsButton").length > 0) {
        $(".renderChartsButton").click(function () {
            var renderElement = $(this).attr("renderElement");
            var dataUrl = $(this).attr("dataUrl");

            bindCharts(renderElement, dataUrl);
        });
    }

});


function bindCharts(elementId, dataUrl) {
    var chartDom = document.getElementById(elementId);
    var currentChart = echarts.init(chartDom);

    $.get(dataUrl , function (rawData) {
        
        var diagramOption = eval("(" + rawData + ")");

        currentChart.setOption(diagramOption);
    });
}