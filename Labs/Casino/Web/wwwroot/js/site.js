var currentParts = '';

$(document).ready(function () {
    if ($(".partsNav").length > 0) {
    $(".partsNav").click(function () {
        var nav = $(this);
        var dataUrl = $(this).attr("dataUrl");
        clearNav();
        $.get(dataUrl, function(html){
            $("#partsContainer").html(html);
            if (!$(nav).hasClass("active")) { $(nav).addClass('active'); }
            currentParts = dataUrl;
            renderContainer();
        });
        
        return false;
    });
    }
});

function clearNav() {
    $(".partsNav").each(function () {
        if ($(this).hasClass("active")) {
            $(this).removeClass("active");
	     }
    });
}

function renderContainer() {
    if ($("#partsContainer .renderCharts").length > 0) {
        $("#partsContainer .renderCharts").each(function () {
            var renderElement = $(this).attr("renderElement");
            var dataUrl = $(this).attr("dataUrl");

            bindCharts(renderElement, dataUrl);
        });
    }

    if ($("#partsContainer .renderChartsButton").length > 0) {
        $("#partsContainer .renderChartsButton").click(function () {
            var renderElement = $(this).attr("renderElement");
            var dataUrl = $(this).attr("dataUrl");

            bindCharts(renderElement, dataUrl);
        });
    }

    if ($("#partsContainer .lazyLoad").length > 0) {
        $("#partsContainer .lazyLoad").each(function () {
            var dataUrl = $(this).attr("dataUrl");
            $(this).load(dataUrl);
        });
    }
}

function bindCharts(elementId, dataUrl) {
    var chartDom = document.getElementById(elementId);
    var currentChart = echarts.init(chartDom);

    $.get(dataUrl, function (rawData) {

        var diagramOption = eval("(" + rawData + ")");

        currentChart.setOption(diagramOption);

        window.onresize = currentChart.resize;
    });
}