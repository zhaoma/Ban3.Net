var currentParts = '';
var currentCharts = '';
var currentCode = '';

$(document).ready(function () {
    initContainer($(document));

    $(document).dblclick(function (e) {
        console.log("dblclick")
        bindCharts('treemapContainer', '/data/Treemap');
    });
});

function clearNav() {
    $(".partsNav").each(function () {
        if ($(this).hasClass("active")) {
            $(this).removeClass("active");
        }
    });
}

function bindCheckBox() {
    if ($(".selectList").length > 0) {
        $(".selectList").each(function () {
            var chk = $(this);
            chk.bind('change', function () {
                var list = $("#dic_" + chk.attr("value"));
                if (chk.is(":checked")) {
                    list.show(300);
                } else {
                    list.hide(300);
                }
                $(list).delay(400).fadeIn(300);
                initGrid();
            });
        });
    }

    return false;
}

function initContainer(ele) {
    var renderCharts = $(ele).find('.renderCharts');
    if (renderCharts.length > 0) {
        renderCharts.each(function () {           
            var renderElement = $(this).attr("renderElement");
            var dataUrl = $(this).attr("dataUrl");
            bindCharts(renderElement, dataUrl);
            $(this).delay(200).fadeIn(300);
        });
    }

    var renderChartsButtons = $(ele).find(".renderChartsButton");
    if (renderChartsButtons.length > 0) {
        renderChartsButtons.each(function () {
            var button = $(this);
            button.bind('click', function () { return bindChartsButton(button); });
        });
    }

    var lazyLoad = $(ele).find(".lazyLoad");
    if (lazyLoad.length > 0) {
        lazyLoad.each(function () {
            var box = $(this);
            var dataUrl = $(this).attr("dataUrl");

            $.get(dataUrl, function (html) {
                $(box).html(html);

                initContainer($(box));
                initGrid();
            });
            $(box).delay(200).fadeIn(300);
        });
    }

    var lazyLoadButtons = $(ele).find(".lazyLoadButton");
    if (lazyLoadButtons.length > 0) {
        lazyLoadButtons.each(function () {
            var button = $(this);
            button.bind('click', function () { return bindButton(button); });
        });
    }

    bindCheckBox();
}

function initGrid() {
    var grids = $(".grid");
    if (grids.length > 0) {
        grids.each(function () { $(this).masonry(); });
    }
}

function bindButton(ele) {
    var renderElement = $(ele).attr("renderElement");
    var dataUrl = $(ele).attr("dataUrl");

    $("#" + renderElement).load(dataUrl);
    $.get(dataUrl, function (html) {
        $("#" + renderElement).html(html);
        $("#" + renderElement).delay(200).fadeIn(300);
        initContainer($("#" + renderElement));
        initGrid();

        if ($("#" + renderElement).parent().hasClass("hide")) {
            $("#" + renderElement).parent().removeClass("hide")
        }
        var li = $(ele).parent().parent().find(".lazyLoadButton");
        if (li.length > 0) {
            li.each(function () { $(this).removeClass('active') });
        }

        if (!$(ele).hasClass("active")) { $(ele).addClass('active'); }
    });
    return false;
}

function bindChartsButton(ele) {
    var renderElement = $(ele).attr("renderElement");
    var dataUrl = $(ele).attr("dataUrl");
    var renderContainer = $(ele).attr("renderContainer");

    if ($("#" + renderContainer).is(":visible")) {
        if (dataUrl == currentCharts) {
            $("#" + renderContainer).slideUp(600, 'linear');
        } else {
            currentCharts = dataUrl;
            $("#" + renderContainer).slideDown(600, 'linear');
        }
    } else {
        currentCharts = dataUrl;
        $("#" + renderContainer).slideDown(600, 'linear');
    }

    $(ele).delay(200).fadeIn(300);
    bindCharts(renderElement, dataUrl);

    var li = $(ele).parent().parent().find(".renderChartsButton");
    if (li.length > 0) {
        li.each(function () {
            $(this).removeClass('active');
        });
    }

    if (!$(ele).hasClass("active")) { $(ele).addClass('active'); }

    return false;
}

function bindCharts(elementId, dataUrl) {
    var chartDom = document.getElementById(elementId);

    var currentChart = echarts.getInstanceByDom(chartDom);

    if (currentChart == null) {
        currentChart = echarts.init(chartDom);
    } 
       
    currentChart.setOption({}, true);
    //currentChart.showLoading();
    $.get(dataUrl, function (rawData) {
        var diagramOption = eval("(" + rawData + ")");
        diagramOption && currentChart.setOption(diagramOption);

        window.onresize = currentChart.resize;
        initGrid();
    });

    currentChart.on('click', function (params) {
        console.log(params);
        if (params.seriesType == 'treemap') {
            showOne(currentChart, params.name);
        }
    });
}

function showOne(charts, code) {
    $.get('/data/Candlestick/' + code, function (rawData) {
        $("#oneModal").modal('show');
        var diagramOption = eval("(" + rawData + ")");
        diagramOption && charts.setOption(diagramOption);

        window.onresize = charts.resize;
    });
}

function findAny() {
    var k = $("#id").val();
    $.get('/parts/stocks/' + k, function (html) {
        $("#partsContainer").html(html);
        initContainer($("#partsContainer"));
    });

    return false;
}

function onesCodes() {
    $.ajax({
        type: "post",
        data: $("#latestSetsForm").serialize(),
        url: $("#latestSetsForm").attr("action"),
        dataType: "text",
        success: function (response) {
            $("#codesContainer").html(response);
            initContainer($("#codesContainer"));
        }
    });
    return false;
}

function viewTarget(id,ignore) {
    $.ajax({
        type: "get",
        url: "/parts/target/" + id + "?ignore=" + ignore,
        dataType: "text",
        success: function (response) {
            document.location.reload();
        }
    });
    return false;
}