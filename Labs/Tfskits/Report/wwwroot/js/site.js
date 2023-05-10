$(document).ready(function () {
    $(".datepicker").datepicker();
    
    if ($("#teamsContainer").length > 0) {
        $("#teamsContainer").load("/home/teams/followedteams");
    }

    $("#ref").change(function () {
        requestTable();
    });
    $("#HasComments").change(function () {
        requestTable();
    });
    /*

    if ($(".followButton").length > 0) {
        $(".followButton").each(function () {
            var button = $(this);
            button.click(
                function () { followOne(button); }
            );
        });
    }

    function followOne(button) {
        var url = "/home/follow/" + button.attr("r");

        $.ajax({
            url: url,
            type: "get",
            dataType: "json",
            success: function (response) {
                console.log(response);
                if (response.team.followed) {
                    button.removeClass("followthem");
                    button.removeClass("bg-warning");
                    button.addClass("unfollow");
                    button.html("followed");
                } else {
                    button.removeClass("unfollow");
                    button.addClass("bg-warning");
                    button.addClass("followthem");
                    button.html("follow them");
                }
            }
        });

        return false;
    }
     $(".author").each(function() {
        $(this).click(function() {
            if ($(this).hasClass("selectedAuthor")) {
                $(this).removeClass("selectedAuthor");
            } else {
                $(this).addClass("selectedAuthor");
            }

            requestTable();

        });
    });

    $("#ref").change(function() {
        requestTable();
    });

    requestTable();
    startSignalR();
    
    */
});

function focusNav(id) {
    $("#" + id).addClass("rotate");
}

function requestIdentities() {
    var limitTeamNames = [];

    limitTeamNames.push($("#LimitTeamNames").val());

    var request = {
        limitTeamNames: limitTeamNames
    };

    $.ajax({
        url: "/home/Identities",
        type: "post",
        data: request,
        dataType: "html",
        success: function (response) {
            $("#membersContainer").html(response);
            $('#offcanvasStart .btn-close').first().click();
        }
    });

    return false;
}

function requestTable() {
    var limitTeamNames = [];
    var limitIdentityIds = [];
    var fromDate = $("#fromDate").val();
    var toDate = $("#toDate").val();
    var keyword = $("#keyword").val();
    var exclude = $("#exclude").val();


    limitTeamNames.push($("#LimitTeamNames").val());

    $("input[name='limitIdentityIds']:checked").each(function () {
        limitIdentityIds.push($(this).val());
    });

    var request = {
        limitTeamNames: limitTeamNames,
        limitIdentityIds: limitIdentityIds,
        fromDate: fromDate,
        toDate: toDate,
        keyword: keyword,
        pageSize: $("#pageSize").val(),
        pageNo: $("#pageNo").val(),
        Ref: $("#ref").val(),
        exclude: exclude,
        hasComments: $("#HasComments").prop("checked")
    };

    $.ajax({
        url: "/home/table",
        type: "post",
        data: request,
        dataType: "html",
        success: function (response) {
            $("#tableContainer").html(response);
        }
    });

    return false;
}

function turnPage(p) {
    $("#pageNo").val(p);
    requestTable();
    return false;
}

function downloadFileByForm() {
    var url = "/home/excel";
    var fileName = "webreport.xls";
    var form = $("<form></form>").attr("action", url).attr("method", "post");

    form.append($("<input></input>").attr("type", "hidden").attr("name", "LimitTeamNames").attr("value", $("#LimitTeamNames").val()));
    form.append($("<input></input>").attr("type", "hidden").attr("name", "HasComments").attr("value", $("#HasComments").prop("checked")));
    form.append($("<input></input>").attr("type", "hidden").attr("name", "fileName").attr("value", fileName));
    form.append(
        $("<input></input>").attr("type", "hidden").attr("name", "fromDate").attr("value", $("#fromDate").val()));
    form.append($("<input></input>").attr("type", "hidden").attr("name", "toDate").attr("value", $("#toDate").val()));
    form.append($("<input></input>").attr("type", "hidden").attr("name", "keyword").attr("value", $("#keyword").val()));
    form.append($("<input></input>").attr("type", "hidden").attr("name", "ref").attr("value", $("#ref").val()));
    form.append($("<input></input>").attr("type", "hidden").attr("name", "exclude").attr("value", $("#exclude").val()));
    $("input[name='limitIdentityIds']:checked").each(function () {
        form.append($("<input></input>").attr("type", "hidden").attr("name", "limitIdentityIds")
            .attr("value", $(this).val()));
    });

    form.appendTo("body").submit().remove();

    return false;
}

var messageConnection = [];
var signalRIsReady = false;
var currentKey = '';

