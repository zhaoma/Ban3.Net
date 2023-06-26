var currentParts = '';
var currentCharts = "";

$(document).ready(function () {
    initContainer('#navIcons');
});

function clearNav() {
    $(".partsNav").each(function () {
        if ($(this).hasClass("active")) {
            $(this).removeClass("active");
        }
    });
}

function initDragdrop() {
    console.log('initDragdrop');

    var draggableElements = document.querySelector('.draggable');
    console.log(draggableElements);
    var oneByOne = document.getElementById("one");

    draggableElements.ondragstart = (e) => {
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
}

function initContainer(ele) {
    var renderCharts = $(ele).find('.renderCharts');
    if (renderCharts.length > 0) {
        renderCharts.each(function () {           
            var renderElement = $(this).attr("renderElement");
            var dataUrl = $(this).attr("dataUrl");
            bindCharts(renderElement, dataUrl);
        });
    }

    var renderChartsButtons = $(ele).find(".renderChartsButton");
    if (renderChartsButtons.length > 0) {
        renderChartsButtons.each(function () {
            var button = $(this);
            button.bind('click', function () {return bindChartsButton(button); });
        });
    }

    var lazyLoad = $(ele).find(".lazyLoad");
    console.log('lazyLoad.length=' + lazyLoad.length);
    if (lazyLoad.length > 0) {
        lazyLoad.each(function () {
            var box = $(this);
            var dataUrl = $(this).attr("dataUrl");

            $.get(dataUrl, function (html) {
                $(box).html(html);
                $(box).delay(500);

                initGrid();

                initContainer($(box));
            });
        });
    }

    var lazyLoadButtons = $(ele).find(".lazyLoadButton");
    console.log('lazyLoadButtons.length=' + lazyLoadButtons.length);
    if (lazyLoadButtons.length > 0) {
        lazyLoadButtons.each(function () {
            var button = $(this);
            button.bind('click', function () { return bindButton(button); });
        });
    }
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
        console.log("html render over.")
        initContainer($("#" + renderElement));

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

    bindCharts(renderElement, dataUrl);

    var renderContainer = $(this).attr("renderContainer");

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

    var li = $(ele).parent().parent().find(".renderChartsButton");
    if (li.length > 0) {
        li.each(function () { $(this).removeClass('active') });
    }

    if (!$(ele).hasClass("active")) { $(ele).addClass('active'); }

    return false;
}

function bindCharts(elementId, dataUrl) {
    var chartDom = document.getElementById(elementId);

    var currentChart = echarts.getInstanceByDom(chartDom);

    if (currentChart == null) {
        currentChart = echarts.init(chartDom);
    } else {
        //currentChart.dispose();
    }
       
    currentChart.setOption({}, true);
    //currentChart.showLoading();
    $.get(dataUrl, function (rawData) {

        var diagramOption = eval("(" + rawData + ")");
        diagramOption && currentChart.setOption(diagramOption);

        window.onresize = currentChart.resize;
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

var casino = (function () {


});
