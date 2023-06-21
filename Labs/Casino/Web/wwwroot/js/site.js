var currentParts = '';
var currentCharts = "";

$(document).ready(function () {
    if ($(".partsNav").length > 0) {
    $(".partsNav").click(function () {
        var nav = $(this);
        var dataUrl = $(this).attr("dataUrl");
        clearNav();
        $.get(dataUrl, function(html){
            $("#partsContainer").html(html);
            if (!$(nav).hasClass("active")) { $(nav).addClass('active'); }
            console.log("render parts");
            currentParts = dataUrl;
            console.log("bind events.");
            renderContainer();
        });
        
        return false;
    });
    }


    // JS
    var oneByOne = document.getElementById("one");

    oneByOne.ondragstart = (e) => {
        e.dataTransfer.effectAllowed = e.target.dataset.effect;
        console.log(e);
        source = e.target;

        console.log('ondragstart');
        console.log(e.target);
    };

    oneByOne.ondragover = function (e) {
        e.preventDefault();
    }
    oneByOne.ondragenter = function (e) {
        e.preventDefault();
    }
    oneByOne.ondrop = (e) => {
        console.log(e.source);
    };
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
            var renderContainer = $(this).attr("renderContainer");
            var dataUrl = $(this).attr("dataUrl");

            if ($("#" + renderContainer).is(":visible")) {
                if (dataUrl == currentCharts) {
                    $("#" + renderContainer).slideUp(600, 'linear');
                    if ($(this).hasClass("btn-secondary")) {
                        $(this).removeClass('btn-secondary');
                        $(this).addClass('btn-outline-secondary');
                    }
                } else {
                    $("#partsContainer .renderChartsButton").each(function () {
                        if ($(this).hasClass("btn-secondary")) {
                            $(this).removeClass("btn-secondary");
                            $(this).addClass('btn-outline-secondary');
                        }
                    });
                    currentCharts = dataUrl;
                    $("#" + renderContainer).slideDown(600, 'linear');
                    if (!$(this).hasClass("btn-secondary")) {
                        $(this).removeClass('btn-outline-secondary');
                        $(this).addClass('btn-secondary');
                    }
                }
            } else {
                currentCharts = dataUrl;
                $("#" + renderContainer).slideDown(600, 'linear');
                if (!$(this).hasClass("btn-secondary")) {
                    $(this).removeClass('btn-outline-secondary');
                    $(this).addClass('btn-secondary');
                }
            }

            bindCharts(renderElement, dataUrl);
            return false;
        });
    }

    if ($("#partsContainer .lazyLoad").length > 0) {
        $("#partsContainer .lazyLoad").each(function () {
            var box = $(this);
            var dataUrl = $(this).attr("dataUrl");
            console.log(dataUrl);

            $.get(dataUrl, function (html) {
                console.log("loaded:" + dataUrl);
                $(box).html(html);
                if ($("#partsContainer .grid").length > 0) {
                    $("#partsContainer .grid").masonry();
                }
            });
        });
    }

    if ($("#partsContainer .lazyLoadButton").length > 0) {
        $("#partsContainer .lazyLoadButton").click(function () {
            var renderElement = $(this).attr("renderElement");
            var dataUrl = $(this).attr("dataUrl");
            $("#" + renderElement).load(dataUrl);
            console.log("init container");
            InitContainer($("#" + renderElement));
            return false;
        });
    }

    if ($("#partsContainer .grid").length > 0) {
        $("#partsContainer .grid").masonry();
    }
}

function InitContainer(ele) {
    var renderCharts = $(ele).find('.renderCharts');
    console.log('renderCharts.length=' + renderCharts.length);
    if (renderCharts.length > 0) {
        renderCharts.each(function () {
            var renderElement = $(this).attr("renderElement");
            var dataUrl = $(this).attr("dataUrl");
            console.log(dataUrl + ' -> ' + renderElement);
            bindCharts(renderElement, dataUrl);
        });
    }


}

function bindButton(ele) {
    var renderElement = $(ele).attr("renderElement");
    var dataUrl = $(ele).attr("dataUrl");

    $("#" + renderElement).load(dataUrl);
    return false;
}

function bindChartsButton(ele) {
    var renderElement = $(ele).attr("renderElement");
    var dataUrl = $(ele).attr("dataUrl");

    bindCharts(renderElement, dataUrl);
    return false;
}

function bindCharts(elementId, dataUrl) {
    console.log('bind charts.');
    var chartDom = document.getElementById(elementId);
    var currentChart = echarts.init(chartDom);
    //currentChart.showLoading();
    $.get(dataUrl, function (rawData) {
        
        var diagramOption = eval("(" + rawData + ")");
        console.log(diagramOption);
        diagramOption&&currentChart.setOption(diagramOption);

        window.onresize = currentChart.resize;
    });
}

function findAny() {
    var k = $("#id").val();

    $.get('/parts/stocks/'+k, function (html) {
        $("#partsContainer").html(html);
        renderContainer();
    });

    return false;
}