function startSignalR() {
    messageConnection = new signalR.HubConnectionBuilder().withUrl("/notify").build();
    messageConnection.start().then(function () {
        $.notify("SignalR is ready.", "info");
        signalRIsReady = true;
    }).catch(function (err) {
        $.notify(err.toString(), "error");
        return console.error(err.toString());
    });

    messageConnection.on("ReceiveMessage", function (msg) {
        console.log(msg);
        if (msg.to == "web") {
            console.log(currentKey);
            if (currentKey == msg.key) {
                console.log("received callback,render it.");
                if (msg.type == "info" || msg.type == "success" || msg.type == "warn" || msg.type == "error") {
                    $.notify(msg.message, msg.type);
                }

                if (msg.diagram != undefined) {
                    $("#diagram").show(300);
                    $("#diagram").notify('diagram is loading.', 'info');
                    console.log("render tree:" + msg.diagram);
                    renderTree(msg.diagram);
                    $("#HTML").load("/modules/Query/" + msg.html);
                }

                if (msg.fusionLogProcess != "" && msg.fusionLogProcess != null && msg.fusionLogProcess != undefined) {
                    renderFusionLog(msg.fusionLogProcess);
                }
            }
        }
    });
}

function CallConsole(key) {
    if (key != "" && signalRIsReady) {
        currentKey = key;
        $.notify("query about " + key, "info");

        var notify = {
            From: 'web',
            To: 'console',
            Key: key,
            Message: 'Query about ' + key
        };
        console.log(notify);
        $("#diagram").hide();
        $("#HTML").html("");
        messageConnection.invoke("HandleOthersMessage", notify)
            .catch(function (err) {
                signalRIsReady = false;
                return console.error(err.toString());
            });
    }
}

function beforeQuery() {
    if ($("#Keyword").val() == "")
        $("#Keyword").val("syngo.Common.Container.exe");

    CallConsole($("#Keyword").val());

    return false;
}

function renderTree(diagramPath) {
    var chartDom = document.getElementById("diagram");
    echarts.init(chartDom).dispose();
    var myChart = echarts.init(chartDom);
    var option;

    console.log(diagramPath);
    myChart
    myChart.showLoading();
    $.get(diagramPath, function (json) {
        myChart.hideLoading();
        console.log('json');
        console.log(json);
        myChart.setOption(
            (option = {
                tooltip: {
                    trigger: 'item',
                    triggerOn: 'mousemove',
                    borderWidth:10
                },
                series: [
                    {
                        type: 'tree',
                        data: [json.data],
                        top: '5%',
                        bottom: '10%',
                        left: '5%',
                        right: '30%',
                        symbol: 'emptyCircle',
                        edgeForkPosition: '63%',
                        symbolSize: 10,
                        initialTreeDepth: 2,
                        animationDurationUpdate: 300,
                        expandAndCollapse: true,
                        lineStyle: {
                            width: 2
                        },
                        label: {
                            backgroundColor: '#fff',
                            position: 'right',
                            verticalAlign: 'bottom',
                            align: 'left',
                            fontSize: 9,
                            color: 'red'
                        },
                        leaves: {
                            label: {
                                position: 'right',
                                verticalAlign: 'middle',
                                align: 'left',
                                fontSize: 14,
                                color:'black'
                            }
                        },
                        emphasis: {
                            focus: 'descendant'
                        }
                    }
                ]
            })
        );
    });

    option && myChart.setOption(option);

    return false;
}

function renderFusionLog(processName) {
    console.log("/modules/fusionlog/" + processName);
    $("#HTML").load("/modules/fusionlog/" + processName);

    return false;
}

function turnLog(ele) {
    //var element = "#row_" + p;

    //if ($(element).hasClass("hiddenRow")) {
    //    $(element).removeClass("hiddenRow");
    //} else {
    //    $(element).addClass("hiddenRow");
    //}

    $(ele).next().toggle();

    return true;
}

/*
 
function renderSankey(canvasId, keywords) {
    var chartDom = document.getElementById(canvasId);
    var myChart = echarts.init(chartDom);
    var option;

    myChart.showLoading();
    $.get('/data/sankey/' + keywords, function (data) {
        myChart.hideLoading();
        myChart.setOption(
            (option = {
                title: {
                    text: keywords
                },
                tooltip: {
                    trigger: 'item',
                    triggerOn: 'mousemove'
                },
                animation: true,
                series: [
                    {
                        type: 'sankey',
                        emphasis: {
                            focus: 'adjacency'
                        },
                        data: data.nodes,
                        links: data.links,
                        lineStyle: {
                            color: 'gradient',
                            curveness: 0.5
                        }
                    }
                ]
            })
        );
    });

    option && myChart.setOption(option);
}

function renderGraph(canvasId, keywords) {
    var chartDom = document.getElementById(canvasId);
    var myChart = echarts.init(chartDom);
    var option;

    myChart.showLoading();
    $.get('/data/graph/' + keywords, function (graph) {
        myChart.hideLoading();
        option = {
            tooltip: {},
            legend: [
                {
                    data: graph.categories.map(function (a) {
                        return a.name;
                    })
                }
            ],
            series: [
                {
                    name: keywords,
                    type: 'graph',
                    layout: 'none',
                    data: graph.nodes,
                    links: graph.links,
                    categories: graph.categories,
                    roam: true,
                    label: {
                        show: true,
                        position: 'right',
                        formatter: '{b}'
                    },
                    labelLayout: {
                        hideOverlap: true
                    },
                    scaleLimit: {
                        min: 0.4,
                        max: 2
                    },
                    lineStyle: {
                        color: 'source',
                        curveness: 0.3
                    }
                }
            ]
        };
        myChart.setOption(option);
    });

    option && myChart.setOption(option);
}

 */