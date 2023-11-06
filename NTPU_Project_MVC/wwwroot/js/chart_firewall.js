google.charts.load("current", { packages: ["corechart"] });
var chart;
$(document).ready(function () {
    $('#getDataButton').click(function () {
        if (chart != null) {
            chart.clearChart();
        }
        $("#loading-spinner").removeClass("d-none");
        var startDate = $('#startDate').val();
        var endDate = $('#endDate').val();
        $.ajax({
            type: 'POST',
            dataType: 'JSON',
            data: { startDate:startDate , endDate:endDate},
            url: '/FireWall/GetMsgData',
            success: function (response) {
                // Set chart options  
                var options = {
                    title: 'FireWall Msg Group',
                    titleTextStyle: {
                        fontName: 'Segoe UI',
                        fontSize: 20,
                        bold: true            
                    },
                    fontName: 'Segoe UI',
                    is3D: true,
                    backgroundColor: '#e0ffff',
                    legend: { position: 'right', alignment: 'start' }

                };

                // Draw.  
                drawGraph(response, options, 'graphId');
            }
        });
    }); 
});

function drawGraph(dataValues, options, elementId) {
    // Initialization.  
    var data = new google.visualization.DataTable();

    // Setting.    
    data.addColumn('string', 'Message Name');
    data.addColumn('number', 'Count');

    // Processing.  
    for (var i = 0; i < dataValues['data'].length; i++) {
        // Setting.  
        data.addRow([dataValues['data'][i].groupName, dataValues['data'][i].groupCount]);
    }

    // Instantiate and draw our chart, passing in some options.  
    chart = new google.visualization.PieChart(document.getElementById(elementId));
    $("#loading-spinner").addClass("d-none");
    // Draw chart.  
    chart.draw(data, options);
}