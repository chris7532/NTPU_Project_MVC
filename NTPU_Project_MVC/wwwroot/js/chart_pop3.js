google.charts.load("current", { packages: ["corechart"] });
var chart;
var dataTable;
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
            url: '/Pop3/GetHashData',
            success: function (response) {
                // Set chart options  
                var options = {
                    title: 'FTP Msg Group',
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
        loadDataTable(startDate,endDate);


    }); 
    $('#getIpGroupButton').click(function () {
        if (dataTable != null) {
            dataTable.clear();
            dataTable.destroy();
        }
        var hash = $('#hash').val();
        dataTable = $('#tblData_hash').DataTable({
            ajax: {
                type: 'POST',
                dataType: 'JSON',
                data: { hash:hash },
                url: '/Pop3/HashToIpGroup',
            },
            columns: [
                { data: 'gDate', width: "15%" },
                { data: 'gip', width: "15%" },
                { data: 'gCountry', width: "15%" },
                { data: 'gCount', width: "15%" }
            ],
            rowCallback: function (row, data) {
                $('td:eq(0)', row).css('color', 'white');
                $('td:eq(1)', row).css('color', 'white');
                $('td:eq(2)', row).css('color', 'white');
                $('td:eq(3)', row).css('color', 'white');
            }
        });

    });
});

function loadDataTable(startDate, endDate) {
    dataTable = $('#tblData').DataTable({
        ajax: {
            type: 'POST',
            dataType: 'JSON',
            data: { startDate: startDate, endDate: endDate },
            url: '/Pop3/GetHashDataTop20',
        },
        columns: [
            { data: 'groupName', width: "25%" },
            { data: 'groupCount', width: "15%" }
        ],
        rowCallback: function (row, data) {
            $('td:eq(0)', row).css('color', 'white');
            $('td:eq(1)', row).css('color', 'white');
        }
            
    });
}
function drawGraph(dataValues, options, elementId) {
    // Initialization.  
    var data = new google.visualization.DataTable();

    // Setting.    
    data.addColumn('string', 'Hash Name');
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